using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace COMP123.Utility
{
    public static class Logger
    {

        private static string debugPath = ConfigurationManager.AppSettings["infoFilePath"];
        private static string errorPath = ConfigurationManager.AppSettings["errorFilePath"];
        private static StreamWriter sw;
        public static void WriteLog<T>(int logLevel, string type, T logReference)
        {
            string fileName = null;
            string logMessage = null;
            switch (logLevel)
            {
                case 0:
                    fileName = $"{debugPath}InfoLog_{DateTime.Now.ToString(Parameters.LOG_FORMAT)}.txt";
                    logMessage = $"[Info] {DateTime.Now.ToString()} : [Class] {type} - [Info Message] {logReference.ToString()}";
                    break;
                case 1:
                    fileName = $"{errorPath}ErrorLog_{DateTime.Now.ToString(Parameters.LOG_FORMAT)}.txt";
                    logMessage = $"[Error] {DateTime.Now.ToString()} : [Class] {type} - [Error Message] {logReference.ToString()}";
                    break;
                default:
                    break;
            }
            try
            {
                sw = new StreamWriter(fileName, true);
                sw.WriteLine(logMessage);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Fail to open file {fileName} with message : {exception.ToString()}");
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                }
            }
        }
    }
}
