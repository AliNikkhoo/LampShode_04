using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public OperationResult Creat(CreatProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Faild(ApplicationMessages.DuplicatedRecord);
            var product = new Product(command.Name,command.Code,command.picture==null ?"":command.picture,command.PictureAlt==null?"":command.PictureAlt
                ,command.pictureTitle,command.ShortDesCription,command.DesCription,command.CategoryId,command.Slug,
                command.KeyWords,command.MetaDesCription);

            _productRepository.Creat(product) ;
            _productRepository.SaveChanges();
            return operation.seccedded();
         
        }

        public OperationResult Edit(EditProudct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.Id);
            if (product == null)
                return operation.Faild(ApplicationMessages.RecordNontFound);

            if (_productRepository.Exists(x => x.Name == command.Name && x.Id ==command.Id))
                return operation.Faild(ApplicationMessages.DuplicatedRecord);

            product.Edit(command.Name, command.Code, command.picture, command.PictureAlt,
                command.pictureTitle, command.ShortDesCription, command.DesCription, command.CategoryId, command.Slug,
                command.KeyWords, command.MetaDesCription);
            _productRepository.SaveChanges();
            return operation.seccedded();
        }

        public EditProudct GetDetails(long id)
        {
            return _productRepository.GetDitails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }


        public List<ProductViewModel> Search(ProductSearchModel seachmodel)
        {
            return _productRepository.Search(seachmodel);
        }
    }
}
