using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingBugFix
{
    public class TransactionService
    {
        public void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount)
        {
            if (amount > fromAccount.Balance)
            {
                Console.WriteLine($"{fromAccount.Iban} has Insufficient funds");
                return;
            }
            fromAccount.Balance -= amount;
            toAccount.Balance += amount;
        }
    }
}
