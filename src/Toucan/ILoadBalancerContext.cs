    using System;
    using System.Collections.Generic;
	using System.Collections;
using Toucan.ServiceDiscovery.Provider;
	
	namespace Toucan
	{
		public interface ILoadBalancerContext
		{
			List<Server> Servers { get; }
		}
	}