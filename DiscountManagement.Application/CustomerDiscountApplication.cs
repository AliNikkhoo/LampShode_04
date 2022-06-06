using _0_Framework.Application;
using _0_FrameWork.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscount.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscount;
        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscount)
        {
            _customerDiscount = customerDiscount;
        }
        public OperationResult Define(DefineCustomerDiscount command)
        {
            var opration = new OperationResult();
            if (_customerDiscount.Exists(x => x.ProductId == command.ProductId &&
            x.DiscountRate == command.DiscountRate))
                return opration.Faild(ApplicationMessages.DuplicatedRecord);

            var StartDate = command.StartDate.ToGeorgianDateTime();
            var EndDate = command.EndDate.ToGeorgianDateTime();
            var customerDiscount = new CustomerDiscount(command.ProductId,command.DiscountRate,
                StartDate, EndDate, command.Reason);

            _customerDiscount.Creat(customerDiscount);
            _customerDiscount.SaveChanges();
            return opration.seccedded();
                
        }   

        public OperationResult Edit(EditDefineCustomerDiscount command)
        {
            var opration = new OperationResult();
            var customerdiscount = _customerDiscount.Get(command.Id);
            if (customerdiscount == null)
                return opration.Faild(ApplicationMessages.RecordNontFound);

            if (_customerDiscount.Exists(x => x.ProductId == command.ProductId &&
           x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return opration.Faild(ApplicationMessages.DuplicatedRecord);

            var StartDate = command.StartDate.ToGeorgianDateTime();
            var EndDate = command.EndDate.ToGeorgianDateTime();
            customerdiscount.Edite(command.ProductId, command.DiscountRate,
                StartDate, EndDate, command.Reason);

            
            _customerDiscount.SaveChanges();
            return opration.seccedded();
        }

        public EditDefineCustomerDiscount GetDetails(long id)
        {
            return _customerDiscount.GetDetails(id);
        }

        public List<DefineCustomerDiscountViewModel> Search(DefineCustomerDiscountSearchModel searchModel)
        {
            return _customerDiscount.Search(searchModel);
        }
    }
}
