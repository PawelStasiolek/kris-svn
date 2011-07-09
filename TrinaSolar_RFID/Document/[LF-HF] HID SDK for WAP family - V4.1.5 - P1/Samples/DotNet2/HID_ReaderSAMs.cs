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
	public class HID_ReaderSAMs : System.Windows.Forms.Form
	{
        private HID_Reader Reader;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button _btReadATR;
        private System.Windows.Forms.Button button2;
        private RadioButton _rbSAM1;
        private RadioButton _rbSAM2;

        public HID_ReaderSAMs(HID_Reader reader)
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
            this._btReadATR = new System.Windows.Forms.Button();
            this._rbSAM1 = new System.Windows.Forms.RadioButton();
            this._rbSAM2 = new System.Windows.Forms.RadioButton();
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
            // _btReadATR
            // 
            this._btReadATR.Location = new System.Drawing.Point(47, 38);
            this._btReadATR.Name = "_btReadATR";
            this._btReadATR.Size = new System.Drawing.Size(151, 36);
            this._btReadATR.TabIndex = 2;
            this._btReadATR.Text = "Read ATR";
            this._btReadATR.Click += new System.EventHandler(this._btReadATR_Click);
            // 
            // _rbSAM1
            // 
            this._rbSAM1.Checked = true;
            this._rbSAM1.Location = new System.Drawing.Point(47, 12);
            this._rbSAM1.Name = "_rbSAM1";
            this._rbSAM1.Size = new System.Drawing.Size(100, 20);
            this._rbSAM1.TabIndex = 7;
            this._rbSAM1.Text = "SAM1";
            // 
            // _rbSAM2
            // 
            this._rbSAM2.Location = new System.Drawing.Point(132, 12);
            this._rbSAM2.Name = "_rbSAM2";
            this._rbSAM2.Size = new System.Drawing.Size(100, 20);
            this._rbSAM2.TabIndex = 8;
            this._rbSAM2.TabStop = false;
            this._rbSAM2.Text = "SAM2";
            // 
            // HID_ReaderSAMs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 295);
            this.Controls.Add(this._rbSAM2);
            this.Controls.Add(this._rbSAM1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this._btReadATR);
            this.MinimizeBox = false;
            this.Name = "HID_ReaderSAMs";
            this.Text = "Reader SAMs";
            this.ResumeLayout(false);

		}
		#endregion


		private void button2_Click(object sender, System.EventArgs e)
		{
			this.listBox1.Items.Clear();
		}

        private void _btReadATR_Click(object sender, EventArgs e)
        {
            try
            {

                string buffer = string.Empty;

                // Init
                // write userport:01
                Reader.RDR_SendCommandGetData("pw01", "", ref buffer);
                if (buffer != "01")
                    MessageBox.Show("Error writing the user port\ndata returned: " + buffer);

                Reader.RDR_SendCommandGetData("led off", "", ref buffer);

                if (_rbSAM1.Checked)
                {
                    // Activate the SmartCard 1 (LED GREEN)
                    Reader.RDR_SendCommandGetData("led green", "", ref buffer);
                    if (buffer != "DG")
                        throw new Exception("Impossible to activate the smart card\ndata returned: " + buffer);

                    listBox1.Items.Add("SmartCard 1 activated");
                }
                else
                {
                    // Activate the SmartCard 2 (LED RED)
                    Reader.RDR_SendCommandGetData("led red", "", ref buffer);
                    if (buffer != "DR")
                        throw new Exception("Impossible to activate the smart card\ndata returned: " + buffer);

                    listBox1.Items.Add("SmartCard 2 activated");
                }
                System.Threading.Thread.Sleep(150);

                // star communication & get ATR
                Reader.RDR_SendCommandGetData("e00011011", "", ref buffer);
                if (buffer.Length <= 2)
                    throw new Exception("Impossible to get the ATR\ndata returned: " +
                        SAMAnswers(buffer));

                listBox1.Items.Add("ATR: " + buffer);

                // stop communication
                Reader.RDR_SendCommandGetData("e00020000", "", ref buffer);
                if (buffer != "P")
                    throw new Exception("Error stopping communication\ndata returned: " +
                        SAMAnswers(buffer));

                listBox1.Items.Add("Communication stopped");

            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }

        private string SAMAnswers(string answer)
        {
            switch (answer)
            {
                case "P":
                    return "End of communication";
                case "C":
                    return "CRC error";
                case "F":
                    return "General failure or incorrect ATR";
                case "N":
                    return "No SAM detected";
                default:
                    return "";
            }
        }
	}
}
