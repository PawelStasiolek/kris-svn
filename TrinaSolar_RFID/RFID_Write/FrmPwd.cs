using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RFID_Write
{
    public partial class FrmPwd : Form
    {
        public FrmPwd()
        {
            InitializeComponent();

            this.Location = new Point((235 - this.Width) / 2, 80);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text.Trim() != Program.Password)
            {
                MessageBox.Show("密码错误!");
                txtPwd.SelectAll();
                txtPwd.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;

        }

        private void FrmPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK_Click(sender, e);
        }
    }
}