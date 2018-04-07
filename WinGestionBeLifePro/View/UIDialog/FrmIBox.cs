using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinGestionBeLifePro.UIDialog
{
    public partial class FrmIBox : Form
    {
        public FrmIBox(String titulo, String mensaje)
        {
            InitializeComponent();
            this.lbTitulo.Text = titulo;
            this.lbMensaje.Text = mensaje;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
