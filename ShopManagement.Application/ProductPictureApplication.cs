using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProducPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;    
        }
        public OperationResult Creat(CreatProductPicture command)
        {
            var operationresult = new OperationResult();
         if(_productPictureRepository.Exists(x=>x.ProductId==command.ProductId && 
         x.Picture==command.Picture))

                return operationresult.Faild(ApplicationMessages.DuplicatedRecord);

            var productpicture = new ProductPicture(command.ProductId, command.Picture, 
                command.PictureAlt, command.PictureTitle);

            _productPictureRepository.Creat(productpicture);
            _productPictureRepository.SaveChanges();
            return operationresult.seccedded();
        }

        public OperationResult Edit(EditeProductPicture command)
        {
            var operationresult = new OperationResult();
            var productpicture = _productPictureRepository.Get(command.Id);
            if (productpicture == null)
                return operationresult.Faild(ApplicationMessages.RecordNontFound);

            if (_productPictureRepository.Exists(x => x.Id != command.Id &&
             x.ProductId == command.ProductId && x.Picture == command.Picture))

                return operationresult.Faild(ApplicationMessages.DuplicatedRecord);
            productpicture.Edit(command.ProductId, command.Picture,
                command.PictureAlt, command.PictureTitle);
            
            _productPictureRepository.SaveChanges();
            return operationresult.seccedded();


        }

        public EditeProductPicture GetDetails(long Id)
        {
            return _productPictureRepository.GetDetails(Id);
        }

        public OperationResult Remove(long Id)
        {
            var operationresult = new OperationResult();
            var productpicture = _productPictureRepository.Get(Id);
            if (productpicture == null)
                return operationresult.Faild(ApplicationMessages.RecordNontFound);


            productpicture.IsRemoved();

            _productPictureRepository.SaveChanges();
            return operationresult.seccedded();
        }

        public OperationResult Restore(long Id)
        {
            var operationresult = new OperationResult();
            var productpicture = _productPictureRepository.Get(Id);
            if (productpicture == null)
                return operationresult.Faild(ApplicationMessages.RecordNontFound);


            productpicture.Restore();

            _productPictureRepository.SaveChanges();
            return operationresult.seccedded();
        }

        public List<ProductPictureViewModel> Serach(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Serach(searchModel);
        }
    }
}
