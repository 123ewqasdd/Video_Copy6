using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Video_Copy6.Controls
{
    class OrderControler
    {
        List<T_CONFIG> re_arr = new List<T_CONFIG>();
        Regex reg;

        public OrderControler()
        {
            re_arr = MyVideoBussiness.GetList_Config("Moive_Name_Replace");
        }

        public int Get_My_Videos(TreeView tv, string[] contents)
        {
            tv.Nodes.Clear();
            TreeNode tn;
            int i_count = 0;
            foreach(var content in contents)
            {
                tn = new TreeNode(content);
                string c_replaced = replace_string(content);
                List<T_Video> vs = MyVideoBussiness.GetList_Video_Info_Like(c_replaced);
                foreach (var v in vs)
                {
                    TreeNode tn_sub = new TreeNode(v.FILE_NAME);
                    tn_sub.Tag = v;
                    tn.Nodes.Add(tn_sub);
                    i_count++;
                }
                tv.Nodes.Add(tn);
            }
            tv.Nodes.Add("[查询]");
            return i_count;
        }

        /// <summary>
        /// 根据数据库预设正则，匹配掉目标字符中的内容
        /// T_CONFIG表中KEY字段为Moive_Name_Replace
        /// 正则存储VALUE1、VALUE3，替换VALUE2、VALUE4
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string replace_string(string str)
        {
            foreach (var re_par in re_arr)
            {
                string str_replace = "";
                if (!string.IsNullOrEmpty(re_par.VALUE1))
                {
                    reg = new Regex(re_par.VALUE1);
                    if (reg.IsMatch(str))
                    {
                        str_replace = (re_par.VALUE2 == null ? "" : re_par.VALUE2);
                        return reg.Replace(str, str_replace);
                    }
                   
                }
                if (!string.IsNullOrEmpty(re_par.VALUE3))
                {
                    reg = new Regex(re_par.VALUE3);
                    if (reg.IsMatch(str))
                    {
                        str_replace = (re_par.VALUE4 == null ? "" : re_par.VALUE4);
                        return reg.Replace(str, str_replace);
                    }
                }
            }
            return str;
        }

        
    }
}
