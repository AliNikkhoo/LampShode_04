using InventoryManagement.Application.Inventory;
using InventoryManagement.Appliction;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
 

namespace InventorManagement.Infrastructure.Configuration
{
    public class InventoryManagementBootstrapper
    {
        public static void Configure(IServiceCollection services,string ConnectionString)
        {
            services.AddTransient<IIiventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InventoryApplication>();

            services.AddDbContext<InventoryContext>(x=>x.UseSqlServer(ConnectionString));
        }
    }
}
