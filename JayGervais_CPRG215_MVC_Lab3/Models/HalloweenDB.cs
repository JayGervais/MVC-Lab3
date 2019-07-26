using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JayGervais_CPRG215_MVC_Lab3.Models
{
    public class HalloweenDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"data source=localhost\SAITSQLEXPRESS;initial catalog=Halloween;integrated security=True";
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
    }
}