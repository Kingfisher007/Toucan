using System;
using System.Collections.Generic;
using System.Text;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public abstract class AbstractRule : IRule
    {
        protected ILoadBalancerContext loadBalancerContext;

        public AbstractRule(ILoadBalancerContext lbContext)
        {
            loadBalancerContext = lbContext;
        }

        public string Application { get { return loadBalancerContext.Application; } }

        public ILoadBalancerContext LoadBalancerContext { get { return loadBalancerContext; } }

        public abstract Server GetNext();
    }
}
