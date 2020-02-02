using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class RateCoupon : Coupon
    {
        public RateCoupon(string code, double minimumAmount, double discountAmount) : base(code, minimumAmount, discountAmount)
        {

        }
        public override double CalculateTotalDiscount(Cart cart)
        {
            return Math.Round(cart.GetTotalAmountAfterCampaignDiscount() * DiscountAmount / 100, 2);
        }
    }
}
