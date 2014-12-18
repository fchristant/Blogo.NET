using Blogo.NET.Business;
using System.Collections.Generic;

namespace Blogo.NET.View.Pages
{
    public partial class PageBase : System.Web.UI.Page
    {

        /// <summary>
        /// Formats a list of tag objects as taken from a data-bound
        /// BlogEntry object on a page, and formats it as a text
        /// string containing comma-seperated, hyperlinked tag names
        /// </summary>
        /// <param name="param">
        /// The tag collection of a Blog entry object, passed as an
        /// object from a databinding expression
        /// </param>
        /// <returns>
        /// returns a comma-seperated list of hyperlinked tags. the 
        /// last tag in the list will not be suffixed with a comma
        /// </returns>

        public static string ImplodeTags(object param)
        {

            string result = "";
            List<Tag> tags = (List<Tag>)param; // cast the object into a tag list so that we can work with it
            int count = tags.Count; // the number of elements in the tag collection
            int index = 1; // the current element we are looking at

            if (count <= 0)
                result = "- None -"; // no tags in the collection
            else
            {
                foreach (Tag t in tags)
                {
                    result = result + "<a href=\"BlogByTag.aspx?tag=" + t.id +
                        "\">" + t.tagname + "</a>" + (index >= count ? "" : ", ");
                    index++;
                }
            }
            return result;
        }

    }
}
