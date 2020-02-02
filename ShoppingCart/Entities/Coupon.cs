using ShoppingCart.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public abstract class Coupon
    {
        private double _minimumAmount;

        private double _discountAmount;

        public Coupon(string code, double minimumAmount, double discountAmount)
        {
            Code = code;
            _minimumAmount = minimumAmount;
            _discountAmount = discountAmount;
        }

        public readonly string Code;

        public double DiscountAmount
        {
            get
            {
                return _discountAmount;
            }
            set
            {
                _discountAmount = value;
            }
        }

        public double MinimumAmount
        {
            get
            {
                return _minimumAmount;
            }
            set
            {
                _minimumAmount = value;
            }
        }


        /// <summary>
        /// Returns is coupon usable or not
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public bool IsUsable(Cart cart)
        {
            return cart.GetTotalAmountAfterCampaignDiscount() >= _minimumAmount;
        }

        /// <summary>
        /// Returns the amount of total discount
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public abstract double CalculateTotalDiscount(Cart cart);
    }
}
