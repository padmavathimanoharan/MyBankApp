using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankApp
{
    public class BankAccount
    {
        public string AccNumber { get; }
        public string OwnerName { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in alltransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        private static int AutoAccNumber = 500001;

        private List<Transaction> alltransactions = new List<Transaction>();
        public BankAccount(string name, decimal initialBalance)
        {           
            this.OwnerName = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial fund");
            this.AccNumber = AutoAccNumber.ToString();
            AutoAccNumber++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string Note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount should not be negative");
            }
            var deposit = new Transaction(amount, date, Note);
            alltransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string Note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount sould be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Low Balance");
            }
            var withdrawal = new Transaction(-amount, date, Note);
            alltransactions.Add(withdrawal);
        }

        public string GetTransactionSummury()
        {
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\t\tNotes");
            foreach(var transaction in alltransactions)
            {
                report.AppendLine($"{transaction.date.ToShortDateString()}\t{transaction.Amount}\t\t{transaction.Notes}");
            }
            return report.ToString();
        }
    }
}
