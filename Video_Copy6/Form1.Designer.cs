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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_disk_Info = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.b_Sender = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.C_Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.C_LOGICAL_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_FIELD1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_LOGICAL_FREESPACE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_LOGICAL_PERCENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_IS_ONLINE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.C_PHYSICAL_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_video_info = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ScanDisk = new System.Windows.Forms.Button();
            this.tb_file_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lb_Total_Size = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_refresh_disk = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rb_single = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_Task_Info = new System.Windows.Forms.Label();
            this.rb_dir = new System.Windows.Forms.RadioButton();
            this.lb_Files = new System.Windows.Forms.ListBox();
            this.cb_disk = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_ReceiveMessage = new System.Windows.Forms.RichTextBox();
            this.dgv_Task = new System.Windows.Forms.DataGridView();
            this.lb_Task_count = new System.Windows.Forms.Label();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Task)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1561, 783);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1561, 520);
            this.splitContainer2.SplitterDistance = 448;
            this.splitContainer2.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_disk_Info);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.b_Sender);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 520);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "硬盘信息";
            // 
            // lb_disk_Info
            // 
            this.lb_disk_Info.AutoSize = true;
            this.lb_disk_Info.Location = new System.Drawing.Point(277, 3);
            this.lb_disk_Info.Name = "lb_disk_Info";
            this.lb_disk_Info.Size = new System.Drawing.Size(107, 12);
            this.lb_disk_Info.TabIndex = 12;
            this.lb_disk_Info.Text = "在线：0 ，离线：0";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(144, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 20);
            this.button2.TabIndex = 12;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // b_Sender
            // 
            this.b_Sender.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_Sender.Location = new System.Drawing.Point(206, -1);
            this.b_Sender.Name = "b_Sender";
            this.b_Sender.Size = new System.Drawing.Size(50, 20);
            this.b_Sender.TabIndex = 7;
            this.b_Sender.Text = "刷新";
            this.b_Sender.UseVisualStyleBackColor = true;
            this.b_Sender.Click += new System.EventHandler(this.b_Sender_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_Check,
            this.C_LOGICAL_NAME,
            this.C_FIELD1,
            this.C_LOGICAL_FREESPACE,
            this.C_LOGICAL_PERCENT,
            this.C_IS_ONLINE,
            this.C_PHYSICAL_NAME});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(442, 500);
            this.dataGridView1.TabIndex = 10;
            // 
            // C_Check
            // 
            this.C_Check.FalseValue = "0";
            this.C_Check.HeaderText = "";
            this.C_Check.Name = "C_Check";
            this.C_Check.TrueValue = "1";
            this.C_Check.Width = 20;
            // 
            // C_LOGICAL_NAME
            // 
            this.C_LOGICAL_NAME.DataPropertyName = "LOGICAL_NAME";
            this.C_LOGICAL_NAME.HeaderText = "硬盘";
            this.C_LOGICAL_NAME.Name = "C_LOGICAL_NAME";
            this.C_LOGICAL_NAME.ReadOnly = true;
            this.C_LOGICAL_NAME.Width = 50;
            // 
            // C_FIELD1
            // 
            this.C_FIELD1.DataPropertyName = "FIELD1";
            this.C_FIELD1.HeaderText = "名称";
            this.C_FIELD1.Name = "C_FIELD1";
            this.C_FIELD1.ReadOnly = true;
            this.C_FIELD1.Width = 50;
            // 
            // C_LOGICAL_FREESPACE
            // 
            this.C_LOGICAL_FREESPACE.DataPropertyName = "LOGICAL_FREESPACE";
            this.C_LOGICAL_FREESPACE.HeaderText = "剩余(GB)";
            this.C_LOGICAL_FREESPACE.Name = "C_LOGICAL_FREESPACE";
            this.C_LOGICAL_FREESPACE.ReadOnly = true;
            this.C_LOGICAL_FREESPACE.Width = 60;
            // 
            // C_LOGICAL_PERCENT
            // 
            this.C_LOGICAL_PERCENT.DataPropertyName = "LOGICAL_PERCENT";
            this.C_LOGICAL_PERCENT.HeaderText = "占用%";
            this.C_LOGICAL_PERCENT.Name = "C_LOGICAL_PERCENT";
            this.C_LOGICAL_PERCENT.ReadOnly = true;
            this.C_LOGICAL_PERCENT.Width = 60;
            // 
            // C_IS_ONLINE
            // 
            this.C_IS_ONLINE.DataPropertyName = "IS_ONLINE";
            this.C_IS_ONLINE.FalseValue = "0";
            this.C_IS_ONLINE.HeaderText = "在线";
            this.C_IS_ONLINE.Name = "C_IS_ONLINE";
            this.C_IS_ONLINE.ReadOnly = true;
            this.C_IS_ONLINE.TrueValue = "1";
            this.C_IS_ONLINE.Width = 40;
            // 
            // C_PHYSICAL_NAME
            // 
            this.C_PHYSICAL_NAME.DataPropertyName = "PHYSICAL_NAME";
            this.C_PHYSICAL_NAME.HeaderText = "物理名称";
            this.C_PHYSICAL_NAME.Name = "C_PHYSICAL_NAME";
            this.C_PHYSICAL_NAME.ReadOnly = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer3.Size = new System.Drawing.Size(1109, 520);
            this.splitContainer3.SplitterDistance = 556;
            this.splitContainer3.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Controls.Add(this.lb_video_info);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btn_ScanDisk);
            this.groupBox3.Controls.Add(this.tb_file_name);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btn_Search);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(556, 520);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询信息";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5});
            this.dataGridView2.Location = new System.Drawing.Point(3, 70);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(550, 447);
            this.dataGridView2.TabIndex = 16;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FalseValue = "0";
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.TrueValue = "1";
            this.dataGridViewCheckBoxColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FILE_NAME";
            this.dataGridViewTextBoxColumn1.HeaderText = "名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FILESIZE";
            this.dataGridViewTextBoxColumn3.HeaderText = "大小(GB)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FILE_FULLPATH";
            this.dataGridViewTextBoxColumn5.HeaderText = "路径";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 400;
            // 
            // lb_video_info
            // 
            this.lb_video_info.AutoSize = true;
            this.lb_video_info.Location = new System.Drawing.Point(441, 53);
            this.lb_video_info.Name = "lb_video_info";
            this.lb_video_info.Size = new System.Drawing.Size(47, 12);
            this.lb_video_info.TabIndex = 15;
            this.lb_video_info.Text = "数量：0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(88, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "模糊查询所有影片库中满足条件的前20部电影，条件不能为空";
            // 
            // btn_ScanDisk
            // 
            this.btn_ScanDisk.Location = new System.Drawing.Point(11, 18);
            this.btn_ScanDisk.Name = "btn_ScanDisk";
            this.btn_ScanDisk.Size = new System.Drawing.Size(87, 26);
            this.btn_ScanDisk.TabIndex = 13;
            this.btn_ScanDisk.Text = "<- 扫描硬盘";
            this.btn_ScanDisk.UseVisualStyleBackColor = true;
            this.btn_ScanDisk.Click += new System.EventHandler(this.button3_Click);
            // 
            // tb_file_name
            // 
            this.tb_file_name.Location = new System.Drawing.Point(151, 21);
            this.tb_file_name.Name = "tb_file_name";
            this.tb_file_name.Size = new System.Drawing.Size(284, 21);
            this.tb_file_name.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "影名：";
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(441, 18);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(87, 26);
            this.btn_Search.TabIndex = 10;
            this.btn_Search.Text = "查询";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(549, 520);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "拷贝文件";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.lb_Task_count);
            this.groupBox6.Controls.Add(this.dgv_Task);
            this.groupBox6.Controls.Add(this.lb_Total_Size);
            this.groupBox6.Controls.Add(this.btn_Start);
            this.groupBox6.Controls.Add(this.btn_refresh_disk);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.rb_single);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.lb_Task_Info);
            this.groupBox6.Controls.Add(this.rb_dir);
            this.groupBox6.Controls.Add(this.lb_Files);
            this.groupBox6.Controls.Add(this.cb_disk);
            this.groupBox6.Controls.Add(this.button4);
            this.groupBox6.Location = new System.Drawing.Point(6, 17);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(543, 497);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "任务";
            // 
            // lb_Total_Size
            // 
            this.lb_Total_Size.AutoSize = true;
            this.lb_Total_Size.Location = new System.Drawing.Point(189, 36);
            this.lb_Total_Size.Name = "lb_Total_Size";
            this.lb_Total_Size.Size = new System.Drawing.Size(47, 12);
            this.lb_Total_Size.TabIndex = 22;
            this.lb_Total_Size.Text = "共：0GB";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(366, 107);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(87, 34);
            this.btn_Start.TabIndex = 15;
            this.btn_Start.Text = "开始任务";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_refresh_disk
            // 
            this.btn_refresh_disk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_refresh_disk.Location = new System.Drawing.Point(450, 52);
            this.btn_refresh_disk.Name = "btn_refresh_disk";
            this.btn_refresh_disk.Size = new System.Drawing.Size(50, 20);
            this.btn_refresh_disk.TabIndex = 19;
            this.btn_refresh_disk.Text = "刷新";
            this.btn_refresh_disk.UseVisualStyleBackColor = true;
            this.btn_refresh_disk.Click += new System.EventHandler(this.btn_refresh_disk_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(159, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "查找失败请重新扫描硬盘";
            // 
            // rb_single
            // 
            this.rb_single.AutoSize = true;
            this.rb_single.Checked = true;
            this.rb_single.Location = new System.Drawing.Point(317, 20);
            this.rb_single.Name = "rb_single";
            this.rb_single.Size = new System.Drawing.Size(71, 16);
            this.rb_single.TabIndex = 13;
            this.rb_single.TabStop = true;
            this.rb_single.Text = "文件拷贝";
            this.rb_single.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "目标硬盘：";
            // 
            // lb_Task_Info
            // 
            this.lb_Task_Info.AutoSize = true;
            this.lb_Task_Info.Location = new System.Drawing.Point(43, 36);
            this.lb_Task_Info.Name = "lb_Task_Info";
            this.lb_Task_Info.Size = new System.Drawing.Size(101, 12);
            this.lb_Task_Info.TabIndex = 16;
            this.lb_Task_Info.Text = "成功：0，失败：0";
            // 
            // rb_dir
            // 
            this.rb_dir.AutoSize = true;
            this.rb_dir.Location = new System.Drawing.Point(417, 20);
            this.rb_dir.Name = "rb_dir";
            this.rb_dir.Size = new System.Drawing.Size(71, 16);
            this.rb_dir.TabIndex = 14;
            this.rb_dir.Text = "目录拷贝";
            this.rb_dir.UseVisualStyleBackColor = true;
            // 
            // lb_Files
            // 
            this.lb_Files.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_Files.FormattingEnabled = true;
            this.lb_Files.ItemHeight = 12;
            this.lb_Files.Location = new System.Drawing.Point(6, 53);
            this.lb_Files.Name = "lb_Files";
            this.lb_Files.Size = new System.Drawing.Size(302, 436);
            this.lb_Files.TabIndex = 12;
            // 
            // cb_disk
            // 
            this.cb_disk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_disk.FormattingEnabled = true;
            this.cb_disk.Location = new System.Drawing.Point(317, 81);
            this.cb_disk.Name = "cb_disk";
            this.cb_disk.Size = new System.Drawing.Size(183, 20);
            this.cb_disk.TabIndex = 17;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(57, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 26);
            this.button4.TabIndex = 11;
            this.button4.Text = "导入任务";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            // dgv_Task
            // 
            this.dgv_Task.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Task.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Task.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6});
            this.dgv_Task.Location = new System.Drawing.Point(314, 147);
            this.dgv_Task.Name = "dgv_Task";
            this.dgv_Task.RowTemplate.Height = 23;
            this.dgv_Task.Size = new System.Drawing.Size(223, 342);
            this.dgv_Task.TabIndex = 23;
            // 
            // lb_Task_count
            // 
            this.lb_Task_count.AutoSize = true;
            this.lb_Task_count.Location = new System.Drawing.Point(471, 132);
            this.lb_Task_count.Name = "lb_Task_count";
            this.lb_Task_count.Size = new System.Drawing.Size(47, 12);
            this.lb_Task_count.TabIndex = 24;
            this.lb_Task_count.Tag = "0";
            this.lb_Task_count.Text = "数量：0";
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.FalseValue = "0";
            this.dataGridViewCheckBoxColumn2.HeaderText = "";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.TrueValue = "1";
            this.dataGridViewCheckBoxColumn2.Width = 20;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FILE_NAME";
            this.dataGridViewTextBoxColumn2.HeaderText = "S大小";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FILESIZE";
            this.dataGridViewTextBoxColumn4.HeaderText = "T目标";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FILE_FULLPATH";
            this.dataGridViewTextBoxColumn6.HeaderText = "T大小";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 60;
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
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Task)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox tb_ReceiveMessage;
        private System.Windows.Forms.Button b_Sender;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lb_disk_Info;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn C_Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_LOGICAL_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_FIELD1;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_LOGICAL_FREESPACE;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_LOGICAL_PERCENT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn C_IS_ONLINE;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_PHYSICAL_NAME;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_ScanDisk;
        private System.Windows.Forms.TextBox tb_file_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label lb_video_info;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lb_Task_Info;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.RadioButton rb_dir;
        private System.Windows.Forms.RadioButton rb_single;
        private System.Windows.Forms.ListBox lb_Files;
        private System.Windows.Forms.Button btn_refresh_disk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_disk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_Total_Size;
        private System.Windows.Forms.DataGridView dgv_Task;
        private System.Windows.Forms.Label lb_Task_count;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}

