using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDAClient
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control control = sender as Control;
                switch (control.Name)
                {
                    case "txtLoginName":
                        txtPassword.Focus();
                        txtPassword.SelectAll();
                        break;
                    case "txtPassword":
                        btnLogin_Click(sender, e);
                        break;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Get login name
            string loginName = txtLoginName.Text;

            // Get password
            string password = txtPassword.Text;

            if (loginName == string.Empty)
            {
                MessageBox.Show("请输入登录用户名！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                txtLoginName.Focus();
                return;
            }

            if (password == string.Empty)
            {
                MessageBox.Show("请输入密码！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                txtPassword.Focus();
                return;
            }

            // Login system
            FormWebServiceCall frmWebService = new FormWebServiceCall();
            frmWebService.MethodName = "Login";
            frmWebService.Parameters = new object[] { loginName, password };
            frmWebService.ShowDialog();
            frmWebService.Dispose();
            if (!frmWebService.ServiceInvokeOK)
            {
                MessageBox.Show(frmWebService.Exception.Message, "网络通讯", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            bool returnResult = (bool)frmWebService.Results[0];
            if (!returnResult)
            {
                string errorText = (string)frmWebService.Results[2];
                MessageBox.Show(errorText, "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            string userName = (string)frmWebService.Results[1];
            Program.LoginName = loginName;
            Program.UserName = userName;
            Program.LoginTime = DateTime.Now;

            // Save application settings
            Program.SaveAppSettings();

            // Close form
            this.DialogResult = DialogResult.OK;

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Set last login name
            txtLoginName.Text = Program.LoginName;

            // Set focus
            if (txtLoginName.Text == string.Empty)
                txtLoginName.Focus();
            else
                txtPassword.Focus();
        }

        private void MemuConfig_Click(object sender, EventArgs e)
        {
            FormSetup formSetup = new FormSetup();
            formSetup.ShowDialog();
            formSetup.Dispose();


        }

    }


}