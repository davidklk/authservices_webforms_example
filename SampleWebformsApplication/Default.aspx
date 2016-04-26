<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleWebformsApplication.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      You are currently <asp:label id="status" runat="server"></asp:label>. <br /><br />
    <section runat="server" id="sctLoggedOut">
       <asp:HyperLink ID="SignInPageLink" Text="Sign In" Target="_self" runat="server"></asp:HyperLink>
    </section>
    <section runat="server" id="sctLoggedIn">
        <a href="Secured/Secured.aspx">Go to Secure Page</a> <br /><br />        
        Claims:<br />
        <asp:Label ID="lblClaims" runat="server"></asp:Label>
    </section>
</asp:Content>
