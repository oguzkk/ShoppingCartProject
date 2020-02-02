using ShoppingCart.Helpers;
using ShoppingCart.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class Cart
    {
        private bool _isCouponApplied = false;
        private List<CartItem> _productList;
        private DeliveryCostCalculator _deliveryCostCalculator;
        private double _totalCouponDiscountAmount = 0;
        private double _totalCampaignDiscountAmount = 0;

        public Cart()
        {
            _productList = new List<CartItem>();
            _deliveryCostCalculator = new DeliveryCostCalculator(Constants.CostPerDelivery, Constants.CostPerProduct);
        }

        /// <summary>
        /// Product List added to cart
        /// </summary>
        public List<CartItem> ProductList
        {
            get
            {
                return _productList;
            }
            set
            {
                _productList = value;
            }
        }


        public bool IsCouponApplied
        {
            get
            {
                return _isCouponApplied;
            }
            set
            {
                _isCouponApplied = value;
            }
        }

        public double TotalCouponDiscountAmount
        {
            get
            {
                return _totalCouponDiscountAmount;
            }
            set
            {
                _totalCouponDiscountAmount = value;
            }
        }

        public double TotalCampaignDiscountAmount
        {
            get
            {
                return _totalCampaignDiscountAmount;
            }
            set
            {
                _totalCampaignDiscountAmount = value;
            }
        }
        /// <summary>
        /// Adds Item to cart
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddItem(Product product, int quantity)
        {
            CartItem existingCartItem = _productList.FirstOrDefault(entity => entity.Product.Id == product.Id);
            // if cartItem exists add quantity. Else add new cartItem
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }
            else
            {
                CartItem cartItem = new CartItem(product, quantity);
                _productList.Add(cartItem);
            }
        }

        /// <summary>
        /// Returns true if coupon usable
        /// </summary>
        /// <param name="coupon"></param>
        /// <returns></returns>
        public bool ApplyCoupon(Coupon coupon)
        {
            bool isCouponUsable = coupon.IsUsable(this);

            if (_isCouponApplied)
            {
                return false;
            }

            if (isCouponUsable)
            {
                _totalCouponDiscountAmount = coupon.CalculateTotalDiscount(this);
                _isCouponApplied = true;
            }

            return isCouponUsable;
        }

        public double GetTotalAmountAfterDiscounts()
        {
            return Math.Round(GetTotalAmount() - _totalCampaignDiscountAmount - _totalCouponDiscountAmount, 2);
        }

        public double GetTotalAmountAfterCampaignDiscount()
        {
            return GetTotalAmount() - _totalCampaignDiscountAmount;
        }

        public double GetCouponDiscount()
        {
            return Math.Round(_totalCouponDiscountAmount, 2);
        }

        public double GetCampaignDiscount()
        {
            return Math.Round(_totalCampaignDiscountAmount, 2);
        }

        public double GetDeliveryCost()
        {
            return _deliveryCostCalculator.CalculateFor(this);
        }

        public CartPrintResult Print()
        {
            CartPrintResult cartPrintResult = new CartPrintResult(this);
            return cartPrintResult;
        }

        public double GetTotalAmount()
        {
            return Math.Round(_productList.Sum(product => product.Product.Price * product.Quantity), 2);
        }

        public void ApplyDiscounts()
        {
            _totalCampaignDiscountAmount = 0;
            CampaignTransaction.GetCampaigns().ForEach(campaign =>
            {
                if (campaign.IsUsable(this))
                {
                    _totalCampaignDiscountAmount += campaign.CalculateTotalDiscount(this);
                }
            });
        }
    }
}
