using DiscountManagement.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscount.Agg;
using DisCountManamgement.Infrastructure.EFCore.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagementConfiguration
{
    public class DiscountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services ,string connectionString)
        {
            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();

            services.AddDbContext(x=>x.UseSql)
        }
    }
}
