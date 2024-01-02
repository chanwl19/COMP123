using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123.Utility
{
    public static class GenerateId
    {

        static Random rand = new Random();
        public static string GenerateIdByNumbers(string staffId = null)
        {
            string generatedId = DateTime.Now.Year.ToString();
            if (string.IsNullOrEmpty(staffId))
            {
                generatedId = generatedId.Substring(2, 2);
                generatedId += rand.Next(1, 10000).ToString().PadLeft(4, '0');
            }
            else
            {
                generatedId += staffId + rand.Next(1, 10000).ToString().PadLeft(4, '0');
            }
            int checkDigit = GetCheckSum(generatedId);
            generatedId += checkDigit;
            return generatedId;
        }

        public static int GetCheckSum(string sequence)
        {
            int sum = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (i % 2 != 0)
                {
                    sum += (int)sequence[i];
                }
            }
            return (sum % 10 == 0) ? 0 : 10 - (sum % 10);
        }
    }
}
