using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlidrAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepositry;
        public SlideApplication(ISlideRepository slideRepositry)
        {
            _slideRepositry = slideRepositry;
        }
        public OperationResult Creat(CreateSlide command)
        {
            var operation = new OperationResult();
            var slide = new Slide(command.Picture,command.PictureAlte,command.PictureTitel,
                command.Text,command.Heading,command.Title,command.Link,command.BtnText);

            _slideRepositry.Creat(slide);
            _slideRepositry.SaveChanges();
            return operation.seccedded();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var slide = _slideRepositry.Get(command.Id);
            if (_slideRepositry == null)
                return operation.Faild(ApplicationMessages.DuplicatedRecord);

            slide.Edit(command.Picture, command.PictureAlte, command.PictureTitel,
                command.Text, command.Heading, command.Title,command.Link ,command.BtnText);

            _slideRepositry.SaveChanges();
            return operation.seccedded();
        }

        public EditSlide GetDelails(long id)
        {
            return _slideRepositry.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepositry.GetList();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepositry.Get(id);
            if (_slideRepositry == null)
                return operation.Faild(ApplicationMessages.DuplicatedRecord);

            slide.Removd();
            _slideRepositry.SaveChanges();
            return operation.seccedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepositry.Get(id);
            if (_slideRepositry == null)
                return operation.Faild(ApplicationMessages.DuplicatedRecord);

            slide.Resort();
            _slideRepositry.SaveChanges();
            return operation.seccedded();
        }
    }
}
