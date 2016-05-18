namespace Plug
{
    public interface ISyncEventListenerSocket<T>
    {
        void Connect(ISyncEventChannelOutputConnector<T> outputConnector);
    }
}
