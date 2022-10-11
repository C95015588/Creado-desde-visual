using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSM
{
    public partial class Administracion : Form
    {

        private bool mouseIsDown = false;
        private Point firstPoint;
        public Administracion()
        {
            InitializeComponent();
        }

        #region TITLE BAR EVENTS

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            mouseIsDown = true;
        }
        private void pnlTitleBar_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void pnlTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }



        #endregion


        private void buttonEditarCertificacionesOEntrenamientos_Click(object sender, EventArgs e)
        {

        }

        private void buttonMultiSkills_Click(object sender, EventArgs e)
        {

        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            Menu Pantalla2 = new Menu();

            Pantalla2.Show();
            this.Close();
            this.Hide();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonFechasDeCertificacionesYEntrenaminetos_Click(object sender, EventArgs e)
        {
            
                Administracion_Actualizacion_Nivel abrirPantalla = new Administracion_Actualizacion_Nivel();
                abrirPantalla.Show();
                this.Hide();
            }

        private void buttonReportePorVencer_Click(object sender, EventArgs e)
        {
            Administracion_Certificacion_Entrenamiento PantallaAdministracion = new Administracion_Certificacion_Entrenamiento();
            PantallaAdministracion.Show();
            this.Hide();

        }
    }
}
