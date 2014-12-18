<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSetup.aspx.cs" Inherits="Blogo.NET.View.Pages.Admin.AdminSetup" MasterPageFile="~/View/Masters/Admin.Master" ValidateRequest="False" %>
<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3>Setup</h3>
    
    <table border="0" width="100%">
    
    <tr>
    <td width="250">Blog title</td>
    <td>
        <asp:TextBox ID="SetupBlogTitle" runat="server" Columns="50"></asp:TextBox></td>
    <td width="50" valign="top">
     <asp:RequiredFieldValidator ID="RequiredFieldValidatorBlogTitle" runat="server" 
                    ErrorMessage="Blog title is a required field!" ControlToValidate="SetupBlogTitle">*</asp:RequiredFieldValidator>
    </td>
    </tr>
    
    <tr>
    <td width="250" valign="top">Blog description (HTML)</td>
    <td>
        <asp:TextBox ID="SetupBlogDescription" runat="server" Columns="50" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
    <td width="50" valign="top">
     <asp:RequiredFieldValidator ID="RequiredFieldValidatorBlogDescription" runat="server" 
                    ErrorMessage="Blog description is a required field!" ControlToValidate="SetupBlogDescription">*</asp:RequiredFieldValidator>
    </td>
    </tr>
    
    <tr>
    <td>Root path</td>
    <td><asp:TextBox ID="SetupRootPath" runat="server" Columns="50"></asp:TextBox></td>
    <td valign="top">
     <asp:RequiredFieldValidator ID="RequiredFieldValidatorRootPath" runat="server" 
                    ErrorMessage="Root path is a required field!" ControlToValidate="SetupRootPath">*</asp:RequiredFieldValidator>
    </td>
    </tr>
    
    <tr>
    <td>RSS page size</td>
    <td><asp:TextBox ID="SetupRSSPageSize" runat="server" Columns="2"></asp:TextBox></td>
    <td valign="top">
     <asp:RequiredFieldValidator ID="RequiredFieldValidatorRSSPageSize" runat="server" 
                    ErrorMessage="RSS page size is  a required field!" ControlToValidate="SetupRSSPageSize">*</asp:RequiredFieldValidator>
    </td>
    </tr>
    
    <tr>
    <td>Max file upload size (bytes)</td>
    <td><asp:TextBox ID="SetupMaxFileSize" runat="server" Columns="10"></asp:TextBox></td>
    <td valign="top">
     <asp:RequiredFieldValidator ID="RequiredFieldValidatorMaxFileSize" runat="server" 
                    ErrorMessage="Max file uploade size is  a required field!" ControlToValidate="SetupMaxFileSize">*</asp:RequiredFieldValidator>
    </td>
    </tr>
    
    <tr>
    <td></td>
    <td>
        <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="button" 
            onclick="SaveButton_Click" />
        <asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="button" onclick="CancelButton_Click" CausesValidation="False" />
    </td>
    <td></td>
    </tr>
    
    </table>
    <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ShowSummary="False" />        
    
    </div>
    </form>
</asp:content>