# Класс System.Object и его методы

Все классы в C# неявно наследуются от `System.Object`. Поэтому у любого объекта есть эти методы.

---

## 1. ToString()

Возвращает строковое представление объекта.

- Для значимых типов (`int`, `double`) - возвращает их значение
- Для классов - по умолчанию возвращает **полное имя класса** с пространством имён

```c#
class Person
{
    public string Name { get; set; }
}

Person p = new Person { Name = "Tom" };
Console.WriteLine(p.ToString()); // "Person" (название класса)
```

Можно переопределить через override:

```c#
class Clock
{
    public int Hours { get; set; }
    public int Minutes { get; set; }

    public override string ToString()
    {
        return $"{Hours}:{Minutes}";
    }
}

Clock clock = new Clock { Hours = 15, Minutes = 34 };
Console.WriteLine(clock.ToString()); // "15:34"
```

ToString() вызывается неявно

```c#
Console.WriteLine(clock); // То же самое, что Console.WriteLine(clock.ToString());
```

## GetHashCode

Возвращает числовой код (хэш) объекта.

- Используется для быстрого сравнения и хранения в словарях (Dictionary, HashSet)

- Два одинаковых объекта должны возвращать одинаковый хэш-код

```c#
class Person
{
    public string Name { get; set; }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
```

Если переопределять Equals() то обязаны переопределить GetHashCode()

```c#
public override int GetHashCode()
{
    return HashCode.Combine(Name, Age);
}
```

## GetType

Возвращает реальный тип объекта.

- Нельзя переопределить

- Возвращает объект Type

```c#
Person person = new Person { Name = "Tom" };
Console.WriteLine(person.GetType().Name); // "Person"
```

Проверка типа

```c#
if (person.GetType() == typeof(Person))
    Console.WriteLine("Это Person");
```

Проще через is

```c#
if (person is Person)
    Console.WriteLine("Это Person");
```

## Equals
Сравнивает два объекта на равенство.

- По умолчанию сравнивает ссылки (адреса в памяти)
- Можно переопределить для сравнения по значению

```c#
class Person
{
    public string Name { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Person other)
            return Name == other.Name;
        return false;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
```

Использование
```c#
Person p1 = new Person { Name = "Tom" };
Person p2 = new Person { Name = "Tom" };

Console.WriteLine(p1.Equals(p2)); // True (сравнили по имени)
```
