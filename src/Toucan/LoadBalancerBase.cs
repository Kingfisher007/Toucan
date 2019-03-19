using System;
using System.Collections.Generic;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public abstract class LoadBalancerBase : ILoadBalancer
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

        public abstract T OnNext<T>(string name, Func<Server, Result<T>> func);
    }
}