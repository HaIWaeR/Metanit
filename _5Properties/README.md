# Свойства

#### Свойство — это посредник между полем и внешним кодом. Позволяет контролировать доступ к данным.
```Csharp
[модификатор] тип Название
{
    get { return поле; }      // чтение
    set { поле = value; }     // запись
}
```

#### Полная запись (ручное поле)
```Csharp
private string _name;
public string Name
{
    get { return _name; }
    set { _name = value; }
}
```
#### Дополнительная логика в свойстве
```Csharp
private int _age;
public int Age
{
    get { return _age; }
    set 
    {
        if (value > 0 && value < 120)
            _age = value;
        else
            Console.WriteLine("Недопустимый возраст");
    }
}
```
#### Короткая запись (expression-bodied)
```Csharp
public string Name
{
    get => _name;
    set => _name = value;
}
```
# Свойства только для чтения и только для записи

#### Только чтение (read-only)
```Csharp
Есть только блок get. Нельзя установить значение снаружи.

public string Name
{
    get { return _name; }
}
// Или с приватным сеттером (можно установить только внутри класса)
public string Name { get; private set; }
```

#### Только запись (write-only)
```Csharp
Есть только блок set. Нельзя прочитать значение снаружи.

private string _password;
public string Password 
{ 
    set { _password = value; } 
}
```

# Вычисляемые свойства

Свойство не обязано хранить значение. Оно может вычислять его на основе других полей или выражений.
```csharp
public class Person
{
    private string _firstName;
    private string _lastName;

    public Person(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }

    // Вычисляемое свойство (только для чтения)
    public string FullName
    {
        get { return $"{_firstName} {_lastName}"; }
    }
}
```

# Модификаторы доступа у блоков get и set

Можно назначить модификатор доступа отдельно для блока get или set.

```csharp
public class Car
{
    private string _name;

    public Car(string name)
    {
        Name = name;  // private set работает внутри конструктора
    }

    public string Name
    {
        get { return _name; }
        private set { _name = value; }  // только внутри класса
    }
}

// Использование
Car myCar = new Car("Billi");
Console.WriteLine(myCar.Name);  // get работает
// myCar.Name = "Tom";          // Ошибка! set объявлен private
```
#### Правила и ограничения

1. Модификатор можно установить только если у свойства есть оба блока (get и set)
2. Только ОДИН блок может иметь модификатор (нельзя оба)
3. Модификатор блока должен быть БОЛЕЕ ограничивающим, чем модификатор свойства

```csharp
public string Name
{
    get { return _name; }           // public (как у свойства)
    private set { _name = value; }  // более ограничивающий
}

public string Name
{
    protected get { return _name; }  // более ограничивающий
    set { _name = value; }           // public (как у свойства)
}

public string Name
{
    public get { return _name; }     // Ошибка! Нельзя, такой же как свойство
    set { _name = value; }
}
```
# Автоматические свойства

Автоматические свойства — это сокращённая запись, когда компилятор сам создаёт скрытое поле. Не нужно вручную писать приватное поле и простые get/set.

#### Синтаксис
```csharp
public string Name { get; set; }
```
#### Пример
```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```
#### Начальное значение (инициализация)
```csharp
public string Name { get; set; } = "Tom";
public int Age { get; set; } = 37;
```
#### Модификаторы доступа у автосвойств
Можно ограничить доступ к get или set.

```csharp
public string Name { get; private set; }   // только чтение снаружи
public string Name { private get; set; }   // только запись снаружи (редко)
```
#### Автосвойство только для чтения (без set)
```csharp
public string Name { get; } = "Tom";        // можно установить только при инициализации
// или через конструктор
public Person(string name) => Name = name;
```
#### Важные ограничения

1. Нельзя создать автоматическое свойство ТОЛЬКО для записи (без get)
2. У автосвойства нельзя добавить логику в get/set (только прямое присвоение)
3. Если нужна логика — нужно разворачивать в обычное свойство с полем

#### Пример из кода
```csharp
public class Student
{
    public Guid Id { get; set; }                      // полный доступ
    public string Name { get; private set; }          // только чтение снаружи
    public int Age { get; set; }                      // полный доступ
    public string Class { get; set; } = "ИТ-11.24.3"; // с начальным значением

    public Student(string name, int age)
    {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;
    }
}
```
