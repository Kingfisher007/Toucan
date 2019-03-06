 	using System;
    using System.Collections.Generic;
	using Toucan.ServiceDiscovery.Provider;
	
	namespace Toucan
	{
		public class RandomRule : IRule
		{
			Random random;
			ILoadBalancerContext loadBalancerContext;
			
			public RandomRule()
			{
				random = new Random();
			}
			
			public ILoadBalancerContext LoadBalancerContext
            { 
				set 
				{
					loadBalancerContext = value;			
				} 
			}

        public Server GetNext()
			{
				int index = loadBalancerContext.Servers.Count;
				if(index < 0)
				{
					return null;
				}
				
				return loadBalancerContext.Servers[random.Next(index)];	
			}
			
			public void Release(Server server, Status status)
			{
				
			}
		}
	}