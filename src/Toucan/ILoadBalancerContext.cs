using System;
using System.Collections.Generic;
using Toucan.Provider;
using Toucan.Provider.ServiceDiscovery;

namespace Toucan
{
    public delegate void ServerListUpdated(object sender, ServerListUpdatedEventArgs eventArgs);
    public delegate void ServerStatAdded(object sender, ServerStatAddedEventArgs eventArgs);

    public interface ILoadBalancerContext
    {
        string Application { get; }
        IReadOnlyList<Server> Servers { get; }
        IReadOnlyList<ServerStats> ServerStats { get; }
        event ServerListUpdated OnServerListUpdated;
        event ServerStatAdded OnServerStatsAdded;

        void AddServerStat(Server server, Status status, double duration);
        void UpdateServerList(IList<Server> serversList)
    }
}