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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                usernameTxt.Text = reqCookies["username"].ToString();
                passwordTxt.Text = reqCookies["password"].ToString();
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;

            var response = UserController.login(username, password);
            if (response is User)
            {
                // set session
                Session["user"] = response;
                Session["userRole"] = UserController.getUserRole(username);

                //set cookie
                if (rememberMe.Checked)
                {
                    // cookie user
                    HttpCookie cookie = new HttpCookie("userInfo");
                    cookie["username"] = response.Username;
                    cookie["password"] = response.Password;
                    cookie.Expires = DateTime.Now.AddDays(1);

                    Response.Cookies.Add(cookie);
                }

                Response.Redirect("~/View/HomePage.aspx");
            }
            else if(response is string)
            {
                LabelMsg.Text = response;
            }
        }
    }
}