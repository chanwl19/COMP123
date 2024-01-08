using COMP123.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static COMP123.Utility.Parameters;

namespace COMP123.Utility
{
    public static class FunctionUtil
    {

        public static bool IsEmptyOrNull(string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }

        public static bool IsCellEmptyOrNUll(DataGridViewCell cell)
        {
            return cell.Value == null || cell.Value == DBNull.Value || IsEmptyOrNull(cell.Value.ToString());
        }

        public static void CreateFolder(string folderName) { 
            if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
        }

        public static List<AccountEntry> GetEntries() { 
            List<AccountEntry> entries = new List<AccountEntry>();
            string directoryFolder = ConfigurationManager.AppSettings["generalEntryFilePath"];
            Logger.WriteLog((int)LogLevels.Info, "FunctionUtil - GetEntries", $"Start to retrieve data from directory : {directoryFolder}");
            if (Directory.Exists(directoryFolder)) {
                string[] subdirectories = Directory.GetDirectories(directoryFolder);
                Logger.WriteLog((int)LogLevels.Info, "FunctionUtil - GetEntries", $"{directoryFolder} exists and loop through each subfolders");
                foreach (string subdirectory in subdirectories)
                {
                    string filePath = subdirectory + @"\" + ConfigurationManager.AppSettings["generalEntryFile"];
                    Logger.WriteLog((int)LogLevels.Info, "FunctionUtil - GetEntries", $"Get data from file {filePath}");
                    if (File.Exists(filePath))
                    {
                        List<AccountEntry> staffEntries = SerializationHandler.JsonDeserialization<List<AccountEntry>>(filePath);
                        if (staffEntries != null && staffEntries.Count > 0)
                        {
                            entries.AddRange(staffEntries);
                        }
                    }
                }
            }
            Logger.WriteLog((int)LogLevels.Info, "FunctionUtil - GetEntries", $"Finsih to retrieve data from directory : {directoryFolder} with number of records : {entries.Count}");
            return entries;
        }

        public static string GetErrorFromDictionary(Dictionary<string, object> errorDict) {
            string errorString = "";
            foreach (KeyValuePair<string, object> dict in errorDict)
            {
                if (string.Compare(dict.Key, "hasError", true) != 0) { 
                    errorString += dict.Key + " : " + dict.Value + System.Environment.NewLine;
                }
            }

            return errorString;
        }
    }
}
