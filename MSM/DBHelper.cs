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

                    Data.ESADMINISTRADOR = false;
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

                Data.NOMBREEMPLEADO = "Número de empleado incorrecto / Wrong employee number";
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

        public void ObtenerCertificacionEntrenamiento(ComboBox comboBoxCertificacion, ComboBox comboBoxcodigo)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;



            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                conexion.Open();




                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select", conexion))
                {



                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {
                        comboBoxCertificacion.Items.Add(dataReader["nombre"].ToString());
                        comboBoxcodigo.Items.Add(dataReader["codigo"].ToString());



                    }



                    dataReader.Close();
                    conexion.Close();
                }
            }
        }



        public void ObtenerCertificacionEntrenamientoCodigo(ComboBox comboBoxCertificacion, ComboBox comboBoxcodigo)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;
            string codigo = "";



            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                conexion.Open();



                //using (SqlCommand sqlCommand = new SqlCommand (), conexion))AQUI ME QUEDE
                {



                }



            }

        }
        public string ObtenerCodigoByCertificacionEntrenamiento(string comboBoxNombre)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;
            //variable para guardar el codigo que se obtiene por medio de la certificacion o entrenamiento
            string codigo = "";
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_certification_entrenamiento_select_codigo_by_certificacion_entrenamiento", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Nombre", comboBoxNombre);
                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        codigo = codigo + dataReader.GetValue(0);

                    }
                    dataReader.Close();
                    conexion.Close();
                }

            }
            return codigo;
        }
        public string ObtenerCertificacionEntrenamientoByCodigo(string comboBoxCodigo)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;
            //variable para guardar el nombre que se obtiene por medio del codigo
            string nombre = "";
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_certification_entrenamiento_select_certificacion_entrenamiento_by_codigo", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Codigo", comboBoxCodigo);
                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        nombre = nombre + dataReader.GetValue(0);

                    }
                    dataReader.Close();
                    conexion.Close();
                }

            }
            return nombre;
        }

        public void CambiarCodigo(string antiguo, string nuevo)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_certification_entrenamiento_update_codigo", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Codigo", antiguo);
                    sqlCommand.Parameters.AddWithValue("@NuevoCodigo", nuevo);
                    dataReader = sqlCommand.ExecuteReader();

                    dataReader.Close();
                    conexion.Close();
                }

            }

        }

        public string RegistrarCambioCodigo(string antiguo, string nuevo, string nombre)
        {
            DataTable tabla = new DataTable();
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_registro_cambios_codigo_insert", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Codigo", antiguo);
                    sqlCommand.Parameters.AddWithValue("@NuevoCodigo", nuevo);
                    sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
                    sqlCommand.Parameters.AddWithValue("@Responsable", Data.CUENTA);
                    dataReader = sqlCommand.ExecuteReader();
                    tabla.Load(dataReader);
                    dataReader.Close();
                    conexion.Close();
                }

            }
            string mensaje = "";
            if (tabla.Rows.Count > 0)
            {

                mensaje = "Cambio efectuado: " + tabla.Rows[0].Field<decimal>("id");

                return mensaje;
            }
            else
            {
                mensaje = "Error no hubo un cambio";
                return mensaje;
            }

        }

        public void ObtenerTipo(ComboBox comboBoxTipo)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;



            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                conexion.Open();


                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select_tipo", conexion))
                {



                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {
                        comboBoxTipo.Items.Add(dataReader["tipo"].ToString());

                    }



                    dataReader.Close();
                    conexion.Close();
                }
            }
        }

        public void ObtenerAgente(ComboBox comboBoxAgente)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;



            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                conexion.Open();


                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select_agente", conexion))
                {



                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {
                        comboBoxAgente.Items.Add(dataReader["agente"].ToString());

                    }



                    dataReader.Close();
                    conexion.Close();
                }
            }
        }

        public void ObtenerFuncion(ComboBox comboBoxFuncion)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;



            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                conexion.Open();


                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select_funcion", conexion))
                {



                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {
                        comboBoxFuncion.Items.Add(dataReader["funcion"].ToString());

                    }



                    dataReader.Close();
                    conexion.Close();
                }
            }
        }

        public void InsertCertificacionesEntrenamientos(string textBoxNombre, string textBoxCodigo, string comboBoxTipo,
                                            string textBoxFrecuencia, string comboBoxAgente, string comboBoxFuncion, string textBoxDuracion)
        {
            DataTable table = new DataTable();
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;
            using (SqlConnection cnn = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                cnn.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_insert", cnn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Nombre", textBoxNombre);
                    sqlCommand.Parameters.AddWithValue("@Codigo", textBoxCodigo);
                    sqlCommand.Parameters.AddWithValue("@Tipo", comboBoxTipo);
                    sqlCommand.Parameters.AddWithValue("@Frecuencia", textBoxFrecuencia);
                    sqlCommand.Parameters.AddWithValue("@Agente", comboBoxAgente);
                    sqlCommand.Parameters.AddWithValue("@Funcion", comboBoxFuncion);
                    sqlCommand.Parameters.AddWithValue("@Duracion", textBoxDuracion);
                    dataReader = sqlCommand.ExecuteReader();
                    table.Load(dataReader);
                    dataReader.Close();
                    cnn.Close();

                }
            }



        }
        public void ObtenerAreasEnCheckedListBox(CheckedListBox checkedListBoxAreas)
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
                        checkedListBoxAreas.Items.Add(dataReader["nombre"].ToString());

                    }

                    dataReader.Close();
                    conexion.Close();
                }

            }
        }

        public void InsertCertificacionEntrenamientoEnArea(string area)
        {

            string sqlDataSource = connectionString;
            SqlDataReader dataReader;
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_area_insert", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Area", area);
                    sqlCommand.Parameters.AddWithValue("@Codigo", Data.TEMPCODIGO);
                    dataReader = sqlCommand.ExecuteReader();

                    dataReader.Close();
                    conexion.Close();

                }
            }



        }

        public string ObtenerActivoByCodigo(string codigo)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;
            //variable para guardar el que se obtiene por medio del codigo
            string activo = "";
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenaminento_select_activo_by_codigo", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Codigo", codigo);
                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        activo = activo + dataReader.GetValue(0);

                    }
                    dataReader.Close();
                    conexion.Close();
                }

            }
            if (activo == "True")
            {
                activo = "Activo";

            }
            else
            {
                if (activo == "False")
                {
                    activo = "Desactivado";
                }
            }
            return activo;
        }


        public string ObtenerProcesoByCodigo(string comboBoxArea, string codigo)
        {



            string sqlDataSource = connectionString;

            SqlDataReader dataReader;
            string proceso = "";
            using (SqlConnection cnn = new SqlConnection(sqlDataSource))
            {
                cnn.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_area_select_proceso_by_codigo", cnn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Area", comboBoxArea);
                    sqlCommand.Parameters.AddWithValue("@Codigo", codigo);
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {
                        proceso = dataReader.GetValue(0).ToString();

                    }
                    dataReader.Close();
                    cnn.Close();
                }
                return proceso;
            }
        }


        public List<string> ObtenerProcesos(string comboBoxArea)
        {
            string sqlDataSource = connectionString;

            SqlDataReader dataReader;
            List<string> procesos = new List<string>();
            using (SqlConnection cnn = new SqlConnection(sqlDataSource))
            {
                cnn.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_area_select_proceso", cnn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Area", comboBoxArea);

                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        procesos.Add(dataReader.GetValue(0).ToString());
                    }
                    dataReader.Close();
                    cnn.Close();
                }
                return procesos;
            }
        }
        public string ComprobarPerteneceArea(string noEmpleado)
        {

            string sqlDataSource = connectionString;

            SqlDataReader dataReader;
            string existencia = "";
            using (SqlConnection cnn = new SqlConnection(sqlDataSource))
            {
                cnn.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_area_no_empleado", cnn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@NoEmpleado", noEmpleado);
                    sqlCommand.Parameters.AddWithValue("@Area", Data.TEMPAREA);
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {
                        existencia = dataReader.GetValue(0).ToString();
                    }
                    dataReader.Close();
                    cnn.Close();
                }
                return existencia;
            }
        }

        public string InsertarEmpleadoEnArea(string noEmpleado, string area)
        {
            DataTable table = new DataTable();
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_area_no_empleado_insert", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Area", area);
                    sqlCommand.Parameters.AddWithValue("@NoEmpleado", noEmpleado);
                    sqlCommand.Parameters.AddWithValue("@Requisitor", Data.CUENTA);

                    dataReader = sqlCommand.ExecuteReader();
                    table.Load(dataReader);
                    dataReader.Close();
                    conexion.Close();

                }
            }

            string mensaje = "";
            if (table.Rows.Count > 0)
            {
                
                mensaje = "Confirmacion de: ";

                return mensaje;
            }
            else
            {
                mensaje = "No se ha podido hacer el cambio";
                return mensaje;
            }
        }
        public string EliminarEmpleadoEnArea(string noEmpleado, string area)
        {
            DataTable table = new DataTable();
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_area_no_empleado_delete", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Area", area);
                    sqlCommand.Parameters.AddWithValue("@NoEmpleado", noEmpleado);
                    sqlCommand.Parameters.AddWithValue("@Requisitor", Data.CUENTA);

                    dataReader = sqlCommand.ExecuteReader();
                    table.Load(dataReader);
                    dataReader.Close();
                    conexion.Close();

                }
            }

            string mensaje = "";
            if (table.Rows.Count > 0)
            {

                mensaje = "Confirmacion de: ";

                return mensaje;
            }
            else
            {
                mensaje = "No se ha podido hacer el cambio";
                return mensaje;
            }
        }

        public string ActualizarNivel(string comboBoxCodigo, string numeroEmpleado, string fechaVencimiento, string nivelCompetencia, string fechaInicio)
        {
            DataTable tabla = new DataTable();
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_empleado_udate_or_insert", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@NivelCompetencia", nivelCompetencia);
                    sqlCommand.Parameters.AddWithValue("@NumeroEmpleado", numeroEmpleado);
                    sqlCommand.Parameters.AddWithValue("@Codigo", comboBoxCodigo);
                    sqlCommand.Parameters.AddWithValue("@Cuenta", Data.CUENTA);
                    if (fechaVencimiento != "")
                    {
                        sqlCommand.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@FechaVencimiento", DBNull.Value);
                    }
                    if (fechaInicio != "")
                    {
                        sqlCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@FechaInicio", DBNull.Value);
                    }


                    dataReader = sqlCommand.ExecuteReader();
                    tabla.Load(dataReader);
                    dataReader.Close();
                    conexion.Close();

                }
            }
            string mensaje = "";
            if (tabla.Rows.Count > 0)
            {

                mensaje = "Cambio efectuado en el codigo: " + comboBoxCodigo + " para el empleado ";
                return mensaje;
            }
            else
            {
                mensaje = "Error no hubo un cambio para el empleado ";
                return mensaje;
            }
        }
        public int ObtenerCantidadCodigos(string nombre)
        {



            string sqlDataSource = connectionString;



            SqlDataReader dataReader;
            int cantidad = 0;
            using (SqlConnection cnn = new SqlConnection(sqlDataSource))
            {
                cnn.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select_cantidad_codigos_by_nombre", cnn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {
                        cantidad = (int)dataReader.GetValue(0);

                    }
                    dataReader.Close();
                    cnn.Close();
                }
                return cantidad;
            }
        }

        public void ObtenerCodigosComboBox(ComboBox comboBoxCodigo, string nombre)
        {

            string sqlDataSource = connectionString;
            SqlDataReader dataReader;

            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select_codigo_by_nombre_igual", conexion))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
                    dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        comboBoxCodigo.Items.Add(dataReader["codigo"].ToString());

                    }

                    dataReader.Close();
                    conexion.Close();
                }

            }
        }
        public void ObtenerCodigos(ComboBox comboBoxcodigo)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;



            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                conexion.Open();




                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select", conexion))
                {



                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {

                        comboBoxcodigo.Items.Add(dataReader["codigo"].ToString());

                    }



                    dataReader.Close();
                    conexion.Close();
                }
            }
        }
        public string ObtenerFrecuenciaByCodigo(string codigo)
        {



            string sqlDataSource = connectionString;

            SqlDataReader dataReader;
            string frecuencia = "";
            using (SqlConnection cnn = new SqlConnection(sqlDataSource))
            {
                cnn.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select_frecuencia_by_codigo", cnn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Codigo", codigo);
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {
                        frecuencia = dataReader.GetValue(0).ToString();

                    }
                    dataReader.Close();
                    cnn.Close();
                }
                return frecuencia;
            }
        }

        public void ObtenerCertificacionEntrenamientoByArea(string area, ComboBox comboBoxCertificacion)
        {
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;



            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                conexion.Open();




                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select_certificacion_entrenamiento_by_area", conexion))
                {



                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Area", area);
                    dataReader = sqlCommand.ExecuteReader();



                    while (dataReader.Read())
                    {
                        comboBoxCertificacion.Items.Add(dataReader["nombre"].ToString());
                        
                    }



                    dataReader.Close();
                    conexion.Close();
                }
            }
        }

        public void MostrarTablaMultiSkillCertificacionEntrenamiento(DataGridView dataGridViewMultiskill, string area, string certificacionEntrenamiento)
        {

            string sqlDataSource = connectionString;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            using (SqlConnection cnn = new SqlConnection(sqlDataSource))
            {
                cnn.Open();
                using (SqlCommand sqlCommand = new SqlCommand("p_certificacion_entrenamiento_select_codigo_by_certificacion_entrenamiento_and_area", cnn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand = sqlCommand;
                    sqlCommand.Parameters.AddWithValue("@Area", area);
                    sqlCommand.Parameters.AddWithValue("@CertificacionesEntrenamiento", certificacionEntrenamiento);
                    adapter.Fill(table);
                    dataGridViewMultiskill.DataSource = table;
                    cnn.Close();
                }

            }
        }

        //public string ActualizarVencidos()
        //{

        //    string sqlDataSource = connectionString;
        //    SqlDataReader dataReader;
        //    DataTable tabla = new DataTable();
        //    using (SqlConnection cnn = new SqlConnection(sqlDataSource))
        //    {
        //        cnn.Open();
        //        using (SqlCommand sqlCommand = new SqlCommand("", cnn))
        //        {
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            dataReader.SelectCommand = sqlCommand;
        //            tabla.Load(dataReader);
        //            cnn.Close();
        //        }

        //    }
        //    string mensaje = "";
        //    if (tabla.Rows.Count > 0)
        //    {

        //        mensaje = "Cambio efectuado: " + tabla.Rows[0].Field<decimal>("id");

        //        return mensaje;
        //    }
        //    else
        //    {
        //        mensaje = "Error no hubo un cambio";
        //        return mensaje;
        //    }
        //}

        public string ActualizarVencidos()
        {
            DataTable tabla = new DataTable();
            string sqlDataSource = connectionString;
            SqlDataReader dataReader;
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {

                //Open the connection
                conexion.Open();

                using (SqlCommand sqlCommand = new SqlCommand("", conexion))
                {
                    dataReader = sqlCommand.ExecuteReader();
                    tabla.Load(dataReader);
                    dataReader.Close();
                    conexion.Close();
                }

            }
            string mensaje = "";
            if (tabla.Rows.Count > 0)
            {

                mensaje = "Cambio efectuado: " + tabla.Rows[0].Field<decimal>("id") + " afectados";

                return mensaje;
            }
            else
            {
                mensaje = "Error no hubo un cambio";
                return mensaje;
            }

        }
    }
}
