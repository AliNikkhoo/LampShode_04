
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagemant.Infrastucture.EfCore.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.FullName).HasMaxLength(100);
            builder.Property(x => x.UserName).HasMaxLength(100);
            builder.Property(x => x.PassWord).HasMaxLength(1000);
            builder.Property(x => x.ProfilePhoto).HasMaxLength(500);
            builder.Property(x => x.Mobile).HasMaxLength(20);
        }
    }
}
