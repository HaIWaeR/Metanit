using InterfaceTrain.Intarface;

namespace InterfaceTrain.Entity
{
    class Phone : IPlayable, IChargeable
    {
        const int BatteryMax = 100;
        public int BatteryLevel { get; private set; } = 30;
        public int Volume { get; set; } = 50;
        public void Play(string music)
        {
            Console.WriteLine($"Сейчас играет трек: {music}");
        }
        public void Stop()
        {
            Console.WriteLine("Музыка остановленна");
        }

        public void Charge(int value)
        {
            if (BatteryLevel + value >= BatteryMax)
                BatteryLevel = 100;
            else
                BatteryLevel += value;

            Console.WriteLine($"Телефон заряжен до {BatteryLevel}%");
        }
    }
}