using COMP123.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace COMP123.Utility
{
    public interface IEntryHandlerAction
    {
        List<AccountEntry> RetrieveEnrties(string staffId, DateTime fromDate, DateTime toDate, bool allRecords, int status, string accountName);
    }
}
