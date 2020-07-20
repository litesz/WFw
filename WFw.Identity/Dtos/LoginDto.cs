using System.ComponentModel.DataAnnotations;
using WFw.Dto;

namespace WFw.Identity.Dtos
{
    public class LoginDto : IInputDto
    {
        [Display(Name = "手机号码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "输入11位手机号码")]
        public string Username { get; set; }

        [Display(Name = "登录密码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "输入5-20位{0}")]
        public string Password { get; set; }
    }
}
