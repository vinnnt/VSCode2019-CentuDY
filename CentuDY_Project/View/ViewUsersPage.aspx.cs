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
    public partial class ViewUsersPage : System.Web.UI.Page
    {
        static string role;
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
                    role = UserController.getUserRole(username);
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

            if (role == "Member")
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            List<User> userList = UserController.getUserList();
            Repeater.DataSource = userList;
            Repeater.DataBind();
        }
    }
}