using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp_StazioneMeteo.Repository.Models
{
    public class SensoreInstallato
    {

        [Required(ErrorMessage = "idSensoriInstallati non può essere omesso.")]
        public int idSensoriInstallati { get; set; }

        [ForeignKey(nameof(Sensore))]
        public int idCodiceSensore { get; set; }

        [ForeignKey(nameof(Stazione))]
        public string idNomeStazione { get; set; }

        public string Note { get; set; }

    }
}
