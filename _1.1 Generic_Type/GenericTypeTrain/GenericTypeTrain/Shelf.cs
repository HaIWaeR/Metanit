namespace GenericTypeTrain
{
    public class Shelf<T>
    {
        private List<T>? _list = new List<T>();
        public int Count => _list.Count; 
        public void Add(T item) => _list.Add(item);
        public T Get(int index) => _list[index];
        public void ShowAll()
        {
            for (int i = 0; i < _list.Count; i++)
            {
                Console.WriteLine($"Элемент {i}: {_list[i]}");
            }
        }
    }
}
