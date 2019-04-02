using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Toucan.Provider;

namespace Toucan.Provider.HealthCheck
{
	public interface IHealthCheck
	{
		bool IsAlive(Server server);
	}
}