using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int userId, int medicineId, int quantity)
        {
            Cart c = new Cart();
            c.UserId = userId;
            c.MedicineId = medicineId;
            c.Quantity = quantity;

            return c;
        }
    }
}