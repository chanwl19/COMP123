using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123.Utility
{
    public static class FunctionUtil
    {

        public static bool isEmptyOrNull(string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }

        public static bool isCellEmptyOrNUll(DataGridViewCell cell)
        {
            return cell.Value == null || cell.Value == DBNull.Value || isEmptyOrNull(cell.Value.ToString());
        }
    }
}
