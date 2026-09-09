# Событие 

#### позволяет классу уведомлять другие части программы о том, что что-то произошло
```c#
// 1. Объявляем делегат
public delegate void AccountHandler(string message);

// 2. Объявляем событие на основе делегата
public event AccountHandler? Notify;
```

# Вызов события

#### Событие вызывается как метод, но только внутри класса, где оно объявлено. событие может быть null, если на него никто не подписался. Поэтому всегда проверяем через ?.Invoke().

```c#
// Способ 1: через if (старый стиль)
if (Notify != null)
    Notify("Сообщение");

// Способ 2: через ?.Invoke() (современный стиль)
Notify?.Invoke("Сообщение");
```

# Добавление обработчика события

```c#
// 1. Метод-обработчик должен совпадать с делегатом события
void DisplayMessage(string message) 
{
    Console.WriteLine(message);
}

// 2. Подписываемся на событие через +=
account.Notify += DisplayMessage;
```

#### виды обработчика 

```c#
// Обычный метод
account.Notify += DisplayMessage;

// Лямбда-выражение
account.Notify += message => Console.WriteLine(message);

// Анонимный метод
account.Notify += delegate (string message)
{
    Console.WriteLine(message);
};
```

# Добавление и удаление обработчиков

```c#
Account account = new Account(100);

// Добавляем обработчики
account.Notify += DisplayMessage;       // вывод в консоль
account.Notify += DisplayRedMessage;    // вывод красным цветом

account.Put(20);  // Вызовутся оба обработчика

// Удаляем один обработчик
account.Notify -= DisplayRedMessage;

account.Put(50);  // Вызовется только DisplayMessage

void DisplayMessage(string message) => Console.WriteLine(message);

void DisplayRedMessage(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ResetColor();
}
```

# Управление обработчиками (add / remove)

- Нужно выполнить дополнительную логику при подписке/отписке
- Нужно логировать, кто подписывается
- Нужно ограничить количество подписчиков

```c#
public delegate void AccountHandler(string message);

private AccountHandler? _notify;  // приватное поле для хранения

public event AccountHandler Notify
{
    add    // вызывается при +=
    {
        _notify += value;
        Console.WriteLine($"{value.Method.Name} добавлен");
    }
    remove // вызывается при -=
    {
        _notify -= value;
        Console.WriteLine($"{value.Method.Name} удален");
    }
}
```

# Передача данных события

#### Вместо простой строки можно создать класс с данными о событии

```c#
public class AccountEventArgs
{
    public string Message { get; }
    public int Sum { get; }
    
    public AccountEventArgs(string message, int sum)
    {
        Message = message;
        Sum = sum;
    }
}
```

#### Объявляем событие с этим классом

```c#
public delegate void AccountHandler(Account sender, AccountEventArgs e);
public event AccountHandler? Notify;
```

#### Вызываем событие, передавая данные

```c#
public void Put(int sum)
{
    Sum += sum;
    Notify?.Invoke(this, new AccountEventArgs($"Пополнение на {sum}", sum));
}
```

#### Обработчик получает данные

```c#
void DisplayMessage(Account sender, AccountEventArgs e)
{
    Console.WriteLine($"Сообщение: {e.Message}");
    Console.WriteLine($"Сумма: {e.Sum}");
    Console.WriteLine($"Баланс: {sender.Sum}");
}
```