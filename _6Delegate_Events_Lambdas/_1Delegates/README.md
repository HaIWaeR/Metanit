# Определение делегатов

#### Делегат это тип, который описывает сигнатуру метода (возвращаемый тип и параметры). Он работает как "шаблон" для методов.

#### Делегат это тип данных Как int для чисел, string для строк, так Message - это тип для методов.

```c#
// 1. Объявляем делегат (тип)
delegate void Message();

// 2. Создаем переменную типа Message
Message mes;

// 3. Присваиваем метод (не вызов!)
mes = Hello;

// 4. Вызываем через делегат
mes();

// Сам метод
void Hello() => Console.WriteLine("Hello");
```

#### При присвоении передается адрес метода, а не результат
```c#
mes = Hello;        // Правильно - передаем метод
mes = Hello();      // Ошибка - передаем результат вызова
```

#### Метод должен полностью совпадать по сигнатуре
```c#
delegate int Operation(int x, int y);

int Add(int a, int b) => a + b;        // Совпадает
void Print(int a, int b) => ...        // Не совпадает (возвращаемый тип)
int Sub(int a) => ...                  // Не совпадает (количество параметров)
```

#### Можно ссылаться на методы из других классов 
```C#
Message m1 = Welcome.Print;      // static метод
Message m2 = new Hello().Display; // обычный метод

delegate void Message();

class Welcome {
    public static void Print() => Console.WriteLine("Welcome");
}
class Hello {
    public void Display() => Console.WriteLine("Привет");
}
```

# Место определения делегата

### Три места для объявления делегата

#### Внутри класса (как вложенный тип)
```C#
class Program
{
    delegate void Message();  // Объявление внутри класса
    
    static void Main()
    {
        Message mes = Hello;
        mes();
    }
    
    static void Hello() => Console.WriteLine("Hello");
}
```

#### Вне класса (в пространстве имен)
```c#
namespace DelegateTrain
{
    delegate void Message();  // Объявление вне класса, прямо в namespace

    class Program
    {
        static void Main()
        {
            Message mes = Hello;
            mes();
        }
        
        static void Hello() => Console.WriteLine("Hello");

    }
}
```

#### В Top-Level программе (C# 9/10+) компилятор требует, чтобы все объявления типов (делегаты, классы, структуры, интерфейсы) шли после исполняемого кода.
```c#
// Код программы
Message mes = Hello;
mes();

void Hello() => Console.WriteLine("Hello");

// Объявление делегата - ТОЛЬКО В КОНЦЕ!
delegate void Message();
```

#### Лучше всего объявлять делегаты на уровне namespace 
```c#
// Файл: Delegates.cs
namespace MyApp
{
    // Все делегаты в одном месте - легко найти и управлять
    public delegate void NotificationHandler(string message);
    public delegate bool Filter<T>(T item);
    public delegate decimal Calculator(decimal a, decimal b);
}

// Файл: Program.cs
using MyApp;

class Program
{
    static void Main()
    {
        NotificationHandler notify = SendEmail;
    }
}
```

- Чистота кода - делегаты не захламляют классы
- Переиспользование - один делегат доступен из любого класса
- Легкость поиска - все делегаты в одном файле

# Параметры и результат делегата
```c#
namespace ExceptionsTrain
{
    // Делегат: принимает два int, возвращает int
    delegate int Calculator(int x, int y);
    public class Program
    {
        static void Main(string[] args)
        {
            // Использование
            Calculator calculator = Add;
            int resultAdd = calculator(4, 5); // Вызов метода Add(4, 5)
            Console.WriteLine(resultAdd); // 9

            calculator = Multiply;
            int resultMultiply = calculator(4, 5); // Вызов метода Multiply(4, 5)
            Console.WriteLine(resultMultiply); // 20
        }
        // Методы которые соответствуют делегату
        public static int Add(int x, int y) => x + y;
        public static int Multiply(int x, int y) => x * y;

    }
}
```
#### Любой метод, который принимает два int и возвращает int подходит под этот делегат
- Возвращаемый тип - должен совпадать точно
- Количество параметров - должно совпадать
- Типы параметров - должны совпадать (и порядок!)
- Модификаторы параметров - ref, out, in тоже важны

# Присвоение ссылки на метод
#### Два способа присвоения: Оба способа равноценны.
```c#
Operation operation1 = Add;              // Способ 1: прямое присвоение
Operation operation2 = new Operation(Add); // Способ 2: через конструктор
```

# Добавление методов в делегат

#### Делегат может указывать на множество методов. Все методы попадают в список вызова invocation list. При вызове делегата все методы из списка вызываются последовательно.

#### Добавление через +=
```c#
Message message = Hello;
message += HowAreYou;  // теперь message указывает на два метода
message();  // вызываются оба метода - Hello и HowAreYou
```

