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
    public partial class Administracion_Actualizacion_Nivel : Form
    {
        DBHelper DBHelper = new DBHelper();
        string certificacionAnterior;
        string codigoAnterior;
        int frecuencia;
        DateTime primeroDelMes;
        DateTime ultimoDelMes;
        int mes, año;
        public Administracion_Actualizacion_Nivel()
        {
            InitializeComponent();
        }

        private void textBoxNumeroEmpleado_TextChanged(object sender, EventArgs e)
        {
            int contadorletras = 0;
            contadorletras = textBoxNumeroEmpleado.Text.Trim().Length;

            if (contadorletras == 8)
            {
                //Obtiene el nombre del usuario y lo guarda en una variable para despues
                //mostrarlo en pantalla
                DBHelper.ObtenerNombreEmpleadoViaNumero(textBoxNumeroEmpleado.Text);
                labelMostrarNombre.Text = Data.NOMBREEMPLEADO;
            }
            if (contadorletras <= 7 || contadorletras > 8)
            {
                labelMostrarNombre.Text = "";
            }
        }

        //private void radioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButtonVencimiento.Checked == true)
        //    {
        //        radioButtonSinVencimiento.Checked = false;
        //        //  dateTimePickerFechaVencimiento.Visible = true;
        //        panelFechas.Visible = true;

        //    }
        //    if (radioButtonSinVencimiento.Checked) 
        //    {
        //        radioButtonVencimiento.Checked = false;
        //        //  dateTimePickerFechaVencimiento.Visible = false;
        //        panelFechas.Visible = false;
        //    }
        //}
        // 
        private void button1_Click(object sender, EventArgs e)
        {
            if (labelMostrarNombre.Text != "" && comboBoxNivelCompetencia.Text != "" && comboBoxCertificacionEntrenamiento.Text != "")
            {
                if (panelFechas.Visible == true)
                {
                    if (labelFechaVencimiento.Text != "--/--/--")
                    {
                        string fechaVencimiento, fechaDeInicio;
                        //string fecha = dateTimePickerFechaVencimiento.Value.ToString("yyyy-MMM-dd");
                        mes = dateTimePickerFechaVencimiento.Value.Month;
                        año = dateTimePickerFechaVencimiento.Value.Year;
                        primeroDelMes = new DateTime(año, mes, 1);
                        ultimoDelMes = primeroDelMes.AddMonths(1).AddDays(-1).AddYears(frecuencia);
                        fechaVencimiento = ultimoDelMes.ToString("MM-dd-yyyy");
                        DateTime fechaInicio = dateTimePickerFechaVencimiento.Value;
                        fechaDeInicio = fechaInicio.ToString("MM-dd-yyyy");
                        
                        string mensaje = DBHelper.ActualizarNivel(comboBoxCodigo.Text, textBoxNumeroEmpleado.Text, fechaVencimiento, comboBoxNivelCompetencia.Text, fechaDeInicio);
                        mensaje = mensaje + labelMostrarNombre.Text;
                        MessageBox.Show(mensaje);

                    }
                }

                if (panelFechas.Visible == false)
                {
                    string mensaje = DBHelper.ActualizarNivel(comboBoxCodigo.Text, textBoxNumeroEmpleado.Text, "", comboBoxNivelCompetencia.Text, "");
                    mensaje = mensaje + labelMostrarNombre.Text;
                    MessageBox.Show(mensaje);

                }
            }
            else
            {
                MessageBox.Show("Llena todos los campos");    
            }
        }

        private void Administracion_Actualizacion_Nivel_Load(object sender, EventArgs e)
        {
            DBHelper.ObtenerCertificacionEntrenamiento(comboBoxCertificacionEntrenamiento, comboBoxCodigo);
        }

        private void comboBoxCertificacionEntrenamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCertificacionEntrenamiento.Text != certificacionAnterior)
            {

                int cantidadCodigos = DBHelper.ObtenerCantidadCodigos(comboBoxCertificacionEntrenamiento.Text);
                if (cantidadCodigos > 1)
                {
                    comboBoxCodigo.Items.Clear();
                    DBHelper.ObtenerCodigosComboBox(comboBoxCodigo, comboBoxCertificacionEntrenamiento.Text);

                }
                else
                {
                    comboBoxCodigo.Items.Clear();
                    DBHelper.ObtenerCodigos(comboBoxCodigo);
                    if (comboBoxCertificacionEntrenamiento.Text != certificacionAnterior)
                    {
                        
                        string codigoIgual = DBHelper.ObtenerCodigoByCertificacionEntrenamiento(comboBoxCertificacionEntrenamiento.Text);
                        comboBoxCodigo.Text = codigoIgual;
                        codigoAnterior = comboBoxCodigo.Text;
                        certificacionAnterior = comboBoxCertificacionEntrenamiento.Text;
                        frecuencia = int.Parse(DBHelper.ObtenerFrecuenciaByCodigo(comboBoxCodigo.Text));
                        if (frecuencia > 0)
                        {
                            panelFechas.Visible = true;
                        }
                        else
                        {
                            panelFechas.Visible = false;
                        }

                    }
                }
            }
        }

        private void comboBoxCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxCodigo.Text != codigoAnterior)
            {
                if (comboBoxCodigo.Text != codigoAnterior)
                {
                    
                    string certificacionEntrenamientoIgual = DBHelper.ObtenerCertificacionEntrenamientoByCodigo(comboBoxCodigo.Text);
                    comboBoxCertificacionEntrenamiento.Text = certificacionEntrenamientoIgual;
                    certificacionAnterior = comboBoxCertificacionEntrenamiento.Text;
                    codigoAnterior = comboBoxCodigo.Text;
                    if (comboBoxCodigo.Text != "")
                    {
                        frecuencia = int.Parse(DBHelper.ObtenerFrecuenciaByCodigo(comboBoxCodigo.Text));

                        if (frecuencia > 0)
                        {
                            panelFechas.Visible = true;
                            if (labelFechaInicio.Text == "--/--/--")
                                mes = dateTimePickerFechaVencimiento.Value.Month;
                            año = dateTimePickerFechaVencimiento.Value.Year;
                            primeroDelMes = new DateTime(año, mes, 1);
                            ultimoDelMes = primeroDelMes.AddMonths(1).AddDays(-1).AddYears(frecuencia);
                            labelFechaVencimiento.Text = ultimoDelMes.ToString("MMM-dd-yyyy");
                            DateTime fechaInicio = dateTimePickerFechaVencimiento.Value;
                            labelFechaInicio.Text = fechaInicio.ToString("MMM-dd-yyyy");
                        }
                        else
                        {
                            panelFechas.Visible = false;
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Seleccione un codigo");
                    }
                }
            }
        }

        private void Administracion_Actualizacion_Nivel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Administracion PantallaAdministracion = new Administracion();
            PantallaAdministracion.Show();
            this.Hide();
        }

        private void dateTimePickerFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {
            mes = dateTimePickerFechaVencimiento.Value.Month;
            año = dateTimePickerFechaVencimiento.Value.Year;
            primeroDelMes = new DateTime(año, mes, 1);
            ultimoDelMes = primeroDelMes.AddMonths(1).AddDays(-1).AddYears(frecuencia);
            labelFechaVencimiento.Text = ultimoDelMes.ToString("MMM-dd-yyyy");
            DateTime fechaInicio = dateTimePickerFechaVencimiento.Value;
            labelFechaInicio.Text = fechaInicio.ToString("MMM-dd-yyyy");
            //labelFechaInicio.Text = dateTimePickerFechaVencimiento.Text;
        }
    }
}
