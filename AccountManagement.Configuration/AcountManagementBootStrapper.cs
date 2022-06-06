
using _0_Framework.Application;
using AccountManagemant.Infrastucture.EfCore;
using AccountManagemant.Infrastucture.EfCore.Repository;
using AccountManagement.Application.Contraccts.Account;
using AccountManagement.Domain.AccountAgg;
using AccountmanagementApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AccountManagement.Configuration
{
    public class AcountManagementBootStrapper
    {
        public static void Configure(IServiceCollection services ,string Connectionstring)
        {
            services.AddTransient<IAccountApplication,AccountApplication>();
            services.AddTransient<IAccountRepository,AccountRepository>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddDbContext<AccountContext>(x=>x.UseSqlServer(Connectionstring));
        }
    }
}
