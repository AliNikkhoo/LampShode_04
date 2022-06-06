using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(15).IsRequired();
            builder.Property(x => x.ShortDesCription).HasMaxLength(500).IsRequired();
            builder.Property(x => x.picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(255).IsRequired();
            builder.Property(x => x.pictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(x => x.KeyWords).HasMaxLength(100).IsRequired();
            builder.Property(x => x.MetaDesCription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(500).IsRequired();

            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x=>x.CategoryId) ;

            builder.HasMany(x => x.productPictures).WithOne(x => x.product).HasForeignKey(x=>x.ProductId);
        }
    }
}
