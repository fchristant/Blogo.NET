<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminTagEditNew.aspx.cs" Inherits="Blogo.NET.View.Pages.Admin.AdminTagEditNew" MasterPageFile="~/View/Masters/Admin.Master" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    <div class="post">
        <asp:FormView ID="FormViewTag" runat="server" DataKeyNames="id" 
            DataSourceID="ObjectDataSourceTag" DefaultMode="Edit" Width="100%" 
            oniteminserted="FormViewTag_ItemInserted" 
            onitemupdated="FormViewTag_ItemUpdated" 
            onitemdeleted="FormViewTag_ItemDeleted">
            <EditItemTemplate>
            <h3>Edit tag</h3>
            <table style="width: 100%;">
               <tr valign="top">
                    <td width="100">
                    <strong>&nbsp;&nbsp;Tag *</strong></td>
                    <td>
                    <asp:TextBox ID="TagName" runat="server" Text='<%# Bind("tagname") %>' Columns="30" />
                    </td>
                    <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTag" runat="server" 
                    ErrorMessage="Tag is a required field!" ControlToValidate="TagName">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr valign="top">
                    <td>&nbsp;</td>
                    <td>
                   <asp:Button ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Save" CssClass="button" />
                        &nbsp;<asp:Button ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" onclick="CancelButton_Click" CssClass="button" />
                        &nbsp;<asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CssClass="button" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');" />    
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr valign="top"><td>&nbsp;</td><td>&nbsp;</td></tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ShowSummary="False" />
            </EditItemTemplate>
            <InsertItemTemplate>
               <h3>New tag</h3>
            <table style="width: 100%;">
               <tr valign="top">
                    <td width="100">
                    <strong>&nbsp;&nbsp;Tag *</strong></td>
                    <td>
                    <asp:TextBox ID="TagName" runat="server" Text='<%# Bind("tagname") %>' Columns="30" />
                    </td>
                    <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTag" runat="server" 
                    ErrorMessage="Tag is a required field!" ControlToValidate="TagName">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr valign="top">
                    <td>&nbsp;</td>
                    <td>
                   <asp:Button ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Save" CssClass="button" />
                        &nbsp;<asp:Button ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" onclick="CancelButton_Click" CssClass="button" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr valign="top"><td>&nbsp;</td><td>&nbsp;</td></tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ShowSummary="False" />
            </EditItemTemplate>
            </InsertItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="ObjectDataSourceTag" runat="server" 
            DataObjectTypeName="Blogo.NET.Business.Tag" DeleteMethod="Delete" 
            InsertMethod="Save" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetItem" TypeName="Blogo.NET.Business.TagManager" 
            UpdateMethod="Save">
            <SelectParameters>
                <asp:QueryStringParameter Name="id" QueryStringField="tag" Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
     </div>
    </form>
</asp:content>
