using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Toucan.Provider.ServiceDiscovery;

namespace Toucan
{
    public class ConcurrentList<T> : IList<T>, IReadOnlyList<T>
    {
        List<T> items;
        ReaderWriterLockSlim rwLock;

        public ConcurrentList()
        {
            rwLock = new ReaderWriterLockSlim(); 
            items = new List<T>();       
        }

        public T this[int index] 
        { 
            get
            {
                try 
                { 
                    rwLock.EnterReadLock();
                    return this.items[index]; 
                }
                finally
                {
                    rwLock.ExitReadLock();
                } 
            } 
            set
            {
                try 
                { 
                    rwLock.EnterWriteLock();
                    this.items[index] = value;
                }
                finally
                {
                    rwLock.ExitWriteLock();
                } 
            } 
        }

        public int Count
        {
            get 
            { 
                try 
                { 
                    rwLock.EnterReadLock();
                    return this.items.Count; 
                }
                finally
                {
                    rwLock.ExitReadLock();
                } 
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            try 
            { 
                rwLock.EnterWriteLock();
                this.items.Add(item); 
            }
            finally
            {
                rwLock.ExitWriteLock();
            } 
        }

        public void Clear()
        {
            try 
            { 
                rwLock.EnterWriteLock();
                this.items.Clear(); 
            }
            finally
            {
                rwLock.ExitWriteLock();
            } 
        }

        public bool Contains(T item)
        {
            try 
            { 
                rwLock.EnterReadLock();
                return this.items.Contains(item); 
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            try 
            { 
                rwLock.EnterReadLock();
                this.items.CopyTo(array, arrayIndex); 
            }
            finally
            {
                rwLock.ExitReadLock();
            } 
        }

        public IEnumerator<T> GetEnumerator()
        {
            try 
            { 
                rwLock.EnterReadLock();
                return this.items.GetEnumerator(); 
            }
            finally
            {
                rwLock.ExitReadLock();
            } 
        }

        public int IndexOf(T item)
        {
            try 
            { 
                rwLock.EnterReadLock();
                return this.items.IndexOf(item); 
            }
            finally
            {
                rwLock.ExitReadLock();
            } 
        }

        public void Insert(int index, T item)
        {
            try 
            { 
                rwLock.EnterWriteLock();
                this.items.Insert(index, item);
            }
            finally
            {
                rwLock.ExitWriteLock();
            } 
        }

        public bool Remove(T item)
        {
            try 
            { 
                rwLock.EnterWriteLock();
                return this.items.Remove(item); 
            }
            finally
            {
                rwLock.ExitWriteLock();
            } 
        }

        public void RemoveAt(int index)
        {
            try 
            { 
                rwLock.EnterWriteLock();
                this.items.RemoveAt(index);
            }
            finally
            {
                rwLock.ExitWriteLock();
            } 
        }

        internal void RemoveAll(Predicate<T> p)
        {
            try 
            { 
                rwLock.EnterWriteLock();
                this.items.RemoveAll(p); 
            }
            finally
            {
                rwLock.ExitWriteLock();
            } 
        }

        internal void AddRange(IEnumerable<T> newServers)
        {
            try 
            { 
                rwLock.EnterWriteLock();
                this.items.AddRange(newServers); 
            }
            finally
            {
                rwLock.ExitWriteLock();
            } 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            try 
            { 
                rwLock.EnterReadLock();
                return this.items.GetEnumerator(); 
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }
    }
}
