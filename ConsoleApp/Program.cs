namespace app
{
    internal class Program
    {
        private static void displayMenu()
        {
            Console.Out.WriteLine("*************** MENU *****************");
            Console.Out.WriteLine("* 1 ---->   Add a new Account        *");
            Console.Out.WriteLine("* 2 ---->   Get All Accounts         *");
            Console.Out.WriteLine("* 3 ---->   Get an Account By Id     *");
            Console.Out.WriteLine("* 4 ---->   Get Debited Accounts     *");
            Console.Out.WriteLine("* 5 ---->   Get Balance AVG          *");
            Console.Out.WriteLine("* 6 ---->   Exit                     *");
            Console.Out.WriteLine("************* BENYISSA ***************");
        }

        private static int getChoice()
        {
            displayMenu();
            Console.Out.WriteLine("Your Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            while (choice < 1 || choice > 6)
            {
                Console.Out.WriteLine("Invalid choice !");
                choice = Convert.ToInt32(Console.ReadLine());
            }

            return choice;
        }


        private static void Main(string[] args)
        {
            AccountServiceImpl accountServiceImpl = new AccountServiceImpl();
            int choice = getChoice();
            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        Console.Out.WriteLine("Account Details : ");
                        Console.Out.Write("id : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Out.Write("balance : ");
                        double balance = Convert.ToDouble(Console.ReadLine());
                        Console.Out.Write("currency : ");
                        string currency = Console.ReadLine();
                        accountServiceImpl.AddNewAccount(new Account(id, currency, balance));
                        break;
                    case 2:
                        foreach (var acc in accountServiceImpl.GetAllAccounts())
                        {
                            Console.Out.WriteLine(acc);
                        }

                        break;
                    case 3:
                        Console.Out.Write("ID : ");
                        try
                        {
                            Account account = accountServiceImpl.GetAccountById(Convert.ToInt32(Console.ReadLine()));
                            Console.Out.WriteLine(account);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Sorry, but there is no account with this ID");
                        }

                        break;
                    case 4:
                        foreach (var acc in accountServiceImpl.GetDebitedAccounts())
                        {
                            Console.Out.WriteLine(acc);
                        }

                        break;
                    case 5:
                        Console.Out.WriteLine("Average of balance : $" + accountServiceImpl.GetBalanceAVG());
                        break;
                    default:
                        Console.Out.WriteLine("ok ");
                        break;
                }

                Thread.Sleep((int)TimeSpan.FromSeconds(1).TotalMilliseconds);
                choice = getChoice();
            }

            Console.Out.WriteLine("Thank you for using our App. Bye ...");
        }
    }
}