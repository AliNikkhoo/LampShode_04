﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slide
{
    public class CreateSlide
    {
        public string Picture { get;  set; }
        public string PictureAlte { get;  set; }
        public string PictureTitel { get;  set; }
        public string Text { get;  set; }
        public string Heading { get;  set; }
        public string Title { get;  set; }
        public string Link { get; set;  }
        public string BtnText { get;  set; }
    }
}
