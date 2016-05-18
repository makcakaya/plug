namespace Plug.Examples.Console
{
    public sealed class StreetLamp
    {
        private LampState _lampState;
        private readonly ISyncEventSource<LampState> _lampStateEventSource = new SyncEventSource<LampState>();
        private readonly ISyncEventListener<LightState> _lightStateListener;

        public ISyncEventSourceSocket<LampState> LampStateChangeEvent { get { return _lampStateEventSource; } }
        public ISyncEventListenerSocket<LightState> LightStateListener { get { return _lightStateListener; } }

        public StreetLamp(LampState initialLampState)
        {
            _lampState = initialLampState;
            _lightStateListener = new SyncEventListener<LightState>(HandleLightStateChange);
        }

        private void HandleLightStateChange(LightState newState)
        {
            if (newState == LightState.Dark)
            {
                if (_lampState == LampState.Off)
                {
                    _lampState = LampState.On;
                    _lampStateEventSource.Raise(_lampState);
                }
            }
            else if (newState == LightState.Light)
            {
                if (_lampState == LampState.On)
                {
                    _lampState = LampState.Off;
                    _lampStateEventSource.Raise(_lampState);
                }
            }
        }
    }
}