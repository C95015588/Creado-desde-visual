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
    public partial class Administracion_actualizar_nivel : Form
    {
        string AntesCertification = "";
        public Administracion_actualizar_nivel()
        {
            InitializeComponent();
        }

        private void textBoxNumeroEmpleado_TextChanged(object sender, EventArgs e)
        {
            DBHelper DBHelper = new DBHelper();
            //Variable para contar los caracteres ingresaras en el textbox
            int contadorcaracteres = 0;
            contadorcaracteres = textBoxNumeroEmpleado.Text.Trim().Length;



            if (contadorcaracteres > 7)
            {
                //Obtiene el nombre del usuario y lo guarda en una variable para despues
                //mostrarlo en pantalla
                DBHelper.ObtenerNombreEmpleadoViaNumero(textBoxNumeroEmpleado.Text);
                labelNombreEmpleado.Text = Data.NOMBREEMPLEADO;

            }

            if (contadorcaracteres <= 7)
            {
                labelNombreEmpleado.Text = "Escribe el numero de empleado";
            }
        }

        //private void Administracion_actualizar_nivel_Load(object sender, EventArgs e)
        //{
        //    DBHelper DBHelper = new DBHelper();
        //    DBHelper.ObtenerCertificacionEntrenamiento(comboBoxCertificacion, comboBoxcodigo);
        //}

        //private void comboBoxCertificacion_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(comboBoxCertificacion.Text != AntesCertification)
        //    {
        //        string equalCode;

        //    }
        //}

        private void radioButtonEntrenamiento_CheckedChanged(object sender, EventArgs e)
        {

            Data.ESENTRENAMIENTO = true;

            
        }

        private void radioButtonCertificacion_CheckedChanged(object sender, EventArgs e)
        {

            Data.ESCERTIFICACION = true;
        }

        public void LlenarCombobox(object sender, EventArgs e)
        {
            DBHelper DBHelper = new DBHelper();


            if(Data.ESENTRENAMIENTO == true)
            {
                DBHelper.ObtenerEntrenamientos(comboBoxCertificacionEntrenamiento);
            }
            if(Data.ESCERTIFICACION == true)
            {
                DBHelper.ObtenerCertificacion(comboBoxCertificacionEntrenamiento);
            }
        }
    }
}

