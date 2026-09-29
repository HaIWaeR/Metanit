namespace InterfaceTrain.Intarface
{
    interface IRepository<T>
    {
        int Count { get; }
        void Add(T item);
        T? GetById(int id);
        List<T> GetAll();
        bool Remove(int id);

    }
}
