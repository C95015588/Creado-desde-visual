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
            dataGridViewReporte.Columns.Clear();
            DBHelper.MostrarReportePorVencer(dataGridViewReporte, comboBoxArea.Text);
            DateTime hoy = DateTime.Today;
            int mesActual = hoy.Month;
            int añoActual = hoy.Year;
            DateTime primeroDeMesActual = new DateTime( añoActual,mesActual, 01);
            DateTime mesUno = primeroDeMesActual;
            mesUno = mesUno.AddMonths(1).AddDays(-1);
            DateTime mesDos = primeroDeMesActual.AddMonths(2).AddDays(-1);
            DateTime mesTres = primeroDeMesActual.AddMonths(3).AddDays(-1);
            DateTime mesCuatro = primeroDeMesActual.AddMonths(4).AddDays(-1);
            string primerMesPalabra = mesUno.ToString("MMM-dd-yyyy");
            string segundoMesPalabra = mesDos.ToString("MMM-dd-yyyy");
            string tercerMesPalabra = mesTres.ToString("MMM-dd-yyyy");
            string cuartoMesPalabra = mesCuatro.ToString("MMM-dd-yyyy");

            dataGridViewReporte.Columns.Add(primerMesPalabra, primerMesPalabra);
            dataGridViewReporte.Columns.Add(segundoMesPalabra,segundoMesPalabra);
            dataGridViewReporte.Columns.Add(tercerMesPalabra, tercerMesPalabra);
            dataGridViewReporte.Columns.Add(cuartoMesPalabra, cuartoMesPalabra);

            for (int i = 5; dataGridViewReporte.ColumnCount > i; i++)
            {
                for (int x = 0; dataGridViewReporte.RowCount > x; x++)
                {

                    try
                    {

                        if (dataGridViewReporte.Rows[x].Cells[4].Value != null)
                        {

                            string fechaAVencer = dataGridViewReporte.Rows[x].Cells[4].Value.ToString();
                            string mesProyectado = dataGridViewReporte.Columns[i].HeaderText;
                            string nombreCertificacionEntrenamiento = dataGridViewReporte.Rows[x].Cells[3].Value.ToString();
                            string duracion = DBHelper.ObtenerDuracionCertificacionEntrenamiento(nombreCertificacionEntrenamiento);
                            int duracionDias = int.Parse(duracion);

                            var fechaVigencia = DateTime.Parse(fechaAVencer);
                            var fechaProyectada = DateTime.Parse(mesProyectado);
                            var fechaVigenciaAnticipada = fechaVigencia.AddDays(-duracionDias);
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


                            //var fechaVigencia = DateTime.Parse(fechaAVencer);
                            //var fechaProyectada = DateTime.Parse(mesProyectado);
                            //fechaProyectada = fechaProyectada.AddDays(-duracionDias);
                            //if (fechaVigencia <= fechaProyectada)
                            //{
                            //    dataGridViewReporte.Rows[x].Cells[i].Style.BackColor = Color.Red;
                            //    dataGridViewReporte.Rows[x].Cells[i].Value = "Vencido";


                            //}
                            //else
                            //{
                            //    dataGridViewReporte.Rows[x].Cells[i].Value = "Vigente";

                            //}
                        }
                    }
                    catch
                    {

                    }
                }
                //dataGridViewMultiskill.Columns[i].DefaultCellStyle = norStyle;  //Metodo para que aparezcan las meatballs
            }
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
    }
}
