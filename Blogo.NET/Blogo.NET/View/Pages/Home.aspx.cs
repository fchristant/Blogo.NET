using System;
using Blogo.NET.Utils;

namespace Blogo.NET.View.Pages
{
    public partial class Home : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // set the blog title from the web.config setting
            lblTitle.Text = BlogoSettings.BlogTitle;
        }
    }
}
