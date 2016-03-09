<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HandIn3CS.Login" Theme="ThemeMyFitness" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
        <p class="toptext">Please enter your login information</p>
        <table class="myTable">  
            <tr>
                <td class="myTableContCol1">
                    <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
                </td>
                <td class="myTableContCol2">
                    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                    <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="myTableContCol2">
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                    &nbsp;</td>
                <td class="myTableContCol2">
                    <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" />
                    &nbsp;
                    <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="LabelMessage" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
        </div> 
    </form>
</body>
</html>
