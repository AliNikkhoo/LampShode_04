using _0_FrameWork.Domain;
using DiscountManagement.Application.Contract.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscount.Agg
{
    public interface ICustomerDiscountRepository :IRepository<long,CustomerDiscount>
    {
        EditDefineCustomerDiscount GetDetails(long id);
        List<DefineCustomerDiscountViewModel> Search(DefineCustomerDiscountSearchModel searchModel);

    }
}
