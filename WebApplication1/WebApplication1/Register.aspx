<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="YourNamespace.Register" %>

<!DOCTYPE html>
<html>
<head>
    <title>Register</title>
</head>
<body>
    <form runat="server">
        <div>
            <h2>Register</h2>
            <label for="txtUsername">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br /><br />
            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
