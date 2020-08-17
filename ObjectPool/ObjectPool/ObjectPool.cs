using System;
using System.Collections.Generic;

namespace ObjectPool
{
    public class ObjectPool<T> : IObjectPool<T>
        where T : class, new()
    {
        private Stack<T> _stack = new Stack<T>();

        public bool AutoCreateObjects { get; set; }
        public int MaxPoolSize { get; set; }

        public int Count => _stack.Count;

        public void Clear()
        {
            _stack.Clear();
        }

        public bool Grab(out T obj)
        {
            if (_stack.Count > 0)
            {
                obj = _stack.Pop();
                return true;
            }
            else if (AutoCreateObjects)
            {
                obj = new T();
                return true;
            }
            else
            {
                obj = null;
                return false;
            }
        }

        public bool Store(T obj)
        {
            if (MaxPoolSize == 0 || _stack.Count < MaxPoolSize)
            {
                _stack.Push(obj);
                return true;
            }
            else
                return false;
        }
    }
}
