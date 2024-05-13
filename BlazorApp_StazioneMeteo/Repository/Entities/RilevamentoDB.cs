using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using BlazorApp_StazioneMeteo.Repository.Models;

namespace BlazorApp_StazioneMeteo.Repository.Entities
{
    public class RilevamentoDB
    {
        private readonly string _conn;
        public RilevamentoDB(string conn)
        {
            _conn = conn;
        }

        public Rilevamento OttieneRilevamento(int id)
        {
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

        public List<Rilevamento> OttieneRilevamenti(int page = 1)
        {
            if (page < 1)
                throw new ArgumentException("La pagina deve essere almeno 1");

            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand($@"
                    SELECT * FROM Rilevamenti 
                    ORDER BY DataOra DESC
                    OFFSET ({page - 1})*10 ROWS
                    FETCH NEXT 10 ROWS ONLY;",
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

        public void CreaRilevamento(Rilevamento rilevamento)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO [Rilevamenti] ([idSensoriInstallati], [DataOra], [Dato])
                    VALUES (@idSensoriInstallati, @DataOra, @Dato)",
                    conn);

                cmd.Parameters.AddWithValue("@idSensoriInstallati", rilevamento.idSensoriInstallati);
                cmd.Parameters.AddWithValue("@DataOra", rilevamento.DataOra);
                cmd.Parameters.AddWithValue("@Dato", rilevamento.Dato ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void ModificaRilevamento(Rilevamento rilevamento)
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
                cmd.Parameters.AddWithValue("@idSensoriInstallati", rilevamento.idSensoriInstallati);
                cmd.Parameters.AddWithValue("@DataOra", rilevamento.DataOra);
                cmd.Parameters.AddWithValue("@Dato", rilevamento.Dato ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public void EliminaRilevamento(int id)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Rilevamenti WHERE idRilevamenti = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Rilevamento> OttieniRilevamentiPerTabella(int page = 1)
        {
            if (page < 1)
                throw new ArgumentException("La pagina deve essere almeno 1");

            using (var conn = new SqlConnection(_conn))
            {
                // TODO: Continua da qui, stavi facendo la query di JOIN per mostrare tutto per bene,
                // il metodo probabilmente deve restituire una lista di stringhe.
                conn.Open();
                var cmd = new SqlCommand($@"
                    SELECT * FROM Rilevamenti 
                    ORDER BY DataOra DESC
                    OFFSET ({page - 1})*10 ROWS
                    FETCH NEXT 10 ROWS ONLY;",
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
    }
}

