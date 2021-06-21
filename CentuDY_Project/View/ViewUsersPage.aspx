<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUsersPage.aspx.cs" Inherits="CentuDY_Project.View.ViewUsersPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h4>View Users</h4>

        <div>
            <asp:Repeater ID="Repeater" runat="server">
                <ItemTemplate>
                    <br />
                    Username:
                    <asp:Label ID="LblUsername" runat="server" Text='<%# Eval("Username")%>'></asp:Label>
                    <br />
    
                    Name:
                    <asp:Label ID="LblName" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                    <br />

                    Role:
                    <asp:Label ID="LblRole" runat="server" Text='<%# Eval("RoleId")%>'></asp:Label>
                    <br />

                    Gender:
                    <asp:Label ID="LblGender" runat="server" Text='<%# Eval("Gender")%>'></asp:Label>
                    <br />

                    Phone Number:
                    <asp:Label ID="LblPhone" runat="server" Text='<%# Eval("PhoneNumber")%>'></asp:Label>
                    <br />

                    Address:
                    <asp:Label ID="LblAddress" runat="server" Text='<%# Eval("Address")%>'></asp:Label>
                    <br />
                    <br />

                    <asp:HyperLink ID="DeleteUserLink" NavigateUrl='<%# "~/View/DeleteUserPage.aspx?UserId=" + Eval("UserId")%>' runat="server">Delete User</asp:HyperLink>

                    <br />
                    <br />

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
