using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long, Product> 
    {
        EditProudct GetDitails(long Id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel seachmodel);
    }
}
