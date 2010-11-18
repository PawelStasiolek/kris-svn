namespace PDAClient
{
    partial class FormFCL
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
            this.txtContainer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPallet = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.dgScaned = new System.Windows.Forms.DataGrid();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTotle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtContainer
            // 
            this.txtContainer.Location = new System.Drawing.Point(75, 6);
            this.txtContainer.MaxLength = 20;
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Size = new System.Drawing.Size(147, 23);
            this.txtContainer.TabIndex = 7;
            this.txtContainer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "柜号：";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "托盘号：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "产品编号：";
            // 
            // txtPallet
            // 
            this.txtPallet.Location = new System.Drawing.Point(75, 32);
            this.txtPallet.MaxLength = 20;
            this.txtPallet.Name = "txtPallet";
            this.txtPallet.Size = new System.Drawing.Size(147, 23);
            this.txtPallet.TabIndex = 13;
            this.txtPallet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(75, 58);
            this.txtProduct.MaxLength = 19;
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(147, 23);
            this.txtProduct.TabIndex = 14;
            this.txtProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // dgScaned
            // 
            this.dgScaned.BackgroundColor = System.Drawing.Color.White;
            this.dgScaned.GridLineColor = System.Drawing.Color.Black;
            this.dgScaned.HeaderBackColor = System.Drawing.Color.Yellow;
            this.dgScaned.Location = new System.Drawing.Point(13, 86);
            this.dgScaned.Name = "dgScaned";
            this.dgScaned.RowHeadersVisible = false;
            this.dgScaned.SelectionBackColor = System.Drawing.Color.LightGray;
            this.dgScaned.Size = new System.Drawing.Size(295, 146);
            this.dgScaned.TabIndex = 23;
            this.dgScaned.Paint += new System.Windows.Forms.PaintEventHandler(this.dgScaned_Paint);
            this.dgScaned.DoubleClick += new System.EventHandler(this.dgScaned_DoubleClick);
            this.dgScaned.CurrentCellChanged += new System.EventHandler(this.dgScaned_CurrentCellChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.Lime;
            this.btnUpload.Location = new System.Drawing.Point(236, 6);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(72, 49);
            this.btnUpload.TabIndex = 19;
            this.btnUpload.Text = "上传数据";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.LightBlue;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Location = new System.Drawing.Point(236, 58);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 27;
            this.btnBack.Text = "返回";
            // 
            // lblTotle
            // 
            this.lblTotle.Location = new System.Drawing.Point(13, 238);
            this.lblTotle.Name = "lblTotle";
            this.lblTotle.Size = new System.Drawing.Size(72, 20);
            this.lblTotle.Text = "总计：";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(91, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 20);
            this.label4.Text = "提示：双击可删除已扫描数据";
            // 
            // FormFCL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotle);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgScaned);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.txtPallet);
            this.Controls.Add(this.txtContainer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFCL";
            this.Text = "拼柜";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.FormFCL_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPallet;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.DataGrid dgScaned;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTotle;
        private System.Windows.Forms.Label label4;
    }
}