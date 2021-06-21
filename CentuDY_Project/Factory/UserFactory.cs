using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Factory
{
    public class UserFactory
    {
        public static User createUser(int roleId, string username, string password, string name, string gender, string phoneNumber, string address)
        {
            User u = new User();
            u.RoleId = roleId;
            u.Username = username;
            u.Password = password;
            u.Name = name;
            u.Gender = gender;
            u.PhoneNumber = phoneNumber;
            u.Address = address;

            return u;
        }
    }
}