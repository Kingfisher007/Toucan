	using System;
    using System.Collections.Generic;
using System.Threading.Tasks;

namespace Toucan.Provider.ServiceDiscovery
	{
		public interface IDiscoveryProvider
		{
			Task<List<Server>> GetServers(string application);
		}
	}