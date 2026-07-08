namespace AbstractClass
{
    abstract class Transport
    {
        public string Name { get; set; }
        protected Transport(string name)
        {
            Name = name;
        }
        public void Move()
        {
            Console.WriteLine($"Транспорт {Name} движеться");
        }
    }
    class Ship : Transport
    {
        public Ship(string name) : base(name)
        {

        }
    }

    class Car : Transport
    {
        public Car(string name) : base(name)
        {

        }
    }

    class Aircraft : Transport
    {
        public Aircraft(string name) : base(name)
        {

        }
    }
}
