## Add(T item) - добавление элемента

```c#
List<string> names = new List<string>();
names.Add("Tom");
names.Add("Bob");
// Результат: ["Tom", "Bob"]
```
## AddRange(IEnumerable<T> collection) - добавление коллекции

```c#
List<string> names = new List<string> { "Tom" };
string[] newNames = { "Bob", "Sam" };
names.AddRange(newNames);
// Результат: ["Tom", "Bob", "Sam"]
```

## Remove(T item) — удаление элемента
```c#
List<string> names = new List<string> { "Tom", "Bob", "Sam" };
bool removed = names.Remove("Bob");
Console.WriteLine(removed); // true
// names = ["Tom", "Sam"]
```

## RemoveAt(int index) - удаление по индексу
```c#
List<string> names = new List<string> { "Tom", "Bob", "Sam" };
names.RemoveAt(1);
// names = ["Tom", "Sam"]
```

## RemoveRange(int index, int count) — удаление диапазона
```c#
List<string> names = new List<string> { "Tom", "Bob", "Sam", "Alice" };
names.RemoveRange(1, 2);
// names = ["Tom", "Alice"]
```

## RemoveAll(Predicate<T> match) — удаление по условию
```c#
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int removed = numbers.RemoveAll(x => x % 2 == 0);
Console.WriteLine(removed); // 2
// numbers = [1, 3, 5]
```

## Sort() — сортировка списка

```c#
List<int> numbers = new List<int> { 3, 1, 4, 1, 5 };
numbers.Sort();
// numbers = [1, 1, 3, 4, 5]
```

## BinarySearch(T item) - бинарный поиск (список должен быть отсортирован)

```c#
List<int> numbers = new List<int> { 1, 3, 5, 7, 9 };
int index = numbers.BinarySearch(5);
Console.WriteLine(index); // 2
```

## CopyTo(T[] array) - копирование в массив

```c#
List<string> names = new List<string> { "Tom", "Bob", "Sam" };
string[] arr = new string[5];
names.CopyTo(arr);
// arr = ["Tom", "Bob", "Sam", null, null]
```

## CopyTo(int index, T[] array, int arrayIndex, int count) - копирование части списка

```c#
List<string> names = new List<string> { "Tom", "Bob", "Sam", "Alice" };
string[] arr = new string[5];
names.CopyTo(1, arr, 2, 2);
// arr = [null, null, "Bob", "Sam", null]
```
- index - С какого индекса в списке начинаем копировать         `// 1`
- array - Массив приёмник (куда копируем)                       `// arr`    
- arrayIndex - С какого индекса в массиве начинаем вставлять    `// 2`
- count - Сколько элементов копируем                            `// 2`

## Contains(T item) - проверка наличия

```c#
List<string> names = new List<string> { "Tom", "Bob" };
bool hasTom = names.Contains("Tom");     // true
bool hasSam = names.Contains("Sam");     // false
```

## Clear() - очистка списка

```c#
List<string> names = new List<string> { "Tom", "Bob" };
names.Clear();
Console.WriteLine(names.Count); // 0
```

## Reverse(int index, int count) — переворот части списка
```c#
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
numbers.Reverse(1, 3);
// numbers = [1, 4, 3, 2, 5]
```



## Exists(Predicate<T> match) - проверка, есть ли элемент, соответствующий условию

```c#
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
bool hasEven = numbers.Exists(x => x % 2 == 0);
Console.WriteLine(hasEven); // true
```

## Find(<T> match) - найти первый подходящий элемент

```c#
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int firstEven = numbers.Find(x => x % 2 == 0);
Console.WriteLine(firstEven); // 2
```

## FindLast(Predicate<T> match) - найти последний подходящий элемент

```c#
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int lastEven = numbers.FindLast(x => x % 2 == 0);
Console.WriteLine(lastEven); // 4
```

## FindAll(Predicate<T> match) — найти все подходящие элементы

```c#
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
List<int> evens = numbers.FindAll(x => x % 2 == 0);
// evens = [2, 4]
```

## IndexOf(T item) - индекс первого вхождения

```c#
List<string> names = new List<string> { "Tom", "Bob", "Tom" };
int index = names.IndexOf("Tom");
Console.WriteLine(index); // 0
```

## LastIndexOf(T item) - индекс последнего вхождения

```c#
List<string> names = new List<string> { "Tom", "Bob", "Tom" };
int index = names.LastIndexOf("Tom");
Console.WriteLine(index); // 2
```

## GetRange(int index, int count) - получить часть списка

```c#
List<string> names = new List<string> { "Tom", "Bob", "Sam", "Alice" };
List<string> sub = names.GetRange(1, 2);
// sub = ["Bob", "Sam"]
```

## Insert(int index, T item) - вставка по индексу

```c#
List<string> names = new List<string> { "Tom", "Bob" };
names.Insert(1, "Sam");
// names = ["Tom", "Sam", "Bob"]
```

## InsertRange(int index, collection) - вставка коллекции

```c#
List<string> names = new List<string> { "Tom", "Bob" };
string[] newNames = { "Sam", "Alice" };
names.InsertRange(1, newNames);
// names = ["Tom", "Sam", "Alice", "Bob"]
```


