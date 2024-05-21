
// Andrea Maria Castronovo
// 5°I
// 11-05-2024
// Progetto stazione meteo


using System.Data.SqlClient;
using System.Diagnostics;
using BlazorApp_StazioneMeteo.Repository.Models;

namespace BlazorApp_StazioneMeteo.Repository.Entities
{
    public class StazioneDB : InterazioneDB<StazioneModel>
    {
        public StazioneDB(string conn) : base(conn)
        {
        }

        public override StazioneModel OttieniElemento(object idO)
        {
            string id = ControllaPrimaryKey<string>(idO);

            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(
                "SELECT * FROM Stazioni WHERE idNomeStazione = @id",
                conn);

                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new StazioneModel
                    {
                        idNomeStazione = reader["idNomeStazione"] == DBNull.Value ? null : (string)reader["idNomeStazione"],
                        Altitudine = reader["Altitudine"] == DBNull.Value ? null : (int)reader["Altitudine"],
                        IP_Statico = reader["IP_Statico"] == DBNull.Value ? null : (string)reader["IP_Statico"],
                        Descrizione = reader["Descrizione"] == DBNull.Value ? null : (string)reader["Descrizione"],
                        Latitudine = reader["Latitudine"] == DBNull.Value ? null : (decimal)reader["Latitudine"],
                        Localita_Indirizzo = reader["Localita_Indirizzo"] == DBNull.Value ? null : (string)reader["Localita_Indirizzo"],
                        Longitudine = reader["Longitudine"] == DBNull.Value ? null : (decimal)reader["Longitudine"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    };
                }
                return null;
            }
        }
        public override List<StazioneModel> OttieniElementi()
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Stazioni", conn);
                var reader = cmd.ExecuteReader();
                var customers = new List<StazioneModel>();
                while (reader.Read())
                {
                    customers.Add(new StazioneModel
                    {
                        idNomeStazione = reader["idNomeStazione"] == DBNull.Value ? null : (string)reader["idNomeStazione"],
                        Altitudine = reader["Altitudine"] == DBNull.Value ? null : (int)reader["Altitudine"],
                        IP_Statico = reader["IP_Statico"] == DBNull.Value ? null : (string)reader["IP_Statico"],
                        Descrizione = reader["Descrizione"] == DBNull.Value ? null : (string)reader["Descrizione"],
                        Latitudine = reader["Latitudine"] == DBNull.Value ? null : (decimal)reader["Latitudine"],
                        Localita_Indirizzo = reader["Localita_Indirizzo"] == DBNull.Value ? null : (string)reader["Localita_Indirizzo"],
                        Longitudine = reader["Longitudine"] == DBNull.Value ? null : (decimal)reader["Longitudine"],
                        Note = reader["Note"] == DBNull.Value ? null : (string)reader["Note"]
                    });
                }
                return customers;
            }
        }
        public override void CreaElemento(StazioneModel customer)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                        INSERT INTO [Stazioni]
                   ([idNomeStazione], [IP_Statico], [Localita_Indirizzo], [Latitudine], [Longitudine], [Altitudine], [Descrizione], [Note])
                    VALUES (@idNomeStazione,@IP_Statico,@Localita_Indirizzo,@Latitudine,@Longitudine,@Altitudine,@Descrizione,@Note)",
                    conn
                );

                cmd.Parameters.AddWithValue("@idNomeStazione", customer.idNomeStazione == null ? DBNull.Value : customer.idNomeStazione);
                cmd.Parameters.AddWithValue("@IP_Statico", customer.IP_Statico == null ? DBNull.Value : customer.IP_Statico);
                cmd.Parameters.AddWithValue("@Localita_Indirizzo", customer.Localita_Indirizzo == null ? DBNull.Value : customer.Localita_Indirizzo);
                cmd.Parameters.AddWithValue("@Latitudine", customer.Latitudine == null ? DBNull.Value : customer.Latitudine);
                cmd.Parameters.AddWithValue("@Longitudine", customer.Longitudine == null ? DBNull.Value : customer.Longitudine);
                cmd.Parameters.AddWithValue("@Altitudine", customer.Altitudine == null ? DBNull.Value : customer.Altitudine);
                cmd.Parameters.AddWithValue("@Descrizione", customer.Descrizione == null ? DBNull.Value : customer.Descrizione);
                cmd.Parameters.AddWithValue("@Note", customer.Note == null ? DBNull.Value : customer.Note);

                cmd.ExecuteNonQuery();
            }
        }
        public override void ModificaElemento(StazioneModel customer)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                UPDATE [dbo].[Stazioni]
                   SET 
                      [IP_Statico] = @IP_Statico
                      ,[Localita_Indirizzo] = @Localita_Indirizzo
                      ,[Latitudine] = @Latitudine
                      ,[Longitudine] = @Longitudine
                      ,[Altitudine] = @Altitudine
                      ,[Descrizione] = @Descrizione
                      ,[Note] = @Note
                 WHERE idNomeStazione = @idNomeStazione",
                conn);

                cmd.Parameters.AddWithValue("@idNomeStazione", customer.idNomeStazione ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IP_Statico", customer.IP_Statico ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Localita_Indirizzo", customer.Localita_Indirizzo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Latitudine", customer.Latitudine == null ? DBNull.Value : customer.Latitudine);
                cmd.Parameters.AddWithValue("@Longitudine", customer.Longitudine ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Altitudine", customer.Altitudine ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Descrizione", customer.Descrizione ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Note", customer.Note ?? (object)DBNull.Value);

                Debug.WriteLine(cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
        }
        public override void EliminaElemento(object idO)
        {
            string id = ControllaPrimaryKey<string>(idO);
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Stazioni WHERE idNomeStazione = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

    }
}