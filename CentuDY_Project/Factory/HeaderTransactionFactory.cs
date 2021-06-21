using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Factory
{
    public class HeaderTransactionFactory
    {
        public static HeaderTransaction createHeader(int userid, DateTime transactionDate)
        {
            HeaderTransaction ht = new HeaderTransaction();
            ht.UserId = userid;
            ht.TransactionDate = transactionDate;

            return ht;
        }
    }
}