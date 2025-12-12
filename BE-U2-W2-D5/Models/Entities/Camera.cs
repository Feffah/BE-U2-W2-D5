using System.ComponentModel.DataAnnotations;

namespace BE_U2_W2_D5.Models.Entities
{
    public class Camera
    {
        [Key]
        public Guid IdCamera { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public decimal Prezzo { get; set; }

        public ICollection<Prenotazione> ? Prenotazioni { get; set; }
    }

}
