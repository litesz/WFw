using System.ComponentModel;
using System;

namespace WFw.Results
{
    /// <summary>
    /// 状态代码
    /// </summary>
    public enum OperationResultType
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("{0}")]
        Success,
        ///// <summary>
        ///// 成功且消息文本有意义
        ///// </summary>
        //[Description("{0}")]
        //Text,

        /// <summary>
        /// 意外状态
        /// </summary>
        [Description("意外状态")]
        Unexpected = 10000,
        /// <summary>
        /// 已存在
        /// </summary>
        [Description("{0}已存在")]
        IsExist,
        /// <summary>
        /// 不存在
        /// </summary>
        [Description("{0}不存在")]
        NotExist,
        /// <summary>
        /// 为空
        /// </summary>
        [Description("{0}为空")]
        IsEmpty,
        /// <summary>
        /// 错误
        /// </summary>
        [Description("{0}")]
        IsErr,

        //权限100+
        /// <summary>
        /// 未登录或已超时
        /// </summary>
        [Description("未登录或已超时")]
        Unauthorized = 11001,
        /// <summary>
        /// 无权执行操作
        /// </summary>
        [Description("无权执行操作{0}")]
        UnauthorizedOperation,

        //参数200+
        /// <summary>
        /// 参数为空
        /// </summary>
        [Description("参数{0}为空")]
        ParamIsEmpty = 12001,
        /// <summary>
        /// 参数错误
        /// </summary>
        [Description("参数{0}错误")]
        ParamIsErr,

        //手机及验证码300+
        /// <summary>
        /// 电话号码或密码错误
        /// </summary>
        [Description("电话号码或密码错误")]
        PhoneOrPasswordErr = 13001,
        /// <summary>
        /// 电话号码{0}不存在
        /// </summary>
        [Description("电话号码{0}不存在")]
        PhoneNotExist,
        /// <summary>
        /// 电话号码{0}已存在
        /// </summary>
        [Description("电话号码{0}已存在")]
        PhoneIsExist,
        /// <summary>
        /// 电话号[0}码错误
        /// </summary>
        [Description("电话号[0}码错误")]
        PhoneIsWrong,
        /// <summary>
        /// 验证码错误或已过期
        /// </summary>
        [Description("验证码错误或已过期")]
        VerificationCodeErr,
        /// <summary>
        /// 验证码已过期
        /// </summary>
        [Description("验证码已过期")]
        VerificationCodeNotExist,
        /// <summary>
        /// 验证码太过频繁
        /// </summary>
        [Description("验证码太过频繁")]
        VerificationCodeTooMuch,

        /// <summary>
        /// 腾讯接口请求错误
        /// </summary>
        [Description("{0}")]
        TencentHttpErr = 40000,

        /// <summary>
        /// 腾讯云skd错误
        /// </summary>
        [Description("{0}")]
        TencentCloudSdkErr = 50000,

        /// <summary>
        /// 腾讯云skdSts错误
        /// </summary>
        [Description("获得临时票据失败")]
        TencentCloudSdkStsErr = 50001,
    }
}
