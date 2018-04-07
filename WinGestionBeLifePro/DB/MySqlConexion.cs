using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WinGestionBeLifePro.DB
{
    class MySqlConexion : IDisposable
    {
        public MySqlConnection conexion;
        private String cadenaConexion;
        //
        // Parámetros MySql
        //
        private String server = "127.0.0.1";
        private String database = "belife";
        private String user = "develop";
        private String password = "duocavaras";

        public MySqlConexion()
        {
            try
            {
                this.cadenaConexion = "server=" + this.server + "; Database=" + this.database + "; uid=" + this.user + "; pwd=" + this.password;
                this.conexion = new MySqlConnection(this.cadenaConexion);
                if (this.conexion.State != ConnectionState.Open)
                {
                    this.conexion.Open();
                }
            } catch(Exception ex) {}
        }

        public void Dispose()
        {
            if (this.conexion.State != ConnectionState.Closed)
            {
                this.conexion.Close();
            }
        }
    }
}
