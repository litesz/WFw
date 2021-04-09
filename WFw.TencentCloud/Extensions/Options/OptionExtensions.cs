using System;
using System.Collections.Generic;
using System.Text;
using TencentCloud.Common;
using WFw.TencentCloud.Options.Abstractions;

namespace WFw.TencentCloud.Options
{
    public static class OptionExtensions
    {
        public static void TrySetSecre(this ITencentSecret target, ITencentSecret source)
        {
            if (string.IsNullOrWhiteSpace(target.SecretId))
            {
                target.SecretId = source.SecretId;
            }

            if (string.IsNullOrWhiteSpace(target.SecretKey))
            {
                target.SecretKey = source.SecretKey;
            }

        }

        public static Credential GetCredential(this ITencentSecret secret) => new Credential { SecretId = secret.SecretId, SecretKey = secret.SecretKey };
    }
}
