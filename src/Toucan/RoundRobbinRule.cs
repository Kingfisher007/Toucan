 	using System;
    using System.Collections.Generic;
	using Toucan.ServiceDiscovery.Provider;
	
	namespace Toucan
	{
		public class RoundRobbinRule : IRule
		{
			int current;
			
			public RoundRobbinRule()
			{
				current = -1;	
			}
			
			public ILoadBalancerContext LoadBalancerContext { set; private get; }
			
			public Server GetNext()
			{
				if(current++ == LoadBalancerContext.Servers.Count)
				{
					current = 0;
				}
            return LoadBalancerContext.Servers[current];
			}
			
			public void Release(Server server, Status status)
			{
				
			}
		}
	}