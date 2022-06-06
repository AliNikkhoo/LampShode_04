using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            
            builder.ToTable("ProductCategories");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(255);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.keyWords).IsRequired().HasMaxLength(80);
            builder.Property(x => x.MetaDescription).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(255);

            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x=>x.CategoryId);
        }
    }
}
