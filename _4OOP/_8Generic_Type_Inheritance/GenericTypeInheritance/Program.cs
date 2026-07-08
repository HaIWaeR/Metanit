namespace GenericTypeInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Первый вариант наследование обобщенных типов
            Person<string> person1 = new Person<string>("34A1F");
            Person<int> person2 = new Person<int>(2202_3454);
            UniversalPerson<int> person3= new UniversalPerson<int>(1234);
            Console.WriteLine(person1.Id);
            Console.WriteLine(person2.Id);
            Console.WriteLine(person3.Id);

            // Второй вариант наследование обобщенных типов 
            StringPerson person4 = new StringPerson("34A1F");
            // Person<string> = new StringPerson("3SAW"); так нельзя написать
            Console.WriteLine(person4.Id);


            // Третий вариант наследование обобщенных типов
            IntPerson<string> person7 = new IntPerson<string>(5, "r4556");
            Person<int> person8 = new IntPerson<long>(7, 4587);
            Console.WriteLine(person7.Id);
            Console.WriteLine(person8.Id);

            MixedPerson<string, int> person9 = new MixedPerson<string, int>("456", 356);
            Person<string> person10 = new MixedPerson<string, int>("9867", 35678);
            Console.WriteLine(person9.Id);
            Console.WriteLine(person10.Id);

        }
    }

    public class Person<T>
    {
        public T Id { get; set; }
        public Person(T id)
        {
            Id = id;
        }
    }
    public class UniversalPerson<T> : Person<T>
    {
        public UniversalPerson(T id) : base(id) {  }
    }

    public class StringPerson : Person<string>
    {
        public StringPerson(string id) : base(id) { }
    }
    public class IntPerson<I> : Person<int>
    {
        public I Code { get; set; }
        public IntPerson(int id, I code) : base(id)
        {
            Code = code;
        }
    }
    class MixedPerson<T, K> : Person<T> where K : struct
    {
        public K Code { get; set; }
        public MixedPerson(T id, K code) : base(id)
        {
            Code = code;
        }
    }

}
