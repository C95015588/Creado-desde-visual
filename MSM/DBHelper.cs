using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSM
{
    public class DBHelper
    {

        string connectionString = "Data Source=AI250373\\SQLEXPRESS;Initial Catalog=MSM;User ID=MSM_User;Password=msm.collins_2017";


        public void connectionDomain(string usuario)
        {
            //Variable para guardar el nombre de usuario
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                //Variable para obtener credenciales
                var credencialesUsuario = UserPrincipal.FindByIdentity(context, usuario);


                if (credencialesUsuario != null)
                {
                    Data.EMAIL = credencialesUsuario.EmailAddress;
                    Data.CUENTA = credencialesUsuario.GivenName + ' ' + credencialesUsuario.Surname;
                }
                //email para autorizar admi desde el dominio
                Data.EMAIL = credencialesUsuario.EmailAddress;

            }
        }

        public void EsAdministrador()
        {
            //Variable para guardar el correo de la base de datos
            string correoBaseDatos = "";
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;

            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                try
                {
                    //Conexion abierta
                    conexion.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("p_administrador_select_by_email", conexion))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Email", Data.EMAIL);

                        dataReader = sqlCommand.ExecuteReader();

                        while (dataReader.Read())
                        {

                            correoBaseDatos = correoBaseDatos + dataReader.GetValue(0);

                        }

                        dataReader.Close();
                        conexion.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("No Conection to Data base");
                }

                if (Data.EMAIL.ToUpper().Equals(correoBaseDatos.ToUpper()))
                {
                    Data.ESADMINISTRADOR = true;
                }
                else
                {

                    Data.ESSUPERVISOR = false;
                }
            }
        }
        public void EsSupervisor()
        {
            //Variable para guardar el correo de la base de datos
            string correoBaseDatos = "";
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;

            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                try
                {
                    //Conexion Abierta
                    conexion.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("p_supervisor_select_by_email", conexion))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Email", Data.EMAIL);
                        dataReader = sqlCommand.ExecuteReader();

                        while (dataReader.Read())
                        {

                            correoBaseDatos = correoBaseDatos + dataReader.GetValue(0);

                        }

                        dataReader.Close();
                        conexion.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("No Conection to Data base");
                }

                if (Data.EMAIL.ToUpper().Equals(correoBaseDatos.ToUpper()))
                {
                    Data.ESSUPERVISOR = true;
                }
                else
                {

                    Data.ESSUPERVISOR = false;
                }
            }
        }
        public void ObtenerNombreEmpleadoViaNumero(string noEmpleado)
        {
            //Variable para guardar el numero de empleado
            string nombreBaseDatos = "";
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;

            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                conexion.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_empleado_select_nombre_by_numero", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@NoEmpleado", noEmpleado);

                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        nombreBaseDatos = nombreBaseDatos + dataReader.GetValue(0);

                    }
                    Data.NOMBREEMPLEADO = nombreBaseDatos;

                    dataReader.Close();
                    conexion.Close();
                }

            }

            if (String.IsNullOrEmpty(Data.NOMBREEMPLEADO))

            {

                Data.NOMBREEMPLEADO = "No de empleado incorrecto";
            }
        }
        public void ObtenerAreasEnComboBox(ComboBox comboBoxArea)
        {

            string sqlDataSource = connectionString;
            SqlDataReader dataReader;

            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_area_select", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        comboBoxArea.Items.Add(dataReader["nombre"].ToString());

                    }

                    dataReader.Close();
                    conexion.Close();
                }

            }
        }

        public void ObtenerBussinesUnitEnComboBox(ComboBox comboBoxBussinesUnit)
        {

            string sqlDataSource = connectionString;
            SqlDataReader dataReader;

            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_businesunit_select", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        comboBoxBussinesUnit.Items.Add(dataReader["businessunit"].ToString());

                    }

                    dataReader.Close();
                    conexion.Close();
                }

            }
        }




        public void MostrarTablaMultiSkill(DataGridView dataGridViewMultiskill, string area)
        {

            string sqlDataSource = connectionString;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            using (SqlConnection cnn = new SqlConnection(sqlDataSource))
            {
                cnn.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select_multiskill", cnn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand = sqlCommand;
                    sqlCommand.Parameters.AddWithValue("@Area", area);
                    adapter.Fill(table);
                    dataGridViewMultiskill.DataSource = table;
                    cnn.Close();
                }

            }
        }
        public string[] MostrarMSMDetalles(string codigo)
        {



            string sqlDataSource = connectionString;



            SqlDataReader dataReader;
            string[] datosDetalles = new string[8];
            using (SqlConnection cnn = new SqlConnection(sqlDataSource))
            {
                cnn.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select_by_codigo", cnn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Codigo", codigo);
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {
                        for (int i = 0; i < datosDetalles.Length; i++)
                        {

                            datosDetalles[i] = dataReader.GetValue(i).ToString();
                        }



                    }
                    dataReader.Close();
                    cnn.Close();
                }
                return datosDetalles;
            }
        }



        public string MostrarEvidencias(string tipo)
        {



            string sqlDataSource = connectionString;



            SqlDataReader dataReader;
            string evidencias = "", evidencia = "";
            using (SqlConnection cnn = new SqlConnection(sqlDataSource))
            {
                cnn.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_tipo_evidencia_select_by_tipo", cnn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Tipo", tipo);
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {
                        evidencia = dataReader.GetValue(0).ToString();
                        evidencias = evidencias + evidencia + "\n";
                    }
                    dataReader.Close();
                    cnn.Close();
                }
                return evidencias;
            }
        }



        public string ObtenerDuracionCertificacionEntrenamiento(string nombre)
        {



            string sqlDataSource = connectionString;



            SqlDataReader dataReader;
            string duracion = "";
            using (SqlConnection cnn = new SqlConnection(sqlDataSource))
            {
                cnn.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select_duracion_by_nombre", cnn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {
                        duracion = dataReader.GetValue(0).ToString();

                    }
                    dataReader.Close();
                    cnn.Close();
                }
                return duracion;
            }
        }



        public void MostrarReportePorVencer(DataGridView dataGridViewReporte, string area)
        {



            string sqlDataSource = connectionString;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            using (SqlConnection cnn = new SqlConnection(sqlDataSource))
            {
                cnn.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_empleado_select_by_area", cnn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand = sqlCommand;
                    sqlCommand.Parameters.AddWithValue("@Area", area);
                    adapter.Fill(table);
                    dataGridViewReporte.DataSource = table;
                    cnn.Close();
                }



            }
        }
    public void ObtenerKardex(string NoEmpleado, DataGridView dataGridView)
        {
            {
                string sqlDataSource = connectionString;
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable DataTable = new DataTable();



                using (SqlConnection conexion = new SqlConnection(sqlDataSource))
                {
                    conexion.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_empleado_select_nivel_competencia_by_numero", conexion))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        adapter.SelectCommand = sqlCommand;
                        try
                        {
                            sqlCommand.Parameters.AddWithValue("@NoEmpleado", NoEmpleado);
                            adapter.Fill(DataTable);
                            dataGridView.DataSource = DataTable;

                        }
                        catch
                        {
                            MessageBox.Show("Make a request");
                        }
                        conexion.Close();

                    }




                }
            }

        }

        public void FiltraKardexPorArea(string NoEmpleado, string comboBoxArea, DataGridView dataGridView)
        {
            string sqlDataSource = connectionString;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                conexion.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_empleado_select_nivel_competencia_by_numero_y_area", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand = sqlCommand;
                    sqlCommand.Parameters.AddWithValue("@NoEmpleado", NoEmpleado);
                    sqlCommand.Parameters.AddWithValue("@Area", comboBoxArea);
                    adapter.Fill(table);
                    dataGridView.DataSource = table;
                    conexion.Close();
                }

            }
        }


        public void FiltraEntrenamientosNoObtenidos(string NoEmpleado, string comboBoxArea, DataGridView dataGridView)
        {
            string sqlDataSource = connectionString;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                conexion.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_select_entrenamiento_certificaciones_where_no_exits_by_numeroempleado", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand = sqlCommand;
                    sqlCommand.Parameters.AddWithValue("@NoEmpleado", NoEmpleado);
                    sqlCommand.Parameters.AddWithValue("@Area", comboBoxArea);
                    adapter.Fill(table);
                    dataGridView.DataSource = table;
                    conexion.Close();
                }



            }
        }

        public void FiltrarAreaBussinesUnit(ComboBox comboBox, string comboBoxBussinesUnit)
        {
            string sqlDataSource = connectionString;
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlDataReader dataReader;

            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("area_select_by_bussinesunit", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand = sqlCommand;
                    sqlCommand.Parameters.AddWithValue("@businessunit", comboBoxBussinesUnit);
                    dataReader = sqlCommand.ExecuteReader();


                    while (dataReader.Read())
                    {
                        comboBox.Items.Add(dataReader["nombre"].ToString());

                    }

                    dataReader.Close();
                    conexion.Close();
                }

            }
        }

        public void ObtenerEntrenamientos(ComboBox comboBoxCertificacionEntrenamiento)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;

            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                conexion.Open();


                using (SqlCommand sqlCommand = new SqlCommand("certificacion_entrenmiento_by_tipo_EP_P_E", conexion))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        comboBoxCertificacionEntrenamiento.Items.Add(dataReader["nombre"].ToString());

                    }

                    dataReader.Close();
                    conexion.Close();
                }
            }
        }

        public void ObtenerCertificacion(ComboBox comboBoxCertificacionEntrenamiento)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;

            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                conexion.Open();


                using (SqlCommand sqlCommand = new SqlCommand("certificacion_entrenmiento_by_tipo_C", conexion))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        comboBoxCertificacionEntrenamiento.Items.Add(dataReader["nombre"].ToString());

                    }

                    dataReader.Close();
                    conexion.Close();
                }
            }
        }





        }
    }


