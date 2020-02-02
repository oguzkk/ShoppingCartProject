using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class AmountCampaign : Campaign
    {
        public AmountCampaign(int id, int categpryId, double discountAmount, int minimumItemCount) : base(id, categpryId, discountAmount, minimumItemCount)
        {

        }
        public override double CalculateTotalDiscount(Cart cart)
        {
            return DiscountAmount;
        }
    }
}
