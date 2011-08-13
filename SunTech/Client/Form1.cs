using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using OpenNETCF.Desktop.Communication;
using Excel = Microsoft.Office.Interop.Excel;

namespace Client
{
    public partial class Form1 : Form
    {
        private RAPI myrapi = new RAPI();
        private string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        private const string remotePath = "\\Program Files\\RFID Write";

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 连接设备
        /// </summary>
        /// <returns></returns>
        private bool ConnectMobile()
        {
            try
            {
                myrapi.Connect(false, 1);
                if (!myrapi.DevicePresent)
                {
                    myrapi.Dispose();
                    return false;
                }
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private string CheckStatus()
        {

            //检查设备连接情况
            if (!this.ConnectMobile())
                return "设备连接检查：失败";

            //检查是否存在导入的文件
            if (!myrapi.DeviceFileExists(remotePath + "\\write.exe"))
                return "移动设备中未安装RFID程序";

            return string.Empty;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|Excel 97-2003工作簿 (*.xls)|*.xls";
            openFileDialog.Title = "选择Excel文件";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string status = CheckStatus();
            if (status != string.Empty)
            {
                MessageBox.Show(status, "导入警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            btnSync.Text = "正在导入";
            btnSync.Enabled = false;
            btnSync.Invalidate();
            Cursor.Current = Cursors.WaitCursor;

            //Excel的路径
            string filePath = openFileDialog.FileName;
            string csvText = "";

            Excel.Application myExcel = new Excel.ApplicationClass();
            Excel.Workbooks myBooks = myExcel.Application.Workbooks;
            Excel.Workbook myBook = null;
            Excel.Worksheet mySheet = null;

            try
            {

                //打开Excel
                myBook = myBooks.Open(filePath,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing);

                //至少要有一个Sheet
                if (myBook.Worksheets.Count < 1)
                    throw new Exception("在Excel里找不到Sheet");

                mySheet = (Excel.Worksheet)myBook.Worksheets[1];

                int rowCount=mySheet.UsedRange.Rows.Count;
                int colCount=mySheet.UsedRange.Columns.Count;

                //生成csv文件内容
                bool findHead = false;
                for(int row=1;row<=rowCount;row++)
                {
                    if (findHead)
                    {
                        for (int col = 1; col <= colCount; col++)
                            csvText += (mySheet.Cells[row, col] as Excel.Range).Text.ToString().Replace(",", " ") + ",";
                        csvText += Environment.NewLine;
                    }
                    else
                    {
                        if ((mySheet.Cells[row, 1] as Excel.Range).Text.ToString() == "NO.")
                            findHead = true;
                    }
                }

                if (findHead)
                {
                    //生成csv文件
                    StreamWriter sw = new StreamWriter(appPath + "\\tmp.csv", false);
                    sw.Write(csvText);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();

                    //把csv文件移动到手持端
                    myrapi.CopyFileToDevice(appPath + "\\tmp.csv", remotePath + "\\list.csv", true);
                    if (File.Exists(appPath + "\\tmp.csv"))
                        File.Delete(appPath + "\\tmp.csv");

                    MessageBox.Show("恭喜您,导入成功 O(∩_∩)O");

                }
                else
                    MessageBox.Show("导入失败,Excal模板错误!");
            }
            catch (Exception errorExcel)
            {
                MessageBox.Show(errorExcel.Message, "导入警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                //释放Excel
                FreeExcelObject(mySheet);
                myBook.Close(Type.Missing, Type.Missing, Type.Missing);
                FreeExcelObject(myBook);
                FreeExcelObject(myBooks);
                myExcel.Application.Quit();
                FreeExcelObject(myExcel.Application);
            }
            Cursor.Current = Cursors.Default;
            btnSync.Text = "开始导入";
            btnSync.Enabled = true;
        }

        private void FreeExcelObject(Object Obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Obj);
            }
            catch { }
            finally
            {
                Obj = null;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.microsoft.com/downloads/details.aspx?FamilyID=9E641C34-6F7F-404D-A04B-DC09F8141141&displaylang=zh-cn");
        }
    }
}
