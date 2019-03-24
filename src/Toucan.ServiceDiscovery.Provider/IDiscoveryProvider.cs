	using System;
    using System.Collections.Generic;
using System.Threading.Tasks;

namespace Toucan.ServiceDiscovery.Provider
	{
		public interface IDiscoveryProvider
		{
			Task<List<Server>> GetServers(string application);
		}
	}