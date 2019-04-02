using System;
using System.Collections.Generic;
using Toucan.Provider.ServiceDiscovery;

namespace Toucan
{
    public class LoadBalancer : LoadBalancerBase
    {
        public LoadBalancer(IDiscoveryProvider discoveryProvider) : base(discoveryProvider)
        {
            
        }

        public override T OnNext<T>(string name, Func<Server, Result<T>> func)
        {
            Status status = Status.Failed;
            int time = DateTime.Now.Millisecond;

            IRule rule = loadBalancers[name];
            if(rule == null)
            {
                return default(T);
            }

            Server server = rule.GetNext();
            if (server == null)
            {
                return default(T);
            }

            try
            {
                Result<T> result = func(server);
                if (result == null)
                {
                    return default(T);
                }
                else
                {
                    status = result.Status;
                    return result.Value;
                }
            }
            finally
            {
                time = DateTime.Now.Millisecond - time;
                rule.LoadBalancerContext.AddServerStat(server, status, time);
            }
        }
    }
}