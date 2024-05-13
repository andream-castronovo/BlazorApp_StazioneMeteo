using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BlazorApp_StazioneMeteo.Repository.Models
{
    public class Rilevamento
    {

        [Required(ErrorMessage = "idRilevamenti non può essere omesso.")]
        public int idRilevamenti { get; set; }

        public int idSensoriInstallati { get; set; }

        public DateTime DataOra { get; set; }

        [StringLength(15)]
        public string Dato { get; set; }

    }
}
