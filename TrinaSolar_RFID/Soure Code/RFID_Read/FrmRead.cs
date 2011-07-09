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
using PsionTeklogix.WorkAboutPro;

namespace RFID_Read
{
    public partial class FrmRead : Form
    {
        private RFIDDriver rfidDriver = new RFIDDriver();
        private HID_Reader Reader = null;

        Thread threadRead;
        public delegate void delegateWrite(string str);
        public delegate void delegateReset();

        public FrmRead()
        {
            InitializeComponent();

            string initflag = InitRFID();
            if (initflag != string.Empty)
            {
                MessageBox.Show(initflag, "into RFID failed", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                Application.Exit();
                return;
            }

            threadRead = new Thread(ReadTag);
            threadRead.Start();
        }

        #region 初始化RFID模块()
        private string InitRFID()
        {

            try
            {
                //先给USB供电
                WorkAboutPro wap = new WorkAboutPro();
                wap.ExpansionUSB_EnablePower(true);
                System.Threading.Thread.Sleep(100);

                //检查RFID驱动是否安装
                if (!rfidDriver.IsInstalled)
                    throw new Exception("RFID驱动未安装!");

                rfidDriver.Enable();

                //打开COM端口
                Reader = new HID_Reader();
                HID_Reader.presetSettings settings = new HID_Reader.presetSettings();
                settings.protocol = 0; // ASCII
                settings.baudRate = 9600; // 9600 bd

                if (Reader.RDR_OpenSingle(string.Format("COM{0}:", rfidDriver.ComPort), 2, 0, settings) <= 0)
                    throw new Exception("打开RFID端口失败，请重新运行程序");

                Reader.RDR_AbortContinuousReadExt();

            }
            catch (Exception initRfidError)
            {
                return initRfidError.Message;
            }

            return string.Empty;

        }
        #endregion

        private void WriteText(string str)
        {
            string[] tag_texts = str.Split('|');
            if (tag_texts.Length != 5)
                throw new Exception("Data in tag is error");

            textBox2.Text = tag_texts[0];
            textBox3.Text = tag_texts[1];
            textBox5.Text = tag_texts[2];
            textBox6.Text = tag_texts[3];
            textBox10.Text = tag_texts[4];

            //显示相应图片
            string pictureFile = Program.AppFilePath + "\\Img\\" + tag_texts[0] + ".jpg";
            try
            {
                if (File.Exists(pictureFile))
                {
                    Bitmap bmp = new Bitmap(pictureFile);
                    pbx.Image = Image.FromHbitmap(bmp.GetHbitmap());
                }
                else
                    pbx.Image = null;
            }
            catch { }

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
                Reader.RDR_AbortContinuousRead();
                string text = "";
                string buffer = "";
                int blocks = 0;

                //前一次扫描的TagID
                oldTagID = tagID;

                //本次扫描的TagID
                Reader.RDR_SendCommandGetData("S", "", ref buffer);
                tagID = buffer;

                //未找到标签
                if (buffer.Length <= 1)
                    continue;

                //读取00H扇区数据，存放的是内容占用扇区数
                Reader.RDR_SendCommandGetData("rb00", "", ref buffer);

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

                        Reader.RDR_SendCommandGetData(txt, "", ref buffer);
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
                        PsionTeklogix.Sound.Beeper.Beeper.PlayTone(10000, 100, 100);
                }

                catch(Exception errorRead) 
                {
                    MessageBox.Show("Data in tag is error");
                }

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            threadRead.Abort();
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        private void Reset()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox10.Text = "";

        }

        private void FrmRead_Closing(object sender, CancelEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            threadRead.Abort();
            Reader.RDR_CloseReader();
            Reader.RDR_CloseComm();
            Reader = null;
            rfidDriver.Disable();

            Cursor.Current = Cursors.Default;
        }
    }
}