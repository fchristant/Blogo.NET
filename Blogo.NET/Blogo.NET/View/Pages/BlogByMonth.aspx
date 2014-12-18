<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlogByMonth.aspx.cs" Inherits="Blogo.NET.View.Pages.BlogByMonth" MasterPageFile="~/View/Masters/Page.Master" %>
<%@ Register src="../Controls/BlogList.ascx" tagname="BlogList" tagprefix="uc1" %>
<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3><asp:Label ID="lblDate" runat="server"></asp:Label></h3>
    </div>
    <uc1:BlogList ID="BlogList" runat="server" />
    <asp:ObjectDataSource ID="ObjectDataSourceBlogs" runat="server" 
        EnableCaching="False" EnablePaging="True" EnableViewState="False" 
        MaximumRowsParameterName="PageSize" 
        OldValuesParameterFormatString="original_{0}" SelectCountMethod="CountMonth" 
        SelectMethod="GetListMonth" StartRowIndexParameterName="StartRow" 
        TypeName="Blogo.NET.Business.BlogEntryManager">
        <SelectParameters>
            <asp:QueryStringParameter Name="year" QueryStringField="year" Type="Int32" />
            <asp:QueryStringParameter Name="month" QueryStringField="month" Type="Int32" />
            <asp:QueryStringParameter Name="StartRow" QueryStringField="page" 
                Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="PageSize" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</asp:content>