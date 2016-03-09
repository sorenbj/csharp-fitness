<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="HandIn3CS.ErrorPage" Theme="ThemeMyFitness" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="headertext">
        <br />
        <br />
        <br />
        <asp:Label ID="LabelError" runat="server" Text="You have to be logged in to see the content of the page"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonReturn" runat="server" OnClick="ButtonReturn_Click" Text="Go to Login" />
    &nbsp;
        <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="Home" />
    </div>
    </form>
</body>
</html>
