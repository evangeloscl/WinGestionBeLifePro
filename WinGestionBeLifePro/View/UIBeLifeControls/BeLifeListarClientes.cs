using System;
using System.Collections;
using System.Windows.Forms;
using WinGestionBeLifePro.Controller;

namespace WinGestionBeLifePro.View.UIBeLifeControls
{
    public partial class BeLifeListarClientes : UserControl
    {
        private ArrayList clientes;
        private ArrayList estados;
        public BeLifeListarClientes()
        {
            InitializeComponent();
            //this.clientes = new ArrayList();
        }

        private void BeLifeListarClientes_Load(object sender, EventArgs e)
        {
            this.obtenerEcivil();
            this.comboBox1.SelectedIndex = 0;

            //this.mostrarDatos();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.rbtFemenino.Enabled = true;
                this.rbtMasculino.Enabled = true;
            }
            else
            {
                this.rbtFemenino.Enabled = false;
                this.rbtMasculino.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                this.comboBox1.Enabled = true;
            }
            else
            {
                this.comboBox1.Enabled = false;
            }
        }

        private void mostrarDatos()
        {
            //this.clientes.Clear();
            this.dataGridView1.Rows.Clear();

            this.clientes = new GestionBelife().listarClientes();

            foreach (String[] cliente in this.clientes)
            {
                this.dataGridView1.Rows.Add(cliente[0], cliente[1], cliente[2], cliente[3], cliente[4]);
            }
        }

        private void mostrarDatos(int genero)
        {
            this.dataGridView1.Rows.Clear();

            this.clientes = new GestionBelife().listarClientes(genero);

            foreach (String[] cliente in this.clientes)
            {
                this.dataGridView1.Rows.Add(cliente[0], cliente[1], cliente[2], cliente[3], cliente[4]);
            }
        }

        private void mostrarDatos(String ecivil)
        {
            this.dataGridView1.Rows.Clear();

            this.clientes = new GestionBelife().listarClientes(ecivil);

            foreach (String[] cliente in this.clientes)
            {
                this.dataGridView1.Rows.Add(cliente[0], cliente[1], cliente[2], cliente[3], cliente[4]);
            }
        }

        private void mostrarDatos(int genero, String ecivil)
        {
            this.dataGridView1.Rows.Clear();

            this.clientes = new GestionBelife().listarClientes(ecivil, genero);

            foreach (String[] cliente in this.clientes)
            {
                this.dataGridView1.Rows.Add(cliente[0], cliente[1], cliente[2], cliente[3], cliente[4]);
            }
        }

        private void BeLifeListarClientes_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) {
                this.mostrarDatos();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!this.rbtFemenino.Enabled && !this.comboBox1.Enabled)
            {
                this.mostrarDatos();
            } else
            {
                if(!this.comboBox1.Enabled && this.rbtFemenino.Enabled)
                {
                    if (this.rbtFemenino.Checked)
                    {
                        this.mostrarDatos(1);
                    }
                    else
                    {
                        this.mostrarDatos(2);
                    }
                } else
                {
                    if(this.comboBox1.Enabled && !this.rbtFemenino.Enabled)
                    {
                        this.mostrarDatos(this.comboBox1.SelectedItem.ToString());
                    } else
                    {
                        string ecivil = this.comboBox1.SelectedItem.ToString();
                        if (this.rbtFemenino.Checked)
                        {
                            this.mostrarDatos(1, ecivil);
                        }
                        else
                        {
                            this.mostrarDatos(2, ecivil);
                        }
                    }
                }
            }
        }

        private void obtenerEcivil()
        {
            this.estados = new GestionBelife().listarEstadoCivil();

            foreach (String[] ecivil in this.estados)
            {
                this.comboBox1.Items.Add(ecivil[1]);
            }
        }
    }
}
