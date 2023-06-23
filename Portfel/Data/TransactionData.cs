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

        public static List<Transaction> GetList()
        {
            using (var db = new TransactionContext())
            {
                var incomeList = db.Transactions.ToList();
                return incomeList;
            }
        }

        public static List<Transaction> GetIncomeList()
        {
            using(var db = new TransactionContext())
            {
                var incomeList = db.Transactions.Where(b => b.TransactionType == true && b.date<DateTime.Now).ToList();
                return incomeList;
            }
        }

        public static List<Transaction> GetOutcomeList()
        {
            using (var db = new TransactionContext())
            {
                var outcomeList = db.Transactions.Where(b => b.TransactionType == false && b.date < DateTime.Now).ToList();
                return outcomeList;
            }
        }
        
        public static List<Transaction> GetPlannedList()
        {
            using (var db = new TransactionContext())
            {
                
                var plannedList = db.Transactions.OrderBy(x => x.date).Where(x =>x.date >DateTime.Now).ToList();
                return plannedList;
            }
        }
        
        public static string GetBalance()
        {
            using (var db = new TransactionContext())
            {
                var balance = db.Transactions.OrderByDescending(x => x.date).Where(x => x.date < DateTime.Now).Select(x =>x.BalanceAfter).FirstOrDefault().ToString(); 
                return balance;
            }

        }

    }
    
}
