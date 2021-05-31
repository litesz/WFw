using Microsoft.Extensions.Logging;
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
        public OperationResultType OperationResult { get; protected set; } = OperationResultType.IsErr;
        /// <summary>
        /// 显示描述
        /// </summary>
        public string ParamName { get; protected set; }

        /// <summary>
        /// 日志记录参数
        /// </summary>
        public string LogParam { get; protected set; }

        /// <summary>
        /// 事件id
        /// </summary>
        public EventId EventId { get; protected set; }

        /// <summary>
        /// 自定义错误
        /// </summary>
        public WFwException() { }

        /// <summary>
        /// 自定义错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwException(string param, string logParam = "") : this(OperationResultType.IsErr, 0, param, logParam) { }

        /// <summary>
        /// 自定义错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwException(string param, EventId eventId, string logParam = "") : this(OperationResultType.IsErr, eventId, param, logParam) { }

        /// <summary>
        /// 自定义错误
        /// </summary>
        /// <param name="eventId">事件id</param>
        /// <param name="param">返回值参数</param>
        /// <param name="logKeyValues">k-v键值对</param>
        public WFwException(string param, params string[] logKeyValues) : this(OperationResultType.IsErr, 0, param, logKeyValues) { }

        /// <summary>
        /// 自定义错误
        /// </summary>
        /// <param name="eventId">事件id</param>
        /// <param name="param">返回值参数</param>
        /// <param name="logKeyValues">k-v键值对</param>
        public WFwException(string param, EventId eventId, params string[] logKeyValues) : this(OperationResultType.IsErr, eventId, param, logKeyValues) { }


        /// <summary>
        /// 自定义错误
        /// </summary>
        /// <param name="result">状态</param>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwException(OperationResultType result, string param, string logParam = "") : this(result, 0, param, logParam)
        {

        }

        /// <summary>
        /// 自定义错误
        /// </summary>
        /// <param name="result">状态</param>
        /// <param name="param">返回值参数</param>
        /// <param name="logKeyValues">k-v键值对</param>
        public WFwException(OperationResultType result, string param, params string[] logKeyValues) : this(result, 0, param, logKeyValues)
        {
        }


        /// <summary>
        /// 自定义错误
        /// </summary>
        /// <param name="result">状态</param>
        /// <param name="eventId">事件id</param>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwException(OperationResultType result, EventId eventId, string param, string logParam = "") : this(result, eventId, param, "logParam", logParam)
        {
        }

        /// <summary>
        /// 自定义错误
        /// </summary>
        /// <param name="result">状态</param>
        /// <param name="eventId">事件id</param>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">k-v键值对</param>
        public WFwException(OperationResultType result, EventId eventId, string param, params string[] logKeyValues) : base(string.Format(result.GetEnumDescription(), param))
        {
            OperationResult = result;
            ParamName = param;
            EventId = eventId;
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
