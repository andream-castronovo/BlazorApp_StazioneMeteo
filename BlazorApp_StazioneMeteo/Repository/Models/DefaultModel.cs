// Andrea Maria Castronovo
// 5°I
// 22-05-2024
// Progetto stazione meteo

using System.Numerics;

namespace BlazorApp_StazioneMeteo.Repository.Models
{
    public abstract class DefaultModel
    {
        public object _id;

        public static bool operator ==(DefaultModel left, DefaultModel right)
        {
           return left._id == right._id;
        }
        public static bool operator !=(DefaultModel left, DefaultModel right)
        {
            return left._id == right._id;
        }

    }
}
