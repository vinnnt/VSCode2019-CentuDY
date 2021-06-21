<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMedicinePage.aspx.cs" Inherits="CentuDY_Project.View.ViewMedicinePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h4>View Medicine</h4>

        <div>
            <asp:Label ID="Label1" runat="server" Text="Search Medicine: "></asp:Label>
            <asp:TextBox ID="keyTxt" runat="server"></asp:TextBox>
        </div>
         <div>
            <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click"/> <br /> <br />
        </div>
        <%
            if(Session["userRole"].ToString() == "Administrator") {%>
            <asp:Button ID="insertBtn" runat="server" Text="Insert Medicine" OnClick="insertBtn_Click"/> <br />
        <%
            } %>

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
            
            <div>
                <%
                    //Console.WriteLine(Session["userRole"].ToString());
                    if (Session["userRole"] == null) {
                        Response.Redirect("~/View/HomePage.aspx");
                    }
                    else if((string)Session["userRole"] == "Member")
                    {
                    %>
                        <asp:HyperLink ID="AddToCartLink" NavigateUrl='<%# "~/View/AddToCartPage.aspx?MedicineId=" + Eval("MedicineId")%>' runat="server">Add to Cart</asp:HyperLink>
                    <%
                    }
                    else if((string)Session["userRole"] == "Administrator")
                    { 
                    %>
                        <asp:HyperLink ID="UpdateMedicineLink" NavigateUrl='<%# "~/View/UpdateMedicinePage.aspx?MedicineId=" + Eval("MedicineId")%>' runat="server">Update Medicine</asp:HyperLink>

                        <asp:HyperLink ID="DeleteMedicineLink" NavigateUrl='<%# "~/View/DeleteMedicinePage.aspx?MedicineId=" + Eval("MedicineId")%>' runat="server">Delete Medicine</asp:HyperLink>
                    <%
                    }
                %>
            </div>

            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
