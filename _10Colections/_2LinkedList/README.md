# LinkedList<T> - двухсвязный список

LinkedList<T> - это коллекция, где каждый элемент (узел) хранит ссылки на предыдущий и следующий узел.

## Создание

```csharp
// Пустой список
LinkedList<string> people = new LinkedList<string>();

// Из другой коллекции
var employees = new List<string> { "Tom", "Sam", "Bob" };
LinkedList<string> people = new LinkedList<string>(employees);
```

## Свойства

- Count - количество элементов
- First - первый узел
- Last - последний узел

```c#
Console.WriteLine(people.Count);
Console.WriteLine(people.First.Value);
Console.WriteLine(people.Last.Value);
```

## LinkedListNode

У узла есть свойства:
- Value - значение
- Next - ссылка на следующий
- Previous - ссылка на предыдущий

```c#
LinkedListNode<string> node = people.First;
Console.WriteLine(node.Value);
Console.WriteLine(node.Next.Value);
Console.WriteLine(node.Previous);
```

## Перебор 

От начала к концу:
```c#
var current = people.First;
while (current != null)
{
    Console.WriteLine(current.Value);
    current = current.Next;
}
```

От конца к началу:
```c#
current = people.Last;
while (current != null)
{
    Console.WriteLine(current.Value);
    current = current.Previous;
}
```

## Методы

- `AddFirst(T) / AddFirst(node)` - Вставить в начало
- `AddLast(T) / AddLast(node)` - Вставить в конец
- `AddAfter(node, T) / AddAfter(node, newNode)` - Вставить после указанного узла
- `AddBefore(node, T) / AddBefore(node, newNode)` - Вставить перед указанным узлом
- `RemoveFirst()` - Удалить первый
- `RemoveLast()` - Удалить последний
- `Remove(T)` - Удалить по значению
- `Remove(node)` - Удалить конкретный узел
- `Find(T)` - Найти узел по значению
- `FindLast(T)` - Найти узел (с конца)
- `Clear()` - Очистить всё





## AddLast(T value) - добавление в конец

```c#
LinkedList<string> list = new LinkedList<string>();
list.AddLast("Tom");      // [Tom]
list.AddLast("Bob");      // [Tom] <--> [Bob]
list.AddLast("Sam");      // [Tom] <--> [Bob] <--> [Sam]
```

## AddFirst(T value) - добавление в начало

```c#
list.AddFirst("Alice");   // [Alice] <--> [Tom] <--> [Bob] <--> [Sam]
```

## AddAfter(LinkedListNode<T> node, T value) - вставка после узла

```c#
LinkedListNode<string> node = list.Find("Bob");
list.AddAfter(node, "Mike");
// [Alice] <--> [Tom] <--> [Bob] <--> [Mike] <--> [Sam]
```

## AddBefore(LinkedListNode<T> node, T value) - вставка перед узлом

```c#
LinkedListNode<string> node = list.Find("Bob");
list.AddBefore(node, "John");
// [Alice] <--> [Tom] <--> [John] <--> [Bob] <--> [Mike] <--> [Sam]
```

## AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode) - вставка готового узла после

```c#
LinkedListNode<string> newNode = new LinkedListNode<string>("Kate");
LinkedListNode<string> node = list.Find("Tom");
list.AddAfter(node, newNode);
// [Alice] <--> [Tom] <--> [Kate] <--> [John] <--> [Bob] <--> [Mike] <--> [Sam]
```

## AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode) - вставка готового узла перед

```c#
LinkedListNode<string> newNode2 = new LinkedListNode<string>("Leo");
LinkedListNode<string> node2 = list.Find("Sam");
list.AddBefore(node2, newNode2);
// [Alice] <--> [Tom] <--> [Kate] <--> [John] <--> [Bob] <--> [Mike] <--> [Leo] <--> [Sam]
```

## AddFirst(LinkedListNode<T> node) - добавление готового узла в начало

```c#
LinkedListNode<string> firstNode = new LinkedListNode<string>("First");
list.AddFirst(firstNode);
// [First] <--> [Alice] <--> [Tom] <--> ... 
```

## AddLast(LinkedListNode<T> node) - добавление готового узла в конец

```c#
LinkedListNode<string> lastNode = new LinkedListNode<string>("Last");
list.AddLast(lastNode);
// ... <--> [Sam] <--> [Last]
```

## RemoveFirst() - удаление первого узла

```c#
list.RemoveFirst();
// Удалили [First]
// Теперь первый — [Alice]
```

## RemoveLast() - удаление последнего узла

```c#
list.RemoveLast();
// Удалили [Last]
// Теперь последний — [Sam]
```

## Remove(T value) - удаление по значению (удаляет первое вхождение)

```c#
list.Remove("Bob");
// [Alice] <--> [Tom] <--> [Kate] <--> [John] <--> [Mike] <--> [Leo] <--> [Sam]
```

## Remove(LinkedListNode<T> node) - удаление конкретного узла

```c#
LinkedListNode<string> nodeToRemove = list.Find("Mike");
list.Remove(nodeToRemove);
// [Alice] <--> [Tom] <--> [Kate] <--> [John] <--> [Leo] <--> [Sam]
```

## Find(T value) - поиск узла по значению (с начала)

```c#
LinkedListNode<string> found = list.Find("Sam");
Console.WriteLine(found?.Value); // Sam
Console.WriteLine(found?.Previous?.Value); // Leo
```

## FindLast(T value) - поиск узла по значению (с конца)

```c#
list.AddLast("Sam");
LinkedListNode<string> lastFound = list.FindLast("Sam");
Console.WriteLine(lastFound?.Previous?.Value); // Leo
```

## Clear() - очистка списка

```c#
list.Clear();
Console.WriteLine(list.Count); // 0
```
