using COMP123.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using static COMP123.Utility.Parameters;

namespace COMP123.Utility
{
    public class GeneralEntryHandler : IEntryHandlerAction
    {
        public List<AccountEntry> RetrieveEnrties(string staffId, DateTime fromDate, DateTime toDate, bool allRecords, int status, string accountName)
        {
            List<AccountEntry> retEntries = FunctionUtil.GetEntries();
            IEnumerable<AccountEntry> generalEntriesQuery = retEntries.Where(entry => entry.EntryDate >= fromDate &&
                                                                        entry.EntryDate < toDate &&
                                                                       (entry.CreateUser == staffId || 
                                                                        entry.ManagerId == staffId));
            if (!allRecords) {
                retEntries = generalEntriesQuery.Where(entry => entry.Status == status).ToList();
            } else {
                retEntries = generalEntriesQuery.ToList();
            };
            return retEntries;
        }
       
    }
}
