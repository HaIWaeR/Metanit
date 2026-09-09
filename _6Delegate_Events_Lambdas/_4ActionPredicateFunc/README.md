# Action действие, которое ничего не возвращает в качестве возвращаемого типа имеет тип void, можно передать до 16 значений в метод.

```c#
public delegate void Action();
public delegate void Action<in T>(T obj)
```

