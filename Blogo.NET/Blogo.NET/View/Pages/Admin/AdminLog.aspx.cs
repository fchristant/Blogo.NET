using System;

using Blogo.NET.Business;

namespace Blogo.NET.View.Pages.Admin
{
    public partial class AdminLog : System.Web.UI.Page
    {

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            LogManager.DeleteAll();
            Response.Redirect("~/View/Pages/Admin/AdminLog.aspx");
        }
    }
}
