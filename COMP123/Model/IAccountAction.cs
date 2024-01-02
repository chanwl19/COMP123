using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123.Model
{
    public interface IAccountAction
    {
        void AddCreditEntry(Entry entry);
        void AddDebitEntry(Entry entry);
    }
}
