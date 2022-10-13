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
    public partial class Administracion_Actualizar_Vencidos : Form
    {
        DBHelper DBHelper = new DBHelper();
        public Administracion_Actualizar_Vencidos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBHelper.ActualizarVencidos();
        }
    }
}
