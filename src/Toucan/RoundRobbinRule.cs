using System;
using System.Collections.Generic;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public class RoundRobbinRule : AbstractRule
    {
        int current;

        public RoundRobbinRule()
        {
            current = -1;
        }

        public override Server GetNext()
        {
            if (current++ == loadBalancerContext.Servers.Count)
            {
                current = 0;
            }
            return loadBalancerContext.Servers[current];
        }
    }
}