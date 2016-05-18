using System;

namespace Plug
{
    public sealed class SyncEventListener<T> : ISyncEventListener<T>
    {
        private readonly Action<T> _handler;

        public SyncEventListener(Action<T> handler)
        {
            if (handler == null) { throw new ArgumentNullException(nameof(handler)); }

            _handler = handler;
        }

        public void Connect(ISyncEventChannelOutputConnector<T> outputConnector)
        {
            outputConnector.Register(_handler);
        }
    }
}
