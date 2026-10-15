namespace InterfaceDiContain.Entity
{
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;  
        }
        public override string ToString() => $"Id: {Id}, Name: {Name} Price: {Price}";

        // По возрастание
        //public int CompareTo(Product? other)
        //{
        //    if (other is null) return 1;
        //    return Price.CompareTo(other.Price);
        //}

        public int CompareTo(Product? other)
        {
            if (other is null) return 1;
            return other.Price.CompareTo(Price);
        }
    }
}
