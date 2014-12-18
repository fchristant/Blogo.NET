<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminFileNew.aspx.cs" Inherits="Blogo.NET.View.Pages.Admin.AdminFileNew" MasterPageFile="~/View/Masters/Admin.Master" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3>Upload new file (max <asp:Label ID="LabelMaxUpload" runat="server" Text="Label"></asp:Label> 
        bytes)</h3>
        <asp:FileUpload ID="FileUpload" runat="server" />&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorFile" runat="server" 
                    ErrorMessage="File is a required field!" ControlToValidate="FileUpload">*</asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button ID="ButtonUpload" runat="server" Text="Upload" CssClass="button" 
            onclick="ButtonUpload_Click" />&nbsp;
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="button" 
            onclick="ButtonCancel_Click" CausesValidation="False" />
            <asp:ValidationSummary ID="ValidationSummary" runat="server" 
        ShowMessageBox="True" ShowSummary="False" />
        <p><asp:Label ID="LabelError" runat="server" Text=""></asp:Label></p>
    </div>
    </form>
</asp:content>