using System;
using System.Collections.Generic;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public interface ILoadBalancer
    {
        void AddApplication(IRule rule);
        T OnNext<T>(string application, Func<Server, Result<T>> func);
    }
}