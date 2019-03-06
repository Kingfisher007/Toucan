 	using System;
    using System.Collections.Generic;
	using System.Linq;
	
	namespace Toucan
	{
		public class Session
		{
			IDictionary<string,int> requestCount;
			
			public Session()
			{
				requestCount = new Dictionary<string,int>();
			}
			
			public IDictionary<string,int> Requests
			{
				get
				{
					return requestCount;
				}
			}
			
			public void Add(string serviceId)
			{
				if(requestCount.Keys.Contains(serviceId))
				{
					requestCount[serviceId] = requestCount[serviceId]++;
				}
				else
				{
					requestCount.Add(serviceId, 1);
				}
			}
			
			public void Reset()
			{
				requestCount.Clear();
			}
		}
	}