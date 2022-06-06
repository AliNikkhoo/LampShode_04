using _0_Framework.Application;
using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory> ,IProductCategoryRepository
    {
        private readonly ShopContext _context;
        public ProductCategoryRepository(ShopContext context) :base(context)
        {
            _context = context;
        }
   

     

        public EditProductCategoey GetDetails(long Id)
        {
            return _context.productCategories.Select(x => new EditProductCategoey
            {
              Id=x.Id,
              Name =x.Name,
              Description =x.Description,
              Picture=x.Picture,
              PictureAlt=x.PictureAlt,
              PictureTitle=x.PictureTitle,
              keyWords =x.keyWords,
              MetaDescription=x.MetaDescription,
              Slug=x.Slug,


            }).FirstOrDefault(x=>x.Id ==Id);

        }

        public List<ProducCategoryViewModel> GetProductCategories()
        {
            return _context.productCategories.Select(x => new ProducCategoryViewModel
            {
                Name=x.Name,
                Id=x.Id
            }).ToList();
        }

        public List<ProducCategoryViewModel> seachModel(ProductCategoryShearchModel searchModel)
        {
            var query = _context.productCategories.Select(x => new ProducCategoryViewModel 
            {
            Name=x.Name,
            CreationDate=x.CreationDate.ToFarsi(),
            Id=x.Id,
            Picture=x.Picture,
            });

             if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
