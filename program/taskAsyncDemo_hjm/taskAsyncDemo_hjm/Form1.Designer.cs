namespace taskAsyncDemo_hjm
{
    partial class Form1
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
            this.btnTask = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.tboxTask1Time = new System.Windows.Forms.TextBox();
            this.tboxTask2Time = new System.Windows.Forms.TextBox();
            this.tboxTask3Time = new System.Windows.Forms.TextBox();
            this.tboxTask4Time = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTask
            // 
            this.btnTask.Location = new System.Drawing.Point(49, 68);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(75, 23);
            this.btnTask.TabIndex = 0;
            this.btnTask.Text = "btnTask";
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(156, 67);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(75, 23);
            this.btnAsync.TabIndex = 1;
            this.btnAsync.Text = "btnAsync";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // tboxTask1Time
            // 
            this.tboxTask1Time.Location = new System.Drawing.Point(12, 137);
            this.tboxTask1Time.Name = "tboxTask1Time";
            this.tboxTask1Time.Size = new System.Drawing.Size(57, 21);
            this.tboxTask1Time.TabIndex = 2;
            this.tboxTask1Time.Text = "1000";
            // 
            // tboxTask2Time
            // 
            this.tboxTask2Time.Location = new System.Drawing.Point(86, 137);
            this.tboxTask2Time.Name = "tboxTask2Time";
            this.tboxTask2Time.Size = new System.Drawing.Size(57, 21);
            this.tboxTask2Time.TabIndex = 3;
            this.tboxTask2Time.Text = "1000";
            // 
            // tboxTask3Time
            // 
            this.tboxTask3Time.Location = new System.Drawing.Point(156, 137);
            this.tboxTask3Time.Name = "tboxTask3Time";
            this.tboxTask3Time.Size = new System.Drawing.Size(57, 21);
            this.tboxTask3Time.TabIndex = 4;
            this.tboxTask3Time.Text = "1000";
            // 
            // tboxTask4Time
            // 
            this.tboxTask4Time.Location = new System.Drawing.Point(229, 137);
            this.tboxTask4Time.Name = "tboxTask4Time";
            this.tboxTask4Time.Size = new System.Drawing.Size(57, 21);
            this.tboxTask4Time.TabIndex = 5;
            this.tboxTask4Time.Text = "1000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Task time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxTask4Time);
            this.Controls.Add(this.tboxTask3Time);
            this.Controls.Add(this.tboxTask2Time);
            this.Controls.Add(this.tboxTask1Time);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.btnTask);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTask;
        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.TextBox tboxTask1Time;
        private System.Windows.Forms.TextBox tboxTask2Time;
        private System.Windows.Forms.TextBox tboxTask3Time;
        private System.Windows.Forms.TextBox tboxTask4Time;
        private System.Windows.Forms.Label label1;
    }
}

