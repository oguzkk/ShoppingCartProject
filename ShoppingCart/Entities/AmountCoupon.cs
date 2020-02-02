using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class AmountCoupon : Coupon
    {
        public AmountCoupon(string code, double minimumAmount, double discountAmount) : base(code, minimumAmount, discountAmount)
        {

        }
        public override double CalculateTotalDiscount(Cart cart)
        {
            return DiscountAmount;
        }
    }
}
