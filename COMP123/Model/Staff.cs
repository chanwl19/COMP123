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

        protected Staff(string name, string staffId, string email, int role, string password, bool isActive = false)
        {
            Name = name;
            Email = email;
            Role = role;
            Password = password;
            IsActive = isActive;
            if (string.IsNullOrEmpty(staffId) || string.IsNullOrWhiteSpace(staffId))
            {
                StaffId = GenerateId.GenerateIdByNumbers();
            }
            else
            {
                StaffId = staffId;
            }
        }

        public abstract T GetDashBoardRecords<T>() where T : class, new();

        public override string ToString()
        {
            return $"Role : {this.Role}, name : {this.Name}, staffId : {this.StaffId}, email : {this.Email}, active: {this.IsActive}";
        }
    }
}
