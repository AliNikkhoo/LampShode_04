using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Define(DefineCustomerDiscount command);
        OperationResult Edit(EditDefineCustomerDiscount command);
        EditDefineCustomerDiscount GetDetails(long id);
        List<DefineCustomerDiscountViewModel> Search(DefineCustomerDiscountSearchModel searchModel);
    }
}
