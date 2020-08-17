using System;
using System.Collections.Generic;

namespace ObjectPool
{
    public interface IObjectPool<T>
        where T : class, new()
    {
        bool AutoCreateObjects { get; set; }
        int MaxPoolSize { get; set; }

        int Count { get; }

        bool Store(T obj);
        bool Grab(out T obj);
        void Clear();
    }
}
