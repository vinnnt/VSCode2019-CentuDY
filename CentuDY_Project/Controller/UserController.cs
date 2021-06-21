using CentuDY_Project.Handler;
using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CentuDY_Project.Controller
{
    public class UserController
    {
        // register
        public static dynamic register(string username, string password, string name, string gender, string phoneNumber, string address , string confirmationPassword)
        {
            //username
            if (username == "")
            {
                return "Username must be filled";
            }
            if (username.Length < 3)
            {
                return "Username must be longer than 3 characters";
            }
        
            //password
            if (password == "")
            {
                return "Password must be filled";
            }
            if (password.Length < 8)
            {
                return "Password must be longer than 8 characters";
            }

            //Confirmation Password
            if(confirmationPassword == "")
            {
                return "Confirmation password must be filled";
            }
            if(confirmationPassword != password)
            {
                return "Confirmation password must be the same with password";
            }

            //name
            if (name == "")
            {
                return "Name must be filled";
            }

            //gender
            if (gender == "")
            {
                return "Gender must be chosen";
            }
            if (gender != "Male" && gender != "Female")
            {
                return "Gender must be chosen)";
            }

            //phone
            if (phoneNumber == "")
            {
                return "phone number must be filled";
            }
            if (!Regex.IsMatch(phoneNumber, @"^\d+$"))
            {
                return "phone number must be numeric";
            }

            //address
            if (address == "")
            {
                return "address must be filled";
            }
            if (!address.Contains("Street"))
            {
                return "address must contain the word 'Street' ";
            }

            int status = UserHandler.createUser(2, username, password, name, gender, phoneNumber, address);
            if (status == 1) {
                return "Register success";
            }
            return "Username already exists";
        }



        // login
        public static dynamic login(string username, string password)
        {
            if (username == "")
            {
                return "Username must be filled!";
            }
            if (password == "")
            {
                return "Password must be filled!";
            }
            User u = UserHandler.getUser(username, password);
            if (u == null)
            {
                return "Wrong Password or Username! Please check again!";
            }
            return u;
        }

        //View User Profile
        public static User getProfile(int id)
        {
            return UserHandler.getProfile(id);
        }

        public static List<User> getUserList()
        {
            return UserHandler.getUserList();
        }

        //Update profile
        public static dynamic updateProfile(int id, string name, string gender, string phoneNumber, string address)
        {
            //name
            if (name == "")
            {
                return "Name must be filled";
            }

            //gender
            if (gender == "")
            {
                return "Gender must be chosen";
            }
            if (gender != "Male" && gender != "Female")
            {
                return "Gender must be chosen";
            }

            //phone
            if (phoneNumber == "")
            {
                return "phone number must be filled";
            }
            if (!Regex.IsMatch(phoneNumber, @"^\d+$"))
            {
                return "phone number must be numeric";
            }

            //address
            if (address == "")
            {
                return "address must be filled";
            }
            if (!address.Contains("Street"))
            {
                return "address must contain the word 'Street' ";
            }

            int status = UserHandler.updateProfile(id, name, gender, phoneNumber, address);
            if(status == 1)
            {
                return "Update success";
            }
            return "Update failed";
        }
        
        public static string getOldPassword(int id)
        {
            return UserHandler.getOldPassword(id);
        }


        //Update password

        public static dynamic updatePassword(int id, string oldPassword, string newPassword, string confirm)
        {
            if(oldPassword == "")
            {
                return "Old password must be filled";
            }else if(oldPassword != getOldPassword(id))
            {
                return "Old password is wrong";
            }

            if(newPassword == "")
            {
                return "New password must be filled";
            }else if(newPassword.Length <= 5)
            {
                return "New password must be longer than 5";
            }

            if(confirm == "")
            {
                return "Confirmation password must be filled";
            }else if(confirm != newPassword)
            {
                return "Confirmation password must be the same with new password";
            }

            int status = UserHandler.updatePassword(id, newPassword);

            if(status == 1)
            {
                return "Update password success";
            }
            return "Update password Failed";
        }

        public static void deleteUser(int id)
        {
            UserHandler.deleteUser(id);
        }

        public static string getUserRole (string username)
        {
            return UserHandler.getUserRole(username);
        }
    }
}