namespace Plug.Examples.Console
{
    public sealed class ConsoleLogger
    {
        private ISyncEventListener<LampState> _lampStateListener;

        public ISyncEventListenerSocket<LampState> LampStateListener { get { return _lampStateListener; } }

        public ConsoleLogger()
        {
            _lampStateListener = new SyncEventListener<LampState>(LogLampState);
        }

        private void LogLampState(LampState state)
        {
            System.Console.WriteLine("New Lamp State: {0}", state);
        }
    }
}
