using System;

using Blogo.NET.Business;

namespace Blogo.NET.View.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if there is no user defined yet, notify the user
            if (AuthorManager.Count(0,10) < 1) {
                LoginBlogo.UserName = "admin";
                LabelMessage.Text = @"You have not yet defined a blog user. You can create new blog users from the 'manage users' option in the 
                administration panel. For now, you can use username: admin, password: admin to access the administration panel. Once you have created
                 a blog user, the admin account will automatically be disabled and the administration panel protected by your newly defined username 
                and password.";
            }
        }
    }
}
