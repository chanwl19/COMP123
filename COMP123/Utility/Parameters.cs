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

        public const string LOG_FORMAT = "yyyyMMdd_HH";

        public const string ENTRY_FOLDER_FORMAT = "yyyyMM";

        public const string MONTH_OPTION_FORMAT = "MMM-yyyy";

        public const string BACKUP_FILE_FORMAT = "yyyyMMdd_HHmmss";

        public const string EMAIL_REGEX = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        public const decimal MANAGER_COMMISSION = 0.0015m;

        public const decimal ACCOUNTANT_COMMISSION = 0.0012m;

        public const decimal MANAGER_BASIC_SALARY = 6000m;

        public const decimal ACCOUNTANT_BASIC_SALARY = 5000m;

        public const decimal ADMIN_BASIC_SALARY = 4000m;

        public static readonly string[] ADMIN_HEADERS = new string[] {"Staff ID", "Name", "Role" };

        public static readonly string[] ACCOUNT_HEADERS = new string[] { "Date", "Account", "Description", "Credit", "Debit","Status","Comment" };

        public static readonly string[] MANAGER_HEADERS = new string[] { "Select", "Date", "Staff", "Account", "Description", "Credit", "Debit", "Status", "Comment" };
    }
}
