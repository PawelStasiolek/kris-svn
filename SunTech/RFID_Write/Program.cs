using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

using HidGlobal.MultiIso.CFReader;
using PsionTeklogix.RFID;

namespace RFID_Write
{
    static class Program
    {
        public static string AppFilePath = string.Empty;
        public static string Mode = string.Empty;

        public static string WebserviceUrl = string.Empty;
        public static string Password = string.Empty;

        public static RFIDDriver rfidDriver = new RFIDDriver();
        public static HID_Reader Reader = null;

        public const string Version = "V1.2";
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

            LoadAppSettings();

            Application.Run(new FrmMain());
        }

        public static void LoadAppSettings()
        {
            // Lad xml file
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(Program.AppFilePath+"\\App.xml");
            }
            catch
            {
                return;
            }

            // Get settings
            try
            {
                Program.WebserviceUrl = doc.DocumentElement["WebserviceUrl"].InnerText.Trim();
            }
            catch
            {
            }

            try
            {
                Program.Password = doc.DocumentElement["Password"].InnerText.Trim();
            }
            catch
            {
            }
        }
    }
}