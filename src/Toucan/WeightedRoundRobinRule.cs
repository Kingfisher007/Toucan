using System;
using System.Collections.Generic;
using System.Linq;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public class WeightedRoundRobinRule : AbstractWeightedRule
    {
        int current;

        public WeightedRoundRobinRule(ILoadBalancerContext lbContext):base(lbContext)
        {
            current = 0;
        }

        public override Server GetNext()
        {
            IList<Server> toBeSelected = GetServersList();

            if(++current >= toBeSelected.Count)
            {
                current = 0;
            }
            Server selected = toBeSelected[current];
            session.Increment(selected.Application);
            return selected;
        }
    }
}