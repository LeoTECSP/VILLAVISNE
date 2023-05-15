using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoDatos 
{
    /// <summary>
    ///GeneralDao (Data Access object)
    /// </summary>
    public class GeneralDao : ConexionSQL  //Para trabajar la cadena de conexión, no tener que pongamos una nueva clase la cadena o el llamado a la cadena de conexion

    {
        public bool ProbarConexion()
        {
            //Hace de forma automática desde aquí
            SqlConnection conexion = ObtenerConexion();
            try
            {
                conexion.Open();
                return true;

            }
            catch (NullReferenceException)
            {

                return false;
            }

            //Se cierra la conexión
            finally
            {
                conexion.Close();
            }


        }


        public bool InsertarSecretario(string nombre, string apellidoPaterno, string apellidoMaterno, string claveAcceso, string matricula)
        {
            SqlConnection conexion = ObtenerConexion();

            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "sp_InsertarSecretario";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                command.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                command.Parameters.AddWithValue("@claveAcceso", claveAcceso);
                command.Parameters.AddWithValue("@matricula", matricula);

                int filasAfectadas = command.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    return true;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public bool ModificarSecretario(string nombre, string apellidoPaterno, string apellidoMaterno, string claveAcceso, string matricula)
        {
            SqlConnection conexion = ObtenerConexion();

            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "sp_ModificarSecretario";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                command.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                command.Parameters.AddWithValue("@claveAcceso", claveAcceso);
                command.Parameters.AddWithValue("@matricula", matricula);

                int filasAfectadas = command.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    return true;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public bool AgregarMateria(string claveMateria, string nombre)
        {
            SqlConnection conexion = ObtenerConexion();
            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "sp_InsertarMateria";
                command.Parameters.AddWithValue("@claveMateria", claveMateria);
                command.Parameters.AddWithValue("@nombre", nombre);

                command.CommandType = CommandType.StoredProcedure;


                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return true;
            }


            catch (Exception)
            {

                return false;
            }
            finally
            {
                conexion.Close();

            }




        }

        public bool ModificarMateria(string claveMateria, string nombre)
        {
            SqlConnection conexion = ObtenerConexion();
            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "sp_ModificarMateria";
                command.Parameters.AddWithValue("@claveMateria", claveMateria);
                command.Parameters.AddWithValue("@nombre", nombre);

                command.CommandType = CommandType.StoredProcedure;


                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return true;
            }


            catch (Exception)
            {

                return false;
            }
            finally
            {
                conexion.Close();

            }



        }



        public bool agrgarCalif(string Matricula, string ClaveProfesor, int grado, string claveMateria, decimal calificacionFinal)
        {

            SqlConnection conexion = ObtenerConexion();
            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "sp_InsertarDatosAcademicos";
                command.Parameters.AddWithValue("@matricula", Matricula);
                command.Parameters.AddWithValue("@claveProfesor", ClaveProfesor);
                command.Parameters.AddWithValue("@grado", grado);
                command.Parameters.AddWithValue("@claveMateria", claveMateria);
                command.Parameters.AddWithValue("@calificacionFINAL", calificacionFinal);


                command.CommandType = CommandType.StoredProcedure;


                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return true;
            }


            catch (Exception)
            {

                return false;
            }
            finally
            {
                conexion.Close();

            }

        }

        public bool modifCalif(int idRegistro, string Matricula, string ClaveProfesor, int grado, string claveMateria, decimal calificacionFinal)
        {
            SqlConnection conexion = ObtenerConexion();
            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "sp_ModificarDatosAcademicos";
                command.Parameters.AddWithValue("@idRegistro", idRegistro);
                command.Parameters.AddWithValue("@matricula", Matricula);
                command.Parameters.AddWithValue("@claveProfesor", ClaveProfesor);
                command.Parameters.AddWithValue("@grado", grado);
                command.Parameters.AddWithValue("@claveMateria", claveMateria);
                command.Parameters.AddWithValue("@calificacionFINAL", calificacionFinal);


                command.CommandType = CommandType.StoredProcedure;


                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return true;
            }


            catch (Exception)
            {

                return false;
            }
            finally
            {
                conexion.Close();

            }

        }

        public bool RegistrarProfesor(string clave, string nombre, string appPaterno, string apMaterno, string CorreoLaboral, string telefono)
        {
            SqlConnection conexion = ObtenerConexion();
            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "sp_InsertarProfesor";
                command.Parameters.AddWithValue("@claveProfesor", clave);
                command.Parameters.AddWithValue("@nombreProfesor", nombre);
                command.Parameters.AddWithValue("@apellidoPaterno", appPaterno);
                command.Parameters.AddWithValue("@apellidoMaterno", apMaterno);
                command.Parameters.AddWithValue("@correoLaboral", CorreoLaboral);
                command.Parameters.AddWithValue("@telefonoProfesor", telefono);
                //Enviar parametros con las variables de la base de datos
                command.CommandType = CommandType.StoredProcedure;


                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return true;
            }


            catch (Exception)
            {

                return false;
            }
            finally
            {
                conexion.Close();

            }
        }

        public bool AgregarHistorial(string matricula, DateTime fechaAcceso)
        {
            SqlConnection conexion = ObtenerConexion();
            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "sp_InsertarHistorial";

                command.Parameters.AddWithValue("@matricula", matricula);
                command.Parameters.AddWithValue("@fechaAcceso", fechaAcceso);

                command.CommandType = CommandType.StoredProcedure;


                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return true;
            }


            catch (Exception)
            {

                return false;
            }
            finally
            {
                conexion.Close();

            }


        }


        public bool ModificarProfesor(string clave, string nombre, string appPaterno, string apMaterno, string CorreoLaboral, string telefono)
        {

            SqlConnection conexion = ObtenerConexion();
            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "sp_ModificarProfesor";
                command.Parameters.AddWithValue("@claveProfesor", clave);
                command.Parameters.AddWithValue("@nombreProfesor", nombre);
                command.Parameters.AddWithValue("@apellidoPaterno", appPaterno);
                command.Parameters.AddWithValue("@apellidoMaterno", apMaterno);
                command.Parameters.AddWithValue("@correoLaboral", CorreoLaboral);
                command.Parameters.AddWithValue("@telefonoProfesor", telefono);
                //Enviar parametros con las variables de la base de datos
                command.CommandType = CommandType.StoredProcedure;


                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return true;
            }


            catch (Exception)
            {

                return false;
            }
            finally
            {
                conexion.Close();

            }

        }

        public bool AgregarAlumno(string matricula, string nombreAlumno, string apellidoPaterno, string apellidoMaterno, string sexo, string CURP, string telefono, string estadoAlumno, DateTime fechaEntrada, int gradoActual)
        {
            SqlConnection conexion = ObtenerConexion();
            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "sp_InsertarAlumno";
                command.Parameters.AddWithValue("@matricula", matricula);
                command.Parameters.AddWithValue("@nombreAlumno", nombreAlumno);
                command.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                command.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                command.Parameters.AddWithValue("@sexo", sexo);
                command.Parameters.AddWithValue("@CURP", CURP);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@estadoAlumno", estadoAlumno);
                command.Parameters.AddWithValue("@fechaEntrada", fechaEntrada);
                command.Parameters.AddWithValue("@gradoActual", gradoActual);

                command.CommandType = CommandType.StoredProcedure;


                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return true;
            }


            catch (Exception)
            {

                return false;
            }
            finally
            {
                conexion.Close();

            }

        }
        public bool ModificarAlumno(string matricula, string nombreAlumno, string apellidoPaterno, string apellidoMaterno, string sexo, string CURP, string telefono, string estadoAlumno, DateTime fechaEntrada, int gradoActual)
        {
            SqlConnection conexion = ObtenerConexion();
            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conexion;
                command.CommandText = "sp_ModificarAlumno";
                command.Parameters.AddWithValue("@matricula", matricula);
                command.Parameters.AddWithValue("@nombreAlumno", nombreAlumno);
                command.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                command.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                command.Parameters.AddWithValue("@sexo", sexo);
                command.Parameters.AddWithValue("@CURP", CURP);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@estadoAlumno", estadoAlumno);
                command.Parameters.AddWithValue("@fechaEntrada", fechaEntrada);
                command.Parameters.AddWithValue("@gradoActual", gradoActual);

                command.CommandType = CommandType.StoredProcedure;


                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
                return true;
            }


            catch (Exception)
            {

                return false;
            }
            finally
            {
                conexion.Close();

            }

        }



        public DataTable ObtenerClavesProfesor()
        {
            SqlConnection conexion = ObtenerConexion();
            try
            {
                string query = "SELECT claveProfesor FROM Profesor";
                using (SqlConnection connection = new SqlConnection(conexion.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }



            }


            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();

            }

        }
        public DataTable ObtenerNombresProfesor()
        {
            SqlConnection conexion = ObtenerConexion();
            try
            {
                string query = "SELECT CONCAT(nombreProfesor ,'' ,apellidoPaterno , ' ',apellidoPaterno) AS nombreCompleto from Profesor";
                using (SqlConnection connection = new SqlConnection(conexion.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }



            }


            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();

            }

        }
        public DataTable ObtenerNombresMaterias()
        {
            SqlConnection conexion = ObtenerConexion();
            try
            {
                string query = "SELECT CONCAT(Clave,' - ',Nombre) AS Materia FROM VMateria";
                using (SqlConnection connection = new SqlConnection(conexion.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }



        public bool AccederLogin(string contrasenaMatricula, string matriculaAcceso)
        {
        
            SqlConnection connection = ObtenerConexion();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM VSecretario WHERE Matricula = @matricula AND ClaveAcceso = @claveAcceso";
                command.Parameters.AddWithValue("@matricula",matriculaAcceso);
                command.Parameters.AddWithValue("@claveAcceso", contrasenaMatricula);
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                

            }
            finally
            {

                connection.Close();
            }
    
        }



        public DataTable ObtenerHistorial( )
        {
            SqlConnection connection = ObtenerConexion();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM VHistorialAcceso";
           
                command.CommandType = CommandType.Text;



                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);


                return dataTable;
             
            }
            catch (Exception)
            {
                return null;


            }
            finally
            {

                connection.Close();
            }

        }

        public DataTable ObtenerAlumnos()
        {
            SqlConnection connection = ObtenerConexion();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM VAlumno";
                command.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable ObtenerDatosAcademicos()
        {
            SqlConnection connection = ObtenerConexion();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM VDatosAcademicos";
                command.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable ObtenerMaterias()
        {
            SqlConnection connection = ObtenerConexion();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM VMateria";
                command.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable ObtenerProfesores()
        {
            SqlConnection connection = ObtenerConexion();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM VProfesor";
                command.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable ObtenerSecretarios()
        {
            SqlConnection connection = ObtenerConexion();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM VSecretario";
                command.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

   


        //public bool VerMateria()
        //     {
        //         //Hace de forma automática desde aquí
        //         SqlConnection conexion = ObtenerConexion();

        //         try
        //         {
        //             conexion.Open();
        //             SqlCommand command = new SqlCommand();
        //             command.CommandText = "VMateria";

        //             command.CommandType = CommandType.Text;
        //             command.ExecuteReader();

        //             return true;
        //         }
        //         catch (Exception)
        //         {
        //             return false;
        //             throw;
        //         }
        //         finally
        //         {

        //             conexion.Close();
        //         }

        //}
        //public bool VerTablita()
        //{
        //    try
        //    {
        //        using (var connection = ObtenerConexion())
        //        {
        //            using (var command = new SqlCommand())
        //            {

        //                command.Connection = connection;

        //                command.CommandText = "";

        //                SqlDataAdapter adapter = new SqlDataAdapter(command);





        //            }

        //        }


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}



        //public DataTable VerTabla()
        //{


        //    string cadena = "SELECT * FROM Person.Person";


        //    SqlConnection conexion = ObtenerConexion();

        //    try
        //    {
        //        conexion.Open();

        //        SqlCommand comando = new SqlCommand(cadena, conexion);
        //        SqlDataReader lector = comando.ExecuteReader();

        //        DataTable tabla = new DataTable();

        //        tabla.Load(lector);


        //            return tabla;
        //    }
        //    catch (NullReferenceException)
        //    {

        //        throw;
        //    }

        //    //Se cierra la conexión
        //    finally
        //    {
        //        conexion.Close();
        //    }



    }

}
