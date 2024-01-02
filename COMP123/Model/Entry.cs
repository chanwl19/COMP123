using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static COMP123.Utility.Parameters;

namespace COMP123.Model
{
    public class Entry
    {
        public DateTime EntryDate { get; }
        public string Description { get; }
        public decimal Amount { get; }
        public int Status { get; private set; }
        public DateTime CreateDate { get; }
        public string CreateUser { get; }
        public DateTime UpdateDate { get; private set; }
        public string UpdateUser { get; private set; }

        public Entry(DateTime entryDate, string description, decimal amount, string staffId)
        {
            this.EntryDate = entryDate;
            this.Description = description;
            this.Amount = amount;
            this.Status = (int)RecordStatus.Pending;
            this.CreateDate = DateTime.Now;
            this.CreateUser = staffId;
        }

        public void SetStatus(int inputStatus, string staffId)
        {
            this.Status = inputStatus;
            this.UpdateDate = DateTime.Now;
            this.UpdateUser = staffId;
        }
    }
}
