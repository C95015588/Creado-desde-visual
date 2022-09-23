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
    public partial class Administracion_Certificacion_Entrenamiento : Form
    {
        DBHelper DBHelper = new DBHelper();
        //Variable que almacena el nombre de la certificacion o entrenamiento que esta seleccionada
        string nombreAnterior = "";
        //Variable que almacena el codigo de la certificacion o entrenamiento que esta seleccionada
        string codigoAnterior = "";
        //Variable que almacena el nombre de la certificacion o entrenamiento que esta seleccionada
        string nombreAnterior1 = "";
        //Variable que almacena el codigo de la certificacion o entrenamiento que esta seleccionada
        string codigoAnterior1 = "";
        public Administracion_Certificacion_Entrenamiento()
        {
            InitializeComponent();
        }

        private void Administracion_Certificacion_Entrenamiento_Load(object sender, EventArgs e)
        {
            DBHelper.ObtenerCertificacionEntrenamiento(comboBoxNombre, comboBoxCodigo);
            DBHelper.ObtenerCertificacionEntrenamiento(comboBoxNombre1, comboBoxCodigo1);
            DBHelper.ObtenerTipo(comboBoxTipo);
            DBHelper.ObtenerFuncion(comboBoxFuncion);
            DBHelper.ObtenerAgente(comboBoxAgente);

        }

        private void comboBoxNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNombre.Text != nombreAnterior)
            {

                comboBoxCodigo.Text = DBHelper.ObtenerCodigoByCertificacionEntrenamiento(comboBoxNombre.Text);
                codigoAnterior = comboBoxCodigo.Text;
            }
        }

        private void comboBoxCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCodigo.Text != codigoAnterior)
            {
                comboBoxNombre.Text = DBHelper.ObtenerCertificacionEntrenamientoByCodigo(comboBoxCodigo.Text);
                nombreAnterior = comboBoxNombre.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxNombre.Text != "" && comboBoxCodigo.Text != "" && textBoxNuevoCodigo.Text != "")
            {
                DBHelper.CambiarCodigo(comboBoxCodigo.Text, textBoxNuevoCodigo.Text.ToUpper());
                string mensaje = DBHelper.RegistrarCambioCodigo(comboBoxCodigo.Text, textBoxNuevoCodigo.Text.ToUpper(), comboBoxNombre.Text);
                MessageBox.Show(mensaje);
                DBHelper.ObtenerCertificacionEntrenamiento(comboBoxNombre, comboBoxCodigo);
                DBHelper.ObtenerCertificacionEntrenamiento(comboBoxNombre1, comboBoxCodigo1);
            }
            else
                MessageBox.Show("Llena los campos correctamente");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxNombre.Text != "" &&
                textBoxCodigo.Text != "" &&
                comboBoxTipo.Text != "" &&
                textBoxFrecuencia.Text != "" &&
                comboBoxAgente.Text != "" &&
                comboBoxFuncion.Text != "" &&
                textBoxDuracion.Text != "")
            {
                Administracion_Certificacion_Entrenamiento_Areas PantallaAdministracion_Certificacion_Entrenamiento_Areas = new Administracion_Certificacion_Entrenamiento_Areas();
                PantallaAdministracion_Certificacion_Entrenamiento_Areas.Show();
                Data.TEMPCODIGO = textBoxCodigo.Text.ToUpper();
                DBHelper.InsertCertificacionesEntrenamientos(textBoxNombre.Text.ToUpper(), textBoxCodigo.Text.ToUpper(), comboBoxTipo.Text,
                                             textBoxFrecuencia.Text, comboBoxAgente.Text, comboBoxFuncion.Text, textBoxDuracion.Text);
                DBHelper.ObtenerCertificacionEntrenamiento(comboBoxNombre, comboBoxCodigo);
                DBHelper.ObtenerCertificacionEntrenamiento(comboBoxNombre1, comboBoxCodigo1);
            }
            else
                MessageBox.Show("Llena los campos correctamente");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBoxNombre1.Text != "" && comboBoxCodigo1.Text != "")
            {
                comboBoxNombre1.Text = DBHelper.ObtenerCertificacionEntrenamientoByCodigo(comboBoxCodigo1.Text);
            }
            else
                MessageBox.Show("Llena los campos correctamente");
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxNombre1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNombre1.Text != nombreAnterior1)
            {

                comboBoxCodigo1.Text = DBHelper.ObtenerCodigoByCertificacionEntrenamiento(comboBoxNombre1.Text);
                codigoAnterior1 = comboBoxCodigo1.Text;
                string activo = DBHelper.ObtenerActivoByCodigo(comboBoxCodigo1.Text);
                labelActivo.Text = activo;
                if (activo == "Activo")
                {
                    button3.Text = "Desactivar";

                }
                if (activo == "Desactivado")
                {
                    button3.Text = "Activar";

                }

            }

        }

        private void comboBoxCodigo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCodigo1.Text != codigoAnterior1)
            {
                comboBoxNombre1.Text = DBHelper.ObtenerCertificacionEntrenamientoByCodigo(comboBoxCodigo1.Text);
                nombreAnterior1 = comboBoxNombre1.Text;
                string activo = DBHelper.ObtenerActivoByCodigo(comboBoxCodigo1.Text);
                labelActivo.Text = activo;
                if (labelActivo.Text == "Activo")
                {
                    button3.Text = "Desactivar";

                }
                if (labelActivo.Text == "Desactivado")
                {
                    button3.Text = "Activado";

                }

            }
        }


        private void radioButtonCambioMarcado(object sender, EventArgs e)
        {
            if (radioButtonCodigo.Checked == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                comboBoxCodigo.Text = "";
                comboBoxNombre.Text = "";
                textBoxNuevoCodigo.Text = "";

            }
            if (radioButtonNuevaCertificacionEntrenamiento.Checked == true)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;
                textBoxNombre.Text = "";
                textBoxCodigo.Text = "";
                comboBoxTipo.Text = "";
                textBoxFrecuencia.Text = "";
                comboBoxAgente.Text = "";
                comboBoxFuncion.Text = "";
                textBoxDuracion.Text = "";
               
            }
            if (radioButtonActivo.Checked == true)
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
                comboBoxCodigo1.Text = "";
                comboBoxNombre1.Text = "";
                labelActivo.Text = "";
            }
        }
    }
}
