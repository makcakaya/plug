using System;
using System.Collections.Generic;

namespace Plug
{
    public sealed class SyncEventSource<T> : ISyncEventSource<T>
    {
        private readonly IList<Action<T>> _handlers = new List<Action<T>>();

        public void Raise(T arg)
        {
            foreach (var handler in _handlers)
            {
                if (handler != null)
                {
                    handler(arg);
                }
            }
        }

        public void Register(Action<T> handler)
        {
            _handlers.AddIfNotExists(handler);
        }

        public void Unregister(Action<T> handler)
        {
            _handlers.RemoveIfExists(handler);
        }
    }
}
