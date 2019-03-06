    using System;
    using System.Collections.Generic;
	using Toucan.ServiceDiscovery.Provider;
	
	namespace Toucan
	{
		public class LoadBalancerContext : ILoadBalancerContext
		{
        protected List<Server> servers;
			
			public LoadBalancerContext(List<Server> _servers)
			{
				servers = _servers;
			}
			
			public List<Server> Servers { get { return servers;} }
		}	
	}