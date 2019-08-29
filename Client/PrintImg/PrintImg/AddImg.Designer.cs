namespace PrintImg
{
    partial class AddImg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddImg));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtChangjia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGG = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStation_S_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.labId = new System.Windows.Forms.Label();
            this.btnDY = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.lb_Start_Stations = new System.Windows.Forms.ListBox();
            this.txtStation_S_Value = new System.Windows.Forms.TextBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.isChange = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(237, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 19;
            this.button2.Text = "重 置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(47, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 18;
            this.button1.Text = "保 存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtChangjia
            // 
            this.txtChangjia.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtChangjia.Location = new System.Drawing.Point(143, 150);
            this.txtChangjia.Name = "txtChangjia";
            this.txtChangjia.ReadOnly = true;
            this.txtChangjia.Size = new System.Drawing.Size(206, 35);
            this.txtChangjia.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(43, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "厂  家:";
            // 
            // txtGG
            // 
            this.txtGG.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGG.Location = new System.Drawing.Point(143, 95);
            this.txtGG.Name = "txtGG";
            this.txtGG.ReadOnly = true;
            this.txtGG.Size = new System.Drawing.Size(206, 35);
            this.txtGG.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(43, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "规  格:";
            // 
            // txtStation_S_Name
            // 
            this.txtStation_S_Name.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStation_S_Name.Location = new System.Drawing.Point(143, 38);
            this.txtStation_S_Name.Name = "txtStation_S_Name";
            this.txtStation_S_Name.Size = new System.Drawing.Size(206, 35);
            this.txtStation_S_Name.TabIndex = 11;
            this.txtStation_S_Name.Enter += new System.EventHandler(this.txtStation_S_Name_Enter);
            this.txtStation_S_Name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtname_KeyUp);
            this.txtStation_S_Name.Leave += new System.EventHandler(this.txtname_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(43, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "名  称:";
            // 
            // txtPH
            // 
            this.txtPH.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPH.Location = new System.Drawing.Point(143, 204);
            this.txtPH.Name = "txtPH";
            this.txtPH.Size = new System.Drawing.Size(206, 35);
            this.txtPH.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(43, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 24);
            this.label5.TabIndex = 20;
            this.label5.Text = "批  号:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(364, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 324);
            this.panel1.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 324);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(72, 268);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(226, 35);
            this.button3.TabIndex = 23;
            this.button3.Text = "选择图片";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labId
            // 
            this.labId.AutoSize = true;
            this.labId.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labId.Location = new System.Drawing.Point(43, 9);
            this.labId.Name = "labId";
            this.labId.Size = new System.Drawing.Size(34, 24);
            this.labId.TabIndex = 25;
            this.labId.Text = "id";
            this.labId.Visible = false;
            // 
            // btnDY
            // 
            this.btnDY.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDY.ForeColor = System.Drawing.Color.Red;
            this.btnDY.Location = new System.Drawing.Point(428, 27);
            this.btnDY.Name = "btnDY";
            this.btnDY.Size = new System.Drawing.Size(61, 28);
            this.btnDY.TabIndex = 26;
            this.btnDY.Text = "导出图片";
            this.btnDY.UseVisualStyleBackColor = true;
            this.btnDY.Click += new System.EventHandler(this.btnDY_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // lb_Start_Stations
            // 
            this.lb_Start_Stations.FormattingEnabled = true;
            this.lb_Start_Stations.ItemHeight = 12;
            this.lb_Start_Stations.Location = new System.Drawing.Point(138, 74);
            this.lb_Start_Stations.Name = "lb_Start_Stations";
            this.lb_Start_Stations.Size = new System.Drawing.Size(365, 220);
            this.lb_Start_Stations.TabIndex = 27;
            this.lb_Start_Stations.Click += new System.EventHandler(this.lb_Start_Stations_Click);
            this.lb_Start_Stations.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lb_Start_Stations_DrawItem);
            this.lb_Start_Stations.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lb_Start_Stations_MouseMove);
            // 
            // txtStation_S_Value
            // 
            this.txtStation_S_Value.Location = new System.Drawing.Point(143, 13);
            this.txtStation_S_Value.Name = "txtStation_S_Value";
            this.txtStation_S_Value.Size = new System.Drawing.Size(72, 21);
            this.txtStation_S_Value.TabIndex = 28;
            this.txtStation_S_Value.Visible = false;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(588, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(68, 28);
            this.button4.TabIndex = 29;
            this.button4.Tag = "";
            this.button4.Text = "打印预览";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "图片预览:";
            // 
            // isChange
            // 
            this.isChange.AutoSize = true;
            this.isChange.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.isChange.Location = new System.Drawing.Point(278, 5);
            this.isChange.Name = "isChange";
            this.isChange.Size = new System.Drawing.Size(22, 24);
            this.isChange.TabIndex = 31;
            this.isChange.Text = "0";
            this.isChange.Visible = false;
            // 
            // AddImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 396);
            this.Controls.Add(this.isChange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtStation_S_Value);
            this.Controls.Add(this.lb_Start_Stations);
            this.Controls.Add(this.btnDY);
            this.Controls.Add(this.labId);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtPH);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtChangjia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGG);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStation_S_Name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddImg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片保存";
            this.Load += new System.EventHandler(this.AddImg_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtChangjia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStation_S_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labId;
        private System.Windows.Forms.Button btnDY;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ListBox lb_Start_Stations;
        private System.Windows.Forms.TextBox txtStation_S_Value;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label isChange;
    }
}