	using System;
    using System.Collections.Generic;
	
	namespace Toucan.ServiceDiscovery.Provider
	{
		public interface IServiceRegistration
		{
			void Register(Server server);
			void DeRegister(Server server);
		}
	}