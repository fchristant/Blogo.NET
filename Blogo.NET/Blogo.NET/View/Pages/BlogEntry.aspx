<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlogEntry.aspx.cs" Inherits="Blogo.NET.View.Pages.BlogEntry" MasterPageFile="~/View/Masters/Page.Master" ValidateRequest="false" EnableViewState="False" %>
<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    
    <script language="javascript" type="text/javascript">
        document.write("<input type=\"hidden\" name=\"comHash\" value=\"" + Math.floor(Math.random()*1000) + "\">");
    </script>
    
    <asp:ListView ID="ListViewBlogEntry" runat="server" 
        DataSourceID="ObjectDataSourceBlogEntry" EnableTheming="False" 
        EnableViewState="False" ItemPlaceholderID="itemContainer">
         <LayoutTemplate>
        <asp:PlaceHolder ID="itemContainer" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
        <div class="post">
        <div class="header">
        <h3><a href="BlogEntry.aspx?page=<%# Eval("id") %>"><%# Eval("title") %></a></h3>
        <div class="date"><%# Eval("datepublished", "{0: MMMM dd, yyyy | hh:mm}")%></div>
        </div>
        <div class="content">
        <p>
        <%# Eval("body") %>
        <p><strong><%# Eval("author.username") %></strong></p>
        </p>
        </div>
        <div class="footer">
        <ul>
        <li class="tags">Tags: <%# ImplodeTags(Eval("tags")) %></li>
        </ul>
        </div>
        </div>
        </ItemTemplate>
        <EmptyDataTemplate>
        <div class="post">
        <div class="header">
        <h3>Invalid blog entry identifier!</h3>
        </div>
        <div class="content">
        <p>The id is not a known blog entry.</p>
        </div>
        </div>
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="ObjectDataSourceBlogEntry" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetItem" 
        TypeName="Blogo.NET.Business.BlogEntryManager" EnableCaching="False" 
        EnableViewState="False">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="page" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ListView ID="ListComments" runat="server" 
        DataSourceID="ObjectDataSourceComments" EnableTheming="False" 
        EnableViewState="False" ItemPlaceholderID="itemContainer">
         <LayoutTemplate>
         <a name="comments"><h4>Comments</h4></a>
        <asp:PlaceHolder ID="itemContainer" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
        <a name="<%# Eval("id") %>"></a>
        <div class="post">
        <div class="content">
        <p>
        <%# Eval("body") %>
        </p>
        </div>
        <div class="footer">
        <ul>
        <li class="comment">Comment by <strong><%# Eval("author") %></strong></li>
        </ul>
        <div class="date"><%# Eval("datecreated", "{0: MMMM dd, yyyy | hh:mm}") %></div>
        </div>
        </div>
        </ItemTemplate>
        <EmptyDataTemplate>
        <div class="post">
        <div class="header">
        <a name="comments"><h3>No comments yet!</h3></a>
        </div>
        </div>
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="ObjectDataSourceComments" runat="server" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetList" TypeName="Blogo.NET.Business.CommentManager">
        <SelectParameters>
            <asp:QueryStringParameter Name="parent_id" QueryStringField="page" 
                Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:PlaceHolder ID="PlaceHolderNewComment" runat="server" EnableTheming="False" EnableViewState="False">
    <fieldset>
    <legend>&nbsp;&nbsp;New comment&nbsp;&nbsp;</legend>
    <table style="width: 100%;">
    <tr valign="top"><td>&nbsp;</td><td>&nbsp;</td></tr>
        <tr valign="top">
            <td width="100">
                <strong>&nbsp;&nbsp;Name *</strong></td>
            <td>
                <asp:TextBox ID="CommentName" Columns="30" runat="server" 
                    EnableViewState="False"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
                    ErrorMessage="Name is a required field!" ControlToValidate="CommentName">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr valign="top">
            <td width="100">
                <strong>&nbsp;&nbsp;Comment *</strong></td>
            <td>
                <asp:TextBox ID="CommentBody" runat="server" Rows="10" Columns="50" 
                    TextMode="MultiLine" EnableViewState="False" ></asp:TextBox>
            </td>
             <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorComment" runat="server" 
                    ErrorMessage="Comment is a required field!" ControlToValidate="CommentBody">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr valign="top">
            <td>
                &nbsp;
            </td>
            <td>HTML is <strong>not</strong> allowed.<br />
                <asp:Button ID="ButtonSubmit" runat="server" CssClass="button" Text="Submit" 
                    onclick="ButtonSubmit_Click" />
                <asp:Button ID="ButtonCancel" runat="server" CssClass="button" Text="Cancel" 
                    OnClientClick="aspnetForm.reset();return false;" />
            </td>
           <td>&nbsp;</td>
        </tr>
    <tr valign="top"><td>&nbsp;</td><td>&nbsp;</td></tr>
    </table>
    </fieldset>
    <asp:ValidationSummary ID="ValidationSummary" runat="server" 
        ShowMessageBox="True" ShowSummary="False" />
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolderNoComments" runat="server" EnableTheming="False" EnableViewState="False" Visible="False">
    <h4>- Comments are disabled for this blog entry -</h4>
    </asp:PlaceHolder>
    </form>
</asp:content>
