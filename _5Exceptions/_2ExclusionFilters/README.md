# Блок catch и фильтры исключений

## Формы блока catch

Без указания типа - обрабатывает любое исключение:
```csharp
catch
{
    // Обработка любой ошибки
}
```

С указанием типа - обрабатывает только конкретный тип:

```csharp
catch (DivideByZeroException)
{
    Console.WriteLine("Деление на ноль");
}
```
С переменной - храним информацию об ошибке в переменной:

```csharp
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message); // Текст ошибки
    Console.WriteLine(ex.StackTrace); // Стек вызовов
}
```

## Фильтры исключений (when)

Позволяют обрабатывать исключения только при выполнении условия:

```csharp
catch (DivideByZeroException) when (y == 0)
{
    Console.WriteLine("y не должен быть равен 0");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
}
```
Если условие в when возвращает true - срабатывает первый catch. Если false - переходит к следующему.

Пример с разными условиями:

```csharp
int x = 1;
int y = 0;

try
{
    int result = x / y;
}
catch (DivideByZeroException) when (y == 0)
{
    Console.WriteLine("Ошибка: y = 0");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
}
```

Вывод: 
```text
Ошибка: y = 0
```

