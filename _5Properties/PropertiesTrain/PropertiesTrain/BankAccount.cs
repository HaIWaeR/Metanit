using System.ComponentModel.Design;

namespace PropertiesTrain
{
    // чтение и запись 
    public class BankAccount
    {
        public string AccountNumber { get; }
        private string _ownerName;
        private decimal _balance;
        private string _password = String.Empty;
        
        public BankAccount(string accountNumber, string ownerName, decimal initialBalance, string password)
        {
            AccountNumber = accountNumber;
            _ownerName = ownerName;
            _balance = initialBalance;
            _password = password;
        }

        public string OwnerName
        {
            get
            {
                return _ownerName;
            }
            set
            {
                _ownerName = value;
            }
        }
        public decimal Balance { get { return _balance; } }
        public string Password { set { _password = value; } }
        public decimal Deposit(decimal amount)
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"Вы внесли: {amount} Р");
            return _balance += amount;
        }


        public decimal Withdraw(decimal amount, string passwordInput)
        {
            if (passwordInput == _password)
            {
                if (_balance >= amount)
                {
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine($"Вы сняли: {amount} Р");
                    return _balance -= amount;
                }
                throw new Exception("На балансе недостаточно средств");
            }
            else
            {
                throw new ArgumentNullException("Пароль не подходит");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"Счёт: {AccountNumber}\nВладелец: {OwnerName}\nБаланс: {Balance}");
        }

    }
}
