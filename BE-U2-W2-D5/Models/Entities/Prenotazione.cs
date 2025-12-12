using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_U2_W2_D5.Models.Entities
{
    public class Prenotazione
    {
        [Key]
        public Guid IdPrenotazione { get; set; }
        [Required]
        public DateTime DataInizio { get; set; }
        [Required]
        public DateTime DataFine { get; set; }
        [Required]
        public string Stato { get; set; }


        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }

        [ForeignKey(nameof(CameraId))]
        public Camera Camera { get; set; }
        public Guid CameraId { get; set; }

    }
}
