using CentuDY_Project.Model;
using CentuDY_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Handler
{
    public class CartHandler
    {
        public static int createCart(int userId, int medicineId, int quantity)
        {
            if (CartRepository.getTotalExistingQuantity(medicineId).ToString() != null)
            {
                if ((CartRepository.getTotalExistingQuantity(medicineId) + quantity) > MedicineRepository.getStock(medicineId))
                {
                    return 0;
                }
            }
           
            if (CartRepository.getExistingQuantity(userId, medicineId) ==  0)
            {
                if (quantity > MedicineRepository.getStock(medicineId))
                {
                    return 0;
                }
                return CartRepository.createCart(userId, medicineId, quantity);
            }
            else
            {
                if ((CartRepository.getExistingQuantity(userId, medicineId) + quantity) > MedicineRepository.getStock(medicineId))
                {
                    return 0;
                }
                return CartRepository.addQuantity(userId, medicineId, quantity);
            }
            
           
        }

        public static List<Cart> getCartList(int id)
        {
            return CartRepository.getCartList(id);
        }

        public static int removeCartItem(int userId, int medicineId)
        {
            return CartRepository.removeCartItem(userId, medicineId);
        }

        public static int clearCart(int userId, int medicineId)
        {
            return CartRepository.clearCart(userId, medicineId);
        }
    }
}