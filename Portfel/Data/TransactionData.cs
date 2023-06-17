using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Data
{
    public static class TransactionData
    {
        public static void AddTransactionToDB(Transaction transaction)
        {
            using(var db = new TransactionContext())
            {
                db.Add(transaction);
                db.SaveChanges();
            }
        }

        public static List<Transaction> GetTransactionList()
        {
            using(var db = new TransactionContext())
            {
                return db.Transactions.ToList();
            }
        }
    }
}
