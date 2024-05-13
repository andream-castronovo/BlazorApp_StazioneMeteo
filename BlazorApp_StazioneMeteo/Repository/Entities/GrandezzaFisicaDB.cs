using System.Data.SqlClient;
using BlazorApp_StazioneMeteo.Repository.Models;

namespace BlazorApp_StazioneMeteo.Repository.Entities
{
    public class GrandezzaFisicaDB
    {
        private readonly string _conn;
        public GrandezzaFisicaDB(string conn)
        {
            _conn = conn;
        }

        public GrandezzaFisica OttieneGrandezzaFisica(int id)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM GrandezzeFisiche WHERE idGrandezzaFisica = @id",
                    conn);

                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new GrandezzaFisica
                    {
                        idGrandezzaFisica = (int)reader["idGrandezzaFisica"],
                        Nome = reader["Nome"] == DBNull.Value ? null : (string)reader["Nome"],
                        Simbolo = reader["Simbolo"] == DBNull.Value ? null : (string)reader["Simbolo"],
                        SimboloUnitaDiMisuraAdottato = reader["SimboloUnitaDiMisuraAdottato"] == DBNull.Value ? null : (string)reader["SimboloUnitaDiMisuraAdottato"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    };
                }
                return null;
            }
        }

        public List<GrandezzaFisica> OttieneGrandezzeFisiche()
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM GrandezzeFisiche", conn);
                var reader = cmd.ExecuteReader();
                var grandezzeFisiche = new List<GrandezzaFisica>();
                while (reader.Read())
                {
                    grandezzeFisiche.Add(new GrandezzaFisica
                    {
                        idGrandezzaFisica = (int)reader["idGrandezzaFisica"],
                        Nome = reader["Nome"] == DBNull.Value ? null : (string)reader["Nome"],
                        Simbolo = reader["Simbolo"] == DBNull.Value ? null : (string)reader["Simbolo"],
                        SimboloUnitaDiMisuraAdottato = reader["SimboloUnitaDiMisuraAdottato"] == DBNull.Value ? null : (string)reader["SimboloUnitaDiMisuraAdottato"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    });
                }
                return grandezzeFisiche;
            }
        }

        public void CreaGrandezzaFisica(GrandezzaFisica grandezzaFisica)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO [GrandezzeFisiche] ([Nome], [Simbolo], [SimboloUnitaDiMisuraAdottato], [Note])
                    VALUES (@Nome, @Simbolo, @SimboloUnitaDiMisuraAdottato, @Note)",
                    conn);

                cmd.Parameters.AddWithValue("@Nome", grandezzaFisica.Nome ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Simbolo", grandezzaFisica.Simbolo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SimboloUnitaDiMisuraAdottato", grandezzaFisica.SimboloUnitaDiMisuraAdottato ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Note", grandezzaFisica.Note ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void ModificaGrandezzaFisica(GrandezzaFisica grandezzaFisica)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    UPDATE [dbo].[GrandezzeFisiche]
                    SET [Nome] = @Nome,
                        [Simbolo] = @Simbolo,
                        [SimboloUnitaDiMisuraAdottato] = @SimboloUnitaDiMisuraAdottato,
                        [Note] = @Note
                    WHERE idGrandezzaFisica = @idGrandezzaFisica",
                    conn);

                cmd.Parameters.AddWithValue("@idGrandezzaFisica", grandezzaFisica.idGrandezzaFisica);
                cmd.Parameters.AddWithValue("@Nome", grandezzaFisica.Nome ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Simbolo", grandezzaFisica.Simbolo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SimboloUnitaDiMisuraAdottato", grandezzaFisica.SimboloUnitaDiMisuraAdottato ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Note", grandezzaFisica.Note ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void EliminaGrandezzaFisica(int id)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM GrandezzeFisiche WHERE idGrandezzaFisica = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
