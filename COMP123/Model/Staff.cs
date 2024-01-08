using COMP123.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123.Model
{
    public abstract class Staff
    {
        public string Name { get; }
        public string StaffId { get; }
        public string Email { get; }
        public int Role { get; }
        public string Password { get; }
        public bool IsActive { get; }
        public string ManagerId { get; }

        protected Staff(string name, string staffId, string email, int role, string password, string managerId, bool isActive = false)
        {
            this.Name = name;
            this.Email = email;
            this.Role = role;
            this.Password = password;
            this.IsActive = isActive;
            if (FunctionUtil.IsEmptyOrNull(staffId))
            {
                this.StaffId = GenerateId.GenerateIdByNumbers();
            }
            else
            {
                this.StaffId = staffId;
            }
            this.ManagerId = managerId;
        }

        public abstract decimal CalculateSalary(List<AccountEntry> entries);

        public override string ToString()
        {
            return $"Role : {this.Role}, name : {this.Name}, staffId : {this.StaffId}, email : {this.Email}, active: {this.IsActive}";
        }
    }
}
