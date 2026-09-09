# Делегаты Action, Predicate и Func

Встроенные обобщённые делегаты .NET. Нужны, чтобы **не объявлять свой `delegate` под каждую сигнатуру**.

```csharp
// Было
delegate int Operation(int x, int y);
Operation op = Add;

// Стало
Func<int, int, int> op = Add;
```

---

## Шпаргалка выбора

| Метод возвращает | Берём |
|---|---|
| `void` | `Action<...>` |
| `bool`, один параметр | `Predicate<T>` (или `Func<T, bool>`) |
| что угодно другое | `Func<..., TResult>` |

---

## Action — действие без результата

Возвращает всегда `void`. Параметров: **от 0 до 16**. Все типы в скобках — только входные.

```csharp
public delegate void Action();
public delegate void Action<in T>(T obj);
```

```csharp
Action greet = () => Console.WriteLine("Привет!");
Action<string> print = s => Console.WriteLine(s);
Action<int, int> add = (x, y) => Console.WriteLine(x + y);

greet();         // Привет!
print("текст");  // текст
add(2, 3);       // 5
```

Типичное применение — передать «что сделать» в метод:

```csharp
void DoOperation(int a, int b, Action<int, int> op) => op(a, b);

void Add(int x, int y)      => Console.WriteLine($"{x} + {y} = {x + y}");
void Multiply(int x, int y) => Console.WriteLine($"{x} * {y} = {x * y}");

DoOperation(10, 6, Add);       // 10 + 6 = 16
DoOperation(10, 6, Multiply);  // 10 * 6 = 60
```

`DoOperation` не знает, что делают с числами. Он знает только сигнатуру.

---

## Func — действие с результатом

**Последний тип в скобках — возвращаемое значение.** До 16 параметров + результат.

```csharp
TResult Func<out TResult>();
TResult Func<in T, out TResult>(T arg);
TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
```

```csharp
Func<int> getNumber = () => 42;                     // () → int
Func<int, int> square = x => x * x;                 // int → int
Func<int, int, string> join = (a, b) => $"{a}{b}";  // (int, int) → string

Console.WriteLine(join(1, 5));  // 15
```

```csharp
int DoOperation(int n, Func<int, int> operation) => operation(n);

int DoubleNumber(int n) => 2 * n;
int SquareNumber(int n) => n * n;

Console.WriteLine(DoOperation(6, DoubleNumber)); // 12
Console.WriteLine(DoOperation(6, SquareNumber)); // 36
```

### ⚠️ Главная путаница

```csharp
Action<int, int>   // (int, int) → void   ДВА параметра
Func<int, int>     // (int)      → int    ОДИН параметр!
```

Читай `Func` справа налево: «отдаю последнее, беру остальное».

---

## Predicate — проверка условия

Один параметр → `bool`. Частный случай `Func<T, bool>`.

```csharp
delegate bool Predicate<in T>(T obj);
```

```csharp
Predicate<int> isPositive = x => x > 0;
Predicate<string> isEmpty = s => s.Length == 0;

Console.WriteLine(isPositive(20));   // True
Console.WriteLine(isPositive(-20));  // False
```

### ⚠️ Типы несовместимы напрямую

Сигнатура одна, но это **разные типы**:

```csharp
Predicate<int> p = x => x > 0;
Func<int, bool> f  = p;          // ОШИБКА компиляции
Func<int, bool> f2 = x => p(x);  // так работает
```

Где встретишь на практике:

| API | Принимает |
|---|---|
| `List<T>`: `Find`, `FindAll`, `RemoveAll`, `Exists` | `Predicate<T>` |
| LINQ: `Where`, `Any`, `All`, `First` | `Func<T, bool>` |

`Predicate` появился в .NET 2.0, `Func` — в 3.5. Разница чисто историческая.

---

## Фишки и грабли

**1. Многоадресность у `Func` теряет результаты** — вернётся только последний:

```csharp
Func<int> f = () => 1;
f += () => 2;
Console.WriteLine(f());  // 2, первый результат потерян
```

Поэтому цепочки делают на `Action` (события), а не на `Func`.

**2. Лямбда-блок требует `return`:**

```csharp
Func<int, int> a = x => x * 2;              // выражение — без return
Func<int, int> b = x => { return x * 2; };  // блок — return обязателен
```

**3. `in` / `out` в объявлении** — это контра-/ковариантность (см. отдельную главу):

```csharp
Action<object> ao = o => Console.WriteLine(o);
Action<string> as_ = ao;   // OK: in T — контравариантность

Func<string> fs = () => "hi";
Func<object> fo = fs;      // OK: out T — ковариантность
```

**4. Метод подходит по сигнатуре, а не по имени.** Компилятор сверяет только типы параметров и возврата.

**5. Пустой делегат = `NullReferenceException`.** Перед вызовом:

```csharp
op?.Invoke(a, b);
```

---

## Итог одной строкой

> `Action` — сделай. `Func` — посчитай и верни. `Predicate` — ответь да/нет.