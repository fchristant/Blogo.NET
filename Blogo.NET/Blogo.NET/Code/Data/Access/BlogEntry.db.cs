using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;

using Blogo.NET.Data.Mapping;
using Blogo.NET.Business;

namespace Blogo.NET.Data.Access
{

    /// <summary>
    /// Data Access Layer class for BlogEntries.
    /// </summary>

    public static class BlogEntryDB
    {
        #region properties
        private static BlogoMapDataContext db = new BlogoMapDataContext();
        #endregion

        #region public methods

        /// <summary>
        /// Returns the total number of blog entries in the database
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// Returns the total number of blog entries in the database
        /// </returns>

        public static int CountAll(int StartRow, int PageSize)
        {
            return db.blogentries.Count();
        }

        /// <summary>
        /// Returns the total number of blog entries in the database, excluding the ones marked private
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// Returns the total number of blog entries in the database
        /// </returns>

        public static int Count(int StartRow, int PageSize)
        {
            return (from blogentry in db.blogentries where blogentry.markprivate == false select blogentry).Count();
        }

        /// <summary>
        /// Returns the total number of blog entries of the specified tag in the database, excluding the ones marked private
        /// </summary>
        /// <param name="TagID">
        /// The ID of the tag
        /// </param>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// Returns the total number of blog entries of the specified tag in the database
        /// </returns>

        public static int CountTag(int TagID, int StartRow, int PageSize)
        {
            return (from blogtag in db.blog_tags where blogtag.tag_id == TagID && blogtag.blogentry.markprivate == false select blogtag.blogentry).Count();
        }

        /// <summary>
        /// Returns the total number of blog entries of the specified type in the database, excluding the ones marked private
        /// </summary>
        /// <param name="type">
        /// The type of the blog entry
        /// </param>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// Returns the total number of blog entries of the specified type in the database
        /// </returns>

        public static int CountType(Types type, int StartRow, int PageSize)
        {
            return (from blogentry in db.blogentries where blogentry.type.Equals(type.ToString()) && blogentry.markprivate == false select blogentry).Count();
        }

        /// <summary>
        /// Counts the blog entries for the specified year and month, excluding the ones marked private
        /// </summary>
        /// <param name="year">
        /// The year associated with the month
        /// </param>
        /// <param name="month">
        /// The months within the year
        /// </param>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// Returns the number of blog entries in the specified year and month
        /// </returns>

        public static int CountMonth(int year, int month, int StartRow, int PageSize)
        {
            return (from blogentry in db.blogentries
                    where (blogentry.datepublished.Year == year
                        && blogentry.datepublished.Month == month && blogentry.markprivate == false)
                    select blogentry).Count();
        }

        /// <summary>
        /// Returns the total number of distinct months in the blog entries collection, excluding the ones marked private
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// Returns the total number of distincs months in the blog entries collection
        /// </returns>

        public static int CountUsedMonths(int StartRow, int PageSize)
        {
            return (from blogentry in db.blogentries where blogentry.markprivate == false select new { blogentry.datepublished.Month, blogentry.datepublished.Year }).Distinct().Count();
        }

        /// <summary>
        /// Get all blog entries from the database, starting from position StartRow, return max PageSize results
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// returns a list of BlogEntry objects
        /// </returns>

        public static List<BlogEntry> GetListAll(int StartRow, int PageSize)
        {
            var query = (from blogentry in db.blogentries orderby blogentry.datepublished descending select blogentry).Skip(StartRow).Take(PageSize);
            List<BlogEntry> result = new List<BlogEntry>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
        }

        /// <summary>
        /// Get all blog entries from the database, starting from position StartRow, return max PageSize results, excluding the ones marked private
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// returns a list of BlogEntry objects
        /// </returns>

        public static List<BlogEntry> GetList(int StartRow, int PageSize)
        {
            var query = (from blogentry in db.blogentries where blogentry.markprivate == false orderby blogentry.datepublished descending select blogentry).Skip(StartRow).Take(PageSize);
            List<BlogEntry> result = new List<BlogEntry>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
        }

        /// <summary>
        /// Get all blog entries of the specified tag from the database, starting from position StartRow, return max PageSize results, excluding the ones marked private
        /// </summary>
        /// <param name="TagID">
        /// The id of the tag for which to retrieve blog entries
        /// </param>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// returns a list of BlogEntry objects
        /// </returns>

        public static List<BlogEntry> GetListTag(int TagID, int StartRow, int PageSize)
        {
            var query = (from blogtag in db.blog_tags where blogtag.tag_id == TagID && blogtag.blogentry.markprivate == false orderby blogtag.blogentry.datepublished descending select blogtag.blogentry).Skip(StartRow).Take(PageSize);
            List<BlogEntry> result = new List<BlogEntry>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
        }

        /// <summary>
        /// Get all blog entries of the specified type from the database, excluding the ones marked private
        /// </summary>
        /// <param name="type">
        /// The type for which the blog entries should be returned
        /// </param>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// returns a list of BlogEntry objects of the specified type
        /// </returns>

        public static List<BlogEntry> GetListType(Types type, int StartRow, int PageSize)
        {
            var query = (from blogentry in db.blogentries where blogentry.type.Equals(type.ToString()) && blogentry.markprivate == false orderby blogentry.datepublished descending select blogentry).Skip(StartRow).Take(PageSize);
            List<BlogEntry> result = new List<BlogEntry>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
        }

        /// <summary>
        /// Gets a descending list of blog entries for the specified year and month, excluding the ones marked private
        /// </summary>
        /// <param name="year">
        /// The year associated with the month
        /// </param>
        /// <param name="month">
        /// The months within the year
        /// </param>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// Returns a descending list of blog entries for the specified year and month
        /// </returns>

