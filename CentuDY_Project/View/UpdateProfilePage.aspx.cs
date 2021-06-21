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
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        static User user;

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
            if (!Page.IsPostBack)
            {
                int id = int.Parse(userId);
                user = UserController.getProfile(id);
                nameTxt.Text = user.Name;
                genderTxt.SelectedValue = user.Gender;
                phoneTxt.Text = user.PhoneNumber;
                addressTxt.Text = user.Address;
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            string response = UserController.updateProfile(user.UserId, nameTxt.Text, genderTxt.Text, phoneTxt.Text, addressTxt.Text);

            LabelMsg.Text = response;
        }
    }
}