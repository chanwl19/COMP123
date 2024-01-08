using COMP123.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static COMP123.Utility.Parameters;

namespace COMP123.Utility
{
    public class AccountEntryHandler : IEntryHandlerAction
    {
        public List<AccountEntry> RetrieveEnrties(string staffId, DateTime fromDate, DateTime toDate, bool allRecords, int status, string accountName)
        {
            List<AccountEntry> retEntries = new List<AccountEntry> ();
            retEntries = FunctionUtil.GetEntries();
            IEnumerable<AccountEntry> accountEntriesQuery =
                retEntries.Where(entry => entry.EntryDate >= fromDate &&
                                          entry.EntryDate < toDate &&
                                          entry.Account == accountName &&
                                         (entry.CreateUser == staffId || entry.ManagerId == staffId));

            if (!allRecords){
                retEntries = accountEntriesQuery.Where(entry => entry.Status == status).ToList();
            } else {
                retEntries = accountEntriesQuery.ToList();
            };
            return retEntries;
        }
    }
}
