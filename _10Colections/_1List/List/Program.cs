using System.Data;
using System.Globalization;
using System.Xml.Serialization;

namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Коллекции
            // Создание пустого списка 
            List<string> list = new List<string>();
            List<string> arr1 = new List<string> { "abc", "oop", "bbc" };

            list = new List<string>(arr1) { "mike" };

            List<string> arr2 = ["Bob", "Sam", "Tom"];
            List<int> arr3 = [];

            List<Persone> persones = new List<Persone>()
            {
                new Persone("Tom"),
                new Persone("Bob"),
                new Persone("Billy"),
            };


            // Установка начальной емкости списка
            List<string> arr4 = new List<string>(4);
            arr4.Capacity = 16;


            // Обращение к элементам списка
            var people = new List<string>() { "Sam", "Tom", "Pablo"};
            Console.WriteLine(people[0]); // получаем первый элемент - Sam
            people[1] = "Joshua";
            Console.WriteLine(people[1]);


            // Длина списка
            var car = new List<string>() { "BMV", "TOYOTA", "MERCEDES" };
            Console.WriteLine(car.Count); // 3 


            // Перебор списка
            foreach (var item in car)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < arr1.Count; i++)
            {
                Console.WriteLine(arr1[i]);
            }


            Console.WriteLine(new string('@', 20));

            List<string> names = new List<string> { "Tom", "Bob", "Sam" };
            string[] arr = new string[5];
            names.CopyTo(arr);

            foreach (var item in arr)
            {
                if (item == null)
                    Console.WriteLine("null");
                else
                    Console.WriteLine(item);
            }

            Console.WriteLine(arr.Length);


        }
    }
}
