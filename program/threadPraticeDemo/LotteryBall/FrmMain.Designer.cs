namespace LotteryBall
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBlue1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblBlue2 = new System.Windows.Forms.Label();
            this.lblBlue3 = new System.Windows.Forms.Label();
            this.lblBlue4 = new System.Windows.Forms.Label();
            this.lblBlue5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBlue1
            // 
            this.lblBlue1.AutoSize = true;
            this.lblBlue1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBlue1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblBlue1.Location = new System.Drawing.Point(69, 186);
            this.lblBlue1.Name = "lblBlue1";
            this.lblBlue1.Size = new System.Drawing.Size(31, 20);
            this.lblBlue1.TabIndex = 0;
            this.lblBlue1.Text = "00";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(206, 406);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblBlue2
            // 
            this.lblBlue2.AutoSize = true;
            this.lblBlue2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBlue2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblBlue2.Location = new System.Drawing.Point(116, 186);
            this.lblBlue2.Name = "lblBlue2";
            this.lblBlue2.Size = new System.Drawing.Size(31, 20);
            this.lblBlue2.TabIndex = 2;
            this.lblBlue2.Text = "00";
            // 
            // lblBlue3
            // 
            this.lblBlue3.AutoSize = true;
            this.lblBlue3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBlue3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblBlue3.Location = new System.Drawing.Point(167, 186);
            this.lblBlue3.Name = "lblBlue3";
            this.lblBlue3.Size = new System.Drawing.Size(31, 20);
            this.lblBlue3.TabIndex = 3;
            this.lblBlue3.Text = "00";
            // 
            // lblBlue4
            // 
            this.lblBlue4.AutoSize = true;
            this.lblBlue4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBlue4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblBlue4.Location = new System.Drawing.Point(214, 186);
            this.lblBlue4.Name = "lblBlue4";
            this.lblBlue4.Size = new System.Drawing.Size(31, 20);
            this.lblBlue4.TabIndex = 4;
            this.lblBlue4.Text = "00";
            // 
            // lblBlue5
            // 
            this.lblBlue5.AutoSize = true;
            this.lblBlue5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBlue5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblBlue5.Location = new System.Drawing.Point(262, 186);
            this.lblBlue5.Name = "lblBlue5";
            this.lblBlue5.Size = new System.Drawing.Size(31, 20);
            this.lblBlue5.TabIndex = 5;
            this.lblBlue5.Text = "00";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 610);
            this.Controls.Add(this.lblBlue5);
            this.Controls.Add(this.lblBlue4);
            this.Controls.Add(this.lblBlue3);
            this.Controls.Add(this.lblBlue2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblBlue1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBlue1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblBlue2;
        private System.Windows.Forms.Label lblBlue3;
        private System.Windows.Forms.Label lblBlue4;
        private System.Windows.Forms.Label lblBlue5;
    }
}

