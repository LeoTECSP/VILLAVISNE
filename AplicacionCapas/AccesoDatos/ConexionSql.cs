using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{


    public abstract class ConexionSQL
    {
        //Dentro de la clase conexionsql de la capa accesodatos de forma abstacta metemos una variable privada
        //Que será la cadena de conexion dentro del constructor ConexionSQL metemos en la cadena de conexión la cadena de conexión
        //Dentro de la variable

        private readonly string cadenaConexion;
 

        public ConexionSQL()
        {
            //Con la ayuda de Intellisense agregamos el System.Configuration

            //O También en referencias podemos agregarla
            //Al tener el nombre una sola vez se van a cambiar las clases relacionadas a la conexión automáticamente
            cadenaConexion = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;
           

        }
       
        //Regresamos la nueva cadena de conexión para que cada vez que usemos una cadena conexión usemos este metodo

        protected SqlConnection ObtenerConexion()
        {

            return new SqlConnection(cadenaConexion);
        }


        
       
    } 
}
