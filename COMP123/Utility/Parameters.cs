using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123.Utility
{
    public class Parameters
    {
        public enum Roles
        {
            Admin = 0,
            Accountant = 1,
            Manager = 2
        }

        public enum LogLevels
        {
            Info = 0,
            Error = 1
        }

        public enum RecordStatus
        {
            Pending = 0,
            Approved = 1,
            Rejected = 2
        }

        public static readonly Dictionary<string, string[]> tableHeader =
            new Dictionary<string, string[]>() {
                { "adminHeader",  new string[] {"Staff ID" , "Name", "Role"} },
                { "accountantHeader", new string[] { "Date", "Account", "Description", "Credit", "Debit" } }
            };

        public const string logFormat = "yyyyMMdd_HH";

        public const string backupFileFormat = "yyyyMMdd_HHmmss";

        public const string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    }
}
