using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Copy6.Classes
{
    /// <summary>
    /// 命令类
    /// </summary>
    public class Command_info
    {
        /// <summary>
        /// 命令类型
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 消息1
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 消息2
        /// </summary>
        public string msg2 { get; set; }
        /// <summary>
        /// 预留
        /// </summary>
        public string tag { get; set; }
    }
}
