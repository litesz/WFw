using System.ComponentModel.DataAnnotations;

namespace Example.Core.Account.Dtos
{
    public class SignInInputDto
    {
        [Required]
        public string UserName { get; set; } = "admin";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "123456";
    }

    public class SignInOutputDto
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Role { get; set; }
    }
}
