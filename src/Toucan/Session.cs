using System;
using System.Collections.Generic;

namespace Toucan
{
    public class Session
    {
        IDictionary<string, int> requestCount;
        int totalRequests;
        int cap;

        public Session(int Cap)
        {
            requestCount = new Dictionary<string, int>();
            totalRequests = 0;
            cap = Cap;
        }

        public IDictionary<string, int> Requests
        {
            get
            {
                return requestCount;
            }
        }

        public int TotalRequests
        {
            get
            {
                return totalRequests;
            }
        }

        public void Increment(string serverId)
        {
            if (requestCount[serverId] == 0)
            {
                requestCount[serverId] = requestCount[serverId]++;
            }
            else
            {
                requestCount[serverId] = 1;
            }
            //
            if (++totalRequests == cap)
            {
                Reset();
            }
        }

        public void Reset()
        {
            requestCount.Clear();
        }
    }
}