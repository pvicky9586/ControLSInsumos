using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControLSInsumos
{
    public class conexionDB
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Conn = new SqlConnection(Properties.Settings.Default.Conectar);
            Conn.Open();
            return Conn;
        }
    }
}
