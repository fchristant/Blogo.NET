using System;
using System.Text;
using System.Xml;
using System.Collections.Generic;

using Blogo.NET.Business;
using Blogo.NET.Utils;

namespace Blogo.NET.View.RSS
{
    public partial class RSSArticles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear any previous output from the buffer

            Response.Clear();

            Response.ContentType = "text/xml";

            XmlTextWriter xtwFeed = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);

            xtwFeed.WriteStartDocument();

            // The mandatory rss tag

            xtwFeed.WriteStartElement("rss");

            xtwFeed.WriteAttributeString("version", "2.0");

            // The channel tag contains RSS feed details

            xtwFeed.WriteStartElement("channel");

            xtwFeed.WriteElementString("title", BlogoSettings.RootPath + ":: Articles Feed");

            xtwFeed.WriteElementString("link", BlogoSettings.RootPath + "/View/Pages/Home.aspx");

            xtwFeed.WriteElementString("description", "The last articles from " + BlogoSettings.RootPath);

            xtwFeed.WriteElementString("copyright", "Copyright s3maphor3.org. All rights reserved.");

            List<Blogo.NET.Business.BlogEntry> rssEntries = BlogEntryManager.GetListType(Types.article, 0, BlogoSettings.RSSPageSize);

            // Loop through the content of the list and add them to the RSS feed

            foreach (Blogo.NET.Business.BlogEntry bEntry in rssEntries)
            {

                xtwFeed.WriteStartElement("item");

                xtwFeed.WriteElementString("title", bEntry.title);

                xtwFeed.WriteElementString("description", bEntry.description);

                xtwFeed.WriteElementString("link", BlogoSettings.RootPath + "/View/Pages/BlogEntry.aspx?page=" + bEntry.id);

                xtwFeed.WriteElementString("pubDate", bEntry.datepublished.ToString());

                xtwFeed.WriteEndElement();

            }

            // Close all tags

            xtwFeed.WriteEndElement();

            xtwFeed.WriteEndElement();

            xtwFeed.WriteEndDocument();

            xtwFeed.Flush();

            xtwFeed.Close();

            Response.End();
        }
    }
}
