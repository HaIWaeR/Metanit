using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitationsGeneralizations
{
    class Messenger<T, P> 
    where T : Message
    where P : Person
    {
        public void SendMessage(P sender, P receiver, T message)
        {
            Console.WriteLine($"Отправитель: {sender.Name}");
            Console.WriteLine($"Получатель: {receiver.Name}");
            Console.WriteLine($"Сообщение: {message.Text}");
        }
    }

    class Person
    {
        public string Name { get; }
        public Person(string name)
        {
            Name = name;
        }
    }

    class Message
    {
        public string Text { get; }

        public Message(string text)
        {
            Text = text;
        }
    }

    class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
    }
}
