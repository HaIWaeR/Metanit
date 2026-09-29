using InterfaceTrain.Intarface;

namespace InterfaceTrain.Entity
{
    public class Order : IEntity
    {
        private static int _count = 1;
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal Sum { get; set; }
        public Order(Client client, decimal sum)
        {
            Id = _count;
            ClientId = client.Id;
            Sum = sum;
            _count++;
        }
    }
}
