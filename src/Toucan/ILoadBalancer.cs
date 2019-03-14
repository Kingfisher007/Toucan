using System;
using System.Collections.Generic;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public interface ILoadBalancer
    {
        T OnNext<T>(Func<Server, Result<T>> func);
    }
}