using System;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;

using Blogo.NET.Data.Mapping;
using Blogo.NET.Business;

namespace Blogo.NET.Data.Access
{

    /// <summary>
    /// Data Access Layer class for Logs.
    /// </summary>

    public static class LogDB
    {
        #region properties
        private static BlogoMapDataContext db = new BlogoMapDataContext();
        #endregion

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
            return db.logs.Count();
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

        public static Log GetItem(long id)
        {

            log t = (from log in db.logs where log.id == id select log).FirstOrDefault();
            return FillRecord(t);
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

        public static List<Log> GetList(int StartRow, int PageSize)
        {
            var query = (from log in db.logs orderby log.date descending select log).Skip(StartRow).Take(PageSize);
            List<Log> result = new List<Log>();
            foreach (var t in query)
                result.Add(FillRecord(t));
            return result;
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

        public static long Save(Log myLog)
        {
            log t;
            long returncode = -1;
            t = new log();
            t.date = System.DateTime.Now;
            t.@event = myLog.@event;
            db.logs.InsertOnSubmit(t);

            try
            {
                db.SubmitChanges();
                returncode = t.id;
            }
            catch (ChangeConflictException)
            {
                db.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                db.SubmitChanges();
            }
            return t.id;
        }

        /// <summary>
        /// Deletes a specific Log object from the database
        /// </summary>
        /// <param name="id">
        /// the unique identifier of the log to delete
        /// </param>
        /// <returns>
        /// returns true when deleted, false if not
        /// </returns>

        public static bool Delete(long id)
        {
            log t = (from log in db.logs where log.id == id select log).FirstOrDefault();
            if (t != null)
            {
                try
                {
                    db.logs.DeleteOnSubmit(t);
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

        /// <summary>
        /// Deletes all log entries from the database
        /// </summary>
        /// <returns>
        /// Returns nothing
        /// </returns>

        public static void DeleteAll()
        {
            try
            {
                db.logs.DeleteAllOnSubmit(db.logs);
                db.SubmitChanges();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region private methods

        /// <summary>
        /// Build a Log object from the database
        /// </summary>
        /// <param name="i">
        /// the LINQ data object to build from
        /// </param>
        /// <returns>
        /// returns a Log object
        /// </returns>

        private static Log FillRecord(log i)
        {
            Log result = null;
            if (i != null)
            {
                result = new Log();
                result.id = i.id;
                result.date = i.date;
                result.@event = i.@event;
            }
            return result;
        }
        #endregion
    }
}
