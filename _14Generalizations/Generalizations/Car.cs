namespace Generalizations
{
    class Car<T>
    {
        public static T? SerialNumber;
        public T Code;
        public string Name = string.Empty;

        public Car(T code, string name)
        {
            Code = code;
            Name = name;
        }

        public void ShowFullInfo()
        {
            Console.WriteLine($"Name: {Name}\nCode: {Code}\nSerial number {SerialNumber}");
        }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}\nCode: {Code}");
        }

    }
}
