using COMP123.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using static COMP123.Utility.Parameters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COMP123.Model
{
    public class AccountEntry
    {
        public string EntryId { get; }
        public DateTime EntryDate { get; private set;  }
        public string Description { get; private set;  }
        public decimal Amount { get; private set;  }
        public int Status { get; private set;}
        public bool IsCredit { get; private set; }
        public string Reason { get; private set; }
        public string Account { get; private set; }
        public DateTime CreateDate { get; }
        public string CreateUser { get; }
        public string ManagerId { get;  }
        public DateTime UpdateDate { get; private set; }
        public string UpdateUser { get; private set; }

        [JsonConstructor]
        public AccountEntry(string entryId, DateTime entryDate, string description, decimal amount, int status,
                            bool isCredit, string reason, string account, DateTime createDate, string createUser,
                            string managerId, DateTime updateDate, string updateUser) {
            this.EntryId = entryId;
            this.EntryDate = entryDate; 
            this.Description = description;
            this.Amount = amount;
            this.Status = status;
            this.IsCredit = isCredit;
            this.Reason = reason;
            this.Account = account;
            this.CreateDate = createDate;
            this.CreateUser = createUser;
            this.ManagerId  = managerId;
            this.UpdateDate = updateDate;
            this.UpdateUser = updateUser;

        }
        public AccountEntry(DateTime entryDate, string description, decimal amount, string createUser, bool isCredit, string account, string entryId , string managerId)
        {
            this.EntryDate = entryDate;
            this.Description = description;
            this.Amount = amount;
            this.Status = (int) RecordStatus.Pending;
            this.CreateDate = DateTime.Now;
            this.CreateUser = createUser;
            this.IsCredit = isCredit;
            this.EntryId = FunctionUtil.IsEmptyOrNull(entryId) ? GenerateId.GenerateIdByNumbers(createUser) : entryId;
            this.Account = account;
            this.ManagerId = managerId;
            this.UpdateDate = DateTime.Now;
            this.UpdateUser = createUser;
        }

        public void SetStatus(int inputStatus, string staffId, string reason = null)
        {
            if (this.ManagerId == staffId) 
            { 
                this.Status = inputStatus;
                this.UpdateDate = DateTime.Now;
                this.UpdateUser = staffId;
                this.Reason = reason;
            }
        }

        public void ResubmitEntry(DateTime entryDate, string description, decimal amount, bool isCredit, string account, string updateUser)
        {
            this.EntryDate = entryDate;
            this.Description = description;
            this.Amount = amount;
            this.Status = (int) RecordStatus.Pending;
            this.IsCredit = isCredit;
            this.Account = account;
            this.UpdateDate = DateTime.Now;
            this.UpdateUser = updateUser;
        }

        public override string ToString()
        {
            return $"Entry Date : {this.EntryDate}, Entry Description : {this.Description}, " +
                   $"Entry Amount : {this.Amount}, Entry status : {(RecordStatus)this.Status}, " +
                   $"Entry create Date : {this.CreateDate}, Entry create user : {this.CreateUser}, " +
                   $"Entry is credit : {this.IsCredit}, Entry id : {this.EntryId}, " +
                   $"Entry account : {this.Account}, Entry update date : {this.UpdateDate}, " +
                   $"Entry update user : {this.UpdateUser}, Entry manager Id : {this.ManagerId}";
        }

        public bool EqualValue(DateTime entryDate, string entryAccount, string entryDesc, decimal amount, bool isCredit, string entryId) {

            if (this == null) {
                return false;
            }

            if (this.EntryId == entryId &&
                this.EntryDate == entryDate &&
                this.Description == entryDesc &&
                this.Amount == amount &&
                this.IsCredit == isCredit &&
                this.Account == entryAccount
            ){
                return true;
            }

            return false;
        }
    }
}
