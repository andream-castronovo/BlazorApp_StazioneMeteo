using System.ComponentModel.DataAnnotations;

namespace BlazorApp_StazioneMeteo.Repository.Models
{
    public class GrandezzaFisica : DefaultModel
    {

        [Required(ErrorMessage = "idGrandezzaFisica non può essere omesso.")]
        public int idGrandezzaFisica { 
            get => (int)_id; 
            set => _id = value; 
        }



        [StringLength(20)]
        public string Nome { get; set; }

        [StringLength(6)]
        public string Simbolo { get; set; }

        [StringLength(6)]
        public string SimboloUnitaDiMisuraAdottato { get; set; }

        [StringLength(45)]
        public string Note { get; set; }



    }
}
