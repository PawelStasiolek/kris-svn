namespace PDAClient
{
    partial class FormDeliver
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.txtPallet = new System.Windows.Forms.TextBox();
            this.txtContainer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPallet
            // 
            this.txtPallet.Location = new System.Drawing.Point(72, 29);
            this.txtPallet.MaxLength = 20;
            this.txtPallet.Name = "txtPallet";
            this.txtPallet.Size = new System.Drawing.Size(147, 23);
            this.txtPallet.TabIndex = 19;
            this.txtPallet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // txtContainer
            // 
            this.txtContainer.Location = new System.Drawing.Point(72, 3);
            this.txtContainer.MaxLength = 20;
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(147, 23);
            this.txtContainer.TabIndex = 18;
            this.txtContainer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "托盘号：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "柜号：";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.LightBlue;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Location = new System.Drawing.Point(225, 29);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 29;
            this.btnBack.Text = "返回";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Lime;
            this.btnOk.Location = new System.Drawing.Point(225, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 23);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "确认";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FormDeliver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPallet);
            this.Controls.Add(this.txtContainer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDeliver";
            this.Text = "发货审核";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.FormDeliver_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPallet;
        private System.Windows.Forms.TextBox txtContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnOk;
    }
}