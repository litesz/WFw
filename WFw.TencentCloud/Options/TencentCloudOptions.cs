using TencentCloud.Common;
using WFw.TencentCloud.Options.Abstractions;

namespace WFw.TencentCloud.Options
{


    /// <summary>
    /// 腾讯云SDK设置
    /// </summary>
    public class TencentCloudOptions : ITencentSecret
    {

        private OcrOptions ocr;
        private CosOptions cos;
        private SmsOptions sms;
        private StsOptions sts;


        /// <summary>
        /// 
        /// </summary>
        public const string Position = "TencentCloud";

        /// <summary>
        /// SecretId
        /// </summary>
        public string SecretId { get; set; }

        /// <summary>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// cos设置
        /// </summary>
        public CosOptions Cos
        {
            get
            {
                if (cos == null)
                {
                    cos = new CosOptions();
                }

                cos.TrySetSecre(this);

                return cos;
            }
            set => cos = value;
        }

        /// <summary>
        /// 短信设置
        /// </summary>
        public SmsOptions Sms
        {
            get
            {
                if (sms == null)
                {
                    sms = new SmsOptions();
                }

                sms.TrySetSecre(this);

                return sms;
            }
            set => sms = value;
        }

        /// <summary>
        /// ocr
        /// </summary>
        public OcrOptions Ocr
        {
            get
            {
                if (ocr == null)
                {
                    ocr = new OcrOptions();
                }

                ocr.TrySetSecre(this);

                return ocr;
            }
            set => ocr = value;
        }


        public StsOptions Sts
        {
            get
            {
                if (sts == null)
                {
                    sts = new StsOptions();
                }

                sts.TrySetSecre(this);

                return sts;
            }
            set => sts = value;
        }

    }

}
