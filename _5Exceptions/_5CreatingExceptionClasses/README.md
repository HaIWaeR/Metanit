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

Вывод:

```text
Ошибка: Лицам до 18 регистрация запрещена
Некорректное значение: 17
```

- Все пользовательские исключения должны наследовать от Exception или его наследников
- Конструктор должен передавать сообщение в базовый класс через base(message)
- Имя класса должно заканчиваться на Exception
- Можно добавлять свойства для передачи дополнительной информации