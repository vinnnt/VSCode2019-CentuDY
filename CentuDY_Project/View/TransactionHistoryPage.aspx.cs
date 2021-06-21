using CentuDY_Project.Controller;
using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY_Project.View
{
    public partial class TransactionHistoryPage : System.Web.UI.Page
    {
        static double total = 0;
        static User user;
        static HeaderTransaction ht;
        static string role;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            total = 0;

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

            if (role == "Administration")
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            List<HeaderTransaction> header = HeaderTransactionController.getHeaderList(user.UserId);
            List<List<DetailTransaction>> detail = new List<List<DetailTransaction>>();

            for (int i = 0; i < header.Count; i++)
            {
                detail.Add(DetailTransactionController.getDetailList(header.ElementAt(i).TransactionId));
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Date");
            dt.Columns.Add("Sub Total");

            foreach(List<DetailTransaction> subList in detail)
            {
                foreach(DetailTransaction item in subList)
                {
                    DataRow dr = dt.NewRow();
                    dr["Name"] = item.Medicine.Name;
                    dr["Quantity"] = item.Quantity;
                    dr["Date"] = item.HeaderTransaction.TransactionDate.ToShortDateString();
                    dr["Sub Total"] = item.Medicine.Price * item.Quantity;
                    total += (item.Medicine.Price * item.Quantity);

                    dt.Rows.Add(dr);
                }
            }
            GridView.FooterStyle.BorderColor = Color.Transparent;
            GridView.FooterStyle.Font.Bold = true;

            GridView.DataSource = dt;
            GridView.DataBind();
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Grand Total";
                e.Row.Cells[3].Text = total.ToString();

            }
        }
    }
}