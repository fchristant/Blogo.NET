using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;

using Blogo.NET.Data.Mapping;
using Blogo.NET.Business;
using Blogo.NET.Utils;

namespace Blogo.NET.Data.Access
{

    /// <summary>
    /// Data Access Layer class for Authors.
    /// </summary>

    public static class AuthorDB
    {
        #region properties
        private static BlogoMapDataContext db = new BlogoMapDataContext();
        #endregion
        
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
            return db.authors.Count();
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

        public static Author GetItem(long id)
        {
            author t = (from author in db.authors where author.id == id select author).FirstOrDefault();
            return FillRecord(t);
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

        public static Author GetItem(string username)
        {
            author t = (from author in db.authors where author.username == username select author).FirstOrDefault();
            return FillRecord(t);
        }

        /// <summary>
        /// Get all authors from the database
        /// </summary>
        /// <returns>
        /// returns a list of Author objects
        /// </returns>

        public static List<Author> GetList()
        {
            var query = from author in db.authors orderby author.username ascending select author;
            List<Author> result = new List<Author>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
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

        public static List<Author> GetList(int StartRow, int PageSize)
        {
            var query = (from author in db.authors orderby author.username ascending select author).Skip(StartRow).Take(PageSize);
            List<Author> result = new List<Author>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
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

        public static long Save(Author myAuthor)
        {
            author t;
            bool found = false;
            
            if (myAuthor.id == -1)
            {
                // new record, check if the username does not exist already
                var dupe = (from author in db.authors where author.username == myAuthor.username select author).FirstOrDefault();
                if (dupe != null)
                {
                    // username already exists
                    found = false;
                    t = null;
                }
                else {
                t = new author();
                t.salt = Hash.GenerateSalt(16);
                t.password = Hash.HashPassword(myAuthor.password, t.salt);
                db.authors.InsertOnSubmit(t);
                found = true;
                }
            }
            else
            {
                // existing record
                t = (from author in db.authors where author.id == myAuthor.id select author).FirstOrDefault();
                if (t != null)
                {
                    found = true;
                    t.id = myAuthor.id;
                }
            }

            if (found)
            {

                t.username = myAuthor.username;
                t.salt = Hash.GenerateSalt(16);
                t.password = Hash.HashPassword(myAuthor.password, t.salt);

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
        /// Deletes a specific Author from the database
        /// </summary>
        /// <param name="id">
        /// the unique identifier of the author to delete
        /// </param>
        /// <returns>
        /// returns true when deleted, false if not
        /// </returns>

        public static bool Delete(long id)
        {
            author t = (from author in db.authors where author.id == id select author).FirstOrDefault();
            if (t != null)
            {
                try
                {
                    db.authors.DeleteOnSubmit(t);
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
        /// Build an Author object from the database
        /// </summary>
        /// <param name="i">
        /// the LINQ data object to build from
        /// </param>
        /// <returns>
        /// returns an Author object
        /// </returns>

        private static Author FillRecord(author i)
        {
            Author result = null;
            if (i != null)
            {
                result = new Author();
                result.id = i.id;
                result.username = i.username;
                result.password = i.password;
                result.salt = i.salt;
            }
            return result;
        }
        #endregion
    }
}
