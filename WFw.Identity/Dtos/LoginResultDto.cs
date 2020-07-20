using WFw.Dto;

namespace WFw.Identity.Dtos
{

    public class LoginResultDto : IOutputDto, IErrCode
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public string[] Roles { get; set; }
        public string Avatar { get; set; } = "Default";
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public string Phone { get; set; }

        /// <summary>
        /// 处理结果 0正常
        /// </summary>
        public int ErrCode { get; set; }
    }
}
