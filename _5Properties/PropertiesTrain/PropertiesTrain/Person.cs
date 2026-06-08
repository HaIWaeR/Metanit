namespace PropertiesTrain
{
    // Вычисляемые свойства
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        string firstName;
        string lastName;        

        public string Name
        {
            get { return $"{firstName},{lastName}"; }
        }
    }
}
