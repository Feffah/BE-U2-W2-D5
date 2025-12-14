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
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Sesso { get; set; }

        public string Ruolo { get; set; }
        public DateTime DataDiNascita { get; set; }
    }
}
