using InterfaceTrain.Intarface;

namespace InterfaceTrain.Entity
{
    class Speaker : IPlayable
    {
        public int Volume { get; } = 80;
        private bool _isBluethoothOn;

        public void Play(string music)
        {
            Console.WriteLine(music);
        }

        public void Stop()
        {
            Console.WriteLine("Музыка не играет");
        }

        public void ConnectBluethooth() => _isBluethoothOn = !_isBluethoothOn; 
    }
}