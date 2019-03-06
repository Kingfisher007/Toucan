	using System;
    using System.Collections.Generic;
	
	namespace Toucan.ServiceDiscovery.Provider
	{
		public interface IDiscoveryProvider
		{
			List<Server> GetServers(string application);
		}
	}