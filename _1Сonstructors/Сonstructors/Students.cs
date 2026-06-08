namespace Сonstructor
{
    // Деконструктор 
    public class Students
    {
        public string Name = string.Empty;
        public int Age;
        private int Grade = 0;
        public Students(string name, int age, int grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }
        public void Deconstruct(out string name, out int age, out int grade)
        {
            name = Name;
            age = Age;
            grade = Grade;
        }
    }

}
