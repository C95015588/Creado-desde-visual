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
     
            string certificacionEntrenamiento, fechaNivelCompetencia, fechaVencimiento, proceso;
            string[] informacionCertificacion, certificacionEntrenamientoNombre;
            string[] procesos;
            int[] colorProcesosRojo = new int[100];
            int[] colorProcesosAzul = new int[100];
            int[] colorProcesosVerde = new int[100];

            procesos = DBHelper.ObtenerProcesos(comboBoxArea.Text).ToArray();
            int rojo = 0 , verde = 65, azul = 50;

            for (int o = 0; o <= procesos.Length; o++)
            {
                colorProcesosRojo[o] = rojo;
                colorProcesosAzul[o] = azul;
                colorProcesosVerde[o] = verde;
                rojo = rojo + 5;
                azul = azul + 15;
                verde = verde + 10;
            }

            for (int i = 2; dataGridViewMultiskill.ColumnCount > i; i++)
            {
                char separador = '|';
                certificacionEntrenamiento = dataGridViewMultiskill.Columns[i].HeaderText;
                certificacionEntrenamientoNombre = certificacionEntrenamiento.Split(separador);
                
                for (int x = 0; dataGridViewMultiskill.RowCount > x; x++)
                {

                    //if (dataGridViewMultiskill.Rows[x].Cells[i].Value != null)
                    //{
                    //    if (dataGridViewMultiskill.Rows[x].Cells[i].Value.ToString() == String.Empty)
                    //        dataGridViewMultiskill.Rows[x].Cells[i].Value = 0;
                    //}
                    try
                    {
                        char delimitador = '[';

                        if (dataGridViewMultiskill.Rows[x].Cells[i].Value != null)
                        {
                            fechaNivelCompetencia = dataGridViewMultiskill.Rows[x].Cells[i].Value.ToString();
                            informacionCertificacion = fechaNivelCompetencia.Split(delimitador);
                            fechaVencimiento = informacionCertificacion[1];
                            if (informacionCertificacion[1] != "")
                            {
                                string duracion = DBHelper.ObtenerDuracionCertificacionEntrenamiento(certificacionEntrenamientoNombre[0]);
                                int duracionDias = int.Parse(duracion);
                                fechaVencimiento = fechaVencimiento.Remove(fechaVencimiento.Length - 1);

                                var fechaVigencia = DateTime.Parse(fechaVencimiento);
                                fechaVigencia = fechaVigencia.AddDays(-duracionDias);
                                if (fechaVigencia <= DateTime.Today)
                                {
                                    dataGridViewMultiskill.Rows[x].Cells[i].Style.BackColor = Color.Red;


                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                }

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxArea.Text != "")
            {

                DBHelper.MostrarTablaMultiSkill(dataGridViewMultiskill, comboBoxArea.Text);
                //System.Windows.Forms.DataGridViewCellStyle norStyle = new System.Windows.Forms.DataGridViewCellStyle();
                //norStyle.Font = new System.Drawing.Font("Lean Status Symbols", 14.0F, System.Drawing.FontStyle.Regular);

                dataGridViewMultiskill.AutoResizeColumns();
                dataGridViewMultiskill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                diseñoMSM();

                dataGridViewMultiskill.Columns[1].Frozen = true;

                Data.TEMPAREA = comboBoxArea.Text;
                //COMENTARIO AÑADIDO PARA HACER PRUEBA EN EL GITHUB
            }
        }

        private void dataGridViewMultiskill_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //REVISAR SI ES NECESARIO POR EL CLICK DERECHO
            char delimitador = '/';

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
    }
}
    