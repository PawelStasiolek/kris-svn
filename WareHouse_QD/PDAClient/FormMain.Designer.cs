namespace PDAClient
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.picBox_FCL = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picBox_StockIn = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picBox_Check = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picBoxExit = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.picBoxFilter = new System.Windows.Forms.PictureBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.SuspendLayout();
            // 
            // picBox_FCL
            // 
            this.picBox_FCL.BackColor = System.Drawing.Color.White;
            this.picBox_FCL.Image = ((System.Drawing.Image)(resources.GetObject("picBox_FCL.Image")));
            this.picBox_FCL.Location = new System.Drawing.Point(28, 25);
            this.picBox_FCL.Name = "picBox_FCL";
            this.picBox_FCL.Size = new System.Drawing.Size(64, 64);
            this.picBox_FCL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_FCL.Click += new System.EventHandler(this.btnFCL_Click);
            this.picBox_FCL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.Text = "拼  柜";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picBox_StockIn
            // 
            this.picBox_StockIn.BackColor = System.Drawing.Color.White;
            this.picBox_StockIn.Image = ((System.Drawing.Image)(resources.GetObject("picBox_StockIn.Image")));
            this.picBox_StockIn.Location = new System.Drawing.Point(121, 25);
            this.picBox_StockIn.Name = "picBox_StockIn";
            this.picBox_StockIn.Size = new System.Drawing.Size(64, 64);
            this.picBox_StockIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_StockIn.Click += new System.EventHandler(this.btnStockIn_Click);
            this.picBox_StockIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(121, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.Text = "入  库";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(215, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.Text = "盘  点";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picBox_Check
            // 
            this.picBox_Check.BackColor = System.Drawing.Color.White;
            this.picBox_Check.Image = ((System.Drawing.Image)(resources.GetObject("picBox_Check.Image")));
            this.picBox_Check.Location = new System.Drawing.Point(215, 25);
            this.picBox_Check.Name = "picBox_Check";
            this.picBox_Check.Size = new System.Drawing.Size(64, 64);
            this.picBox_Check.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_Check.Click += new System.EventHandler(this.picBox_Check_Click);
            this.picBox_Check.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(28, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.Text = "发货复核";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 137);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Click += new System.EventHandler(this.btnDeliver_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(215, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.Text = "退  出";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picBoxExit
            // 
            this.picBoxExit.BackColor = System.Drawing.Color.White;
            this.picBoxExit.Image = ((System.Drawing.Image)(resources.GetObject("picBoxExit.Image")));
            this.picBoxExit.Location = new System.Drawing.Point(215, 137);
            this.picBoxExit.Name = "picBoxExit";
            this.picBoxExit.Size = new System.Drawing.Size(64, 64);
            this.picBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxExit.Click += new System.EventHandler(this.btnExit_Click);
            this.picBoxExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(121, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.Text = "设  置";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picBoxFilter
            // 
            this.picBoxFilter.BackColor = System.Drawing.Color.White;
            this.picBoxFilter.Image = ((System.Drawing.Image)(resources.GetObject("picBoxFilter.Image")));
            this.picBoxFilter.Location = new System.Drawing.Point(121, 137);
            this.picBoxFilter.Name = "picBoxFilter";
            this.picBoxFilter.Size = new System.Drawing.Size(64, 64);
            this.picBoxFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxFilter.Click += new System.EventHandler(this.btnFilter_Click);
            this.picBoxFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 431);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(638, 24);
            this.statusBar1.Text = "当前用户: N/A";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.picBoxFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picBoxExit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picBox_Check);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picBox_StockIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBox_FCL);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "组件产品管理 ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_FCL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBox_StockIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picBox_Check;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picBoxExit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picBoxFilter;
        private System.Windows.Forms.StatusBar statusBar1;
    }
}