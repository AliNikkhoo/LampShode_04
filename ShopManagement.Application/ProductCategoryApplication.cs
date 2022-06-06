using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoeyApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Creat(CreatProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Faild(ApplicationMessages.DuplicatedRecord);

            var productcategory = new ProductCategory(command.Name, command.Description, command.Picture == null ? "" : command.Picture,
                command.PictureAlt, command.PictureTitle, command.Slug, command.keyWords == null ? "" : command.keyWords, command.MetaDescription);
            _productCategoryRepository.Creat(productcategory);
            _productCategoryRepository.SaveChanges();
            return operation.seccedded();

        }

        public OperationResult Edit(EditProductCategoey command)
        {
            var operation = new OperationResult();
            var productcategory = _productCategoryRepository.Get(command.Id);
            if (productcategory == null)
                return operation.Faild(ApplicationMessages.RecordNontFound);
            if (_productCategoryRepository.Exists(x => x.Name != command.Name && x.Id != x.Id))
                return operation.Faild(ApplicationMessages.DuplicatedRecord);

            productcategory.Edit(command.Name, command.Picture, command.PictureAlt, command.PictureTitle, command.keyWords,
                command.MetaDescription, command.Slug, command.Description);
            _productCategoryRepository.SaveChanges();
            return operation.seccedded();


        }

        public EditProductCategoey GetDetails(long Id)
        {
            return _productCategoryRepository.GetDetails(Id);
        }

        public List<ProducCategoryViewModel> GetProducCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }

        public List<ProducCategoryViewModel> Search(ProductCategoryShearchModel shearchModel)
        {
            return _productCategoryRepository.seachModel(shearchModel);
        }
    }
}
