// Andrea Maria Castronovo
// 5°I
// 11-05-2024
// Progetto stazione meteo
using BlazorApp_StazioneMeteo.Repository.Models;
using System.Security.Principal;

namespace BlazorApp_StazioneMeteo.Repository.Entities
{
    public abstract class InterazioneDB<T> where T : DefaultModel
    {
        protected readonly string _conn;
        public InterazioneDB(string conn)
        {
            _conn = conn;
        }

        public abstract List<T> OttieniElementi();

        public abstract T OttieniElemento(object id);

        public abstract void CreaElemento(T elemento);

        public abstract void EliminaElemento(object id);

        public abstract void ModificaElemento(T elemento);


        public static M ControllaPrimaryKey<M>(object id)
        {
            if (id.GetType() != typeof(M))
            {
                throw new ArgumentException("L'ID passato non è del tipo corretto.");
            }
            return (M)id;
        }
    }
}
