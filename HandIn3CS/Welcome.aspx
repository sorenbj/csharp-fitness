<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="HandIn3CS.Welcome" Theme="ThemeMyFitness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">          
    <div>
        <p class="myUserlevel" >
        <asp:Label ID="LabelUserLevel" runat="server" EnableTheming="False"></asp:Label>
        </p>
        <br />
        <p class="toptext">Fitness Center Hall and Gym</p>
        <br />
        <asp:Image ID="Image1" runat="server" src="/images/image1.jpg" alt="Picture of center" style="width:300px;height:200px;" />
            &nbsp;&nbsp;
        <asp:Image ID="Image2" runat="server" src="/images/image2.jpg" alt="another Picture of center" style="width:300px;height:200px;" />
            &nbsp;&nbsp;
        <asp:Image ID="Image3" runat="server" src="/images/image3.jpg" alt="and another Picture of center" style="width:300px;height:200px;" />
        <br /> 
    </div>     
</asp:Content>
