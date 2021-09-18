using WFw.Utils;

namespace WFw.SmsChinese.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class SmsChineseOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public const string Position = "SmsChinese";
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Uid { get; set; }

        public string VerificationCodeTemplate { get; set; } = "验证码为：${code}，有效期${expireMin}分钟，若非本人操作，请忽略。";



        public string GetSendMsgUrl(string smsMob, string smsText)
        {
            ParamCheck.NotNull(Key, "平台私钥");
            ParamCheck.NotNull(Uid, "平台ID");
            return $"http://utf8.api.smschinese.cn/?Uid={Uid}&Key={Key}&smsMob={smsMob}&smsText={smsText}";
        }

        public string GetMessageRemainingUrl()
        {
            ParamCheck.NotNull(Key, "平台私钥");
            ParamCheck.NotNull(Uid, "平台ID");
            return $"http://www.smschinese.cn/web_api/SMS/?Action=SMS_Num&Uid={Uid}&Key={Key}";
        }
    }
}
