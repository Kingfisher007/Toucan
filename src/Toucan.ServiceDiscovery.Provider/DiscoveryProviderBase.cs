using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Toucan.ServiceDiscovery.Provider
{
    public abstract class DiscoveryProviderBase : IDiscoveryProvider, IServiceRegistration
    {
        public DiscoveryProviderBase()
        {

        }

        protected abstract void Initialise();
        public abstract Task Register(Server server);
        public abstract Task DeRegister(Server server);
        public abstract Task<List<Server>> GetServers(string application);
    }
}