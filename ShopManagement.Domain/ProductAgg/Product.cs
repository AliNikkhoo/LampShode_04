using _0_FrameWork.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
   public class Product : EntityBase
    {
     

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string picture  { get; private set; }
        public string PictureAlt { get; private set; }
        public string pictureTitle { get; private set; }
        public string ShortDesCription { get; private set; }
        public string DesCription { get; private set; }
        public long CategoryId { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDesCription { get; private set; }
        public ProductCategory Category { get; private set; }
        public List<ProductPicture> productPictures { get; private set; }

        public Product(string name, string code, string picture, string pictureAlt,
          string pictureTitle, string shortDesCription, string desCription, long categoryId, string slug,
           string keyWords, string metaDesCription)
        {
            Name = name;
            Code = code;
        
            this.picture = picture;
            PictureAlt = pictureAlt;
            this.pictureTitle = pictureTitle;
            ShortDesCription = shortDesCription;
            DesCription = desCription;
            CategoryId = categoryId;
            Slug = slug;
            KeyWords = keyWords;
            MetaDesCription = metaDesCription;
            
        }


        public void Edit(string name, string code, string picture, string pictureAlt,
          string pictureTitle, string shortDesCription, string desCription, long categoryId, string slug,
           string keyWords, string metaDesCription)
        {
            Name = name;
            Code = code;
          
            this.picture = picture;
            PictureAlt = pictureAlt;
            this.pictureTitle = pictureTitle;
            ShortDesCription = shortDesCription;
            DesCription = desCription;
            CategoryId = categoryId;
            Slug = slug;
            KeyWords = keyWords;
            MetaDesCription = metaDesCription;
        }

    
    }
}
