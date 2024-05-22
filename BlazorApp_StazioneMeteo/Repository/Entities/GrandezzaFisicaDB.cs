// Andrea Maria Castronovo
// 5°I
// 11-05-2024
// Progetto stazione meteo

using System.Data.SqlClient;
using BlazorApp_StazioneMeteo.Repository.Models;

namespace BlazorApp_StazioneMeteo.Repository.Entities
{
    public class GrandezzaFisicaDB : InterazioneDB<GrandezzaFisica>
    {
        public GrandezzaFisicaDB(string conn) : base(conn)
        {
        }

        public override GrandezzaFisica OttieniElemento(object idO)
        {
            int id = ControllaPrimaryKey<int>(idO);

            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM GrandezzaFisica WHERE idGrandezzaFisica = @id",
                    conn).cmd;

                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Models.GrandezzaFisica
                    {
                        idGrandezzaFisica = (int)reader["idGrandezzaFisica"],
                        Nome = reader["GrandezzaFisica"] == DBNull.Value ? null : (string)reader["GrandezzaFisica"],
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
                SqlCommand cmdH = new SqlCommand("SELECT * FROM GrandezzaFisica", conn);
                //dynamic cmd = Convert.ChangeType(cmdH.cmd, cmdH.Tipo);
                var reader = cmdH.ExecuteReader();
                var grandezzeFisiche = new List<Models.GrandezzaFisica>();
                while (reader.Read())
                {
                    grandezzeFisiche.Add(new Models.GrandezzaFisica
                    {
                        idGrandezzaFisica = (int)reader["idGrandezzaFisica"],
                        Nome = reader["GrandezzaFisica"] == DBNull.Value ? null : (string)reader["GrandezzaFisica"],
                        Simbolo = reader["Simbolo"] == DBNull.Value ? null : (string)reader["Simbolo"],
                        SimboloUnitaDiMisuraAdottato = reader["SimboloUnitaDiMisuraAdottato"] == DBNull.Value ? null : (string)reader["SimboloUnitaDiMisuraAdottato"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    });
                }
                return grandezzeFisiche;
            }
        }

        public override void CreaElemento(GrandezzaFisica grandezzaFisica)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO [GrandezzaFisica] ([GrandezzaFisica], [Simbolo], [SimboloUnitaDiMisuraAdottato], [Note])
                    VALUES (@GrandezzaFisica, @Simbolo, @SimboloUnitaDiMisuraAdottato, @Note)",
                    conn);

                cmd.Parameters.AddWithValue("@GrandezzaFisica", grandezzaFisica.Nome ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Simbolo", grandezzaFisica.Simbolo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SimboloUnitaDiMisuraAdottato", grandezzaFisica.SimboloUnitaDiMisuraAdottato ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Note", grandezzaFisica.Note ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public override void ModificaElemento(GrandezzaFisica grandezzaFisica)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    UPDATE [dbo].[GrandezzaFisica]
                    SET [GrandezzaFisica] = @GrandezzaFisica,
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

        public override void EliminaElemento(object idO)
        {
            int id = ControllaPrimaryKey<int>(idO);

            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM GrandezzaFisica WHERE idGrandezzaFisica = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public override List<GrandezzaFisica> OttieniElementi()
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM GrandezzaFisica", conn);
                var reader = cmd.ExecuteReader();
                var grandezzeFisiche = new List<Models.GrandezzaFisica>();
                while (reader.Read())
                {
                    grandezzeFisiche.Add(new Models.GrandezzaFisica
                    {
                        idGrandezzaFisica = (int)reader["idGrandezzaFisica"],
                        Nome = reader["GrandezzaFisica"] == DBNull.Value ? null : (string)reader["GrandezzaFisica"],
                        Simbolo = reader["Simbolo"] == DBNull.Value ? null : (string)reader["Simbolo"],
                        SimboloUnitaDiMisuraAdottato = reader["SimboloUnitaDiMisuraAdottato"] == DBNull.Value ? null : (string)reader["SimboloUnitaDiMisuraAdottato"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    });
                }
                return grandezzeFisiche;
            }
        }
    }
}
