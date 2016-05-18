using System.Threading;

namespace Plug.Examples.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var lightSensor = new LightSensor(LightState.Light);
            var streetLamp = new StreetLamp(LampState.Off);
            var consoleLogger = new ConsoleLogger();

            var sensorLampEventChannel = new SyncEventChannel<LightState>(lightSensor.StateChangeEvent, streetLamp.LightStateListener);
            sensorLampEventChannel.Connect();

            var lampConsoleEventChannel = new SyncEventChannel<LampState>(streetLamp.LampStateChangeEvent, consoleLogger.LampStateListener);
            lampConsoleEventChannel.Connect();

            for (int i = 0; i < 10; i++)
            {
                lightSensor.ChangeState(lightSensor.LightState == LightState.Dark ? LightState.Light : LightState.Dark);

                Thread.Sleep(2000);
                if (i == 5)
                {
                    sensorLampEventChannel.Disconnect();
                }
            }

            System.Console.WriteLine("Program has ended.");
            System.Console.ReadLine();
        }
    }
}
