namespace PropertiesTrain
{
    // Модификаторы доступа
    public class Car
    {
        public Car(string name)
        {
            Name = name;
        }
        string name = "";
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
    }
}