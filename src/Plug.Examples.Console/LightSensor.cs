namespace Plug.Examples.Console
{
    public sealed class LightSensor
    {
        private ISyncEventSource<LightState> _stateChangeEvent = new SyncEventSource<LightState>();

        public ISyncEventSourceSocket<LightState> StateChangeEvent { get { return _stateChangeEvent; } }
        public LightState LightState { get; private set; }

        public LightSensor(LightState initialLightState)
        {
            LightState = initialLightState;
        }

        public void ChangeState(LightState state)
        {
            if (LightState != state)
            {
                LightState = state;
                _stateChangeEvent.Raise(state);
            }
        }
    }
}
