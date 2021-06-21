using CentuDY_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentuDY_Project.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;
            string confirmationPassword = confirmationPasswordTxt.Text;
            string name = nameTxt.Text;
            string gender = genderTxt.SelectedValue;
            string phoneNumber = phoneNumberTxt.Text;
            string address = addressTxt.Text;

            var response = UserController.register(username, password, name, gender, phoneNumber, address, confirmationPassword);

            LabelMsg.Text = response;

        }
    }
}