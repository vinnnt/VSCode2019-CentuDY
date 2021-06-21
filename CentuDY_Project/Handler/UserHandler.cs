using CentuDY_Project.Model;
using CentuDY_Project.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Handler
{
    public class UserHandler
    {
        public static int createUser(int roleId, string username, string password, string name, string gender, string phoneNumber, string address)
        {
            if (!UserRepository.checkUsername(username))
            {
                return 0;
            }
            return UserRepository.createUser(roleId, username, password, name, gender, phoneNumber, address);
        }

        public static User getUser(string username, string password)
        {
            return UserRepository.getUser(username, password);
        }

        public static List<User> getUserList()
        {
            return UserRepository.getUserList();
        }

        public static bool checkUsername(string username)
        {
            return UserRepository.checkUsername(username);
        }

        public static User getProfile(int id)
        {
            return UserRepository.getProfile(id);
        }

        public static int updateProfile(int id, string name, string gender, string phoneNumber, string address)
        {
            return UserRepository.updateProfile(id, name, gender, phoneNumber, address);
        }

        public static string getOldPassword(int id)
        {
            return UserRepository.getOldPassword(id);
        }

        public static int updatePassword(int id , string newPassword)
        {
            return UserRepository.updatePassword(id, newPassword);
        }

        public static void deleteUser(int id)
        {
            if (CartRepository.cartExistByUserId(id))
            {
                List<Cart> cart = CartRepository.getCartList(id);
                for (int i = 0; i < cart.Count; i++)
                {
                    CartRepository.clearCart(cart.ElementAt(i).UserId, cart.ElementAt(i).MedicineId);
                }
            }

            if (DetailTransactionRepository.detailExistByTransactionId(HeaderTransactionRepository.getTransactionId(id)))
            {
                List<DetailTransaction> dt = DetailTransactionRepository.getDetailList(HeaderTransactionRepository.getTransactionId(id));
                for (int i = 0; i < dt.Count; i++)
                {
                    DetailTransactionRepository.deleteDetail(dt.ElementAt(i).TransactionId, dt.ElementAt(i).MedicineId);
                }
            }

            if (HeaderTransactionRepository.headerExist(id))
            {
                List<HeaderTransaction> ht = HeaderTransactionRepository.getHeaderList(id);
                for (int i = 0; i < ht.Count; i++)
                {
                    HeaderTransactionRepository.deleteHeader(id);
                }
            }

            UserRepository.deleteUser(id);
        } 

        public static string getUserRole(string username)
        {
            return UserRepository.getUserRole(username);
        }
    }
}