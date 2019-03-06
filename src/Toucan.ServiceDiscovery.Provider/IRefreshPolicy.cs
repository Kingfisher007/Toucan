	using System;
    using System.Collections.Generic;
	
	namespace Toucan.ServiceDiscovery.Provider
	{
		public interface IRefreshPolicy
		{
			event Action BeginRefresh;	
		}
	}