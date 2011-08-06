using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

using HidGlobal.MultiIso.CFReader;
using PsionTeklogix.RFID;
using PsionTeklogix.Sound.Beeper;

namespace RFID_Read
{
    public partial class FrmRead : Form
    {
        Thread threadRead;

        public delegate void delegateWrite(string str);
        public delegate void delegateReset();

        public FrmRead()
        {
            InitializeComponent();

            FrmWelcome frmWelcome = new FrmWelcome();
            DialogResult dialoResult = frmWelcome.ShowDialog();
            if (dialoResult == DialogResult.OK)
            {
                threadRead = new Thread(ReadTag);
                threadRead.IsBackground = true;
                threadRead.Start();
            }
            else
                Application.Exit();

        }

        private void WriteText(string str)
        {
            string[] tag_texts = str.Split('|');
            if (tag_texts.Length != 10)
                throw new Exception("Data in tag is error");

            textBox1.Text = tag_texts[0];
            textBox2.Text = tag_texts[1];
            textBox3.Text = tag_texts[2];
            textBox4.Text = tag_texts[3];
            textBox5.Text = tag_texts[4];
            textBox6.Text = tag_texts[5];
            textBox7.Text = tag_texts[6];
            textBox8.Text = tag_texts[7];
            textBox9.Text = tag_texts[8];
            textBox10.Text = tag_texts[9];

            try
            {
                //显示相应图片
                string moduleNo = tag_texts[2].Substring(0, tag_texts[2].IndexOf("/"));
                string pictureFile = Program.AppFilePath + "\\Img\\" + moduleNo + ".jpg";

                Bitmap bmp = new Bitmap(pictureFile);
                pbx.Width = bmp.Width;
                pbx.Height = bmp.Height;
                pbx.Image = Image.FromHbitmap(bmp.GetHbitmap());
            }
            catch
            {
                pbx.Image = null;
            }

        }

        private string HexToString(string str)
        {
            if (str.Length % 2 != 0)
                return null;

            byte[] bytes = new byte[str.Length / 2];
            string tmp = "";

            for (int i = 0; i < str.Length / 2; i++)
            {
                tmp = str.Substring(i * 2, 2);
                bytes[i] = Convert.ToByte(tmp, 16);
            }
            return System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        private void ReadTag()
        {
            string tagID = "";
            string oldTagID = "";

            while (true)
            {
                Program.Reader.RDR_AbortContinuousRead();
                string text = "";
                string buffer = "";
                int blocks = 0;

                //前一次扫描的TagID
                oldTagID = tagID;

                //本次扫描的TagID
                Program.Reader.RDR_SendCommandGetData("S", "", ref buffer);
                tagID = buffer;

                //未找到标签
                if (buffer.Length <= 1)
                    continue;

                //读取00H扇区数据，存放的是内容占用扇区数
                Program.Reader.RDR_SendCommandGetData("rb00", "", ref buffer);

                //读取00H扇区失败，TagID清空，以便下次扫描正确可以发声
                if (buffer.Length <= 1)
                {
                    tagID = "";
                    continue;
                }

                try
                {
                    blocks = int.Parse(HexToString(buffer.Substring(0, 4)));
                    string txt = "";

                    //从01H开始循环读取每个扇区
                    for (int i = 0; i < blocks; i++)
                    {
                        txt = "rb" + (i + 1).ToString("X2");

                        Program.Reader.RDR_SendCommandGetData(txt, "", ref buffer);
                        if (buffer.Length <= 1)
                            break;

                        Debug.WriteLine("Read Block:" + (i + 1).ToString() + ", Total:" + blocks);
                        text += buffer;
                    }

                    //校验读出数据是否完整
                    if (text.Length / 8 != blocks)
                    {
                        //TagID清空，以便下次扫描正确可以发声

                        tagID = "";
                        continue;
                    }

                    //将数据写到界面上
                    this.Invoke(new delegateWrite(WriteText), HexToString(text));

                    //声音提示
                    if (oldTagID != tagID)
                        PsionTeklogix.Sound.Beeper.Beeper.PlayTone(10000, 200, 100);
                }

                catch(Exception errorRead) 
                {
                    MessageBox.Show(errorRead.Message);
                }

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            threadRead.Abort();
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        private void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";

            pbx.Image = null;

        }

        private void FrmRead_Closing(object sender, CancelEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            threadRead.Abort();
            Program.Reader.RDR_CloseReader();
            Program.Reader.RDR_CloseComm();
            Program.Reader = null;
            Program.rfidDriver.Disable();

            Cursor.Current = Cursors.Default;
        }
    }
}