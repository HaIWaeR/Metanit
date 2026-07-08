# Виртуальные методы и свойства в C#

## Виртуальный метод (virtual)

Метод в базовом классе, который можно переопределить в наследниках.

```c#
class Person
{
    public virtual void Print()
    {
        Console.WriteLine("Person");
    }
}

## Переопределение метода (override)

Изменяет реализацию виртуального метода в классе-наследнике.

```c#
class Employee : Person
{
    public override void Print()
    {
        Console.WriteLine("Employee");
    }
}
```

## Ключевое слово base

Обращение к реализации метода из базового класса.

```c#
class Employee : Person
{
    public override void Print()
    {
        base.Print(); // вызов метода из Person
        Console.WriteLine("Employee");
    }
}
```

## Запрет переопределения (sealed override)

```c#
class Employee : Person
{
    public sealed override void Print()
    {
        Console.WriteLine("Employee");
    }
}

class Manager : Employee
{
    public override void Print() { } // Нельзя переопределить sealed метод 
}
```

## Переопределение свойств

Свойства переопределяются так же, как методы.

```c#
class Person
{
    public virtual int Age { get; set; }
}

class Employee : Person
{
    private int _age;
    public override int Age
    {
        get => _age;
        set => _age = value > 0 ? value : 0;
    }
}
```

## Статические методы нельзя переопределить

```c#
class Person
{
    public static void Print() { } // static
}

class Employee : Person
{
    public override void Print() { } // Нельзя переопределить static метод
}
```

## Цепочка переопределений

```c#
Person (virtual Print)
   ↑
Employee (override Print)
   ↑
Manager (override Print)   // Можно
```