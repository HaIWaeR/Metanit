# Static статические члены

`static`  общий ресурс для всех объектов класса. Значение принадлежит классу, а не каждому объекту.

## 1. Статическое поле
* Общее для всех объектов 
* Хранит состояние всего класса 
* Меняется у всех объектов сразу

```csharp
public class Car
{
    string _model;
    public static int TotalCars;   // статическое поле

    public Car(string model)
    {
        _model = model;
        TotalCars++;   // увеличивается при создании каждого объекта
    }
}
// Доступ через имя класса
Console.WriteLine(Car.TotalCars);  // 3