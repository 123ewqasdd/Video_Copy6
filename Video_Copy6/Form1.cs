using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        string str_r_rec_disk = "";
        string str_r_rec_disk_info = "";
        string str_search = "";
        //声明一个委托
        public delegate void SetTextBoxValue(string value);

        //委托使用文本框
        void SetMyTextBoxValue(string value)
        {
            // Control.InvokeRequired 属性： 获取一个值，该值指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中。当前线程不是创建控件的线程时为true,当前线程中访问是False
            if (this.tb_ReceiveMessage.InvokeRequired)
            {
                SetTextBoxValue objSetTextBoxValue = new SetTextBoxValue(SetMyTextBoxValue);

                // IAsyncResult 接口：表示异步操作的状态。不同的异步操作需要不同的类型来描述，自然可以返回任何对象。
                // Control.BeginInvoke 方法 (Delegate)：在创建控件的基础句柄所在线程上异步执行指定委托。
                IAsyncResult result = this.tb_ReceiveMessage.BeginInvoke(objSetTextBoxValue, new object[] { value });
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
                this.tb_ReceiveMessage.Text += value + Environment.NewLine;
                this.tb_ReceiveMessage.SelectionStart = this.tb_ReceiveMessage.TextLength;
                this.tb_ReceiveMessage.ScrollToCaret();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            h_redis = new Helper_Redis();
            h_redis.Use(r_ip, r_port, r_pwd, r_DB);

            h_redis.RedisSubMessageEvent += H_redis_RedisSubMessageEvent;
            h_redis.Use(r_DB).RedisSub(str_r_rec);
        }

        private void H_redis_RedisSubMessageEvent(string str)
        {
            //string msg = System.Text.Encoding.UTF8.GetString(str);
            SetMyTextBoxValue(str);
            Result_Info r = (Result_Info)Helper_Json.Decode(str, typeof(Result_Info));
            SetMyTextBoxValue(r.msg);

            if (r.type > 0)
            {
                if (r.type == 1)
                {
                    if (r.code > 0)
                    {
                        List<Disk_Info> ds = (List<Disk_Info>)Helper_Json.Decode(r.msg, typeof(List<Disk_Info>));
                        SetMyTextBoxValue("成功更新硬盘信息：" + MyVideoBussiness.Update_Disk_Info(ds));
                    }



                    //using (var ctx = new myVideoEntities())
                    //{
                    //    //Querying with LINQ to Entities
                    //    var L2EQuery = ctx.T_DISK_INFO.Where(s => s.LOGICAL_NAME == "C:\\");
                    //    var disks = L2EQuery.FirstOrDefault<T_DISK_INFO>();

                    //    //LINQ Query syntax:
                    //    var L2EQuery2 = from di in ctx.T_DISK_INFO
                    //                    where di.LOGICAL_NAME == "C:\\"
                    //                    select di;

                    //    var disks2 = L2EQuery2.FirstOrDefault<T_DISK_INFO>();


                    //    ////Querying with Object Services and Entity SQL
                    //    //string sqlString = "select * from T_DISK_INFO as di where di.LOGICAL_NAME == 'C:\\'";
                    //    //var objctx = (ctx1 as IObjectContextAdapter).ObjectContext;
                    //    //ObjectQuery<T_DISK_INFO> disk3 = objctx.CreateQuery<T_DISK_INFO>(sqlString);
                    //    //T_DISK_INFO newDisk = disk3.First<T_DISK_INFO>();

                    //    ////Native SQL:
                    //    //var disk4 = ctx.T_DISK_INFO.SqlQuery("select * from T_DISK_INFO as di where di.LOGICAL_NAME == 'C:\\'")
                    //    //    .FirstOrDefault<T_DISK_INFO>();

                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new myVideoEntities())
            {

                //ctx.T_CONFIG.Attach(new T_CONFIG() { ID = 0, KEY = "1", VALUE1 = "1" });
                ctx.T_CONFIG.Add(new T_CONFIG() { ID = 0, KEY = "1", VALUE1 = "1" });
                SetMyTextBoxValue("操作数量：" + ctx.SaveChanges());
            }
        }

        private void b_Sender_Click(object sender, EventArgs e)
        {
            Command_info c = new Command_info();
            c.type = 1;
            c.msg = "";
            c.msg2 = "";
            string str_c = Helper_Json.Encode(c);

            long r_l = h_redis.RedisPub(str_r_rep, str_c);
            SetMyTextBoxValue(str_r_rep + ":" + str_c);
        }

        private void b_SearchFile_Click(object sender, EventArgs e)
        {
            Command_info c = new Command_info();
            c.type = 2;
            c.msg = "D:\\,E:\\";
            c.msg2 = str_search;
            string str_c = Helper_Json.Encode(c);

            long r_l = h_redis.RedisPub(str_r_rep, str_c);
            SetMyTextBoxValue(str_r_rep + ":" + str_c);
        }
    }
}
