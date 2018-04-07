using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinGestionBeLifePro.Model
{
    class EstadoCivil
    {
        private int id_estado;
        private String descripcion;

        public EstadoCivil()
        {
        }

        public EstadoCivil(int id_estado, String descripcion)
        {
            this.id_estado = id_estado;
            this.descripcion = descripcion;
        }

        public int Id_estado { get => id_estado; set => id_estado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
