using System;
using System.Collections.Generic;
using System.Text;
using Toucan.ServiceDiscovery.Provider;


namespace Toucan
{
class LoadBalancerBuilder
{
	IDiscoveryProvider serviceDiscovery;
	ILoadBalancer loadBalancer;
	IRule rule;
	Option option;
	
	public LoadBalanceBuilder(IDiscoveryProvider serviceDiscovery)
	{
		
	}
	
	public void New(string appname)
	{
		option = new LoadBalancerContext(appname);
	}
	
	public void WithRule(Func<Options, IRule> RuleCreator)
	{
		rule = RuleCreator(option);
	}
	
	public ILoadBaLancer Create()
	{
            return new LoadBalancer(serviceDiscovery, option.LoadBalancerContext, rule);
	}
}
}