using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RFID_Read
{
    static class Program
    {
        public static string AppFilePath = string.Empty;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            string appName = Assembly.GetExecutingAssembly().GetName().CodeBase;
            string appPath = Path.GetDirectoryName(appName);
            Program.AppFilePath = appPath;

            Application.Run(new FrmRead());
        }
    }
}