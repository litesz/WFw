using System;
using System.Collections.Generic;
using System.Text;

namespace WFw.Utils.Dtos
{
    /// <summary>
    /// 验证码
    /// </summary>
    public interface IVerifyCode
    {
        /// <summary>
        /// 手机号
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        string VerifyCode { get; set; }
    }
}
