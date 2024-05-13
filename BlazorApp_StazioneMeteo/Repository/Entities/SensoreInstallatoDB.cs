using System.Data.SqlClient;
using BlazorApp_StazioneMeteo.Repository.Models;

namespace BlazorApp_StazioneMeteo.Repository.Entities
{
    public class SensoriInstallatiDB
    {
        private readonly string _conn;
        public SensoriInstallatiDB(string conn)
        {
            _conn = conn;
        }

        public SensoreInstallato OttieneSensoriInstallati(int id)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM SensoriInstallati WHERE idSensoriInstallati = @id",
                    conn);

                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new SensoreInstallato
                    {
                        idSensoriInstallati = (int)reader["idSensoriInstallati"],
                        idCodiceSensore = (int)reader["idCodiceSensore"],
                        idNomeStazione = (string)reader["idNomeStazione"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    };
                }
                return null;
            }
        }

        public List<SensoreInstallato> OttieneSensoriInstallati()
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM SensoriInstallati", conn);
                var reader = cmd.ExecuteReader();
                var sensoriInstallati = new List<SensoreInstallato>();
                while (reader.Read())
                {
                    sensoriInstallati.Add(new SensoreInstallato
                    {
                        idSensoriInstallati = (int)reader["idSensoriInstallati"],
                        idCodiceSensore = (int)reader["idCodiceSensore"],
                        idNomeStazione = (string)reader["idNomeStazione"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    });
                }
                return sensoriInstallati;
            }
        }

        public void CreaSensoriInstallati(SensoreInstallato sensoriInstallati)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO [SensoriInstallati] ([idSensoriInstallati], [idSensoriInstallati], [Note])
                    VALUES (@idSensoriInstallati, @idSensoriInstallati, @Note)",
                    conn);

                cmd.Parameters.AddWithValue("@idSensoriInstallati", sensoriInstallati.idSensoriInstallati);
                // Se il campo idSensoriInstallati è anche una chiave esterna, verifica l'implementazione appropriata
                cmd.Parameters.AddWithValue("@idSensoriInstallati", sensoriInstallati.idSensoriInstallati);
                cmd.Parameters.AddWithValue("@Note", sensoriInstallati.Note ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void ModificaSensoriInstallati(SensoreInstallato sensoriInstallati)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    UPDATE [dbo].[SensoriInstallati]
                    SET [idSensoriInstallati] = @idSensoriInstallati,
                        [idSensoriInstallati] = @idSensoriInstallati,
                        [Note] = @Note
                    WHERE idSensoriInstallati = @idSensoriInstallati",
                    conn);

                cmd.Parameters.AddWithValue("@idSensoriInstallati", sensoriInstallati.idSensoriInstallati);
                // Se il campo idSensoriInstallati è anche una chiave esterna, verifica l'implementazione appropriata
                cmd.Parameters.AddWithValue("@idSensoriInstallati", sensoriInstallati.idSensoriInstallati);
                cmd.Parameters.AddWithValue("@Note", sensoriInstallati.Note ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void EliminaSensoriInstallati(int id)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM SensoriInstallati WHERE idSensoriInstallati = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
