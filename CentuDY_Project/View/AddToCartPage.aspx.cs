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
    public partial class AddToCart : System.Web.UI.Page
    {
        static Medicine m;
        static User user;
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

            user = (User)Session["user"];

            if (role == "Administration")
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

        protected void addBtn_Click(object sender, EventArgs e)
        {
            var response = CartController.createCart(user.UserId, m.MedicineId, int.Parse(quantityTxt.Text));
            if(response is string)
            {
                LabelMsg.Text = response;
            }
            else
            {
                Response.Redirect("~/View/ViewCartPage.aspx");
            }
        }
    }
}