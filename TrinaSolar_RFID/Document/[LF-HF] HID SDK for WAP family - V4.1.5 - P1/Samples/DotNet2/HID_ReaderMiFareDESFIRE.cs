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
	public class HID_ReaderMiFareDESFIRE : System.Windows.Forms.Form
	{
        private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox _txtRead;
		private System.Windows.Forms.Button _btRead;
		private System.Windows.Forms.TextBox _txtWrite;
		private System.Windows.Forms.Button _btWrite;
        private System.Windows.Forms.Button buttonCreate;
		private System.Windows.Forms.Button button2;

        private HID_Reader Reader;

        public HID_ReaderMiFareDESFIRE(HID_Reader reader)
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
            this.buttonCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(8, 120);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(224, 146);
            this.listBox1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 24);
            this.button2.TabIndex = 5;
            this.button2.Text = "Clear";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // _txtRead
            // 
            this._txtRead.Enabled = false;
            this._txtRead.Location = new System.Drawing.Point(72, 60);
            this._txtRead.Name = "_txtRead";
            this._txtRead.Size = new System.Drawing.Size(160, 23);
            this._txtRead.TabIndex = 4;
            // 
            // _btRead
            // 
            this._btRead.Location = new System.Drawing.Point(8, 60);
            this._btRead.Name = "_btRead";
            this._btRead.Size = new System.Drawing.Size(58, 20);
            this._btRead.TabIndex = 3;
            this._btRead.Text = "Read";
            this._btRead.Click += new System.EventHandler(this._btRead_Click);
            // 
            // _txtWrite
            // 
            this._txtWrite.Location = new System.Drawing.Point(72, 31);
            this._txtWrite.MaxLength = 16;
            this._txtWrite.Name = "_txtWrite";
            this._txtWrite.Size = new System.Drawing.Size(160, 23);
            this._txtWrite.TabIndex = 2;
            // 
            // _btWrite
            // 
            this._btWrite.Location = new System.Drawing.Point(8, 31);
            this._btWrite.Name = "_btWrite";
            this._btWrite.Size = new System.Drawing.Size(58, 20);
            this._btWrite.TabIndex = 1;
            this._btWrite.Text = "Write";
            this._btWrite.Click += new System.EventHandler(this._btWrite_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(8, 5);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(225, 20);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Create Plain Standard Data File";
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // HID_ReaderMiFareDESFIRE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 295);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this._txtRead);
            this.Controls.Add(this._btRead);
            this.Controls.Add(this._txtWrite);
            this.Controls.Add(this._btWrite);
            this.MinimizeBox = false;
            this.Name = "HID_ReaderMiFareDESFIRE";
            this.Text = "Reader MiFare DESFIRE";
            this.ResumeLayout(false);

		}
		#endregion


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string response = "";
            byte command = 0;

            // Select the tag, and activate the DESFirecard
            this.listBox1.Items.Add("select");
            Reader.RDR_SendCommandGetData("select", "", ref response);
            this.listBox1.Items.Add(response);
            if (response.Length != 14)
            {
                // The lenght is not correct
                this.listBox1.Items.Add("UID incorrect");
                return;
            }

            // Set Highspeed select before authenticate
            this.listBox1.Items.Add("highspeed select");
            Reader.RDR_SendCommandGetData("h04", "", ref response);
            this.listBox1.Items.Add(response);

            // Authenticate
            command = 1;
            this.listBox1.Items.Add("autenticate");
            Reader.RDR_DESFire(command, "0000000000000000000000000000000000", ref response);
            this.listBox1.Items.Add(response);

            // Get Key settings
            command = 3;
            this.listBox1.Items.Add("get key settings");
            Reader.RDR_DESFire(command, "", ref response);
            this.listBox1.Items.Add(response);

            // Create application 000010
            command = 06;
            this.listBox1.Items.Add("create application 000010");
            Reader.RDR_DESFire(command, "0000100F01", ref response);
            this.listBox1.Items.Add(response);

            // Select application 000010
            command = 09;
            this.listBox1.Items.Add("select application 000010");
            Reader.RDR_DESFire(command, "000010", ref response);
            this.listBox1.Items.Add(response);

            // Set file settings for plain text without free access
            command = 32;
            this.listBox1.Items.Add("set file settings");
            Reader.RDR_DESFire(command, "0000EEEE", ref response);
            this.listBox1.Items.Add(response);

            // Create standard data file with 32 byte size
            command = 15;
            this.listBox1.Items.Add("create standard data file 00");
            Reader.RDR_DESFire(command, "200000", ref response);
            this.listBox1.Items.Add(response);
        }

		private void _btWrite_Click(object sender, System.EventArgs e)
		{
            string response = "";
            string data = "";
            byte command = 0;

            // Select the tag, and activate the DESFirecard
            this.listBox1.Items.Add("select");
            Reader.RDR_SendCommandGetData("select", "", ref response);
            this.listBox1.Items.Add(response);
            if (response.Length != 14)
            {
                // The lenght is not correct
                this.listBox1.Items.Add("UID incorrect");
                return;
            }

            // Set Highspeed select before authenticate
            this.listBox1.Items.Add("highspeed select");
            Reader.RDR_SendCommandGetData("h04", "", ref response);
            this.listBox1.Items.Add(response);

            // Authenticate
            command = 1;
            this.listBox1.Items.Add("autenticate");
            Reader.RDR_DESFire(command, "0000000000000000000000000000000000", ref response);
            this.listBox1.Items.Add(response);

            // Get Key settings
            command = 3;
            this.listBox1.Items.Add("get key settings");
            Reader.RDR_DESFire(command, "", ref response);
            this.listBox1.Items.Add(response);

            // Select application 000010
            command = 09;
            this.listBox1.Items.Add("select application 000010");
            Reader.RDR_DESFire(command, "000010", ref response);
            this.listBox1.Items.Add(response);

            // Set file settings for plain text without free access
            command = 32;
            this.listBox1.Items.Add("set file settings");
            Reader.RDR_DESFire(command, "0000EEEE", ref response);
            this.listBox1.Items.Add(response);

            // Write data
            data = _txtWrite.Text;
            data.PadRight(64, '0');

            command = 23;
            this.listBox1.Items.Add("write data file 00");
            Reader.RDR_DESFire(command, "000000" + data, ref response);
            this.listBox1.Items.Add(response);
		}

		private void _btRead_Click(object sender, System.EventArgs e)
		{
            string response = "";
            byte command = 0;

            // Select the tag, and activate the DESFirecard
            this.listBox1.Items.Add("select");
            Reader.RDR_SendCommandGetData("select", "", ref response);
            this.listBox1.Items.Add(response);
            if (response.Length != 14)
            {
                // The lenght is not correct
                this.listBox1.Items.Add("UID incorrect");
                return;
            }

            // Set Highspeed select before authenticate
            this.listBox1.Items.Add("highspeed select");
            Reader.RDR_SendCommandGetData("h04", "", ref response);
            this.listBox1.Items.Add(response);

            // Authenticate
            command = 1;
            this.listBox1.Items.Add("autenticate");
            Reader.RDR_DESFire(command, "0000000000000000000000000000000000", ref response);
            this.listBox1.Items.Add(response);

            // Get Key settings
            command = 3;
            this.listBox1.Items.Add("get key settings");
            Reader.RDR_DESFire(command, "", ref response);
            this.listBox1.Items.Add(response);

            // Select application 000010
            command = 09;
            this.listBox1.Items.Add("select application 000010");
            Reader.RDR_DESFire(command, "000010", ref response);
            this.listBox1.Items.Add(response);

            // Set file settings for plain text without free access
            command = 32;
            this.listBox1.Items.Add("set file settings");
            Reader.RDR_DESFire(command, "0000EEEE", ref response);
            this.listBox1.Items.Add(response);

            // Read data
            command = 21;
            this.listBox1.Items.Add("read data file 00");
            Reader.RDR_DESFire(command, "000000200000", ref response);
            this.listBox1.Items.Add(response);

            if (response.Length == 66)
                _txtRead.Text = response.Substring(2);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.listBox1.Items.Clear();
        }
	}
}
