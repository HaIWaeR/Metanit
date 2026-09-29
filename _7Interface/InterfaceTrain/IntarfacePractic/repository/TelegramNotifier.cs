using IntarfacePractic.Interface;

namespace IntarfacePractic.repository
{
    public class TelegramNotifier : INotifier
    {
        public string Name { get; private set; }

        public TelegramNotifier(string name)
        {
            Name = name;
        }

        public void Send(string message)
        {
            Console.WriteLine($"На Telegram: @{Name}, пришло сообщение: {message}");
        }

        public void SendSticker(string sticker)
        {
            Console.WriteLine("\")");
        }
    }
}
