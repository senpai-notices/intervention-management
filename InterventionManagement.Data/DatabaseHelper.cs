using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Data
{
    public class DatabaseHelper
    {
        public static string ConnectionString
        {
            get
            {
                var connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                var sb = new SqlConnectionStringBuilder(connStr);
                sb.ApplicationName = ApplicationName ?? sb.ApplicationName;
                sb.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : sb.ConnectTimeout;
                return sb.ToString();
            }  
        }
        /// <summary>
        /// Opens connection and returns it
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();

            return conn;
        }

        /// <summary>
        /// Overrides application name
        /// </summary>
        public static string ApplicationName { get; set; }

        /// <summary>
        /// Overrides connection timeout
        /// </summary>
        public static int ConnectionTimeout { get; set; }

        
    }
}
