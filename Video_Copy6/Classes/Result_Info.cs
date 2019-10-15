using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Copy6.Classes
{
    /// <summary>
    /// 服务器返回信息
    /// </summary>
    class Result_Info
    {
        /// <summary>
        /// 成功失败
        /// </summary>
        public bool flag { get; set; }
        /// <summary>
        /// 命令类型
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 执行结果代码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 执行结果数据
        /// </summary>
        public string msg { get; set; }
    }
}
