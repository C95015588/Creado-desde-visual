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
    public partial class meatballs_Detalle : Form
    {
        DBHelper DBHelper = new DBHelper();
        private Point firstPoint;
        public meatballs_Detalle()
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
    }
}
