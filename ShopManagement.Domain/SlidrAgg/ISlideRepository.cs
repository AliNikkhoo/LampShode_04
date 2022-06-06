﻿using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SlidrAgg
{
    public interface ISlideRepository :IRepository<long,Slide>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
