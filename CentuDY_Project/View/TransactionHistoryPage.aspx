<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="CentuDY_Project.View.TransactionHistoryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <h4>
           My Transaction History
       </h4>
        <div>
            <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView_RowDataBound"  EditRowStyle-BackColor="White" ShowFooter="true" >
                <Columns>
                    <asp:BoundField HeaderText="Name" DataField="Name" />
                     <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                     <asp:BoundField HeaderText="Date" DataField="Date" />
                      <asp:BoundField HeaderText="Sub Total" DataField="Sub Total" />
                </Columns>
            </asp:GridView>
        </div>
     
    </form>
</body>
</html>
