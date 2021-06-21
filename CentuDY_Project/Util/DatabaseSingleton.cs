using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY_Project.Util
{
    public class DatabaseSingleton
    {
        private static CentuDYDBEntities db;
        public static CentuDYDBEntities getInstance()
        {
            if(db == null)
            {
                db = new CentuDYDBEntities();
            }
            return db;
        }
    }
}