<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="YourNamespace.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
</head>
<body>
    <form runat="server">
        <div>
            <h2>Login</h2>
            <label for="txtUsername">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br /><br />
            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            <br /><br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        </div>
    </form>
</body>
</html>
