using System;

namespace Plug
{
    public interface ISyncEventChannelOutputConnector<T>
    {
        void Register(Action<T> handler);
    }
}
