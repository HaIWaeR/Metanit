# Наследование обобщенных типов

Базовый класс
```csharp
class Person<T>
{
    public T Id { get; }
    public Person(T id) => Id = id;
}
```

# Способы наследования

## Наследник с тем же T

```c#
class UniversalPerson<T> : Person<T>
{
    public UniversalPerson(T id) : base(id) { }
}
```

## Наследник с фиксированным типом (необобщённый)

```c#
class StringPerson : Person<string>
{
    public StringPerson(string id) : base(id) { }
}
```

## Наследник обобщённый, но с другим типом

```c#
class IntPerson<T> : Person<int>
{
    public T Code { get; set; }
    public IntPerson(int id, T code) : base(id) => Code = code;
}
```

## Наследник с двумя типами (свой + родительский)

```c#
class MixedPerson<T, K> : Person<T>
{
    public K Code { get; set; }
    public MixedPerson(T id, K code) : base(id) => Code = code;
}
```

## Ограничения при наследовании
```c#
class Person<T> where T : class
{
    public T Id { get; }
    public Person(T id) => Id = id;
}

class UniversalPerson<T> : Person<T> where T : class
{
    public UniversalPerson(T id) : base(id) { }
}
```
Если базовый класс ограничивает T, наследник обязан повторить это ограничение.

## Итог

Тот же T   
```c#
 class A<T> : Person<T>
```
Фиксированный тип 
```c#
class A : Person<int>
```
Свой параметр
```c#
 class A<T> : Person<int>
```
Свой + родительский
```c#
class A<T, K> : Person<T>
```
Ограничение
```c#
повторяем where T : class
```