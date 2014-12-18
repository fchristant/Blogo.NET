using System;

using Blogo.NET.Utils;

namespace Blogo.NET.View.Masters
{
    public partial class Page : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelBlogDescription.Text = BlogoSettings.BlogDescription;
        }
    }
}
