using CentuDY_Project.Factory;
using CentuDY_Project.Model;
using CentuDY_Project.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Repository
{
    public class HeaderTransactionRepository
    {
        public static CentuDYDBEntities db = DatabaseSingleton.getInstance();
        public static HeaderTransaction createHeader(int userId , DateTime transactionDate)
        {
            HeaderTransaction ht = HeaderTransactionFactory.createHeader(userId, transactionDate);
            db.HeaderTransactions.Add(ht);

            db.SaveChanges();

            return ht;
        }

        public static void deleteHeader(int userId)
        {
            HeaderTransaction ht = (
                from
                    x
                in
                    db.HeaderTransactions
                where
                    x.UserId == userId
                select
                    x
                ).FirstOrDefault();

            db.HeaderTransactions.Remove(ht);

            db.SaveChanges();
        }

        public static bool headerExist(int userId)
        {
            HeaderTransaction ht = (
               from
                   x
               in
                   db.HeaderTransactions
               where
                   x.UserId == userId
               select
                   x
               ).FirstOrDefault();

            if(ht == null)
            {
                return false;
            }
            return true;
        }

        public static List<HeaderTransaction> getHeaderList(int userId)
        {
            return (
                from
                    x
                in
                    db.HeaderTransactions
                where
                     x.UserId == userId
                select
                    x
                ).ToList();
        }

        

        public static int getTransactionId(int userId)
        {

            HeaderTransaction ht = (
                from
                    x
                in
                    db.HeaderTransactions
                where
                    x.UserId == userId
                select
                    x
                ).FirstOrDefault();

            return ht.TransactionId;
        }

        public static List<HeaderTransaction> getAllHeaderList()
        {
            return (
                from
                    x
                in
                    db.HeaderTransactions
                select
                    x
                ).ToList();
        }
    }
}