# Перегрузка методов (Method Overloading)

Несколько методов с **одинаковым именем**, но **разной сигнатурой**.

## Cигнатура
* Имя метода
* Количество параметров
* Типы параметров
* Порядок параметров
* Модификаторы параметров (ref, out)

## Перегрузки
* Количеством параметров
* Типом параметров
* Порядком параметров
* Модификаторами параметров

**Названия параметров НЕ входят в сигнатуру.**

```csharp
public class Calculator
{
    public void Add(int a, int b)                 // Add(int, int)
    {
        Console.WriteLine(a + b);
    }
    
    public void Add(int a, int b, int c)          // Add(int, int, int)
    {
        Console.WriteLine(a + b + c);
    }
    
    public int Add(int a, int b, int c, int d)    // Add(int, int, int, int)
    {
        return a + b + c + d;
    }
    
    public void Add(double a, double b)           // Add(double, double)
    {
        Console.WriteLine(a + b);
    }
    
    public void Increment(int a)                  // Increment(int)
    {
        a++;
    }
    
    public void Increment(ref int a)              // Increment(ref int)
    {
        a++;
    }
}

// Использование
Calculator calc = new Calculator();
calc.Add(1, 2);           // 3
calc.Add(1, 2, 3);        // 6
calc.Add(1, 2, 3, 4);     // 10
calc.Add(1.5, 2.5);       // 4.0V
```