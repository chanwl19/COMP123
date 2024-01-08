using COMP123.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using static COMP123.Utility.Parameters;

namespace COMP123.Model
{
    public class Manager : Staff
    {
        public Manager(string name, string staffId, string email, string password, bool isActive) : base(name, staffId, email, (int)(Roles)Roles.Manager, password, null, isActive) { }

        public override decimal CalculateSalary(List<AccountEntry> entries)
        {
            decimal commission = decimal.Zero;
            if (entries != null && entries.Count > 0)
            {
                decimal approvedAmount = entries.Where(entry => entry.Status == (int)RecordStatus.Approved)
                                                .Sum(entry => entry.Amount);
                if (approvedAmount.CompareTo(decimal.Zero) <= 0) approvedAmount = decimal.Zero;
                commission = decimal.Multiply(approvedAmount, Parameters.MANAGER_COMMISSION);
            }
            return decimal.Add(commission, Parameters.MANAGER_BASIC_SALARY);
        }
    }
}
