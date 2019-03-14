using System;
using System.Collections.Generic;
using System.Text;

namespace Toucan
{
class LoadBalancerBuilderContext
{
	protected string appName;
	ILoadBalancerContext loadBalncerContext;
	
	public LoadBalancerBuilderContext(string appname)
	{
		loadBalancerContext = new LoadBalancerContext(appname);
		appName = appname
	}
	
	public string AppName
	{
		get
		{
			return appName;
		}
	}
	
	public ILoadBalancerContext
	{
		get
		{
			return loadBalancerContext;
		}
	}
}
}