<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="CentuDY_Project.View.RegisterPage" %>

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
            <asp:Label ID="Label3" runat="server" Text="Confirm Password: "></asp:Label>
            <asp:TextBox ID="confirmationPasswordTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label4" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:RadioButtonList ID="genderTxt" runat="server">
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
            </asp:RadioButtonList>

        </div>

        <div>
            <asp:Label ID="Label5" runat="server" Text="Phone Number: "></asp:Label>
            <asp:TextBox ID="phoneNumberTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label6" runat="server" Text="Address: "></asp:Label>
            <asp:TextBox ID="addressTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click"/>
        </div>

        <asp:HyperLink ID="loginLink" NavigateUrl="~/View/LoginPage.aspx" runat="server">Login</asp:HyperLink>

        <div>
            <asp:Label ID="LabelMsg" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
