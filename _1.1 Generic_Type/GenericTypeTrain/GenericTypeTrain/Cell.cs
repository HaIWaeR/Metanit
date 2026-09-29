namespace GenericTypeTrain
{
    class Cell<T>
    {
        public T Value { get; set; }

        public Cell(T value)
        {
            Value = value;
        }

        public void Show()
            => Console.WriteLine("В ячейке: " + Value);
    }
}