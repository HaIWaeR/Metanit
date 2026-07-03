namespace TypeСonversion
{
    public class Animal
    {
        public string Group { get; set; }

        public Animal(string nameGroup)
        {
            Group = nameGroup;
        }

    }
    public class Dog : Animal
    {
        public string Name { get; set; }

        public Dog(string name, string group) : base(group)
        {
            Name = name;
        }
    }

    public class Cat : Animal
    {
        public string Name { get; set; }

        public Cat(string name, string group) : base(group)
        {
            Name = name;
        }
    }
}
