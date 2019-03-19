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
        public abstract Server GetNext();
    }
}
