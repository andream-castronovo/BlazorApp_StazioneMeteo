// Andrea Maria Castronovo
// 5°I
// 29-04-202
// Progetto stazione meteo

using BlazorApp_StazioneMeteo.Components;
using BlazorApp_StazioneMeteo.Pages.ComponentiMeteo.Elettronica;
using BlazorApp_StazioneMeteo.Pages.ComponentiMeteo.Encoders;
using BlazorApp_StazioneMeteo.Pages.ComponentiMeteo.Esterno;
using BlazorApp_StazioneMeteo.Pages.ComponentiMeteo;
using BlazorApp_StazioneMeteo.Pages;
using System.Runtime.InteropServices;

namespace BlazorApp_StazioneMeteo.Classes
{
    public class Correlati
    {
        // Se potessimo fare noi un database, sarebbe stato meglio fare una 
        // tabella con i link utili che si riferisca ad ogni pagina.
        List<Tuple<string, string>> x = new List<Tuple<string, string>>
        {
            new Tuple <string,string> ("Wikipedia","wikipedia.it")
        }; 

        Dictionary<string, string> _link = new Dictionary<string, string>()
        {
            {"/", ""},
            {"/info", ""},
            {"/rilevazioni", ""},
            {"/contatti", ""},
            {"/stazione-meteo", ""},
            {"/stazione-meteo/esterno", ""},
            {"/esterno/anemometro", ""},
            {"/esterno/banderuola", ""},
            {"/esterno/picam", ""},
            {"/esterno/proterigro", ""},
            {"/esterno/pluviometro", ""},
            {"/stazione-meteo/interno", ""},
            {"/interno/antirimbalzo", ""},
            {"/interno/batteria_cont", ""},
            {"/interno/picam", ""},
            {"/interno/raspberry", ""},
            {"/interno/reg_ten_in", ""},
            {"/interno/reg_ten_out", ""},
            {"/interno/ups", ""},
            {"/stazione-meteo/encoders", ""},
            {"/encoders/encoder_assoluto", ""},
            {"/encoders/encoder_incrementale", ""},
        };
    }
}
