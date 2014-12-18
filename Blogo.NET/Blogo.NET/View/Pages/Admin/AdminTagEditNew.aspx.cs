using System;
using System.Web.UI.WebControls;

namespace Blogo.NET.View.Pages.Admin
{
    public partial class AdminTagEditNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tag"] == null)
            {
                // new user form
                FormViewTag.DefaultMode = FormViewMode.Insert;
            }
            else
            {
                // edit user form
                FormViewTag.DefaultMode = FormViewMode.Edit;
            }

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/AdminTags.aspx");
        }

        protected void FormViewTag_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/AdminTags.aspx");
        }

        protected void FormViewTag_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/AdminTags.aspx");
        }

        protected void FormViewTag_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/AdminTags.aspx");
        }
    }
}
