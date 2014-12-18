<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLog.aspx.cs" Inherits="Blogo.NET.View.Pages.Admin.AdminLog" MasterPageFile="~/View/Masters/Admin.Master" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3>Manage log</h3>
    <p>
    <asp:Button ID="ButtonClear" runat="server" CssClass="button" 
            Text="Clear Log..." UseSubmitBehavior="True" OnClick="ButtonClear_Click" OnClientClick="return confirm('Are you sure you want to clear the entire log?');" 
            CausesValidation="False" />
    </p>
        <asp:GridView ID="GridViewLog" runat="server" 
            AutoGenerateColumns="False" DataSourceID="ObjectDataSourceLog" 
            PageSize="50" Width="100%" 
            CellPadding="5" BorderColor="#656551" GridLines="Horizontal" 
            AllowPaging="True" DataKeyNames="id">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    
                    DataNavigateUrlFormatString="~/View/Pages/Admin/AdminLogEntry.aspx?log={0}" 
                    DataTextField="date" HeaderText="Date" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="40px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#656551" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
        </asp:GridView>    
        <asp:ObjectDataSource ID="ObjectDataSourceLog" runat="server" 
            DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetList" TypeName="Blogo.NET.Business.LogManager" 
            DataObjectTypeName="Blogo.NET.Business.Log" UpdateMethod="Save">
            <SelectParameters>
                <asp:QueryStringParameter Name="StartRow" QueryStringField="page" 
                    Type="Int32" />
                <asp:Parameter DefaultValue="50" Name="PageSize" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</asp:content>