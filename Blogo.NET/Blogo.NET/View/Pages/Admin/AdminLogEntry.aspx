<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogEntry.aspx.cs" Inherits="Blogo.NET.View.Pages.Admin.AdminLogentry" MasterPageFile="~/View/Masters/Admin.Master" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3>Log entry</h3>
        <asp:ListView ID="ListViewLogEntry" runat="server" 
            DataSourceID="ObjectDataSourceLogEntry" ItemPlaceholderID="itemContainer" 
            DataKeyNames="id" onitemdeleted="ListViewLogEntry_ItemDeleted">
            <LayoutTemplate> <asp:PlaceHolder ID="itemContainer" runat="server" /></LayoutTemplate>
         
           <ItemTemplate>
           <table width="100%">
           
           <tr><td>Date</td></tr>
           <tr><td><asp:Label ID="dateLabel" runat="server" Text='<%# Eval("date") %>' /></td></tr>
           
           <tr><td>Event</td></tr>
           <tr><td> <asp:TextBox ID="eventText" runat="server" Text='<%# Bind("event") %>' TextMode="MultiLine" Rows="30" Width="100%" /></td></tr>
           
           <tr><td>
           <asp:Button ID="ButtonClose" CssClass="button" runat="server" Text="Close" 
            onclick="ButtonClose_Click" />
               &nbsp;<asp:Button ID="ButtonDelete" CommandName="Delete" CssClass="button" runat="server" Text="Delete" 
            OnClientClick="return confirm('Are you sure you want to delete this record?');" />
           </td></tr>
           
           </table>
                   
            </ItemTemplate>   
           
            <EmptyDataTemplate>
                Invalid log entry!
            </EmptyDataTemplate>
         
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSourceLogEntry" runat="server" 
            DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetItem" TypeName="Blogo.NET.Business.LogManager" 
            DataObjectTypeName="Blogo.NET.Business.Log" UpdateMethod="Save">
            <SelectParameters>
                <asp:QueryStringParameter Name="id" QueryStringField="log" Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</asp:content>