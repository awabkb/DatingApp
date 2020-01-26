using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }    
        [Required]
        [StringLength(10,MinimumLength=5,ErrorMessage="min 5 max 10")]
        public string  Password { get; set; }
    }
}