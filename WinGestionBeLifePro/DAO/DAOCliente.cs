using System;
using System.Collections;
using MySql.Data.MySqlClient;
using WinGestionBeLifePro.DB;
using WinGestionBeLifePro.Model;

namespace WinGestionBeLifePro.DAO
{
    class DAOCliente
    {
        private string sql_selectAll = "select rut, nombre, apellidos, date_format(fec_nac, '%d-%m-%Y') fec_nac, id_genero, id_ecivil, e.descripcion, g.descripcion from cliente join genero g using(id_genero) join estado_civil e using(id_ecivil);";
        private string sql_selectGenero = "select rut, nombre, apellidos, date_format(fec_nac, '%d-%m-%Y') fec_nac, id_genero, id_ecivil, e.descripcion, g.descripcion from cliente join genero g using(id_genero) join estado_civil e using(id_ecivil) where id_genero = ";
        private string sql_selectEcivil = "select rut, nombre, apellidos, date_format(fec_nac, '%d-%m-%Y') fec_nac, id_genero, id_ecivil, e.descripcion, g.descripcion from cliente join genero g using(id_genero) join estado_civil e using(id_ecivil) where e.descripcion = '";
        private string sql_selectGeneroEcivil_1 = "select rut, nombre, apellidos, date_format(fec_nac, '%d-%m-%Y') fec_nac, id_genero, id_ecivil, e.descripcion, g.descripcion from cliente join genero g using(id_genero) join estado_civil e using(id_ecivil) where e.descripcion = '";
        private string sql_selectGeneroEcivil_2 = " and id_genero = ";
        private string sql_Insert = "insert into cliente values (@rut, @nombre, @apellido, str_to_date(@fec_nac, '%d-%m-%Y'), @id_genero, @id_ecivil);";
        private MySqlConexion sql = new MySqlConexion();
        private ArrayList result;
        private Cliente registro = new Cliente();

        public DAOCliente()
        {
            this.result = new ArrayList();
        }

        public ArrayList Listar()
        {
            this.result.Clear();

            try {
                MySqlCommand query = new MySqlCommand(this.sql_selectAll, this.sql.conexion);
                MySqlDataReader data = query.ExecuteReader();

                while(data.Read())
                {
                    this.result.Add(new Cliente(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3),
                                                data.GetInt16(4), data.GetInt16(5), data.GetString(6), data.GetString(7)));
                }
            } catch (Exception ex) { }
            finally { this.sql.Dispose(); }

            return this.result;
        }

        public ArrayList listarPorGenero(int id_genero)
        {
            this.result.Clear();

            try
            {
                MySqlCommand query = new MySqlCommand(this.sql_selectGenero + id_genero, this.sql.conexion);
                MySqlDataReader data = query.ExecuteReader();

                while (data.Read())
                {
                    this.result.Add(new Cliente(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3),
                                                data.GetInt16(4), data.GetInt16(5), data.GetString(6), data.GetString(7)));
                }
            }
            catch (Exception ex) { }
            finally { this.sql.Dispose(); }

            return this.result;
        }

        public ArrayList listarPorEcivil(String ecivil)
        {
            this.result.Clear();

            try
            {
                MySqlCommand query = new MySqlCommand(this.sql_selectEcivil + ecivil + "'", this.sql.conexion);
                MySqlDataReader data = query.ExecuteReader();

                while (data.Read())
                {
                    this.result.Add(new Cliente(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3),
                                                data.GetInt16(4), data.GetInt16(5), data.GetString(6), data.GetString(7)));
                }
            }
            catch (Exception ex) { }
            finally { this.sql.Dispose(); }

            return this.result;
        }

        public ArrayList listarPorEcivilGenero(String ecivil , int id_genero)
        {
            this.result.Clear();

            try
            {
                MySqlCommand query = new MySqlCommand(this.sql_selectGeneroEcivil_1 + ecivil + "'" + this.sql_selectGeneroEcivil_2 + id_genero, this.sql.conexion);
                MySqlDataReader data = query.ExecuteReader();

                while (data.Read())
                {
                    this.result.Add(new Cliente(data.GetString(0), data.GetString(1), data.GetString(2), data.GetString(3),
                                                data.GetInt16(4), data.GetInt16(5), data.GetString(6), data.GetString(7)));
                }
            }
            catch (Exception ex) { }
            finally { this.sql.Dispose(); }

            return this.result;
        }

        public bool insert(Cliente cliente)
        {
            try
            {
                MySqlCommand query = new MySqlCommand(this.sql_Insert, this.sql.conexion);
                query.Prepare();
                query.Parameters.AddWithValue("@rut", cliente.Rut);
                query.Parameters.AddWithValue("@nombre", cliente.Nombre);
                query.Parameters.AddWithValue("@apellido", cliente.Apellidos);
                query.Parameters.AddWithValue("@fec_nac", cliente.Fec_nac);
                query.Parameters.AddWithValue("@id_genero", cliente.Id_genero);
                query.Parameters.AddWithValue("@id_ecivil", cliente.Id_ecivil);

                if(query.ExecuteNonQuery() != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { return false; }
            finally { this.sql.Dispose(); }
        }
    }
}
