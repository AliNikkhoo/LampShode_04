using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SlidrAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Sildes");
            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Picture).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PictureAlte).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PictureTitel).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Heading).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Text).IsRequired().HasMaxLength(250);
            builder.Property(x => x.BtnText).IsRequired().HasMaxLength(50);
            
        }
    }
}
