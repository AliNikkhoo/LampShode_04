using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
   public interface IProductApplication
    {
        OperationResult Creat(CreatProduct command);
        OperationResult Edit(EditProudct command);
        EditProudct GetDetails(long id);
        List<ProductViewModel> GetProducts();
      List<ProductViewModel> Search(ProductSearchModel seachmodel);
    }
}
