using System;

using Blogo.NET.Business;

namespace Blogo.NET.View.Pages
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // log the error in the database
                Log l = new Log();
                l.date = System.DateTime.Now;
                l.@event = Server.GetLastError().ToString();
                LogManager.Save(l);
                Server.ClearError();
            }
            catch (Exception)
            {
                // an error occured during the error handling. don't do anything,
                // otherwise we will end up in an endless loop!
            }
        }
    }
}
