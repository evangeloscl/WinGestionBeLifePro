using System;
using System.Collections;
using WinGestionBeLifePro.DAO;
using WinGestionBeLifePro.Model;

namespace WinGestionBeLifePro.Controller
{
    class GestionBelife
    {
        private ArrayList clientes;

        private ArrayList estados;

        public ArrayList listarClientes()
        {
            ArrayList rows = new ArrayList();
            this.clientes = new DAOCliente().Listar();
            foreach(Cliente cliente in this.clientes)
            {
                String[] datos = new String[5];
                datos[0] = cliente.Rut;
                datos[1] = cliente.Nombre + " " + cliente.Apellidos;
                datos[2] = cliente.Fec_nac;
                datos[3] = cliente.Genero;
                datos[4] = cliente.Ecivil;

                rows.Add(datos);
            }
            return rows;
        }

        public ArrayList listarClientes(int id_genero)
        {
            ArrayList rows = new ArrayList();
            this.clientes = new DAOCliente().listarPorGenero(id_genero);
            foreach (Cliente cliente in this.clientes)
            {
                String[] datos = new String[5];
                datos[0] = cliente.Rut;
                datos[1] = cliente.Nombre + " " + cliente.Apellidos;
                datos[2] = cliente.Fec_nac;
                datos[3] = cliente.Genero;
                datos[4] = cliente.Ecivil;

                rows.Add(datos);
            }
            return rows;
        }

        public ArrayList listarClientes(String ecivil)
        {
            ArrayList rows = new ArrayList();
            this.clientes = new DAOCliente().listarPorEcivil(ecivil);
            foreach (Cliente cliente in this.clientes)
            {
                String[] datos = new String[5];
                datos[0] = cliente.Rut;
                datos[1] = cliente.Nombre + " " + cliente.Apellidos;
                datos[2] = cliente.Fec_nac;
                datos[3] = cliente.Genero;
                datos[4] = cliente.Ecivil;

                rows.Add(datos);
            }
            return rows;
        }

        public ArrayList listarClientes(String ecivil, int id_genero)
        {
            ArrayList rows = new ArrayList();
            this.clientes = new DAOCliente().listarPorEcivilGenero(ecivil, id_genero);
            foreach (Cliente cliente in this.clientes)
            {
                String[] datos = new String[5];
                datos[0] = cliente.Rut;
                datos[1] = cliente.Nombre + " " + cliente.Apellidos;
                datos[2] = cliente.Fec_nac;
                datos[3] = cliente.Genero;
                datos[4] = cliente.Ecivil;

                rows.Add(datos);
            }
            return rows;
        }

        public bool nuevoCliente(String rut, String nombre, String apellido, String fec_nac, int id_genero, 
                                    int id_ecivil)
        {
            bool registrado = new DAOCliente().insert(new Cliente(rut, nombre, apellido, fec_nac, id_genero, id_ecivil));
            return registrado;
        }

        public bool editarUsuario() {
            return true;
        }


        public ArrayList listarEstadoCivil()
        {
            ArrayList rows = new ArrayList();
            this.estados = new DAOEstadoCivil().Listar();
            foreach (EstadoCivil estado in this.estados)
            {
                String[] datos = new String[5];
                datos[0] = estado.Id_estado.ToString();
                datos[1] = estado.Descripcion;
                
                rows.Add(datos);
            }
            return rows;
        }
    }
}