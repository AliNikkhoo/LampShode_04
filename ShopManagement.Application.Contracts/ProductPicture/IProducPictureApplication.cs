using _0_FrameWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public interface IProducPictureApplication
    {
        OperationResult Creat(CreatProductPicture command);
        OperationResult Edit(EditeProductPicture command);
        OperationResult Remove(long Id);
        OperationResult Restore(long Id);
        EditeProductPicture GetDetails(long Id);
        List<ProductPictureViewModel> Serach(ProductPictureSearchModel searchModel);
    }
}
