
## Создание 

Создать пустую очередь
```c#
Queue<string> people = new Queue<string>();
```
При создании пустой очереди можно указать емкость очереди:
```c#
Queue<string> people = new Queue<string>(16);
```
Инициализация очереди элементами из другой коллекции или массивом
```c#
var employees = new List<string> { "Tom", "Sam", "Bob" };
Queue<string> people = new Queue<string>(employees);
foreach (var person in people) Console.WriteLine(person);
 
Console.WriteLine(people.Count); // 3
```

## Перебор очереди 
```c#
foreach (var person in people) 
{
    Console.WriteLine(person);
}
```



## Проверка перед Queue и Dequeue

```c#
if(people.Count > 0)
{
    var person = people.Peek();
    people.Dequeue();
}
```

# Методы Queue

- `Enqueue(T item)` - добавить в конец
- `Dequeue()` - извлечь первый (удалить)
- `Peek()` - посмотреть первый (не удалять)
- `Contains(T item)` - проверить наличие
- `Clear()` - очистить всё

## Enqueue(T item) - добавление в конец

```c#
queue.Enqueue("Tom");   // [Tom]
queue.Enqueue("Bob");   // [Tom, Bob]
queue.Enqueue("Sam");   // [Tom, Bob, Sam]
```

## Dequeue() - извлечение первого с удалением

```c#
string first = queue.Dequeue(); // first = Tom
// [Bob, Sam]

string next = queue.Dequeue();  // next = Bob
// [Sam]
```

## Peek() - просмотр первого без удаления

```c#
string peek = queue.Peek();     // peek = Sam
// [Sam] (не изменился)
```

## Contains(T item) - проверка наличия

```c#
bool hasSam = queue.Contains("Sam");   // true
bool hasTom = queue.Contains("Tom");   // false
```

## Clear() - очистка

```c#
queue.Clear();  // []
Console.WriteLine(queue.Count); // 0
```

## TryDequeue(out T result) - попытка извлечь первый с удалением
Возвращает true, если очередь не пуста, и записывает первый элемент в result с его удалением. Если очередь пуста - возвращает false, а result получает значение по умолчанию.

```c#
// Очередь: [Sam, John, Mike]
if (queue.TryDequeue(out string name))
{
    Console.WriteLine(name);    // Sam
}
// Очередь стала: [John, Mike]

// Если очередь пуста:
if (queue.TryDequeue(out string empty))
{
    // сюда не зайдет
}
// empty = null (для ссылочных типов)
```

## TryPeek(out T result) - попытка посмотреть первый без удаления
Возвращает true, если очередь не пуста, и записывает первый элемент в result без его извлечения. Если очередь пуста - возвращает false, а result получает значение по умолчанию
```c#
// Очередь: [Sam, John, Mike]
if (queue.TryPeek(out string name))
{
    Console.WriteLine(name);    // Sam
}
// Очередь осталась: [Sam, John, Mike] (не изменилась)

// Если очередь пуста:
if (queue.TryPeek(out string empty))
{
    // сюда не зайдет
}
// empty = null (для ссылочных типов)
```