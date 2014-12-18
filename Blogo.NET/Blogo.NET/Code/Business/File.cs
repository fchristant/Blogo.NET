using System.ComponentModel;
using System.Collections.Generic;

using Blogo.NET.Data.Access;

namespace Blogo.NET.Business
{

    /// <summary>
    /// Business Object Manager class for Files.
    /// </summary>

    [DataObjectAttribute()]
    public class FileManager
    {

        #region public methods

        /// <summary>
        /// Returns the total number of files in the database
        /// </summary>
        /// <returns>
        /// Returns the total number of files in the database
        /// </returns>

        public static int Count()
        {
            return FileDB.Count();
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
            return FileDB.Count(StartRow, PageSize);
        }

        /// <summary>
        /// Get all files from the database
        /// </summary>
        /// <returns>
        /// returns a list of File objects
        /// </returns>

        public static List<File> GetList()
        {
            return FileDB.GetList();
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

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<File> GetList(int StartRow, int PageSize)
        {
            return FileDB.GetList(StartRow, PageSize);
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

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static File GetItem(long id)
        {
            return FileDB.GetItem(id);
        }

        /// <summary>
        /// Saves a File object to the database
        /// </summary>
        /// <param name="myTag">
        /// The File object to save to the database
        /// </param>
        /// <returns>
        /// returns the id of the saved File object in the database, or -1 if failed
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static long Save(File myFile)
        {
            return FileDB.Save(myFile);
        }

        /// <summary>
        /// Deletes a specific File from the database
        /// </summary>
        /// <param name="id">
        /// the file to delete
        /// </param>
        /// <returns>
        /// returns true when deleted, false if not
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(File myFile)
        {
            if (myFile != null)
                return FileDB.Delete(myFile.id);
            else
                return false;
        }

        #endregion

    }

    /// <summary>
    /// Business Object class for Tags.
    /// </summary>

    public class File
    {
        #region properties
        private long _id = -1;
        public long id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string filename { get; set; }
        public string mime { get; set; }
        public byte[] filecontent { get; set; }
        #endregion
    }
}
