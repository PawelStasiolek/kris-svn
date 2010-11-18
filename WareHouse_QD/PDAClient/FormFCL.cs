using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDAClient
{
    public partial class FormFCL : Form
    {
        private enum ItemStatus { NeedCheck, Checking, Checked }
        private Symbol.Barcode.Reader _MyReader = null;
        private Symbol.Barcode.ReaderData _MyReaderData = null;

        public FormFCL()
        {
            InitializeComponent();

            // Set data grid font
            dgScaned.Font = this.Font;

            // Set data table
            DataTable dataTable = new DataTable("ScanedList");
            dataTable.Columns.Add("Pallet");
            dataTable.Columns.Add("Product");
            dataTable.Columns.Add("ScanTime");
            dataTable.Columns.Add("ItemStatus");

            // Set grid data source
            dgScaned.DataSource = dataTable;

            // Create grid table style
            DataGridTableStyle tableStyle = new DataGridTableStyle();
            tableStyle.MappingName = "ScanedList";

            // Create grid column style
            DataGridTextBoxColumn columnStyle = new DataGridTextBoxColumn();
            columnStyle.MappingName = "Pallet";
            columnStyle.HeaderText = "托盘号";
            columnStyle.Width = 125;
            columnStyle.NullText = string.Empty;
            tableStyle.GridColumnStyles.Add(columnStyle);

            columnStyle = new DataGridTextBoxColumn();
            columnStyle.MappingName = "Product";
            columnStyle.HeaderText = "产品编号";
            columnStyle.Width = 150;
            columnStyle.NullText = string.Empty;
            tableStyle.GridColumnStyles.Add(columnStyle);

            // Add grid table style to the grid
            dgScaned.TableStyles.Add(tableStyle);

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
                MessageBox.Show("打开扫描枪失败，请联系技术人员！","扫描",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
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

                    if (TheReaderData.Text.Length == 19)
                        txtProduct.Text = TheReaderData.Text;
                    else
                        txtPallet.Text = TheReaderData.Text;

                    this.StartRead();

                    if (txtProduct.Text != string.Empty && txtPallet.Text != string.Empty)
                        AddToBarcodeList(txtPallet.Text.Trim(), txtProduct.Text.Trim());
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
                        txtProduct.Focus();
                        txtProduct.SelectAll();
                        break;
                    case "txtProduct":
                        AddToBarcodeList(txtPallet.Text.Trim(), txtProduct.Text.Trim());
                        break;

                }
            }
        }

        public void EnsureVisible(int rowIndex)
        {
            VScrollBar verticalScrollBar = null;

            // Get vertical scroll bar
            foreach (Control ctrl in dgScaned.Controls)
            {
                if (ctrl.GetType().Name == "VScrollBar")
                {
                    verticalScrollBar = (VScrollBar)ctrl;
                    break;
                }
            }


            if (!verticalScrollBar.Visible)
                return;

            // Get new scroll bar's value
            if (rowIndex < verticalScrollBar.Value)
                verticalScrollBar.Value = rowIndex;
            else if (rowIndex >= verticalScrollBar.Value + verticalScrollBar.LargeChange)
                verticalScrollBar.Value += rowIndex - verticalScrollBar.LargeChange + 1;

        }

        private void AddToBarcodeList(string pallet, string product)
        {
            // Validate bar code, return
            if (txtContainer.Text==string.Empty)
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

            if (product == string.Empty)
            {
                MessageBox.Show("请先录入或扫描产品条码！", "数据检验", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                txtProduct.Focus();
                return;
            }

            foreach (char chPallet in pallet)
            {
                if (!char.IsDigit(chPallet))
                {
                    MessageBox.Show("录入或扫描的托盘条码必须是数字，请检查！", "数据检验", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtPallet.Focus();
                    txtPallet.SelectAll();
                    return;
                }
            }

            foreach (char chProduct in product)
            {
                if (!char.IsDigit(chProduct))
                {
                    MessageBox.Show("录入或扫描的产品条码必须是数字，请检查！", "数据检验", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtProduct.Focus();
                    txtProduct.SelectAll();
                    return;
                }
            }

            char[] products = product.ToCharArray();
            for (int i = 0; i < product.Length; i++)
            {
                DataRow[] rows = Program.dtRule.Select("Number='" + (i + 1) + "'");
                if (rows.Length < 1)
                    continue;

                if (products[i].ToString() != rows[0]["Value"].ToString())
                {
                    MessageBox.Show("条码检验未通过！\n产品条码第" + (i + 1) + "位必须是" + rows[0]["Value"].ToString(), "规则检查", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    // Prepare to next bar code input
                    txtPallet.Text = txtProduct.Text = string.Empty;
                    txtPallet.Focus();

                    return;
                }
            }

            // Get data table
            DataTable dataTable = (DataTable)dgScaned.DataSource;

            //exists same pallet
            if (dataTable.Select("Pallet='" + pallet + "'").Length > 0)
            {
                MessageBox.Show("此托盘号已扫描过，请勿重复扫描！", "规则检查", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                // Prepare to next bar code input
                txtPallet.Text = txtProduct.Text = string.Empty;
                txtPallet.Focus();
                return;
            }

            // Add bar code into data grid to validate
            DataRow newRow = dataTable.NewRow();
            newRow["Pallet"] = pallet;
            newRow["Product"] = product;
            newRow["ScanTime"] = DateTime.Now;
            newRow["ItemStatus"] = ItemStatus.NeedCheck;
            dataTable.Rows.Add(newRow);
            dataTable.AcceptChanges();

            int rowIndex = dataTable.Rows.Count - 1;
            EnsureVisible(rowIndex);
            dgScaned.Select(rowIndex);

            // Redraw
            dgScaned.Invalidate();

            // Prepare to next bar code input
            txtPallet.Text = txtProduct.Text = string.Empty;
            txtPallet.Focus();

        }

        private void dgScaned_CurrentCellChanged(object sender, EventArgs e)
        {
            // Select row
            dgScaned.Select(dgScaned.CurrentRowIndex);

            // Redraw
            dgScaned.Invalidate();
        }

        private void dgScaned_Paint(object sender, PaintEventArgs e)
        {
            int rowIndex=((DataTable)dgScaned.DataSource).Rows.Count;
            lblTotle.Text = "总计：" + rowIndex.ToString();
        }

        private void dgScaned_DoubleClick(object sender, EventArgs e)
        {
            if (dgScaned.CurrentRowIndex < 0)
                return;

            DataTable datatable = (DataTable)dgScaned.DataSource;
            string message = "请确认您要删除的条码\n托盘号：" + datatable.Rows[dgScaned.CurrentRowIndex]["Pallet"].ToString() + "\n产品号：" + datatable.Rows[dgScaned.CurrentRowIndex]["Product"].ToString();
            DialogResult result= MessageBox.Show(message, "删除数据", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                datatable.Rows.RemoveAt(dgScaned.CurrentRowIndex);
                datatable.AcceptChanges();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string continer = txtContainer.Text.Trim();
            if (continer == string.Empty)
            {
                MessageBox.Show("请先录入柜号！", "数据检验", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                txtContainer.Focus();
                return;
            }

            DataTable datatable = (DataTable)dgScaned.DataSource;
            if (datatable.Rows.Count < 1)
            {
                MessageBox.Show("没有数据可以上传！", "数据检验", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;

            }

            DialogResult ok = MessageBox.Show("请注意：上传后的数据将不能修改！", "数据上传", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            if (ok != DialogResult.Yes)
                return;

            // upload data
            FormWebServiceCall frmWebService = new FormWebServiceCall();
            frmWebService.MethodName = "InsertBarcode";
            frmWebService.Parameters = new object[] { datatable, continer, Program.LoginName };
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
                string errorText = (string)frmWebService.Results[1];
                MessageBox.Show(errorText, "数据上传", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtPallet.Focus();
                return;
            }

            // upload successed
            MessageBox.Show("上传数据成功！", "数据上传", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            txtContainer.Text = string.Empty;
            txtPallet.Text = string.Empty;
            txtProduct.Text = string.Empty;
            txtContainer.Focus();

            // Get data table
            DataTable dataTable = (DataTable)dgScaned.DataSource;
            dataTable.Clear();
            dataTable.AcceptChanges();
            dgScaned.Invalidate();

        }

        private void FormFCL_Closed(object sender, EventArgs e)
        {
            TermReader();

        }

    }


}