using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Toucan.Provider;
using Toucan.Provider.ServiceDiscovery;

namespace Toucan
{
    public interface ILoadBalancer
    {
        Task Init();
        void AddApplication(IRule rule);
        Task<T> OnNext<T>(string application, Func<Server, Task<Result<T>>> func);
    }
}