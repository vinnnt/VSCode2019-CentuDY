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
    public partial class HomePage : System.Web.UI.Page
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
                    Session["user"] = u;
                    role = UserController.getUserRole(username);
                    usernameTxt.Text = username;
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
            usernameTxt.Text = "Welcome, " + user.Username;

            List<Medicine> randomMedicineList = MedicineController.getRandomMedicineList();
            MedicineRepeater.DataSource = randomMedicineList;
            MedicineRepeater.DataBind();

            buttonVisibility();
          
        }

        protected void buttonVisibility()
        {
           
            //User user = (User)Session["user"];
            //string userRole = user.Role.RoleName;

            if(role == "Member")
            {
                insertMedicineBtn.Style.Add("display", "none");
                viewUsersBtn.Style.Add("display", "none");
                viewTransactionsReportBtn.Style.Add("display", "none");
            }
            else if(role== "Administrator")
            {
                viewCartBtn.Style.Add("display", "none");
                viewTransactionHistoryBtn.Style.Add("display", "none");
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];

            Session.Remove("user");
            Session.Remove("userRole");
            Session.Clear();
            Session.Abandon();

            if (reqCookies != null)
            {
                reqCookies.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(reqCookies);
            }

            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void viewProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/UserProfilePage.aspx");
        }

        protected void viewMedicineBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ViewMedicinePage.aspx");
        }

        protected void viewCartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ViewCartPage.aspx");
        }

        protected void viewTransactionHistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionHistoryPage.aspx");
        }

        protected void insertMedicineBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertMedicinePage.aspx");
        }

        protected void viewUsersBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ViewUsersPage.aspx");
        }

        protected void viewTransactionsReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionReport.aspx");
        }
    }
}