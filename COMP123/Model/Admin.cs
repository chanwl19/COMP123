using COMP123.Utility;
using System;
using System.Collections.Generic;
using static COMP123.Utility.Parameters;

namespace COMP123.Model
{
    public class Admin : Staff
    {
        public Admin(string name, string staffId, string email, string password, bool isActive) : base(name, staffId, email, (int)(Roles)Roles.Admin, password, null,isActive) { }

        public override decimal CalculateSalary(List<AccountEntry> entries = null)
        {
            return Parameters.ADMIN_BASIC_SALARY;
        }
    }
}
