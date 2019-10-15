using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace Video_Copy6.Tools
{
    class Helper_Json
    {
        public static string DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";
        public static string Encode(object o)
        {
            if (o == null || o.ToString() == "null")
                return null;
            if (o != null && (o.GetType() == typeof(String) || o.GetType() == typeof(string)))
            {
                return o.ToString();
            }


            //不随机排序的Hashtable
            if (o.GetType() == typeof(NoSortHashtable))
            {
                NoSortHashtable ht = (NoSortHashtable)o;
                string json = "{";
                foreach (string key in ht.Keys)
                {
                    object value = ht[key];
                    if (value.GetType() == typeof(String) || value.GetType() == typeof(string))
                        json += "\"" + key + "\":\"" + value.ToString() + "\","; //字符串
                    else
                        json += "\"" + key + "\":" + value.ToString().ToLower() + ","; //非字符串，如整型或布尔型
                }
                json = json.Substring(0, json.Length - 1); //去掉最后一个逗号
                json += "}";
                return json;
            }


            IsoDateTimeConverter dt = new IsoDateTimeConverter();
            dt.DateTimeFormat = DateTimeFormat;
            return JsonConvert.SerializeObject(o, dt);
        }

        public static object Decode(string json)
        {
            if (String.IsNullOrEmpty(json)) return "";
            object o = JsonConvert.DeserializeObject(json);
            if (o.GetType() == typeof(String) || o.GetType() == typeof(string))
            {
                o = JsonConvert.DeserializeObject(o.ToString());
            }
            object v = toObject(o);
            return v;
        }
        public static object Decode(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }
        private static object toObject(object o)
        {
            if (o == null) return null;

            if (o.GetType() == typeof(string))
            {
                //判断是否符合2010-09-02T10:00:00的格式
                string s = o.ToString();
                if (s.Length == 19 && s[10] == 'T' && s[4] == '-' && s[13] == ':')
                {
                    o = System.Convert.ToDateTime(o);
                }
            }
            else if (o is JObject)
            {
                JObject jo = o as JObject;
                Hashtable h = new Hashtable();
                foreach (KeyValuePair<string, JToken> entry in jo)
                {
                    h[entry.Key] = toObject(entry.Value);
                }
                o = h;
            }
            else if (o is IList)
            {
                ArrayList list = new ArrayList();
                list.AddRange((o as IList));
                int i = 0, l = list.Count;
                for (; i < l; i++)
                {
                    list[i] = toObject(list[i]);
                }
                o = list;
            }
            else if (typeof(JValue) == o.GetType())
            {
                JValue v = (JValue)o;
                o = toObject(v.Value);
            }
            else
            {

            }
            return o;
        }


    }


    /*
     * 
     * 表示层的辅助类
     * 
     * 功能：实现Hashtable不随机进行排序
     * 作者：
     * 
     */
    public class NoSortHashtable : Hashtable
    {
        private ArrayList keys = new ArrayList(); //借助ArrayList来指定顺序，从而避免使用Hashtable原有的随机顺序

        //构造函数
        public NoSortHashtable()
        {

        }

        //添加元素
        public override void Add(object key, object value)
        {
            base.Add(key, value);
            keys.Add(key);
        }

        //泛型的key集合
        public override ICollection Keys
        {
            get
            {
                return keys;
            }
        }

        //清除所有元素
        public override void Clear()
        {
            base.Clear();
            keys.Clear();
        }

        //删除一个元素
        public override void Remove(object key)
        {
            base.Remove(key);
            keys.Remove(key);
        }

        public override IDictionaryEnumerator GetEnumerator()
        {
            return base.GetEnumerator();
        }
    }
}
