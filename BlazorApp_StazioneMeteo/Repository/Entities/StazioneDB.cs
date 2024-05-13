using System.Data.SqlClient;
using BlazorApp_StazioneMeteo.Repository.Models;

namespace BlazorApp_StazioneMeteo.Repository.Entities
{
    public class StazioneDB
    {
        private readonly string _conn;
        public StazioneDB(string conn)
        {
            _conn = conn;
        }
        public Stazione OttieneStazione(string id)
        {
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
                    return new Stazione
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
        public List<Stazione> OttieneStazioni()
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Stazioni", conn);
                var reader = cmd.ExecuteReader();
                var customers = new List<Stazione>();
                while (reader.Read())
                {
                    customers.Add(new Stazione
                    {
                        idNomeStazione = (string)reader["idNomeStazione"],
                        Altitudine = (int)reader["Altitudine"],
                        IP_Statico = (string)reader["IP_Statico"],
                        Descrizione = (string)reader["Descrizione"],
                        Latitudine = (decimal)reader["Latitudine"],
                        Localita_Indirizzo = (string)reader["Localita_Indirizzo"],
                        Longitudine = (decimal)reader["Longitudine"],
                        Note = (string)reader["Note"]
                    });
                }
                return customers;
            }
        }
        public void CreaStazione(Stazione customer)
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
        public void ModificaStazione(Stazione customer)
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
        public void EliminaStazione(string id)
        {
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