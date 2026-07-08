# Обобщения (Generics)

## Проблема без обобщений

```c#
class Person
{
    public object Id { get; set; }  // можно int, string, что угодно
}

Person p = new Person();
p.Id = 123;          // int в object (упаковка)
int id = (int)p.Id;  // object в int (распаковка, может упасть)
```

Минусы:

- Упаковка/распаковка (медленно)
- Нет проверки типов на этапе компиляции
- Можно случайно привести не к тому типу → исключение

## Как делают с Generics

```c#
class Person<T>
{
    public T Id { get; set; }   // вместо T подставляется нужный тип
}

Person<int> p1 = new Person<int>();
p1.Id = 123;              // int, без упаковки

Person<string> p2 = new Person<string>();
p2.Id = "abc";            // string, без упаковки
```

Плюсы:

- Без упаковки/распаковки
- Ошибка при компиляции, если тип не совпадает
- Код один — типов много

## Несколько типов

```c#
class Person<T, K>
{
    public T Id { get; set; }
    public K Password { get; set; }
}

Person<int, string> p = new Person<int, string>();
p.Id = 123;
p.Password = "qwerty";
```

## Обобщённый метод

```c#
void Swap<T>(ref T a, ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}

int x = 5, y = 10;
Swap(ref x, ref y);   // работает с int

string s1 = "a", s2 = "b";
Swap(ref s1, ref s2); // работает с string
```

Обобщения позволяют писать код для любого типа, сохраняя проверку типов на этапе компиляции.