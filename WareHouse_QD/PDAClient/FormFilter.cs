using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDAClient
{
    public partial class FormFilter : Form
    {
        public FormFilter()
        {
            InitializeComponent();
        }

        private void FormFilter_Load(object sender, EventArgs e)
        {
            UpdateRuleList();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control control = sender as Control;
                switch (control.Name)
                {
                    case "txtNum":
                        txtValue.Focus();
                        txtValue.SelectAll();
                        break;
                    case "txtValue":
                        AddFilter(txtNum.Text.Trim(), txtValue.Text.Trim());
                        break;
                }
            }
        }

        private void AddFilter(string number, string value)
        {
            if (number == string.Empty)
            {
                MessageBox.Show("请录入位数！", "条码规则设定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtNum.Focus();
                return;
            }

            if (value == string.Empty)
            {
                MessageBox.Show("请录入数值！", "条码规则设定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtValue.Focus();
                return;
            }

            foreach (char chNum in number)
            {
                if (!char.IsDigit(chNum))
                {
                    MessageBox.Show("录入的必须是数字，请检查！", "条码规则设定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtNum.Focus();
                    txtNum.SelectAll();
                    return;
                }
            }

            foreach (char chvalue in value)
            {
                if (!char.IsDigit(chvalue))
                {
                    MessageBox.Show("录入的必须是数字，请检查！", "条码规则设定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtValue.Focus();
                    txtValue.SelectAll();
                    return;
                }
            }

            bool update = false;
            foreach (DataRow row in Program.dtRule.Rows)
            {
                if (row["Number"].ToString() == number)
                {
                    row["Value"] = value;
                    Program.dtRule.AcceptChanges();
                    update = true;
                    break;
                }
            }

            if (!update)
            {
                DataRow newRow = Program.dtRule.NewRow();
                newRow["Number"] = number;
                newRow["Value"] = value;
                Program.dtRule.Rows.Add(newRow);
                Program.dtRule.AcceptChanges();
            }

            UpdateRuleList();

        }

        private void UpdateRuleList()
        {
            lstRule.Items.Clear();
            
            foreach (DataRow row in Program.dtRule.Rows)
                lstRule.Items.Add("第" + row["Number"].ToString() + "位" + row["Value"].ToString());

            lstRule.SelectedIndex = lstRule.Items.Count - 1;

            //ready to next rule
            txtNum.Text = txtValue.Text = string.Empty;
            txtNum.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddFilter(txtNum.Text.Trim(), txtValue.Text.Trim());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstRule.SelectedIndex < 0)
            {
                MessageBox.Show("请在左边选择需要移除的规则！", "条码规则设定",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                return;
            }

            Program.dtRule.Rows.RemoveAt(lstRule.SelectedIndex);
            Program.dtRule.AcceptChanges();
            UpdateRuleList();
        }
    }
}