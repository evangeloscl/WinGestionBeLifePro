using System;

namespace WinGestionBeLifePro.Model
{
    class Cliente
    {
        private String rut, nombre, apellidos, fec_nac, ecivil, genero;
        private int id_genero, id_ecivil;

        public Cliente()
        {

        }

        public Cliente(String rut, String nombre, String apellidos, String fec_nac, int id_genero, int id_ecivil)
        {
            this.Rut = rut;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Fec_nac = fec_nac;
            this.Id_genero = id_genero;
            this.Id_ecivil = id_ecivil;
        }

        public Cliente(String rut, String nombre, String apellidos, String fec_nac, int id_genero, int id_ecivil, String ecivil, String genero) {
            this.Rut = rut;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Fec_nac = fec_nac;
            this.Id_genero = id_genero;
            this.Id_ecivil = id_ecivil;
            this.genero = genero;
            this.ecivil = ecivil;
        }

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Fec_nac { get => fec_nac; set => fec_nac = value; }
        public int Id_genero { get => id_genero; set => id_genero = value; }
        public int Id_ecivil { get => id_ecivil; set => id_ecivil = value; }
        public String Ecivil { get => ecivil; set => ecivil = value; }
        public String  Genero { get => genero; set => genero = value; }

    }
}
