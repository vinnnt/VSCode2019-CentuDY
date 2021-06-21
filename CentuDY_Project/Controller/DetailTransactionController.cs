using CentuDY_Project.Handler;
using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Controller
{
    public class DetailTransactionController
    {
        public static void createDetail(List<Cart> cart ,int transactionId)
        {
            for(int i = 0; i < cart.Count; i++)
            {
                DetailTransactionHandler.createDetail(transactionId, cart.ElementAt(i).MedicineId, cart.ElementAt(i).Quantity);
            }
        }

        public static List<DetailTransaction> getDetailList(int transactionId)
        {
            return DetailTransactionHandler.getDetailList(transactionId);
        }

        public static void deleteDetail(List<DetailTransaction> dt)
        {
            for (int i = 0; i < dt.Count; i++)
            {
                DetailTransactionHandler.deleteDetail(dt.ElementAt(i).TransactionId, dt.ElementAt(i).MedicineId);
            }
        }
    }
}