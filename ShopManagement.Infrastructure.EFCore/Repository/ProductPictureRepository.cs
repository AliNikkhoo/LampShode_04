using _0_FrameWork.Domain;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _shopContext;
        public ProductPictureRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditeProductPicture GetDetails(long Id)
        {
            return _shopContext.productPictures.Select(x => new EditeProductPicture
            {
            Id=x.Id,
            Picture= x.Picture,
            PictureAlt=x.PictureAlt,
            PictureTitle=x.PictureTitle,
            ProductId =x.ProductId
            }).FirstOrDefault(x=>x.Id ==Id);
        }

        public List<ProductPictureViewModel> Serach(ProductPictureSearchModel searchModel)
        {
            var query = _shopContext.productPictures.Include(x=>x.product).Select(x=>new ProductPictureViewModel 
            {
            Id=x.Id,
            CreationDate=x.CreationDate.ToString(),
            Picture=x.Picture,
            Product=x.product.Name,
            ProductId =x.ProductId ,
            IsRemoved =x.IsRemoves
            });

            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
