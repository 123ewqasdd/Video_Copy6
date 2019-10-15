using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Copy6.Classes
{
    /// <summary>
    /// 文件基本信息类
    /// </summary>
    class File_Info
    {
        public string fileIndex { get; set; }
        public string fileRoot { get; set; }
        public string fileName { get; set; }
        public string fileFullPath { get; set; }
        public string fileExtension { get; set; }
        public string fileSize { get; set; }
    }
}
