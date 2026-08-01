# Создание классов исключений

Для создания собственного типа исключения необходимо унаследовать класс от Exception (или его производного).

```csharp
class PersonException : Exception
{
    public PersonException(string message)
        : base(message) { }
}
```

Использование 
```csharp
try
{
    Person person = new Person { Name = "Tom", Age = 17 };
}
catch (PersonException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}
```

## Выбор базового класса
Можно наследоваться не только от Exception, но и от более конкретных типов
```csharp
class PersonException : ArgumentException
{
    public PersonException(string message)
        : base(message) { }
}
```

## Добавление свойств

Класс исключения может содержать дополнительные данные.

```c#
class PersonException : ArgumentException
{
    public int Value { get; }
    
    public PersonException(string message, int val)
        : base(message)
    {
        Value = val;
    }
}
```

Пример получения данных при обработке:

```csharp
catch (PersonException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
    Console.WriteLine($"Некорректное значение: {ex.Value}");
}
```