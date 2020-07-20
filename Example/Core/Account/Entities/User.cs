using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFw.Entity;
using WFw.Utils;

namespace Example.Core.Account.Entities
{
    [SqlSugar.SugarTable("Account_User")]
    public class User : FullAuditWithRemarkEntityBase<int>
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Pwd { get; set; }
        public string PwdSalt { get; set; } = new Random().NextLetterAndNumberString(8);
        public string Role { get; set; } = "Admin";
    }
}
