<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Blogo.NET.View.Pages.Home" MasterPageFile="~/View/Masters/Page.Master" EnableViewState="False" %>
<%@ Register src="../Controls/BlogList.ascx" tagname="BlogList" tagprefix="uc1" %>
<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3><asp:Label id="lblTitle" runat="server"></asp:Label></h3>
    </div>
    <uc1:BlogList ID="BlogList" runat="server" />
    <asp:ObjectDataSource ID="ObjectDataSourceBlogs" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
        TypeName="Blogo.NET.Business.BlogEntryManager" EnablePaging="True" SelectCountMethod="Count" StartRowIndexParameterName="StartRow" MaximumRowsParameterName="PageSize" EnableCaching="False" EnableViewState="False">
        <SelectParameters>
            <asp:QueryStringParameter Name="StartRow" QueryStringField="page" 
                Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="PageSize" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</asp:content>