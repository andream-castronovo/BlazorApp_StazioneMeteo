namespace BlazorApp_StazioneMeteo.Repository
{
    using MySql.Data.MySqlClient;
    using System.Data.SqlClient;

    public static class HandleSqlVersion
    {
        // SqlServer
        // MySql
        static public string Type { get; set; } = "SqlServer";
    }

    class SqlCommand2
    {

        public Type Tipo { get; set; }

        public object cmd
        {
            get;
            set;
        }

        public SqlCommand2(string query, object conn)
        {
            if (HandleSqlVersion.Type == "SqlServer")
            {
                cmd = new System.Data.SqlClient.SqlCommand(query, (SqlConnection)conn);
                Tipo = typeof(SqlCommand);
            }

            else if (HandleSqlVersion.Type == "MySql")
            {
                cmd = new MySqlCommand(query, (MySqlConnection)conn);
                Tipo = typeof(MySqlCommand);
            }
        }


    }
    class SqlConnection2
    {

        public Type Tipo { get; set; }

        public object con
        {
            get;set;
        }

        public SqlConnection2(string conn)
        {
            if (HandleSqlVersion.Type == "SqlServer")
            {
                con = new System.Data.SqlClient.SqlConnection(conn);
                Tipo = typeof(SqlConnection);
            }
            else if (HandleSqlVersion.Type == "MySql")
            {
                con = new MySqlConnection(conn);
                Tipo = typeof(MySqlConnection);
            }
        }


    }


}
