<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogList.ascx.cs" Inherits="Blogo.NET.View.Controls.BlogList" %>

<asp:ListView ID="ListBlogs" runat="server" ConvertEmptyStringToNull="False" 
        DataSourceID="ObjectDataSourceBlogs" EnableViewState="False" 
        ItemPlaceholderID="itemContainer">
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
		<li class="comments">
            <%# (bool)Eval("allowcomments") ? "<a href=\"BlogEntry.aspx?page=" + Eval("id") + "#comments\">Comments (" + Eval("comments.count") + ")</a>" : "- disabled -" %></li>
        </ul>
        </div>
        </div>
        </ItemTemplate>
        <EmptyDataTemplate>
        <div class="post">
        <div class="header">
        <h3>No entries found</h3>
        </div>
        <div class="content">
        <p>No entries yet. You can create new blog entries from the <a href="~/View/Pages/Admin/Admin.aspx" id="linkAdmin" runat="server">admin panel</a>.</p>
        </div>
        </div>
        </EmptyDataTemplate>
</asp:ListView>
  <asp:DataPager ID="DataPager" runat="server" PagedControlID="ListBlogs" 
        PageSize="3" QueryStringField="page" EnableViewState="False">
        <Fields>
            <asp:NextPreviousPagerField FirstPageText="" LastPageText="" 
                NextPageText="Read more..." PreviousPageText="" 
                ShowPreviousPageButton="False" />
        </Fields>
    </asp:DataPager>