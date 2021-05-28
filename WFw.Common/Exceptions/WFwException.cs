using System;
using System.Collections.Generic;
using System.Text;
using WFw.Results;

namespace WFw
{

    /// <summary>
    /// 自定义错误
    /// </summary>
    public class WFwException : Exception
    {
        /// <summary>
        /// 错误类型
        /// </summary>
        public OperationResultType OperationResult { get; }
        /// <summary>
        /// 显示描述
        /// </summary>
        public string ParamName { get; }

        /// <summary>
        /// 日志记录参数
        /// </summary>
        public string LogParam { get; set; }

        /// <summary>
        /// 自定义错误
        /// </summary>
        public WFwException() { }

        /// <summary>
        /// 自定义错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwException(string param, string logParam = "") : this(OperationResultType.IsErr, param, logParam) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="logKeyValues"></param>
        public WFwException(string param, params string[] logKeyValues) : this(OperationResultType.IsErr, param, logKeyValues) { }


        /// <summary>
        /// 自定义错误
        /// </summary>
        /// <param name="result">状态</param>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwException(OperationResultType result, string param, string logParam = "") : base(string.Format(result.GetEnumDescription(), param))
        {
            OperationResult = result;
            ParamName = param;
            LogParam = $"logParam={logParam};";
        }

        /// <summary>
        /// 自定义错误
        /// </summary>
        /// <param name="result">状态</param>
        /// <param name="param">返回值参数</param>
        /// <param name="logKeyValues">k-v键值对</param>
        public WFwException(OperationResultType result, string param, params string[] logKeyValues) : base(string.Format(result.GetEnumDescription(), param))
        {
            OperationResult = result;
            ParamName = param;

            if (logKeyValues == null || logKeyValues.Length == 0)
            {
                return;
            }

            if (logKeyValues.Length == 1)
            {
                LogParam = $"logParam={logKeyValues[0]};";
                return;
            }

            StringBuilder sb = new StringBuilder();
            bool isKey = true;
            foreach (var item in logKeyValues)
            {
                sb.Append(item);

                if (isKey)
                {
                    sb.Append('=');
                }
                else
                {
                    sb.Append(';');
                }
                isKey = !isKey;
            }
            if (sb.Length > 0 && sb[sb.Length - 1] == '=')
            {
                sb.Replace('=', ';', sb.Length - 1, 1);
            }

            LogParam = sb.ToString();
        }

    }
}
