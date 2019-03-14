using System;
using System.Collections.Generic;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public delegate void ServerListUpdated(object sender, ServerListChangeEventArgs eventArgs);
    public delegate void ServerStatAdded(object sender, ServerStatChangedEventArgs eventArgs);

    public interface ILoadBalancerContext
    {
        string Application { get; }
        IReadOnlyList<Server> Servers { get; }
        IReadOnlyList<ServerStats> ServerStats { get; }
        event ServerListUpdated OnServerListUpdated;
        event ServerStatAdded OnServerStatsAdded;
    }
}