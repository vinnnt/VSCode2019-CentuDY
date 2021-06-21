using CentuDY_Project.Handler;
using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Controller
{
    public class HeaderTransactionController
    {
        public static HeaderTransaction createHeader(int userid, DateTime transactionDate)
        {
            return HeaderTransactionHandler.createHeader(userid, transactionDate);
        }

        public static void deleteHeader(int userId)
        {
            HeaderTransactionHandler.deleteHeader(userId);
        }

        public static int getTransactionId(int userId)
        {
            return HeaderTransactionHandler.getTransactionId(userId);
        }

        public static List<HeaderTransaction> getHeaderList(int userId)
        {
            return HeaderTransactionHandler.getHeaderList(userId);
        }

        public static List<HeaderTransaction> getAllHeaderList()
        {
            return HeaderTransactionHandler.getAllHeaderList();
        }
    }
}