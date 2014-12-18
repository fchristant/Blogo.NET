using System;
using System.Web;

using Blogo.NET.Business;
using Blogo.NET.Utils;

namespace Blogo.NET.View.Pages.Admin
{
    public partial class AdminFileNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelMaxUpload.Text = BlogoSettings.MaxFileSize.ToString();
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Pages/Admin/AdminFiles.aspx");
        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (FileUpload.HasFile)
                {
                    // a file has been uploaded, check if it has content,
                    // and if the content size does not exceed the maximum 
                    // as set by the administrator in the settings
                    HttpPostedFile httpFile = FileUpload.PostedFile;
                    if (httpFile.ContentLength > 0 && httpFile.ContentLength < BlogoSettings.MaxFileSize)
                    {
                        // the file size is valid, let's put it into the database
                        Blogo.NET.Business.File newFile = new Blogo.NET.Business.File();
                        newFile.filename = System.IO.Path.GetFileName(httpFile.FileName);
                        newFile.mime = httpFile.ContentType;
                        newFile.filecontent = new byte[httpFile.ContentLength];
                        httpFile.InputStream.Read(newFile.filecontent, 0, httpFile.ContentLength);
                        FileManager.Save(newFile);
                        Response.Redirect("~/View/Pages/Admin/AdminFiles.aspx");
                    }
                    else
                    {
                        // a file was uploaded but the file's content size was invalid
                        LabelError.Text = "The file size is invalid (either 0 or exceeding the maximum)";
                        // SPECIAL NOTE: When the uploaded file is larger than the setting
                        // maxRequestLength in the web.config (httpRuntime setting),
                        // users will not face our friendly error message. Instead,
                        // they will get a brute "connect was reset" error from the browser.
                        // to avoid this, increase the maxRequestLength setting
                    }
                }

            }
        }
    }
}
