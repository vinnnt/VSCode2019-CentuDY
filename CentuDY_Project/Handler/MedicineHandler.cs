using CentuDY_Project.Model;
using CentuDY_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Handler
{
    public class MedicineHandler
    {
        public static int createMedicine(string name, string description, int stock, int price)
        {
            return MedicineRepository.createMedicine(name, description, stock, price);
        }

        public static List<Medicine> getMedicineList(string key)
        {
            return MedicineRepository.getMedicineList(key);
        }

        public static int updateMedicine(int id, string name, string description, int stock, int price)
        {
            return MedicineRepository.updateMedicine(id, name, description, stock, price);
        }

        public static Medicine getMedicineById(int id)
        {
            return MedicineRepository.getMedicineById(id);
        }
        public static void deleteMedicine(int id)
        {

            Medicine m = MedicineRepository.getMedicineById(id);
            if (m == null)
            {
                return;
            }
            if (CartRepository.cartExist(id))
            {
                CartRepository.clearCartByMedicineId(id);
            }

            if (DetailTransactionRepository.detailExist(id))
            {
                DetailTransactionRepository.deleteDetailByMedicineId(id);
            }
            MedicineRepository.deleteMedicine(id);
        }

        public static List<Medicine> getRandomMedicineList()
        {
            return MedicineRepository.getRandomMedicineList();
        }

        public static int getMedicineId(string name)
        {
            return MedicineRepository.getMedicineId(name);
        }

        public static void buyMedicine(int id, int quantity)
        {
            MedicineRepository.buyMedicine(id, quantity);
        }
    }
}