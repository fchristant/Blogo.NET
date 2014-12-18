<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminFiles.aspx.cs" Inherits="Blogo.NET.View.Pages.Admin.AdminFiles"
    MasterPageFile="~/View/Masters/Admin.Master" %>

<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolderPage"
    runat="server">
    <form id="form" runat="server">
    <div class="post">
        <h3>
            Manage files</h3>
        <p>
            <asp:Button ID="ButtonNew" runat="server" CssClass="button" 
                Text="Upload File..." UseSubmitBehavior="False" onclick="ButtonNew_Click" />
        </p>
        <asp:GridView ID="GridViewFiles" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="id" 
            DataSourceID="ObjectDataSourceFile" PageSize="50" Width="100%" CellPadding="5" BorderColor="#656551" GridLines="Horizontal">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="~/View/Pages/File.aspx?file={0}" 
                    DataTextField="filename" HeaderText="File" />
                <asp:BoundField DataField="mime" HeaderText="Mime type" SortExpression="mime">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="40px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#656551" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceFile" runat="server" 
            DataObjectTypeName="Blogo.NET.Business.File" DeleteMethod="Delete" 
            EnablePaging="True" MaximumRowsParameterName="PageSize" 
            OldValuesParameterFormatString="original_{0}" SelectCountMethod="Count" 
            SelectMethod="GetList" StartRowIndexParameterName="StartRow" 
            TypeName="Blogo.NET.Business.FileManager">
            <SelectParameters>
                <asp:QueryStringParameter Name="StartRow" QueryStringField="page" 
                    Type="Int32" />
                <asp:Parameter DefaultValue="50" Name="PageSize" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</asp:Content>
