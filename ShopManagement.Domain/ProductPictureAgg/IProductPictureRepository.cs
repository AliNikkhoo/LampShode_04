using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long,ProductPicture>
    {
        EditeProductPicture GetDetails(long Id);
        List<ProductPictureViewModel> Serach(ProductPictureSearchModel searchModel);
    }
}
