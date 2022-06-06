using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadQuery.Cantracts.Slide
{
    public interface ISlideQuery
    {
        List<SlideQueryModel> GetSlides();
    }
}
