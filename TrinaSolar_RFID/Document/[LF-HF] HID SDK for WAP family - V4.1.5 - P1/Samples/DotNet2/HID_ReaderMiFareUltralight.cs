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
	public class HID_ReaderMiFareUltralight : System.Windows.Forms.Form
	{
        private HID_Reader Reader = null; 
        private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox _txtRead;
		private System.Windows.Forms.Button _btRead;
		private System.Windows.Forms.TextBox _txtWrite;
		private System.Windows.Forms.Button _btWrite;
		private System.Windows.Forms.Button button2;

        public HID_ReaderMiFareUltralight(HID_Reader reader)
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this._txtRead = new System.Windows.Forms.TextBox();
            this._btRead = new System.Windows.Forms.Button();
            this._txtWrite = new System.Windows.Forms.TextBox();
            this._btWrite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(8, 98);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(224, 162);
            this.listBox1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 24);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // _txtRead
            // 
            this._txtRead.Enabled = false;
            this._txtRead.Location = new System.Drawing.Point(72, 37);
            this._txtRead.Name = "_txtRead";
            this._txtRead.Size = new System.Drawing.Size(160, 23);
            this._txtRead.TabIndex = 3;
            // 
            // _btRead
            // 
            this._btRead.Location = new System.Drawing.Point(8, 37);
            this._btRead.Name = "_btRead";
            this._btRead.Size = new System.Drawing.Size(58, 20);
            this._btRead.TabIndex = 2;
            this._btRead.Text = "Read";
            this._btRead.Click += new System.EventHandler(this._btRead_Click);
            // 
            // _txtWrite
            // 
            this._txtWrite.Location = new System.Drawing.Point(72, 8);
            this._txtWrite.MaxLength = 16;
            this._txtWrite.Name = "_txtWrite";
            this._txtWrite.Size = new System.Drawing.Size(160, 23);
            this._txtWrite.TabIndex = 1;
            // 
            // _btWrite
            // 
            this._btWrite.Location = new System.Drawing.Point(8, 8);
            this._btWrite.Name = "_btWrite";
            this._btWrite.Size = new System.Drawing.Size(58, 20);
            this._btWrite.TabIndex = 0;
            this._btWrite.Text = "Write";
            this._btWrite.Click += new System.EventHandler(this._btWrite_Click);
            // 
            // HID_ReaderMiFareUltralight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 295);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this._txtRead);
            this.Controls.Add(this._btRead);
            this.Controls.Add(this._txtWrite);
            this.Controls.Add(this._btWrite);
            this.MinimizeBox = false;
            this.Name = "HID_ReaderMiFareUltralight";
            this.Text = "Reader MiFare Ultralight";
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
			this.listBox1.Items.Clear();
		}

		private void _btWrite_Click(object sender, System.EventArgs e)
		{
			int cpt;
			string txt, buffer = "";
			string txtToWrite = this._txtWrite.Text;

			// 
			if (txtToWrite.Length == 0)
			{
				this.listBox1.Items.Add ("No datas to write");
				return;
			}

			// Abort Continuous read
			Reader.RDR_AbortContinuousRead();

			// Select tag
            Reader.RDR_SendCommandGetData("S", "", ref buffer);
            if (buffer.Length == 1)
			{
				this.listBox1.Items.Add ("Detect tag error");
				return;
			}

			txt ="";
			for (cpt = 0; cpt < 16 ; cpt ++)
			{
				if (cpt < txtToWrite.Length)
					txt += String.Format("{0:x2}",Convert.ToUInt32(txtToWrite[cpt])).PadLeft(2, '0');
				else
					txt += "00";
			}
			
			//write command : wb(page)(data) : wb04(data)
            Reader.RDR_SendCommandGetData("wb04" + txt.Substring(0, 8).PadRight(32, '0'), "", ref buffer);
            Reader.RDR_SendCommandGetData("wb05" + txt.Substring(8, 8).PadRight(32, '0'), "", ref buffer);
            Reader.RDR_SendCommandGetData("wb06" + txt.Substring(16, 8).PadRight(32, '0'), "", ref buffer);
            Reader.RDR_SendCommandGetData("wb07" + txt.Substring(24, 8).PadRight(32, '0'), "", ref buffer);

            Reader.RDR_SendCommandGetData("rb04", "", ref buffer); 
			if (buffer.ToUpper() != txt.ToUpper() )
				this.listBox1.Items.Add("Write error");
			else
				this.listBox1.Items.Add ("Write success");

		}

		private void _btRead_Click(object sender, System.EventArgs e)
		{
			int cpt;
			string  buffer= "";

			// Abort Continuous read
			Reader.RDR_AbortContinuousRead();
			
			// Select tag
            Reader.RDR_SendCommandGetData("S", "", ref buffer);
			if (buffer.Length < 2)
			{
				this.listBox1.Items.Add ("Detect tag error");
				return;
			}

			// Read blocks
			this._txtRead.Text ="";
			Reader.RDR_SendCommandGetData("rb04", "", ref buffer);

            if (buffer.Length < 32)
            {
                this.listBox1.Items.Add("Read error");
                return;
            }

			for (cpt = 0; cpt < 32 ; cpt +=2)
					this._txtRead.Text +=  (char)System.Convert.ToUInt32(buffer.Substring(cpt,2), 16);

			this.listBox1.Items.Add ("Read success");
		}

	}
}
