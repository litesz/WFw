using SqlSugar;
using System;
using WFw.Entity;
using WFw.Extensions.Utils;

namespace WFw.Core.Identity.Entities
{
    [SugarTable("Identity_User")]
    public class User : FullAuditOrganizationEntityBase<int>
    {
        [SugarColumn(Length = 16)]
        public string UserName { get; set; }

        [SugarColumn(Length = 16)]
        public string NickName { get; set; }

        [SugarColumn(Length = 11)]
        public string Phone { get; set; }

        [SugarColumn(Length = 32)]
        public string Password { get; set; }

        [SugarColumn(Length = 255)]
        public string HeadImg { get; set; } = "Default";

        [SugarColumn(Length = 32, ColumnDataType = "char")]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString("N");

        [SugarColumn(Length = 8, ColumnDataType = "char")]
        public string PasswordSalt { get; set; } = new Random().NextLetterAndNumberString(8);

        [SugarColumn(Length = 32, ColumnDataType = "char")]
        public string RefreshToken { get; set; } = new Random().NextLetterAndNumberString(32);

        /// <summary>
        /// 登录过期时间
        /// </summary>
        public DateTime LoginExpire { get; set; } = new DateTime(2000, 1, 1);
        /// <summary>
        /// 最近登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; } = new DateTime(2000, 1, 1);
        /// <summary>
        /// 付费类型
        /// </summary>
        public PaymentType PaymentType { get; set; }
        /// <summary>
        /// 账户过期时间
        /// </summary>
        public DateTime Expire { get; set; } = new DateTime(2100, 1, 1);
        /// <summary>
        /// 账户状态
        /// </summary>
        public UserAuditType AuditState { get; set; }

        public bool IsLock { get; set; }

        public bool IsSystem { get; set; }
    }
}
