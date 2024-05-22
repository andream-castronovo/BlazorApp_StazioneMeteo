// Andrea Maria Castronovo
// 5°I
// 22-05-2024
// Progetto stazione meteo
using System.ComponentModel.DataAnnotations;

namespace BlazorApp_StazioneMeteo.Repository.Models
{
    public class StazioneModel : DefaultModel
    {
        [Key]
        [Required(ErrorMessage = "idNomeStazione non può essere omesso.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "idNomeStazione è obbligatorio e deve essere minore di 10 caratteri")]
        public string idNomeStazione { get => (string)_id; set => _id = value; }
        public string IP_Statico { get; set; }
        public string Localita_Indirizzo { get; set; }
        public decimal? Latitudine { get; set; }
        public decimal? Longitudine { get; set; }
        public int? Altitudine { get; set; }
        public string Descrizione { get; set; }
        public string Note { get; set; }


    }
}
