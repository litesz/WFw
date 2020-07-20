using System.ComponentModel;

namespace WFw.Data
{
    public enum OperationResultType
    {
        //成功0
        [Description("成功")]
        Success,

        [Description("{0}")]
        Text,


        [Description("意外状态")]
        Unexpected = 50,
        [Description("{0}已存在")]
        IsExist,
        [Description("{0}不存在")]
        NotExist,
        [Description("{0}为空")]
        IsEmpty,
        [Description("{0}错误")]
        IsErr,

        //权限100+
        [Description("未登录或已超时")]
        Unauthorized = 101,
        [Description("无权执行操作{0}")]
        UnauthorizedOperation,

        //参数200+
        [Description("参数为空:{0}")]
        ParamIsEmpty = 201,
        [Description("参数错误:{0}")]
        ParamIsErr,

        //手机及验证码300+
        [Description("电话号码或密码错误")]
        PhoneOrPasswordErr = 301,
        [Description("电话号码{0}不存在")]
        PhoneNotExist,
        [Description("电话号码{0}已存在")]
        PhoneIsExist,
        [Description("电话号[0}码错误")]
        PhoneIsWrong,
        [Description("验证码错误或已过期")]
        VerificationCodeErr,
        [Description("验证码已过期")]
        VerificationCodeNotExist,
        [Description("验证码太过频繁")]
        VerificationCodeTooMuch,


    }
}
