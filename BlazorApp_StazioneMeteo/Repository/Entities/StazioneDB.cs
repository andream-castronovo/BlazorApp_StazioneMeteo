using System.Data.SqlClient;
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
                        idNomeStazione = (string)reader["idNomeStazione"],
                        Altitudine = (int)reader["Altitudine"],
                        IP_Statico = (string)reader["IP_Statico"],
                        Descrizione = (string)reader["Descrizione"],
                        Latitudine = (decimal)reader["Latitudine"],
                        Localita_Indirizzo = (string)reader["Localita_Indirizzo"],
                        Longitudine = (decimal)reader["Longitudine"],
                        Note = (string)reader["Note"]
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
                        idNomeStazione = (string)reader["idNomeStazione"],
                        Altitudine = reader["Altitudine"] == DBNull.Value ? null : (int)reader["Altitudine"],
                        IP_Statico = (string)reader["IP_Statico"],
                        Descrizione = (string)reader["Descrizione"],
                        Latitudine = reader["Latitudine"] == DBNull.Value ? null : (decimal)reader["Latitudine"],
                        Localita_Indirizzo = (string)reader["Localita_Indirizzo"],
                        Longitudine = reader["Longitudine"] == DBNull.Value ? null : (decimal)reader["Longitudine"],
                        Note = (string)reader["Note"]
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

                cmd.Parameters.AddWithValue("@idNomeStazione", customer.idNomeStazione);
                cmd.Parameters.AddWithValue("@IP_Statico", customer.IP_Statico);
                cmd.Parameters.AddWithValue("@Localita_Indirizzo", customer.Localita_Indirizzo);
                cmd.Parameters.AddWithValue("@Latitudine", customer.Latitudine);
                cmd.Parameters.AddWithValue("@Longitudine", customer.Longitudine);
                cmd.Parameters.AddWithValue("@Altitudine", customer.Altitudine);
                cmd.Parameters.AddWithValue("@Descrizione", customer.Descrizione);
                cmd.Parameters.AddWithValue("@Note", customer.Note);

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
                   SET [idNomeStazione] = @idNomeStazione
                      ,[IP_Statico] = @IP_Statico
                      ,[Localita_Indirizzo] = @Localita_Indirizzo
                      ,[Latitudine] = @Latitudine, decimal(8
                      ,[Longitudine] = @Longitudine, decimal(8
                      ,[Altitudine] = @Altitudine
                      ,[Descrizione] = @Descrizione
                      ,[Note] = @Note
                 WHERE idNomeStazione = @idNomeStazione",
                conn);

                cmd.Parameters.AddWithValue("@idNomeStazione", customer.idNomeStazione);
                cmd.Parameters.AddWithValue("@IP_Statico", customer.IP_Statico);
                cmd.Parameters.AddWithValue("@Localita_Indirizzo", customer.Localita_Indirizzo);
                cmd.Parameters.AddWithValue("@Latitudine", customer.Latitudine);
                cmd.Parameters.AddWithValue("@Longitudine", customer.Longitudine);
                cmd.Parameters.AddWithValue("@Altitudine", customer.Altitudine);
                cmd.Parameters.AddWithValue("@Descrizione", customer.Descrizione);
                cmd.Parameters.AddWithValue("@Note", customer.Note);

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