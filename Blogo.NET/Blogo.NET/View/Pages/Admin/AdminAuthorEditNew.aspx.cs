using System;
using System.Web.UI.WebControls;

using Blogo.NET.Business;

namespace Blogo.NET.View.Pages.Admin
{
    public partial class AdminAuthorEditNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["user"] == null)
            {
                // new user form
                FormViewAuthor.DefaultMode = FormViewMode.Insert;
            }
            else
            {
                // edit user form
                FormViewAuthor.DefaultMode = FormViewMode.Edit;
            }

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            // create new author object if this is a new user, retrieve existing author object if one is being edited
            Author author = null;
            if (Request.QueryString["user"] == null)
            {
                // new user
                author = new Author();
            }
            else
            {
                // edit user
                author = AuthorManager.GetItem(long.Parse(Request.QueryString["user"].ToString()));
            }

            TextBox tbName = (TextBox)FormViewAuthor.FindControl("AuthorUserName");
            author.username = tbName.Text;

            TextBox tbPassword = (TextBox)FormViewAuthor.FindControl("AuthorPassword");
            author.password = tbPassword.Text;

            AuthorManager.Save(author);
            Response.Redirect("~/View/Pages/Admin/AdminAuthors.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/AdminAuthors.aspx");
        }

    }
}
