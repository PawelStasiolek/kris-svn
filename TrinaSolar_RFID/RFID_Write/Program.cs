using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace RFID_Write
{
    static class Program
    {
        public static string AppFilePath = string.Empty;
        public static string Mode = string.Empty;

        public static string OPC_Token = string.Empty;
        public static string OPC_WorkShop = string.Empty;
        public static string OPC_Category = string.Empty;
        public static string Password = string.Empty;

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
                Program.OPC_Token = doc.DocumentElement["OPC_Token"].InnerText.Trim();
            }
            catch
            {
            }

            try
            {
                Program.OPC_WorkShop = doc.DocumentElement["OPC_WorkShop"].InnerText.Trim();
            }
            catch
            {
            }

            try
            {
                Program.OPC_Category = doc.DocumentElement["OPC_Category"].InnerText.Trim();
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