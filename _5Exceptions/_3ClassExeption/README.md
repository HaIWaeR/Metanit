# Типы исключений. Класс Exception
Все исключения наследуются от класса Exception. Он содержит основные свойства для получения информации об ошибке:


## Свойства класса Exception

### Message - Содержит текст ошибки
```csharp
try
{
    int x = 5;
    int y = x / 0;
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
Вывод: 
```text
Attempted to divide by zero
```

### StackTrace - Показывает последовательность вызовов методов, которая привела к ошибке
```csharp
try
{
    MethodA();
}
catch (Exception ex)
{
    Console.WriteLine(ex.StackTrace);
}

void MethodA()
{
    MethodB();
}

void MethodB()
{
    int x = 5;
    int y = x / 0;
}
```

Вывод
```text
at Program.MethodB() in Program.cs:строка 20
at Program.MethodA() in Program.cs:строка 15
at Program.Main() in Program.cs:строка 8
```

### TargetSite - Возвращает метод, в котором произошла ошибка
```csharp
try
{
    int x = 5;
    int y = x / 0;
}
catch (Exception ex)
{
    Console.WriteLine(ex.TargetSite);
}
```

Вывод 
```text
Void Main()
```

### Source - Имя сборки или объекта, вызвавшего исключение

```csharp
try
{
    int x = 5;
    int y = x / 0;
}
catch (Exception ex)
{
    Console.WriteLine(ex.Source);
}
```
Вывод:
```text
MyProgram
```

### InnerException - Хранит исключение, которое стало причиной текущего
```csharp
try
{
    try
    {
        int x = 5;
        int y = x / 0;
    }
    catch (DivideByZeroException ex)
    {
        throw new Exception("Ошибка в программе", ex);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.InnerException.Message);
}
```
Вывод:
```text
Ошибка в программе
Attempted to divide by zero.
```

## Обработка разных типов

Можно использовать несколько блоков catch для разных типов исключений

```csharp
try
{
    int[] numbers = new int[4];
    numbers[7] = 9; // IndexOutOfRangeException
}
catch (DivideByZeroException)
{
    Console.WriteLine("Деление на ноль");
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine($"Другая ошибка: {ex.Message}");
}
```

Важные правила
- Блоки catch для более конкретных типов должны идти перед более общими
- Exception лучше ставить последним, чтобы обработать все остальные ошибки
- Если подходящий catch не найден - программа падает
- В одном try может быть несколько catch для разных типов исключений

## Распространённые типы исключений в C#

- DivideByZeroException - деление на ноль
- IndexOutOfRangeException - индекс вне диапазона массива
- NullReferenceException - обращение к null объекту
- ArgumentException - некорректное значение аргумента 
- ArgumentNullException - передача null вместо аргумента 
- ArgumentOutOfRangeException - значение аргумента вне допустимого диапазона 
- InvalidCastException - недопустимое преобразование типов
- InvalidOperationException - вызов метода невозможен в текущем состоянии объекта 
- FormatException - неверный формат строки или данных 
- IOException - ошибка ввода-вывода 
- FileNotFoundException - файл не найден 
- NotSupportedException - операция или функция не поддерживается 

## Распространённые исключения Entity Framework

- DbUpdateException - общая ошибка при сохранении в БД 
- EntityCommandExecutionException - ошибка выполнения команды БД 
- UniqueConstraintException - нарушение уникальности (дубликат) 
- CannotInsertNullException - попытка вставить null в обязательное поле 
- MaxLengthExceededException - превышение длины поля 
- ReferenceConstraintException - нарушение внешнего ключа 
- NumericOverflowException - числовое переполнение 

## Распространённые исключения ASP.NET Core 
- BadRequestException - неверный запрос (400)
- UnauthorizedException - неавторизованный доступ (401)
- ForbiddenException - доступ запрещен (403)
- NotFoundException - ресурс не найден (404)
- ConflictException - конфликт данных (409)
- TooManyRequestsException - слишком много запросов (429)
- InternalServerErrorException - внутренняя ошибка сервера (500)
- ValidationException - ошибка валидации модели
- TimeoutException - превышение времени ожидания
- InvalidKeyException - неверный формат или значение ключа
- KeyNotFoundException - ключ не найден
- DuplicateKeyException - дублирующийся ключ
- MissingKeyException - отсутствует обязательный ключ