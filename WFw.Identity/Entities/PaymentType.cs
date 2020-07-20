using System.ComponentModel.DataAnnotations;

namespace WFw.Core.Identity.Entities
{
    public enum PaymentType
    {
        [Display(Name = "试用")]
        onTrial,
        [Display(Name = "免费")]
        Free,
        [Display(Name = "付费")]
        Pay
    }
}
