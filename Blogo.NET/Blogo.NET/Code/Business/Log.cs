using System;
using System.ComponentModel;
using System.Collections.Generic;

using Blogo.NET.Data.Access;

namespace Blogo.NET.Business
{

    /// <summary>
    /// Business Object Manager class for Logs.
    /// </summary>

    [DataObjectAttribute()]
    public class LogManager
    {

        #region public methods

        /// <summary>
        /// Returns the total number of log entries in the database
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// Returns the total number of log entries in the database
        /// </returns>

        public static int Count(int StartRow, int PageSize)
        {
            return LogDB.Count(StartRow, PageSize);
        }

        /// <summary>
        /// Get a specific Log from the database
        /// </summary>
        /// <param name="id">
        /// the unique identifier of the object to retrieve
        /// </param>
        /// <returns>
        /// returns a Log object if found, otherwise NULL
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Log GetItem(long id)
        {
            return LogDB.GetItem(id);
        }

        /// <summary>
        /// Get all log entries from the database, starting from position StartRow, return max PageSize results
        /// </summary>
        /// <param name="StartRow">
        /// The start position in the result set to retrieve records from
        /// </param>
        /// <param name="PageSize">
        /// The maximum number of records to retrieve from position StartRow
        /// </param>
        /// <returns>
        /// returns a list of Log objects
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Log> GetList(int StartRow, int PageSize)
        {
            return LogDB.GetList(StartRow, PageSize);
        }

        /// <summary>
        /// Saves a Log object to the database
        /// </summary>
        /// <param name="myLog">
        /// The Log object to save to the database
        /// </param>
        /// <returns>
        /// returns the id of the saved Log object in the database, or -1 if failed
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static long Save(Log myLog)
        {
            return LogDB.Save(myLog);
        }

        /// <summary>
        /// Deletes a specific Log object from the database
        /// </summary>
        /// <param name="myLog">
        /// the log to delete
        /// </param>
        /// <returns>
        /// returns true when deleted, false if not
        /// </returns>

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Log MyLog)
        {
            if (MyLog != null)
                return LogDB.Delete(MyLog.id);
            else
                return false;
        }

        /// <summary>
        /// Deletes all log entries from the database
        /// </summary>
        /// <returns>
        /// Returns nothing
        /// </returns>

        public static void DeleteAll()
        {
            LogDB.DeleteAll();
        }

        #endregion

    }

    /// <summary>
    /// Business Object class for Tags.
    /// </summary>

    public class Log
    {
        #region properties
        private long _id = -1;
        public long id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime date { get; set; }
        public string @event { get; set; }
        #endregion
    }
}
