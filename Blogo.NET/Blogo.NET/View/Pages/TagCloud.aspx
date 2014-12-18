<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TagCloud.aspx.cs" Inherits="Blogo.NET.View.Pages.TagCloud" MasterPageFile="~/View/Masters/Page.Master" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3>Tag cloud</h3>
    </div>
    <asp:Label ID="LabelTagCloud" runat="server" Text=""></asp:Label>
    </form>
</asp:content>