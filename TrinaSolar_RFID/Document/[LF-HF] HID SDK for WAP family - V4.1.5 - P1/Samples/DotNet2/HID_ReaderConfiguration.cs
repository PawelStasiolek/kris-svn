using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using HidGlobal.MultiIso.CFReader;

namespace PsionTeklogixRFIDDemoApplications
{
	/// <summary>
	/// Summary description for fTagSYSReader.
	/// </summary>
	public class HID_ReaderConfiguration : System.Windows.Forms.Form
	{
        private HID_Reader Reader = null; 
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;

		private string ComPort ;
		public HID_ReaderConfiguration(string ComPort)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.ComPort = ComPort;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(8, 128);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(224, 114);
            this.listBox1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "Version reader";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(160, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 24);
            this.button2.TabIndex = 9;
            this.button2.Text = "Clear";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(120, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 24);
            this.button3.TabIndex = 8;
            this.button3.Text = "DLL Version ";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 40);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 24);
            this.button4.TabIndex = 6;
            this.button4.Text = "Get";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(56, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.Text = "Baud Rate";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button5.Location = new System.Drawing.Point(120, 40);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 24);
            this.button5.TabIndex = 4;
            this.button5.Text = "Get";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(168, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.Text = "Cont receive";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button6.Location = new System.Drawing.Point(8, 64);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 24);
            this.button6.TabIndex = 2;
            this.button6.Text = "Get";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(56, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.Text = "Protocol";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button7.Location = new System.Drawing.Point(120, 64);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(40, 24);
            this.button7.TabIndex = 0;
            this.button7.Text = "Get";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(168, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.Text = "Timeout";
            // 
            // HID_ReaderConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 295);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.MinimizeBox = false;
            this.Name = "HID_ReaderConfiguration";
            this.Text = "Reader Configuration";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.fTagSYSReader_Closing);
            this.Load += new System.EventHandler(this.fTagSYSReader_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void fTagSYSReader_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Reader.RDR_CloseReader();
            Reader.RDR_CloseComm();
		}

		private void fTagSYSReader_Load(object sender, System.EventArgs e)
		{
            Reader = new HID_Reader();
			//open port com 1, baud rate : 9600
            HID_Reader.presetSettings PS = new HID_Reader.presetSettings();
			PS.baudRate = 9600;
			PS.protocol = 0;

            if (Reader.RDR_OpenComm(ComPort, 1, PS) != 0)
			{
				this.listBox1.Items.Add ("open port com (" + ComPort + ")");
			}
			else
			{
				//Error during Open port com
				this.listBox1.Items.Add ("Error during open port com");
				return;
			}

            if (Reader.RDR_OpenReader((byte)Reader.RDR_DetectReader(), 0) != 0)
			{
				this.listBox1.Items.Add ("open reader");
			}
			else
			{
				this.listBox1.Items.Add ("Error during open reader");
			}

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
                string Buffer = "";
                Reader.RDR_AbortContinuousRead();
                Reader.RDR_SendCommandGetData("version", "", ref Buffer);
				this.listBox1.Items.Add("Version Reader : " + Buffer);
			}
			catch (Exception ex)
			{
				this.listBox1.Items.Add(ex.Message);
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.listBox1.Items.Clear();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
//			string Version = Reader.GetDLLVersion().ToString();
//			this.listBox1.Items.Add("DLL Version : " + Version.Substring(0,1) + "." + Version.Substring(1,1) + "." + Version.Substring(2,1));
            string Version = "";
            Reader.RDR_GetDLLVersionStr(ref Version);
			this.listBox1.Items.Add("DLL Version : " + Version);

		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			Reader.RDR_AbortContinuousRead();
			this.listBox1.Items.Add("Baud Rate : " + Reader.RDR_GetCommBaudRate().ToString() + " bd");
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			Reader.RDR_AbortContinuousRead();
			string Result;
            if (Reader.RDR_GetCommContRcv() != 0)
				Result = "Active";
			else
				Result = "Not active";
			this.listBox1.Items.Add("Continuous receive mode : " + Result);
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			Reader.RDR_AbortContinuousRead();
			string Result;
            if (Reader.RDR_GetCommContRcv() != 0)
				Result = "BIN";
			else
				Result = "ASCII";

			this.listBox1.Items.Add("Protocol : " + Result );
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			Reader.RDR_AbortContinuousRead();
            this.listBox1.Items.Add("Timeout : " + Reader.RDR_GetCommTimeout().ToString() + " ms");
		}


	}
}
