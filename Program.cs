namespace MyBankApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var account = new BankAccount("Padma", 10000);
            Console.WriteLine($"Account {account.OwnerName} mapped accno {account.AccNumber} balance {account.Balance}");
            account.MakeWithdrawal(200, DateTime.Now, "withdraw");
            Console.WriteLine(account.Balance);
            try
            {
                account.MakeDeposit(-10, DateTime.Now, "deposit");
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            account.MakeWithdrawal(50, DateTime.Now, "withdraw");
            Console.WriteLine(account.Balance);
            Console.WriteLine(account.GetTransactionSummury());
        }
    }
}