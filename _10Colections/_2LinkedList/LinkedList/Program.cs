using System.Collections.Generic;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> car = new LinkedList<string>();


            var employees = new List<string> { "Tom", "Sam", "Bob" };
            LinkedList<string> people = new LinkedList<string>(employees);
            foreach (string person in people)
            {
                Console.WriteLine(person);
            }

            // LinkedListNode
            LinkedList<string> names = new LinkedList<string>();
            names.AddLast("Tom");
            names.AddLast("Bob");
            names.AddLast("Sam");

            Console.WriteLine(names.Count);            // 3
            Console.WriteLine(names.First?.Value);    // Tom
            Console.WriteLine(names.Last?.Value);    // Bob


            // Получаем первый узел
            LinkedListNode<string> firstNode = names.First;
            Console.WriteLine(firstNode.Value); // Tom
            Console.WriteLine(firstNode.Next.Value); // Bob
            Console.WriteLine(firstNode.Previous.Value); // null (Перед ним ничего нету)


            // Получаем последний узел
            LinkedListNode<string> lastNode = names.Last;
            Console.WriteLine(lastNode.Value); // Sam
            Console.WriteLine(lastNode.Next.Value); // null (После него ничего нету)
            Console.WriteLine(lastNode.Previous.Value); // Bob


            // Поиск узла по значению

            LinkedListNode<string> node = names.Find("Bob");

            if (node != null)
            {
                Console.WriteLine(node.Value);         // Bob
                Console.WriteLine(node.Previous.Value);// Tom
                Console.WriteLine(node.Next.Value);    // Sam
            }

            // Вставка до/после узла
            LinkedListNode<string> nodes = names.Find("Bob");
            names.AddAfter(node, "Mike");
            names.AddBefore(node, "Alice");

            LinkedList<string> cars = new LinkedList<string>(new[] { "Bmv", "Mrcedes", "Toyota" });
        }
    }
}
