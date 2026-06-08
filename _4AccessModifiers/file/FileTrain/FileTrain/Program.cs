using System.ComponentModel.DataAnnotations;

namespace FileTrain
{
    // file - работает только в файле 
    public class Program
    {
        static void Main(string[] args)
        {

            NewsOnTV newsOnTV = new NewsOnTV();

            newsOnTV.ShowInfoCar();
            
            // Car myCar = new Car();
            // Console.WriteLine(Car.ShowInfo());

            // Ошибка CS9059: Тип "Car" объявлен как file и не виден за пределами файла
        }
    }
}
