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
	public class HID_ReaderHitagS : System.Windows.Forms.Form
	{
        private HID_Reader Reader;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btContinuousRead;
        private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.ComboBox _cbConfiguration;
		private System.Windows.Forms.ListBox _lb;
		private System.Windows.Forms.TextBox _txt;
        private TextBox _txtSend;
        private Button _btSend;
        private Label label2;
		private System.Windows.Forms.Button button2;

        public HID_ReaderHitagS(HID_Reader reader)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.Reader = reader;
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
            this._lb = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._btContinuousRead = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer();
            this._cbConfiguration = new System.Windows.Forms.ComboBox();
            this._txt = new System.Windows.Forms.TextBox();
            this._txtSend = new System.Windows.Forms.TextBox();
            this._btSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _lb
            // 
            this._lb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            this._lb.Location = new System.Drawing.Point(8, 143);
            this._lb.Name = "_lb";
            this._lb.Size = new System.Drawing.Size(224, 132);
            this._lb.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 24);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.Text = "Continuous read";
            // 
            // _btContinuousRead
            // 
            this._btContinuousRead.Location = new System.Drawing.Point(112, 37);
            this._btContinuousRead.Name = "_btContinuousRead";
            this._btContinuousRead.Size = new System.Drawing.Size(56, 24);
            this._btContinuousRead.TabIndex = 2;
            this._btContinuousRead.Text = "Active";
            this._btContinuousRead.Click += new System.EventHandler(this._btContinuousRead_Click);
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick_1);
            // 
            // _cbConfiguration
            // 
            this._cbConfiguration.Items.Add("Default");
            this._cbConfiguration.Items.Add("Hitag S 256 memory");
            this._cbConfiguration.Items.Add("Hitag S 2048 memory");
            this._cbConfiguration.Location = new System.Drawing.Point(112, 67);
            this._cbConfiguration.Name = "_cbConfiguration";
            this._cbConfiguration.Size = new System.Drawing.Size(120, 23);
            this._cbConfiguration.TabIndex = 3;
            this._cbConfiguration.SelectedIndexChanged += new System.EventHandler(this._cbConfiguration_SelectedIndexChanged);
            // 
            // _txt
            // 
            this._txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this._txt.Location = new System.Drawing.Point(8, 124);
            this._txt.Name = "_txt";
            this._txt.Size = new System.Drawing.Size(224, 23);
            this._txt.TabIndex = 5;
            // 
            // _txtSend
            // 
            this._txtSend.Location = new System.Drawing.Point(112, 8);
            this._txtSend.Name = "_txtSend";
            this._txtSend.Size = new System.Drawing.Size(120, 23);
            this._txtSend.TabIndex = 1;
            // 
            // _btSend
            // 
            this._btSend.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this._btSend.Location = new System.Drawing.Point(8, 8);
            this._btSend.Name = "_btSend";
            this._btSend.Size = new System.Drawing.Size(98, 20);
            this._btSend.TabIndex = 0;
            this._btSend.Text = "Send command";
            this._btSend.Click += new System.EventHandler(this._btSend_Click_1);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 23);
            this.label2.Text = "Reading mode:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // HID_ReaderHitagS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 295);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txt);
            this.Controls.Add(this._cbConfiguration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btContinuousRead);
            this.Controls.Add(this._txtSend);
            this.Controls.Add(this._btSend);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._lb);
            this.MinimizeBox = false;
            this.Name = "HID_ReaderHitagS";
            this.Text = "Hyper Terminal";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.fTagSYSReader_Closing);
            this.Load += new System.EventHandler(this.fTagSYSReader_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void fTagSYSReader_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		}

		private void fTagSYSReader_Load(object sender, System.EventArgs e)
		{
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		private void _btContinuousRead_Click(object sender, System.EventArgs e)
		{
			if ( this._btContinuousRead.Text == "Active" )
			{
				Reader.RDR_AbortContinuousRead();
                Reader.RDR_SendCommand("c", "");
				timer.Enabled = true;
				this._btSend.Enabled = false;
				this._txtSend.Enabled = false;
				this._cbConfiguration.Enabled = false;
				this._btContinuousRead.Text = "Stop";
			}
			else
			{
				Reader.RDR_AbortContinuousRead();
				timer.Enabled = false;
				this._btSend.Enabled = true;
				this._txtSend.Enabled = true;
				this._cbConfiguration.Enabled = true;
				this._btContinuousRead.Text = "Active";
			}
		}

		private void _btSend_Click_1(object sender, System.EventArgs e)
		{
			try
			{
				Reader.RDR_AbortContinuousRead();
				string Buffer = "";
                Reader.RDR_SendCommandGetData(this._txtSend.Text, "", ref Buffer);
				Display("" + Buffer);
			}
			catch (Exception ex)
			{
				Display(ex.Message);
			}
		}

		[System.Runtime.InteropServices.DllImport("coredll.dll")]
		extern private static int GetTickCount();

		private void timer_Tick_1(object sender, System.EventArgs e)
		{
			int t = GetTickCount();

			string IDTAG= "";
            Reader.RDR_GetData(ref IDTAG);

			if ( IDTAG.Length > 2 )
				Display( "(" + Convert.ToString(GetTickCount() - t) + ")" + IDTAG);
		}

		private void _cbConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbConfiguration.SelectedIndex != -1)
            {
                string buffer = "";
                switch (_cbConfiguration.SelectedItem.ToString())
                {
                    case "Default":
                        Reader.RDR_AbortContinuousRead();
                        Display("Abort continuous read");

                        Reader.RDR_SendCommandGetData("wp0b01", "", ref buffer);
                        Display("Protocol configuration: " + buffer);

                        //Reader.RDR_SendCommandGetData("wp0e7f");
                        Reader.RDR_SendCommandGetData("wp0eff", "", ref buffer);
                        Display("Operation mode: " + buffer);

                        Reader.RDR_SendCommandGetData("wp1984", "", ref buffer);
                        Display("Hitag 1/Hitag S settings: " + buffer);

                        Reader.RDR_SendCommandGetData("wp1100", "", ref buffer);
                        Display("Start block: " + buffer);

                        Reader.RDR_SendCommandGetData("wp1201", "", ref buffer);
                        Display("Number of blocks: " + buffer);

                        // Default timeout 300 ms
                        Reader.RDR_SetCommTimeout(300);
                        Display("TimeOut: 300 ms");

                        Reader.RDR_ResetReader();
                        Display("Reset");
                        break;
                    case "Hitag S 256 memory":
                        // Default timeout 2s
                        Reader.RDR_AbortContinuousRead();
                        Display("Abort continuous read");

                        Reader.RDR_AbortContinuousRead();
                        Display("Abort continuous read");

                        Reader.RDR_SetCommTimeout(2000);
                        Display("TimeOut: 2 000 ms");

                        Reader.RDR_SendCommandGetData("wp0b41", "", ref buffer);
                        Display("Protocol configuration: " + buffer);

                        Reader.RDR_SendCommandGetData("wp0e7f", "", ref buffer);
                        Display("Operation mode: " + buffer);

                        Reader.RDR_SendCommandGetData("wp19FF", "", ref buffer);
                        Display("Hitag 1/Hitag S settings: " + buffer);

                        Reader.RDR_SendCommandGetData("wp1100", "", ref buffer);
                        Display("Start block: " + buffer);

                        Reader.RDR_SendCommandGetData("wp1207", "", ref buffer);
                        Display("Number of blocks: " + buffer);

                        Reader.RDR_ResetReader();
                        Display("Reset");
                        break;
                    case "Hitag S 2048 memory":
                        // Default timeout 2s
                        Reader.RDR_AbortContinuousRead();
                        Display("Abort continuous read");

                        Reader.RDR_SetCommTimeout(2000);
                        Display("TimeOut: 2 000 ms");

                        Reader.RDR_SendCommandGetData("wp0b41", "", ref buffer);
                        Display("Protocol configuration: " + buffer);

                        Reader.RDR_SendCommandGetData("wp0e7f", "", ref buffer);
                        Display("Operation mode: " + buffer);

                        Reader.RDR_SendCommandGetData("wp19FF", "", ref buffer);
                        Display("Hitag 1/Hitag S settings: " + buffer);

                        Reader.RDR_SendCommandGetData("wp1100", "", ref buffer);
                        Display("Start block: " + buffer);

                        Reader.RDR_SendCommandGetData("wp1239", "", ref buffer);
                        Display("Number of blocks: " + buffer);

                        Reader.RDR_ResetReader();
                        Display("Reset");
                        break;

                }
            }
        }

		private void Display (string Info)
		{
			_lb.Items.Insert(0, Info);
			_txt.Text = Info;

		}

		private void Clear()
		{
			_lb.Items.Clear();
			_txt.Text = "";
		}

	}
}
