namespace Structures
{
    public struct Person
    {
        public string name = String.Empty;
        public int age;

        public Person()
        {

        }

        public void Print()
        {
            Console.WriteLine($"{name}, {age}");
        }
    }
}
