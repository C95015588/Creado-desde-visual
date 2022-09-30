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
    public partial class MSM_Area : Form
    {
        DBHelper DBHelper = new DBHelper();

        private bool mouseIsDown = false;
        private Point firstPoint;
        public MSM_Area()
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

        public void diseñoMSM()
        {
            dataGridViewMultiskill.AutoResizeColumns();

            dataGridViewMultiskill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            string certificacionEntrenamiento, fechaNivelCompetencia, fechaVencimiento, proceso;
            string[] informacionCertificacion, certificacionEntrenamientoNombre;
            string[] procesos;

            procesos = DBHelper.ObtenerProcesos(comboBoxArea.Text).ToArray();
            int rojo = 0, verde = 65, azul = 50;

            char separador = '|';
            char delimitador = '[';


            int[] colorProcesosRojo = new int[procesos.Length];
            int[] colorProcesosAzul = new int[procesos.Length];
            int[] colorProcesosVerde = new int[procesos.Length];
            string duracion;
            double duracionDias;
            for (int o = 0; o <= procesos.Length - 1; o++)
            {
                colorProcesosRojo[o] = rojo;
                colorProcesosAzul[o] = azul;
                colorProcesosVerde[o] = verde;
                rojo = rojo + 5;
                azul = azul + 15;
                verde = verde + 10;
                if (rojo >= 255 || azul >= 255 || verde >= 255)
                {
                    rojo = 50;
                    azul = 20;
                    verde = 10;
                }
            }

                 float employeesCount = (dataGridViewMultiskill.RowCount / 50) + 1;
            for (int i = 2; dataGridViewMultiskill.ColumnCount > i; i++)
            {
              
                    certificacionEntrenamiento = dataGridViewMultiskill.Columns[i].HeaderText;
                    certificacionEntrenamientoNombre = certificacionEntrenamiento.Split(separador);
                    duracion = DBHelper.ObtenerDuracionCertificacionEntrenamiento(certificacionEntrenamientoNombre[0]);
                //try
                //{
                if(duracion != "")
                {
                    duracionDias = double.Parse(duracion);
                }
                else
                {
                    duracionDias = 0;
                }
                //}
                //catch
                //{
                    //MessageBox.Show("duracion: " + duracion + " no pudo ser transformada a 
                //}

                for (int x = 0; dataGridViewMultiskill.RowCount > x; x++)
                    {

                        //if (dataGridViewMultiskill.Rows[x].Cells[i].Value != null)
                        //{
                        //    if (dataGridViewMultiskill.Rows[x].Cells[i].Value.ToString() == String.Empty)
                        //        dataGridViewMultiskill.Rows[x].Cells[i].Value = 0;
                        //}
                        //try
                        //{
                            // char delimitador = '[';

                            if (dataGridViewMultiskill.Rows[x].Cells[i].Value != null)
                            {
                                fechaNivelCompetencia = dataGridViewMultiskill.Rows[x].Cells[i].Value.ToString();
                                informacionCertificacion = fechaNivelCompetencia.Split(delimitador);
                        try
                        {
                                fechaVencimiento = informacionCertificacion[1];
                        }
                        catch
                        {
                            continue;
                        }
                                if (informacionCertificacion[1] != "")
                                {

                                    fechaVencimiento = fechaVencimiento.Remove(fechaVencimiento.Length - 1);
                                    var fechaVigencia = DateTime.Parse(fechaVencimiento);
                                    fechaVigencia = fechaVigencia.AddDays(-duracionDias);
                                    if (fechaVigencia <= DateTime.Today)
                                    {
                                        
                                        dataGridViewMultiskill.Rows[x].Cells[i].Style.BackColor = Color.Red;
                                        

                                    }
                                }
                            }
                    



                        metroProgressBarCarga.Value += (int)Math.Round(employeesCount);

                    }   
                //}
                //catch
                //{

                //}

                certificacionEntrenamientoNombre[1] = certificacionEntrenamientoNombre[1].Remove(0, 2);
                proceso = DBHelper.ObtenerProcesoByCodigo(comboBoxArea.Text, certificacionEntrenamientoNombre[1]);

                for (int x = 0; x <= procesos.Length - 1; x++)
                {
                    if (procesos[x] == proceso)
                    {
                        dataGridViewMultiskill.Columns[i].HeaderCell.Style.BackColor = Color.FromArgb(colorProcesosRojo[x], colorProcesosAzul[x], colorProcesosVerde[x]);
                        break;
                    }
                }
                //dataGridViewMultiskill.Columns[i].DefaultCellStyle = norStyle;  //Metodo para que aparezcan las meatballs
            }

        }

        private void MSM_Area_Load(object sender, EventArgs e)
        {
            DBHelper.ObtenerAreasEnComboBox(comboBoxArea);
            Cambio_Area funcionCambioArea = new Cambio_Area();
            funcionCambioArea.TopLevel = false;
           panelCambioArea.Controls.Add(funcionCambioArea);
            funcionCambioArea.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewMultiskill.Visible = true;
            labelcargando.Text = "Cargando / Loading ";
            labelcargando.Visible = true;
            
            metroProgressBarCarga.Visible = true;
            metroProgressBarCarga.Value = 10;

            DBHelper.MostrarTablaMultiSkill(dataGridViewMultiskill, comboBoxArea.Text);
            //System.Windows.Forms.DataGridViewCellStyle norStyle = new System.Windows.Forms.DataGridViewCellStyle();
            //norStyle.Font = new System.Drawing.Font("Lean Status Symbols", 14.0F, System.Drawing.FontStyle.Regular);

            metroProgressBarCarga.Value = 50;
            
          
            diseñoMSM();
            
            
            buttonNivel.Visible = true;
            
            labelcargando.Text = "Carga finalizada / Upload finished";
            Data.TEMPAREA = comboBoxArea.Text;
            metroProgressBarCarga.Visible = false;
            dataGridViewMultiskill.Columns[1].Frozen = true; 


        }

        private void dataGridViewMultiskill_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //REVISAR SI ES NECESARIO POR EL CLICK DERECHO
            char delimitador = '-';

            var certificacionSeleccionada = dataGridViewMultiskill.CurrentRow;
            try
            {
                string certificacion = dataGridViewMultiskill.Columns[e.ColumnIndex].HeaderText;
                string[] informacionCertificacion = certificacion.Split(delimitador);
                Data.CODIGO = informacionCertificacion[2];
                KARDEX_TIPODETALLE openForm = new KARDEX_TIPODETALLE();
                openForm.Show();
            }
            catch
            {

            }
        }

        private void dataGridViewMultiskill_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            diseñoMSM();

            if (e.Button == MouseButtons.Right)
            {
                char delimitador = '-';

                var certificacionSeleccionada = dataGridViewMultiskill.CurrentRow;
                try
                {
                    string certificacion = dataGridViewMultiskill.Columns[e.ColumnIndex].HeaderText;
                    string[] informacionCertificacion = certificacion.Split(delimitador);
                    Data.CODIGO = informacionCertificacion[2];
                    KARDEX_TIPODETALLE openForm = new KARDEX_TIPODETALLE();
                    openForm.Show();
                }
                catch
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu Pantalla2 = new Menu();

            Pantalla2.Show();
            this.Close();
            this.Hide();
        }

        private void TittleBar_MouseMove(object sender, MouseEventArgs e)
        {

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

        private void pictureBoxExcel_Click(object sender, EventArgs e)
        {
            labelcargando.Text = "Cargando / Loading ";
            metroProgressBarCarga.Visible = true;
            metroProgressBarCarga.Value = 10;
            string mensaje = "La información descargada es solo para fines de consulta y puede variar, para información oficial consultar la publicada en MSM/Training app                                                                        " +
                "                                                                                                         " +
                "The downloaded information is only for consultation purposes and may vary, for official information consult the published in MSM/Training app ";
              

            MessageBox.Show( mensaje , "Advertencia / Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //^Mensaje que avisa que la informacion exportada a excell no es oficial 



            metroProgressBarCarga.Value = 20;
            metroProgressBarCarga.Value = 30;
            metroProgressBarCarga.Value = 40;
            exportarexcel(dataGridViewMultiskill);
            metroProgressBarCarga.Value = 100;


            labelcargando.Text = "Carga finalizada / Upload finished";

        }
        private void buttonNivel_Click_1(object sender, EventArgs e)
        {

            meatballs_Detalle PantallaMeatballs = new meatballs_Detalle();
            PantallaMeatballs.Show();
        }

        private void panelCambioArea_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
        }

    }
    }

    