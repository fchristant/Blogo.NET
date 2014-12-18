using System;
using System.ComponentModel;
using System.Collections.Generic;

using Blogo.NET.Data.Access;

namespace Blogo.NET.Business
{

    /// <summary>
    /// Business Object Manager class for Comments.
    /// </summary>

    [DataObjectAttribute()]
    public class CommentManager
    {

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
            return CommentDB.Count(StartRow, PageSize);
        }

        /// <summary>
        /// Get all comments from the database
        /// </summary>
        /// <returns>
        /// returns a list of Comment objects
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Comment> GetList()
        {
            return CommentDB.GetList();
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

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Comment> GetList(int StartRow, int PageSize)
        {
            return CommentDB.GetList(StartRow, PageSize);
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

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Comment> GetList(long parent_id)
        {
            return CommentDB.GetList(parent_id);
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

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Comment GetItem(long id)
        {
            return CommentDB.GetItem(id);
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

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static long Save(Comment myComment)
        {
            return CommentDB.Save(myComment);
        }

        /// <summary>
        /// Deletes a specific Comment from the database
        /// </summary>
        /// <param name="myComment">
        /// the comment to delete
        /// </param>
        /// <returns>
        /// returns true when deleted, false if not
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Comment myComment)
        {
            if (myComment != null)
                return CommentDB.Delete(myComment.id);
            else
                return false;
        }

        #endregion

    }

    /// <summary>
    /// Business Object class for Comments.
    /// </summary>

    public class Comment
    {
        #region properties
        private long _id = -1;
        public long id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string author { get; set; }
        public long blog_id { get; set; }
        public string IP { get; set; }
        public DateTime datecreated { get; set; }
        public DateTime datemodified { get; set; }
        public string body { get; set; }
        #endregion
    }
}
