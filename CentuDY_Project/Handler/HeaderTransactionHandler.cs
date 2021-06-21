using CentuDY_Project.Model;
using CentuDY_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Handler
{
    public class HeaderTransactionHandler
    {
        public static HeaderTransaction createHeader(int userid, DateTime transactionDate)
        {
            return HeaderTransactionRepository.createHeader(userid, transactionDate);
        }

        public static void deleteHeader(int userId)
        {
            HeaderTransactionRepository.deleteHeader(userId);
        }

        public static int getTransactionId(int userId)
        {
            return HeaderTransactionRepository.getTransactionId(userId);
        }

        public static List<HeaderTransaction> getHeaderList(int userId)
        {
            return HeaderTransactionRepository.getHeaderList(userId);
        }

        public static List<HeaderTransaction> getAllHeaderList()
        {
            return HeaderTransactionRepository.getAllHeaderList();
        }
    }
}