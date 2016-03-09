<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayCoach.aspx.cs" Inherits="HandIn3CS.DisplayCoach" Theme="ThemeMyFitness" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p class="myUserlevel" >
        <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label>
        </p>
        <p class="toptext">Coaches</p>
        <br />
        <asp:ListBox ID="ListBoxDisplay" runat="server" Height="175px" Width="850px" OnSelectedIndexChanged="ListBoxDisplay_SelectedIndexChanged">
        </asp:ListBox>
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
        <br />
        <br />
        <asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
        <br />
    </div>
</asp:Content>
    
