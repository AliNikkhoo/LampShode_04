using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreatProduct
   {
        public string Name { get;  set; }
        public string Code { get;  set; }
        public double UnitPrice { get;  set; }
        public string picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string pictureTitle { get;  set; }
        public string ShortDesCription { get;  set; }
        public string DesCription { get;  set; }
        public long CategoryId { get;  set; }
        public string Slug { get;  set; }
        public string KeyWords { get;  set; }
        public string MetaDesCription { get;  set; }
        public List<ProducCategoryViewModel> Categories { get; set; }
   }

  
}
