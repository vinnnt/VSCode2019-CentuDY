using CentuDY_Project.Factory;
using CentuDY_Project.Model;
using CentuDY_Project.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Repository
{
    public class DetailTransactionRepository
    {
        private static CentuDYDBEntities db = DatabaseSingleton.getInstance();
        public static int createDetail(int transactionId , int medicineId , int quantity)
        {
            DetailTransaction dt = DetailTransactionFactory.createDetail(transactionId, medicineId, quantity);
            db.DetailTransactions.Add(dt);

            return db.SaveChanges();
        }
        
        public static List<DetailTransaction> getDetailList(int transactionId)
        {
            return (
                from
                    x
                in
                    db.DetailTransactions
                where
                    x.TransactionId == transactionId
                select
                    x
                ).ToList();
        }


        public static void deleteDetail(int transactionId, int medicineId)
        {
            DetailTransaction dt = (
                from
                     x
                in
                    db.DetailTransactions
                where
                    x.TransactionId == transactionId && x.MedicineId == medicineId
                select
                    x
                ).FirstOrDefault();

            db.DetailTransactions.Remove(dt);

            db.SaveChanges();
        }

        public static bool detailExist(int medicineId)
        {
            DetailTransaction dt = (
              from
                   x
              in
                  db.DetailTransactions
              where
                   x.MedicineId == medicineId
              select
                  x
              ).FirstOrDefault();

            if(dt == null)
            {
                return false;
            }
            return true;
        }

        public static bool detailExistByTransactionId(int transactionId)
        {
            DetailTransaction dt = (
              from
                   x
              in
                  db.DetailTransactions
              where
                   x.TransactionId == transactionId
              select
                  x
              ).FirstOrDefault();

            if (dt == null)
            {
                return false;
            }
            return true;
        }

        public static void deleteDetailByMedicineId(int medicineId)
        {
            DetailTransaction dt = (
               from
                    x
               in
                   db.DetailTransactions
               where
                    x.MedicineId == medicineId
               select
                   x
               ).FirstOrDefault();

            db.DetailTransactions.Remove(dt);

            db.SaveChanges();
        }
    }
}