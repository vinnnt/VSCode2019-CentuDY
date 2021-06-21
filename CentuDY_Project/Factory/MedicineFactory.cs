using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Factory
{
    public class MedicineFactory
    {
        public static Medicine createMedicine(string name, string description, int stock, int price)
        {
            Medicine m = new Medicine();
            m.Name = name;
            m.Description = description;
            m.Stock = stock;
            m.Price = price;

            return m;
        }
    }
}