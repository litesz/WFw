using WFw.Dto;

namespace WFw.Identity.Dtos
{
    public class UserOutputDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
    }
}
