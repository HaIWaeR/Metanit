using InterfaceTrain.repository;
using InterfaceTrain.Intarface;
using InterfaceTrain.Entity;

namespace InterfaceTrain
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayable player = new Speaker();
            player.Play("Баста");

            List<IPlayable> listPlay = new List<IPlayable>()
            {
                new Speaker(),
                new Phone()
            };

            foreach (IPlayable item in listPlay)
            {
                item.Play("Говорит москва");
                item.Stop();
                PrintVolume(item);
            }

            //----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            Phone phoneApple = new Phone();  


            IPlayable playablePhone = phoneApple;
            IChargeable chargeablePhone = phoneApple;

            playablePhone.Play("SOAD");

            Console.WriteLine(chargeablePhone.BatteryLevel);
            chargeablePhone.Charge(20);
            Console.WriteLine(chargeablePhone.BatteryLevel);

            //----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");
            
            IRepository<Product> productRepository = new ProductRepository();
            
            Product windows = new Product("Win-7", 5_000);
            Product linux = new Product("Uduntu", 3_400);
            productRepository.Add(windows);
            productRepository.Add(linux);

            Product? found = productRepository.GetById(1);
            if (found is not null)
                Console.WriteLine($"Имя: {found.Name}, Цена: {found.Price}");

            Product? missing = productRepository.GetById(999);
            if (missing is null)
                Console.WriteLine("Товар с id 999 не найден");
            else
                Console.WriteLine($"Найдено: {missing.Name}");

            Console.WriteLine($"\nВсе товары: \n");
            foreach (Product item in productRepository.GetAll())
            {
                Console.WriteLine($"{item.Id}. {item.Name} — {item.Price} руб.");
            }

            //----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            IRepository<Product> products = new InMemoryRepository<Product>();
            Product phone = new Product("Телефон", 2_500);
            products.Add(phone);
            Console.WriteLine(products.GetById(phone.Id)?.Name);

            IRepository<Client> clients = new InMemoryRepository<Client>();
            clients.Add(new Client("Bob"));
            clients.Add(new Client("Sam"));
            clients.Add(new Client("Sam"));
            Console.WriteLine(clients.GetById(1)?.Name);

            //----------------------------------------------------------------
            Console.WriteLine($"\n{new string('_', 50)}\n");

            IRepository<Order> orders = new InMemoryRepository<Order>();
            Console.WriteLine("Clients");
            PrintAll(clients);
            Console.WriteLine("Products");
            PrintAll(products);
            Console.WriteLine("Orders");

            Client tom = new Client("Tom");
            Client sam = new Client("Sam");
            Order android = new Order(sam, 1200);
            Order poko = new Order(tom, 2500);
            orders.Add(android);
            orders.Add(poko);
            PrintAll(orders);

            Console.WriteLine($"Элементов в clients: {clients.Count}");
            clients.Remove(1);
            Console.WriteLine($"Элементов в clients: {clients.Count}");

        }
        static void PrintAll<T>(IRepository<T> repo) where T : IEntity
        {
            foreach (T item in repo.GetAll())
            {
                Console.WriteLine($"Id: {item.Id}");
            }
        }

        public static void PrintVolume(IPlayable playable) 
            => Console.WriteLine($"Громкость: {playable.Volume}");
    }
}