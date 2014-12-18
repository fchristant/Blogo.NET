<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCommentEdit.aspx.cs" Inherits="Blogo.NET.View.Pages.CommentEdit" MasterPageFile="~/View/Masters/Admin.Master" ValidateRequest="False" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
    <h3>Edit comment</h3>
        <asp:FormView ID="FormViewComment" runat="server" 
            DataSourceID="ObjectDataSourceComment" DefaultMode="Edit" 
            EnableTheming="False" EnableViewState="False" DataKeyNames="id" 
            onitemdeleted="FormViewComment_ItemDeleted" >
            <EditItemTemplate>
            <table style="width: 100%;">
                <tr valign="top">
                    <td width="100">
                    <strong>&nbsp;&nbsp;Name *</strong></td>
                    <td>
                    <asp:TextBox ID="CommentName" runat="server" Text='<%# Bind("author") %>' Columns="30" />
                    </td>
                    <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
                    ErrorMessage="Name is a required field!" ControlToValidate="CommentName">*</asp:RequiredFieldValidator></td>
                    </tr>
                <tr valign="top">
                    <td width="100">
                    <strong>&nbsp;&nbsp;Comment *</strong></td>
                    <td>
                    <asp:TextBox ID="CommentBody" runat="server" Text='<%# Bind("body") %>' TextMode="MultiLine" Rows="10" Columns="50" />
                    </td>
                    <td>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidatorComment" runat="server" 
                    ErrorMessage="Comment is a required field!" ControlToValidate="CommentBody">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr valign="top">
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CssClass="button" Text="Save" onclick="UpdateButton_Click" />
                        &nbsp;<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CssClass="button" Text="Cancel" onclick="CancelButton_Click" />
                        &nbsp;<asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CssClass="button" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr valign="top"><td>&nbsp;</td><td>&nbsp;</td></tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" 
        ShowMessageBox="True" ShowSummary="False" />
            </EditItemTemplate>
            <EmptyDataTemplate>
            Invalid comment!
            </EmptyDataTemplate>
        </asp:FormView> 
        <asp:ObjectDataSource ID="ObjectDataSourceComment" runat="server" 
            DataObjectTypeName="Blogo.NET.Business.Comment" DeleteMethod="Delete" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetItem" 
            TypeName="Blogo.NET.Business.CommentManager">
            <SelectParameters>
                <asp:QueryStringParameter Name="id" QueryStringField="comment" Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</asp:content>