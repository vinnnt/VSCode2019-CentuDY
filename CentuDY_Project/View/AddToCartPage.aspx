<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToCartPage.aspx.cs" Inherits="CentuDY_Project.View.AddToCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="nameTxt" runat="server" Enabled="false"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label2" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="descriptionTxt" runat="server" Enabled="false"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label3" runat="server" Text="Stock: "></asp:Label>
            <asp:TextBox ID="stockTxt" runat="server" Enabled="false"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label4" runat="server" Text="Price: "></asp:Label>
            <asp:TextBox ID="priceTxt" runat="server" Enabled="false"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label5" runat="server" Text="Quantity: "></asp:Label>
            <asp:TextBox ID="quantityTxt" runat="server"></asp:TextBox>
        </div>

            <div>
            <asp:Button ID="addBtn" runat="server" Text="Add to Cart" OnClick="addBtn_Click"/>
        </div>

        <div>
            <asp:Label ID="LabelMsg" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
