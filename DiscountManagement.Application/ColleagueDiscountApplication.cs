using _0_FrameWork.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscount.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;
        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }
        public OperationResult Define(DefineColleagueDiscount command)
        {
            var opration = new OperationResult();
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return opration.Faild(ApplicationMessages.DuplicatedRecord);
                   var colleaguediscount = new ColleagueDiscount(command.ProductId , command.DiscountRate);
            _colleagueDiscountRepository.Creat(colleaguediscount);
            _colleagueDiscountRepository.SaveChanges();
            return opration.seccedded();

        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var opration = new OperationResult();
            var colleaguediscount = _colleagueDiscountRepository.Get(command.Id);
            if (colleaguediscount == null)
                return opration.Faild(ApplicationMessages.RecordNontFound); 

            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId &&
            x.DiscountRate == command.DiscountRate && x.Id==command.Id))
                return opration.Faild(ApplicationMessages.DuplicatedRecord);
          colleaguediscount.Edit(command.ProductId, command.DiscountRate);
            
            _colleagueDiscountRepository.SaveChanges();
            return opration.seccedded();

        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);

        }

        public OperationResult Removed(long id)
        {
            var opration = new OperationResult();
            var colleaguediscount = _colleagueDiscountRepository.Get(id);
            if (colleaguediscount == null)
                return opration.Faild(ApplicationMessages.RecordNontFound);


            colleaguediscount.Remove();

            _colleagueDiscountRepository.SaveChanges();
            return opration.seccedded();
        }

        public OperationResult Restore(long id)
        {
            var opration = new OperationResult();
            var colleaguediscount = _colleagueDiscountRepository.Get(id);
            if (colleaguediscount == null)
                return opration.Faild(ApplicationMessages.RecordNontFound);


            colleaguediscount.Restore();

            _colleagueDiscountRepository.SaveChanges();
            return opration.seccedded();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _colleagueDiscountRepository.Search(searchModel);
        }
    }
}
