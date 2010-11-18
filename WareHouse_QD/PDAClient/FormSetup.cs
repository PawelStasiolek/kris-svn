using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDAClient
{
    public partial class FormSetup : Form
    {
        public FormSetup()
        {
            InitializeComponent();
        }

        private void chkUseSSL_Click(object sender, EventArgs e)
        {

        }

        private void FormSetup_Load(object sender, EventArgs e)
        {
            txtServerAddress.Text = Program.ServerAddress;
            txtPort.Text = Program.Port.ToString();
            chkUseSSL.Checked = Program.UseSSL;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtServerAddress.Text = Program.DefaultServerAddress;
            txtPort.Text = Program.DefaultPort.ToString();
            chkUseSSL.Checked = Program.DefaultUseSSL;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Date validation
            string serverAddress = txtServerAddress.Text.Trim();
            if (serverAddress == string.Empty)
            {
                MessageBox.Show("请正确输入服务器地址！", "系统设置", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                txtServerAddress.Focus();
                return;
            }

            int port = 0;
            try
            {
                port = int.Parse(txtPort.Text);
                if (port <= 0)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("请正确输入端口号！", "系统设置", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                txtPort.Focus();
                return;
            }

            // Update global variables
            Program.ServerAddress = serverAddress;
            Program.Port = port;
            Program.UseSSL = chkUseSSL.Checked;
            Program.SaveAppSettings();

            this.DialogResult=DialogResult.OK;
        }
    }
}