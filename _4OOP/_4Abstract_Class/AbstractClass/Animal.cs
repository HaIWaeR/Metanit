using System.Reflection.Metadata.Ecma335;

namespace AbstractClass
{
    // Абстрактные свойства
    public abstract class Animal
    {
        public abstract int Age { get; set; }
        public abstract void PrintAge();

    }

    public class Person : Animal
    {
        public override int Age { get; set; }

        public override void PrintAge()
        {
            Console.WriteLine($"Возраст человека: {Age}");
        }
    }

    public class  Cat : Animal
    {
        int age;
        public override int Age
        {
            get => age;
            set
            {
                if (value <= 0) age = 0;
                else if (value == 1) age = 15;
                else if (value == 2) age = 24;
                else age = 24 + (value - 2) * 4;
            }
        }
        public override void PrintAge()
        {
            Console.WriteLine($"Возраст кота: {Age}");
        }
    }
}
