using System;
using System.Web.UI.WebControls;
using System.Web.Security;

using Blogo.NET.Business;

namespace Blogo.NET.View.Pages.Admin
{
    public partial class AdminBlogEditNew : System.Web.UI.Page
    {

        protected string GetAppRoot()
        {
            // returns the root path of the application
            string path = Request.ApplicationPath;
            return (path.EndsWith("/") ? "" : path);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                if (Request.QueryString["page"] == null)
                {
                    // new user form
                    FormViewBlog.DefaultMode = FormViewMode.Insert;
                    // set current user as author
                    DropDownList ddlAuthor = (DropDownList)FormViewBlog.FindControl("BlogAuthor");
                    Author tempAuthor = AuthorManager.GetItem(User.Identity.Name);
                    if (tempAuthor != null)
                        ddlAuthor.SelectedValue = tempAuthor.id.ToString();
                }
                else
                {
                    // edit user form
                    FormViewBlog.DefaultMode = FormViewMode.Edit;

                    // pre-select author and tags
                    Blogo.NET.Business.BlogEntry blogentry = BlogEntryManager.GetItem(long.Parse(Request.QueryString["page"].ToString()));

                    DropDownList ddlAuthor = (DropDownList)FormViewBlog.FindControl("BlogAuthor");
                    if (blogentry.author != null)
                        ddlAuthor.SelectedValue = blogentry.author.id.ToString();

                    CheckBoxList cblTags = (CheckBoxList)FormViewBlog.FindControl("BlogTags");
                    foreach (Tag t in blogentry.tags)
                    {
                        ListItem currentTag = cblTags.Items.FindByValue(t.id.ToString());
                        if (currentTag != null)
                        {
                            currentTag.Selected = true;
                        }
                    }
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // create new blog object if this is a new user, retrieve existing blog object if one is being edited
            Blogo.NET.Business.BlogEntry blogentry = null;
            if (Request.QueryString["page"] == null)
            {
                // new user
                blogentry = new Blogo.NET.Business.BlogEntry();
                blogentry.datecreated = System.DateTime.Now;
                blogentry.datepublished = System.DateTime.Now;
            }
            else
            {
                // edit user
                blogentry = BlogEntryManager.GetItem(long.Parse(Request.QueryString["page"].ToString()));
            }

            // build up blog entry object
            DropDownList ddlAuthor = (DropDownList)FormViewBlog.FindControl("BlogAuthor");
            ListItem liAuthor = ddlAuthor.SelectedItem;
            blogentry.author = AuthorManager.GetItem(long.Parse(liAuthor.Value));

            TextBox tbTitle = (TextBox)FormViewBlog.FindControl("BlogTitle");
            blogentry.title = tbTitle.Text;

            TextBox tbDescription = (TextBox)FormViewBlog.FindControl("BlogDescription");
            blogentry.description = tbDescription.Text;

            CheckBoxList cblTags = (CheckBoxList)FormViewBlog.FindControl("BlogTags");
            ListItemCollection licTags = cblTags.Items;
            blogentry.tags.Clear();
            foreach (ListItem liTag in licTags) {
                if (liTag.Selected)
                {
                    Tag t = new Tag();
                    t.id = long.Parse(liTag.Value);
                    t.tagname = liTag.Text;
                    blogentry.tags.Add(t);
                }
            }

            RadioButtonList rblTyp = (RadioButtonList)FormViewBlog.FindControl("BlogType");
            ListItem liType = rblTyp.SelectedItem;
            blogentry.type = (liType.Text.Equals(Types.article.ToString(),StringComparison.CurrentCultureIgnoreCase) ? Types.article : Types.blogentry);

            CheckBox cbAllowComments = (CheckBox)FormViewBlog.FindControl("BlogAllowComments");
            blogentry.allowcomments = cbAllowComments.Checked;

            CheckBox cbMarkPrivate = (CheckBox)FormViewBlog.FindControl("BlogMarkPrivate");
            blogentry.markprivate = cbMarkPrivate.Checked;

            TextBox tbBody = (TextBox)FormViewBlog.FindControl("BlogBody");
            blogentry.body = tbBody.Text;

            blogentry.datemodified = System.DateTime.Now;

            // save blog entry to the database
            BlogEntryManager.Save(blogentry);
            Response.Redirect("~/View/Pages/Admin/Admin.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/Admin.aspx");
        }

        protected void FormViewBlog_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/Admin.aspx");
        }

        protected void FormViewBlog_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/Admin.aspx");
        }

    }
}
