<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAuthorEditNew.aspx.cs" Inherits="Blogo.NET.View.Pages.Admin.AdminAuthorEditNew" MasterPageFile="~/View/Masters/Admin.Master" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
        <asp:FormView ID="FormViewAuthor" runat="server" DataKeyNames="id" 
            DataSourceID="ObjectDataSourceAuthor" DefaultMode="Edit" Width="100%" >
            <EditItemTemplate>
            <h3>Edit user</h3>
            <table style="width: 100%;">
                <tr valign="top">
                    <td width="100">
                    <strong>&nbsp;&nbsp;Username *</strong></td>
                    <td>
                    <asp:TextBox ID="AuthorUserName" runat="server" Text='<%# Bind("username") %>' Columns="30" />
                    </td>
                    <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" 
                    ErrorMessage="Username is a required field!" ControlToValidate="AuthorUserName">*</asp:RequiredFieldValidator></td>
                    </tr>
                <tr valign="top">
                    <td width="100">
                    <strong>&nbsp;&nbsp;Password *</strong></td>
                    <td>
                    <asp:TextBox ID="AuthorPassword" runat="server" Text='<%# Bind("password") %>' TextMode="Password" Columns="30" />
                    </td>
                    <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" 
                    ErrorMessage="Password is a required field!" ControlToValidate="AuthorPassword">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr valign="top">
                    <td>&nbsp;</td>
                    <td>
                    <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" 
                    CssClass="button" Text="Save" onclick="ButtonSave_Click" UseSubmitBehavior="False" />
                    &nbsp;<asp:Button ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CssClass="button" Text="Cancel" 
                    onclick="CancelButton_Click" UseSubmitBehavior="False" />
                    &nbsp;<asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CssClass="button" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');" />    
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr valign="top"><td>&nbsp;</td><td>&nbsp;</td></tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ShowSummary="False" />
            </EditItemTemplate>
            <EmptyDataTemplate>
            <h3>Edit user</h3>
            Invalid user!
            </EmptyDataTemplate>
            <InsertItemTemplate>
            <h3>New user</h3>
             <table style="width: 100%;">
                <tr valign="top">
                    <td width="100">
                    <strong>&nbsp;&nbsp;Username *</strong></td>
                    <td>
                     <asp:TextBox ID="AuthorUserName" runat="server" Text='<%# Bind("username") %>' Columns="30" />
                    </td>
                    <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" 
                    ErrorMessage="Username is a required field!" ControlToValidate="AuthorUserName">*</asp:RequiredFieldValidator></td>
                    </tr>
                <tr valign="top">
                    <td width="100">
                    <strong>&nbsp;&nbsp;Password *</strong></td>
                    <td>
                     <asp:TextBox ID="AuthorPassword" runat="server" Text='<%# Bind("password") %>' Columns="30" TextMode="Password" />
                    </td>
                    <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" 
                    ErrorMessage="Password is a required field!" ControlToValidate="AuthorPassword">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr valign="top">
                    <td>&nbsp;</td>
                    <td>
                    <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CssClass="button" Text="Save" onclick="ButtonSave_Click" UseSubmitBehavior="False" />
                    &nbsp;<asp:Button ID="InsertCancelButton" runat="server" CausesValidation="False" CssClass="button" Text="Cancel" onclick="CancelButton_Click" UseSubmitBehavior="False" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr valign="top"><td>&nbsp;</td><td>&nbsp;</td></tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ShowSummary="False" />
            </InsertItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="ObjectDataSourceAuthor" runat="server" 
            DataObjectTypeName="Blogo.NET.Business.Author" DeleteMethod="Delete" 
            InsertMethod="Save" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetItem" TypeName="Blogo.NET.Business.AuthorManager" 
            UpdateMethod="Save">
            <SelectParameters>
                <asp:QueryStringParameter Name="id" QueryStringField="user" Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</asp:content>