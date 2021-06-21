<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="CentuDY_Project.View.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="usernameTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="passwordTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:CheckBox ID="rememberMe" runat="server" Text="Remember me"/>
        </div>

        <div>
            <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click"/>
        </div>

        <div>
            <asp:Label ID="LabelMsg" runat="server" Text=""></asp:Label>
        </div>

        <asp:HyperLink ID="Registerink" NavigateUrl="~/View/RegisterPage.aspx" runat="server">Register</asp:HyperLink>

    </form>
</body>
</html>
