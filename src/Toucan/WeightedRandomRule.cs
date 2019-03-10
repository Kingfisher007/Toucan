using System;
using System.Collections.Generic;
using System.Linq;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public class WeightedRandomRule : AbstractRule
    {
        Random random;
        int totalWeight;
        IReadOnlyList<Server> servers;
        IDictionary<string, int> WeightList;
        Session session;

        public WeightedRandomRule()
        {
            WeightList = new Dictionary<string, int>();
            random = new Random();
            session = new Session(10);
        }

        public override void Initialise(ILoadBalancerContext loadBalancerContext)
        {
            this.loadBalancerContext = loadBalancerContext;
            servers = loadBalancerContext.Servers;
            loadBalancerContext.OnServerListUpdated += ServerListChangedEventHandler;
        }

        protected void ServerListChangedEventHandler(Object sender, ServerListChangeEventArgs args)
        {
            session.Reset();
        }

        public override Server GetNext()
        {
            IList<string> toBeSelected = (from ser in WeightList
                                          join ses in session.Requests on ser.Key equals ses.Key
                                          where ses.Value < ser.Value
                                          select ser.Key).ToList();

            string selected = toBeSelected[random.Next(toBeSelected.Count)];
            session.Increment(selected);
            return loadBalancerContext.Servers.First(s => s.Id.Equals(selected));
        }
    }
}