using InterfaceTrain.Entity;
using InterfaceTrain.Intarface;

namespace InterfaceTrain.repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly List<Product> _products = new();
        public int Count => _products.Count;
        public void Add(Product item) => _products.Add(item);

        public Product? GetById(int Id)
        {
            foreach(Product item in _products)
            {
                if (item.Id == Id)
                {
                    return item;
                }
            }
            return null;
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public bool Remove(int id)
        {
            Product? item = GetById(id);
            if (item is null)
                return false;

            _products.Remove(item);
            return true;
        }
    }
}
