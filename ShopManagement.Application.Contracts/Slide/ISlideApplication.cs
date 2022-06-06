﻿using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication 
    {
        OperationResult Creat(CreateSlide command);
        OperationResult Edit(EditSlide command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditSlide GetDelails(long id);
        List<SlideViewModel> GetList();
    }
}