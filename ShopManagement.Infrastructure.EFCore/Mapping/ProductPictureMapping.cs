using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        

        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPicture");
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Picture).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PictureTitle).IsRequired().HasMaxLength(500);

            builder.HasOne(x => x.product).WithMany(x => x.productPictures).HasForeignKey(x => x.ProductId);
            
        }
    }
}
