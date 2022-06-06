using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoeyApplication
    {
        OperationResult Creat(CreatProductCategory command);
        OperationResult Edit(EditProductCategoey command);
        EditProductCategoey GetDetails(long Id);
        List<ProducCategoryViewModel> GetProducCategories();

        List<ProducCategoryViewModel> Search(ProductCategoryShearchModel shearchModel);

    }
}
