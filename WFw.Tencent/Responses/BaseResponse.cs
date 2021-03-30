using System;

namespace WFw.Tencent.Responses
{
    public abstract class BaseResponse
    {
        /// <summary>
        /// 故障代码
        /// </summary>
        public int Errcode { get; set; }
        /// <summary>
        /// 故障信息
        /// </summary>
        public string ErrMsg { get; set; }
    }
}
