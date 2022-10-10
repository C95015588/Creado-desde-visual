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
    public partial class Empleado_Kardex : Form

    {            DBHelper DBHelper = new DBHelper();
                 private bool mouseIsDown = false;
                 private Point firstPoint;

        public Empleado_Kardex()
        {
            InitializeComponent();
            dataGridViewCertificacionesEmpleado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      

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
        private void buttonOkIngresarElNumeroEmpleado_Click(object sender, EventArgs e) //Metodo que le da accion al boton buscar
        {

            panelexcell.Visible = true; 
         
            DBHelper.ObtenerNombreEmpleadoViaNumero(textBoxNumeroEmpleado.Text);

            dataGridViewCertificacionesEmpleado.DataSource = null;
            dataGridViewEntrenamientosNoObtenidos.DataSource = null;
            comboBoxAreaEmpleado.SelectedIndex = -1;


            DBHelper.ObtenerKardex(textBoxNumeroEmpleado.Text, dataGridViewCertificacionesEmpleado);
            
            System.Windows.Forms.DataGridViewCellStyle norStyle = new System.Windows.Forms.DataGridViewCellStyle();
            norStyle.Font = new System.Drawing.Font("Lean Status Symbols", 8.25F, System.Drawing.FontStyle.Regular);
            dataGridViewCertificacionesEmpleado.Columns[4].DefaultCellStyle = norStyle;  //Metodo para que aparezcan las meatballs

            labelcargando.Visible = false;
            metroProgressBarCarga.Visible = false;
            comboBoxBusinessUnit.Visible = true;
            labelBannerBusines.Visible = true;
            dataGridViewCertificacionesEmpleado.Visible = true;
            buttonBorrarFiltro.Visible = false;
            labelKarde.Visible = true;
            labelKardexIngles.Visible = true;
            buttonTipoDetalle.Visible = true;
            buttonNivel.Visible = true;
            labelBusinesIngles.Visible = true;
         
           

            comboBoxBusinessUnit.Items.Clear();

            DBHelper.ObtenerBussinesUnitEnComboBox(comboBoxBusinessUnit);


            //DBHelper.ObtenerAreasEnComboBox(comboBoxAreaEmpleado);
            







            if (Data.NOMBREEMPLEADO.Equals("Número de empleado incorrecto / Wrong employee number"))
            {

                comboBoxAreaEmpleado.Visible = false;
                labelBannerFiltrarEntrenamientos.Visible = false;
                dataGridViewCertificacionesEmpleado.Visible = false;


                MessageBox.Show("Numero de empleado incorrecto" + "\nWrong employee number"+ MessageBoxButtons.OK+ MessageBoxIcon.Error);
                this.Show();
             

            }
            //dataGridViewCertificacionesEmpleado.Columns[0].DefaultCellStyle.BackColor = Color.Cyan;


           

        }


        private void textBoxNumeroEmpleado_TextChanged(object sender, EventArgs e) //Metodo que aparece el nombre de empleado
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
                labelNombreEmpleado.Text = "Escribe el número de empleado / Write the employee number";
            }
        }
        private void comboBoxAreaEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBHelper.FiltraKardexPorArea(textBoxNumeroEmpleado.Text, comboBoxAreaEmpleado.Text, dataGridViewCertificacionesEmpleado);
            DBHelper.FiltraEntrenamientosNoObtenidos(textBoxNumeroEmpleado.Text, comboBoxAreaEmpleado.Text, dataGridViewEntrenamientosNoObtenidos);

            String nombreArea = comboBoxAreaEmpleado.Text;
       

            labelArea.Text = nombreArea;
            labelBannerInglesArea.Text = nombreArea;

            labelEntrenamientosNoObtenidos.Visible = true;
            labelEntrenamientosNoObtenidosIngles.Visible = true;
            dataGridViewEntrenamientosNoObtenidos.Visible = true;
            labelArea.Visible = true;
            labelEntrenamientosNoObtenidos.Visible = true;
            labelAreaIngles.Visible = true;
            buttonBorrarFiltro.Visible = true;



            
        }

      

        private void buttonBorrarFiltro_Click(object sender, EventArgs e) //Metodo desaparece el filtro 
        {
            comboBoxAreaEmpleado.SelectedIndex = -1;


            DBHelper.ObtenerKardex(textBoxNumeroEmpleado.Text, dataGridViewCertificacionesEmpleado);

            System.Windows.Forms.DataGridViewCellStyle norStyle = new System.Windows.Forms.DataGridViewCellStyle();
            norStyle.Font = new System.Drawing.Font("Lean Status Symbols", 8.25F, System.Drawing.FontStyle.Regular);
            dataGridViewCertificacionesEmpleado.Columns[4].DefaultCellStyle = norStyle;  //Metodo para que aparezcan las meatballs

            comboBoxAreaEmpleado.Visible = true;
            labelBannerFiltrarEntrenamientos.Visible = true;
            dataGridViewCertificacionesEmpleado.Visible = true;

            labelEntrenamientosNoObtenidos.Visible = false;
            labelEntrenamientosNoObtenidosIngles.Visible = false;
            dataGridViewEntrenamientosNoObtenidos.Visible = false;
            labelArea.Visible = false;
            labelEntrenamientosNoObtenidos.Visible = false;
            labelAreaIngles.Visible = false;
            buttonBorrarFiltro.Visible = false;



        }

        private void comboBoxBusinessUnit_SelectedIndexChanged(object sender, EventArgs e) //Metodo de combobox bussinessunit, hace el filtro de areas
        {
            comboBoxAreaEmpleado.SelectedIndex = -1;
            comboBoxAreaEmpleado.Items.Clear();
    

            DBHelper.FiltrarAreaBussinesUnit(comboBoxAreaEmpleado, comboBoxBusinessUnit.Text);

            labelBannerFiltrarEntrenamientos.Visible = true;
            comboBoxAreaEmpleado.Visible = true;
            labelAreaIngles.Visible = true; 
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


        public void exportarexcel(DataGridView datatabla) //Metodo para exportar los datos de data griedview a excell
        {
          Microsoft.Office.Interop.Excel.Application exportarexcel = new Microsoft.Office.Interop.Excel.Application();

            exportarexcel.Application.Workbooks.Add(true);

            int indicecolumna = 0;

            foreach (DataGridViewColumn columna in datatabla.Columns)
            {
                indicecolumna++;

                exportarexcel.Cells[1, indicecolumna] = columna.Name;

            }
            int indicefila = 0;

            foreach (DataGridViewRow fila in datatabla.Rows)
            {
                indicefila++;
                indicecolumna = 0;

                foreach (DataGridViewColumn columna in datatabla.Columns)
                {
                    indicecolumna++;
                    exportarexcel.Cells[indicefila + 1, indicecolumna] = fila.Cells[columna.Name].Value;
                }




            }
            exportarexcel.Visible = true;
        }


        public void exportarexcel2(DataGridView datatabla) //Metodo para exportar los datos de segundo data griedview a excell
        {
            Microsoft.Office.Interop.Excel.Application exportarexcel2 = new Microsoft.Office.Interop.Excel.Application();

            exportarexcel2.Application.Workbooks.Add(true);

            int indicecolumna = 0;

            foreach (DataGridViewColumn columna in datatabla.Columns)
            {
                indicecolumna++;

                exportarexcel2.Cells[1, indicecolumna] = columna.Name;

            }
            int indicefila = 0;

            foreach (DataGridViewRow fila in datatabla.Rows)
            {
                indicefila++;
                indicecolumna = 0;

                foreach (DataGridViewColumn columna in datatabla.Columns)
                {
                    indicecolumna++;
                    exportarexcel2.Cells[indicefila + 1, indicecolumna] = fila.Cells[columna.Name].Value;
                }




            }
            exportarexcel2.Visible = true;
        }


        private void buttonExportar_Click(object sender, EventArgs e) // Metodo para anadirle accion al logo de excell 
        {


            string mensaje = "La información descargada es solo para fines de consulta y puede variar, para información oficial consultar la publicada en MSM/Training app" 
             +"\nThe downloaded information is only for consultation purposes and may vary, for official information consult the published in MSM/Training app ";


            DialogResult resultado = MessageBox.Show(mensaje, "Advertencia / Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.OK)
            {
                labelcargando.Text = "Cargando / Loading ";
                labelcargando.Visible = true;
                metroProgressBarCarga.Visible = true;
                metroProgressBarCarga.Value = 10;
                metroProgressBarCarga.Value = 20;
                metroProgressBarCarga.Value = 30;
                metroProgressBarCarga.Value = 40;
                exportarexcel(dataGridViewCertificacionesEmpleado);
                exportarexcel2(dataGridViewEntrenamientosNoObtenidos);
                metroProgressBarCarga.Value = 100;


                labelcargando.Text = "Carga finalizada / Upload finished";
            }
            else

            if (resultado == DialogResult.Cancel)
            {

            }

                                                                            


        }

     

       
        private void button1_Click(object sender, EventArgs e) //Metodo para mostrar pantalla tipo detalle
        {
            KARDEX_TIPODETALLE PantallaTipo = new KARDEX_TIPODETALLE();
            PantallaTipo.Show();
            
        }
        private void buttonNivel_Click_1(object sender, EventArgs e)
        {

            meatballs_Detalle PantallaMeatballs = new meatballs_Detalle();
            PantallaMeatballs.Show();
        }

        private void button3_Click(object sender, EventArgs e) //Metodo y boton para poner la pantalla mazimizada o minimizada
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;

            }
            else
            {
                this.WindowState = FormWindowState.Maximized;

            }
        }
    } 
    }
    
    

    

