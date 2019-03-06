    using System;
    using System.Collections.Generic;
	using Toucan.ServiceDiscovery.Provider;
	
	namespace Toucan
	{
		public abstract class LoadBalancerBase
		{
			protected ILoadBalancerContext loadBalancerContext;
			protected string application;
		
			public LoadBalancerBase(string applicationName, IDiscoveryProvider discoveryProvider, IRule rule)
			{
				DiscoveryProvider = discoveryProvider;
				Rule = rule;
				application = applicationName;
			}
			
			protected IDiscoveryProvider DiscoveryProvider { get; }
			protected IRule Rule { get; }
			
			protected virtual void Initialise()
			{
				List<Server> servers = DiscoveryProvider.GetServers(application);
				loadBalancerContext = new LoadBalancerContext(servers);
				Rule.LoadBalancerContext = loadBalancerContext;	
			}
			
			public abstract T OnNext<T>(Func<Server, Result<T>> func);
		}	
	}