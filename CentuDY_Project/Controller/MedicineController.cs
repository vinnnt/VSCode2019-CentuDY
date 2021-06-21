using CentuDY_Project.Handler;
using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CentuDY_Project.Controller
{
    public class MedicineController
    {
        public static List<Medicine> getMedicineList(string key)
        {
            return MedicineHandler.getMedicineList(key);
        }

        public static dynamic createMedicine(string name, string description, string stock, string price)
        {

            int stockVal = 0;
            int priceVal = 0;

            if (name == null)
            {
                return "Name cannot be empty";
            }

            if (description == null)
            {
                return "Description cannot be empty";
            }
            if(description.Length < 10)
            {
                return "Description length must be longer than 10";
            }

            if(stock == "")
            {
                return "stock cannot be empty";
            }
            else
            {
                int x = 0;
                if (int.TryParse(stock, out x))
                {
                    stockVal = Int32.Parse(stock);
                }
                else
                {
                    return "stock must be numeric";
                }
            }

            if(stockVal <= 0)
            {
                return "stock must be more than 0";
            }

            if (!Regex.IsMatch(stock, @"^\d+$"))
            {
                return "stock must be numeric";
            }

            if (price == "")
            {
                return "price cannot be empty";
            }
            else
            {
                int x = 0;
                if (int.TryParse(price, out x))
                {
                    priceVal = Int32.Parse(price);
                }
                else
                {
                    return "stock must be numeric";
                }
            }
            if (priceVal <= 0)
            {
                return "price must be more than 0";
            }
            if (!Regex.IsMatch(price, @"^\d+$"))
            {
                return "price must be numeric";
            }

            int status = MedicineHandler.createMedicine(name, description, stockVal, priceVal);

            if(status == 1)
            {
                return "Medicine successfully inserted";
            }
            return "Failed to insert medicine";
        }


        public static dynamic updateMedicine(int id, string name, string description, string stock, string price)
        {

            int stockVal = 0;
            int priceVal = 0;

            if (name == null)
            {
                return "Name cannot be empty";
            }

            if (description == null)
            {
                return "Description cannot be empty";
            }
            if (description.Length < 10)
            {
                return "Description length must be longer than 10";
            }

            if (stock == "")
            {
                return "stock cannot be empty";
            }
            else
            {
                int x = 0;
                if (int.TryParse(stock, out x))
                {
                    stockVal = Int32.Parse(stock);
                }
                else
                {
                    return "stock must be numeric";
                }
            }

            if (stockVal <= 0)
            {
                return "stock must be more than 0";
            }

            if (!Regex.IsMatch(stock, @"^\d+$"))
            {
                return "stock must be numeric";
            }

            if (price == "")
            {
                return "price cannot be empty";
            }
            else
            {
                int x = 0;
                if (int.TryParse(price, out x))
                {
                    priceVal = Int32.Parse(price);
                }
                else
                {
                    return "stock must be numeric";
                }
            }
            if (priceVal <= 0)
            {
                return "price must be more than 0";
            }
            if (!Regex.IsMatch(price, @"^\d+$"))
            {
                return "price must be numeric";
            }

            int status = MedicineHandler.updateMedicine(id, name, description, stockVal, priceVal);

            if (status == 1)
            {
                return "Medicine successfully update";
            }
            return "Failed to update medicine";
        }

        public static Medicine getMedicineById(int id)
        {
            return MedicineHandler.getMedicineById(id);
        }

        public static void deleteMedicine(int id)
        {
            MedicineHandler.deleteMedicine(id);
        }

        public static List<Medicine> getRandomMedicineList()
        {
            return MedicineHandler.getRandomMedicineList();
        }

        public static int getMedicineId(string name)
        {
            return MedicineHandler.getMedicineId(name);
        }

        public static void buyMedicine(List<Cart> cart)
        {
            for(int i=0; i<cart.Count; i++)
            {
                MedicineHandler.buyMedicine(cart.ElementAt(i).MedicineId, cart.ElementAt(i).Quantity);
            }
        }
    }
}