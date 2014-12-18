<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAuthors.aspx.cs" Inherits="Blogo.NET.View.Pages.Admin.AdminUsers" MasterPageFile="~/View/Masters/Admin.Master" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3>Manage users</h3>
    <p>
    <asp:Button ID="ButtonNew" runat="server" CssClass="button" 
            Text="New User..." UseSubmitBehavior="False" onclick="ButtonNew_Click" />
    </p>
        <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="id" DataSourceID="ObjectDataSourceUsers" PageSize="50" Width="100%" 
            CellPadding="5" BorderColor="#656551" GridLines="Horizontal" 
            AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="Username" 
                    SortExpression="username">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle VerticalAlign="Top" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="~/View/Pages/Admin/AdminAuthorEditNew.aspx?user={0}" Text="Edit">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="40px" />
                </asp:HyperLinkField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDelete" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="40px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#656551" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceUsers" runat="server" 
            DataObjectTypeName="Blogo.NET.Business.Author" DeleteMethod="Delete" 
            EnablePaging="True" EnableViewState="False" MaximumRowsParameterName="PageSize" 
            OldValuesParameterFormatString="original_{0}" SelectCountMethod="Count" 
            SelectMethod="GetList" StartRowIndexParameterName="StartRow" 
            TypeName="Blogo.NET.Business.AuthorManager">
            <SelectParameters>
                <asp:QueryStringParameter Name="StartRow" QueryStringField="page" 
                    Type="Int32" />
                <asp:Parameter DefaultValue="50" Name="PageSize" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</asp:content>