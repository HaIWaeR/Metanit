namespace LimitationsGeneralizations
{
    class Animal<T> where T : struct { } // Ограничение на значение
    class Animal2<T> where T : class { } // Ограничение на ссылочный тип
    class Animal3<T> where T : new() { } // Ограничение на наличие конструктора без параметров  

}
