using _0_Framework.Application;
using _0_FrameWork.Domain;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscount.Agg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DisCountManamgement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long,CustomerDiscount>,ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopcontext;
        public CustomerDiscountRepository(DiscountContext context, ShopContext shopcontext) :base(context)
        {
            _context = context;
            _shopcontext = shopcontext;
        }

        public EditDefineCustomerDiscount GetDetails(long id)
        {


            return _context.customerDiscounts.Select(x => new EditDefineCustomerDiscount
            {
                Id=x.Id,
                DiscountRate=x.DiscountRate,
                EndDate=x.EndDate.ToFarsi(),
                StartDate=x.StartDate.ToFarsi(),
                ProductId=x.ProductId,
                Reason=x.Reason


            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<DefineCustomerDiscountViewModel> Search(DefineCustomerDiscountSearchModel searchModel)
        {
            var product = _shopcontext.Products.Select(x => new { x.Id, x.Name }).ToList();

            var query = _context.customerDiscounts.Select(x => new DefineCustomerDiscountViewModel
            {
                Id =x.Id,
                DiscountRate = x.DiscountRate,
                EndDate = x.EndDate.ToFarsi(),
                EndDateGr = x.EndDate,
                StartDate = x.StartDate.ToFarsi(),
                StartDateGr = x.StartDate,
                ProductId = x.ProductId,
                Reason = x.Reason,
                CreationDate = x.CreationDate.ToFarsi()
            }) ;

            if (searchModel.Productid > 0)
                query = query.Where(x => x.ProductId == searchModel.Productid);

            if (!string.IsNullOrEmpty(searchModel.StartDate))
            {
                var startDate = DateTime.Now;
                query = query.Where(x=>x.StartDateGr > searchModel.StartDate.ToGeorgianDateTime());
            }


            if (!string.IsNullOrEmpty(searchModel.EndDate))
            {
                var endDate = DateTime.Now;
                query = query.Where(x => x.EndDateGr < searchModel.EndDate.ToGeorgianDateTime());
            }

            var discounts = query.OrderByDescending(x =>x.Id).ToList();
            discounts.ForEach(discounts =>
            discounts.Product = product.FirstOrDefault(x => x.Id == discounts.ProductId)?.Name);

            return discounts;
        }
    }
    
}
