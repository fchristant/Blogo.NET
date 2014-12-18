using System;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

using Blogo.NET.Business;

namespace Blogo.NET.View.Pages
{
    public partial class CommentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            // get comment object from database and update it
            Comment com = CommentManager.GetItem(long.Parse(Request.QueryString["comment"].ToString()));

            TextBox tbName = (TextBox)FormViewComment.FindControl("CommentName");
            com.author = tbName.Text;

            TextBox tbBody = (TextBox)FormViewComment.FindControl("CommentBody");
            com.body = tbBody.Text;
            com.datemodified = System.DateTime.Now;

            CommentManager.Save(com);
            Response.Redirect("~/View/Pages/Admin/AdminComments.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/AdminComments.aspx");
        }

        protected void FormViewComment_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            // redirect user to manage comments view after deletion of a comment
            Response.Redirect("~/View/Pages/Admin/AdminComments.aspx");
        }

    }
}
