using CentuDY_Project.Factory;
using CentuDY_Project.Model;
using CentuDY_Project.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Repository
{
    public class UserRepository
    {
        private static CentuDYDBEntities db = DatabaseSingleton.getInstance();

        // register
        public static int createUser(int roleId, string username, string password, string name, string gender, string phoneNumber, string address)
        {
            User user = UserFactory.createUser(roleId, username, password, name, gender, phoneNumber, address);
            db.Users.Add(user);
            return db.SaveChanges();
        }

        // login
        public static User getUser(string Username, string password)
        {
            return 
                (
                    from 
                        x 
                    in 
                        db.Users 
                    where 
                        x.Username == Username && x.Password == password 
                    select 
                        x
                ).FirstOrDefault();
        }

        // to get user list 
        public static List<User> getUserList()
        {
            return
                (
                    from
                        x
                    in
                        db.Users
                    select
                        x
                ).ToList();
        }

        // to get profile
        public static User getProfile(int id)
        {
            return
                (
                    from
                        x
                    in
                        db.Users
                    where
                        x.UserId == id
                    select
                        x
            ).FirstOrDefault();
        }


        //Update Profile
        public static int updateProfile(int id, string name, string gender, string phoneNumber, string address)
        {
            User u = db.Users.Find(id);
            u.Name = name;
            u.Gender = gender;
            u.PhoneNumber = phoneNumber;
            u.Address = address;

            return db.SaveChanges();
        }


        //Change Password
        public static int updatePassword(int id, string password)
        {
            User u = db.Users.Find(id);
            u.Password = password;
            return db.SaveChanges();
        }

        public static string getOldPassword(int id)
        {
            User u = db.Users.Find(id);
            return u.Password;
        }

        // check unique
        public static bool checkUsername(string username)
        {
            User u =
            (
                from
                    x
                in
                    db.Users
                where
                    x.Username.Equals(username)
                select
                    x
            ).FirstOrDefault();
            
            if(u == null)
            {
                return true;
            }
            return false;
        }
        
        // delete user
        public static void deleteUser(int id)
        {
            User u = db.Users.Find(id);

            db.Users.Remove(u);
            db.SaveChanges();
        }
        public static string getUserRole(string username)
        {
            int role = (
                from
                    x
                in
                    db.Users
                where
                    x.Username == username
                select
                    x.RoleId
                ).FirstOrDefault();

            if(role == 1)
            {
                return "Administrator";
            }
            else
            {
                return "Member";
            }
          
        }

    }
}