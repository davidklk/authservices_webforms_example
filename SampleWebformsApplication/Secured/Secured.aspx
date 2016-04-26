<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Secured.aspx.cs" Inherits="SampleWebformsApplication.Secured.Secured" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Secure.</h2><br />
    This is a secure page that only works when logged in -  <asp:HyperLink ID="LogOutPageLink" Text="Log Out" Target="_self" runat="server"></asp:HyperLink><br /><br />
    Claims: <br />
    <asp:Label ID="lblClaims" runat="server"></asp:Label>
</asp:Content>
