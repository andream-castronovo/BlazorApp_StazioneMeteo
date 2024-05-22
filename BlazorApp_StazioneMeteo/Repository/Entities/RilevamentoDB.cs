// Andrea Maria Castronovo
// 5°I
// 22-05-2024
// Progetto stazione meteo
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using BlazorApp_StazioneMeteo.Repository.Models;
using BlazorApp_StazioneMeteo.Pages;

namespace BlazorApp_StazioneMeteo.Repository.Entities
{
    public class RilevamentoDB : InterazioneDB<Rilevamento>
    {
        public RilevamentoDB(string conn) : base(conn)
        {
        }
        public override void CreaElemento(Rilevamento rilevamento)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO [Rilevamenti] ([idSensoriInstallati], [DataOra], [Dato])
                    VALUES (@idSensoriInstallati, @DataOra, @Dato)",
                    conn);

                cmd.Parameters.AddWithValue("@idSensoriInstallati", rilevamento.idSensoriInstallati);
                cmd.Parameters.AddWithValue("@DataOra", rilevamento.DataOra ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Dato", rilevamento.Dato ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }

        }

        public override void EliminaElemento(object idO)
        {
            int id = ControllaPrimaryKey<int>(idO);
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Rilevamenti WHERE idRilevamenti = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

        }

        public override void ModificaElemento(Rilevamento rilevamento)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    UPDATE [dbo].[Rilevamenti]
                    SET [idSensoriInstallati] = @idSensoriInstallati,
                        [DataOra] = @DataOra,
                        [Dato] = @Dato
                    WHERE idRilevamenti = @idRilevamenti",
                    conn);

                cmd.Parameters.AddWithValue("@idRilevamenti", rilevamento.idRilevamenti);
                cmd.Parameters.AddWithValue("@idSensoriInstallati", rilevamento.idSensoriInstallati ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DataOra", rilevamento.DataOra ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Dato", rilevamento.Dato ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }

        }

        public override List<Rilevamento> OttieniElementi()
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand($@"
                    SELECT * FROM Rilevamenti 
                    ORDER BY DataOra DESC",
                    //OFFSET ({page - 1})*10 ROWS
                    //FETCH NEXT 10 ROWS ONLY;",
                    conn
                );
                var reader = cmd.ExecuteReader();
                var rilevamenti = new List<Rilevamento>();
                while (reader.Read())
                {
                    rilevamenti.Add(new Rilevamento
                    {
                        idRilevamenti = (int)reader["idRilevamenti"],
                        idSensoriInstallati = (int)reader["idSensoriInstallati"],
                        DataOra = (DateTime)reader["DataOra"],
                        Dato = reader["Dato"] == DBNull.Value ? null : (string)reader["Dato"]
                    });
                }
                return rilevamenti;
            }
        }

        public override Rilevamento OttieniElemento(object idO)
        {
            int id = ControllaPrimaryKey<int>(idO);
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Rilevamenti WHERE idRilevamenti = @id",
                    conn);

                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Rilevamento
                    {
                        idRilevamenti = (int)reader["idRilevamenti"],
                        idSensoriInstallati = (int)reader["idSensoriInstallati"],
                        DataOra = (DateTime)reader["DataOra"],
                        Dato = reader["Dato"] == DBNull.Value ? null : (string)reader["Dato"]
                    };
                }
                return null;
            }

        }



    }
}

