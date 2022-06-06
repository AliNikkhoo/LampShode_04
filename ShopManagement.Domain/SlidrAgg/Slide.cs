using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SlidrAgg
{
    public class Slide :EntityBase
    {
      

        public string Picture { get;private set; }
        public string PictureAlte { get; private set; }
        public string PictureTitel { get; private set; }
        public string Text { get; private set; }
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string BtnText { get; private set; }
        public string Link { get; private set; }        
        public bool IsRemovd { get;private set; }

        public Slide(string picture, string pictureAlte, string pictureTitel, 
            string text, string heading, string title,string link, string btnText)
        {
            Picture = picture;
            PictureAlte = pictureAlte;
            PictureTitel = pictureTitel;
            Text = text;
            Heading = heading;
            Title = title;
            Link = link;
            BtnText = btnText;
        }

        public void Edit(string picture, string pictureAlte, string pictureTitel,
           string text, string heading, string titel,string link, string btnText)
        {
            Picture = picture;
            PictureAlte = pictureAlte;
            PictureTitel = pictureTitel;
            Text = text;
            Heading = heading;
            Title = titel;
            Link = link;
            BtnText = btnText;
        }

        public void Removd()
        {
            IsRemovd = true;
        }
        public void Resort()
        {
            IsRemovd = false;
        }
    }
}
