using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Data;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using PDAClient.PDAWebService;

namespace PDAClient
{
    public enum ScannerType
    {
        Symbol_MC3000 = 0
    }

    static class Program
    {
        // Application file name
        public static string AppFilePath = string.Empty;
        public static string AppSettingFileName = string.Empty;
        public static string UncheckedVoucherFileName = string.Empty;

        // Default variables
        public const string DefaultServerAddress = "192.158.1.100";
        public const int DefaultPort = 58220;
        public const bool DefaultUseSSL = false;

        // System version number
        public const string VersionNumber = "0.1.1114";

        // Global variables
        public static Guid UserGuid = Guid.Empty;
        public static string UserName = string.Empty;
        public static string LoginName = string.Empty;
        public static DateTime LoginTime = DateTime.Now;

        public const string Confirm_Barcode = "30000";
        public const string Batch_Barcode = "10000";
        public const string Single_Barcode = "20000";

        public static string ServerAddress = DefaultServerAddress;
        public static int Port = DefaultPort;
        public static bool UseSSL = DefaultUseSSL;
        public static ScannerType ActiveScanner = ScannerType.Symbol_MC3000;


        public static DataTable dtRule=new DataTable();

        // Service
        public static PDAService MyPDAService=new PDAService();

        
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            // Set global file name
            string appName = Assembly.GetExecutingAssembly().GetName().CodeBase;
            string appPath = Path.GetDirectoryName(appName);
            Program.AppFilePath = appPath;
            Program.AppSettingFileName = Path.Combine(appPath, "App.xml");
            Program.UncheckedVoucherFileName = Path.Combine(appPath, "Unchecked.xml");

            // Load application settings
            LoadAppSettings();

            // Set web service setting
            Program.MyPDAService.Url = string.Format("http{0}://{1}:{2}/webservice/PDAService.asmx", (Program.UseSSL ? "s" : string.Empty), Program.ServerAddress, Program.Port);

            Program.dtRule.Columns.Add("Number");
            Program.dtRule.Columns.Add("Value");



            Application.Run(new FormMain());
        }

        public static void SaveAppSettings()
        {
            // Build xml document
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<?xml version='1.0' ?><AppSettings/>");
            XmlElement elementServerAddress = doc.CreateElement("ServerAddress");
            XmlElement elementPort = doc.CreateElement("Port");
            XmlElement elementUseSSL = doc.CreateElement("UseSSL");
            XmlElement elementLastLoginName = doc.CreateElement("LastLoginName");

            elementServerAddress.AppendChild(doc.CreateTextNode(Program.ServerAddress.Trim()));
            elementPort.AppendChild(doc.CreateTextNode(Program.Port.ToString().Trim()));
            elementUseSSL.AppendChild(doc.CreateTextNode(Program.UseSSL.ToString()));
            elementLastLoginName.AppendChild(doc.CreateTextNode(Program.LoginName.Trim()));

            doc.DocumentElement.AppendChild(elementServerAddress);
            doc.DocumentElement.AppendChild(elementPort);
            doc.DocumentElement.AppendChild(elementUseSSL);
            doc.DocumentElement.AppendChild(elementLastLoginName);

            // Save xml file
            doc.Save(Program.AppSettingFileName);

            // Set web service setting
            Program.MyPDAService.Url = string.Format("http{0}://{1}:{2}/webservice/PDAService.asmx", (Program.UseSSL ? "s" : string.Empty), Program.ServerAddress, Program.Port);
        }

        public static void LoadAppSettings()
        {
            // Lad xml file
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(Program.AppSettingFileName);
            }
            catch
            {
                return;
            }

            // Get settings
            try
            {
                Program.ServerAddress = doc.DocumentElement["ServerAddress"].InnerText.Trim();
            }
            catch
            {
            }

            try
            {
                Program.Port = int.Parse(doc.DocumentElement["Port"].InnerText.Trim());
            }
            catch
            {
            }

            try
            {
                Program.UseSSL = bool.Parse(doc.DocumentElement["UseSSL"].InnerText.Trim());
            }
            catch
            {
            }

            try
            {
                Program.LoginName = doc.DocumentElement["LastLoginName"].InnerText.Trim();
            }
            catch
            {
            }
        }
    }
}