 	using System;
    using System.Collections.Generic;
	using System.Linq;
	using Toucan.ServiceDiscovery.Provider;
	
	namespace Toucan
	{
		public class WeightedRandomRule : IRule
		{
			Random random;
			ILoadBalancerContext loadBalancerContext;
			int totalWeight;
			IList<ServerStats> serverStats;
			
			public WeightedRandomRule()
			{
				serverStats = new List<ServerStats>();
				random = new Random();		
			}
			
			public ILoadBalancerContext LoadBalancerContext 
			{ 
				set 
				{
					loadBalancerContext = value;
					totalWeight = loadBalancerContext.Servers.Sum(s => s.Weight);	
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