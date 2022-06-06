using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.ColleagueDiscount.Agg
{
    public class ColleagueDiscount:EntityBase
    {
        

        public long ProductId { get; private set; }
        public string DiscountRate { get; private set; }
        public bool IsRemoved { get; private set; }

        public ColleagueDiscount(long productId, string discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
        }

        public void Edit(long productId, string discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }

    }
}
