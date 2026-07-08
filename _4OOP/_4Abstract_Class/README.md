# Абстрактные классы и члены классов

##  Абстрактный класс (abstract class)

Класс, который нельзя создать через `new`. Он задаёт **правила** для наследников.

```c#
abstract class Animal
{
    public string Name { get; set; }  // Обычное свойство

    public void Sleep()  // Обычный метод
    {
        Console.WriteLine("Животное спит");
    }
}

Создать объект абстрактного класса нельзя:

```c#
Animal animal = new Animal(); // Ошибка
```

## Абстрактный метод (abstract method)

Метод без реализации в базовом классе. Наследник обязан его реализовать через override.

```c#
abstract class Animal
{
    public abstract void Eat();  // Без тела, без фигурных скобок
}

class Dog : Animal
{
    public override void Eat()  // Обязаны реализовать
    {
        Console.WriteLine("Собака ест");
    }
}
```

## Абстрактное свойство (abstract property)

Свойство без реализации в базовом классе. Наследник обязан его реализовать через override.

```c#
abstract class Animal
{
    public abstract int Age { get; set; }
}

class Dog : Animal
{
    private int _age;
    public override int Age
    {
        get => _age;
        set => _age = value;
    }
}
```

Можно реализовать и как автосвойство:

```c#
class Cat : Animal
{
    public override int Age { get; set; }
}
```

## Если есть абстрактный член → класс абстрактный

```c#
abstract class Animal  //  Обязательно abstract
{
    public abstract void Eat();  // Есть абстрактный метод
}
```

## Наследник обязан реализовать все абстрактные члены

```c#
abstract class Animal
{
    public abstract void Eat();
    public abstract void Sleep();
}

class Dog : Animal
{
    public override void Eat() { }    //
    public override void Sleep() { }  // Обязаны оба
}
```
Если пропустить хотя бы один - ошибка компиляции.

## Можно не реализовывать, если наследник абстрактный

```c#
abstract class Animal
{
    public abstract void Eat();
}

abstract class Dog : Animal
{
    // Можно не реализовывать, класс абстрактный
}

class Labrador : Dog
{
    public override void Eat()  // Реализует здесь
    {
        Console.WriteLine("Лабрадор ест");
    }
}
```

## Конструктор в абстрактном классе

Абстрактный класс может иметь конструктор. Наследники вызывают его через base.

```c#
abstract class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }
}

class Dog : Animal
{
    public Dog(string name) : base(name) { }
}
```