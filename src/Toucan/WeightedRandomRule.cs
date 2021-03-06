using System;
using System.Collections.Generic;
using System.Linq;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public class WeightedRandomRule : AbstractWeightedRule
    {
        Random random;

        public WeightedRandomRule(ILoadBalancerContext lbContext):base(lbContext)
        {
            random = new Random();
        }

        public override Server GetNext()
        {
            IList<Server> toBeSelected = GetServersList();

            Server selected = toBeSelected[random.Next(toBeSelected.Count)];
            session.Increment(selected.Application);
            return selected;
        }
    }
}