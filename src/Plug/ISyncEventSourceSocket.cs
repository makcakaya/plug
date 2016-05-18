using System;

namespace Plug
{
    public interface ISyncEventSourceSocket<T>
    {
        void Register(Action<T> handler);
        void Unregister(Action<T> handler);
    }
}
