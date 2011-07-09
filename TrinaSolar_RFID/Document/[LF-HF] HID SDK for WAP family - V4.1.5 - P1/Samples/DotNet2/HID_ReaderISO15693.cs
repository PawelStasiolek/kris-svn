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
	public class HID_ReaderISO15693 : System.Windows.Forms.Form
	{
        private HID_Reader Reader;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox _txtRead;
		private System.Windows.Forms.Button _btRead;
		private System.Windows.Forms.TextBox _txtWrite;
        private System.Windows.Forms.Button _btWrite;
        private System.Windows.Forms.Button button2;

		private string TagType = "";

        public HID_ReaderISO15693(HID_Reader reader)
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
            this.listBox1.Location = new System.Drawing.Point(8, 104);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(224, 162);
            this.listBox1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 24);
            this.button2.TabIndex = 5;
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
            // HID_ReaderISO15693
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
            this.Name = "HID_ReaderISO15693";
            this.Text = "Reader ISO 15693";
            this.ResumeLayout(false);

		}
		#endregion


		private void button2_Click(object sender, System.EventArgs e)
		{
			this.listBox1.Items.Clear();
		}

		private void _btWrite_Click(object sender, System.EventArgs e)
		{
			int BlockBegin=0, SizeBlock=4, cpt, cpt2, iTxt;
			string txt, Buffer="";
			string txtToWrite = this._txtWrite.Text;

			// 
			if (txtToWrite.Length == 0)
			{
				this.listBox1.Items.Add ("No datas to write");
				return;
			}

			// Select tag
            Reader.RDR_SendCommandGetData("S", "", ref Buffer);
            if (Buffer.Length == 1)
            {
				this.listBox1.Items.Add ("Detect tag error");
				return;
			}


			// Write blocks
			for (cpt = 0; cpt < (16 / SizeBlock) ; cpt ++)
			{
				// String constructor
				txt = "wb" + Convert.ToString((BlockBegin + cpt),16).PadLeft(2,'0');
				for (cpt2 = 0 ; cpt2 < SizeBlock  ; cpt2++)
				{
					if ((cpt * SizeBlock + cpt2) <  txtToWrite.Length )
					{
						iTxt = Convert.ToByte ( txtToWrite[cpt * SizeBlock + cpt2]);
						txt += String.Format("{0:x2}", iTxt);
					}
					else
					{
						txt += "00";
					}
				}
				// Write
				Reader.RDR_SendCommandGetData (txt, "", ref Buffer);
				// Error management
				if (Buffer.Length <= 1)
				{
					this.listBox1.Items.Add ("Write error : Block=" + cpt);
					return;
				}
			}

			this.listBox1.Items.Add ("Write success");

		}

		private void _btRead_Click(object sender, System.EventArgs e)
		{
			int BlockBegin=0, SizeBlock=4, cpt, cpt2;
			string txt, Buffer="";

			// Select tag
            Reader.RDR_SendCommandGetData("S", "", ref Buffer);
            if (Buffer.Length == 1)
            {
				this.listBox1.Items.Add ("Detect tag error");
				return;
			}

			// Read blocks
			this._txtRead.Text ="";
			for (cpt = 0; cpt < (16 / SizeBlock) ; cpt ++)
			{
				// String constructor
				txt = "rb" + Convert.ToString((BlockBegin + cpt),16).PadLeft(2,'0');

				// Read
                Reader.RDR_SendCommandGetData(txt, "", ref Buffer);
				// Error management
				if (Buffer.Length <= SizeBlock)
				{
					this.listBox1.Items.Add ("Write error : Block=" + cpt);
					return;
				}
				else
				{	
					for (cpt2 = 0; cpt2 < (SizeBlock * 2) ; cpt2 +=2)
					{
						this._txtRead.Text +=  (char)System.Convert.ToUInt32(Buffer.Substring(cpt2,2), 16);
					}
				}
			}

			this.listBox1.Items.Add ("Read success");
		}

	}
}
