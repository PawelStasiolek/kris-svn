using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using HidGlobal.MultiIso.CFReader;
using PsionTeklogix.RFID;
using PsionTeklogix.WorkAboutPro;

namespace RFID_Write
{
    public partial class FrmMain : Form
    {
        private RFIDDriver rfidDriver = new RFIDDriver();
        private HID_Reader Reader = null;
        private DataManager dataManager = new DataManager();

        public FrmMain()
        {
            InitializeComponent();

            string initflag = InitRFID();
            if (initflag != string.Empty)
            {
                MessageBox.Show(initflag, "Init RFID error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                Application.Exit();
            }

            menuLocal_Click(this, EventArgs.Empty);
        }

        #region 初始化RFID模块()
        private string InitRFID()
        {

            try
            {
                //先给USB供电
                WorkAboutPro wap = new WorkAboutPro();
                wap.ExpansionUSB_EnablePower(true);
                System.Threading.Thread.Sleep(100);

                //检查RFID驱动是否安装
                if (!rfidDriver.IsInstalled)
                    throw new Exception("RFID驱动未安装!");

                rfidDriver.Enable();

                //打开COM端口
                Reader = new HID_Reader();
                HID_Reader.presetSettings settings = new HID_Reader.presetSettings();
                settings.protocol = 0; // ASCII
                settings.baudRate = 9600; // 9600 bd

                if (Reader.RDR_OpenSingle(string.Format("COM{0}:", rfidDriver.ComPort), 2, 0, settings) <= 0)
                    throw new Exception("打开RFID端口失败，请重新运行程序");

                Reader.RDR_AbortContinuousReadExt();

            }
            catch (Exception initRfidError)
            {
                return initRfidError.Message;
            }

            return string.Empty;

        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            string information = "";
            string returnMsg="";

            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("请扫描或输入组件号!");
                txtCode.SelectAll();
                txtCode.Focus();
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            //从OPC获取信息
            if (Program.Mode=="online")
                information = dataManager.GetDataFromOpc(txtCode.Text.Trim(), out returnMsg);
            //从本地获取信息
            else
                information = dataManager.GetDataFromCSV(txtCode.Text.Trim(), out returnMsg);

            Cursor.Current = Cursors.Default;

            if (returnMsg != string.Empty)
            {
                MessageBox.Show(returnMsg);
                txtCode.SelectAll();
                txtCode.Focus();
                return;
            }

            FrmWrite frm = new FrmWrite();
            frm.Reader = Reader;
            frm.TagText = information;
            frm.ModelNo = txtCode.Text.Trim();
            frm.ShowDialog();

            txtCode.Text = "";
            txtCode.Focus();
        }

        private void FrmMain_Closing(object sender, CancelEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Reader.RDR_CloseReader();
            Reader.RDR_CloseComm();
            Reader = null;
            rfidDriver.Disable();

            Cursor.Current = Cursors.Default;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }

        private void rbtOnline_CheckedChanged(object sender, EventArgs e)
        {
            Program.Mode = "online";
            txtCode.SelectAll();
            txtCode.Focus();
        }

        private void rbtLocal_CheckedChanged(object sender, EventArgs e)
        {
            Program.Mode = "local";
            txtCode.SelectAll();
            txtCode.Focus();

        }

        private void menuLocal_Click(object sender, EventArgs e)
        {
            Program.Mode = "local";
            menuLocal.Checked = true;
            menuOnline.Checked = false;

            lblMode.Text = "查询模式: "+menuLocal.Text;
        }

        private void menuOnline_Click(object sender, EventArgs e)
        {
            Program.Mode = "online";
            menuOnline.Checked = true;
            menuLocal.Checked = false;

            lblMode.Text = "查询模式: " + menuOnline.Text;
        }

    }
}