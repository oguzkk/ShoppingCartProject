using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class CartPrintItem
    {
        public Category Category
        {
            get; set;
        }
        public List<CartItem> CartItems
        {
            get; set;
        }
    }
}
