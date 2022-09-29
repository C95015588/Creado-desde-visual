﻿using System;
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
    public partial class Cambio_Area : Form
    {
        DBHelper DBHelper = new DBHelper();
        public Cambio_Area()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (labelMostrarNombre.Text != "")
            {


                string existencia = DBHelper.ComprobarPerteneceArea(textBoxNumeroEmpleado.Text);
                if (existencia == "")
                {
                    string mensaje = DBHelper.InsertarEmpleadoEnArea(textBoxNumeroEmpleado.Text, Data.TEMPAREA);
                    mensaje = mensaje + labelMostrarNombre + " agregado a el area " + Data.TEMPAREA;
                    MessageBox.Show(mensaje);
                }
                else
                {
                    MessageBox.Show("El empleado ya pertenece a esta area");
                }
            }
            else
            {
                MessageBox.Show("El numero de empleado es incorrecto");
            }
        }

        private void textBoxNumeroEmpleado_TextChanged(object sender, EventArgs e)
        {
            //variable que hace determina los numeros de caracteres que tiene que tener empleado
            //Para hacer busqueda de su nombre en la base de datos
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

        private void Cambio_Area_Load(object sender, EventArgs e)
        {

        }
    }
}
