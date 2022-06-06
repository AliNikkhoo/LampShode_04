using _0_Framework.Application;
using _0_FrameWork.Domain;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlidrAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;
        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
           return _context.Slides.Select(x=> new EditSlide
           {
               Id=x.Id,
               Picture=x.Picture,
               PictureAlte=x.PictureAlte,
               PictureTitel=x.PictureTitel,
               Heading=x.Heading,
               Text=x.Heading,
               Title=x.Title,
               Link = x.Link,
               BtnText=x.BtnText,
           }).FirstOrDefault(x=>x.Id==id); 
        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Picture =x.Picture,
                Heading=x.Heading,
                Title=x.Title,
                IsRemoved =x.IsRemovd,
                CreationDate=x.CreationDate.ToFarsi(),
              
                
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
