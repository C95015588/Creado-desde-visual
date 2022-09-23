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
    public partial class Administracion_Certificacion_Entrenamiento_Areas : Form
    {
        DBHelper DBHelper = new DBHelper();
        public Administracion_Certificacion_Entrenamiento_Areas()
        {
            InitializeComponent();
        }

        private void Administracion_Certificacion_Entrenamiento_Areas_Load(object sender, EventArgs e)
        {
            DBHelper.ObtenerAreasEnCheckedListBox(checkedListBoxAreas);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBoxAreas.CheckedItems.Count != 0)
            {
               
                for (int x = 0; x < checkedListBoxAreas.CheckedItems.Count; x++)
                {
                    string area = checkedListBoxAreas.CheckedItems[x].ToString();
                    DBHelper.InsertCertificacionEntrenamientoEnArea(area);
                }
              
                this.Close();
            }
            else
            {
                this.Close();
            }

        }
    }
}
