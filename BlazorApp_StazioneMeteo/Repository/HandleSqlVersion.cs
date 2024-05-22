//namespace BlazorApp_StazioneMeteo.Repository
//{
//    using MySql.Data.MySqlClient;
//    using System.Data.SqlClient;

//    public static class HandleSqlVersion
//    {
//        // SqlServer
//        // MySql
//        static public string Type { get; set; } = "SqlServer";
//    }

//    class SqlCommand
//    {

//        public Type Tipo { get; set; }

//        public object cmd
//        {
//            get
//            {
//                if (HandleSqlVersion.Type == "SqlServer")
//                    return (SqlCommand)cmd;
//                else if (HandleSqlVersion.Type == "MySql")
//                    return (MySqlCommand)cmd;
//                else
//                    return null;
//            }
//            set
//            {
//                if (HandleSqlVersion.Type == "SqlServer")
//                    cmd = (SqlCommand)value;
//                else if (HandleSqlVersion.Type == "MySql")
//                    cmd =(MySqlCommand)cmd;
//            }
//        }

//        public SqlCommand(string query, object conn)
//        {
//            if (HandleSqlVersion.Type == "SqlServer")
//                cmd = new System.Data.SqlClient.SqlCommand(query, (SqlConnection)conn);
//            else if (HandleSqlVersion.Type == "MySql")
//                cmd = new MySqlCommand(query, (MySqlConnection)conn);
//        }


//    }
//}
