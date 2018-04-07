using System;
using System.Collections;
using MySql.Data.MySqlClient;
using WinGestionBeLifePro.DB;
using WinGestionBeLifePro.Model;

namespace WinGestionBeLifePro.DAO
{
    class DAOEstadoCivil
    {
        private String sql_selectAll = "select * from estado_civil";

        private MySqlConexion sql = new MySqlConexion();
        private ArrayList result;
        private EstadoCivil registro = new EstadoCivil();

        public DAOEstadoCivil()
        {
            this.result = new ArrayList();
        }

        public ArrayList Listar()
        {
            this.result.Clear();

            try
            {
                MySqlCommand query = new MySqlCommand(this.sql_selectAll, this.sql.conexion);
                MySqlDataReader data = query.ExecuteReader();

                while (data.Read())
                {
                    this.result.Add(new EstadoCivil(data.GetInt16(0), data.GetString(1)));
                }
            }
            catch (Exception ex) { }
            finally { this.sql.Dispose(); }

            return this.result;
        }
    }
}