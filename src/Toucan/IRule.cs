using System;
using System.Collections.Generic;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public interface IRule
    {
        void Initialise(ILoadBalancerContext loadBalancerContext);
        Server GetNext();
    }
}