<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateMedicinePage.aspx.cs" Inherits="CentuDY_Project.View.UpdateMedicinePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label2" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="descriptionTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label3" runat="server" Text="Stock: "></asp:Label>
            <asp:TextBox ID="stockTxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label4" runat="server" Text="Price: "></asp:Label>
            <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox>
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
