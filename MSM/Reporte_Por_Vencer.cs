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
    public partial class Reporte_Por_Vencer : Form
    {
        DBHelper DBHelper = new DBHelper();
        
        private bool mouseIsDown = false;
        private Point firstPoint;
        public Reporte_Por_Vencer()
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


        private void Reporte_Por_Vencer_Load(object sender, EventArgs e)
        {
            DBHelper.ObtenerAreasEnComboBox(comboBoxArea);
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            labelcargando.Visible = true;
            labelcargando.Text = "Cargando / Loading ";
            metroProgressBarCarga.Visible = true;
            metroProgressBarCarga.Value = 20;

            dataGridViewReporte.Columns.Clear();
            DBHelper.MostrarReportePorVencer(dataGridViewReporte, comboBoxArea.Text);
            DateTime hoy = DateTime.Today;
            int mesActual = hoy.Month;
            int añoActual = hoy.Year;
            DateTime primeroDeMesActual = new DateTime(añoActual, mesActual, 01);
            DateTime mesUno = primeroDeMesActual;
            mesUno = mesUno.AddMonths(1).AddDays(-1);
            DateTime mesDos = primeroDeMesActual.AddMonths(2).AddDays(-1);
            DateTime mesTres = primeroDeMesActual.AddMonths(3).AddDays(-1);
            DateTime mesCuatro = primeroDeMesActual.AddMonths(4).AddDays(-1);
            string primerMesPalabra = mesUno.ToString("MMM-dd-yyyy");
            string segundoMesPalabra = mesDos.ToString("MMM-dd-yyyy");
            string tercerMesPalabra = mesTres.ToString("MMM-dd-yyyy");
            string cuartoMesPalabra = mesCuatro.ToString("MMM-dd-yyyy");
            metroProgressBarCarga.Value = 50;

            dataGridViewReporte.Columns.Add(primerMesPalabra, primerMesPalabra);
            dataGridViewReporte.Columns.Add(segundoMesPalabra, segundoMesPalabra);
            dataGridViewReporte.Columns.Add(tercerMesPalabra, tercerMesPalabra);
            dataGridViewReporte.Columns.Add(cuartoMesPalabra, cuartoMesPalabra);
            string nombreCertificacionEntrenamiento;
            string fechaAVencer;
            string duracion;
            string mesProyectado;
            DateTime fechaVigencia;
            DateTime fechaProyectada;
            DateTime fechaVigenciaAnticipada;

            metroProgressBarCarga.Value = 70;
            int duracionDias;
            for (int x = 0; dataGridViewReporte.RowCount - 1 > x; x++)
            {
                nombreCertificacionEntrenamiento = dataGridViewReporte.Rows[x].Cells[3].Value.ToString();
                fechaAVencer = dataGridViewReporte.Rows[x].Cells[4].Value.ToString();
                duracion = DBHelper.ObtenerDuracionCertificacionEntrenamiento(nombreCertificacionEntrenamiento);

                // if (dataGridViewReporte.Rows[x].Cells[4].Value != null)
                //{
                if (duracion != "")
                {
                    duracionDias = int.Parse(duracion);

                }
                else
                {
                    duracionDias = 0;
                }
                //}
                for (int i = 5; dataGridViewReporte.ColumnCount > i; i++)
                {
                    try
                    {

                        mesProyectado = dataGridViewReporte.Columns[i].HeaderText;
                        fechaVigencia = DateTime.Parse(fechaAVencer);
                        fechaProyectada = DateTime.Parse(mesProyectado);
                        fechaVigenciaAnticipada = fechaVigencia.AddDays(-duracionDias);
                        if (fechaVigencia <= fechaProyectada)
                        {
                            dataGridViewReporte.Rows[x].Cells[i].Value = "Vencido";
                            dataGridViewReporte.Rows[x].Cells[i].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridViewReporte.Rows[x].Cells[i].Value = "Vigente";
                        }
                        if (fechaVigenciaAnticipada <= fechaProyectada)
                        {
                            dataGridViewReporte.Rows[x].Cells[i].Style.BackColor = Color.Red;
                        }


                    }
                    catch
                    {

                    }
                }

            }
            metroProgressBarCarga.Value = 90;

            dataGridViewReporte.Columns[1].Frozen = true;

            metroProgressBarCarga.Value = 100;
            labelcargando.Text = "Carga finalizada / Upload finished";

            metroProgressBarCarga.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
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



        private void pictureBoxExcel_Click(object sender, EventArgs e)
        {
            labelcargando.Text = "Cargando / Loading ";
            labelcargando.Visible = true;
            metroProgressBarCarga.Visible = true;    //Mostramos barra de loading y asi el porcentaje que ira aumentando
            metroProgressBarCarga.Value = 10;
            string mensaje = "La información descargada es solo para fines de consulta y puede variar, para información oficial consultar la publicada en MSM/Training app                                                                        " +
                "                                                                                                         " +
                "The downloaded information is only for consultation purposes and may vary, for official information consult the published in MSM/Training app ";


            MessageBox.Show(mensaje, "Advertencia / Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //^Mensaje que avisa que la informacion exportada a excell no es oficial 
            metroProgressBarCarga.Value = 20;
            metroProgressBarCarga.Value = 30;
            metroProgressBarCarga.Value = 40;
            metroProgressBarCarga.Value = 50;
            metroProgressBarCarga.Value = 60;
            metroProgressBarCarga.Value = 70;
            metroProgressBarCarga.Value = 80;
            metroProgressBarCarga.Value = 95;
            exportarexcel(dataGridViewReporte);
            metroProgressBarCarga.Value = 100;
            labelcargando.Text = "Carga finalizada / Upload finished";

            metroProgressBarCarga.Visible = false; 

        }
    }
}
