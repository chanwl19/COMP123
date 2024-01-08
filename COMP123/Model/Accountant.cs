using COMP123.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using static COMP123.Utility.Parameters;

namespace COMP123.Model
{
    public class Accountant : Staff
    {
        public Accountant(string name, string staffId, string email, string password, string managerId, bool isActive) : base(name, staffId, email, (int)(Roles)Roles.Accountant, password, managerId, isActive) { }

        public override decimal CalculateSalary(List<AccountEntry> entries)
        {
            decimal commission = decimal.Zero;
            if (entries != null && entries.Count > 0)
            {
                decimal approvedAmount = entries.Where(entry => entry.Status == (int)RecordStatus.Approved)
                                                .Sum(entry => entry.Amount);
                decimal rejectedAmount = entries.Where(entry => entry.Status == (int)RecordStatus.Rejected)
                                                .Sum(entry => entry.Amount);
                decimal awardedAmount = decimal.Subtract(approvedAmount, rejectedAmount);
                if (awardedAmount.CompareTo(decimal.Zero) <= 0) awardedAmount = decimal.Zero;
                commission = decimal.Multiply(awardedAmount, Parameters.ACCOUNTANT_COMMISSION);
            }
            return decimal.Add(commission, Parameters.ACCOUNTANT_BASIC_SALARY);
        }
    }
}
