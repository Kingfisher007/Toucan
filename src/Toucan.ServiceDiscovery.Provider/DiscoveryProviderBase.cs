	using System;
    using System.Collections.Generic;
	
	namespace Toucan.ServiceDiscovery.Provider
	{
		public abstract class DiscoveryProviderBase : IDiscoveryProvider
    {
			IRefreshPolicy RefreshPolicy;
			
			public DiscoveryProviderBase(IRefreshPolicy refreshPolicy)
			{
				RefreshPolicy = refreshPolicy;	
			}
			
			event Action ServicesRefreshed;
			
			protected abstract void Initialise();
			protected abstract void OnBeginRefresh();
			public abstract List<Server> GetServers(string application);
		}
	}