<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfilePage.aspx.cs" Inherits="CentuDY_Project.View.UpdateProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      
        <div>
            <asp:Label ID="LblName" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
        </div>

         <div>
            <asp:RadioButtonList ID="genderTxt" runat="server">
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <asp:Label ID="LblPhone" runat="server" Text="PhoneNumber: "></asp:Label>
            <asp:TextBox ID="phoneTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="LblAddress" runat="server" Text="Address: "></asp:Label>
            <asp:TextBox ID="addressTxt" runat="server"></asp:TextBox>
        </div>

         <div>
            <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click"/>
        </div>

        <div>
            <asp:Label ID="LabelMsg" runat="server" Text=""></asp:Label>
        </div>
       
    </form>
</body>
</html>
