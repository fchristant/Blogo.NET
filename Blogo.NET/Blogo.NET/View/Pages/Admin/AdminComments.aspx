<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminComments.aspx.cs" Inherits="Blogo.NET.View.Pages.Admin.AdminComments" MasterPageFile="~/View/Masters/Admin.Master" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3>Manage comments</h3>
        <asp:GridView ID="GridViewComments" runat="server" 
            DataSourceID="ObjectDataSourceComments" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="id" PageSize="50" 
            Width="100%" CellPadding="5" BorderColor="#656551" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="datecreated" HeaderText="Date" 
                    SortExpression="datecreated" DataFormatString="{0: yyyy-MM-dd}">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle VerticalAlign="Top" Width="80px" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="blog_id,id" 
                    DataNavigateUrlFormatString="~/View/Pages/BlogEntry.aspx?page={0}#{1}" 
                    DataTextField="author" HeaderText="Author">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle VerticalAlign="Top" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="IP" HeaderText="IP" SortExpression="IP">
                    <HeaderStyle VerticalAlign="Top" HorizontalAlign="Left" />
                    <ItemStyle VerticalAlign="Top" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="~/View/Pages/Admin/AdminCommentEdit.aspx?comment={0}" 
                    Text="Edit" >
                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                </asp:HyperLinkField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDelete" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#656551" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceComments" runat="server" 
            DataObjectTypeName="Blogo.NET.Business.Comment" DeleteMethod="Delete" 
            EnablePaging="True" EnableViewState="False" MaximumRowsParameterName="PageSize" 
            OldValuesParameterFormatString="original_{0}" SelectCountMethod="Count" 
            SelectMethod="GetList" StartRowIndexParameterName="StartRow" 
            TypeName="Blogo.NET.Business.CommentManager">
            <SelectParameters>
                <asp:QueryStringParameter Name="StartRow" QueryStringField="page" 
                    Type="Int32" />
                <asp:Parameter DefaultValue="50" Name="PageSize" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</asp:content>
