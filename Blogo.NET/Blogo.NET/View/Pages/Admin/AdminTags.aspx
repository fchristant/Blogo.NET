<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminTags.aspx.cs" Inherits="Blogo.NET.View.Pages.Admin.AdminTags" MasterPageFile="~/View/Masters/Admin.Master" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3>Manage tags</h3>
    <p>
    <asp:Button ID="ButtonNew" runat="server" CssClass="button" 
            Text="New Tag..." UseSubmitBehavior="False" onclick="ButtonNew_Click" />
    </p>
        <asp:GridView ID="GridViewTags" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="id" 
            DataSourceID="ObjectDataSourceTags" PageSize="50" Width="100%" 
            CellPadding="5" BorderColor="#656551" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="tagname" HeaderText="Tag" SortExpression="tagname">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="~/View/Pages/Admin/AdminTagEditNew.aspx?tag={0}" 
                    Text="Edit">
                    <HeaderStyle Width="40px" />
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
        <asp:ObjectDataSource ID="ObjectDataSourceTags" runat="server" 
            DataObjectTypeName="Blogo.NET.Business.Tag" DeleteMethod="Delete" 
            EnablePaging="True" EnableViewState="False" InsertMethod="Save" 
            MaximumRowsParameterName="PageSize" 
            OldValuesParameterFormatString="original_{0}" SelectCountMethod="Count" 
            SelectMethod="GetList" StartRowIndexParameterName="StartRow" 
            TypeName="Blogo.NET.Business.TagManager" UpdateMethod="Save">
            <SelectParameters>
                <asp:QueryStringParameter Name="StartRow" QueryStringField="page" 
                    Type="Int32" />
                <asp:Parameter DefaultValue="50" Name="PageSize" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</asp:content>