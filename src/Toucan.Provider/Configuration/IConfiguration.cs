using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Toucan.Provider.Configuration
{
	public interface IConfiguration
	{
		T GetValue<T>(string key);
	}
}