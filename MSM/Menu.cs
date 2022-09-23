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
    public partial class Menu : Form
    {

        private bool mouseIsDown = false;
        private Point firstPoint;
        public Menu()
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
            if (mouseIsDown)
            {
                // Get the difference between the two points
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }
        private void pnlTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }



        #endregion


        private void Menu_Load(object sender, EventArgs e)
        {
            if(Data.ESADMINISTRADOR == true)
            {
                buttonAdministrador.Visible = true;
                
                
            }
            if(Data.ESSUPERVISOR == true)
            {
                buttonAdministrador.Visible = true;
              
            }
        }

        //PELICANO 
        private void buttonAdministrador_Click(object sender, EventArgs e)
        {
            Administracion PantallaAdministracion = new Administracion();
            PantallaAdministracion.Show();
            this.Hide();
        }

        private void buttonMultiSkills_Click(object sender, EventArgs e)
        {
            MSM_Area PantallaMsm = new MSM_Area();
            PantallaMsm.Show();
            this.Hide();
        }

        private void buttonKardex_Click(object sender, EventArgs e)
        {
            Empleado_Kardex PantallaKardex = new Empleado_Kardex();
            PantallaKardex.Show();
            this.Hide();
        }

        private void buttonReportePorVencer_Click(object sender, EventArgs e)
        {
            Reporte_Por_Vencer PantallaReporte = new Reporte_Por_Vencer();
            PantallaReporte.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Login Pantalla1 = new Login();

            Pantalla1.Show();
            this.Close();
            this.Hide();

        }
    }
}
