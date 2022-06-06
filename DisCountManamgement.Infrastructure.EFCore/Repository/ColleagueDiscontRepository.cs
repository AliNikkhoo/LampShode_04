using _0_Framework.Application;
using _0_FrameWork.Domain;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscount.Agg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisCountManamgement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscontRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _Context;
        private readonly ShopContext _shopContext;
        public ColleagueDiscontRepository(DiscountContext Context, ShopContext shopContext) : base(Context)
        {
            _Context = Context;
            _shopContext = shopContext;
        }
        public EditColleagueDiscount GetDetails(long id)
        {
            return _Context.colleagueDiscounts.Select(x=>new EditColleagueDiscount 
            { 
            Id=x.Id,
            ProductId=x.ProductId,
            DiscountRate=x.DiscountRate,
            
            }).FirstOrDefault(X=>X.Id==id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var Products = _shopContext.Products.Select(x =>new {x.Id,x.Name}).ToList();

            var query = _Context.colleagueDiscounts.Select(x => new ColleagueDiscountViewModel 
            {
            Id=x.Id,
            DiscountReat=x.DiscountRate,
            CreationDate=x.CreationDate.ToFarsi(),
            ProductId=x.ProductId,
            IsRemoved=x.IsRemoved,
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x=>x.ProductId == searchModel.ProductId);

            var discount = query.OrderByDescending(x => x.Id).ToList();

            discount.ForEach(discount => discount.Product = Products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);

            return discount;
        }
    }
}
