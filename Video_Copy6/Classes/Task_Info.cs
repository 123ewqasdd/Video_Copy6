using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Copy6.Classes
{
    class Task_Info
    {
        /// <summary>
        /// 操作id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 拷贝方式，0单个文件，1目录拷贝
        /// </summary>
        public string copy_type { get; set; }
        /// <summary>
        /// 影片完整路径
        /// </summary>
        public string[] arr_source { get; set; }
        /// <summary>
        /// 拷贝目录地址
        /// </summary>
        public string target { get; set; }
        /// <summary>
        /// 原文件所有大小
        /// </summary>
        public double source_size { get; set; }
        /// <summary>
        /// 目标地址大小
        /// </summary>
        public double target_size { get; set; }
        /// <summary>
        /// 目标地址剩余大小
        /// </summary>
        public double target_free_size { get; set; }
        /// <summary>
        /// 复制文件数量
        /// </summary>
        public int count_copy_files { get; set; }
    }
}
