using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WFw.Entity;
using WFw.Utils;

namespace Example.Core.Account.Entities
{
    [SqlSugar.SugarTable("Account_User")]
    public class User : FullAuditWithRemarkByUserEntityBase<int>
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Pwd { get; set; }
        public string PwdSalt { get; set; } = new Random().NextLetterAndNumberString(8);
        public string Role { get; set; } = "Admin";

        [SqlSugar.SugarColumn(IsIgnore = true)]
        public List<UserAddress> Address { get; set; }
        public User() { }
        public User(string userName, string nickName, string pwd)
        {
            UserName = userName;
            NickName = nickName;
            Pwd = EncryptProvider.GetMd5($"{ pwd}{PwdSalt}");
        }

    }

    [SqlSugar.SugarTable("Account_User_Address")]
    public class UserAddress : IncrFullAuditByUserEntityBase<int>
    {
      
        public string Address { get; set; }
        public int UserId { get; set; }

      
        public decimal Rating { get; set; }
    }


}
