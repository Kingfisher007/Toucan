	using System;
    using System.Collections.Generic;
using System.Threading.Tasks;

namespace Toucan.ServiceDiscovery.Provider
	{
		public interface IServiceRegistration
		{
			Task Register(Server server);
			Task DeRegister(Server server);
		}
	}