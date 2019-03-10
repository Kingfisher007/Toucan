using System;
using System.Collections.Generic;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public class Result<T>
    {
        public Result(Status status, T value)
        {
            Status = status;
            Value = value;
        }

        public Status Status
        {
            get;
            protected set;
        }

        public T Value
        {
            get;
            protected set;
        }
    }
}