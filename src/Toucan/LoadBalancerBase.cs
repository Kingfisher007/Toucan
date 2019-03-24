using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Toucan.ServiceDiscovery.Provider;

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

        protected async Task Refresh()
        {
            Task[] tasks = new Task[loadBalancers.Count];
            int count = 0;
            foreach(var lb in loadBalancers)
            {
                IRule current = lb.Value;
                string application = lb.Key;
                tasks[count] = Task.Run(async () => {
                    List<Server> servers = await discoveryProvider.GetServers(application);
                    current.LoadBalancerContext.Update(servers);
                                              });
                count++;
            }

            await Task.WhenAll(tasks);
        }

        public abstract T OnNext<T>(string name, Func<Server, Result<T>> func);
    }
}