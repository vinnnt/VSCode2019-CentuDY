using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Factory
{
    public class DetailTransactionFactory
    {
        public static DetailTransaction createDetail(int transactionId , int medicineId, int quantity)
        {
            DetailTransaction dt = new DetailTransaction();
            dt.TransactionId = transactionId;
            dt.MedicineId = medicineId;
            dt.Quantity = quantity;
            
            return dt;
        }

    }
}