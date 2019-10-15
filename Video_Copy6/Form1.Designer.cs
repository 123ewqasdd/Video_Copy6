namespace Video_Copy6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.b_SearchFile = new System.Windows.Forms.Button();
            this.b_Sender = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_ReceiveMessage = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.b_SearchFile);
            this.splitContainer1.Panel1.Controls.Add(this.b_Sender);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1561, 783);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_SearchFile
            // 
            this.b_SearchFile.Location = new System.Drawing.Point(34, 66);
            this.b_SearchFile.Name = "b_SearchFile";
            this.b_SearchFile.Size = new System.Drawing.Size(87, 26);
            this.b_SearchFile.TabIndex = 8;
            this.b_SearchFile.Text = "扫描文件";
            this.b_SearchFile.UseVisualStyleBackColor = true;
            this.b_SearchFile.Click += new System.EventHandler(this.b_SearchFile_Click);
            // 
            // b_Sender
            // 
            this.b_Sender.Location = new System.Drawing.Point(34, 21);
            this.b_Sender.Name = "b_Sender";
            this.b_Sender.Size = new System.Drawing.Size(87, 26);
            this.b_Sender.TabIndex = 7;
            this.b_Sender.Text = "获取硬盘";
            this.b_Sender.UseVisualStyleBackColor = true;
            this.b_Sender.Click += new System.EventHandler(this.b_Sender_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_ReceiveMessage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1561, 259);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志";
            // 
            // tb_ReceiveMessage
            // 
            this.tb_ReceiveMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ReceiveMessage.Location = new System.Drawing.Point(3, 17);
            this.tb_ReceiveMessage.Name = "tb_ReceiveMessage";
            this.tb_ReceiveMessage.Size = new System.Drawing.Size(1555, 239);
            this.tb_ReceiveMessage.TabIndex = 3;
            this.tb_ReceiveMessage.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1561, 783);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "终端界面";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox tb_ReceiveMessage;
        private System.Windows.Forms.Button b_SearchFile;
        private System.Windows.Forms.Button b_Sender;
        private System.Windows.Forms.Button button1;
    }
}

