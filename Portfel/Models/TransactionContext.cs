using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Data
{
    public class TransactionContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set;}

        public string path = @"C:\Users\kris\source\repos\Portfel\transactionDb.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source ={path}");
    }
}
