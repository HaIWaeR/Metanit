using InterfaceTrain.Intarface;

namespace InterfaceTrain.Entity
{
    public class Product : IEntity
    {
        private static int _count = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Id = _count;
            Name = name;
            Price = price;
            _count++;
        }
    }
}
