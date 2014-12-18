using System;

using Blogo.NET.Business;

namespace Blogo.NET.View.Pages
{
    public partial class File : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check if a file identifier was passed...
            if (Request.QueryString["file"] != null)
            {
                // get the file object
                long fileID = long.Parse(Request.QueryString["file"].ToString());
                Blogo.NET.Business.File myFile = FileManager.GetItem(fileID);

                if (myFile != null) {
                    // a file object was found in the database, output the file contents
                    Response.Clear();
                    Response.ContentType = myFile.mime;
                    Response.OutputStream.Write((byte[])myFile.filecontent, 0, (int)myFile.filecontent.Length);
                    Response.End();
                }
                else 
                {
                    // now file was found matching the file identifier
                    throw new Exception("Invalid file identifier: " + fileID.ToString());
                }
            }
        }
    }
}
