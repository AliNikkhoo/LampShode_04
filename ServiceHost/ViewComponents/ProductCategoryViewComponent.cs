using _01_LampShadQuery.Cantracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryViewComponent :ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;
        public ProductCategoryViewComponent(IProductCategoryQuery productCategoryquery)
        {
            _productCategoryQuery = productCategoryquery;
        }
        public IViewComponentResult Invoke()
        {
           var productCategories= _productCategoryQuery.GetProductCategoryQueries();
            return View(productCategories);
        }
    }
}
