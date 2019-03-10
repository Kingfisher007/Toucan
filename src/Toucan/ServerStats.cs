using System;
using System.Collections.Generic;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public class ServerStats
    {
        Server server;
        int successfulRequests;
        int failedRequests;
        double lastRequestDuration;

        public ServerStats(Server server)
        {
            this.server = server;
        }

        public Server Server
        {
            get
            {
                return server;
            }
        }

        public int Requests
        {
            get
            {
                return successfulRequests + failedRequests;
            }
        }

        public int SuccessRequests
        {
            get
            {
                return successfulRequests;
            }
        }

        public int FailedRequests
        {
            get
            {
                return failedRequests;
            }
        }

        public double LastRequestDuration
        {
            get
            {
                return lastRequestDuration;
            }
        }

        public void AddRequestResult(Status result, double timeForRequest)
        {
            if (Status.Success == result)
            {
                successfulRequests++;
            }
            else
            {
                failedRequests++;
            }
        }
    }
}