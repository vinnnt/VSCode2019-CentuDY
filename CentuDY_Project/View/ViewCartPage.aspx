<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCartPage.aspx.cs" Inherits="CentuDY_Project.View.ViewCartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <h4>
           My Cart
       </h4>
        <div>
            <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridView_RowDeleting" OnRowDataBound="GridView_RowDataBound"  EditRowStyle-BackColor="White" ShowFooter="true" >
                <Columns>
                    <asp:BoundField HeaderText="Name" DataField="Name" />
                     <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                     <asp:BoundField HeaderText="Price" DataField="Price" />
                      <asp:BoundField HeaderText="Sub Total" DataField="Sub Total" />
                </Columns>
               
                <Columns>
                    <asp:CommandField ShowDeleteButton="true" HeaderText="Action"/>
                </Columns>
                
            </asp:GridView>
        </div>
        <asp:Button ID="checkoutBtn" runat="server" Text="Checkout" OnClick="checkoutBtn_Click"/>
        <asp:Label ID="LblMsg" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
