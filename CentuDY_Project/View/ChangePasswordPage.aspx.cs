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
    public partial class ChangePasswordPage : System.Web.UI.Page
    {
        static int id;

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
                    u.Username = username;
                    Session["user"] = u;
                }
            }

            queryString();
        }

        protected void queryString()
        {
            string userId = Request.QueryString["UserId"];
            if (userId == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            id = int.Parse(userId);
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            var response = UserController.updatePassword(id, oldPasswordTxt.Text, newPasswordTxt.Text, confirmPasswordTxt.Text);

            LabelMsg.Text = response;
        }
    }
}