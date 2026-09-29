using IntarfacePractic.Interface;
using IntarfacePractic.repository;
using IntarfacePractic.Services;
using System.Runtime.InteropServices.Marshalling;

namespace IntarfacePractic
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------------------------------------------------------------
            // Для тестов классов
            EmailNotifier gmail = new EmailNotifier("Gmail.com");
            gmail.Send("Ты видел новости?");

            TelegramNotifier haiwaer = new TelegramNotifier("HaIWaeR");
            haiwaer.Send("Ты чего почту не читаешь?");

            SmsNotifier megafon = new SmsNotifier("Megafon");
            megafon.Send("Ты хоть где то читаешь?");

            //----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            // Для того что бы подменить в цикле и проверить вывод ошибки
            List<INotifier> Bob = new List<INotifier>();

            List<INotifier> Sam = new List<INotifier>()
            {
                new EmailNotifier("Mail"),
                new TelegramNotifier("L8pexa"),
                new SmsNotifier("+79227452045")
            };

            try
            {
                NotifyAll(Sam, "Ты проект доделал?");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            OrderService mail = new OrderService(new EmailNotifier("vital.com"));
            OrderService telegram = new OrderService(new TelegramNotifier("@haiwaer"));
            OrderService sms = new OrderService(new SmsNotifier("+99999999999"));

            mail.CompleteOrder(1);
            telegram.CompleteOrder(5);
            sms.CompleteOrder(3);

            //----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            var services = new ServicesCollection();

            INotifier notifier = new EmailNotifier("vital.com"); // Место выбора

            OrderService orders = new OrderService(notifier);
            ClientServices clients = new ClientServices(notifier);

            orders.CompleteOrder(1);
            clients.Register("Sam");
        }

        static public void NotifyAll(List<INotifier> notifiers, string message)
        {
            if (notifiers == null || notifiers.Count == 0)
            {
                throw new ArgumentException("Notifiers is empty");
            }

            foreach (INotifier notifier in notifiers)
            {
                notifier.Send(message);
            }
        }
    }
}