using CentuDY_Project.Factory;
using CentuDY_Project.Model;
using CentuDY_Project.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Repository
{
    public class MedicineRepository
    {
        private static CentuDYDBEntities db = DatabaseSingleton.getInstance();
        private static Random rand = new Random();

        //insert medicine
        public static int createMedicine(string name , string description , int stock , int price)
        {
            Medicine medicine = MedicineFactory.createMedicine(name, description, stock, price);
            db.Medicines.Add(medicine);
            return db.SaveChanges();
        }

        //get medicine list
        public static List<Medicine> getMedicineList(string key) 
        {
            if(key == "")
            {
                return (
                    from
                        x
                    in
                        db.Medicines
                    select
                        x
                ).ToList();
            }
            
            else
            {
                return (
                    from
                        x
                    in
                        db.Medicines

                    where 
                        x.Name == key
                    select
                        x
                ).ToList();

            }
        }

        // update medicine
        public static int updateMedicine(int id, string name, string description, int stock, int price)
        {
            Medicine m = db.Medicines.Find(id);
            m.Name = name;
            m.Description = description;
            m.Stock = stock;
            m.Price = price;

            return db.SaveChanges();
        }
        
        // get medicine
        public static Medicine getMedicineById(int id)
        {
            Medicine m = db.Medicines.Find(id);

            return m;
        }


        // delete medicine
        public static void deleteMedicine(int id)
        {
            Medicine m = db.Medicines.Find(id);
            db.Medicines.Remove(m);

            db.SaveChanges();
        }

        // get medicine randomly
        public static List<Medicine> getRandomMedicineList()
        {
            List<Medicine> randomList =
                (
                from
                    x
                in
                    db.Medicines
                select
                    x
                ).OrderBy(x => Guid.NewGuid()).Take(5).ToList();

            return randomList;
        }

        // get medicine stock
        public static int getStock(int id)
        {
            Medicine m = db.Medicines.Find(id);
            return m.Stock;
        }

        public static int getMedicineId(string name)
        {
            Medicine m = (
                from
                    x
                in
                    db.Medicines
                where
                    x.Name == name
                select
                    x
                ).FirstOrDefault();

            return m.MedicineId;
        }

        public static void buyMedicine(int id, int quantity)
        {
            Medicine m = (
                from
                    x
                in
                    db.Medicines
                where
                    x.MedicineId == id
                select
                    x
                ).FirstOrDefault();

            m.Stock = m.Stock - quantity;

            db.SaveChanges();
            
        }
    }
}