namespace app
{

    public interface AccountService
    {
        public void AddNewAccount(Account account);
        public List<Account> GetAllAccounts();
        public Account GetAccountById(int id);
        public List<Account> GetDebitedAccounts();
        public long GetBalanceAVG();

    }
}
