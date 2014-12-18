using System.Text.RegularExpressions;
using System;

using Blogo.NET.Business;

namespace Blogo.NET.View.Pages
{
    public partial class BlogEntry : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           // hide comments listview and "new comment" panel
           // when comments are disabled for the current blog entry
            try
            {
                Blogo.NET.Business.BlogEntry myBlogEntry = BlogEntryManager.GetItem(long.Parse(Request.QueryString["page"]));
                if (myBlogEntry.allowcomments == false)
                {
                    ListComments.Visible = false;
                    PlaceHolderNewComment.Visible = false;
                    PlaceHolderNoComments.Visible = true;
                }
                else
                {
                    // if a blogo admin user is logged in, prefill comment name field with current user
                    CommentName.Text = (User.Identity.IsAuthenticated ? User.Identity.Name : String.Empty);
                }
            }
            catch (Exception)
            {
            }
        }

        protected void ButtonSubmit_Click(object sender, System.EventArgs e)
        {
            // build a new Comment object from the user's comment input,
            // and save it into the database. Only do this if the request has a
            // comHash field, to protect against comment spam

            if (Request.Form.Get("comHash") != null)
            {

                Comment com = new Comment();
                com.author = Server.HtmlEncode(CommentName.Text);

                // 1. to prevent users from injecting HTML into the comments, we will encode the comment body
                // 2. to preserve the new lines entered by the user, we need to replace \r with HTML <br/>
                com.body = Regex.Replace(Server.HtmlEncode(CommentBody.Text), @"\r", "<br/>", RegexOptions.Multiline);
                com.blog_id = long.Parse(Request.QueryString["page"]);
                com.datecreated = System.DateTime.Now;
                com.datemodified = System.DateTime.Now;
                com.IP = Request.UserHostAddress;

                CommentManager.Save(com);

                Response.Redirect(Request.Url.ToString());
            }
        }

    }
}
