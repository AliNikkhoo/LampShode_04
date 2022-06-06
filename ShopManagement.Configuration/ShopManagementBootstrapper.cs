using _01_LampShadQuery.Cantracts.ProductCategory;
using _01_LampShadQuery.Cantracts.Slide;
using _01_LampShadQuery.Qurey;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlidrAgg;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Configuration
{
   public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection service,string ConnectionString)
        {
            service.AddTransient<IProductCategoeyApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            service.AddTransient<IProductApplication, ProductApplication>();
            service.AddTransient<IProductRepository, ProductRepository>();

            service.AddTransient<IProducPictureApplication, ProductPictureApplication>();
            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            service.AddTransient<ISlideApplication, SlideApplication>();
            service.AddTransient<ISlideRepository, SlideRepository>();



            service.AddTransient<ISlideQuery, SlideQuery>();
            service.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();


            service.AddDbContext<ShopContext>(x => x.UseSqlServer(ConnectionString));

            
        }
    }
}
