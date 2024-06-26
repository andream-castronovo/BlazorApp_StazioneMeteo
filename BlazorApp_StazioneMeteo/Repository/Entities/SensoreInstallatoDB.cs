﻿// Andrea Maria Castronovo
// 5°I
// 22-05-2024
// Progetto stazione meteo
using System.Data.SqlClient;
using BlazorApp_StazioneMeteo.Repository.Models;

namespace BlazorApp_StazioneMeteo.Repository.Entities
{
    public class SensoriInstallatiDB : InterazioneDB<SensoreInstallato>
    {
        public SensoriInstallatiDB(string conn) : base(conn)
        {
        }

        public override SensoreInstallato OttieniElemento(object idO)
        {
            int id = ControllaPrimaryKey<int>(idO);

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
                        idCodiceSensore = reader["idCodiceSensore"] == DBNull.Value ? null : (int)reader["idCodiceSensore"],
                        idNomeStazione = reader["idNomeStazione"] == DBNull.Value ? null : (string)reader["idNomeStazione"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    };
                }
                return null;
            }
        }

        public override List<SensoreInstallato> OttieniElementi()
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
                        idCodiceSensore = reader["idCodiceSensore"] == DBNull.Value ? null : (int)reader["idCodiceSensore"],
                        idNomeStazione = reader["idNomeStazione"] == DBNull.Value ? null : (string)reader["idNomeStazione"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    });
                }
                return sensoriInstallati;
            }
        }

        public override void CreaElemento(SensoreInstallato sensoriInstallati)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO [SensoriInstallati] ([idCodiceSensore], [Note], [idNomeStazione])
                    VALUES (@idCodiceSensore, @Note, @idNomeStazione)",
                    conn);

                cmd.Parameters.AddWithValue("@idSensoriInstallati", sensoriInstallati.idSensoriInstallati);
                cmd.Parameters.AddWithValue("@idCodiceSensore", sensoriInstallati.idCodiceSensore ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@idNomeStazione", sensoriInstallati.idNomeStazione ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Note", sensoriInstallati.Note ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public override void ModificaElemento(SensoreInstallato sensoriInstallati)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    UPDATE [dbo].[SensoriInstallati]
                    SET [idCodiceSensore] = @idCodiceSensore,
                        [idNomeStazione] = @idNomeStazione,
                        [Note] = @Note
                    WHERE idSensoriInstallati = @idSensoriInstallati",
                    conn);

                cmd.Parameters.AddWithValue("@idSensoriInstallati", sensoriInstallati.idSensoriInstallati);
                cmd.Parameters.AddWithValue("@idCodiceSensore", sensoriInstallati.idCodiceSensore ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@idNomeStazione", sensoriInstallati.idNomeStazione ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Note", sensoriInstallati.Note ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public override void EliminaElemento(object idO)
        {
            int id = ControllaPrimaryKey<int>(idO);

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
