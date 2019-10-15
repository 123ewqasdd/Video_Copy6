using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Copy6.Tools
{
    /// <summary>
    /// 保存日志类
    /// </summary>
    public static class Helper_log
    {
        static string path_log = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\";
        static string msg_format = "{0}_{1}_{2}" + Environment.NewLine;//时间、类型、消息

        static Helper_log()
        {
            if (!Directory.Exists(path_log))
                Directory.CreateDirectory(path_log);
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message"></param>
        public static void Write_log(string message)
        {
            Helper_Txt.AppendAllText(Get_FullPath(string.Empty), string.Format(msg_format, DateTime.Now.ToLocalTime(), "INFO", message));
        }

        /// <summary>
        /// 记录日志2
        /// </summary>
        /// <param name="message"></param>
        public static void Write_log(string filename, string message)
        {
            try
            {
                Helper_Txt.AppendAllText(Get_FullPath(filename), string.Format(msg_format, DateTime.Now.ToLocalTime(), "INFO", message));
            }
            catch (Exception ex)
            {
                Write_Error(ex.Message);
            }
        }

        public static void Write_Error(string message)
        {
            Helper_Txt.AppendAllText(Get_FullPath(string.Empty), string.Format(msg_format, DateTime.Now.ToLocalTime(), "ERROR", message));
        }

        public static void Write_log(string folder, string filename, string message, bool bTimeFormat = true)
        {
            string fullfilename = Path.Combine(folder, filename);
            try
            {
                if (bTimeFormat)
                    Helper_Txt.AppendAllText(fullfilename, string.Format(msg_format, DateTime.Now.ToLocalTime(), "INFO", message));
                else
                    Helper_Txt.AppendAllText(fullfilename, message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Write_Error(ex.Message);
            }
        }

        public static void Write_Error(string folder, string filename, string message)
        {
            string fullfilename = Path.Combine(folder, filename);
            try
            {
                Helper_Txt.AppendAllText(fullfilename, string.Format(msg_format, DateTime.Now.ToLocalTime(), "ERROR", message));
            }
            catch (Exception ex)
            {
                Write_Error(ex.Message);
            }
        }


        /// <summary>
        /// 根据预警信息返回保存文件完整路径
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string Get_FullPath(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                return path_log + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            else
                return path_log + filename + ".txt";
        }
    }
}
