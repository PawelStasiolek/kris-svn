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
	public class HID_ReaderISO14443 : System.Windows.Forms.Form
	{
        private HID_Reader Reader;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox _txtRead;
		private System.Windows.Forms.Button _btRead;
		private System.Windows.Forms.TextBox _txtWrite;
		private System.Windows.Forms.Button _btWrite;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button2;
        private Label label1;

		private string TagType = "";

        public HID_ReaderISO14443(HID_Reader reader)
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // comboBox1
            // 
            this.comboBox1.Items.Add("SR176");
            this.comboBox1.Items.Add("SRIX4K");
            this.comboBox1.Location = new System.Drawing.Point(72, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(73, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.Text = "Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // HID_ReaderISO14443
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 295);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this._txtRead);
            this.Controls.Add(this._btRead);
            this.Controls.Add(this._txtWrite);
            this.Controls.Add(this._btWrite);
            this.MinimizeBox = false;
            this.Name = "HID_ReaderISO14443";
            this.Text = "Reader ISO 14443-B";
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
			int BlockBegin=0, SizeBlock=0, cpt, cpt2, iTxt;
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

			// Informations tag
			switch (TagType )
			{
				case "":
					this.listBox1.Items.Add ("Select type of tag");
					return;

				case "SR176":
					BlockBegin = 4; SizeBlock = 2;
					break;

				case "SRIX4K":
					BlockBegin = 7; SizeBlock = 4;
					break;
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
			int BlockBegin=0, SizeBlock=0, cpt, cpt2;
			string txt, Buffer="";

			// Select tag
            Reader.RDR_SendCommandGetData("S", "", ref Buffer);
            if (Buffer.Length == 1)
            {
				this.listBox1.Items.Add ("Detect tag error");
				return;
			}

			// Informations tag
			switch (TagType )
			{
				case "":
					this.listBox1.Items.Add ("Select type of tag");
					return;

				case "SR176":
					BlockBegin = 4; SizeBlock = 2;
					break;

				case "SRIX4K":
					BlockBegin = 7; SizeBlock = 4;
					break;
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

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( this.comboBox1.SelectedItem != null)
			{
				TagType =this.comboBox1.SelectedItem.ToString();
			}
		}





	}
}
