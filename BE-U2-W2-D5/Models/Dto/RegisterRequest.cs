using System.ComponentModel.DataAnnotations;

namespace BE_U2_W2_D5.Models.Dto
{
    public class RegisterRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
