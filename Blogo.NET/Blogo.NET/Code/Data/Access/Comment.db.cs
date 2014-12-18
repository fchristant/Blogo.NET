using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;

using Blogo.NET.Data.Mapping;
using Blogo.NET.Business;

namespace Blogo.NET.Data.Access
{

    /// <summary>
    /// Data Access Layer class for Comments.
    /// </summary>

    public static class CommentDB

    {
        #region properties
        private static BlogoMapDataContext db = new BlogoMapDataContext();
        #endregion
        
        #region public methods

        /// <summary>
        /// Returns the total number of comments in the database
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// Returns the total number of comments in the database
        /// </returns>

        public static int Count(int StartRow, int PageSize)
        {
            return db.comments.Count();
        }

        /// <summary>
        /// Get a specific Comment from the database
        /// </summary>
        /// <param name="id">
        /// the unique identifier of the comment to retrieve
        /// </param>
        /// <returns>
        /// returns a Comment object if found, otherwise NULL
        /// </returns>

        public static Comment GetItem(long id)
        {
            comment t = (from comment in db.comments where comment.id == id select comment).FirstOrDefault();
            return FillRecord(t);
        }

        /// <summary>
        /// Get all comments from the database
        /// </summary>
        /// <returns>
        /// returns a list of Comment objects
        /// </returns>

        public static List<Comment> GetList()
        {
            var query = from comment in db.comments orderby comment.datecreated descending select comment;
            List<Comment> result = new List<Comment>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
        }

        /// <summary>
        /// Get all comments from the database, starting from position StartRow, return max PageSize results
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// returns a list of Comment objects
        /// </returns>

        public static List<Comment> GetList(int StartRow, int PageSize)
        {
            var query = (from comment in db.comments orderby comment.datecreated descending select comment).Skip(StartRow).Take(PageSize);
            List<Comment> result = new List<Comment>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
        }

        /// <summary>
        /// Get a list of comment associated with the specified blog entry
        /// </summary>
        /// <param name="parent_id">
        /// the unique identifier of the blog entry for which the comments must be retrieved
        /// </param>
        /// <returns>
        /// returns a list of Comment objects that are associated with the specified blog entry
        /// </returns>

        public static List<Comment> GetList(long parent_id)
        {
            var query = from comment in db.comments where comment.blog_id == parent_id orderby comment.datecreated ascending select comment;
            List<Comment> result = new List<Comment>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
        }

        /// <summary>
        /// Saves a Comment object to the database
        /// </summary>
        /// <param name="myComment">
        /// The Comment object to save to the database
        /// </param>
        /// <returns>
        /// returns the id of the saved Comment object in the database, or -1 if failed
        /// </returns>

        public static long Save(Comment myComment)
        {
            comment t;
            bool found = false;

            if (myComment.id == -1)
            {
                // new record
                t = new comment();
                db.comments.InsertOnSubmit(t);
                found = true;
            }
            else
            {
                // existing record
                t = (from comment in db.comments where comment.id == myComment.id select comment).FirstOrDefault();
                if (t != null)
                {
                    found = true;
                    t.id = myComment.id;
                }
            }

            if (found)
            {

                t.author = myComment.author;
                t.blog_id = myComment.blog_id;
                t.IP = myComment.IP;
                t.datecreated = myComment.datecreated;
                t.datemodified = myComment.datemodified;
                t.body = myComment.body;

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
        /// Deletes a specific Comment from the database
        /// </summary>
        /// <param name="id">
        /// the unique identifier of the comment to delete
        /// </param>
        /// <returns>
        /// returns true when deleted, false if not
        /// </returns>

        public static bool Delete(long id)
        {
            comment t = (from comment in db.comments where comment.id == id select comment).FirstOrDefault();
            if (t != null)
            {
                try
                {
                    db.comments.DeleteOnSubmit(t);
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
        /// Build a Comment object from the database
        /// </summary>
        /// <param name="i">
        /// the LINQ data object to build from
        /// </param>
        /// <returns>
        /// returns a Comment object
        /// </returns>

        private static Comment FillRecord(comment i)
        {
            Comment result = null;
            if (i != null)
            {
                result = new Comment();
                result.id = i.id;
                result.author = i.author;
                result.blog_id = i.blog_id;
                result.IP = i.IP;
                result.datecreated = i.datecreated;
                result.datemodified = i.datemodified;
                result.body = i.body;
            }
            return result;
        }
        #endregion
    }
}
