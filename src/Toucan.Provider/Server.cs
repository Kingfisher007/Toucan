    using System;
    using System.Collections.Generic;
	
	namespace Toucan.Provider
	{
		public class Server
		{
			public Server(string application, string id, string address)
			{
				Application = application;
				Id = id;
				Address = address;
			}
			
			public string Application
			{
				get;
				protected set;
			}
			
			public string Id
			{
				get;
				protected set;
			}
			
			public string Address
			{
				get;
				protected set;
			}
			
			public int Weight
			{
				get;
				set;
			}
			
			public bool IsAlive
			{
				get;
				set;
			}
		}	
	}