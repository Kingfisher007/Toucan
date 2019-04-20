using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Toucan.Provider;
using Toucan.Provider.ServiceDiscovery;

namespace Toucan
{
    public abstract class LoadBalancerBase : ILoadBalancer
    {
        protected string application;
        protected IDiscoveryProvider discoveryProvider;
        protected IDictionary<string, IRule> loadBalancers;

        public LoadBalancerBase(IDiscoveryProvider discoveryProvider)
        {
            this.discoveryProvider = discoveryProvider;
            loadBalancers = new Dictionary<string, IRule>();
        }

        public void AddApplication(IRule rule)
        {
            loadBalancers.Add(rule.Application, rule);
        }

        public async Task Init()
        {
            await GetServersList();
        }

        protected async Task GetServersList()
        {
            Task[] tasks = new Task[loadBalancers.Count];
            int count = 0;
            foreach(var lb in loadBalancers)
            {
                string application = lb.Key;
                IRule current = lb.Value;
                tasks[count] = Task.Run(async () => {
                                                        List<Server> servers = await discoveryProvider.GetServers(application);
                                                        current.LoadBalancerContext.UpdateServerList(servers);
                                                    });
                count++;
            }

            await Task.WhenAll(tasks);
        }

        public abstract Task<T> OnNext<T>(string name, Func<Server, Task<Result<T>>> func);
    }
}