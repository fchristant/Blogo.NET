using System.Web;
using System.Web.Configuration;
using System;
using System.Configuration;

namespace Blogo.NET.Utils
{

    /// <summary>
    /// Utility class to retrieve and persist application settings in the web.config
    /// Note that when setting a config property, an explicit call to this class'
    /// Save method is required to persist the change
    /// </summary>

    public static class BlogoSettings
    {

        public static Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(@"~");

        /// <summary>
        /// returns or sets the title of the blog as defined in the web.config "blogtitle" setting
        /// returns "MyTitle" if no value is found
        /// </summary>
        /// <returns>
        /// returns or sets the title of the blog as defined in the web.config "blogtitle" setting
        /// returns "MyTitle" if no value is found
        /// </returns>

        public static string BlogTitle
        {
            get
            {
                try
                {
                    return WebConfigurationManager.AppSettings["blogtitle"].ToString();
                }
                catch (Exception)
                {
                    return "MyTitle";
                }
            }
            set
            {
                config.AppSettings.Settings["blogtitle"].Value = value;
            }
        }

        /// <summary>
        /// returns or sets the root path of the blog as defined in the web.config "rootpath" setting
        /// </summary>
        /// <returns>
        /// returns or sets the root path of the blog as defined in the web.config "rootpath" setting
        /// </returns>        

        public static string RootPath
        {
            get
            {
                return WebConfigurationManager.AppSettings["rootpath"].ToString();
            }
            set
            {
                config.AppSettings.Settings["rootpath"].Value = value;
            }
        }

        /// <summary>
        /// returns or sets the RSS page size of the blog as defined in the web.config "rsspagesize" setting
        /// returns 10 if no value is found
        /// </summary>
        /// <returns>
        /// returns or sets the root path of the blog as defined in the web.config "rootpath" setting
        /// returns 10 if no value is found
        /// </returns>        

        public static int RSSPageSize
        {
            get
            {
                try
                {
                    return int.Parse(WebConfigurationManager.AppSettings["rsspagesize"].ToString());
                }
                catch (Exception)
                {
                    return 10;
                }
            }
            set
            {
                config.AppSettings.Settings["rsspagesize"].Value = value.ToString();
            }
        }

        /// <summary>
        /// returns or sets the maximum file upload size as defined in the web.config "maxfilesize" setting
        /// returns 1048576 (1MB) if no value is found
        /// </summary>
        /// <returns>
        /// returns or sets the maximum file upload size as defined in the web.config "maxfilesize" setting
        /// returns 1048576 (1MB) if no value is found
        /// </returns>        

        public static long MaxFileSize
        {
            get
            {
                try
                {
                    return long.Parse(WebConfigurationManager.AppSettings["maxfilesize"].ToString());
                }
                catch (Exception)
                {
                    return 1048576;
                }
            }
            set
            {
                config.AppSettings.Settings["maxfilesize"].Value = value.ToString();
            }
        }

        /// <summary>
        /// returns or sets the blog description as defined in the web.config "blogdescription" setting
        /// </summary>
        /// <returns>
        /// returns or sets the blog description as defined in the web.config "blogdescription" setting
        /// </returns>        

        public static string BlogDescription
        {
            get
            {
                return WebConfigurationManager.AppSettings["blogdescription"].ToString();
            }
            set
            {
                config.AppSettings.Settings["blogdescription"].Value = value.ToString();
            }
        }

        /// <summary>
        /// saves the web.config using the properties in this class
        /// </summary>
        /// <returns>Returns nothing</returns>        

        public static void Save()
        {
            config.Save();
        }
   
    }
}
