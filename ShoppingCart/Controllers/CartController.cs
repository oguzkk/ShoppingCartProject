using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Entities;
using ShoppingCart.Integration;
using ShoppingCart.Helpers;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        [HttpGet("[action]")]
        public CartPrintResult Print()
        {
            Cart cart = GetCartFromSession();
            return cart.Print();
        }

        [HttpPost("[action]")]
        public void ApplyDiscounts()
        {
            Cart cart = GetCartFromSession();
            cart.ApplyDiscounts();
            HttpContext.Session.SetObjectAsJson("ShoppingCart", cart);
        }

        [HttpPost("[action]")]
        public void AddItem([FromBody]CartItem cartItem)
        {
            Cart cart = GetCartFromSession();
            cart.AddItem(cartItem.Product, cartItem.Quantity);
            HttpContext.Session.SetObjectAsJson("ShoppingCart", cart);
        }

        [HttpPost("[action]")]
        public bool ApplyCoupon([FromBody]dynamic request)
        {
            bool isCouponApplied = false;
            string couponCode = request.couponCode;
            Cart cart = GetCartFromSession();
            List<Coupon> coupons = CouponTransaction.GetCoupons();
            Coupon coupon = coupons.FirstOrDefault(entity => entity.Code == couponCode);
            if (coupon != null && cart.ApplyCoupon(coupon))
            {
                isCouponApplied = true;
                HttpContext.Session.SetObjectAsJson("ShoppingCart", cart);
            }
            return isCouponApplied;
        }

        private Cart GetCartFromSession()
        {
            Cart cart = HttpContext.Session.GetObjectFromJson<Cart>("ShoppingCart");
            if (cart == null)
            {
                cart = new Cart();
            }
            return cart;
        }
    }
}