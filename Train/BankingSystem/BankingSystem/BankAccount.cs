namespace BankingSystem
{
    public class BankAccount
    {
        private static int _nextId = 1;
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }
        private List<Transaction> _transactions = [];


        public BankAccount(string ownerName)
        {
            OwnerName = ownerName;
            Balance = 0;
            Id = _nextId++;
        }

        public bool Deposit(decimal amount, bool addTransaction = true)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма не может быть отрицательной или равной 0");
                return false;
            }

            Balance += amount;

            if (addTransaction)
            {
                AddTransaction("Пополнение", amount);
            }

            return true;
        }

        public bool Withdraw(decimal amount, bool addTransaction = true)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма для снятия должн быть больше 0");
                return false;
            }
            if (Balance < amount)
            {
                Console.WriteLine("Недостаточно средств для снятия");
                return false;
            }

            Balance -= amount;

            if (addTransaction)
            {
                AddTransaction("Снятие", amount);
            }
            return true;
        }

        public void AddTransaction(string type, decimal amount)
        {
            _transactions.Add(new Transaction(type, amount));
        }
        public void AddTransaction(string type, decimal amount, string description)
        {
            _transactions.Add(new Transaction(type, amount, description));
        }

        public void ShowTransactionHistory()
        {
            if (_transactions.Count == 0)
            {
                Console.WriteLine("Транзакцией нету");
            }

            foreach (Transaction transaction in _transactions)
            {
                Console.WriteLine(transaction);
            }
        }


        public override string ToString() => $"Id: {Id}, Name: {OwnerName}, Balance: {Balance} ";
    }
}
