using WFw.Data;
using WFw.Dto;

namespace WFw.Identity.Dtos
{
    public class UserInputDto : IInputDto, IVerifyCode
    {
        public string Phone { get; set; }
        public string VerifyCode { get; set; }
        public string Password { get; set; }
    }
}
