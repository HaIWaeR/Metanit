using IntarfacePractic.Interface;

namespace IntarfacePractic.repository
{
    public class EmailNotifier : INotifier
    {
        public string Name { get; private set; }

        public EmailNotifier(string name)
        {
            Name = name;
        }

        public void Send(string message)
        {
            Console.WriteLine($"На Email: {Name}, пришло новое сообщение: {message}");
        }
    }
}
