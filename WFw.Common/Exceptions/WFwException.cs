using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Text;
using WFw.Results;

namespace WFw
{

    /// <summary>
    /// 自定义错误
    /// </summary>
    public class WFwException : Exception
    {
        private string logParam;
        private bool dataChanged = false;
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
        public string LogParam
        {
            get
            {
                if (LogParam == null || dataChanged)
                {

                    if (Data.Count == 0)
                    {
                        logParam = "";
                        dataChanged = false;
                        return logParam;
                    }
                    StringBuilder sb = new StringBuilder();
                    foreach (DictionaryEntry item in Data)
                    {
                        sb.Append($"{item.Key}={item.Value};");
                    }
                    logParam = sb.ToString();
                    dataChanged = false;
                }
                return logParam;
            }
        }

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

            if (eventId.Id > 0)
            {
                EventId = eventId;
                Data.Add("eventId", eventId);
            }

            if (logKeyValues == null || logKeyValues.Length == 0)
            {
                return;
            }
            dataChanged = true;
            if (logKeyValues.Length == 1)
            {
                logParam = $"logParam={logKeyValues[0]};";
                Data.Add("logParam", logKeyValues[0]);
                return;
            }

            int index = 0;
            while (index < logKeyValues.Length)
            {
                if (index + 1 >= logKeyValues.Length)
                {
                    Data.Add(logKeyValues[index], "");
                    return;
                }

                Data.Add(logKeyValues[index], logKeyValues[index + 1]);
                index += 2;
            }
        }


        public void AddData(string key, object value)
        {
            dataChanged = true;
            Data.Add(key, value);
        }

    }
}
