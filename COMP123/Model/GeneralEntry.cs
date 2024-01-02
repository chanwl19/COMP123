using COMP123.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123.Model
{
    public class GeneralEntry : IAccountAction
    {
        public string EntryId { get; }
        public List<Entry> CreditEntryList { get; }
        public List<Entry> DebitEntryList { get; }
        public GeneralEntry(string staffId)
        {
            this.EntryId = GenerateId.GenerateIdByNumbers(staffId);
            this.CreditEntryList = new List<Entry>();
            this.DebitEntryList = new List<Entry>();
        }
        public void AddCreditEntry(Entry entry)
        {
            if (entry != null)
            {
                CreditEntryList.Add(entry);
            }
        }
        public void AddDebitEntry(Entry entry)
        {
            if (entry != null)
            {
                DebitEntryList.Add(entry);
            }
        }
    }
}
