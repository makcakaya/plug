using System;

namespace Plug
{
    public sealed class SyncEventChannel<T> : ISyncEventChannel
    {
        private readonly ISyncEventSourceSocket<T> _source;
        private readonly ISyncEventListenerSocket<T> _listener;
        private readonly SyncEventChannelOutputConnector<T> _outputter = new SyncEventChannelOutputConnector<T>();

        public SyncEventChannel(ISyncEventSourceSocket<T> source, ISyncEventListenerSocket<T> listener)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            if (listener == null) { throw new ArgumentNullException(nameof(listener)); }

            _source = source;
            _listener = listener;
        }

        public void Connect()
        {
            _listener.Connect(_outputter);
            _source.Register(_outputter.Handler);
        }

        public void Disconnect()
        {
            _source.Unregister(_outputter.Handler);
        }

        private class SyncEventChannelOutputConnector<TOut> : ISyncEventChannelOutputConnector<TOut>
        {
            public Action<TOut> Handler { get; private set; }

            public void Register(Action<TOut> handler)
            {
                Handler = handler;
            }
        }
    }
}
