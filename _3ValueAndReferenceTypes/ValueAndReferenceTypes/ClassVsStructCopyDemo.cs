namespace ValueAndReferenceTypes
{
    // класс копирует ссылку, структура копирует значение
    class PersonClass { public string name = string.Empty; }
    struct PersonStruct { public string name; }

    class ClassVsStructCopyDemo
    {
        public static void Run()
        {
            // Класс — копируется ссылка
            PersonClass c1 = new PersonClass { name = "Tom" };
            PersonClass c2 = c1;
            c2.name = "Bob";
            Console.WriteLine($"Класс: c1.name = {c1.name} (изменился через c2)");

            // Структура — копируется значение
            PersonStruct s1 = new PersonStruct { name = "Tom" };
            PersonStruct s2 = s1;
            s2.name = "Bob";
            Console.WriteLine($"Структура: s1.name = {s1.name} (не изменился)");
        }
    }
}
