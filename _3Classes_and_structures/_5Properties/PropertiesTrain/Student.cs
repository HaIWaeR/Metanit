namespace PropertiesTrain
{
    // Автоматические свойства
    public class Student
    {
        public Guid Id { get; set; }
        // Автосвойства также могут иметь модификаторы доступа
        public string Name { get; private set; }
        public int Age { get; set; }
        public string @class { get; set; } = "Ит-11.24.3";

        public Student(string name, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }
    }
}
