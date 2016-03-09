<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayAdmin.aspx.cs" Inherits="HandIn3CS.DisplayAdmin" Theme="ThemeMyFitness" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>    
        <p class="myUserlevel" >
                <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label>
            </p>
        <p class="toptext">Administrators</p>
        <br />
        <asp:ListBox ID="ListBoxDisplay" runat="server" Width="850px" AutoPostBack="True" Height="175px"></asp:ListBox>
        <br />
        <asp:Button ID="ButtonCreate" runat="server" OnClick="ButtonCreate_Click" Text="Create" Width="77px" />
        &nbsp;
        <asp:Button ID="ButtonRead" runat="server" OnClick="ButtonRead_Click" Text="Display" />
        &nbsp;
        <asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Update" />
        &nbsp;
        <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Delete" />
        &nbsp;
        <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Save" Width="75px" />
        &nbsp;
        <asp:Button ID="ButtonShowAll" runat="server" OnClick="ButtonShowAll_Click" Text="All employees" />
        <asp:Button ID="ButtonHide" runat="server" OnClick="ButtonHide_Click" Text="Hide employees" />
        <br />
        <br />
        <asp:ListBox ID="ListBoxAll" runat="server" Height="200px" Visible="False" Width="850px"></asp:ListBox>
        <br />
        <asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
        <br />
    </div>
</asp:Content>
