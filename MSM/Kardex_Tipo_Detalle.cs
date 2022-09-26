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
    public partial class KARDEX_TIPODETALLE : Form
    {
        DBHelper DBHelper = new DBHelper();
        private Point firstPoint;
        public KARDEX_TIPODETALLE()
        {
            InitializeComponent();
        }


        #region TITLE BAR EVENTS

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
          
        }
        private void pnlTitleBar_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void pnlTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
    
        }



        #endregion


       

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void labelDescripcion_Click(object sender, EventArgs e)
        {

        }

        private void labelTipo_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void labelFuncion_Click(object sender, EventArgs e)
        {

        }

        private void TittleBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
