using InterfaceTrain.Intarface;

namespace InterfaceTrain.repository
{
    public class InMemoryRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> _memoryRepository = new List<T>();
        public int Count => _memoryRepository.Count;
        public void Add(T item) => _memoryRepository.Add(item);
        public T? GetById(int id)
        {
            foreach(T item in _memoryRepository)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return default;
        }
        public List<T> GetAll()
        {
            return _memoryRepository;
        }

        public bool Remove(int id)
        {
            T? item = GetById(id);
            if (item is null)
                return false;

            _memoryRepository.Remove(item);
            return true;
        }
    }
}
