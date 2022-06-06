using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscount.Agg
{
    public class CustomerDiscount : EntityBase
    {
        

        public long ProductId { get;private set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Reason { get; private set; }


        public CustomerDiscount(long productId, int discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }

        public void Edite(long productId, int discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }
    }
}
