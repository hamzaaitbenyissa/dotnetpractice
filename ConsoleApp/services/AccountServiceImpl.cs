namespace app
{
    public class AccountServiceImpl : AccountService
    {
        Dictionary<int, Account> accounts = new Dictionary<int, Account>();

        public void AddNewAccount(Account account)
        {
            this.accounts.Add(account.Id, account);
        }

        public List<Account> GetAllAccounts()
        {
            return accounts.Values.ToList();
        }

        public Account GetAccountById(int id)
        {
            return accounts[id];
        }

        public List<Account> GetDebitedAccounts()
        {
            return accounts.Values.Where(acc => acc.Balance < 0).ToList();
        }

        public long GetBalanceAVG()
        {
            return (long)accounts.Values.Average(acc => acc.Balance);
        }
    }
}