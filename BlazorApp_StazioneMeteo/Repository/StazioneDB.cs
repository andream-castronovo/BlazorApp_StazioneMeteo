using System.Data.SqlClient;

namespace BlazorApp_StazioneMeteo.Repository
{
    public class StazioneDB
    {
        private readonly string _conn;
        public StazioneDB(string conn)
        {
            _conn = conn;
        }
        public Stazione OttieneCustomer(string id)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(
                "SELECT * FROM Customers WHERE CustomerID = @id",
                conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Stazione
                    {
                        //CustomerID = (string)reader["CustomerID"],
                        //CompanyName = (string)reader["CompanyName"],
                        //ContactName = (string)reader["ContactName"],
                    };
                }
                return null;
            }
        }
        public List<Stazione> OttieneCustomers()
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(
                "SELECT * FROM Customers",
                conn);
                var reader = cmd.ExecuteReader();
                var customers = new List<Stazione>();
                while (reader.Read())
                {
                    customers.Add(new Stazione
                    {
                        CustomerID = (string)reader["CustomerID"],
                        CompanyName = (string)reader["CompanyName"],
                        ContactName = (string)reader["ContactName"],
                    });
                }
                return customers;
            }
        }
        public void CreaCustomer(Stazione customer)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(
                "INSERT INTO Customers (CustomerID, CompanyName, ContactName) " +
    
                "VALUES (@customerID, @companyName, @contactName)",
                conn);
                cmd.Parameters.AddWithValue("@customerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@companyName", customer.CompanyName);
                cmd.Parameters.AddWithValue("@contactName", customer.ContactName);
                cmd.ExecuteNonQuery();
            }
        }
        public void ModificaCustomer(Stazione customer)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand(
                "UPDATE Customers SET " +
                "CompanyName = @companyName, ContactName = @contactName" +
                " WHERE CustomerID = @id",
                conn);
                cmd.Parameters.AddWithValue("@id", customer.CustomerID);
                cmd.Parameters.AddWithValue("@companyName", customer.CompanyName);
                cmd.Parameters.AddWithValue("@contactName", customer.ContactName);
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminaCustomer(string id)
        {
            using (var conn = new SqlConnection(_conn))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}