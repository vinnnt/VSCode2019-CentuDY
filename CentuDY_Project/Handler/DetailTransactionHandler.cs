using CentuDY_Project.Model;
using CentuDY_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Handler
{
    public class DetailTransactionHandler
    {
        public static void createDetail(int transactionId, int medicineId, int quantity)
        {

            DetailTransactionRepository.createDetail(transactionId, medicineId, quantity);

        }

        public static List<DetailTransaction> getDetailList(int transactionId)
        {
            return DetailTransactionRepository.getDetailList(transactionId);
        }

        public static void deleteDetail(int transactionId, int medicineId)
        {
            DetailTransactionRepository.deleteDetail(transactionId, medicineId);
        }
    }
}