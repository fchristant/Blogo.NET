using System;

using Blogo.NET.Utils;

namespace Blogo.NET.View.Pages.Admin
{
    public partial class AdminSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // bind setup fields to values from web.config
                SetupBlogTitle.Text = BlogoSettings.BlogTitle;
                SetupBlogDescription.Text = BlogoSettings.BlogDescription;
                SetupRootPath.Text = BlogoSettings.RootPath;
                SetupRSSPageSize.Text = BlogoSettings.RSSPageSize.ToString();
                SetupMaxFileSize.Text = BlogoSettings.MaxFileSize.ToString();
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/Admin.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // save setup field values to web.config
            BlogoSettings.BlogTitle = SetupBlogTitle.Text;
            BlogoSettings.BlogDescription = SetupBlogDescription.Text;
            BlogoSettings.RootPath = SetupRootPath.Text;
            BlogoSettings.RSSPageSize = int.Parse(SetupRSSPageSize.Text);
            BlogoSettings.MaxFileSize = long.Parse(SetupMaxFileSize.Text);
            BlogoSettings.Save();
            Response.Redirect("~/View/Pages/Admin/Admin.aspx");
        }
    }
}
