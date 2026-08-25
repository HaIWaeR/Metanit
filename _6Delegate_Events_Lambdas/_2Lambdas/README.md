# Лямбды
#### Лямбда-выражения позволяют создать емкие лаконичные методы, которые могут возвращать некоторое значение и которые можно передать в качестве параметров в другие методы.

```c#
Message hello = () => Console.WriteLine("Hello");
hello();       // Hello
hello();       // Hello
hello();       // Hello
 
delegate void Message();
```

#### Если лямбда-выражение содержит несколько действий, то они помещаются в фигурные скобки:
```c#
Message hello = () =>
{
    Console.Write("Hello ");
    Console.WriteLine("World");
};
hello();       // Hello World
```

# Параметры лямбды

#### Если лямбда присваивается конкретному делегату, типы параметров выводятся автоматически:
```c#
Operation sum = (x, y) => Console.WriteLine($"{x} + {y} = {x + y}");
sum(1, 2);       // 1 + 2 = 3
sum(22, 14);     // 22 + 14 = 36

delegate void Operation(int x, int y);
```

#### Для var нужно указывать типы параметров
```c#
var sum = (int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");
sum(1, 2);       // 1 + 2 = 3
```

#### Если один параметр скобки можно опустить
```c#
PrintHandler print = message => Console.WriteLine(message);
print("Hello");         // Hello

print("Welcome");       // Welcome

delegate void PrintHandler(string message);
```

#### Параметры со значением по умолчанию (C# 12)
```c#
var welcome = (string message = "hello") => Console.WriteLine(message);

welcome("hello world"); // hello world
welcome();              // hello
```


# Возвращение результата

#### В однострочной лямбде return не нужен
```c#
var sum = (int x, int y) => x + y;
int result = sum(4, 5);         // 9
Console.WriteLine(result);      // 9

Operation multiply = (x, y) => x * y;
int multiplyResult = multiply(4, 5);  // 20

delegate int Operation(int x, int y);
```

#### Многострочная лямбда — нужен return
```c#
var subtract = (int x, int y) =>
{
    if (x > y) return x - y;
    else return y - x;
};

int result1 = subtract(10, 6);   // 4 
Console.WriteLine(result1);      // 4

int result2 = subtract(-10, 6);  // 16
Console.WriteLine(result2);      // 16
```

# Добавление и удаление действий в лямбда-выражении

#### Метод может возвращать лямбда-выражение. Возвращаемый тип — делегат, соответствующий лямбде:
```c#
// Вместо var используем явный тип делегата
Action hello = () => Console.WriteLine("Banana");

Action message = () => Console.Write("Hello ");
message += () => Console.WriteLine("World");   // добавляем анонимную лямбду
message += hello;                              // добавляем лямбду из переменной
message += Print;                              // добавляем обычный метод

message();  // Вызовет все: Hello World, Banana, Welcome to C#

Console.WriteLine("--------------");

message -= Print;    // удаляем метод
message -= hello;    // удаляем лямбду

message?.Invoke();   // безопасный вызов

void Print() => Console.WriteLine("Welcome to C#");
```

# Лямбда-выражение как аргумент метода

#### Лямбды можно передавать как аргументы методов, которые ожидают делегат:

```c#
public delegate bool isEqual(int x);
int[] integers = [1, 2, 3, 4, 5, 6, 7, 8, 9];

public int Sum(int[] numbers, isEqual func)
{
    int result = 0;
    foreach (int item in numbers)
    {
        if (func(item))
        {
            result += item;
        }
    }
    return result;
}
```
#### Вызов
```c#
Console.WriteLine(Sum(integers, x => x < 5));
```

# Лямбда-выражение как результат метода

#### Метод SelectOperation возвращает разные лямбды в зависимости от переданного параметра. Возвращенную лямбду можно вызвать как обычный метод.
```c#
Operation operation = SelectOperation(OperationType.Add);
Console.WriteLine(operation(10, 4));    // 14

operation = SelectOperation(OperationType.Subtract);
Console.WriteLine(operation(10, 4));    // 6

operation = SelectOperation(OperationType.Multiply);
Console.WriteLine(operation(10, 4));    // 40

Operation SelectOperation(OperationType opType)
{
    switch (opType)
    {
        case OperationType.Add: return (x, y) => x + y;
        case OperationType.Subtract: return (x, y) => x - y;
        default: return (x, y) => x * y;
    }
}

enum OperationType
{
    Add, Subtract, Multiply
}

delegate int Operation(int x, int y);
```

