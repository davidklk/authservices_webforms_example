<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleWebformsApplication.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Sample Kentor Authservices Webforms Implementation</h2> <br />
    This is a very basic <a href="https://github.com/KentorIT/authservices">Kentor Authservices</a> implementation for webforms.<br />
    Full credit for the SSO goes to the Kentor team, I just made a simple translation of the MVC demo. <br />
    It only features log in and out functions. <br /><br />
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
