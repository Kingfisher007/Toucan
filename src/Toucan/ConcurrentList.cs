using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Toucan.ServiceDiscovery.Provider;

namespace Toucan
{
    public class ConcurrentList<T> : IList<T>, IReadOnlyList<T>
    {
        ReaderWriterLock rwLock;

        public ConcurrentList()
        {
            rwLock = new ReaderWriterLock();        
        }

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        internal void RemoveAll(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        internal void AddRange(IEnumerable<Server> newServers)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
