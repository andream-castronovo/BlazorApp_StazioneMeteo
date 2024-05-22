// Andrea Maria Castronovo
// 5°I
// 22-05-2024
// Progetto stazione meteo

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorApp_StazioneMeteo.Repository.Models;

namespace BlazorApp_StazioneMeteo.Repository.Entities
{
    public class SensoreDB : InterazioneDB<Sensore>
    {
        public SensoreDB(string conn) : base(conn)
        {
        }

        public override Sensore OttieniElemento(object idO)

        {
            int id = ControllaPrimaryKey<int>(idO);
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Sensori WHERE idCodiceSensore = @id",
                    conn);

                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Sensore
                    {
                        idCodiceSensore = (int)reader["idCodiceSensore"],
                        idGrandezzaFisica = reader["idGrandezzaFisica"] == DBNull.Value ? null : (int)reader["idGrandezzaFisica"],
                        Camera = (byte)reader["Camera"],
                        Nome = reader["Nome"] == DBNull.Value ? null : (string)reader["Nome"],
                        Tipo = reader["Tipo"] == DBNull.Value ? null : (string)reader["Tipo"],
                        Caratteristiche = reader["Caratteristiche"] == DBNull.Value ? null : (string)reader["Caratteristiche"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    };
                }
                return null;
            }
        }

        public override List<Sensore> OttieniElementi()
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Sensori", conn);
                var reader = cmd.ExecuteReader();
                var sensori = new List<Sensore>();
                while (reader.Read())
                {
                    sensori.Add(new Sensore
                    {
                        idCodiceSensore = (int)reader["idCodiceSensore"],
                        idGrandezzaFisica = (int)reader["idGrandezzaFisica"],
                        Camera = (byte)reader["Camera"],
                        Nome = reader["Nome"] == DBNull.Value ? null : (string)reader["Nome"],
                        Tipo = reader["Tipo"] == DBNull.Value ? null : (string)reader["Tipo"],
                        Caratteristiche = reader["Caratteristiche"] == DBNull.Value ? null : (string)reader["Caratteristiche"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    });
                }
                return sensori;
            }
        }

        public override void CreaElemento(Sensore sensore)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO [Sensori] ([idGrandezzaFisica], [Camera], [Nome], [Tipo], [Caratteristiche], [Note])
                    VALUES (@idGrandezzaFisica, @Camera, @Nome, @Tipo, @Caratteristiche, @Note)",
                    conn);

                cmd.Parameters.AddWithValue("@idGrandezzaFisica", sensore.idGrandezzaFisica);
                cmd.Parameters.AddWithValue("@Camera", sensore.Camera);
                cmd.Parameters.AddWithValue("@Nome", sensore.Nome ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Tipo", sensore.Tipo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Caratteristiche", sensore.Caratteristiche ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Note", sensore.Note ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public override void ModificaElemento(Sensore sensore)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    UPDATE [dbo].[Sensori]
                    SET [idGrandezzaFisica] = @idGrandezzaFisica,
                        [Camera] = @Camera,
                        [Nome] = @Nome,
                        [Tipo] = @Tipo,
                        [Caratteristiche] = @Caratteristiche,
                        [Note] = @Note
                    WHERE idCodiceSensore = @idCodiceSensore",
                    conn);

                cmd.Parameters.AddWithValue("@idCodiceSensore", sensore.idCodiceSensore);
                cmd.Parameters.AddWithValue("@idGrandezzaFisica", sensore.idGrandezzaFisica);
                cmd.Parameters.AddWithValue("@Camera", sensore.Camera);
                cmd.Parameters.AddWithValue("@Nome", sensore.Nome ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Tipo", sensore.Tipo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Caratteristiche", sensore.Caratteristiche ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Note", sensore.Note ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public override void EliminaElemento(object idO)
        {
            int id = ControllaPrimaryKey<int>(idO);
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Sensori WHERE idCodiceSensore = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
