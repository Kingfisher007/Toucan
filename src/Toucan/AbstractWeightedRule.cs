using System;
using System.Collections.Generic;
using System.Linq;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public abstract class AbstractWeightedRule : AbstractRule
    {
        protected IReadOnlyList<Server> servers;
        protected Session session;
        
        public AbstractWeightedRule(ILoadBalancerContext lbContext):base(lbContext)
        {
            session = new Session(10);
            servers = loadBalancerContext.Servers;
            loadBalancerContext.OnServerListUpdated += ServerListChangedEventHandler;
        }

        protected void ServerListChangedEventHandler(Object sender, ServerListChangeEventArgs args)
        {
            session.Reset();
        }

        protected IList<Server> GetServersList()
        {
            return (from ser in servers
                    join ses in session.Requests on ser.Application equals ses.Key
                    where ses.Value < ser.Weight
                    select ser).ToList();
        }
    }
}