using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagemant.Infrastucture.EfCore
{
    public class AccountContext :DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options ) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(AccountContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
