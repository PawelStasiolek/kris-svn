namespace PsionTeklogixRFIDDemoApplications
{
    partial class HID_Launcher
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
            this._btConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._lb = new System.Windows.Forms.ListBox();
            this._btLaunch = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this._plExamples = new System.Windows.Forms.Panel();
            this._btSettings = new System.Windows.Forms.Button();
            this._lblRFIDDriverStatus = new System.Windows.Forms.Label();
            this._btDriverInformation = new System.Windows.Forms.Button();
            this._plExamples.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btConnect
            // 
            this._btConnect.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this._btConnect.Location = new System.Drawing.Point(150, 24);
            this._btConnect.Name = "_btConnect";
            this._btConnect.Size = new System.Drawing.Size(86, 30);
            this._btConnect.TabIndex = 2;
            this._btConnect.Text = "Connect";
            this._btConnect.Click += new System.EventHandler(this._btConnect_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 20);
            this.label3.Text = "Select a sample and launch";
            // 
            // _lb
            // 
            this._lb.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this._lb.Items.Add("Hyper Terminal");
            this._lb.Location = new System.Drawing.Point(0, 15);
            this._lb.Name = "_lb";
            this._lb.Size = new System.Drawing.Size(159, 93);
            this._lb.TabIndex = 7;
            // 
            // _btLaunch
            // 
            this._btLaunch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this._btLaunch.Location = new System.Drawing.Point(165, 15);
            this._btLaunch.Name = "_btLaunch";
            this._btLaunch.Size = new System.Drawing.Size(68, 93);
            this._btLaunch.TabIndex = 8;
            this._btLaunch.Text = "Launch";
            this._btLaunch.Click += new System.EventHandler(this._btLaunch_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Gray;
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.listBox1.Location = new System.Drawing.Point(3, 60);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(236, 90);
            this.listBox1.TabIndex = 9;
            // 
            // _plExamples
            // 
            this._plExamples.BackColor = System.Drawing.Color.White;
            this._plExamples.Controls.Add(this._btLaunch);
            this._plExamples.Controls.Add(this._lb);
            this._plExamples.Controls.Add(this.label3);
            this._plExamples.Enabled = false;
            this._plExamples.Location = new System.Drawing.Point(3, 156);
            this._plExamples.Name = "_plExamples";
            this._plExamples.Size = new System.Drawing.Size(236, 116);
            // 
            // _btSettings
            // 
            this._btSettings.Location = new System.Drawing.Point(6, 24);
            this._btSettings.Name = "_btSettings";
            this._btSettings.Size = new System.Drawing.Size(138, 30);
            this._btSettings.TabIndex = 20;
            this._btSettings.Text = "Connection settings";
            this._btSettings.Click += new System.EventHandler(this._btSettings_Click);
            // 
            // _lblRFIDDriverStatus
            // 
            this._lblRFIDDriverStatus.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this._lblRFIDDriverStatus.Location = new System.Drawing.Point(6, 3);
            this._lblRFIDDriverStatus.Name = "_lblRFIDDriverStatus";
            this._lblRFIDDriverStatus.Size = new System.Drawing.Size(141, 20);
            this._lblRFIDDriverStatus.Text = "label1";
            // 
            // _btDriverInformation
            // 
            this._btDriverInformation.Location = new System.Drawing.Point(150, 3);
            this._btDriverInformation.Name = "_btDriverInformation";
            this._btDriverInformation.Size = new System.Drawing.Size(86, 17);
            this._btDriverInformation.TabIndex = 22;
            this._btDriverInformation.Text = "Driver infos";
            this._btDriverInformation.Click += new System.EventHandler(this._btDriverInformation_Click);
            // 
            // HID_Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(242, 295);
            this.Controls.Add(this._btDriverInformation);
            this.Controls.Add(this._lblRFIDDriverStatus);
            this.Controls.Add(this._btSettings);
            this.Controls.Add(this._plExamples);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this._btConnect);
            this.MinimizeBox = false;
            this.Name = "HID_Launcher";
            this.Text = "HID Launcher";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.HID_Launcher_Closing);
            this._plExamples.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox _lb;
        private System.Windows.Forms.Button _btLaunch;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel _plExamples;
        private System.Windows.Forms.Button _btSettings;
        private System.Windows.Forms.Label _lblRFIDDriverStatus;
        private System.Windows.Forms.Button _btDriverInformation;
    }
}