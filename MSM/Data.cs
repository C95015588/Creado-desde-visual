using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSM
{
    internal class Data
    {
        //Variable Para administrador si esta true es administrador, false no es administrador
        static public Boolean ESADMINISTRADOR = false;
        //Variable Para Supervisor si esta true es Supervisor, false no es Supervisor
        static public Boolean ESSUPERVISOR = false;
        //Variable del nombre completo del usuario desede del dominio
        static public string CUENTA;
        //Variable que almacena el email del usario 
        static public string EMAIL;
        //Variable que almacena el nombre del empleado que accedio sin credenciales 
        static public string NOMBREEMPLEADO;
        //Variable que almacena el numero del empleado que accedio sin credenciales 
        static public string NOEMPLEADO;
        //Variable para identificar a que Businessunit pertenece un area 
        static public string BUSINESSUNIT;
        // //Variable que almacena el numero del empleado que accedio sin credenciales
        static public string CODIGO;
        static public Boolean ESCERTIFICACION = false;
        //Variable para certificacion si es true es certificacion, falso no es certificacion
        static public Boolean ESENTRENAMIENTO = false; 
        //Variable para certificacion si es true es entrenamiento, falso no es entrenamiento 

    }
}
