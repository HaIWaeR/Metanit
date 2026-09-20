namespace DelegatesPractice.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public Client? Client { get; set; }

        public Order() { }
        public Order(int id, decimal amount, DateTime createdAt)
        {
            Id = id;
            Amount = amount;
            CreatedAt = createdAt;
            Status = OrderStatus.New;
        }

        public override string ToString()
            => $"Id: {Id}, Amount: {Amount}, ClientId: {Client.Id}, {Client.Name}, CreatedAt: {CreatedAt}, Status: {Status}";
    }
}
