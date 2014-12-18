using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;

using Blogo.NET.Data.Mapping;
using Blogo.NET.Business;

namespace Blogo.NET.Data.Access
{
    
    /// <summary>
    /// Data Access Layer class for Tags.
    /// </summary>

    public static class TagDB
    {
        #region properties
        private static BlogoMapDataContext db = new BlogoMapDataContext();
        #endregion

        #region public methods

        /// <summary>
        /// Returns the total number of tags in the database
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// Returns the total number of tags in the database
        /// </returns>

        public static int Count(int StartRow, int PageSize)
        {
            return db.tags.Count();
        }

        /// <summary>
        /// Returns the total number of entries for the specified tag id
        /// </summary>
        /// <param name="id">
        /// the id of the tag for which to retrieve the count
        /// </param>
        /// <returns>
        /// Returns the total number of entries for the specified tag id
        /// </returns>

        public static int CountByTag(long id)
        {
            return (from tag in db.blog_tags where tag.tag_id == id select tag).Count();
        }

        /// <summary>
        /// Get a specific Tag from the database
        /// </summary>
        /// <param name="id">
        /// the unique identifier of the tag to retrieve
        /// </param>
        /// <returns>
        /// returns a Tag object if found, otherwise NULL
        /// </returns>

        public static Tag GetItem(long id)
        {
            
            tag t = (from tag in db.tags where tag.id == id select tag).FirstOrDefault();
            return FillRecord(t);
        }

        /// <summary>
        /// Get all tags from the database
        /// </summary>
        /// <returns>
        /// returns a list of Tag objects
        /// </returns>

        public static List<Tag> GetList()
        {
            var query = from tag in db.tags orderby tag.tagname ascending select tag;
            List<Tag> result = new List<Tag>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
        }

        /// <summary>
        /// Get all tags from the database, starting from position StartRow, return max PageSize results
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// returns a list of Tag objects
        /// </returns>

        public static List<Tag> GetList(int StartRow, int PageSize)
        {
            var query = (from tag in db.tags orderby tag.tagname ascending select tag).Skip(StartRow).Take(PageSize);
            List<Tag> result = new List<Tag>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
        }

        /// <summary>
        /// Get a list of tags associated with the specified blog entry
        /// </summary>
        /// <param name="parent_id">
        /// the unique identifier of the blog entry for which the tags must be retrieved
        /// </param>
        /// <returns>
        /// returns a list of Tag objects that are associated with the specified blog entry
        /// </returns>

        public static List<Tag> GetList(long parent_id)
        {
            var query = from tag in db.blog_tags where tag.blog_id == parent_id select tag.tag;
            List<Tag> result = new List<Tag>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
        }

        /// <summary>
        /// Get a list of used tags. A used tag is a tag for which there is at least one blog entry
        /// </summary>
        /// <returns>
        /// returns a list of Tag objects for which there is at least one blog entry
        /// </returns>

        public static List<Tag> GetListUsedTags()
        {
            var query = (from tag in db.blog_tags orderby tag.tag.tagname ascending select tag.tag).Distinct();
            List<Tag> result = new List<Tag>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
        }

        /// <summary>
        /// Saves a Tag object to the database
        /// </summary>
        /// <param name="myTag">
        /// The Tag object to save to the database
        /// </param>
        /// <returns>
        /// returns the id of the saved Tag object in the database, or -1 if failed
        /// </returns>

        public static long Save(Tag myTag)
        {
            tag t;
            bool found = false;

            if (myTag.id == -1)
            {
                // new record, check if the tagname does not already exist in the database
                tag dupe = (from tag in db.tags where tag.tagname == myTag.tagname select tag).FirstOrDefault();
                if (dupe != null)
                {
                    // duplicate found
                    found = false;
                    t = null;
                }
                else
                {
                    t = new tag();
                    db.tags.InsertOnSubmit(t);
                    found = true;
                }
            }
            else
            {
                // existing record
                t = (from tag in db.tags where tag.id == myTag.id select tag).FirstOrDefault();
                if (t != null)
                {
                    found = true;
                    t.id = myTag.id;
                }
            }

            if (found)
            {

                t.tagname = myTag.tagname;

                try
                {
                    db.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    db.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    db.SubmitChanges();
                }
                return t.id;
            }
            else
                return -1;
          
        }

        /// <summary>
        /// Deletes a specific Tag from the database
        /// </summary>
        /// <param name="id">
        /// the unique identifier of the tag to delete
        /// </param>
        /// <returns>
        /// returns true when deleted, false if not
        /// </returns>

        public static bool Delete(long id)
        {
            tag t = (from tag in db.tags where tag.id == id select tag).FirstOrDefault();
            if (t != null)
            {
                try
                {
                    db.tags.DeleteOnSubmit(t);
                    db.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    db.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    db.SubmitChanges();
                }
            }
            return (t!=null);
        }

        #endregion

        #region private methods

        /// <summary>
        /// Build a Tag object from the database
        /// </summary>
        /// <param name="i">
        /// the LINQ data object to build from
        /// </param>
        /// <returns>
        /// returns a Tag object
        /// </returns>

        private static Tag FillRecord(tag i)
        {
            Tag result = null;
            if (i != null)
            {
                result = new Tag();
                result.id = i.id;
                result.tagname = i.tagname;
            }
            return result;
        }
        #endregion
    }
}
