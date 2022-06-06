using _0_Framework.Application;
using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context):base (context)
        {
            _context = context;
        }
        public EditProudct GetDitails(long Id)
        {

            return _context.Products.Select(x => new EditProudct 
            {
            Id=x.Id,
            CategoryId=x.CategoryId,
            Code=x.Code,
            DesCription=x.DesCription,
            KeyWords=x.KeyWords,
            Name=x.Name,
            MetaDesCription=x.MetaDesCription,
            picture=x.picture,
            PictureAlt=x.PictureAlt,
            pictureTitle=x.pictureTitle,
            ShortDesCription=x.ShortDesCription,
            Slug=x.Slug,

            }).FirstOrDefault(x=>x.Id==Id);
        }
        
        public List<ProductViewModel> GetProducts()
        {
            return _context.Products.Select(x => new ProductViewModel 
            { 
            Id=x.Id,
            Name=x.Name,
            }).ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel seachmodel)
        {
            var query = _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                picture = x.picture,
                Category = x.Category.Name,
                Code = x.Code,
                CategoryId = x.CategoryId,
                CreationDate = x.CreationDate.ToFarsi(),
                

            }) ;
            if (!string.IsNullOrEmpty(seachmodel.Name))
                query = query.Where(x => x.Name.Contains(seachmodel.Name));

            if (!string.IsNullOrEmpty(seachmodel.Code))
                if (!string.IsNullOrEmpty(seachmodel.Code))
                    query = query.Where(x => x.Code.Contains(seachmodel.Code));

            if (seachmodel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == seachmodel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
