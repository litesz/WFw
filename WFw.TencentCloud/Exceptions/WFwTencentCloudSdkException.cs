using System;
using System.Collections.Generic;
using System.Text;
using WFw.Results;

namespace WFw.TencentCloud.Exceptions
{
    /// <summary>
    /// 腾讯云SDK错误
    /// </summary>
    public class WFwTencentCloudSdkException : WFwException
    {
        /// <summary>
        /// 腾讯云SDK错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwTencentCloudSdkException(string param) : base(OperationResultType.TencentCloudSdkErr, param)
        {

        }

        /// <summary>
        /// 腾讯云SDK错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logKeyValues">k-v键值对</param>
        public WFwTencentCloudSdkException(string param, params string[] logKeyValues) : base(OperationResultType.TencentCloudSdkErr, param, logKeyValues)
        {

        }
    }


    /// <summary>
    /// 腾讯云StsSDK错误
    /// </summary>
    public class WFwTencentCloudSdkStsException : WFwException
    {
        /// <summary>
        /// 不存在错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logParam">日志消息参数</param>
        public WFwTencentCloudSdkStsException(string param, string logParam = "") : base(OperationResultType.TencentCloudSdkStsErr, param, logParam)
        {

        }

        /// <summary>
        /// 不存在错误
        /// </summary>
        /// <param name="param">返回值参数</param>
        /// <param name="logKeyValues">k-v键值对</param>
        public WFwTencentCloudSdkStsException(string param, params string[] logKeyValues) : base(OperationResultType.TencentCloudSdkStsErr, param, logKeyValues)
        {

        }
    }
}
