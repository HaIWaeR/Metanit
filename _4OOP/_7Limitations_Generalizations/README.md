# Ограничения обобщений (Constraints)

## Зачем нужны ограничения

Чтобы сказать компилятору что T - это не просто любой тип, а конкретный тип с определёнными свойствами
Без ограничений нельзя вызвать у T никаких методов, кроме тех, что есть у object.

```csharp
void Print<T>(T obj)
{
    Console.WriteLine(obj.Text);   // Ошибка! T может не иметь Text
}
```

## Синтаксис

```c#
void Method<T>(T param) where T : Ограничение
```

```c#
class Class<T> where T : Ограничение
```

## Виды ограничений

```c#
where T : Message T // Message или его наследник
where T : IComparable // Реализует интерфейс IComparable
where T : class // Ссылочный тип (класс)
where T : struct // Значимый тип (структура)
where T : new() // Есть публичный конструктор без параметров
```

Пример с классом
```c#
class Message
{
    public string Text { get; set; }
}

void Send<T>(T msg) where T : Message
{
    Console.WriteLine(msg.Text);   // T точно имеет Text
}

Send(new Message { Text = "Hi" });   // можно 
// Send("Hello");                    // Ошибка: string не Message
```

Пример с new()
```c#
void Create<T>() where T : new()
{
    T obj = new T();   //  работает, потому что new() гарантирует конструктор
}
```

Несколько ограничений

```c#
class Messenger<T, P>
    where T : Message
    where P : Person
{
    public void Send(T msg, P sender) { }
}
```