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
    public partial class UserProfilePage : System.Web.UI.Page
    {

        static User x;
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

            x = (User)Session["user"];
            User user = UserController.getProfile(x.UserId);

            usernameTxt.Text = user.Username;
            nameTxt.Text = user.Name;
            genderTxt.Text = user.Gender;
            addressTxt.Text = user.Address;
            phoneTxt.Text = user.PhoneNumber;
        }

        protected void updateProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/UpdateProfilePage.aspx?UserId=" + x.UserId);
        }

        protected void changePasswordBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ChangePasswordPage.aspx?UserId=" + x.UserId);
        }
    }
}