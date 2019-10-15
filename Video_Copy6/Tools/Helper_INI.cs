using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Specialized;

namespace Video_Copy6.Tools
{

    public class Helper_INI
    {
        #region private property
        //声明读写INI文件的API函数 
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);

        #endregion private

        #region public  property
        public string FileName; //INI文件名 

        #endregion public

        #region public method
        public Helper_INI(string pFileName)
        {
            // 判断文件是否存在 
            FileInfo fileInfo = new FileInfo(pFileName);

            if ((!fileInfo.Exists))
            {
                //文件不存在，建立文件 
                System.IO.StreamWriter sw = new System.IO.StreamWriter(pFileName, false, System.Text.Encoding.Default);
                try
                {
                    sw.Close();
                }
                catch
                {
                    throw (new ApplicationException("Ini文件不存在"));
                }
            }

            FileName = fileInfo.FullName;
        }


        //写INI文件 
        public void WriteString(string Section, string Ident, string Value)
        {
            if (!WritePrivateProfileString(Section, Ident, Value, FileName))
            {
                throw (new ApplicationException("写Ini文件出错"));
            }
        }
        //读取INI文件指定 
        public string ReadString(string Section, string Ident, string Default)
        {
            Byte[] Buffer = new Byte[65535];
            int bufLen = GetPrivateProfileString(Section, Ident, Default, Buffer, Buffer.GetUpperBound(0), FileName);
            //必须设定0（系统默认的代码页）的编码方式，否则无法支持中文 
            string s = Encoding.GetEncoding(0).GetString(Buffer);
            s = s.Substring(0, bufLen);
            return s.Trim().TrimEnd('\0');
        }

        //读整数 
        public int ReadInteger(string Section, string Ident, int Default)
        {
            string intStr = ReadString(Section, Ident, Convert.ToString(Default));
            try
            {
                return Convert.ToInt32(intStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        //读整数 
        public DateTime ReadDateTime(string Section, string Ident, DateTime Default)
        {
            string dtStr = ReadString(Section, Ident, "");
            try
            {
                return Convert.ToDateTime(dtStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        //写整数 
        public void WriteDateTime(string Section, string Ident, DateTime Value)
        {
            WriteString(Section, Ident, Value.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        //写整数 
        public void WriteInteger(string Section, string Ident, int Value)
        {
            WriteString(Section, Ident, Value.ToString());
        }

        //读布尔 
        public bool ReadBool(string Section, string Ident, bool Default)
        {
            try
            {
                return Convert.ToBoolean(ReadString(Section, Ident, Convert.ToString(Default)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        //写Bool 
        public void WriteBool(string Section, string Ident, bool Value)
        {
            WriteString(Section, Ident, Convert.ToString(Value));
        }

        //删除某个Section下的键 
        public void DeleteKey(string Section, string Ident)
        {
            WritePrivateProfileString(Section, Ident, null, FileName);
        }

        //检查某个Section下的某个键值是否存在 
        public bool ValueExists(string Section, string Ident)
        {
            // 
            StringCollection Idents = new StringCollection();
            ReadSection(Section, Idents);
            return Idents.IndexOf(Ident) > -1;
        }

        //从Ini文件中，将指定的Section名称中的所有Ident添加到列表中 
        public void ReadSection(string Section, StringCollection Idents)
        {
            Byte[] Buffer = new Byte[16384];
            //Idents.Clear(); 

            int bufLen = GetPrivateProfileString(Section, null, null, Buffer, Buffer.GetUpperBound(0),
              FileName);
            //对Section进行解析 
            GetStringsFromBuffer(Buffer, bufLen, Idents);
        }
        public void UpdateFile()
        {
            WritePrivateProfileString(null, null, null, FileName);
        }

        #endregion public method

        #region private method

        private void GetStringsFromBuffer(Byte[] Buffer, int bufLen, StringCollection Strings)
        {
            Strings.Clear();
            if (bufLen != 0)
            {
                int start = 0;
                for (int i = 0; i < bufLen; i++)
                {
                    if ((Buffer[i] == 0) && ((i - start) > 0))
                    {
                        String s = Encoding.GetEncoding(0).GetString(Buffer, start, i - start);
                        Strings.Add(s);
                        start = i + 1;
                    }
                }
            }
        }
        #endregion private method

        //确保资源的释放 
        ~Helper_INI()
        {
            UpdateFile();
        }

    }
}

