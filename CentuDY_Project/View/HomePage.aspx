<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CentuDY_Project.View.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4>CentuDY</h4>
        </div>
        <div>
            <asp:Label ID="usernameTxt" runat="server" Text=" "></asp:Label>
        </div>
        <br />

        <%-- Button --%>
        <div>
            <asp:Button ID="viewMedicineBtn" runat="server" Text="View Medicine" OnClick="viewMedicineBtn_Click"/>
        </div>
        <br />
        <div>
            <asp:Button ID="viewProfileBtn" runat="server" Text="View Profile" OnClick="viewProfileBtn_Click"/>
        </div>
        <br />

        <%-- Member --%>
        <div>
            <asp:Button ID="viewCartBtn" runat="server" Text="View Cart" OnClick="viewCartBtn_Click"/>
        </div>
        <br />
        <div>
            <asp:Button ID="viewTransactionHistoryBtn" runat="server" Text="View Transaction History" OnClick="viewTransactionHistoryBtn_Click"/>
        </div>
        <br />

        <div>
            <%
                if (Session["userRole"] == null) {
                    Response.Redirect("~/View/HomePage.aspx");
                }
                else if(Session["userRole"].ToString() == "Member") 
                { 
                %>
                    <div>
                        <h4>Daily Medicines</h4>
                    </div>
                    <asp:Repeater ID="MedicineRepeater" runat="server">
                        <ItemTemplate>
                        <br />
                        Medicine Name:
                        <asp:Label ID="LblName" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                        <br />
    
                        Description:
                        <asp:Label ID="LblDescription" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                        <br />

                        Stock:
                        <asp:Label ID="LblStock" runat="server" Text='<%# Eval("Stock")%>'></asp:Label>
                        <br />

                        Price:
                        <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("Price")%>'></asp:Label>
                        <br />
                        <br />
    
                        <asp:HyperLink ID="AddToCartLink" NavigateUrl='<%# "~/View/AddToCartPage.aspx?MedicineId=" + Eval("MedicineId")%>' runat="server">Add to Cart</asp:HyperLink>
                        <br />

                        </ItemTemplate>
                    </asp:Repeater>
                <%
                }
            %>
        </div>

        <%--Admin--%>
         <div>
            <asp:Button ID="insertMedicineBtn" runat="server" Text="Insert Medicine" OnClick="insertMedicineBtn_Click"/>
        </div>
        <br />
        <div>
            <asp:Button ID="viewUsersBtn" runat="server" Text="View Users" OnClick="viewUsersBtn_Click"/>
        </div>
        <br />
         <div>
            <asp:Button ID="viewTransactionsReportBtn" runat="server" Text="View Transactions Report" OnClick="viewTransactionsReportBtn_Click"/>
        </div>
        <br />


        <div>
            <asp:Button ID="logoutBtn" runat="server" Text="Logout" OnClick="logoutBtn_Click"/>
        </div>
    </form>
</body>
</html>
