using WFw.Core.Identity.Entities;

namespace WFw.Identity.Dtos
{
    public class UserQueryOutputDto
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string HeadImg { get; set; }
        public PaymentType PaymentType { get; set; }
        public UserAuditType AuditState { get; set; }
        public string Remark { get; set; }
        public bool IsLock { get; set; }
    }
}
