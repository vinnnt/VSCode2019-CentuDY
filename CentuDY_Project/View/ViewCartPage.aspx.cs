using CentuDY_Project.Controller;
using CentuDY_Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY_Project.View
{
    public partial class ViewCartPage : System.Web.UI.Page
    {
        static double total = 0;
        static User user;
        static HeaderTransaction ht;
        static string role;
        static List<Cart> cart;
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

            if ( role == "Administration")
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            

            List<Cart> cartList = CartController.getCartList(user.UserId);
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Price");
            dt.Columns.Add("Sub Total");

            for(int i=0; i<cartList.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = cartList.ElementAt(i).Medicine.Name;
                dr["Quantity"] = cartList.ElementAt(i).Quantity;
                dr["Price"] = cartList.ElementAt(i).Medicine.Price;
                dr["Sub Total"] = cartList.ElementAt(i).Quantity * cartList.ElementAt(i).Medicine.Price;
                total += (cartList.ElementAt(i).Quantity * cartList.ElementAt(i).Medicine.Price);

                dt.Rows.Add(dr);
            }
            GridView.FooterStyle.BorderColor = Color.Transparent;
            GridView.FooterStyle.Font.Bold = true;

            GridView.DataSource = dt;
            GridView.DataBind();

     
        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strId = GridView.Rows[e.RowIndex].Cells[0].Text;
            int medicineId = MedicineController.getMedicineId(strId);

            var status = CartController.removeCartItem(user.UserId, medicineId);
            if (status is string)
            {
                LblMsg.Text = status;
            }
            else
            {
                Response.Redirect("~/View/ViewCartPage.aspx");
            }
        }


        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if(e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Grand Total";
                e.Row.Cells[3].Text = total.ToString();
             
            }
        }

        protected void checkoutBtn_Click(object sender, EventArgs e)
        {
            ht = HeaderTransactionController.createHeader(user.UserId, DateTime.Now);
            cart = CartController.getCartList(user.UserId);
            DetailTransactionController.createDetail(cart, ht.TransactionId);
            MedicineController.buyMedicine(cart);

            var response = CartController.clearCart(cart);

            if(response == 1)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            else
            {
                LblMsg.Text = "Failed to checkout items";
            }
        }
    }
}