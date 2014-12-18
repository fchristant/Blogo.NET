using System;
namespace Blogo.NET.View.Pages
{
    public partial class BlogByMonth : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // output month to the header label
            try
            {
                int year = int.Parse(Request.QueryString["year"]);
                int month = int.Parse(Request.QueryString["month"]);
                lblDate.Text = year + "-" + month;
            }
            catch (Exception)
            {
                lblDate.Text = "&nbsp;";
            }
        }
    }
}
