using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Data
{
    class TransactionDbContext : DbContext
    {
        #region Constructor
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion
        #region Public properties
        public DbSet<Transaction> Transactions { get; set; }
        #endregion
        #region Overridden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(GetTransactions());
            base.OnModelCreating(modelBuilder);
        }
        #endregion
        #region Private methods
        private Transaction[] GetTransactions()
        {
            return new Transaction[]
            {
            new Transaction { Id = 1, TransactionName="one",Amount=10, TransactionType=true },
            new Transaction { Id = 2, TransactionName="two",Amount=1000, TransactionType=true  },
            new Transaction { Id = 3, TransactionName="three",Amount=20, TransactionType=false },
            new Transaction { Id = 4, TransactionName="four",Amount=300, TransactionType=true },
            };
        }
        #endregion
    }
}
