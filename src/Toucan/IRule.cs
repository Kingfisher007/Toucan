using System;
using System.Collections.Generic;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public interface IRule
    {
        Server GetNext();
    }
}