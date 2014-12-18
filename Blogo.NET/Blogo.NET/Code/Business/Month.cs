using System.ComponentModel;
using System.Collections.Generic;

using Blogo.NET.Data.Access;

namespace Blogo.NET.Business
{

    /// <summary>
    /// Business Object class for Months.
    /// </summary>

    public class Month
    {
        public Month(int y, int m)
        {
            year = y;
            month = m;
        }

        #region properties
        public int year { get; set; }
        public int month { get; set; }
        #endregion
    }
}
