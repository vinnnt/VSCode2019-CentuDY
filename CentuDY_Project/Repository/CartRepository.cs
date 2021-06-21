using CentuDY_Project.Factory;
using CentuDY_Project.Model;
using CentuDY_Project.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Repository
{
    public class CartRepository
    {
        private static CentuDYDBEntities db = DatabaseSingleton.getInstance();
        public static int createCart(int userId, int medicineId, int quantity)
        {
            Cart cart = CartFactory.createCart(userId, medicineId, quantity);
            db.Carts.Add(cart);

            return db.SaveChanges();
        }

        public static int getExistingQuantity(int userId, int medicineId)
        {
            return (
                from
                    x
                in
                    db.Carts
                where
                    x.UserId == userId && x.MedicineId == medicineId
                select
                    x.Quantity
                ).FirstOrDefault();
        }

        public static int getTotalExistingQuantity(int medicineId)
        {
            var sum = (
                from
                    x
                in
                    db.Carts
                where
                    x.MedicineId == medicineId
                select (int?)x.Quantity
                ).Sum() ?? 0;

            return sum;
        }

        public static int addQuantity(int userId, int medicineId, int quantity)
        {
            Cart c = (
                from
                    x
                in
                    db.Carts
                where
                    x.UserId == userId && x.MedicineId == medicineId
                select
                    x
                ).FirstOrDefault();

            c.Quantity = c.Quantity + quantity;

            return db.SaveChanges();
        }

        public static List<Cart> getCartList(int userId)
        {
            return (
                from
                     x
                in
                    db.Carts
                where
                    x.UserId == userId
                select
                    x
                ).ToList();

        }

        public static int clearCart(int userId, int medicineId)
        {
            Cart c = (
                 from
                     x
                 in
                     db.Carts
                 where
                     x.UserId == userId && x.MedicineId == medicineId
                 select
                     x
                 ).FirstOrDefault();

            db.Carts.Remove(c);

            return db.SaveChanges();
        }

        public static bool cartExistByUserId(int userId)
        {
            Cart c = (
                from
                    x
                in
                    db.Carts
                where
                    x.UserId == userId
                select
                    x
                ).FirstOrDefault();

            if(c == null)
            {
                return false;
            }
            return true;
        }


        public static int removeCartItem(int userId, int medicineId)
        {
            Cart c = (
                from
                    x
                in
                    db.Carts
                where
                    x.UserId == userId && x.MedicineId == medicineId
                select
                    x
                ).FirstOrDefault();

            db.Carts.Remove(c);

            return db.SaveChanges();
        }

        public static bool cartExist(int medicineId)
        {
            Cart c = (
                from
                    x
                in
                    db.Carts
                where
                    x.MedicineId == medicineId
                select
                    x
                ).FirstOrDefault();

            if(c == null)
            {
                return false;
            }
            return true;
        }

        public static void clearCartByMedicineId(int medicineId)
        {
            Cart c = (
                from
                    x
                in
                    db.Carts
                where
                    x.MedicineId == medicineId
                select
                    x
                ).FirstOrDefault();

            db.Carts.Remove(c);

            db.SaveChanges();
        }
    }
}