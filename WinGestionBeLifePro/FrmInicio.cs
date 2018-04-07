using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinGestionBeLifePro
{
    public partial class FrmInicio : Form
    {
        private int MenuWidth;
        private bool HiddenMenu;

        public FrmInicio()
        {
            InitializeComponent();
            this.MenuWidth = this.PanelMenu.Width;
            this.PanelMenu.Width = 0;
            this.HiddenMenu = true;
            this.menuStrip1.Renderer = new MyRenderer();
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected) base.OnRenderMenuItemBackground(e);
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(Brushes.Gray, rc);
                    e.Graphics.DrawRectangle(Pens.Gray, 1, 0, rc.Width - 2, rc.Height - 1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = new UIDialog.FrmMBox("Cerrando aplicación","¿Realmente desea salir de la aplicación?").ShowDialog();
            if(result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void timerSlide_Tick(object sender, EventArgs e)
        {
            if (this.HiddenMenu)
            {
                this.PanelMenu.Width = this.PanelMenu.Width + 50;
                if (this.PanelMenu.Width >= this.MenuWidth)
                {
                    this.timerSlide.Stop();
                    this.HiddenMenu = false;
                    this.Refresh();
                }
            }
            else
            {
                this.PanelMenu.Width = this.PanelMenu.Width - 50;
                if (this.PanelMenu.Width <= 0)
                {
                    this.timerSlide.Stop();
                    this.HiddenMenu = true;
                    this.Refresh();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.timerSlide.Start();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            new UIDialog.FrmIBox("Acerca de la aplicación BeLife","Desarrolladores: \n Evángelos Dimitrópulos Flores \n Diengo Heríquez Pinochet").ShowDialog();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.beLifeFromUsuarioNuevo.BringToFront();
            if(this.beLifeListarClientes1.Visible)
            {
                this.beLifeListarClientes1.Visible = false;
            }
        }

        private void listarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.beLifeListarClientes1.BringToFront();
            if(!this.beLifeListarClientes1.Visible)
            {
                this.beLifeListarClientes1.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.beLifeBuscar1.BringToFront();
        }
    }
}
