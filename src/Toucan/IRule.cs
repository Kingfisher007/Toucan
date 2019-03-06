    using System;
    using System.Collections.Generic;
	using Toucan.ServiceDiscovery.Provider;
	
	namespace Toucan
	{
		public interface IRule
		{
			ILoadBalancerContext LoadBalancerContext { set; }
			Server GetNext();
			void Release(Server server, Status status);
		}	
	}