        public static List<BlogEntry> GetListMonth(int year, int month, int StartRow, int PageSize)
        {
            var query = (from blogentry in db.blogentries
                         where (blogentry.datepublished.Year == year && blogentry.datepublished.Month == month && blogentry.markprivate == false)
                         orderby blogentry.datepublished descending
                         select blogentry).Skip(StartRow).Take(PageSize);
            List<BlogEntry> result = new List<BlogEntry>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
        }

        /// <summary>
        /// Gets a descending list of month object in which blog entries are posted, excluding the ones marked private
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// returns a list of month objects in which blog entries are posted
        /// </returns>

        public static List<Month> GetListUsedMonths(int StartRow, int PageSize)
        {
            var query = (from blogentry in db.blogentries where blogentry.markprivate == false select new { blogentry.datepublished.Month, blogentry.datepublished.Year })
                         .Distinct().Skip(StartRow).Take(PageSize).OrderByDescending(x => x.Year).ThenByDescending(x => x.Month);
            List<Month> result = new List<Month>();
            foreach (var m in query)
                result.Add(new Month(m.Year, m.Month));
            return result;
        }

        /// <summary>
        /// Get a specific BlogEntry from the database
        /// </summary>
        /// <param name="id">
        /// the unique identifier of the blog entry to retrieve
        /// </param>
        /// <returns>
        /// returns a BlogEntry object if found, otherwise NULL
        /// </returns>

        public static BlogEntry GetItem(long id)
        {
            blogentry t = (from blogentry in db.blogentries where blogentry.id == id select blogentry).FirstOrDefault();
            return FillRecord(t);
        }

        /// <summary>
        /// Saves a BlogEntry object to the database
        /// </summary>
        /// <param name="myBlogEntry">
        /// The BlogEntry object to save to the database
        /// </param>
        /// <returns>
        /// returns the id of the saved BlogEntry object in the database, or -1 if failed
        /// </returns>

        public static long Save(BlogEntry myBlogEntry)
        {
            blogentry t;
            bool found = false;

            if (myBlogEntry.id == -1)
            {
                // new record
                t = new blogentry();
                t.datecreated = System.DateTime.Now;
                t.datepublished = myBlogEntry.datepublished;
                db.blogentries.InsertOnSubmit(t);
                found = true;
            }
            else
            {
                // existing record
                t = (from blogentry in db.blogentries where blogentry.id == myBlogEntry.id select blogentry).FirstOrDefault();
                if (t != null)
                {
                    found = true;
                    t.id = myBlogEntry.id;
                }
            }

            if (found)
            {

                t.author = db.authors.Single(c => c.id == myBlogEntry.author.id);
                t.title = myBlogEntry.title;
                t.description = myBlogEntry.description;
                t.type = (myBlogEntry.type.Equals(Types.article) ? Types.article.ToString() : Types.blogentry.ToString());
                t.allowcomments = myBlogEntry.allowcomments;
                t.markprivate = myBlogEntry.markprivate;
                t.body = myBlogEntry.body;
                t.datemodified = System.DateTime.Now;

                try
                {
                    db.SubmitChanges();

                    // delete and recreate blog/tag mappings
                    var tagmaps = (from tagmap in db.blog_tags where tagmap.blog_id == t.id select tagmap);
                    db.blog_tags.DeleteAllOnSubmit(tagmaps);
                    foreach (Tag tag in myBlogEntry.tags)
                    {
                        blog_tag bTag = new blog_tag();
                        bTag.blog_id = t.id;
                        bTag.tag_id = tag.id;
                        db.blog_tags.InsertOnSubmit(bTag);
                    }

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
        /// Deletes a specific BlogEntry from the database
        /// </summary>
        /// <param name="id">
        /// the unique identifier of the blog entry to delete
        /// </param>
        /// <returns>
        /// returns true when deleted, false if not
        /// </returns>

        public static bool Delete(long id)
        {
            blogentry t = (from blogentry in db.blogentries where blogentry.id == id select blogentry).FirstOrDefault();
            if (t != null)
            {
                try
                {
                    // delete related comments of blog entry
                    var comments = (from comment in db.comments where comment.blog_id == id select comment);
                    db.comments.DeleteAllOnSubmit(comments);

                    // delete tag mappings of blog entry
                    var tagmaps = (from tagmap in db.blog_tags where tagmap.blog_id == id select tagmap);
                    db.blog_tags.DeleteAllOnSubmit(tagmaps);

                    // delete blog entry
                    db.blogentries.DeleteOnSubmit(t);
                    db.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    db.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    db.SubmitChanges();
                }
            }
            return (t != null);
        }

        #endregion

        #region private methods

        /// <summary>
        /// Build a BlogEntry object from the database
        /// </summary>
        /// <param name="i">
        /// the LINQ data object to build from
        /// </param>
        /// <returns>
        /// returns a BlogEntry object
        /// </returns>

        private static BlogEntry FillRecord(blogentry i)
        {
            BlogEntry result = null;
            if (i != null)
            {
                result = new BlogEntry();
                result.id = i.id;

                if (i.author != null)
                    result.author = AuthorDB.GetItem(i.author.id);
                else
                    result.author = null;

                result.title = i.title;
                result.description = i.description;
                result.type = (i.type.Equals(Types.article.ToString()) ? Types.article : Types.blogentry);
                result.allowcomments = i.allowcomments;
                result.markprivate = i.markprivate;
                result.body = i.body;
                result.datecreated = i.datecreated;
                result.datepublished = i.datepublished;
                result.datemodified = i.datemodified;
                result.comments = CommentDB.GetList(i.id);
                result.tags = TagDB.GetList(i.id);
            }
            return result;
        }
        #endregion
    }
}
