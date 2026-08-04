namespace BankingSystem
{
    public class Transaction
    {
        private static int _nextId = 1;
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string type, decimal amount)
        {
            Id = _nextId++;
            Type = type;
            Amount = amount;
            Date = DateTime.Now;
        }
        public Transaction(string type, decimal amount, string description)
        {
            Id = _nextId++;
            Type = type;
            Amount = amount;
            Description = description;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{Date}] {Type}: {Amount} руб. {Description}";
        }
    }
}
