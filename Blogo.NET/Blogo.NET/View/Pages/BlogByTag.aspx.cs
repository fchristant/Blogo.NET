using System;
using Blogo.NET.Business;

namespace Blogo.NET.View.Pages
{
    public partial class BlogByTag : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get tag id from querystring, retrieve the associated
            // tag object and display the tagname property in the
            // header label
            try
            {
                long tagID = long.Parse(Request.QueryString["tag"]);
                Tag t = TagManager.GetItem(tagID);
                lblTagName.Text = t.tagname;
            }
            catch (Exception)
            {
                lblTagName.Text = "&nbsp;";
            }
        }
    }
}
