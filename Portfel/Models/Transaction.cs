using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        public string TransactionName { get; set; }
        public decimal Amount { get; set; }
        //public string Group { get; set; }
        //public DateTime date { get; set; }
        //public decimal BalanceAfter { get; set; }
        
        public bool TransactionType { get; set; }


    }
}
