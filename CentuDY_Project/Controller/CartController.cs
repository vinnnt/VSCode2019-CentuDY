using CentuDY_Project.Handler;
using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CentuDY_Project.Controller
{
    public class CartController
    {
        public static dynamic createCart(int userId, int medicineId, int quantity)
        {
            if(quantity.ToString() == null)
            {
                return "Quantity can't be empty";
            }
            if(!Regex.IsMatch(quantity.ToString(), @"^\d+$"))
            {
                return "Quantity must be numeric";
            }
            if(quantity <= 0)
            {
                return "Quantity must be more than 0";
            }

            int status = CartHandler.createCart(userId, medicineId, quantity);
            if(status == 1)
            {
                return 1;
            }
            return "Quantity exceeds current medicine stock";
        }

        public static List<Cart> getCartList(int id)
        {
            return CartHandler.getCartList(id);
        }

        public static dynamic removeCartItem(int userId, int medicineId)
        {
            int status = CartHandler.removeCartItem(userId, medicineId);
            if(status == 1)
            {
                return 1;
            }
            return "Failed to remove item from the cart";
        }

        public static dynamic clearCart(List<Cart> cart)
        {
            for(int i=0; i<cart.Count; i++)
            {
                CartHandler.clearCart(cart.ElementAt(i).UserId, cart.ElementAt(i).MedicineId);
            }
            
            return 1;

        }
    }
}