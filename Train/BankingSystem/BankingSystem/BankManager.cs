using System.Transactions;

namespace BankingSystem
{
    public class BankManager
    {
        private List<BankAccount> _accounts = new List<BankAccount>();

        public void CreateAccount(string ownerName)
        {
            _accounts.Add(new BankAccount(ownerName));
            Console.WriteLine($"Счёт '{ownerName}' успешно создан!");
        }
        public void ShowAllAccounts()
        {
            for (int i = 0; i < _accounts.Count; i++)
            {
                Console.WriteLine(_accounts[i].ToString());
            }
        }
        public BankAccount GetAccountById(int id)
        {
            foreach (BankAccount account in _accounts)
            {
                if (account.Id == id)
                {
                    return account;
                }
            }

            return null;
        }
        public bool DepositToAccount(int id, decimal amount)
        {
            foreach(BankAccount account in _accounts)
            {
                if (account.Id == id)
                {
                    account.Deposit(amount);
                    return true;
                }
            }
            return false;
        }
        public bool WithdrawFromAccount(int id, decimal amount)
        {
            foreach(BankAccount account in _accounts)
            {
                if (account.Id == id)
                {
                    return account.Withdraw(amount);
                }
            }
            
            return false;
        }
        public bool Transfer(int fromId, int toId, decimal amount)
        {
            BankAccount? fromAccount = null;
            BankAccount? toAccount = null;

            foreach (BankAccount account in _accounts)
            {
                if (account.Id == fromId) fromAccount = account; 
                if (account.Id == toId) toAccount = account;
            }

            if (fromAccount == null)
            {
                Console.WriteLine("Отправитель не найден");
                return false;
            }
            if (toAccount == null)
            {
                Console.WriteLine("Получатель не найден");
                return false;
            }

            if (!fromAccount.Withdraw(amount, false))
            {
                return false;
            }

            toAccount.Deposit(amount, false);
            Console.WriteLine("Перевод успешно выполнен");
            fromAccount.AddTransaction("Перевод", amount, $"На счет #{toId}" );
            toAccount.AddTransaction("Перевод", amount, $"Со счета #{fromId}" );
            return true;
        }
        public void ShowTransactionHistory(int accountId)
        {
            foreach (BankAccount account in _accounts)
            {
                if (account.Id == accountId)
                {
                    account.ShowTransactionHistory();
                }
            }

        }
    }
}
