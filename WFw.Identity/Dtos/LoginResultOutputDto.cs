using WFw.Dto;

namespace WFw.Identity.Dtos
{
    public class LoginResultOutputDto : IOutputDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Avatar { get; set; } = "Default";
        public string Name { get; set; }
        public string[] Roles { get; set; }
        public int CompanyId { get; set; }
    }
}
