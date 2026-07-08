using System;
using System.Globalization;
using System.Xml.Serialization;

namespace LimitationsGeneralizations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SendMessage(new Message("Hello"));


            //Ограничения обобщений в типах
            //Console.WriteLine(new string('@', 50));

            //Messenger<Message> telegram = new Messenger<Message>();
            //telegram.SendMessage(new Message("Hello"));

            //Messenger<EmailMessage> outlook = new Messenger<EmailMessage>();
            //outlook.SendMessage(new EmailMessage("Bye World"));

            //Типы ограничений и стандартные ограничения

            Messenger<Message, Person> telegram = new Messenger<Message, Person>();
            Person tom = new Person("Tom");
            Person bob = new Person("Bob");
            Message hello = new Message("Hello, Bob!");
            telegram.SendMessage(tom, bob, hello);

        }
        public static void SendMessage<T>(T message) where T : Message
        {
            Console.WriteLine($"Сообщение: {message.Text}");
        }
    }
}
