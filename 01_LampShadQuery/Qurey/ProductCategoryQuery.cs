using _01_LampShadQuery.Cantracts.ProductCategory;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadQuery.Qurey
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;
        public ProductCategoryQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public List<ProductCategoryQueryModel> GetProductCategoryQueries()
        {
            return _shopContext.productCategories.Select(x => new ProductCategoryQueryModel
            {
               Id=x.Id, 
            Name =x.Name,
            Picture =x.Picture,
            PictureAlt =x.PictureAlt,
            PictureTitle =x.PictureTitle,
            Slug =x.Slug,   
            }).ToList();
        }
    }
}
