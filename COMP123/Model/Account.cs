using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123.Model
{
    public class Account : IAccountAction
    {
        public string AccountName { get; }
        public List<Entry> CreditEntryList { get; }
        public List<Entry> DebitEntryList { get; }

        public Account(string name)
        {
            this.AccountName = name;
            CreditEntryList = new List<Entry>();
            DebitEntryList = new List<Entry>();
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
