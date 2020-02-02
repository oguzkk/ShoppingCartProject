using ShoppingCart.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class RateCampaign : Campaign
    {
        public RateCampaign(int id, int categpryId, double discountAmount, int minimumItemCount) : base(id, categpryId, discountAmount, minimumItemCount)
        {

        }
        public override double CalculateTotalDiscount(Cart cart)
        {
            return Math.Round(cart.ProductList.Where((cartItem) => cartItem.Product.CategoryId == CategoryId || CategoryTransaction.GetParentCategoryId(cartItem.Product.CategoryId) == CategoryId)
                       .Sum(cartItem => cartItem.Product.Price * cartItem.Quantity) * DiscountAmount / 100, 2);
        }
    }
}
