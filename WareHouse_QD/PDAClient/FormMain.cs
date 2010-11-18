using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDAClient
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Show self
            this.Visible = true;

            // Show pre-login form
            FormLogin frmPreLogin = new FormLogin();
            frmPreLogin.ShowDialog();
            frmPreLogin.Dispose();
            if (frmPreLogin.DialogResult != DialogResult.OK)
            {
                // Close main menu form and quit system
                Close();
                return;
            }

            statusBar1.Text = string.Format("当前用户:{0}     版本:{1}", Program.UserName,Program.VersionNumber); 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定退出系统？", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                // Close main menu form, quit system
                Close();

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FormFilter formFilter = new FormFilter();
            formFilter.ShowDialog();
            formFilter.Dispose();
        }

        private void btnFCL_Click(object sender, EventArgs e)
        {
            FormFCL formFcl = new FormFCL();
            formFcl.ShowDialog();
            formFcl.Dispose();
        }

        private void btnDeliver_Click(object sender, EventArgs e)
        {
            FormDeliver formDeliver = new FormDeliver();
            formDeliver.ShowDialog();
            formDeliver.Dispose();

        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            FormStockIn formStockIn = new FormStockIn();
            formStockIn.ShowDialog();
            formStockIn.Dispose();

        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            CreateGraphics().DrawRectangle(new Pen(Color.Black), new Rectangle((sender as PictureBox).Left - 1, (sender as PictureBox).Top - 1, (sender as PictureBox).Width + 1, (sender as PictureBox).Height + 1));
        }

        private void picBox_Check_Click(object sender, EventArgs e)
        {
            FormInventory formInventory = new FormInventory();
            formInventory.ShowDialog();
            formInventory.Dispose();
        }
    }
}