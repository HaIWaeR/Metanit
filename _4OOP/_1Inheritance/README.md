# НАСЛЕДОВАНИЕ INHERITANCE
класс наследник забирает себе всё содержимое другого класса (родителя).
Синтаксис

```c#
class Employee : Prsone
{
}
```
## Что наследуется
**Можно:** 
- поля, свойства, методы
- public, protected, internal
- private protected (если наследник в той же сборке)

**Нельзя:**
- private
- конструкторы (кроме пустого)

## Доступ к членам родителя
**Из наследника видны:**
- public
- protected
- internal (если в той же сборке)
- private protected (если в той же сборке)

**Из наследника НЕ видны:**
- private

```c#
class Person
{
    private string _name;      // наследник не видит
    protected int Age;         // видит
    public string Name;        // видит
}

class Employee : Person
{
    void Print()
    {
        Console.WriteLine(Name);   // работает
        Console.WriteLine(Age);    // работает
        // Console.WriteLine(_name); // ошибка
    }
}
```

##  Ключевое слово base

Вызов конструктора родителя
```c#
class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
}
class Employee : Person
{
    public string Company { get; set; }
    public Employee(string name, string company) : base(name) // передаём name в конструктор Person
    {
        Company = company;
    }
}
```

Вызов метода родителя
```c#
class Person
{
    public virtual void Print()
    {
        Console.WriteLine("Person");
    }
}

class Employee : Person
{
    public override void Print()
    {
        base.Print();          // ← сначала вызываем метод Person
        Console.WriteLine("Employee");
    }
}
```
Если у родителя нет конструктора без параметров, наследник обязан вызвать его конструктор через base(...).
Если у родителя есть пустой конструктор, вызывать base(...) необязательно — он вызовется сам.

```c#
class Person
{
    public Person(string name) { }   // нет пустого конструктора
}

class Employee : Person
{
    public Employee(string name) : base(name) 
    {
    }
}
```

Порядок вызова конструкторов
Сначала вызываются конструкторы родителя, потом наследника.

```c#
class Person
{
    public Person(string name)
    {
        Console.WriteLine("Person(string name)");
    }
}

class Employee : Person
{
    public Employee(string name, string company) : base(name)
    {
        Console.WriteLine("Employee(string name, string company)");
    }
}
```

**Использование**
```c#
Employee emp = new Employee("Tom", "Microsoft");
```
**Вывод**
```s
Person(string name)
Employee(string name, string company)
```