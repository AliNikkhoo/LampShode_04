using System.Collections.Generic;

namespace _01_LampShadQuery.Cantracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetProductCategoryQueries();
    }
}
