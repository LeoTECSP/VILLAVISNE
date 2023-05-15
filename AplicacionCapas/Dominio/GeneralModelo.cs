using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos; //usamos la capa de acceso a datos

namespace Dominio
{
    public class GeneralModelo
    {
        //Instanciando la clase de acceso a datos
        GeneralDao generalDao = new GeneralDao();
        public bool TestConnection()
        {
            //Retornamos a traves de un bool
            return generalDao.ProbarConexion();
        }

        //public bool MostrarTabla()
        //{

        //    //return generalDao.VerTablita();
        //}



        public bool AgregarMateria(string claveMateria, string nombre)
        {
            return generalDao.AgregarMateria(claveMateria,nombre);


        }
        public bool ModificarMateria(string claveMateria, string nombre)
        {
            return generalDao.ModificarMateria(claveMateria, nombre);


        }

        public bool AccederLogin(string contrasenaMatricula,string matriculaAcceso)
        {
            return generalDao.AccederLogin(contrasenaMatricula, matriculaAcceso);

          
        }

        public bool agrgarCalif(string Matricula, string ClaveProfesor, int grado, string claveMateria, decimal calificacionFinal)
        {
            return generalDao.agrgarCalif(Matricula, ClaveProfesor, grado, claveMateria, calificacionFinal);
        
        }

        public bool modifCalif(int idRegistro,string Matricula, string ClaveProfesor, int grado, string claveMateria, decimal calificacionFinal)
        {
            return generalDao.modifCalif(idRegistro,Matricula, ClaveProfesor, grado, claveMateria, calificacionFinal);

        }
        public bool RegistrarProfesor(string clave, string nombre, string appPaterno, string apMaterno, string CorreoLaboral, string telefono)
        {

            return generalDao.RegistrarProfesor(clave, nombre, appPaterno, apMaterno, CorreoLaboral, telefono);

        }

        public bool ModificarProfesor(string clave, string nombre, string appPaterno, string apMaterno, string CorreoLaboral, string telefono)
        {

            return generalDao.ModificarProfesor(clave, nombre, appPaterno, apMaterno, CorreoLaboral, telefono);

        }

        public DataTable ObtenerHistorial()
        {

            return generalDao.ObtenerHistorial();
        }

        public DataTable ObtenerAlumnos()
        {
            return generalDao.ObtenerAlumnos();
        }

        public DataTable ObtenerDatosAcademicos()
        {
            return generalDao.ObtenerDatosAcademicos();
        }

        public DataTable ObtenerMaterias()
        {
            return generalDao.ObtenerMaterias();
        }

        public DataTable ObtenerProfesores()
        {
            return generalDao.ObtenerProfesores();
        }

        public DataTable ObtenerSecretarios()
        {
            return generalDao.ObtenerSecretarios();
        }


        public bool AgregarAlumno(string matricula, string nombreAlumno, string apellidoPaterno, string apellidoMaterno, string sexo, string CURP, string telefono, string estadoAlumno, DateTime fechaEntrada, int gradoActual)
        {
            return generalDao.AgregarAlumno(matricula, nombreAlumno, apellidoPaterno, apellidoMaterno, sexo, CURP, telefono, estadoAlumno, fechaEntrada, gradoActual);

        }
        public bool ModificarAlumno(string matricula, string nombreAlumno, string apellidoPaterno, string apellidoMaterno, string sexo, string CURP, string telefono, string estadoAlumno, DateTime fechaEntrada, int gradoActual)
        {
            return generalDao.ModificarAlumno(matricula, nombreAlumno, apellidoPaterno, apellidoMaterno, sexo, CURP, telefono, estadoAlumno, fechaEntrada, gradoActual);

        }


        public bool InsertarSecretario(string nombre, string apellidoPaterno, string apellidoMaterno, string claveAcceso, string matricula)
        {
            return generalDao.InsertarSecretario(nombre, apellidoPaterno, apellidoMaterno, claveAcceso, matricula);
        }


        public bool ModificarSecretario(string nombre, string apellidoPaterno, string apellidoMaterno, string claveAcceso, string matricula)
        {
            return generalDao.ModificarSecretario(nombre, apellidoPaterno, apellidoMaterno, claveAcceso, matricula);
        }

        public bool AgregarHistorial(string matricula, DateTime fechaAcceso)
        {
            return generalDao.AgregarHistorial(matricula, fechaAcceso);


        }

        public List<string> ObtenerClavesProfesor()
        {
            DataTable dataTable = generalDao.ObtenerClavesProfesor();
            List<string> clavesProfesor = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                clavesProfesor.Add(row["claveProfesor"].ToString());
            }
            return clavesProfesor;
        }
        public List<string> ObtenerNombresMaterias()
        {
            DataTable dataTable = generalDao.ObtenerNombresMaterias();
            List<string> nombresMaterias = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                nombresMaterias.Add(row["Materia"].ToString());
            }
            return nombresMaterias;
        }


        public List<string> ObtenerNombresProfesor()
        {
            DataTable dataTable = generalDao.ObtenerNombresProfesor();
            List<string> nombresProfesor = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                nombresProfesor.Add(row["nombreCompleto"].ToString());
            }
            return nombresProfesor;
        }

        //public bool VerAlumnos()
        //{
        //    //genero booleano
        //    return generalDao.VerAlumnos();

        //}
    }
}
