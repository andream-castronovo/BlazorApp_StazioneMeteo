// Andrea Maria Castronovo
// 5°I
// 11-05-2024
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
    static public class Correlati
    {
        // Se potessimo fare noi un database, sarebbe stato meglio fare una 
        // tabella con i link utili che si riferisca ad ogni pagina.
        public static Dictionary<string, string> LinkUtili = new Dictionary<string, string>()
        {
            {"/", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca;Google$https://google.it"},
            {"/info", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/rilevazioni", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/contatti", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/esterno", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/esterno/anemometro", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/esterno/banderuola", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/esterno/picam", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/esterno/proterigro", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/esterno/pluviometro", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/interno", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/interno/antirimbalzo", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/interno/batteria_cont", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/interno/picam", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/interno/raspberry", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/interno/reg_ten_in", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/interno/reg_ten_out", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/interno/ups", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/encoders", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/encoders/encoder_assoluto", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
            {"/stazione-meteo/encoders/encoder_incrementale", "Wikipedia$https://it.wikipedia.org/wiki/Francesco_Petrarca"},
        };
    }
}
