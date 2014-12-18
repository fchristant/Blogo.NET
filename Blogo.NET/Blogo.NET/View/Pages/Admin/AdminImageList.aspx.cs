using System;
using System.Collections.Generic;

using Blogo.NET.Business;

namespace Blogo.NET.View.Pages.Admin
{
    public partial class AdminImageList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // This page outputs the images names/URLs from the database
            // into a javascript array format. This array is required for
            // the TinyMCE image picker to insert a new image into the
            // rich text panel

            int countFiles = FileManager.Count();

            Response.Clear();
            Response.ContentType = "text/javascript";
            Response.Write("var tinyMCEImageList = new Array("); // start of array

            if (countFiles > 0)
            {
                List<Blogo.NET.Business.File> myFiles = Blogo.NET.Business.FileManager.GetList();
                foreach (Blogo.NET.Business.File myFile in myFiles)
                {
                    Response.Write("[\"" + myFile.filename + "\", \"File.aspx?file=" + myFile.id.ToString() + "\"],");
                }
            }
            else
            {
                Response.Write("[\"" + "no images found" + "\", \"/View/Pages/File.aspx?file=" + "error" + "\"],");
            }
            Response.Write("[\"---\", \"\"]);"); // end of array
            Response.End(); // flush output
        }
    }
}
