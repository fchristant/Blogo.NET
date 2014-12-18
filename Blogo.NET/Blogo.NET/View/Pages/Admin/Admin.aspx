<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Blogo.NET.View.Pages.Admin.Admin" MasterPageFile="~/View/Masters/Admin.Master" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3>Manage blog entries</h3>
    <p>
    <asp:Button ID="ButtonNew" runat="server" CssClass="button" 
            Text="New Blog entry..." UseSubmitBehavior="False" 
            onclick="ButtonNew_Click" />
    </p>
        <asp:GridView ID="GridViewBlogs" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataSourceID="ObjectDataSourceBlogs" 
            DataKeyNames="id" PageSize="50" Width="100%" CellPadding="5" 
            BorderColor="#656551" GridLines="Horizontal">
            <RowStyle Wrap="True" VerticalAlign="Top" />
            <Columns>
                <asp:BoundField DataField="datepublished" HeaderText="Date" 
                    SortExpression="datepublished" 
                    DataFormatString="{0: yyyy-MM-dd}" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="80px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="~/View/Pages/BlogEntry.aspx?page={0}" 
                    DataTextField="title" HeaderText="Title" >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:HyperLinkField>
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="~/View/Pages/Admin/AdminBlogEditNew.aspx?page={0}" >
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDelete" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#656551" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceBlogs" runat="server" 
            DataObjectTypeName="Blogo.NET.Business.BlogEntry" DeleteMethod="Delete" 
            InsertMethod="Save" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetListAll" TypeName="Blogo.NET.Business.BlogEntryManager" 
            UpdateMethod="Save" EnablePaging="True" 
            MaximumRowsParameterName="PageSize" SelectCountMethod="CountAll" 
            StartRowIndexParameterName="StartRow" EnableViewState="False">
            <SelectParameters>
                <asp:QueryStringParameter Name="StartRow" QueryStringField="page" 
                    Type="Int32" />
                <asp:Parameter DefaultValue="50" Name="PageSize" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</asp:content>


