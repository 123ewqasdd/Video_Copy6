using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Video_Copy6.Classes;
using Video_Copy6.Controls;
using Video_Copy6.Tools;

namespace Video_Copy6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Helper_INI h_ini;
        Helper_Redis h_redis;
        string str_ini = "config.ini";
        string str_r_rec = "";
        string str_r_rep = "";
        string str_copy_dir = "";   //1 拷贝整个目录，0拷贝单个文件
        string str_r_rec_disk = "";
        string str_r_rec_disk_info = "";
        string str_search = "";
        string str_disk_format = "在线：{0} ，离线：{1}";
        string str_match_file = "成功：{0}";
        string str_match_file_size = "共：{0} GB";
        string str_video_format = "数量：{0}";
        string str_Scan_dir = "";
        private bool m_bolHighlight = true;
        private OrderControler order_controler;


        //声明一个委托
        public delegate void SetTextBoxValue(Control c, string value);
        private delegate void SetRichTextValue(string text);//申明委托，防止不同线程设置richtextbox时出现错误
        public delegate void Bind_DGV_DataSource<T>(DataGridView datagridview, List<T> value);

        //委托使用文本框
        void SetMyTextBoxValue(Control c, string value)
        {
            // Control.InvokeRequired 属性： 获取一个值，该值指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中。当前线程不是创建控件的线程时为true,当前线程中访问是False
            if (c.InvokeRequired)
            {
                
                SetTextBoxValue objSetTextBoxValue = new SetTextBoxValue(SetMyTextBoxValue);

                // IAsyncResult 接口：表示异步操作的状态。不同的异步操作需要不同的类型来描述，自然可以返回任何对象。
                // Control.BeginInvoke 方法 (Delegate)：在创建控件的基础句柄所在线程上异步执行指定委托。
                IAsyncResult result = this.tb_ReceiveMessage.BeginInvoke(objSetTextBoxValue, new object[] { c, value });
                try
                {
                    objSetTextBoxValue.EndInvoke(result);
                }
                catch
                {
                }
            }
            else
            {
               
                    c.Text = value;
            }
        }
        void SetrichTextBox(string value)
        {

            if (tb_ReceiveMessage.InvokeRequired)
            {
                SetRichTextValue d = new SetRichTextValue(SetrichTextBox);
                tb_ReceiveMessage.Invoke(d, value);
            }
            else
            {
                if (tb_ReceiveMessage.Lines.Length > 5000)
                {
                    tb_ReceiveMessage.Clear();
                }

                //========richtextbox滚动条自动移至最后一条记录
                //让文本框获取焦点  
                tb_ReceiveMessage.Focus();
                //设置光标的位置到文本尾  
                tb_ReceiveMessage.Select(tb_ReceiveMessage.TextLength, 0);
                //滚动到控件光标处  
                tb_ReceiveMessage.ScrollToCaret();
                if (m_bolHighlight)
                {
                    tb_ReceiveMessage.SelectionFont = new Font("Verdana", 9, FontStyle.Bold);
                    tb_ReceiveMessage.SelectionColor = Color.Red;
                }
                tb_ReceiveMessage.AppendText(value + Environment.NewLine);
            }
        }       

        //void UpdateRichTextBoxValue()
        //{
        //      //更新滚动条
        //    this.tb_ReceiveMessage.SelectionStart = this.tb_ReceiveMessage.TextLength;
        //    this.tb_ReceiveMessage.ScrollToCaret();
        //}

        /// <summary>
        /// 委托表格绑定数据源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datagridview"></param>
        /// <param name="value"></param>
        void SetMyDataViewSourceValue<T>(DataGridView datagridview, List<T> value)
        {
            // Control.InvokeRequired 属性： 获取一个值，该值指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中。当前线程不是创建控件的线程时为true,当前线程中访问是False
            if (datagridview.InvokeRequired)
            {
                Bind_DGV_DataSource<T> objSetTextBoxValue = new Bind_DGV_DataSource<T>(SetMyDataViewSourceValue);

                // IAsyncResult 接口：表示异步操作的状态。不同的异步操作需要不同的类型来描述，自然可以返回任何对象。
                // Control.BeginInvoke 方法 (Delegate)：在创建控件的基础句柄所在线程上异步执行指定委托。
                IAsyncResult result = datagridview.BeginInvoke(objSetTextBoxValue, new object[] { datagridview, value });
                try
                {
                    objSetTextBoxValue.EndInvoke(result);
                }
                catch
                {
                }
            }
            else
            {              
                BindDatagridviewRow<T>(datagridview, value);
            }
        }

        private void BindDatagridviewRow<T>(DataGridView datagridview, List<T> values)
        {
            datagridview.Rows.Clear();
            for (int i = 0; i < values.Count; i++)
            {
                DataGridViewRow dgr = new DataGridViewRow();
                dgr.CreateCells(datagridview);

                for (int j = 1; j < datagridview.ColumnCount; j++)
                {
                    dgr.Cells[j].Value = GetModelValue2(datagridview.Columns[j].DataPropertyName, values[i]);
                }
                dgr.Tag = values[i];
                datagridview.Rows.Add(dgr);
            }
        }

        private object GetModelValue2(string FieldName, object obj)
        {
            try
            {
                Type Ts = obj.GetType();
                object o = Ts.GetProperty(FieldName).GetValue(obj, null);

                return o;
            }
            catch
            {
                return null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetDatagridview_Style(dataGridView1);
            SetDatagridview_Style(dataGridView2);
            SetDatagridview_Style(dgv_Task);
            order_controler = new OrderControler();
            Refresh_DataGridView();
            h_ini = new Helper_INI(str_ini);

            string r_ip = h_ini.ReadString("redis", "ip2", "localhost");
            string r_port = h_ini.ReadString("redis", "port2", "6379");
            string r_pwd = h_ini.ReadString("redis", "pwd2", "");
            int r_DB = h_ini.ReadInteger("redis", "db", 0);
            str_r_rec = h_ini.ReadString("redis", "chan2", "");         //服务器的接收就是这边的发送
            str_r_rep = h_ini.ReadString("redis", "chan1", "");         //服务器的发送频道就是这边的接收频道
            str_r_rec_disk = h_ini.ReadString("redis", "key_disk", "");
            str_r_rec_disk_info = h_ini.ReadString("redis", "key_disk_info", "");

            str_search = h_ini.ReadString("DEFAULT", "scan_filter", ".avi,.mp4,.rmvb");
            str_copy_dir =  h_ini.ReadString("DEFAULT", "copy_dir", "0");

            h_redis = new Helper_Redis();
            h_redis.Use(r_ip, r_port, r_pwd, r_DB);

            h_redis.RedisSubMessageEvent += H_redis_RedisSubMessageEvent;
            h_redis.Use(r_DB).RedisSub(str_r_rec);
            //功能被删除
            //if (str_copy_dir == "1")
            //    rb_dir.Checked = true;
            //else
            //    rb_single.Checked = true;


        }


        private void SetDatagridview_Style(DataGridView datagridview)
        {
            datagridview.AllowUserToAddRows = false;
            
        

            datagridview.AutoGenerateColumns = false;
            //设置列填充满区域
       
            datagridview.AllowUserToResizeColumns = true;
            datagridview.AllowUserToResizeRows = false;
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; 

            //datagridview.BackImage = Image.FromFile(@"C:\Users\Administrator\Desktop\网格背景.jpg");
            ////设置cell背景透明
            //datagridview.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
            //datagridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //datagridview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ////加上这句前面的才起作用
            //datagridview.EnableHeadersVisualStyles = false;

            datagridview.RowsDefaultCellStyle.BackColor = Color.Bisque;
            datagridview.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridview.RowHeadersVisible = false;
            datagridview.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 1; i < datagridview.ColumnCount; i++)
                datagridview.Columns[i].ReadOnly = true;
        }

        private void Refresh_DataGridView()
        {
            List<T_DISK_INFO> tds = MyVideoBussiness.GetList_Disk_Info();
            SetMyDataViewSourceValue(dataGridView1, tds);
            int i_Line = 0, i_offLine = 0;
            for (int i = 0; i < tds.Count; i++)
            {
                if (tds[i].IS_ONLINE == 1)
                    i_Line++;
                else
                    i_offLine++;
            }
            SetMyTextBoxValue(lb_disk_Info, string.Format(str_disk_format, i_Line, i_offLine));
        }

        private void H_redis_RedisSubMessageEvent(string str)
        {          
            //Add_Text_Value(str);
            Result_Info r = (Result_Info)Helper_Json.Decode(str, typeof(Result_Info));            

            if (r.type > 0)
            {
                Helper_log.Write_log(str);
                if (r.type == 1)
                {                    
                    if (r.code > 0)
                    {
                        List<Disk_Info> ds = (List<Disk_Info>)Helper_Json.Decode(r.msg, typeof(List<Disk_Info>));
                        SetrichTextBox("更新成功数量：" + MyVideoBussiness.Update_Disk_Info(ds));
                        Refresh_DataGridView();
                        SetrichTextBox("更新硬盘成功");
                    }

                }
                else if (r.type == 2)
                {
                    if (r.code == 1)
                    {
                        File_Info fi = (File_Info)Helper_Json.Decode(r.msg, typeof(File_Info));
                        MyVideoBussiness.Add_Video_Info(fi);
                        SetrichTextBox("扫描：" + fi.fileFullPath);
                    }
                }
                else if (r.type == 3)
                {
                    string str_total_size = string.Format(str_match_file_size, Math.Round(r.code, 4));
                    SetMyTextBoxValue(lb_Total_Size, str_total_size);
                    lb_Total_Size.Tag = r.code;
                }
                else if (r.type == 4)
                {
                    string str_msg = "";
                    string[] arr_msg = Regex.Split(r.msg, ",.,", RegexOptions.IgnoreCase);       


                    if (r.flag)
                    {
                        str_msg = "拷贝完成：";
                        if (arr_msg.Length > 2)
                        {
                            for (int i = 0; i < dgv_Task.RowCount; i++)
                            {
                                Task_Info ti = dgv_Task.Rows[i].Tag as Task_Info;
                                if (ti.id == arr_msg[0])
                                {
                                    ti.count_copy_files += Convert.ToInt16(arr_msg[2]);

                                    //判断是否拷贝完成
                                    if (r.code == 0)      //0单文件拷贝
                                    {
                                        if (ti.arr_source.Length == ti.count_copy_files)
                                            dgv_Task.Rows[i].Cells[0].Value = 1;
                                    }
                                    else if (r.code == 1) //1目录拷贝
                                    {
                                        //拷贝目录待判定是否拷贝完成

                                    }
                                    MyVideoBussiness.Update_Task_Info(ti.id, ti.count_copy_files);
                                    break;
                                }
                            }
                        }
                        //待完成目录拷贝的判定
                       

                    }
                    else
                    {
                        str_msg = "拷贝失败：";
                    }
                    str_msg += r.msg;
                    SetrichTextBox(str_msg);
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string str_name = tb_file_name.Text.Trim();
            if (!string.IsNullOrEmpty(str_name))
            {
                List<T_Video> vs = MyVideoBussiness.GetList_Video_Info_Like(str_name);
                SetMyDataViewSourceValue(dataGridView2, vs);                
                SetMyTextBoxValue(lb_video_info, string.Format(str_video_format, vs.Count));
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            List<T_DISK_INFO> tds = MyVideoBussiness.GetList_Disk_Info();
            SetMyDataViewSourceValue(dataGridView1,tds);
        }

        private void b_Sender_Click(object sender, EventArgs e)
        {
            Command_info c = new Command_info();
            c.type = 1;
            c.msg = "";
            c.msg2 = "";
            string str_c = Helper_Json.Encode(c);
            SetrichTextBox("刷新所有硬盘信息.....");
            long r_l = h_redis.RedisPub(str_r_rep, str_c); 
            Helper_log.Write_log(str_r_rep + ":" + str_c);
        }

        private void b_SearchFile_Click(object sender, EventArgs e)
        {
            Command_info c = new Command_info();
            c.type = 2;
            c.msg = "D:\\,.,E:\\";
            c.msg2 = str_search;
            string str_c = Helper_Json.Encode(c);

            long r_l = h_redis.RedisPub(str_r_rep, str_c);
            SetrichTextBox(str_r_rep + ":" + str_c);
        }

        private List<T_DISK_INFO> Get_Selected_DISK_INFO()
        {
            List<T_DISK_INFO> l_dele = new List<T_DISK_INFO>();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() == "1")
                {
                    T_DISK_INFO tdi = dataGridView1.Rows[i].Tag as T_DISK_INFO;
                    l_dele.Add(tdi);
                }
            }
            return l_dele;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<T_DISK_INFO> l_dele = Get_Selected_DISK_INFO();
            if (l_dele.Count > 0)
            {
                int i_delete =  MyVideoBussiness.Delete_Disk_Info(l_dele);
                SetrichTextBox("删除硬盘数量：" + i_delete);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> arr_disklist = new List<string>();
            List<int> arr_disk_id_list = new List<int>();
            List<string> arr_disk_list_offline = new List<string>();
            
            int i_count_disk_online = 0, i_count_disk_offline = 0;
            List<T_DISK_INFO> l_tdi = Get_Selected_DISK_INFO();
            if (l_tdi.Count > 0)
            {
                foreach (var di in l_tdi)
                {
                    if (di.IS_ONLINE == 1)
                    {
                        i_count_disk_online++;
                        arr_disklist.Add(di.LOGICAL_NAME);
                        arr_disk_id_list.Add(Convert.ToInt32(di.ID));                        
                    }
                    else
                    {
                        i_count_disk_offline++;
                        arr_disk_list_offline.Add(di.LOGICAL_NAME);
                        
                    }
                }
                //if (i_count_disk_online > 0)
                //{
                //    str_disklist = str_disklist.Substring(0, str_disklist.Length - 3);
                //    str_disk_id_list = str_disk_id_list.Substring(0, str_disk_id_list.Length - 3);
                //}

                if (i_count_disk_online == 0)
                {
                    SetrichTextBox("请选择待扫描的在线硬盘");
                    return;
                }
                if (i_count_disk_offline > 0)
                {
                    SetrichTextBox("以下硬盘离线，系统将不扫描。" + string.Join(",", arr_disk_list_offline));                    
                }

                //删除影片表中对应盘符下的影片，以备重新扫描
                foreach (var id in arr_disk_id_list)
                {
                    MyVideoBussiness.Delete_Video_Info(id);
                }

                Command_info c = new Command_info();
                c.type = 2;
                for (int i = 0; i < arr_disklist.Count; i++)
                {
                    if (i == arr_disklist.Count - 1)
                    {
                        c.msg += arr_disklist[i] + "\\";
                    }
                    else
                    {
                        c.msg += arr_disklist[i] + "\\,.,";
                    }
                }
                //c.msg = @"D:\chao\工作\电影程序\Data";

                c.msg2 = str_search;
                c.tag = string.Join(",.,", arr_disk_id_list); 
                string str_c = Helper_Json.Encode(c);
                SetrichTextBox("开始扫描....." + i_count_disk_online + "..." + string.Join(",", arr_disklist));
                str_Scan_dir = "";
                long r_l = h_redis.RedisPub(str_r_rep, str_c);              

            }
        }

        private void btn_refresh_disk_Click(object sender, EventArgs e)
        {
            List<T_DISK_INFO> ds = MyVideoBussiness.GetList_Disk_Info();
            cb_disk.Items.Clear();
            string str_format = "{0}(可用：{1}GB，总：{2}GB)";
            string str_display = "";
            for (int i = 0; i < ds.Count ; i++)
            {
                if (ds[i].IS_ONLINE == 1)
                {
                    str_display = string.Format(str_format, ds[i].FIELD1 +"|" + ds[i].LOGICAL_NAME, Math.Round(ds[i].LOGICAL_FREESPACE.Value, 2), Math.Round(ds[i].LOGICAL_TOTALSIZE.Value, 2));
                    cb_disk.Items.Add(str_display);                   
                }
            }
            cb_disk.Tag = ds;
            if (cb_disk.Items.Count > 0)
                cb_disk.SelectedIndex = cb_disk.Items.Count - 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "文本文件|*.txt";
                ofd.Multiselect = false;//是否允许多选，false表示单选
                if (ofd.ShowDialog() == DialogResult.OK)  //如果点击的是打开文件
                {
                    lb_Files.Items.Clear();
                    lb_Files.Tag = null;
                    try
                    {
                        //int i_success = 0, i_fail = 0;
                        //string str_temp = "";
                        //List<T_Video> lts = new List<T_Video>();
                        //string[] arr_files = Helper_Txt.ReadAllLines(ofd.FileName, Encoding.UTF8);  //获取全路径文件名

                        //for (int i = 0; i < arr_files.Length; i++)
                        //{
                        //    T_Video v = MyVideoBussiness.GetList_Video_Info(arr_files[i]);
                        //    if (v == null)
                        //    {
                        //        i_fail++;
                        //        str_temp = "NO  NULL  " + arr_files[i];

                        //    }
                        //    else
                        //    {
                        //        i_success++;
                        //        str_temp = "OK  "+ v.FILE_ROOT + "  " + arr_files[i];
                        //        lts.Add(v);
                        //    }
                        //    lb_Files.Items.Add(str_temp);
                        //}
                        //SetMyTextBoxValue(lb_Task_Info, string.Format(str_match_file, i_success, i_fail));
                        //lb_Files.Tag = lts;

                        //if (lts.Count > 0)
                        //{
                        //    Command_info c = new Command_info();
                        //    c.type = 3;
                        //    if (rb_dir.Checked)
                        //    {
                        //        c.msg = string.Join(",.,", lts.Select(s => s.FILE_DIR).Distinct());
                        //        c.msg2 = "1";
                        //    }
                        //    else
                        //    {
                        //        c.msg = string.Join(",.,", lts.Select(s => s.FILE_FULLPATH));
                        //        c.msg2 = "0";
                        //    }                            
                        //    string str_c = Helper_Json.Encode(c);
                        //    SetrichTextBox("刷新所有硬盘信息.....");
                        //    long r_l = h_redis.RedisPub(str_r_rep, str_c);
                        //    Helper_log.Write_log(str_r_rep + ":" + str_c);
                        //}

                        List<T_Video> lts = new List<T_Video>();
                        string[] arr_files = Helper_Txt.ReadAllLines(ofd.FileName, Encoding.UTF8);  //获取全路径文件名
                        for (int i = 0; i < arr_files.Length; i++)
                        {
                            T_Video v = MyVideoBussiness.GetList_Video_Info(arr_files[i]);
                            if (v != null)
                            {
                                lts.Add(v);
                            }
                            else
                            {
                                lb_Files.Items.Add("NO  " + arr_files[i]);
                            }
                        }
                        Add_Task_Node(lts);
                    }
                    catch (Exception ex)
                    {
                        Helper_log.Write_Error(ex.Message);
                    }
                   
                    
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<T_Video> lts = new List<T_Video>();
            foreach (TreeNode tn in tv_videos.Nodes)
            {
                foreach (TreeNode sub_tn in tn.Nodes)
                {
                    lts.Add((T_Video)sub_tn.Tag);
                }
            }
            Add_Task_Node(lts);
        }

        private void Add_Task_Node(List<T_Video> vs)
        {
            int i_success = 0;
            double d_total_size = 0;
            string str_temp = "";
            foreach (var v in vs)
            {
                i_success++;
                str_temp = "OK  " + v.FILE_ROOT + "  " + v.FILE_NAME;
                d_total_size += (v.FILESIZE.HasValue ? v.FILESIZE.Value : 0);
                lb_Files.Items.Add(str_temp);
            }
            SetMyTextBoxValue(lb_Task_Info, string.Format(str_match_file, i_success));
            lb_Files.Tag = vs;
            string str_total_size = string.Format(str_match_file_size, Math.Round(d_total_size, 4));
            SetMyTextBoxValue(lb_Total_Size, str_total_size);
            lb_Total_Size.Tag = d_total_size;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lb_Files.Tag != null && cb_disk.Tag != null)
            {
                List<T_Video> lts = (List<T_Video>)lb_Files.Tag;
                List<T_DISK_INFO> dis = (List<T_DISK_INFO>)cb_disk.Tag;
                T_DISK_INFO di = dis[cb_disk.SelectedIndex];
                double d_source_size = 0;
                if (lb_Total_Size.Tag != null)
                    d_source_size = Math.Round((double)lb_Total_Size.Tag, 4);

                Task_Info ti = new Task_Info();
                ti.id = Guid.NewGuid().ToString();             
                List<string> arr_file_path = new List<string>();
                List<string> arr_copy_type = new List<string>();
                foreach (var v in lts)
                {
                    arr_file_path.Add(v.FILE_FULLPATH);
                    if (v.FILE_INDEX == "1")
                        arr_copy_type.Add(v.FILE_INDEX);
                    else
                        arr_copy_type.Add("0");
                }
                ti.arr_source = arr_file_path.ToArray();
                ti.copy_type = string.Join(",.,", arr_copy_type);

                ti.source_size = d_source_size;
                ti.target = di.LOGICAL_NAME;
                if (di.LOGICAL_TOTALSIZE.HasValue)
                    ti.target_size = Math.Round(di.LOGICAL_TOTALSIZE.Value, 4);
                if (di.LOGICAL_FREESPACE.HasValue)
                    ti.target_free_size = di.LOGICAL_FREESPACE.Value;

                int i_exists = -1;      //是否存在相同的硬盘拷贝
                for (int i = 0; i < lts.Count; i++)
                    if (lts[i].FILE_ROOT == ti.target)
                    {
                        i_exists = i;
                        break;
                    }

                //此处应该增加排除相同任务的判定，待到重构时增加



                if (i_exists > -1)
                {
                    if (MessageBox.Show("拷贝任务中拷贝文件【" + (i_exists + 1) + "】存在源硬盘与目标硬盘名称相同【"+ ti.target +"】，是否继续？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                    {
                        return;
                    }
                }

                //待添加硬盘剩余空间的判定


                DataGridViewRow dr = new DataGridViewRow();
                dr.CreateCells(dgv_Task);
                dr.Cells[0].Value = "0";
                dr.Cells[1].Value = ti.source_size;
                dr.Cells[2].Value = ti.target;
                dr.Cells[3].Value = ti.target_size;
                dr.Tag = ti;
                //添加的行作为第一行
                dgv_Task.Rows.Insert(0, dr);

                int i_count = Convert.ToInt16(lb_Task_count.Tag);
                i_count++;
                string str_format = "数量：{0}";
                lb_Task_count.Tag = i_count;
                lb_Task_count.Text = string.Format(str_format, i_count);

                Command_info c = new Command_info();
                c.type = 4;
                c.msg = string.Join(",.,", ti.arr_source);
                c.msg2 = ti.copy_type;
                c.tag = Helper_Json.Encode(ti);
                //c.tag = ti.id;
                string str_c = Helper_Json.Encode(c);
               
                int i_success = MyVideoBussiness.Add_Task_Info(ti, lts);
                if (i_success > 0)
                {
                    long r_l = h_redis.RedisPub(str_r_rep, str_c);
                    SetrichTextBox("拷贝任务....." + ti.arr_source.Length + "..." + i_success);
                }
                else
                {
                    SetrichTextBox("记录失败....." + i_success+ "...");
                }


            }
        }

        private void btn_Import_txt_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "文本文件|*.txt";
                ofd.Multiselect = false;//是否允许多选，false表示单选
                if (ofd.ShowDialog() == DialogResult.OK)  //如果点击的是打开文件
                {
                    string[] arr_files = Helper_Txt.ReadAllLines(ofd.FileName, Encoding.UTF8);  //获取全路径文件名
                    int i_count = order_controler.Get_My_Videos(tv_videos, arr_files);
                    lb_video_order_found.Text = string.Format(str_video_format, i_count);
                }
            }
        }

        private void Refresh_Node_Count()
        {
            int i_count = 0;
            foreach (TreeNode tn in tv_videos.Nodes)
            {
                i_count += tn.Nodes.Count;
            }
            lb_video_order_found.Text = string.Format(str_video_format, i_count);

        }

        private void btn_Import_Excel_Click(object sender, EventArgs e)
        {
            List<T_Video> vs = MyVideoBussiness.GetList_Video_Info_Like("石");
            SetrichTextBox("....." + vs.Count);
        }

        private void tv_videos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(!string.IsNullOrEmpty(e.Node.Text))
            {
                if (e.Node.Level == 0)
                {
                    string str_name = e.Node.Text;
                    str_name = order_controler.replace_string(str_name);
                    tabControl1.SelectedIndex = 1;
                    tb_file_name.Text = str_name;
                    btn_Search.PerformClick();
                }
                else if (e.Node.Level == 1)
                {
                    e.Node.Remove();
                    Refresh_Node_Count();
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            List<T_Video> vs = new List<T_Video>();
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value != null && dataGridView2.Rows[i].Cells[0].Value.ToString() == "1")
                {
                    vs.Add((T_Video)dataGridView2.Rows[i].Tag);
                }
            }
            if (vs.Count > 0)
            {
                if (tv_videos.Nodes.Count > 0)
                {
                    foreach (var tvn in vs)
                    {
                        TreeNode tn = new TreeNode(tvn.FILE_NAME);
                        tn.Tag = tvn;
                        tv_videos.Nodes[tv_videos.Nodes.Count - 1].Nodes.Add(tn);
                    }
                    tv_videos.Focus();
                    tv_videos.Nodes[tv_videos.Nodes.Count - 1].Expand();
                    tv_videos.SelectedNode = tv_videos.Nodes[tv_videos.Nodes.Count - 1].Nodes[tv_videos.Nodes[tv_videos.Nodes.Count - 1].Nodes.Count -1];//选中
                    Refresh_Node_Count();
                    tabControl1.SelectedIndex = 0;
                }
            }
        }


    }
}
