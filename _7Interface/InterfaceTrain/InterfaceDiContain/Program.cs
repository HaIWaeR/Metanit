using InterfaceDiContain.Entity;

namespace InterfaceDiContain
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product ( 2, "Тостер", 2000),
                new Product ( 1, "Чайник", 1500),
                new Product ( 3, "Микроволновка", 5000 )
            };

            Array.Sort(products);

            foreach (var item in products)
                Console.WriteLine(item);

            var byName = products.OrderBy(p => p.Name);

            foreach (var item in byName)
                Console.WriteLine(item.ToString());
        }
    }
}