<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePasswordPage.aspx.cs" Inherits="CentuDY_Project.View.ChangePasswordPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      
        <div>
            <asp:Label ID="Label1" runat="server" Text="Old Password: "></asp:Label>
            <asp:TextBox ID="oldPasswordTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label2" runat="server" Text="New Password: "></asp:Label>
            <asp:TextBox ID="newPasswordTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label3" runat="server" Text="Confirm Password: "></asp:Label>
            <asp:TextBox ID="confirmPasswordTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click"/>
        </div>

        <div>
            <asp:Label ID="LabelMsg" runat="server" Text=""></asp:Label>
        </div>
      
    </form>
</body>
</html>
