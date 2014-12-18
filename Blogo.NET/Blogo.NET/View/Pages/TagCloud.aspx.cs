using System;
using System.Collections.Generic;

using Blogo.NET.Business;

namespace Blogo.NET.View.Pages
{
    public partial class TagCloud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // render a tag cloud
            
            int count;              // the number of blog entries per tag
            int min = 0;            // the lowest count in the cloud
            int max = 0;            // the highest count in the cloud
            int maxStyle = 6;       // the highest css style to apply to the tag links
            int loop = 0;           // index for determining min and max


            // get the list of tags for which there is at least one blog entry
            List<Tag> usedTags = TagManager.GetListUsedTags();

            // loop through each of the tags to determine the minimum and maximum count
            foreach (Tag t in usedTags)
            {
                // get the count for the current tag
                count = TagManager.CountByTag(t.id);
                // if current count higher than max, set max to current count
                max = (count > max ? count : max);
                // if min is not initialized yet, set it to the first count
                // we need to do this because we cannot initialize min at 0
                // as no counts will be lower than 0
                if (loop == 0)
                    min = count;
                else
                    // if current count lower than min, set min to current count
                    min = (count < min ? count : min);
                loop++;
            }

            // with min and max calculated, we can now concatenate the tag cloud string
            string strCloud = "";
            foreach (Tag t in usedTags)
            {
                count = TagManager.CountByTag(t.id);

                strCloud += "<a href=\"BlogByTag.aspx?tag=" + t.id.ToString() + "\" class=\"tag" +
                    GetSizeByCount(count, min, max, maxStyle).ToString() + "\">" + t.tagname + "</a>&nbsp;";
            }

            // output the tag cloud
            LabelTagCloud.Text = strCloud;
        }

        /// <summary>
        /// Calculate the (CSS) size to apply to the specified count
        /// this algorithm takes into effect the distribution of counts across the map,
        /// which it implements using the min and max values of the count
        /// </summary>
        /// <param name="count">
        /// the number of blog entries that are in the tag
        /// </param>
        /// <param name="min">
        /// the lowest count in the tag cloud
        /// </param>
        /// <param name="max">
        /// the highest count in the tag cloud
        /// </param>
        /// <param name="maxStyle">
        /// the highest CSS class that can be applied to a tag
        /// </param>
        /// <returns>
        /// returns a Tag object if found, otherwise NULL
        /// </returns>

        protected int GetSizeByCount(int count, int min, int max, int maxStyle)
        {
            if (max - min == 0)
                // min and max are even, this means that all tags have an equal count,
                // and must be rendered with the same size. Therefore, take the middle
                // size of the specified maxStyle
                return Convert.ToInt32(Math.Round((Decimal)maxStyle / 2));
            else
                // not all tags have an equal count, distribute the size according to the
                // min count, max count and maxStyle parameters
                return Convert.ToInt32(Math.Round((Decimal)(((maxStyle - 1) / (max - min)) * count) + (1 * max - maxStyle * min) / (max - min)));
        }
    }
}
