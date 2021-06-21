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
    public partial class InsertMedicinePage : System.Web.UI.Page
    {
        static string role;
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    role = UserController.getUserRole(username);
                    u.Username = username;
                    Session["user"] = u;
                }
            }
            if (Session["userRole"] == null)
            {
                Response.Redirect("~/View/LoginPage.aspx");
            }
            else
            {
                role = Session["userRole"].ToString();
            }

            User user = (User)Session["user"];

            if (role == "Member")
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
        }

        protected void insertrBtn_Click(object sender, EventArgs e)
        {
            var response = MedicineController.createMedicine(nameTxt.Text, descriptionTxt.Text, stockTxt.Text, priceTxt.Text);

            LabelMsg.Text = response;
        }
    }
}