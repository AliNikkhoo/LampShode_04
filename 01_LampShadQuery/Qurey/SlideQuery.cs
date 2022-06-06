using _01_LampShadQuery.Cantracts.Slide;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadQuery.Qurey
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;
        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext; 
        }
        public List<SlideQueryModel> GetSlides()
        {
            return _shopContext.Slides
                .Where(x=>x.IsRemovd ==false)
                .Select(x => new SlideQueryModel
                {
                    Picture =x.Picture,
                    PictureAlte = x.PictureAlte,
                    PictureTitel =x.PictureAlte,
                    Heading =x.Heading,
                    Link=x.Link,
                    Text =x.Text,
                    BtnText =x.BtnText,
                    Title =x.Title,
                })
                .ToList();
        }
    }
}
