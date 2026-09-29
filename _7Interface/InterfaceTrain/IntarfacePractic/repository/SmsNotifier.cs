using IntarfacePractic.Interface;

namespace IntarfacePractic.repository
{
    public class SmsNotifier : INotifier
    {
        public string Name { get; private set; }

        public SmsNotifier(string name)
        {
            Name = name;
        }

        public void Send(string message)
        {
            Console.WriteLine($"Sms: {Name}, {DateTime.Now}: {message}");
        }
    }
}
