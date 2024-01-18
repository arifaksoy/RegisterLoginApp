using System.ComponentModel.DataAnnotations;

namespace RegisterLoginApp.Server.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

    }
}
