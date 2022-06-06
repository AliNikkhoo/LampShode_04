using DiscountManagement.Domain.ColleagueDiscount.Agg;
using DiscountManagement.Domain.CustomerDiscount.Agg;
using DisCountManamgement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DisCountManamgement.Infrastructure.EFCore
{
    public class DiscountContext :DbContext
    {
        public DbSet<CustomerDiscount> customerDiscounts { get; set; }
        public DbSet<ColleagueDiscount> colleagueDiscounts { get; set; }
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
