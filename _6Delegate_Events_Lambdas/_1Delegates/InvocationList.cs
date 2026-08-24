namespace Delegates
{
    public class InvocationList
    {
        delegate void Message();

        public void ShowInfo()
        {
            // Добавление метода в список 
            Message? message = HelloMethod;
            message += GoodByeMethod;
            message += GoodByeMethod;
            message();

            // Удаление метода из списка
            Console.WriteLine();
            message -= GoodByeMethod;
            if (message != null) message();

            // Вывод методов в списке
            Console.WriteLine();
            foreach (Delegate d in message.GetInvocationList())
            {
                Console.WriteLine(d.Method.Name);
            }
        }

        // Методы с выводом инфомрации
        public void GoodByeMethod()
        {
            Console.WriteLine("Good bye");
        }
        public void HelloMethod()
        {
            Console.WriteLine("Hello");
        }
    }
}
