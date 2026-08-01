# Поиск блока catch при обработке исключений

Когда возникает исключение, система ищет подходящий блок catch в следующем порядке:

1. Проверяет текущий метод (где произошла ошибка)
2. Если catch не найден - поднимается на уровень выше (вызывающий метод)
3. Продолжает подниматься по стеку вызовов
4. Если catch найден - выполняет все блоки finally на пути от места ошибки до catch
5. Если catch не найден до самого верха - программа падает

## Пример
```csharp
try // Main
{
    TestClass.Method1();
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Catch в Main: {ex.Message}");
}
finally
{
    Console.WriteLine("Блок finally в Main");
}

class TestClass
{
    public static void Method1()
    {
        try
        {
            Method2();
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Catch в Method1: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Блок finally в Method1");
        }
    }
    
    static void Method2()
    {
        try
        {
            int x = 8;
            int y = x / 0; // DivideByZeroException
        }
        finally
        {
            Console.WriteLine("Блок finally в Method2");
        }
    }
}
```

1. Ошибка в Method2
2. В Method2 нет catch для DivideByZeroException - поднимаемся выше
3. В Method1 нет catch для DivideByZeroException - поднимаемся выше
4. В Main найден catch для DivideByZeroException
5. Выполняется finally в Method2
6. Выполняется finally в Method1
7. Выполняется catch в Main
8. Выполняется finally в Main

Вывод: 
```text
Блок finally в Method2
Блок finally в Method1
Catch в Main: Attempted to divide by zero
Блок finally в Main
Конец метода Main
```

- finally выполняется на всех уровнях, где он есть (от места ошибки до catch)
- Код после try-catch в методах, где не нашелся catch, не выполняется
- Писк идет снизу вверх по стеку вызовов
- catch выполняется только на том уровне, где нашелся подходящий обработчик