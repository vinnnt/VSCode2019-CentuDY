<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfilePage.aspx.cs" Inherits="CentuDY_Project.View.UserProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h4>User Profile</h4>

        <div>
            Username:
            <asp:Label ID="usernameTxt" runat="server" Text=""></asp:Label>
            <br />
        </div>
        <div>
            Name:
            <asp:Label ID="nameTxt" runat="server" Text=""></asp:Label>
            <br />
        </div>
        <div>
            Gender:
            <asp:Label ID="genderTxt" runat="server" Text=""></asp:Label>
            <br />
        </div>
        <div>
            Phone Number:
            <asp:Label ID="phoneTxt" runat="server" Text=""></asp:Label>
            <br />
        </div>
        <div>
            Address:
            <asp:Label ID="addressTxt" runat="server" Text=""></asp:Label>
            <br />
        </div>

        <br />
        <br />

        <asp:Button ID="updateProfileBtn" runat="server" Text="Update Profile" OnClick="updateProfileBtn_Click" />
        <asp:Button ID="changePasswordBtn" runat="server" Text="Change Password" OnClick="changePasswordBtn_Click" />
    </form>
</body>
</html>
