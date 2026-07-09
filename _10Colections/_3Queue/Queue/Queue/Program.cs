namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //  FIFO первый вошел - первый вышел.

            // Создание пустой очереди (с указанием ёмкости) 
            Queue<string> car = new Queue<string>(16);

            // Создание очереди элементами из другой коллекции
            var employees = new List<string> { "Tom", "Sam", "Bob" };
            Queue<string> people = new Queue<string>(employees);
            foreach (var person in people) Console.WriteLine(person);
            Console.WriteLine(people.Count); // 3


            Queue<string> animal = new Queue<string>();
            
            animal.Enqueue("Dog");
            animal.Enqueue("Cat");

            bool isDog = animal.TryDequeue(out string? dog);
            Console.WriteLine(isDog);

            Queue<string> q = new Queue<string>();
            q.Enqueue("Tom");
            q.Enqueue("Bob");

            // 1. TryDequeue - пытаемся извлечь первый с удалением
            if (q.TryDequeue(out string first))
            {
                Console.WriteLine($"Извлечено: {first}");  // Извлечено: Tom
            }
            else
            {
                Console.WriteLine("Очередь пуста");
            }

            // В очереди сейчас: [Bob]

            // 2. TryPeek - пытаемся посмотреть первый без удаления
            if (q.TryPeek(out string peek))
            {
                Console.WriteLine($"Первый элемент: {peek}");  // Первый элемент: Bob
            }
            else
            {
                Console.WriteLine("Очередь пуста");
            }

            // В очереди сейчас: [Bob] (без изменений)

            // 3. Очищаем очередь
            q.Clear();

            // 4. Пробуем извлечь из пустой очереди
            if (q.TryDequeue(out string empty))
            {
                Console.WriteLine($"Извлечено: {empty}");
            }
            else
            {
                Console.WriteLine("Очередь пуста, извлечь нечего");  // Очередь пуста, извлечь нечего
            }

            // 5. Пробуем посмотреть из пустой очереди
            if (q.TryPeek(out string emptyPeek))
            {
                Console.WriteLine($"Первый элемент: {emptyPeek}");
            }
            else
            {
                Console.WriteLine("Очередь пуста, посмотреть нечего");  // Очередь пуста, посмотреть нечего
            }

        }
    }
}
