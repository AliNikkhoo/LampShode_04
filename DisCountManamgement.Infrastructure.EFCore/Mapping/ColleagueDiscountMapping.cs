using DiscountManagement.Domain.ColleagueDiscount.Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisCountManamgement.Infrastructure.EFCore.Mapping
{
    internal class ColleagueDiscountMapping : IEntityTypeConfiguration<ColleagueDiscount>
    {
        public void Configure(EntityTypeBuilder<ColleagueDiscount> builder)
        {
            builder.ToTable("ColleaugeDisconts");
            builder.HasKey(x=>x.Id);
        }
    }
}
