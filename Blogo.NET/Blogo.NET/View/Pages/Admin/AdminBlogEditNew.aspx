<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminBlogEditNew.aspx.cs" Inherits="Blogo.NET.View.Pages.Admin.AdminBlogEditNew" MasterPageFile="~/View/Masters/Admin.Master" ValidateRequest="False" %>

<asp:content id="ContentPlaceHolder" contentplaceholderid="ContentPlaceHolderPage" runat="server">
    <form id="form" runat="server">
    
    <asp:ScriptManager ID="SMgr" runat="server">
    <Scripts>
        <asp:ScriptReference Path="~/View/Controls/tiny_mce/tiny_mce.js" />
    </Scripts>
    </asp:ScriptManager> 
    <script language="javascript" type="text/javascript">
    tinyMCE.init({
    mode : "exact",
    elements : "ctl00_ctl00_ContentPlaceHolderPrimary_ContentPlaceHolderPage_FormViewBlog_BlogBody",
    theme : "advanced",
    plugins : "table,fullscreen",
    apply_source_formatting : "true",
    theme_advanced_container_toolbar1_align : "left",
    theme_advanced_container_toolbar2_align : "left",
    theme_advanced_layout_manager : "RowLayout",
    theme_advanced_containers : "toolbar1,toolbar2,mceEditor",
    theme_advanced_container_toolbar1 :
        "bold,italic,underline,strikethrough,charmap,separator,"+
        "justifyleft,justifycenter,justifyright,justifyfull,"+
        "separator,bullist,numlist,indent,outdent,separator,"+
        "link,unlink,anchor,hr",
    theme_advanced_container_toolbar2 :
        "tablecontrols,separator,image,removeformat,code,|,fullscreen",
    theme_advanced_path : "false",
    relative_urls : "true",
    document_base_url : "<%= GetAppRoot() %>/View/Pages/",
    fullscreen_new_window : "true",
    external_image_list_url : "Admin/AdminImageList.aspx"
    })
    </script>
    
    <div class="post">
    <asp:FormView ID="FormViewBlog" runat="server" DataKeyNames="id" 
            DataSourceID="ObjectDataSourceBlog" DefaultMode="Edit" Width="100%" onitemdeleted="FormViewBlog_ItemDeleted" 
            oniteminserted="FormViewBlog_ItemInserted">
            <EditItemTemplate>
            <h3>Edit blog entry</h3>
            
            <table border="0" width="100%">
            
            <tr>
            <td valign="top">Author</td>
            <td><asp:DropDownList ID="BlogAuthor" runat="server" 
                    DataSourceID="ObjectDataSourceAuthor" DataTextField="username" 
                    DataValueField="id">
                </asp:DropDownList></td>
            <td valign="top">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAuthor" runat="server" 
                    ErrorMessage="Author is a required field!" ControlToValidate="BlogAuthor">*</asp:RequiredFieldValidator>
            </td>
            </tr>
            
            <tr>
            <td valign="top">Title</td>
            <td><asp:TextBox ID="BlogTitle" runat="server" Text='<%# Bind("title") %>' Columns="60" /></td>
            <td valign="top">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" 
                    ErrorMessage="Title is a required field!" ControlToValidate="Blogtitle">*</asp:RequiredFieldValidator>
            </td>
            </tr>
            
            <tr>
            <td valign="top">Description</td>
            <td><asp:TextBox ID="BlogDescription" runat="server" 
                    Text='<%# Bind("description") %>' Columns="60" Rows="3" TextMode="MultiLine" /></td>
            <td valign="top">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" runat="server" 
                    ErrorMessage="Description is a required field!" ControlToValidate="BlogDescription">*</asp:RequiredFieldValidator>
            </td>
            </tr>
            
            <tr>
            <td valign="top">Tags</td>
            <td><asp:CheckBoxList ID="BlogTags" runat="server" 
                    DataSourceID="ObjectDataSourceTag" DataTextField="tagname" 
                    DataValueField="id" RepeatLayout="Flow">
                </asp:CheckBoxList></td>
            <td valign="top">
            </td>
            </tr>
            
            <tr>
            <td valign="top">Type</td>
            <td><asp:RadioButtonList ID="BlogType" runat="server" 
                    SelectedValue='<%# Bind("type") %>' RepeatLayout="Flow">
                    <asp:ListItem Value="article">Article</asp:ListItem>
                    <asp:ListItem Value="blogentry">Blog entry</asp:ListItem>
                </asp:RadioButtonList></td>
            <td valign="top">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorType" runat="server" 
                    ErrorMessage="Type is a required field!" ControlToValidate="BlogType">*</asp:RequiredFieldValidator>
            </td>
            </tr>
            
            <tr>
            <td valign="top">Allow comments</td>
            <td>                <asp:CheckBox ID="BlogAllowComments" runat="server" 
                    Checked='<%# Bind("allowcomments") %>' /></td>
            <td valign="top"></td>
            </tr>
            
            <tr>
            <td valign="top">Mark private</td>
            <td><asp:CheckBox ID="BlogMarkPrivate" runat="server" 
                    Checked='<%# Bind("markprivate") %>' /></td>
            <td valign="top"></td>
            </tr>
            
            <tr>
            <td valign="top">Body</td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorBody" runat="server" 
                    ErrorMessage="Body is a required field!" ControlToValidate="BlogBody">*</asp:RequiredFieldValidator></td>
            <td></td>
            </tr>
            </table>
            
            <table width="100%" border="0">
            <tr>
            
            <td><asp:TextBox ID="BlogBody" runat="server" Text='<%# Bind("body") %>' 
                    TextMode="MultiLine" Rows="20" width="100%" /></td>
            </tr>
                                
            <tr>
            
            <td><asp:Button ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" CssClass="button" Text="Save" 
                    onclick="SaveButton_Click" OnClientClick="tinyMCE.triggerSave(false,false);" />
                &nbsp;<asp:Button ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" CssClass="button" 
                    Text="Cancel" onclick="CancelButton_Click" />
                    &nbsp;<asp:Button ID="DeleteButton" runat="server" CausesValidation="False" CssClass="button" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');" />    
                    </td>
            </tr>
                        
            </table>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ShowSummary="False" />        
         
            </EditItemTemplate>
            <InsertItemTemplate>
            <h3>New blog entry</h3>
            
            <table border="0" width="100%">
            
            <tr>
            <td valign="top">Author</td>
            <td><asp:DropDownList ID="BlogAuthor" runat="server" 
                    DataSourceID="ObjectDataSourceAuthor" DataTextField="username" 
                    DataValueField="id">
                </asp:DropDownList></td>
            <td valign="top">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAuthor" runat="server" 
                    ErrorMessage="Author is a required field!" ControlToValidate="BlogAuthor">*</asp:RequiredFieldValidator>
            </td>
            </tr>
            
            <tr>
            <td valign="top">Title</td>
            <td><asp:TextBox ID="BlogTitle" runat="server" Text='<%# Bind("title") %>' Columns="60" /></td>
            <td valign="top">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" 
                    ErrorMessage="Title is a required field!" ControlToValidate="Blogtitle">*</asp:RequiredFieldValidator>
            </td>
            </tr>
            
            <tr>
            <td valign="top">Description</td>
            <td><asp:TextBox ID="BlogDescription" runat="server" 
                    Text='<%# Bind("description") %>' Columns="60" Rows="3" TextMode="MultiLine" /></td>
            <td valign="top">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" runat="server" 
                    ErrorMessage="Description is a required field!" ControlToValidate="BlogDescription">*</asp:RequiredFieldValidator>
            </td>
            </tr>
            
            <tr>
            <td valign="top">Tags</td>
            <td><asp:CheckBoxList ID="BlogTags" runat="server" 
                    DataSourceID="ObjectDataSourceTag" DataTextField="tagname" 
                    DataValueField="id" RepeatLayout="Flow">
                </asp:CheckBoxList></td>
            <td valign="top">
            </td>
            </tr>
            
            <tr>
            <td valign="top">Type</td>
            <td><asp:RadioButtonList ID="BlogType" runat="server" RepeatLayout="Flow">
                    <asp:ListItem Value="article">Article</asp:ListItem>
                    <asp:ListItem Value="blogentry" Selected="True">Blog entry</asp:ListItem>
                </asp:RadioButtonList></td>
            <td valign="top">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorType" runat="server" 
                    ErrorMessage="Type is a required field!" ControlToValidate="BlogType">*</asp:RequiredFieldValidator>
            </td>
            </tr>
            
            <tr>
            <td valign="top">Allow comments</td>
            <td>                <asp:CheckBox ID="BlogAllowComments" runat="server" Checked="true" /></td>
            <td valign="top"></td>
            </tr>
            
            <tr>
            <td valign="top">Mark private</td>
            <td><asp:CheckBox ID="BlogMarkPrivate" runat="server" Checked="false" /></td>
            <td valign="top"></td>
            </tr>
            
            <tr>
            <td valign="top">Body</td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorBody" runat="server" 
                    ErrorMessage="Body is a required field!" ControlToValidate="BlogBody">*</asp:RequiredFieldValidator></td>
            <td></td>
            </tr>
            </table>
            
            <table width="100%" border="0">
            <tr>
            <td><asp:TextBox ID="BlogBody" runat="server" Text='<%# Bind("body") %>' 
                    TextMode="MultiLine" Rows="20" Width="100%" /></td>
            </tr>
            
            <tr>
            <td><asp:Button ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" CssClass="button" Text="Save" 
                    onclick="SaveButton_Click" OnClientClick="tinyMCE.triggerSave(false,false);" />
                &nbsp;<asp:Button ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" CssClass="button" 
                    Text="Cancel" onclick="CancelButton_Click" />                    
            </td>
            </tr>
            </table>
            
            <asp:ValidationSummary ID="ValidationSummary" runat="server" ShowMessageBox="True" ShowSummary="False" />        
            </InsertItemTemplate>
    </asp:FormView>   
      <asp:ObjectDataSource ID="ObjectDataSourceBlog" runat="server" 
            DataObjectTypeName="Blogo.NET.Business.BlogEntry" DeleteMethod="Delete" 
            InsertMethod="Save" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetItem" TypeName="Blogo.NET.Business.BlogEntryManager" 
            UpdateMethod="Save">
            <SelectParameters>
                <asp:QueryStringParameter Name="id" QueryStringField="page" Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceAuthor" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
            TypeName="Blogo.NET.Business.AuthorManager"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceTag" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetList" 
            TypeName="Blogo.NET.Business.TagManager"></asp:ObjectDataSource>
    </div>
    </form>
    <br />
</asp:content>