using System;
using System.Collections.Generic;

namespace ObjectPool
{
    public class ObjectPool<T> : IObjectPool<T> where T : class, new()
    {
        private Queue<T> _queue = new Queue<T>();

        public bool AutoCreateObjects { get; set; } = true;
        public int MaxPoolSize { get; set; } = 0;

        public int Count => _queue.Count;

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Grab(out T obj)
        {
            throw new NotImplementedException();
        }

        public bool Store(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
