namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> product = new List<string>();

            product.Add("Молоко");
            product.Add("Хлеб");
            product.Add("Яблоко");

            Console.WriteLine(product.Count);
            Console.WriteLine(product[0]);
            product[1] = "Батон";

            product.Remove("Батон");
            product.RemoveAt(0);

            product.Clear();

            // ----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            List<string> car = new List<string>()
            {
                "БМВ",
                "Мерседес",
                "Тайта"
            };

            List<int> value = [1, 2, 3];

            List<int> grade = new List<int>();
            grade.Add(5);
            grade.Add(4);
            grade.Add(3);
            grade.Add(3);

            foreach (var item in grade)
                Console.WriteLine(item);

            grade[grade.Count - 1] = 5;

            // ----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            List<string> havchik = ["Молоко", "Хлеб", "Сыр", "Хлеб", "Чай"];

            havchik.RemoveAt(havchik.Count - 1); // Удаление Чай

            if (!havchik.Remove("Кофе"))
                Console.WriteLine("Кофе в списке нету");

            for (int i = 0; i < havchik.Count; i++)
            {
                if (havchik[i] == "Хлеб")
                {
                    havchik.RemoveAt(i);
                    i--;
                }
            }

            foreach (var item in havchik)
                Console.Write($"{item} ");

            Console.WriteLine($"\nКоличество: {havchik.Count}");

            // ----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");


            List<string> products = ["Чай", "Молоко", "Кофе"];

            bool hasMilk = products.Contains("Молок");
            Console.WriteLine(hasMilk);

            int indexTea = products.IndexOf("Чай");
            Console.WriteLine(indexTea);

            int missing = products.IndexOf("Колла");
            Console.WriteLine(missing);

            if (!product.Contains("Кефир"))
                product.Add("Кефир");

            // ----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            List<string> logins = ["admin", "user1", "guest"];

            if (!logins.Contains("user2"))
                logins.Add("user2");
            else
                Console.WriteLine("Лоигн занят");

            int indexGuest = logins.IndexOf("guest");

            if (indexGuest == -1)
                logins[indexGuest] = "guest_old";

            foreach (var item in logins)
                Console.Write($"{item} ");

            // ----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            List<int> prices = [120, 450, 80, 300, 999];

            int sum = 0;
            foreach (var item in prices)
            {
                if (item > sum)
                    sum = item;
            }

            Console.WriteLine(sum);

            for (int i = 0; i < prices.Count; i++)
            {
                prices[i] = prices[i] * 110 / 100;
            }

            for (int i = 0; i < prices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {prices[i]} ");
            }

            // ----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            List<int> numbers = [4, 7, 2, 2, 9, 1, 6, 3];

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbers.RemoveAt(i);
                }
            }

            foreach (var item in numbers)
                Console.Write($"{item} ");

            // ----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            List<int> scores = [72, 95, 58, 88, 95, 61];

            List<int> uniqueScores = new List<int>(scores);
            uniqueScores.Sort();
            uniqueScores.Reverse();

            for (int i = 0; i < scores.Count; i++)
            {
                Console.Write($"{scores[i]} ");
            }

            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{uniqueScores[i]} ");
            }

            // ----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            Console.WriteLine($"\n{new string('-', 10) + "Вывод списка" + new string('-', 10)}\n");
            PrintTasks(tasks);

            Console.WriteLine($"\n{new string('-', 10) + "Добавить два элемента" + new string('-', 10)}\n");
            AddTask(tasks, "Купить хлеб");
            AddTask(tasks, "сделать кт"); // дубль

            Console.WriteLine($"\n{new string('-', 10) + "Отметить выполненым" + new string('-', 10)}\n");
            CompleteTask(tasks, "Купить молоко");
            CompleteTask(tasks, "Погулять с собакой");
            CompleteTask(tasks, "Сходить в зал");

            Console.WriteLine($"\n{new string('-', 10) + "Вывести список" + new string('-', 10)}\n");
            PrintTasks(tasks);

            Console.WriteLine($"\n{new string('-', 10) + "Удалить выполненные, вывести список" + new string('-', 10)}\n");
            RemoveCompleted(tasks);
            PrintTasks(tasks);

            Console.WriteLine($"\n{new string('-', 10) + "Вывести по алфавиту" + new string('-', 10)}\n");
            PrintSorted(tasks);

            Console.WriteLine($"\n{new string('-', 10) + "Обычный список" + new string('-', 10)}\n");
            PrintTasks(tasks);
        }

        public static List<string> tasks = ["Купить молоко", "Сделать КТ", "Погулять с собакой", "Прочитать главу"];
        public static void AddTask(List<string> tasks, string task)
        {
            foreach (var existing in tasks)
            {
                if (IsLower(existing) == IsLower(task))
                {
                    Console.WriteLine("Задача уже в пуле");
                    return;
                }
            }
            tasks.Add(task);
        }
        public static string IsLower(string message) => message.ToLower();
        public static void PrintTasks(List<string> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }

            Console.WriteLine($"\nВсего {tasks.Count} задач");
        }

        public static void CompleteTask(List<string> tasks, string task)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Задач нету");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                if (IsLower(tasks[i]) == IsLower(task))
                {
                    tasks[i] = $"[X] {tasks[i]}";
                }
            }
        }

        public static void RemoveCompleted(List<string> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].StartsWith("[X]"))
                {
                    tasks.RemoveAt(i);
                    i--;
                }
            }
        }

        public static void PrintSorted(List<string> tasks)
        {
            List<string> NewTasks = new List<string>(tasks);
            NewTasks.Sort();
            
            for (int i = 0; i < NewTasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {NewTasks[i]}");
            }

            Console.WriteLine($"Всего {NewTasks.Count} задач");
        }
    }
}
