<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlogArticles.aspx.cs" Inherits="Blogo.NET.View.Pages.BlogArticles" MasterPageFile="~/View/Masters/Page.Master" %>
<%@ Register src="../Controls/BlogList.ascx" tagname="BlogList" tagprefix="uc1" %>
<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3>Articles</h3>
    </div>
   <uc1:BlogList ID="BlogList1" runat="server" />
    <asp:ObjectDataSource ID="ObjectDataSourceBlogs" runat="server" 
        MaximumRowsParameterName="PageSize" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetListType" 
        StartRowIndexParameterName="StartRow" 
        TypeName="Blogo.NET.Business.BlogEntryManager" EnablePaging="True" 
        EnableCaching="False" EnableViewState="False" SelectCountMethod="CountType">
        <SelectParameters>
            <asp:Parameter DefaultValue="article" Name="type" Type="Object" />
            <asp:Parameter DefaultValue="" Name="StartRow" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="PageSize" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</asp:content>