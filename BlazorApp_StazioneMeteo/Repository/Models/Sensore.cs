using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp_StazioneMeteo.Repository.Models
{
    public class Sensore : DefaultModel
    {

        [Required(ErrorMessage = "idNomeStazione non può essere omesso.")]
        public int idCodiceSensore { get => (int)_id; set => _id = value; }

        [ForeignKey("GrandezzaFisica")]
        public int idGrandezzaFisica { get; set; }

        public byte Camera { get; set; }

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
