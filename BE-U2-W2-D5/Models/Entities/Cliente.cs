using System.ComponentModel.DataAnnotations;

namespace BE_U2_W2_D5.Models.Entities
{
    public class Cliente
    {
        [Key]
        public Guid IdCliente { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Phone]
        public string Telefono { get; set; }

        public ICollection<Prenotazione> ? Prenotazioni { get; set; }

    }
}
