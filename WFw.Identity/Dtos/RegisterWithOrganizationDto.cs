using System;
using System.ComponentModel.DataAnnotations;
using WFw.Core.Identity.Entities;
using WFw.Data;
using WFw.Dto;

namespace WFw.Identity.Dtos
{
    /// <summary>
    /// 用户注册信息DTO
    /// </summary>
    public class RegisterWithOrganizationDto : IInputDto, IVerifyCode
    {
        [Display(Name = "手机号码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "输入11位手机号码")]
        public string Phone { get; set; }

        [Display(Name = "验证码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(6)]
        public string VerifyCode { get; set; }


        [Display(Name = "名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "输入2-10位{0}")]
        public string NickName { get; set; }
        public UserAuditType AuditType { get; set; }

        /// <summary>
        /// 获取或设置 密码
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "输入5-20位{0}")]

        public string Password { get; set; }

        /// <summary>
        /// 获取或设置 确认密码
        /// </summary>
        [Compare("Password", ErrorMessage = "密码与确认密码不匹配")]
        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "输入5-20位{0}")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "公司名")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "输入2-32位{0}")]
        public string OrganizationName { get; set; }


        [Display(Name = "省")]
        public int Province { get; set; }

        [Display(Name = "市")]
        public int City { get; set; }

        [Display(Name = "区")]
        public int District { get; set; }

        [Display(Name = "地址")]
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(32, MinimumLength = 5, ErrorMessage = "输入5-32位{0}")]
        public string Address { get; set; }
    }
}
