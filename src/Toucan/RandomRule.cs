using System;
using System.Linq;
using System.Collections.Generic;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public class RandomRule : AbstractRule
    {
        Random random;

        public RandomRule(ILoadBalancerContext lbContext) : base (lbContext)
        {
            random = new Random();
        }

        public override Server GetNext()
        {
            int index = loadBalancerContext.Servers.Count;
            if (index < 0)
            {
                return null;
            }

            return loadBalancerContext.Servers[random.Next(index)];
        }
    }
}