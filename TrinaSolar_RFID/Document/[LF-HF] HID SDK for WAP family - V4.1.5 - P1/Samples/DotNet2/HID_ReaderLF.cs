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
	public class HID_ReaderLF : System.Windows.Forms.Form
	{
        private HID_Reader Reader;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox _txtRead;
		private System.Windows.Forms.Button _btRead;
		private System.Windows.Forms.TextBox _txtWrite;
		private System.Windows.Forms.Button _btWrite;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.RadioButton _rbHex;
		private System.Windows.Forms.RadioButton _rbAscii;
        private Label label1;

		private string TagType = "";

        public HID_ReaderLF(HID_Reader reader)
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
            this._rbHex = new System.Windows.Forms.RadioButton();
            this._rbAscii = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(8, 128);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(224, 146);
            this.listBox1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 24);
            this.button2.TabIndex = 7;
            this.button2.Text = "Clear";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // _txtRead
            // 
            this._txtRead.Location = new System.Drawing.Point(72, 37);
            this._txtRead.Name = "_txtRead";
            this._txtRead.ReadOnly = true;
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
            this._txtWrite.MaxLength = 2048;
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
            this.comboBox1.Items.Add("EM 4x50");
            this.comboBox1.Items.Add("Hitag 1");
            this.comboBox1.Items.Add("Hitag 2");
            this.comboBox1.Items.Add("Hitag S 256");
            this.comboBox1.Items.Add("Hitag S 2048");
            this.comboBox1.Location = new System.Drawing.Point(72, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(88, 23);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // _rbHex
            // 
            this._rbHex.Checked = true;
            this._rbHex.Location = new System.Drawing.Point(72, 64);
            this._rbHex.Name = "_rbHex";
            this._rbHex.Size = new System.Drawing.Size(58, 20);
            this._rbHex.TabIndex = 4;
            this._rbHex.Text = "Hex";
            this._rbHex.CheckedChanged += new System.EventHandler(this._rbHex_CheckedChanged);
            // 
            // _rbAscii
            // 
            this._rbAscii.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this._rbAscii.Location = new System.Drawing.Point(136, 64);
            this._rbAscii.Name = "_rbAscii";
            this._rbAscii.Size = new System.Drawing.Size(58, 20);
            this._rbAscii.TabIndex = 5;
            this._rbAscii.Text = "Ascii";
            this._rbAscii.CheckedChanged += new System.EventHandler(this._rbAscii_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.Text = "Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // HID_ReaderLF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 295);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._rbAscii);
            this.Controls.Add(this._rbHex);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this._txtRead);
            this.Controls.Add(this._btRead);
            this.Controls.Add(this._txtWrite);
            this.Controls.Add(this._btWrite);
            this.MinimizeBox = false;
            this.Name = "HID_ReaderLF";
            this.Text = "Reader Low Frequency";
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

		private void Clear()
		{
			this.listBox1.Items.Clear();
			_txtRead.Text = "";
		}

		private void _btWrite_Click(object sender, System.EventArgs e)
		{
			bool result = false;
			string txtToWrite = this._txtWrite.Text;

			
			Clear();
			
			// 
			if (txtToWrite.Length == 0)
			{
				this.listBox1.Items.Add ("No datas to write");
				return;
			}

			int Current, TimeResult;
			Current =  GetTickCount();

			Reader.RDR_AbortContinuousRead();

			TimeResult = GetTickCount() - Current;
			this.listBox1.Items.Add ("AbortContinuousRead (" + TimeResult.ToString() + " ms)");

			Current =  GetTickCount();

			// Informations tag
			switch (TagType )
			{
				case "":
					this.listBox1.Items.Add ("Select type of tag");
					return;

				case "EM 4x50":
				case "Hitag 1":
				case "Hitag 2":
				case "Hitag S 256":
				case "Hitag S 2048":
					result = WriteTagMemory(TagType, txtToWrite, bHex);
					break;
			}

			TimeResult = GetTickCount() - Current;

			if (result)
				this.listBox1.Items.Add ("Write success (" + TimeResult.ToString() + ")");
			else
				this.listBox1.Items.Add ("Write error ");

		}

		private void _btRead_Click(object sender, System.EventArgs e)
		{
			string Result = "";

			Clear();
			
			int Current, TimeResult;
			Current =  GetTickCount();
			
			Reader.RDR_AbortContinuousRead();

			TimeResult = GetTickCount() - Current;
			this.listBox1.Items.Add ("AbortContinuousRead (" + TimeResult.ToString() + " ms)");

			Current =  GetTickCount();

			// Informations tag
			switch (TagType )
			{
				case "":
					this.listBox1.Items.Add ("Select type of tag");
					return;

				case "EM 4x50":
				case "Hitag 1":
				case "Hitag 2":
				case "Hitag S 256":
				case "Hitag S 2048":
					Result = ReadTagMemory(TagType, bHex, 0, 0);
					break;
			}

			TimeResult = GetTickCount() - Current;

			if (Result != "")
			{
				this.listBox1.Items.Add ("Read success (" + TimeResult.ToString() + " ms)");
				_txtRead.Text = Result;
			}
			else
				this.listBox1.Items.Add	("Read error");
		}

		[System.Runtime.InteropServices.DllImport("coredll.dll")]
		extern static int GetTickCount();

		private string ReadTagMemory (string TagType, bool ReturnHex, int StripLeading, int StripTrailing)
		{
			int BlockBegin=0, SizeBlock=0, NbBlocks=0, cpt;
			string txt = ""; 

			string Buffer="";
			StringBuilder Result = new StringBuilder();

			// Tag information
			switch (TagType )
			{
				case "EM 4x50":
					BlockBegin = 0x3; SizeBlock = 4; NbBlocks = 28;
					break;

				case "Hitag 1":
					BlockBegin = 0x10; SizeBlock = 4; NbBlocks = 48;
					break;

				case "Hitag 2":
					BlockBegin = 0x4; SizeBlock = 4; NbBlocks = 4;
					break;
		
				case "Hitag S 256":
					//BlockBegin = 0x00; SizeBlock = 4; NbBlocks = 08;
					BlockBegin = 0x02; SizeBlock = 4; NbBlocks = 06;
					break;

				case "Hitag S 2048":
					//BlockBegin = 0x00; SizeBlock = 4; NbBlocks = 64;
					BlockBegin = 0x02; SizeBlock = 4; NbBlocks = 62;
					break;
			}

			int FirstBlock = BlockBegin + (int) (StripLeading / SizeBlock);
			NbBlocks = NbBlocks - (int) (StripTrailing / SizeBlock);

			string Cmd;
            Reader.RDR_AbortContinuousReadExt();
            string s = "";
            Reader.RDR_SendCommandGetData("S", "", ref s);

            if (s.Length < 2)
            {
                if (s == "N")
                    this.listBox1.Items.Add("No tag in the field");
                else
                    this.listBox1.Items.Add("Select error");
                return "";
            }
            this.listBox1.Items.Add("Select: " + s);


			// Read blocks
			for (cpt = FirstBlock; cpt < NbBlocks + BlockBegin; cpt ++)
			{
				// String constructor
				Cmd = "rb" + String.Format("{0:x2}", cpt);
				Reader.RDR_SendCommandGetData( Cmd , "", ref Buffer);				
				
				// Error management
				if ((Buffer[0] == 'N') )
				{
                    listBox1.Items.Add(String.Format("Error on the block={0:x2}", cpt));
                    return "";
				}

				Result.Append( Buffer );
			}


			if (! ReturnHex)
			{
				txt = Result.ToString();
				Result = new StringBuilder();

				for ( cpt = 0; cpt < txt.Length; cpt += 2 )
				{
					Result.Append( (char) Int32.Parse( txt.Substring( cpt, 2 ), System.Globalization.NumberStyles.HexNumber ) );
				}

				txt = Result.ToString();

				// Resize TagMemory
				StripLeading = StripLeading - (((int) (StripLeading / SizeBlock)) * SizeBlock);
				if ( StripLeading > 0)
					txt = txt.Substring (StripLeading , txt.Length - StripLeading );

				StripTrailing = StripTrailing - (((int) (StripTrailing / SizeBlock)) * SizeBlock);
				if ( StripTrailing > 0)
					txt = txt.Substring (0 , txt.Length - StripTrailing );
			}
			else //
			{
				txt = Result.ToString();

				// resize TagMemory
				StripLeading = (StripLeading - (((int) (StripLeading / SizeBlock)) * SizeBlock) ) * 2;
				if ( StripLeading > 0)
					txt = txt.Substring (StripLeading , txt.Length - StripLeading );

				StripTrailing = (StripTrailing - (((int) (StripTrailing / SizeBlock)) * SizeBlock)) * 2;
				if ( StripTrailing > 0)
					txt = txt.Substring (0 , txt.Length - StripTrailing );
			}

			return txt;
		}


		private bool WriteTagMemory (string TagType, string Data, bool Hex)
		{
			int BlockBegin=0, SizeBlock=0, NbBlocks=0;
			string txt=""; 
			int iTxt;

			// Tag information
			switch (TagType )
			{
				case "EM 4x50":
					BlockBegin = 0x3; SizeBlock = 4; NbBlocks = 28;
					break;

				case "Hitag 1":
					BlockBegin = 0x10; SizeBlock = 4; NbBlocks = 48;
					break;

				case "Hitag 2":
					BlockBegin = 0x4; SizeBlock = 4; NbBlocks = 4;
					break;
		
				case "Hitag S 256":
					//BlockBegin = 0x00; SizeBlock = 4; NbBlocks = 08;
					BlockBegin = 0x02; SizeBlock = 4; NbBlocks = 06;
					break;

				case "Hitag S 2048":
					//BlockBegin = 0x00; SizeBlock = 4; NbBlocks = 64;
					BlockBegin = 0x02; SizeBlock = 4; NbBlocks = 62;
					break;
			}

            Reader.RDR_AbortContinuousReadExt();
            string s = "";
            Reader.RDR_SendCommandGetData("S", "", ref s);

            if (s.Length < 2)
            {
                if (s == "N")
                    this.listBox1.Items.Add("No tag in the field");
                else
                    this.listBox1.Items.Add("Select error");
                return false;
            }
            this.listBox1.Items.Add("Select: " + s);


			// Write blocks
			for (int cpt = BlockBegin; cpt < NbBlocks + BlockBegin; cpt ++)
			{
				// String constructor
				txt = "wb" + String.Format("{0:x2}", cpt);
				if (Hex)
				{
                    if (Data.Length % 2 == 1) Data += "0";

					for (int cpt2 = 0 ; cpt2 < SizeBlock  * 2; cpt2 += 2)
					{
						if ( ((cpt - BlockBegin) * SizeBlock * 2) + cpt2 < Data.Length)
						{
							txt += Data.Substring((cpt - BlockBegin) * SizeBlock  * 2+ cpt2, 2).PadRight(2,'0');
						}
						else
						{
							txt += "00";
						}
					}
				}
				else
				{
					for (int cpt2 = 0 ; cpt2 < SizeBlock  ; cpt2++)
					{
						if (((cpt - BlockBegin) * SizeBlock + cpt2) <  Data.Length )
						{
							iTxt = Convert.ToByte ( Data[(cpt - BlockBegin) * SizeBlock + cpt2]);
							txt += String.Format("{0:x2}", iTxt);
						}
						else
						{
							txt += "00";
						}
					}
				}

                if (txt.Substring(4,txt.Length - 4) == "".PadLeft(SizeBlock * 2, '0'))
                {
                    this.listBox1.Items.Add("Number of blocks written: " + (cpt - BlockBegin));
                    return true;
                }

                Reader.RDR_SendCommandGetData(txt, "", ref s);
				
				// Error management
				// Write
                if (s.Length < 2)
                {
                    listBox1.Items.Add(String.Format("Error on the block={0:x2}", cpt));
					return false;
				}
			}

			return true;
		}


		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( this.comboBox1.SelectedItem != null)
			{
				TagType =this.comboBox1.SelectedItem.ToString();
			}
		}

		private bool bHex = true;

		private void _rbHex_CheckedChanged(object sender, System.EventArgs e)
		{
			bHex = _rbHex.Checked;
		}

		private void _rbAscii_CheckedChanged(object sender, System.EventArgs e)
		{
			bHex = ! _rbAscii.Checked;
		}

	}
}
