using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Create folders when program starts
            Directory.CreateDirectory(ConfigurationManager.AppSettings["userFilePath"]);
            Directory.CreateDirectory(ConfigurationManager.AppSettings["infoFilePath"]);
            Directory.CreateDirectory(ConfigurationManager.AppSettings["errorFilePath"]);
            Directory.CreateDirectory(ConfigurationManager.AppSettings["accountFilePath"]);
            Directory.CreateDirectory(ConfigurationManager.AppSettings["generalEntryFilePath"]);
            Application.Run(new LoginForm());
        }
    }
}
