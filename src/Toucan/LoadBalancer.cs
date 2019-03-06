	using System;
    using System.Collections.Generic;
	using Toucan.ServiceDiscovery.Provider;
	
	namespace Toucan
	{
		public class LoadBalancer : LoadBalancerBase
		{
			public LoadBalancer(string application, IDiscoveryProvider discoveryProvider, IRule rule) : base (application, discoveryProvider, rule)
			{
			
			}
			
			public override T OnNext<T>(Func<Server, Result<T>> func)
			{
				Status status = Status.Failed;
				
				Server server = Rule.GetNext();
				if(server == null)
				{
					return default(T);
				}
				
				try
				{
					Result<T> result = func(server);
					if(result == null)
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
					Rule.Release(server, status);
				}
			}
		}
	}