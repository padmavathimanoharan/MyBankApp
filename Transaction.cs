using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankApp
{
    public class Transaction
    {
        public decimal Amount { get;}
        public DateTime date { get;}
        public string Notes { get;}

        public Transaction(decimal amount, DateTime date, string notes)
        {
            Amount = amount;
            this.date = date;
            Notes = notes;
        }
    }
}
