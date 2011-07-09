using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using HidGlobal.MultiIso.CFReader;

namespace PsionTeklogixRFIDDemoApplications
{
	/// <summary>
	/// Summary description for fTagSYSReader.
	/// </summary>
	public class HID_HyperTerminal : System.Windows.Forms.Form
	{
        private HID_Reader Reader = null; 
        private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _btContinuousRead;
		private System.Windows.Forms.TextBox _txtSend;
		private System.Windows.Forms.Button _btSend;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Button button2;
        private TextBox _txtData;
        private ComboBox _cbHistoric;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private Label label2;

        public HID_HyperTerminal(HID_Reader reader)
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
            this.label1 = new System.Windows.Forms.Label();
            this._btContinuousRead = new System.Windows.Forms.Button();
            this._txtSend = new System.Windows.Forms.TextBox();
            this._btSend = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer();
            this._txtData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._cbHistoric = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.listBox1.Location = new System.Drawing.Point(8, 79);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(224, 212);
            this.listBox1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(184, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 21);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(57, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.Text = "Continuous read";
            // 
            // _btContinuousRead
            // 
            this._btContinuousRead.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this._btContinuousRead.Location = new System.Drawing.Point(8, 57);
            this._btContinuousRead.Name = "_btContinuousRead";
            this._btContinuousRead.Size = new System.Drawing.Size(48, 21);
            this._btContinuousRead.TabIndex = 3;
            this._btContinuousRead.Text = "Active";
            this._btContinuousRead.Click += new System.EventHandler(this._btContinuousRead_Click);
            // 
            // _txtSend
            // 
            this._txtSend.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this._txtSend.Location = new System.Drawing.Point(28, 3);
            this._txtSend.Name = "_txtSend";
            this._txtSend.Size = new System.Drawing.Size(90, 19);
            this._txtSend.TabIndex = 1;
            this._txtSend.Text = "version";
            // 
            // _btSend
            // 
            this._btSend.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this._btSend.Location = new System.Drawing.Point(149, 27);
            this._btSend.Name = "_btSend";
            this._btSend.Size = new System.Drawing.Size(90, 20);
            this._btSend.TabIndex = 0;
            this._btSend.Text = "Send command";
            this._btSend.Click += new System.EventHandler(this._btSend_Click_1);
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick_1);
            // 
            // _txtData
            // 
            this._txtData.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this._txtData.Location = new System.Drawing.Point(149, 3);
            this._txtData.Name = "_txtData";
            this._txtData.Size = new System.Drawing.Size(90, 19);
            this._txtData.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(119, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Data:";
            // 
            // _cbHistoric
            // 
            this._cbHistoric.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this._cbHistoric.Location = new System.Drawing.Point(44, 27);
            this._cbHistoric.Name = "_cbHistoric";
            this._cbHistoric.Size = new System.Drawing.Size(99, 19);
            this._cbHistoric.TabIndex = 6;
            this._cbHistoric.SelectedIndexChanged += new System.EventHandler(this._cbHistoric_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(1, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Historic:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(1, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Cmd:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 2);
            // 
            // HID_HyperTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(242, 295);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._cbHistoric);
            this.Controls.Add(this._txtData);
            this.Controls.Add(this._txtSend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btContinuousRead);
            this.Controls.Add(this._btSend);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label4);
            this.MinimizeBox = false;
            this.Name = "HID_HyperTerminal";
            this.Text = "Hyper Terminal";
            this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.listBox1.Items.Clear();
		}

		private void _btContinuousRead_Click(object sender, System.EventArgs e)
		{
			if ( this._btContinuousRead.Text == "Active" )
			{
				Reader.RDR_AbortContinuousRead();
				Reader.RDR_SendCommand ("c", "");
				timer.Enabled = true;
				this._btSend.Enabled = false;
                this._txtSend.Enabled = false;
                this._txtData.Enabled = false;
                this._btContinuousRead.Text = "Stop";
			}
			else
			{
				Reader.RDR_AbortContinuousRead();
				timer.Enabled = false;
				this._btSend.Enabled = true;
				this._txtSend.Enabled = true;
                this._txtData.Enabled = true;
                this._btContinuousRead.Text = "Active";
			}
		}

		private void _btSend_Click_1(object sender, System.EventArgs e)
		{
            try
            {
                Reader.RDR_AbortContinuousRead();
                string buffer = "";

                Reader.RDR_SendCommandGetData(this._txtSend.Text, _txtData.Text, ref buffer);
                this.listBox1.Items.Add("" + buffer);

                // add to historic
                 _cbHistoric.Items.Insert(0, this._txtSend.Text + " " + _txtData.Text);
                // remove last element
                if ( _cbHistoric.Items.Count > 10)
                    _cbHistoric.Items.RemoveAt(_cbHistoric.Items.Count - 1);
            }
            catch (Exception ex)
            {
                this.listBox1.Items.Add(ex.Message);
            }
		}

		private void timer_Tick_1(object sender, System.EventArgs e)
		{
            string IDTAG = "";
			Reader.RDR_GetData(ref IDTAG);

			if ( IDTAG.Length > 2 )
				this.listBox1.Items.Add(IDTAG);
		}

        private void _cbHistoric_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbHistoric.SelectedIndex != -1)
            {
                string[] data = _cbHistoric.Items[_cbHistoric.SelectedIndex].ToString().Split(' ');
                _txtSend.Text = data[0];
                _txtData.Text = data[1];
            }
        }




	}
}
