using System;
using System.Collections.Generic;
using System.ComponentModel;

using Blogo.NET.Data.Access;

namespace Blogo.NET.Business
{

    /// <summary>
    /// Business Object Manager class for BlogEntries.
    /// </summary>

    [DataObjectAttribute()]
    public class BlogEntryManager
    {

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
            return BlogEntryDB.CountAll(StartRow, PageSize);
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
            return BlogEntryDB.Count(StartRow, PageSize);
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
            return BlogEntryDB.CountTag(TagID, StartRow, PageSize);
        }

        /// <summary>
        /// Returns the total number of blog entries of the specified type in the database, excluding the ones marked private
        /// </summary>
        /// <param name="type">
        /// The type of blog entry
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
            return BlogEntryDB.CountType(type, StartRow, PageSize);
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
            return BlogEntryDB.CountMonth(year, month, StartRow, PageSize);
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
            return BlogEntryDB.CountUsedMonths(StartRow, PageSize);
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
            return BlogEntryDB.GetListAll(StartRow, PageSize);
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

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<BlogEntry> GetList(int StartRow, int PageSize)
        {
            return BlogEntryDB.GetList(StartRow, PageSize);
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

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<BlogEntry> GetListTag(int TagID, int StartRow, int PageSize)
        {
            return BlogEntryDB.GetListTag(TagID, StartRow, PageSize);
        }

        /// <summary>
        /// Get all blog entries of the specified type from the database, excluding the ones marked private
        /// </summary>]
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

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<BlogEntry> GetListType(Types type, int StartRow, int PageSize)
        {
            return BlogEntryDB.GetListType(type, StartRow, PageSize);
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

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<BlogEntry> GetListMonth(int year, int month, int StartRow, int PageSize)
        {
            return BlogEntryDB.GetListMonth(year, month, StartRow, PageSize);
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

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Month> GetListUsedMonths(int StartRow, int PageSize)
        {
            return BlogEntryDB.GetListUsedMonths(StartRow, PageSize);
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

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BlogEntry GetItem(long id)
        {
            return BlogEntryDB.GetItem(id);
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

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static long Save(BlogEntry myBlogEntry)
        {
            return BlogEntryDB.Save(myBlogEntry);
        }

        /// <summary>
        /// Deletes a specific BlogEntry from the database
        /// </summary>
        /// <param name="myBlogEntry">
        /// the blog entry to delete
        /// </param>
        /// <returns>
        /// returns true when deleted, false if not
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(BlogEntry myBlogEntry)
        {
            if (myBlogEntry != null)
                return BlogEntryDB.Delete(myBlogEntry.id);
            else
                return false;
        }

        #endregion

    }

    /// <summary>
    /// Business Object class for BlogEntries.
    /// </summary>


    public class BlogEntry
    {
        #region properties
        private long _id = -1;
        private List<Tag> _tags = new List<Tag>();
        private List<Comment> _comments = new List<Comment>();

        public long id
        {
            get { return _id; }
            set { _id = value; }
        }

        public List<Tag> tags
        {
        get { return _tags; }
        set { _tags = value; }
        }

        public List<Comment> comments {
            get { return _comments; }
            set { _comments = value; }
        }

        public Author author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Types type { get; set; }
        public bool allowcomments { get; set; }
        public bool markprivate { get; set; }
        public string body { get; set; }
        public DateTime datecreated { get; set; }
        public DateTime datepublished { get; set; }
        public DateTime datemodified { get; set; }
        #endregion
    }
}
