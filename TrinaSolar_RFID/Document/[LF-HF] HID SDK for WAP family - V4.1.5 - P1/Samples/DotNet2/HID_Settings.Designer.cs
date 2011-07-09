namespace PsionTeklogixRFIDDemoApplications
{
    partial class HID_Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this._cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAutodetect = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonBin = new System.Windows.Forms.RadioButton();
            this.radioButtonASCII = new System.Windows.Forms.RadioButton();
            this.panelAutodetect = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox0x80 = new System.Windows.Forms.CheckBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButtonNoAuto = new System.Windows.Forms.RadioButton();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelAutodetect.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.Text = "Protocol:";
            // 
            // _cbBaudRate
            // 
            this._cbBaudRate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this._cbBaudRate.Items.Add("9600");
            this._cbBaudRate.Items.Add("19200");
            this._cbBaudRate.Items.Add("38400");
            this._cbBaudRate.Items.Add("57600");
            this._cbBaudRate.Items.Add("115200");
            this._cbBaudRate.Items.Add("230400");
            this._cbBaudRate.Location = new System.Drawing.Point(114, 9);
            this._cbBaudRate.Name = "_cbBaudRate";
            this._cbBaudRate.Size = new System.Drawing.Size(125, 19);
            this._cbBaudRate.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.Text = "BaudRate:";
            // 
            // labelAutodetect
            // 
            this.labelAutodetect.Location = new System.Drawing.Point(3, 0);
            this.labelAutodetect.Name = "labelAutodetect";
            this.labelAutodetect.Size = new System.Drawing.Size(236, 20);
            this.labelAutodetect.Text = "Autodetect:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButtonBin);
            this.panel1.Controls.Add(this.radioButtonASCII);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 72);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(143, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 33);
            this.label1.Text = " (this demo doesn\'t fully support it)";
            // 
            // radioButtonBin
            // 
            this.radioButtonBin.Location = new System.Drawing.Point(73, 34);
            this.radioButtonBin.Name = "radioButtonBin";
            this.radioButtonBin.Size = new System.Drawing.Size(100, 20);
            this.radioButtonBin.TabIndex = 22;
            this.radioButtonBin.TabStop = false;
            this.radioButtonBin.Text = "1-Binary";
            // 
            // radioButtonASCII
            // 
            this.radioButtonASCII.Checked = true;
            this.radioButtonASCII.Location = new System.Drawing.Point(73, 12);
            this.radioButtonASCII.Name = "radioButtonASCII";
            this.radioButtonASCII.Size = new System.Drawing.Size(100, 20);
            this.radioButtonASCII.TabIndex = 21;
            this.radioButtonASCII.Text = "0-ASCII";
            // 
            // panelAutodetect
            // 
            this.panelAutodetect.Controls.Add(this.label3);
            this.panelAutodetect.Controls.Add(this.checkBox0x80);
            this.panelAutodetect.Controls.Add(this.radioButton2);
            this.panelAutodetect.Controls.Add(this.label2);
            this.panelAutodetect.Controls.Add(this.radioButton1);
            this.panelAutodetect.Controls.Add(this.radioButtonNoAuto);
            this.panelAutodetect.Controls.Add(this.labelAutodetect);
            this.panelAutodetect.Location = new System.Drawing.Point(0, 108);
            this.panelAutodetect.Name = "panelAutodetect";
            this.panelAutodetect.Size = new System.Drawing.Size(242, 125);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(38, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 40);
            this.label3.Text = "0x80-Disable driver power management and shorten the time to close the reader";
            // 
            // checkBox0x80
            // 
            this.checkBox0x80.Location = new System.Drawing.Point(13, 100);
            this.checkBox0x80.Name = "checkBox0x80";
            this.checkBox0x80.Size = new System.Drawing.Size(38, 20);
            this.checkBox0x80.TabIndex = 30;
            // 
            // radioButton2
            // 
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(73, 58);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(154, 20);
            this.radioButton2.TabIndex = 29;
            this.radioButton2.Text = "2-Fast autodetection";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(83, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 23);
            this.label2.Text = " (doesn\'t work with old reader)";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(73, 36);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(145, 20);
            this.radioButton1.TabIndex = 27;
            this.radioButton1.TabStop = false;
            this.radioButton1.Text = "1-Autodetection";
            // 
            // radioButtonNoAuto
            // 
            this.radioButtonNoAuto.Location = new System.Drawing.Point(73, 14);
            this.radioButtonNoAuto.Name = "radioButtonNoAuto";
            this.radioButtonNoAuto.Size = new System.Drawing.Size(166, 20);
            this.radioButtonNoAuto.TabIndex = 26;
            this.radioButtonNoAuto.TabStop = false;
            this.radioButtonNoAuto.Text = "0-No autodetection";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(143, 239);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(84, 20);
            this.buttonUpdate.TabIndex = 27;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(53, 239);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(84, 20);
            this.buttonCancel.TabIndex = 31;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // HID_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 295);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.panelAutodetect);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._cbBaudRate);
            this.Controls.Add(this.label4);
            this.MinimizeBox = false;
            this.Name = "HID_Settings";
            this.Text = "Connection Settings";
            this.panel1.ResumeLayout(false);
            this.panelAutodetect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _cbBaudRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAutodetect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonBin;
        private System.Windows.Forms.RadioButton radioButtonASCII;
        private System.Windows.Forms.Panel panelAutodetect;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButtonNoAuto;
        private System.Windows.Forms.CheckBox checkBox0x80;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonCancel;
    }
}