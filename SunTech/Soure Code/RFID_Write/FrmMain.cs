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
        private DataManager dataManager = new DataManager();

        public FrmMain()
        {
            InitializeComponent();
            this.Text = "移动RFID系统 " + Program.Version;

            FrmWelcome frmWelcome = new FrmWelcome();
            DialogResult dialoResult = frmWelcome.ShowDialog();
            if (dialoResult == DialogResult.OK)
                menuOnline_Click(this, EventArgs.Empty);
            else
                Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string information = "";
            string returnMsg="";
            bool overWrited = false;

            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("请扫描组件条码!");
                txtCode.SelectAll();
                txtCode.Focus();
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            //在线方式获取数据
            if (Program.Mode == "online")
                information = dataManager.GetDataFromOnline(txtCode.Text.Trim(), out returnMsg, out overWrited);
            //本地获取数据
            else
                information = dataManager.GetDataFromLocal(txtCode.Text.Trim(), out returnMsg, out overWrited);

            Cursor.Current = Cursors.Default;

            if (returnMsg != string.Empty)
            {
                MessageBox.Show(returnMsg,"错误",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                txtCode.SelectAll();
                txtCode.Focus();
                return;
            }

            //如果这个条码已写入过标签则需要弹出验证信息
            if (overWrited)
            {
                FrmPwd frmPwd = new FrmPwd();
                frmPwd.ShowDialog();
                frmPwd.Dispose();

                //取消验证
                if (frmPwd.DialogResult == DialogResult.Cancel)
                {
                    txtCode.Text = "";
                    txtCode.Focus();
                    return;
                }
            }

            FrmWrite frm = new FrmWrite();
            frm.TagText = information;
            frm.ModelNo = txtCode.Text.Trim();
            frm.ShowDialog();

            txtCode.Text = "";
            txtCode.Focus();
        }

        private void FrmMain_Closing(object sender, CancelEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Program.Reader.RDR_CloseReader();
            Program.Reader.RDR_CloseComm();
            Program.Reader = null;
            Program.rfidDriver.Disable();

            Cursor.Current = Cursors.Default;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnOK_Click(sender,e);
                    break;
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

            lblMode.Text = "当前模式: " + menuLocal.Text;
        }

        private void menuOnline_Click(object sender, EventArgs e)
        {
            Program.Mode = "online";
            menuOnline.Checked = true;
            menuLocal.Checked = false;

            lblMode.Text = "当前模式: " + menuOnline.Text;
        }

    }
}