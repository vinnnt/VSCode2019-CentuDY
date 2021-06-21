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
    public partial class UpdateMedicinePage : System.Web.UI.Page
    {
        static string role;
        static Medicine m;
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

            queryString();
        }

        protected void queryString()
        {
            string medicineId = Request.QueryString["MedicineId"];
            if (medicineId == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            if (!Page.IsPostBack)
            {
                int id = int.Parse(medicineId);
                m = MedicineController.getMedicineById(id);
                nameTxt.Text = m.Name;
                descriptionTxt.Text = m.Description;
                stockTxt.Text = m.Stock.ToString();
                priceTxt.Text = m.Price.ToString();
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            string response = MedicineController.updateMedicine(m.MedicineId, nameTxt.Text, descriptionTxt.Text , stockTxt.Text, priceTxt.Text);

            LabelMsg.Text = response;
        }
    }
}