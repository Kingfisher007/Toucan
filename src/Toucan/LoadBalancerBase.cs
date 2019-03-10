using System;
using System.Collections.Generic;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public abstract class LoadBalancerBase
    {
        protected LoadBalancerContext loadBalancerContext;
        protected string application;
        protected IDiscoveryProvider discoveryProvider;
        protected IRule rule;

        public LoadBalancerBase(string applicationName, IDiscoveryProvider discoveryProvider, IRule rule)
        {
            this.discoveryProvider = discoveryProvider;
            this.rule = rule;
            application = applicationName;
        }

        protected virtual void Initialise()
        {
            List<Server> servers = discoveryProvider.GetServers(application);
            loadBalancerContext = new LoadBalancerContext(servers);
            rule.Initialise(loadBalancerContext);
        }

        public abstract T OnNext<T>(Func<Server, Result<T>> func);
    }
}