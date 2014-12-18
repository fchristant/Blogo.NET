using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;

using Blogo.NET.Data.Mapping;
using Blogo.NET.Business;

namespace Blogo.NET.Data.Access
{

    /// <summary>
    /// Data Access Layer class for Files.
    /// </summary>

    public static class FileDB
    {
        #region properties
        private static BlogoMapDataContext db = new BlogoMapDataContext();
        #endregion

        #region public methods

        /// <summary>
        /// Returns the total number of files in the database
        /// </summary>
        /// <returns>
        /// Returns the total number of files in the database
        /// </returns>

        public static int Count()
        {
            return db.files.Count();
        }

        /// <summary>
        /// Returns the total number of files in the database
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// Returns the total number of files in the database
        /// </returns>

        public static int Count(int StartRow, int PageSize)
        {
            return db.files.Count();
        }

        /// <summary>
        /// Get a specific File from the database
        /// </summary>
        /// <param name="id">
        /// the unique identifier of the file to retrieve
        /// </param>
        /// <returns>
        /// returns a File object if found, otherwise NULL
        /// </returns>

        public static File GetItem(long id)
        {

            file t = (from file in db.files where file.id == id select file).FirstOrDefault();
            return FillRecord(t, true);
        }

        /// <summary>
        /// Get all files from the database
        /// </summary>
        /// <returns>
        /// returns a list of File objects
        /// </returns>

        public static List<File> GetList()
        {
            var query = from file in db.files orderby file.filename ascending select file;
            List<File> result = new List<File>();
            foreach (var t in query)
                result.Add(FillRecord(t, false));
            return result;
        }

        /// <summary>
        /// Get all files from the database, starting from position StartRow, return max PageSize results
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// returns a list of File objects
        /// </returns>

        public static List<File> GetList(int StartRow, int PageSize)
        {
            var query = (from file in db.files orderby file.filename ascending select file).Skip(StartRow).Take(PageSize);
            List<File> result = new List<File>();
            foreach (var t in query)
                result.Add(FillRecord(t, false));
            return result;
        }

        /// <summary>
        /// Saves a File object to the database. This operation only allows a file insert, not an update
        /// </summary>
        /// <param name="myFile">
        /// The File object to save to the database
        /// </param>
        /// <returns>
        /// returns the id of the saved File object in the database, or -1 if failed
        /// </returns>

        public static long Save(File myFile)
        {
            file t = null;
            bool cont = false;
            long result = -1;

            // check if the filename does not already exist in the database
            file dupe = (from file in db.files where file.filename == myFile.filename select file).FirstOrDefault();
            cont = (dupe != null ? false : true); // if there is no duplicate record, continue processing

            if (cont)
            {
                try
                {
                    t = new file();
                    t.filename = myFile.filename;
                    t.mime = myFile.mime;
                    t.filecontent = myFile.filecontent;
                    db.files.InsertOnSubmit(t);
                    db.SubmitChanges();
                    result = t.id;
                }
                catch (ChangeConflictException)
                {
                    db.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    db.SubmitChanges();
                    result = t.id;
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes a specific File from the database
        /// </summary>
        /// <param name="id">
        /// the unique identifier of the file to delete
        /// </param>
        /// <returns>
        /// returns true when deleted, false if not
        /// </returns>

        public static bool Delete(long id)
        {
            file t = (from file in db.files where file.id == id select file).FirstOrDefault();
            if (t != null)
            {
                try
                {
                    db.files.DeleteOnSubmit(t);
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
        /// Build a File object from the database
        /// </summary>
        /// <param name="i">
        /// the LINQ data object to build from
        /// </param>
        /// <param name="getFile">
        /// flag to indicate whether the file content should be loaded as part of the returned File object
        /// </param>
        /// <returns>
        /// returns a File object
        /// </returns>

        private static File FillRecord(file i, bool getFile)
        {
            File result = null;
            if (i != null)
            {
                result = new File();
                result.id = i.id;
                result.filename = i.filename;
                result.mime = i.mime;
                if (getFile)
                    result.filecontent = i.filecontent.ToArray();
            }
            return result;
        }
        #endregion
    }
}
