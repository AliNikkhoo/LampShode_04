using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
   public interface IProductCategoryRepository :IRepository<long,ProductCategory>
    {

        List<ProducCategoryViewModel> GetProductCategories();
          EditProductCategoey GetDetails(long Id);
        List<ProducCategoryViewModel> seachModel(ProductCategoryShearchModel searchModel);
    }
}
