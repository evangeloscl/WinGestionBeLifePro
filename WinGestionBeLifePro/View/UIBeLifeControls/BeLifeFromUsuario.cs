using System;
using System.Collections;
using System.Windows.Forms;
using WinGestionBeLifePro.Controller;

namespace WinGestionBeLifePro.UIBeLifeControls
{
    public partial class BeLifeFromUsuario : UserControl
    {
        private ArrayList estados;
        private bool nuevo;

        public BeLifeFromUsuario()
        {
            InitializeComponent();
        }

        public bool Nuevo { get => nuevo; set => nuevo = value; }

        private void BeLifeFromUsuario_Load(object sender, EventArgs e)
        {
            this.obtenerEcivil();
            this.comboBox1.SelectedIndex = 0;
        }

        private void obtenerEcivil()
        {
            this.estados = new GestionBelife().listarEstadoCivil();

            foreach (String[] ecivil in this.estados)
            {
                this.comboBox1.Items.Add(ecivil[1]);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Nuevo)
            {
                //bool result = new GestionBelife().nuevoCliente();
            } else
            {

            }
        }
    }
}
