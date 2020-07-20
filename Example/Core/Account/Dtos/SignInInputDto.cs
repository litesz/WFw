using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Models
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
