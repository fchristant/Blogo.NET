using System.ComponentModel;
using System.Collections.Generic;

using Blogo.NET.Data.Access;

namespace Blogo.NET.Business
{

    /// <summary>
    /// Business Object Manager class for Tags.
    /// </summary>

    [DataObjectAttribute()]
    public class TagManager
    {

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
            return TagDB.Count(StartRow, PageSize);
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
            return TagDB.CountByTag(id);
        }

        /// <summary>
        /// Get all tags from the database
        /// </summary>
        /// <returns>
        /// returns a list of Tag objects
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Tag> GetList()
        {
            return TagDB.GetList();
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

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Tag> GetList(int StartRow, int PageSize)
        {
            return TagDB.GetList(StartRow, PageSize);
        }

        /// <summary>
        /// Get all tags from the database for which there is at least one blog entry
        /// </summary>
        /// <returns>
        /// returns a list of Tag objects for which there is at least one blog entry
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Tag> GetListUsedTags()
        {
            return TagDB.GetListUsedTags();
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

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Tag GetItem(long id)
        {
            return TagDB.GetItem(id);
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

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static long Save(Tag myTag)
        {
            return TagDB.Save(myTag);
        }

        /// <summary>
        /// Deletes a specific Tag from the database
        /// </summary>
        /// <param name="myTag">
        /// the tag to delete
        /// </param>
        /// <returns>
        /// returns true when deleted, false if not
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Tag myTag)
        {
            if (myTag != null)
                return TagDB.Delete(myTag.id);
            else
                return false;
        }

        #endregion

    }

    /// <summary>
    /// Business Object class for Tags.
    /// </summary>

    public class Tag
    {
        #region properties
        private long _id = -1;
        public long id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string tagname { get; set; }
        #endregion
    }
}
