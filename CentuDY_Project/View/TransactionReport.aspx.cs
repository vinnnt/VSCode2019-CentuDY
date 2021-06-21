using CentuDY_Project.Controller;
using CentuDY_Project.CrystalReport;
using CentuDY_Project.Model;
using CentuDY_Project.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY_Project.View
{
    public partial class TransactionReport : System.Web.UI.Page
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

            TransactionCrystalReport cr = new TransactionCrystalReport();

            cr.SetDataSource(getDataSet(
               HeaderTransactionController.getAllHeaderList()
            ));

            CrystalReportViewer.ReportSource = cr;
        }

        protected TransactionDataSet getDataSet(List<HeaderTransaction> transactions)
        {
            TransactionDataSet ds = new TransactionDataSet();

            var header = ds.HeaderTransaction;
            var detail = ds.DetailTransaction;
            foreach (HeaderTransaction ht in transactions)
            {
                var newHeader = header.NewRow();

                newHeader["TransactionId"] = ht.TransactionId;
                newHeader["Username"] = ht.User.Username;
                newHeader["TransactionDate"] = ht.TransactionDate;

                header.Rows.Add(newHeader);

                foreach (DetailTransaction dt in ht.DetailTransactions.ToList())
                {
                    var newDetail = detail.NewRow();

                    newDetail["HeaderTransactionId"] = ht.TransactionId;
                    newDetail["MedicineName"] = dt.Medicine.Name;
                    newDetail["MedicinePrice"] = dt.Medicine.Price;
                    newDetail["Quantity"] = dt.Quantity;

                    detail.Rows.Add(newDetail);
                }
            }

            return ds;
        }
    }
}