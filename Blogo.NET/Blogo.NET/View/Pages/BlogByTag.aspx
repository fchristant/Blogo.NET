<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlogByTag.aspx.cs" Inherits="Blogo.NET.View.Pages.BlogByTag" MasterPageFile="~/View/Masters/Page.Master" %>
<%@ Register src="../Controls/BlogList.ascx" tagname="BlogList" tagprefix="uc1" %>
<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3><asp:Label ID="lblTagName" runat="server"></asp:Label></h3>
    </div>
   <uc1:BlogList ID="BlogList" runat="server" />
    <asp:ObjectDataSource ID="ObjectDataSourceBlogs" runat="server" 
        MaximumRowsParameterName="PageSize" 
        OldValuesParameterFormatString="original_{0}" SelectCountMethod="CountTag" 
        SelectMethod="GetListTag" StartRowIndexParameterName="StartRow" 
        TypeName="Blogo.NET.Business.BlogEntryManager" EnablePaging="True" 
        EnableCaching="False" EnableViewState="False">
        <SelectParameters>
            <asp:QueryStringParameter Name="TagID" QueryStringField="tag" Type="Int32" />
            <asp:Parameter Name="StartRow" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="PageSize" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</form>
</asp:content>