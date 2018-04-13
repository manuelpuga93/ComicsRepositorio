using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Conexion
    {
        public string _cadenaConexion { get; set; }

        public Conexion()
        {
            _cadenaConexion = ConfigurationManager.ConnectionStrings["ComicDBContext"].ToString();

        }

        public SqlConnection _Connection()
        {
            SqlConnection connection = new SqlConnection(_cadenaConexion);
            connection.Open();
            return connection;
        }
    }
}
