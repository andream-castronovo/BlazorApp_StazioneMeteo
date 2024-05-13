using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp_StazioneMeteo.Repository.Models
{
    public class Sensore
    {

        [Required(ErrorMessage = "idNomeStazione non può essere omesso.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "idNomeStazione è obbligatorio e deve essere minore di 10 caratteri")]
        public int idCodiceSensore { get; set; }

        [ForeignKey("GrandezzaFisica")]
        public int idGrandezzaFisica { get; set; }

        public short Camera { get; set; }

        [StringLength(30)]
        public string Nome { get; set; }

        [StringLength(30)]
        public string Tipo { get; set; }

        [StringLength(40)]
        public string Caratteristiche { get; set; }

        [StringLength(50)]
        public string Note { get; set; }


    }
}
