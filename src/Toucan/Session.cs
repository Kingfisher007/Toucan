using System;
using System.Collections.Generic;

namespace Toucan
{
    public class Session
    {
        IDictionary<string, int> requests;
        int requestCount;
        int cap;

        public Session(int Cap)
        {
            requests = new Dictionary<string, int>();
            requestCount = 0;
            cap = Cap;
        }

        public IDictionary<string, int> Requests
        {
            get
            {
                return requests;
            }
        }

        public int TotalRequests
        {
            get
            {
                return requestCount;
            }
        }

        public void Increment(string serverId)
        {
            if (requests[serverId] == 0)
            {
                requests[serverId] = requests[serverId]++;
            }
            else
            {
                requests[serverId] = 1;
            }
            //
            if (++requestCount == cap)
            {
                Reset();
            }
        }

        public void Reset()
        {
            requests.Clear();
        }
    }
}