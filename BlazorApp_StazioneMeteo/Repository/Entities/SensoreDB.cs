using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorApp_StazioneMeteo.Repository.Models;

namespace BlazorApp_StazioneMeteo.Repository.Entities
{
    public class SensoreDB
    {
        private readonly string _conn;
        public SensoreDB(string conn)
        {
            _conn = conn;
        }

        public Sensore OttieneSensore(int id)
        {
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
                        idGrandezzaFisica = (int)reader["idGrandezzaFisica"],
                        Camera = (short)reader["Camera"],
                        Nome = reader["Nome"] == DBNull.Value ? null : (string)reader["Nome"],
                        Tipo = reader["Tipo"] == DBNull.Value ? null : (string)reader["Tipo"],
                        Caratteristiche = reader["Caratteristiche"] == DBNull.Value ? null : (string)reader["Caratteristiche"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    };
                }
                return null;
            }
        }

        public List<Sensore> OttieneSensori()
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
                        Camera = (short)reader["Camera"],
                        Nome = reader["Nome"] == DBNull.Value ? null : (string)reader["Nome"],
                        Tipo = reader["Tipo"] == DBNull.Value ? null : (string)reader["Tipo"],
                        Caratteristiche = reader["Caratteristiche"] == DBNull.Value ? null : (string)reader["Caratteristiche"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    });
                }
                return sensori;
            }
        }

        public void CreaSensore(Sensore sensore)
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

        public void ModificaSensore(Sensore sensore)
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

        public void EliminaSensore(int id)
        {
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
