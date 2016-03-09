<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateCoach.aspx.cs" Inherits="HandIn3CS.CreateCoach" Theme="ThemeMyFitness" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p class="myUserlevel" >
                <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label>
            </p>
        <p class="toptext">Create a new coach</p>
        <table class="myTable">
            <tr>
                <td class="myTableContCol1">
                    <asp:Label ID="LabelStaffNumber" runat="server" Text="Staffnumber"></asp:Label>
                </td>
                <td class="myTableContCol2">
                    <asp:TextBox ID="TextBoxStaffNumber" runat="server" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                    <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="myTableContCol2">
                    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                    <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
                </td>
                <td class="myTableContCol2">
                    <asp:TextBox ID="TextBoxGender" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="myTableContCol1">
                    <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="myTableContCol2">
                    <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
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
                    <asp:Label ID="LabelClass" runat="server" Text="Event Type"></asp:Label>
                </td>
                <td class="myTableContCol2">
                    <asp:TextBox ID="TextBoxEvent" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Button ID="ButtonCreate" runat="server" OnClick="ButtonCreate_Click" Text="Submit" />
&nbsp;&nbsp;<asp:Button ID="ButtonCancel" runat="server" OnClick="ButtonCancel_Click" Text="Cancel" />
        <br />
        <br />
        <asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
        <br />    
    </div>
</asp:Content>
