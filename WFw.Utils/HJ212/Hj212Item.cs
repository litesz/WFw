using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WFw.Utils.Signatures;

namespace WFw.Utils.Hj212
{
    /// <summary>
    /// HJ212项
    /// </summary>
    public class Hj212Item
    {
        const string head = "##";
        const string end = "\r\n";

        /// <summary>
        /// 值
        /// </summary>
        private readonly Dictionary<string, string> values = new Dictionary<string, string>();
        /// <summary>
        /// 变化标识
        /// </summary>
        private bool isChanged = false;

        /// <summary>
        /// 设备唯一标识符
        /// </summary>
        public string Mn { get; private set; } = "00000000000000";
        /// <summary>
        /// 命令编码
        /// </summary>
        public int Cn { get; private set; } = 2011;
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime DateTime { get; private set; }
        /// <summary>
        /// 访问密码
        /// </summary>
        public string Pw { get; private set; }
        /// <summary>
        /// 系统编码
        /// </summary>
        public string St { get; private set; } = "A0";
        /// <summary>
        /// 数据段长度
        /// </summary>
        public int Length { get; private set; }
        /// <summary>
        /// CRC校验
        /// </summary>
        public string Crc { get; private set; }
        /// <summary>
        /// 精确到毫秒的时间戳
        /// </summary>
        public string Qn { get; private set; }
        /// <summary>
        /// 拆分包及应答标志
        /// </summary>
        public byte Flag { get; private set; }
        /// <summary>
        /// 总报数
        /// </summary>
        public int Pnum { get; private set; }
        /// <summary>
        /// 包号
        /// </summary>
        public int Pno { get; private set; }
        /// <summary>
        /// 指令参数
        /// </summary>
        public string Cp { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mn"></param>
        /// <param name="cn"></param>
        public Hj212Item(string mn, int cn)
        {
            Mn = mn;
            Cn = cn;
            DateTime = DateTime.Now;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                key = key.Trim();
                if (values.ContainsKey(key))
                {
                    return values[key];
                }
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"ST={St};CN={Cn};MN={Mn};CP=&&DataTime={DateTime:yyyyMMddHHmmss};");
            string l = "";
            foreach (var key in values.Keys.OrderBy(u => u))
            {
                string[] a = key.Split('-');
                sb.Append($"{key}={values[key]}{(a[0] == l ? "," : ";")}");
                l = a[0];
            }
            sb.Append("&&");
            string body = sb.ToString();
            byte[] content = System.Text.Encoding.UTF8.GetBytes(body);
            if (string.IsNullOrWhiteSpace(Crc) || isChanged)
            {
                Crc = Convert.ToString(CrcCalculator.CalculateCrc16(content), 16);
            }
            return $"{head}{content:d4}{body}{ Crc}{end}";
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void Add<T>(string code, string type, T value)
        {
            Add<T>($"{code.Trim()}-{type.Trim()}", value);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add<T>(string key, T value)
        {
            isChanged = true;
            if (values.ContainsKey(key))
            {
                values[key] = value.ToString();
            }
            else
            {
                values.Add(key, value.ToString());
            }
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="code"></param>
        /// <param name="type"></param>
        public void Remove(string code, string type)
        {
            Remove($"{code.Trim()}-{type.Trim()}");

        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            if (values.ContainsKey(key))
            {
                isChanged = true;
                values.Remove(key);
            }
        }
    }
}
