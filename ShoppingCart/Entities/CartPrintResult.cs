using ShoppingCart.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class CartPrintResult
    {
        public CartPrintResult(Cart cart)
        {
            List<Category> categories = CategoryTransaction.GetCategories();
            List<IGrouping<Category, CartItem>> productListGroupping = cart.ProductList.GroupBy(item =>
                categories.Where(category => category.Id == item.Product.CategoryId).FirstOrDefault()).ToList();
            List<CartPrintItem> cartPrintItems = new List<CartPrintItem>();
            productListGroupping.ForEach(productList =>
            {
                CartPrintItem cartPrintItem = new CartPrintItem();
                cartPrintItem.Category = productList.Key;
                cartPrintItem.CartItems = productList.ToList();
                cartPrintItems.Add(cartPrintItem);
            });
            CartPrintItems = cartPrintItems;
            TotalAmount = cart.GetTotalAmount();
            CampaignDiscountAmount = cart.GetCampaignDiscount();
            CouponDiscountAmount = cart.GetCouponDiscount();
            TotalAmountAfterDiscounts = cart.GetTotalAmountAfterDiscounts();
            DeliveryCost = cart.GetDeliveryCost();
        }

        public List<CartPrintItem> CartPrintItems
        {
            get;
            set;
        }
        public double TotalAmount
        {
            get;
            set;
        }
        public double CampaignDiscountAmount
        {
            get;
            set;
        }
        public double CouponDiscountAmount
        {
            get;
            set;
        }
        public double TotalAmountAfterDiscounts
        {
            get;
            set;
        }
        public double DeliveryCost
        {
            get;
            set;
        }
    }
}
