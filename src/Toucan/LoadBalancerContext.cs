using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public class LoadBalancerContext : ILoadBalancerContext
    {
        protected List<Server> servers;
        protected List<ServerStats> serverStats;
        public event ServerListUpdated OnServerListUpdated;
        public event ServerStatAdded OnServerStatsAdded;

        public LoadBalancerContext(string application, List<Server> _servers)
        {
            Application = application;
            servers = _servers;
        }

        public string Application
        {
            get;
            protected set;
        }

        public IReadOnlyList<Server> Servers { get { return servers; } }
        public IReadOnlyList<ServerStats> ServerStats { get { return serverStats; } }

        internal void RaiseServerListChanged(ServerListChangeEventArgs EventArgs)
        {
            OnServerListUpdated?.Invoke(this, EventArgs);
        }

        public void UpdateServerList(IList<Server> serversList)
        {
            var newServers = from s in serversList
                             where !serversList.Contains(s)
                             select s;
            servers.AddRange(newServers);
            servers.RemoveAll(s => !serversList.Contains(s));
        }

        public void AddServerStat(Server server, Status status, double duration)
        {
            ServerStats stat = serverStats.FirstOrDefault(st => st.Server.Id == server.Id);
            if (stat == null)
            {
                stat = new ServerStats(server);
            }
            stat.AddRequestResult(status, duration);
            RaiseServerStatChanged(stat);
        }

        internal void RaiseServerStatChanged(ServerStats stat)
        {
            OnServerStatsAdded?.Invoke(this, new ServerStatChangedEventArgs());
        }
    }
}