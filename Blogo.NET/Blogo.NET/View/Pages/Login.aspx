<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Blogo.NET.View.Pages.Login" MasterPageFile="~/View/Masters/Site.Master" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPrimary" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3>Log in to access the administration panel</h3>
    <asp:Login ID="LoginBlogo" runat="server" MembershipProvider="BlogoMembershipProvider" DisplayRememberMe="False" RememberMeSet="False" FailureText="Invalid credentials. Please try again.">
        <LoginButtonStyle CssClass="button" />
    </asp:Login>
        <asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label>
    </div>
    </form>
</asp:content>
