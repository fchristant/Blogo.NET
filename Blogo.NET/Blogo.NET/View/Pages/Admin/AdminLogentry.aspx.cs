using System;

using Blogo.NET.Business;

namespace Blogo.NET.View.Pages.Admin
{
    public partial class AdminLogentry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/AdminLog.aspx");
        }

        protected void ListViewLogEntry_ItemDeleted(object sender, System.Web.UI.WebControls.ListViewDeletedEventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/AdminLog.aspx");
        }
    }
}
