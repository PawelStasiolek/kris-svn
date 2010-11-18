using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDAClient
{
    public partial class FormDeliver : Form
    {
        private Symbol.Barcode.Reader _MyReader = null;
        private Symbol.Barcode.ReaderData _MyReaderData = null;

        public FormDeliver()
        {
            InitializeComponent();

            StartRead();
        }

        #region 扫描器事件
        private void StartRead()
        {
            try
            {
                // Create new reader, first available reader will be used.
                this._MyReader = new Symbol.Barcode.Reader();

                // Create reader data
                this._MyReaderData = new Symbol.Barcode.ReaderData(
                    Symbol.Barcode.ReaderDataTypes.Text,
                    Symbol.Barcode.ReaderDataLengths.MaximumLabel);

                // Enable reader, with wait cursor
                this._MyReader.Actions.Enable();

                this._MyReader.Parameters.Feedback.Success.BeepTime = 200;

                // Submit a read
                this._MyReader.ReadNotify += new EventHandler(BarReader_ReadNotify);
                this._MyReader.Actions.Read(this._MyReaderData);
            }
            catch
            {
                MessageBox.Show("打开扫描枪失败，请联系技术人员！", "扫描", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void TermReader()
        {
            try
            {
                // If we have a reader
                if (this._MyReader != null)
                {
                    // Disable the reader
                    this._MyReader.Actions.Disable();

                    // Free it up
                    this._MyReader.Dispose();

                    // Indicate we no longer have one
                    this._MyReader = null;
                }

                // If we have a reader data
                if (this._MyReaderData != null)
                {
                    // Free it up
                    this._MyReaderData.Dispose();

                    // Indicate we no longer have one
                    this._MyReaderData = null;
                }
            }
            catch { }
        }

        private void BarReader_ReadNotify(object sender, EventArgs e)
        {

            Symbol.Barcode.ReaderData TheReaderData = this._MyReader.GetNextReaderData();

            //如果扫描成功
            if (TheReaderData.Result == Symbol.Results.SUCCESS)
            {

                txtPallet.Text = TheReaderData.Text;

                this.StartRead();

                btnOk_Click(sender, e);
            }
        }

        #endregion

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control control = sender as Control;
                switch (control.Name)
                {
                    case "txtContainer":
                        txtPallet.Focus();
                        txtPallet.SelectAll();
                        break;
                    case "txtPallet":
                        btnOk_Click(sender, e);
                        break;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Validate bar code, return
            string container = txtContainer.Text.Trim();
            string pallet = txtPallet.Text.Trim();

            if (container == string.Empty)
            {
                MessageBox.Show("请先录入柜号！", "数据检验", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                txtContainer.Focus();
                return;
            }

            if (pallet == string.Empty)
            {
                MessageBox.Show("请先录入或扫描托盘条码！", "数据检验", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                txtPallet.Focus();
                return;
            }

            // upload data
            FormWebServiceCall frmWebService = new FormWebServiceCall();
            frmWebService.MethodName = "DeliverCheck";
            frmWebService.Parameters = new object[] { container,pallet };
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
                MessageBox.Show("托盘号不存在！", "数据上传", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtPallet.Text = "";
                txtPallet.Focus();
                return;
            }

            txtPallet.Text = "";


        }

        private void FormDeliver_Closed(object sender, EventArgs e)
        {
            TermReader();

        }

        
    }
}