Удаление через -=
```c#
Message? message = Hello;
message += HowAreYou;
message -= HowAreYou;   // удаляем метод HowAreYou
if (message != null) message(); // вызывается только Hello
```
- При добавлении/удалении создается новый объект делегата
- Можно добавить один метод несколько раз - он вызовется столько же раз
- -= удаляет первое найденное вхождение (поиск с конца)
- Если методов не осталось - делегат становится null

#### Посмотреть все методы в списке
```c#  
foreach (Delegate d in message.GetInvocationList())
{
    Console.WriteLine(d.Method.Name);
}
```

# Объединение делегатов

#### Делегаты можно объединять в другие делегаты. Например:
```c#
Message mes1 = Hello;
Message mes2 = HowAreYou;
Message mes3 = mes1 + mes2; // объединяем делегаты
mes3(); // вызываются все методы из mes1 и mes2
 
void Hello() => Console.WriteLine("Hello");
void HowAreYou() => Console.WriteLine("How are you?");
 
delegate void Message();
```

#### При объединении методы идут в порядке добавления:
```c#
Message mes1 = Method1;
mes1 += Method2;  // mes1: Method1, Method2

Message mes2 = Method3;
mes2 += Method4;  // mes2: Method3, Method4

Message mes3 = mes1 + mes2;  // mes3: Method1, Method2, Method3, Method4
mes3();  // Вызовет: Method1, Method2, Method3, Method4
```

# Вызов делегата
#### Два способа вызова:

```c#
Message mes = Hello;
mes();              // Способ 1: как обычный метод

Operation op = Add;
int n = op.Invoke(3, 4);  // Способ 2: через метод Invoke()
```

#### проверка на null:
```c#
Message? mes = null;
mes?.Invoke();        // ошибки нет, делегат просто не вызывается

Operation? op = Add;
op -= Add;            // делегат op пуст
int? n = op?.Invoke(3, 4);  // ошибки нет, n = null
```
#### Если несколько методов: возвращается значение последнего метода:
```c#
Operation op = Subtract;
op += Multiply;
op += Add;
Console.WriteLine(op(7, 2));  // Add(7,2) = 9
```

# Обобщенные делегаты
```c#
Operation<decimal, int> squareOperation = Square;
decimal result1 = squareOperation(5);
Console.WriteLine(result1);  // 25
 
Operation<int, int> doubleOperation = Double;
int result2 = doubleOperation(5);
Console.WriteLine(result2);  // 10
 
decimal Square(int n) => n * n;
int Double(int n) => n + n;
 
delegate T Operation<T, K>(K val);
```
#### Operation типизируется двумя параметрами типов. Параметр T представляет тип возвращаемого значения. А параметр K представляет тип передаваемого в делегат параметра

#### делегату Operation<decimal, int> соответствует метод, который принимает число int и возвращает число типа decimal. А делегату Operation<int, int> соответствует метод, который принимает и возвращает число типа int.

# Делегаты как параметры методов

#### Благодаря этому один метод в качестве параметров может получать действия - другие методы

```c#
DoOperation(5, 4, Add);         // 9
DoOperation(5, 4, Subtract);    // 1
DoOperation(5, 4, Multiply);    // 20
 
void DoOperation(int a, int b, Operation op)
{
    Console.WriteLine(op(a,b));
}
int Add(int x, int y) => x + y;
int Subtract(int x, int y) => x - y;
int Multiply(int x, int y) => x * y;
 
delegate int Operation(int x, int y);
```
#### При вызове метода DoOperation мы можем передать в него в качестве третьего параметра метод, который соответствует делегату Operation.


# Возвращение делегатов из метода

#### Метод может возвращать делегат, который указывает на какой-то другой метод
```c#
public Operation SelectOperation(OperationType opType)
{
    switch (opType)
    {
        case OperationType.Add: return Add;
        case OperationType.Subtract: return Subtract;
        default: return Multiply;
    }
}
```
#### Использование

```c#
Operation operation = SelectOperation(OperationType.Add);
Console.WriteLine(operation(10, 4));    // 14 (Add)

operation = SelectOperation(OperationType.Subtract);
Console.WriteLine(operation(10, 4));    // 6 (Subtract)
```

# Возвращение делегатом делегата

#### Здесь у нас определен делегат Hungry, который принимает некоторое число и возвращает объект этого же делегата.

Для примера определяем метод Eat(), который соответствует делегату Hungry - принимает число типа int и возвращает делегат Hungry. А поскольку метод Eat соответствует делегату Hungry, то из этого метода мы можем возвратить ... сам же этот метод.

В итоге при создании цепочки Eat(5)(6)(7) мы получим три вызова метода Eat:

```c#
Eat(5)(6)(7);
 
Hungry Eat(int val)
{
    Console.WriteLine($"Съели число {val}"); 
    return Eat;
};
 
delegate Hungry Hungry(int value);
```
Вывод: 
```Text
Съели число 5
Съели число 6
Съели число 7`
```