// Andrea Maria Castronovo
// 5°I
// 22-05-2024
// Progetto stazione meteo

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace BlazorApp_StazioneMeteo.Repository.Models
{
    public class SensoreInstallato : DefaultModel
    {

        [Key]
        [Required(ErrorMessage = "idSensoriInstallati non può essere omesso.")]
        public int idSensoriInstallati { get => (int)_id; set => _id = value; }
        
        [Key]
        [ForeignKey(nameof(Sensore))]
        public int? idCodiceSensore { get; set; }
        
        [Key]
        [ForeignKey(nameof(StazioneModel))]
        public string idNomeStazione { get; set; }

        public string Note { get; set; }

    }
}
