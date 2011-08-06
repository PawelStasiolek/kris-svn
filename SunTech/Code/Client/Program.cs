using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        public const string Version = "V1.0";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
