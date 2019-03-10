using System;
using System.Collections.Generic;
using System.Text;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public abstract class AbstractRule : IRule
    {
        protected ILoadBalancerContext loadBalancerContext;

        public abstract Server GetNext(); 
        public virtual void Initialise(ILoadBalancerContext loadBalancerContext)
        {
            this.loadBalancerContext = loadBalancerContext;
        }
    }
}
