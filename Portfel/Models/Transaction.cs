using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        public string TransactionName { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Group { get; set; }
        public DateTime date { get; set; }
        public decimal BalanceAfter { get; set; }
        
        public bool TransactionType { get; set; }


    }
}
