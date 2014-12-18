using System;
using Blogo.NET.View.Pages;

namespace Blogo.NET.View.Controls
{
    public partial class BlogList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static string ImplodeTags(object param)
        {
            return PageBase.ImplodeTags(param);
        }
    }
}