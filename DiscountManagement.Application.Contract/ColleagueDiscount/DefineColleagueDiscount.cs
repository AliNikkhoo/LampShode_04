using ShopManagement.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public class DefineColleagueDiscount
    {
        public long ProductId { get; set; }
        public string DiscountRate { get; set; }
        public List<ProductViewModel> Products{get;set;}
    }
}
