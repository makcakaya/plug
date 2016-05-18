namespace Plug
{
    public interface ISyncEventSource<T> : ISyncEventSourceSocket<T>
    {
        void Raise(T arg);
    }
}
