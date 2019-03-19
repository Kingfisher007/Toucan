	using System;
  using System.Collections.Generic;
	
	namespace Toucan.ServiceDiscovery.Provider
	{
		public abstract class DiscoveryProviderBase : IDiscoveryProvider, IServiceRegistration
    {
			public DiscoveryProviderBase()
			{
					
			}
			
			event Action ServicesRefreshed;
			
			protected abstract void Initialise();
			protected abstract void OnBeginRefresh();
			public abstract void Register(Server server);
			public abstract void DeRegister(Server server);
			public abstract List<Server> GetServers(string application);
		}
	}