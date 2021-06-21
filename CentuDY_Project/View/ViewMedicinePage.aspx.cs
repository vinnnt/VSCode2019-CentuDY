using CentuDY_Project.Controller;
using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY_Project.View
{ 
    
    public partial class ViewMedicinePage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = keyTxt.Text;

            HttpCookie reqCookies = Request.Cookies["userInfo"];

            if (Session["user"] == null)
            {
                if (reqCookies == null)
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
                else
                {
                    string username = reqCookies["username"].ToString();
                    User u = new User();
                    u.Username = username;
                    Session["user"] = u;
                }
            }

            List<Medicine> medicineList = MedicineController.getMedicineList(key);
            MedicineRepeater.DataSource = medicineList;
            MedicineRepeater.DataBind();
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string key = keyTxt.Text;

            List<Medicine> medicineList = MedicineController.getMedicineList(key);
            MedicineRepeater.DataSource = medicineList;
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertMedicinePage.aspx");
        }
    }
}