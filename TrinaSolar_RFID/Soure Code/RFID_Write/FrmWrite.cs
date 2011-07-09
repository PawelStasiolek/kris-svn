using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using HidGlobal.MultiIso.CFReader;
using PsionTeklogix.RFID;
using PsionTeklogix.Sound.Beeper;

namespace RFID_Write
{
    public partial class FrmWrite : Form
    {
        private DataManager dataManager = new DataManager();
        
        private HID_Reader _Reader;
        public HID_Reader Reader
        {
            set { this._Reader = value; }
            get { return _Reader; }
        }

        private string _ModelNo;
        public string ModelNo
        {
            set { this._ModelNo = value; }
            get { return _ModelNo; }
        }

        private string _TagText;
        public string TagText
        {
            set { this._TagText = value; }
            get { return _TagText; }
        }

        public FrmWrite()
        {
            InitializeComponent();
        }

        private void FrmWrite_Load(object sender, EventArgs e)
        {
            this.Text = "组件号: " + ModelNo;

            FillText();
        }

        private void FillText()
        {
            string[] tag_texts = TagText.Split('|');

            textBox2.Text = tag_texts[0];
            textBox3.Text = tag_texts[1];
            textBox5.Text = tag_texts[2];
            textBox6.Text = tag_texts[3];
            textBox10.Text = tag_texts[4];

        }

        #region 将内容写入标签
        /// <summary>
        /// 将字符串写入标签
        /// </summary>
        /// <param name="str">待写入的字符串</param>
        /// <returns></returns>
        private bool WriteRFID(string str, out string returnMsg)
        {
            returnMsg = "";
            string tagID = "";
            string buffer = "";

            //将待写入的字符串转换为16进制
            string hexString = StringToHex(str);

            //共需写入的扇区数
            int blocks = hexString.Length % 8 == 0 ? hexString.Length / 8 : hexString.Length / 8 + 1;

            //每个扇区必须写满4个字节，不足在后面补0
            hexString = hexString.PadRight(blocks * 8, '0');

            //select tag
            Reader.RDR_SendCommandGetData("S", "", ref buffer);
            tagID = buffer;
            if (buffer.Length <= 1)
            {
                returnMsg = "Error: 读取标签失败";
                return false;
            }

            //判断是否已写过数据
            Reader.RDR_SendCommandGetData("rb00", "", ref buffer);
            if (buffer.Length <= 1)
            {
                returnMsg = "Error: 读取标签失败";
                return false;
            }
            if (buffer.Substring(4, 4) == "FFFF")
            {
                DialogResult dialogResult = MessageBox.Show("此标签已写入过数据，是否覆盖原来标签里的内容？", "警告"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (dialogResult == DialogResult.No)
                    return true;
            }

            //00H扇区写入数据所占扇区数
            string block = StringToHex(blocks.ToString()).PadRight(8, 'F');
            Reader.RDR_SendCommandGetData("wb00" + block, "", ref buffer);
            if (buffer.Length <= 1)
            {
                returnMsg = "Error: 写入失败";
                return false;
            }

            //循环写入扇区
            for (int i = 0; i < blocks; i++)
            {
                string txt = "wb" + (i+1).ToString("X2");
                txt += hexString.Substring(i * 8, 8);

                Reader.RDR_SendCommandGetData(txt, "", ref buffer);
                if (buffer.Length <= 1)
                {
                    returnMsg = "Error: 写入失败!";
                    return false;
                }

                Debug.WriteLine("write block:" + (i + 1) + ",total:" + blocks);
            }

            //更新状态栏
            returnMsg = "写入成功 " + hexString.Length / 2 + "bytes";

            //声音提示
            PsionTeklogix.Sound.Beeper.Beeper.PlayTone(10000, 100, 100);

            //写入日志
            dataManager.WriteLog(string.Format("{0},{1},{2},{3}", tagID, ModelNo, DateTime.Now.ToString(), str));

            return true;
        }

        #endregion

        private void btnWrite_Click(object sender, EventArgs e)
        {
            //判断组件是否已写入过标签
            if (dataManager.ModelWrited(ModelNo))
            {
                FrmPwd frmPwd = new FrmPwd();
                frmPwd.ShowDialog();
                frmPwd.Dispose();

                if (frmPwd.DialogResult == DialogResult.Cancel)
                    return;
            }

            btnWrite.Enabled = false;
            btnWrite.Text = "正在写入...";
            statusBar.Text = "";

            string returnMsg = string.Empty;
            bool writeFlag = WriteRFID(TagText, out returnMsg);
            if (writeFlag)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }

            statusBar.Text = returnMsg;

            btnWrite.Enabled = true;
            btnWrite.Text = "写入标签";

        }

        private string StringToHex(string str)
        {
            string hex = "";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            foreach (byte b in bytes)
                hex += b.ToString("X2");

            return hex;
        }

        private void FrmWrite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnWrite_Click(sender, e);
            }
        }

        
    }


}