using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using HidGlobal.MultiIso.CFReader;
using PsionTeklogix.RFID;
using PsionTeklogix.WorkAboutPro;

namespace RFID_Read
{
    public partial class FrmWelcome : Form
    {

        public FrmWelcome()
        {
            InitializeComponent();

            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

            //打开一个新的线程用来初始RFID操作
            System.Threading.Thread threadInit = new System.Threading.Thread(InitRFID);
            threadInit.IsBackground = true;
            threadInit.Start();
        }

        #region 初始化RFID模块()
        private void InitRFID()
        {

            try
            {
                //先给USB供电
                WorkAboutPro wap = new WorkAboutPro();
                wap.ExpansionUSB_EnablePower(true);
                System.Threading.Thread.Sleep(100);

                //检查RFID驱动是否安装
                if (!Program.rfidDriver.IsInstalled)
                    throw new Exception("RFID驱动未安装!");

                Program.rfidDriver.Enable();

                //打开COM端口
                Program.Reader = new HID_Reader();
                HID_Reader.presetSettings settings = new HID_Reader.presetSettings();
                settings.protocol = 0; // ASCII
                settings.baudRate = 9600; // 9600 bd

                if (Program.Reader.RDR_OpenSingle(string.Format("COM{0}:", Program.rfidDriver.ComPort), 2, 0, settings) <= 0)
                    throw new Exception("打开RFID端口失败，请重新运行程序");

                Program.Reader.RDR_AbortContinuousReadExt();

            }
            catch (Exception initRfidError)
            {
                MessageBox.Show(initRfidError.Message, "Init RFID error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                
                this.Invoke((EventHandler)delegate
                {
                    this.DialogResult = DialogResult.Cancel;
                });
            }

            this.Invoke((EventHandler)delegate
            {
                this.DialogResult = DialogResult.OK;
            });

        }
        #endregion
    }
}