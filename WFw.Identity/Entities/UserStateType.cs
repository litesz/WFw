using System.ComponentModel.DataAnnotations;

namespace WFw.Core.Identity.Entities
{
    public enum UserAuditType
    {
        [Display(Name = "审核成功")]
        Success,
        [Display(Name = "审核中")]
        InReview,
        [Display(Name = "审核失败")]
        Failure,
       
    }
}
