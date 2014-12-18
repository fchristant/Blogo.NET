using System.ComponentModel;
using System.Collections.Generic;

using Blogo.NET.Data.Access;

namespace Blogo.NET.Business
{

    /// <summary>
    /// Business Object Manager class for Authors.
    /// </summary>

    [DataObjectAttribute()]
    public class AuthorManager
    {

        #region public methods

        /// <summary>
        /// Returns the total number of authors in the database
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// Returns the total number of authors in the database
        /// </returns>

        public static int Count(int StartRow, int PageSize)
        {
            return AuthorDB.Count(StartRow, PageSize);
        }

        /// <summary>
        /// Get all authors from the database
        /// </summary>
        /// <returns>
        /// returns a list of Author objects
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Author> GetList()
        {
            return AuthorDB.GetList();
        }

        /// <summary>
        /// Get all authors from the database, starting from position StartRow, return max PageSize results
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// returns a list of Author objects
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static List<Author> GetList(int StartRow, int PageSize)
        {
            return AuthorDB.GetList(StartRow, PageSize);
        }

        /// <summary>
        /// Get a specific Author from the database
        /// </summary>
        /// <param name="id">
        /// the unique identifier of the author to retrieve
        /// </param>
        /// <returns>
        /// returns an Author object if found, otherwise NULL
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Author GetItem(long id)
        {
            return AuthorDB.GetItem(id);
        }

        /// <summary>
        /// Get a specific Author from the database
        /// </summary>
        /// <param name="username">
        /// the username of the author to retrieve
        /// </param>
        /// <returns>
        /// returns an Author object if found, otherwise NULL
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Author GetItem(string username)
        {
            return AuthorDB.GetItem(username);
        }

        /// <summary>
        /// Saves an Author object to the database
        /// </summary>
        /// <param name="myAuthor">
        /// The Author object to save to the database
        /// </param>
        /// <returns>
        /// returns the id of the saved Author object in the database, or -1 if failed
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static long Save(Author myAuthor)
        {
            return AuthorDB.Save(myAuthor);
        }

        /// <summary>
        /// Deletes a specific Author from the database
        /// </summary>
        /// <param name="myAuthor">
        /// the author to delete
        /// </param>
        /// <returns>
        /// returns true when deleted, false if not
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Author myAuthor)
        {
            if (myAuthor != null)
                return AuthorDB.Delete(myAuthor.id);
            else
                return false;
        }

        #endregion

    }

    /// <summary>
    /// Business Object class for Authors.
    /// </summary>

    public class Author
    {
        #region properties
        private long _id = -1;
        public long id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        #endregion
    }
}
