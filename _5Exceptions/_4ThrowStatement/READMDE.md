# Генерация исключения и оператор throw

Позволяет вручную создать и выбросить исключение в любом месте кода.

```csharp
throw new Exception("Текст ошибки");
```

```csharp
try
{
    Console.Write("Введите имя: ");
    string name = Console.ReadLine();
    
    if (name == null || name.Length < 2)
    {
        throw new Exception("Длина имени меньше 2 символов");
    }
    else
    {
        Console.WriteLine($"Ваше имя: {name}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}
```

## Проброс исключения throw без объекта

Используется только внутри блока catch
Пробрасывает текущее исключение дальше по стеку вызовов

```csharp
try
{
    try
    {
        throw new Exception("Ошибка");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Внутренний catch: {ex.Message}");
        throw; // Пробрасываем дальше
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Внешний catch: {ex.Message}");
}
```

Вывод:
```text
Внутренний catch: Ошибка
Внешний catch: Ошибка
```

- throw с объектом можно использовать в любом месте
- throw без объекта используется только в catch
- throw без объекта сохраняет стек вызовов
- Можно пробрасывать исключение несколько раз по цепочке