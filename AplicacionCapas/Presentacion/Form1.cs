using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

//Dominio tiene acceso a datos y presentacion a dominio

namespace Presentacion
{
    public partial class Forma : Form
    {
        private void ReiniciarBoton()
        {

            VentanaProfesor = false;
            VentanaAlumnos = false;
            VentanaMateria = false;

            VentanaCalificaciones = false;
            VentanaSecretario = false;

        }



        public bool VentanaProfesor = false;
        public bool VentanaAlumnos = false;
        public bool VentanaSecretario = false;
        public bool VentanaMateria = false;
        public bool VentanaCalificaciones = false;

        public Forma()
        {
            InitializeComponent();
        }

        //Los niveles es la parte fisica del equipo, trabajamo en el primer nivel porque tenemos el servidor y el equipo en el mismo equipo

        //Tenemos una arquitectura de 3 capas (dominio, presentacion y acceso a datos)

        //Debemos de mandar un metodo dentro de dominio
        private void btnRevisarConexion_Click(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();
            //se ejecuta el dato y llega al formulario
            if (generalModelo.TestConnection())
            {
                MessageBox.Show("Exito");
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {

            //GeneralModelo generalModelo = new GeneralModelo();

            //if (generalModelo.MostrarTabla())
            //{
            //    MessageBox.Show("Hubo un error, verifica el problema");
            //}

            //else
            //{
            //    //dtgInfo.DataSource = generalModelo.MostrarTabla();

            //}

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();
            List<string> clavesProfesor = generalModelo.ObtenerClavesProfesor();

            List<string> nombresProfesor = generalModelo.ObtenerNombresProfesor();
            for (int i = 0; i < clavesProfesor.Count; i++)
            {
                string clave = clavesProfesor[i];
                string nombre = nombresProfesor[i];
                lbClaveProfesor2.Items.Add(clave + " - " + nombre); // agrega tanto la clave como el nombre a la lista
            }

            List<string> materias = generalModelo.ObtenerNombresMaterias();

            lbListaMaterias.Items.Clear();
            foreach (string materia in materias)
            {
                lbListaMaterias.Items.Add(materia);
            }


            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            btnVerAlumnos.Click += CommonButtonClickHandler;
            btnVerCalificaciones.Click += CommonButtonClickHandler;
            btnVerMaestros.Click += CommonButtonClickHandler;
            btnVerCalificaciones.Click += CommonButtonClickHandler;
            btnVerHistorial.Click += CommonButtonClickHandler;
            btnVerSecretario.Click += CommonButtonClickHandler;


    

        }


        private void CommonButtonClickHandler(object sender, EventArgs e)
        {
            ReiniciarBoton();
            // Código a ejecutar cuando se presiona cualquier botón
            // Obtener el botón que se presionó
            Button btn = sender as Button;

            // Verificar si el botón presionado es btnPRO o btnNUB
            if (btn == btnVerMaterias)
            {
                VentanaMateria = true;
                tabInformacion.SelectedTab = tabMateria;
            }
            if (btn == btnVerCalificaciones)
            {
                VentanaCalificaciones = true;
                tabInformacion.SelectedTab = tabCalificaciones;
            }

            if (btn == btnVerAlumnos)
            {
                VentanaAlumnos = true;
                tabInformacion.SelectedTab = tabAlumno;
            }

            if (btn == btnVerMaestros)
            {
                VentanaProfesor = true;
                tabInformacion.SelectedTab = tabProfesor;
            }

            if (btn == btnVerSecretario)
            {
                VentanaSecretario = true;
                tabInformacion.SelectedTab = tabSecretario;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label16.Text = lbSexoA.Text.ToString();
        }

        private void btnAgregarAlumnos_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarAlumnos_Click(object sender, EventArgs e)
        {

        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();
            //generalModelo.MostrarTabla();


            DataTable dt = generalModelo.ObtenerHistorial();

            if (dt != null)
            {
                ReiniciarBoton();
                dtgGeneral.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error al obtener el historial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnVerMaterias_Click(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();
            //generalModelo.MostrarTabla();


            DataTable dt = generalModelo.ObtenerMaterias();

            if (dt != null)
            {
                ReiniciarBoton();
                dtgGeneral.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error al obtener el historial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerAlumnos_Click(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();
            //generalModelo.MostrarTabla();


            DataTable dt = generalModelo.ObtenerAlumnos();

            if (dt != null)
            {
                ReiniciarBoton();
                dtgGeneral.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error al obtener los alumnos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnVerMaestros_Click(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();
            //generalModelo.MostrarTabla();


            DataTable dt = generalModelo.ObtenerProfesores();

            if (dt != null)
            {
                ReiniciarBoton();
                dtgGeneral.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error al obtener los alumnos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarMateria_Click(object sender, EventArgs e)
        {



            //ME INTERESA EL PURO INSERT (POR SI SE DUPLICA O X, SON CUESTIONES DE VILLA NO MIAS)
        }



        private void btnAgregarCalificacion_Click(object sender, EventArgs e)
        {


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrarDatosProfesor_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarDatosProfesor_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarMateria_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void btnVerCalificaciones_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnVerHistorial_Click_1(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();
            //generalModelo.MostrarTabla();


            DataTable dt = generalModelo.ObtenerHistorial();

            if (dt != null)
            {
                ReiniciarBoton();
                dtgGeneral.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error al obtener el historial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnVerMaterias_Click_1(object sender, EventArgs e)
        {
            tabInformacion.SelectedTab = tabMateria;

            GeneralModelo generalModelo = new GeneralModelo();
            //generalModelo.MostrarTabla();


            DataTable dt = generalModelo.ObtenerMaterias();

            if (dt != null)
            {
                ReiniciarBoton();
                dtgGeneral.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error al obtener el historial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            VentanaMateria = true;



        }

        private void btnVerCalificaciones_Click_1(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();
            //generalModelo.MostrarTabla();


            DataTable dt = generalModelo.ObtenerDatosAcademicos();

            if (dt != null)
            {
                ReiniciarBoton();
                dtgGeneral.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error al obtener los datos academicos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            VentanaCalificaciones = true;

        }

        private void btnVerAlumnos_Click_1(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();
            //generalModelo.MostrarTabla();




            DataTable dt = generalModelo.ObtenerAlumnos();

            if (dt != null)
            {
                ReiniciarBoton();
                dtgGeneral.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error al obtener los datos academicos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnVerMaestros_Click_1(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();
            //generalModelo.MostrarTabla();


            DataTable dt = generalModelo.ObtenerProfesores();

            if (dt != null)
            {
                ReiniciarBoton();
                dtgGeneral.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error al obtener los alumnos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }

        private void btnAgregarSecretario_Click(object sender, EventArgs e)
        {



        }

        private void btnModificarSecretario_Click(object sender, EventArgs e)
        {

        }

        private void btnVerSecretario_Click(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();
            //generalModelo.MostrarTabla();


            DataTable dt = generalModelo.ObtenerSecretarios();

            if (dt != null)
            {
                ReiniciarBoton();
                dtgGeneral.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Error al obtener el secretario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        //la 2 y 4 con los entregables y las actividades
        //2 en lo que llevamos de base de datos, 3 y 4 con base a la arquitectura y lo que concluyamos con la base de datos
        private void dtgGeneral_SelectionChanged(object sender, EventArgs e)
        {


            if (VentanaProfesor)
            {
                if (dtgGeneral.SelectedRows.Count > 0)
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow row = dtgGeneral.SelectedRows[0];

                    // Obtener los valores de las columnas de la fila seleccionada
                    string claveProfesor = row.Cells[1].Value.ToString();
                    string nombreProfesor = row.Cells[2].Value.ToString();
                    string apProfesor = row.Cells[3].Value.ToString();
                    string amProfesor = row.Cells[4].Value.ToString();
                    string correoProfesor = row.Cells[5].Value.ToString();
                    string telefonoProfesor = row.Cells[6].Value.ToString();

                    // Asignar los valores a los campos correspondientes
                    txtClaveProfesorP.Text = claveProfesor;
                    txtNombreProfesorP.Text = nombreProfesor;
                    txtAPProfesorP.Text = apProfesor;
                    txtAMProfesorM.Text = amProfesor;
                    txtCLProfesorP.Text = correoProfesor;
                    txtTelefonoProfesorP.Text = telefonoProfesor;

                    // Establecer el color de los campos en gris
                    txtClaveProfesorP.ForeColor = Color.Gray;
                    txtNombreProfesorP.ForeColor = Color.Gray;
                    txtAPProfesorP.ForeColor = Color.Gray;
                    txtAMProfesorM.ForeColor = Color.Gray;
                    txtCLProfesorP.ForeColor = Color.Gray;
                    txtTelefonoProfesorP.ForeColor = Color.Gray;

                    tabInformacion.SelectedTab = tabProfesor;
                }
            }
            if (VentanaAlumnos)
            {
                if (dtgGeneral.SelectedRows.Count > 0)
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow row = dtgGeneral.SelectedRows[0];

                    // Obtener los valores de las columnas de la fila seleccionada por índice
                    string matricula = row.Cells[1].Value.ToString();
                    string nombre = row.Cells[2].Value.ToString();
                    string apellidoPaterno = row.Cells[3].Value.ToString();
                    string apellidoMaterno = row.Cells[4].Value.ToString();
                    DateTime fechaIngreso = Convert.ToDateTime(row.Cells[9].Value);
                    string sexo = row.Cells[5].Value.ToString();
                    string curp = row.Cells[6].Value.ToString();
                    string telefono = row.Cells[7].Value.ToString();
                    string estadoAcceso = row.Cells[8].Value.ToString();
                    int gradoActual = Convert.ToInt32(row.Cells[10].Value);

                    // Asignar los valores a los campos correspondientes
                    txtMatriculaA.Text = matricula;
                    txtNombreAlumnoA.Text = nombre;
                    txtApellidoPaternoA.Text = apellidoPaterno;
                    txtApellidoMaternoA.Text = apellidoMaterno;
                    dtFechaIngresoA.Value = fechaIngreso;
                    lbSexoA.SelectedItem = sexo;
                    txtCurpA.Text = curp;
                    txtTelefonoA.Text = telefono;
                    lbEstadoAlumnoA.SelectedItem = estadoAcceso;
                    lbGradoActual.SelectedItem = gradoActual.ToString();

                    // Cambiar el tab seleccionado al tab que contiene los campos
                    tabInformacion.SelectedTab = tabAlumno;

                    // Cambiar el color de los campos si es necesario
                    txtMatriculaA.ForeColor = Color.Gray;
                    txtNombreAlumnoA.ForeColor = Color.Gray;
                    txtApellidoPaternoA.ForeColor = Color.Gray;
                    txtApellidoMaternoA.ForeColor = Color.Gray;
                    dtFechaIngresoA.CalendarForeColor = Color.Gray;
                    lbSexoA.ForeColor = Color.Gray;
                    txtCurpA.ForeColor = Color.Gray;
                    txtTelefonoA.ForeColor = Color.Gray;
                    lbEstadoAlumnoA.ForeColor = Color.Gray;
                    lbGradoActual.ForeColor = Color.Gray;
                }
            }
            if (VentanaSecretario)
            {
                if (dtgGeneral.SelectedRows.Count > 0)
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow row = dtgGeneral.SelectedRows[0];

                    // Obtener los valores de las columnas de la fila seleccionada por índice
                    string nombre = row.Cells[1].Value.ToString();
                    string apellidoPaterno = row.Cells[2].Value.ToString();
                    string apellidoMaterno = row.Cells[3].Value.ToString();
                    string claveAcceso = row.Cells[4].Value.ToString();
                    string matricula = row.Cells[5].Value.ToString();

                    // Asignar los valores a los campos correspondientes
                    txtSeN.Text = nombre;
                    txtSeApellidoP.Text = apellidoPaterno;
                    txtSeApellidoM.Text = apellidoMaterno;
                    txtSeClave.Text = claveAcceso;
                    txtSeMatricula.Text = matricula;

                    // Cambiar el tab seleccionado al tab que contiene los campos
                    tabInformacion.SelectedTab = tabSecretario;

                    // Cambiar el color de los campos si es necesario
                    txtSeN.ForeColor = Color.Gray;
                    txtSeApellidoP.ForeColor = Color.Gray;
                    txtSeApellidoM.ForeColor = Color.Gray;
                    txtSeClave.ForeColor = Color.Gray;
                    txtSeMatricula.ForeColor = Color.Gray;
                }
            }
            if (VentanaMateria)
            {
                // Verificar que se haya seleccionado alguna fila
                if (dtgGeneral.SelectedRows.Count > 0)
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow row = dtgGeneral.SelectedRows[0];

                    // Obtener el valor de la columna 1 de la fila seleccionada
                    string claveMateria = row.Cells[1].Value.ToString();
                    string nombreMateria = row.Cells[2].Value.ToString();
                    // Hacer lo que necesites con el valor de la columna 1
                    // ...



                    tabMateria.Controls["txtClaveMateria"].Text = claveMateria;
                    tabMateria.Controls["txtNombreMateria"].Text = nombreMateria;


                    txtClaveMateria.ForeColor = Color.Gray;
                    txtNombreMateria.ForeColor = Color.Gray;


                }

            }
            if (VentanaCalificaciones)
            {
                if (dtgGeneral.SelectedRows.Count > 0)
                {

                    // Obtener la fila seleccionada
                    DataGridViewRow row = dtgGeneral.SelectedRows[0];

                    // Obtener los valores de las columnas de la fila seleccionada
                    int idRegistro = Convert.ToInt32(row.Cells[0].Value);
                    string matricula = row.Cells[2].Value.ToString();
                    string claveProfesor = row.Cells[4].Value.ToString().Substring(0,3).Trim();
                    int grado = Convert.ToInt32(row.Cells[5].Value);
                    string claveMateria = row.Cells[7].Value.ToString().Substring(0, 3).Trim();



                    string calTEMP = (row.Cells[8].Value.ToString());

                    decimal calificacionFinal = Convert.ToDecimal((row.Cells[8].Value.ToString()), CultureInfo.InvariantCulture);

                    // Asignar los valores a los campos correspondientes
                    txtIdRegistroCalificaciones.Text = idRegistro.ToString();
                    txtMatriculaCalif.Text = matricula;
                    foreach (string item in lbClaveProfesor2.Items)
                    {
                        if (item.Substring(0, 3) == claveProfesor.Substring(0, 3))
                        {
                            lbClaveProfesor2.SelectedItem = item;
                            break;
                        }
                    }
                    txtGradoMateria.Text = grado.ToString();
                 

                    foreach (string item in lbListaMaterias.Items)
                    {
                        if (item.Substring(0, 3) == claveMateria.Substring(0, 3))
                        {
                            lbListaMaterias.SelectedItem = item;
                            break;
                        }
                    }

                    txtCalificacionFinal1.Text = calificacionFinal.ToString(CultureInfo.InvariantCulture);

                    // Establecer el color de los campos
                    txtIdRegistroCalificaciones.ForeColor = Color.Gray;
                    txtMatriculaCalif.ForeColor = Color.Gray;
                    lbClaveProfesor2.ForeColor = Color.Gray;
                    txtGradoMateria.ForeColor = Color.Gray;
                    lbListaMaterias.ForeColor = Color.Gray;
                    txtCalificacionFinal1.ForeColor = Color.Gray;


                }
            }
            else
            {
                Console.WriteLine("Ninguna ventana está abierta.");
            }

        }

        private void tabInformacion_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void tabMateria_Enter(object sender, EventArgs e)
        {
            txtClaveMateria.ForeColor = Color.Black;
            txtNombreMateria.ForeColor = Color.Black;


        }

        private void tabMateria_Leave(object sender, EventArgs e)
        {
            txtClaveMateria.Clear();
            txtNombreMateria.Clear();
        }

        private void tabInformacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnModificarMateria_Click_1(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();

            if (string.IsNullOrEmpty(txtClaveMateria.Text) || txtClaveMateria.Text.Length != 3 || !int.TryParse(txtClaveMateria.Text, out int result))
            {
                MessageBox.Show("La clave ingresada no es correcta, verifica que sea de 3 numeros");
                return;
            }
            if (string.IsNullOrEmpty(txtNombreMateria.Text) || txtNombreMateria.Text.Length > 20)
            {

                MessageBox.Show("El nombre no es válido, verifica la información");
                return;
            }

            bool claveMateriaExiste = false;
            foreach (DataGridViewRow row in dtgGeneral.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == txtClaveMateria.Text.Trim())
                {
                    claveMateriaExiste = true;
                    break;
                }
            }

            if (!claveMateriaExiste)
            {

                MessageBox.Show("La clave de materia no existe");
                return;
            }
        



            if (generalModelo.ModificarMateria(txtClaveMateria.Text.Trim(), txtNombreMateria.Text) == true)
            {
                MessageBox.Show("Exito");

                btnVerMaterias.PerformClick();
            }
            else
            {
                MessageBox.Show("Error");
            }



        }

        private void btnAgregarMateria_Click_1(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();


            if (string.IsNullOrEmpty(txtClaveMateria.Text) || txtClaveMateria.Text.Length != 3 || !int.TryParse(txtClaveMateria.Text, out int result))
            {
                MessageBox.Show("La clave ingresada no es correcta, verifica que sea de 3 numeros");
                return;
            }
            if (string.IsNullOrEmpty(txtNombreMateria.Text) || txtNombreMateria.Text.Length > 20)
            {

                MessageBox.Show("El nombre no es válido, verifica la información");
                return;
            }
            foreach (DataGridViewRow row in dtgGeneral.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == txtClaveMateria.Text.Trim())
                {
                    MessageBox.Show("La clave de materia ya ha sido registrada");
                    return;
                }
            }

            foreach (DataGridViewRow row in dtgGeneral.Rows)
            {
                if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == txtNombreMateria.Text.Trim())
                {
                    MessageBox.Show("El nombre de materia ya ha sido registrado");
                    return;
                }
            }


            if (generalModelo.AgregarMateria(txtClaveMateria.Text.Trim(), txtNombreMateria.Text) == true)
            {
                MessageBox.Show("Exito");

                btnVerMaterias.PerformClick();

            }
            else
            {
                MessageBox.Show("Error");
            }



            //ACCESO A DATOS 
            //MANDAME EL NOMBRE DEL DATO Y EL VALOR ES EL STRING QUE LE MANDO DE ALLÁ A RECIBIR
            //INSERT INTO VALUES EN CASO DE QUE FUERA TEXTO
            //SI EN EL SP SOLO TUVIERA UN PURO INSERT ENTONCES EN EL RESULTADO MAYOR A 0

        }

        private void btnAgregarAlumnos_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtMatriculaA.Text) || !Regex.IsMatch(txtMatriculaA.Text, @"^[0-9]{6}$"))
                {
                    MessageBox.Show("La matrícula es incorrecta, debe ser de 6 dígitos");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombreAlumnoA.Text) || txtNombreAlumnoA.Text.Length > 50 || !Regex.IsMatch(txtNombreAlumnoA.Text, @"^[a-zA-Z]+(\s[a-zA-Z]+){0,1}$"))
                {
                    MessageBox.Show("El nombre solo acepta letras");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellidoPaternoA.Text) || !Regex.IsMatch(txtApellidoPaternoA.Text, "^[a-zA-Z]{1,30}$"))
                {
                    MessageBox.Show("El apellido paterno es inválido");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellidoMaternoA.Text) || !Regex.IsMatch(txtApellidoMaternoA.Text, "^[a-zA-Z]{1,30}$"))
                {
                    MessageBox.Show("El apellido materno es inválido");
                    return;
                }


                if (string.IsNullOrEmpty(txtTelefonoA.Text) || !Regex.IsMatch(txtTelefonoA.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("El teléfono no es válido, debe contener 10 números");
                    return;
                }

                if (string.IsNullOrEmpty(txtCurpA.Text) || !Regex.IsMatch(txtCurpA.Text, @"^[a-zA-Z0-9]{1,18}$"))
                {
                    MessageBox.Show("La CURP no es válida, debe contener letras y números hasta 18 caracteres");
                    return;
                }

                if (string.IsNullOrEmpty(lbSexoA.Text) || string.IsNullOrEmpty(lbEstadoAlumnoA.Text))
                {
                    MessageBox.Show("Debes seleccionar una opción en Sexo y Estado del Alumno");
                    return;
                }


                // Verifica si la matrícula ya existe en la columna 2 del DataGridView
                foreach (DataGridViewRow row in dtgGeneral.Rows)
                {
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == txtMatriculaA.Text.Trim())
                    {
                        MessageBox.Show("La matrícula ya existe en la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }



                GeneralModelo generalModelo = new GeneralModelo();
                int gradoActual = Convert.ToInt32(lbGradoActual.SelectedItem.ToString());

                if (generalModelo.AgregarAlumno(txtMatriculaA.Text.Trim(), txtNombreAlumnoA.Text.Trim(), txtApellidoPaternoA.Text.Trim(),
                    txtApellidoMaternoA.Text.Trim(), lbSexoA.SelectedItem.ToString(), txtCurpA.Text.Trim(),
                    txtTelefonoA.Text.Trim(), lbEstadoAlumnoA.SelectedItem.ToString(), dtFechaIngresoA.Value.Date, gradoActual))
                {

                    MessageBox.Show("Exito");

                    btnVerAlumnos.PerformClick();
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnModificarAlumnos_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtMatriculaA.Text) || !Regex.IsMatch(txtMatriculaA.Text, @"^[0-9]{6}$"))
                {
                    MessageBox.Show("La matrícula es incorrecta, debe ser de 6 dígitos");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombreAlumnoA.Text) || txtNombreAlumnoA.Text.Length > 50 || !Regex.IsMatch(txtNombreAlumnoA.Text, @"^[a-zA-Z]+(?:\s[a-zA-Z]+)?$"))
                {
                    MessageBox.Show("El nombre solo acepta letras");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellidoPaternoA.Text) || !Regex.IsMatch(txtApellidoPaternoA.Text, "^[a-zA-Z]{1,30}$"))
                {
                    MessageBox.Show("El apellido paterno es inválido");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellidoMaternoA.Text) || !Regex.IsMatch(txtApellidoMaternoA.Text, "^[a-zA-Z]{1,30}$"))
                {
                    MessageBox.Show("El apellido materno es inválido");
                    return;
                }


                if (string.IsNullOrEmpty(txtTelefonoA.Text) || !Regex.IsMatch(txtTelefonoA.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("El teléfono no es válido, debe contener 10 números");
                    return;
                }

                if (string.IsNullOrEmpty(txtCurpA.Text) || !Regex.IsMatch(txtCurpA.Text, @"^[a-zA-Z0-9]{1,18}$"))
                {
                    MessageBox.Show("La CURP no es válida, debe contener letras y números hasta 18 caracteres");
                    return;
                }

                if (string.IsNullOrEmpty(lbSexoA.Text) || string.IsNullOrEmpty(lbEstadoAlumnoA.Text))
                {
                    MessageBox.Show("Debes seleccionar una opción en Sexo y Estado del Alumno");
                    return;
                }


                bool matriculaExiste = false;

                foreach (DataGridViewRow row in dtgGeneral.Rows)
                {
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == txtMatriculaA.Text.Trim())
                    {
                        matriculaExiste = true;
                        break;
                    }
                }

                if (!matriculaExiste)
                {
                    MessageBox.Show("La matrícula no existe en la tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                GeneralModelo generalModelo = new GeneralModelo();
                int gradoActual = Convert.ToInt32(lbGradoActual.SelectedItem.ToString());

                if (generalModelo.ModificarAlumno(txtMatriculaA.Text.Trim(), txtNombreAlumnoA.Text.Trim(), txtApellidoPaternoA.Text.Trim(),
                    txtApellidoMaternoA.Text.Trim(), lbSexoA.SelectedItem.ToString(), txtCurpA.Text.Trim(),
                    txtTelefonoA.Text.Trim(), lbEstadoAlumnoA.SelectedItem.ToString(), dtFechaIngresoA.Value.Date, gradoActual))
                {

                    MessageBox.Show("Exito");
                    btnVerAlumnos.PerformClick();
                    
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrarDatosProfesor_Click_1(object sender, EventArgs e)
        {

            GeneralModelo generalModelo = new GeneralModelo();


            if (string.IsNullOrEmpty(txtClaveProfesorP.Text) || txtClaveProfesorP.Text.Trim().Length != 3 || !txtClaveProfesorP.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("La clave del profesor debe contener solo 3 números");
                return;
            }

            string nombre = txtNombreProfesorP.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length > 50 || !Regex.IsMatch(nombre, @"^[\p{L}]+(\s[\p{L}]+){0,1}$"))
            {
                MessageBox.Show("El nombre solo acepta letras y puede contener hasta dos nombres");
                return;
            }

            string apellidoPaterno = txtAPProfesorP.Text.Trim();

            if (string.IsNullOrEmpty(apellidoPaterno) || apellidoPaterno.Length > 30 || !apellidoPaterno.All(c => char.IsLetter(c) || c == ' ' || c == '\b'))
            {
                MessageBox.Show("El apellido paterno solo acepta letras");
                return;
            }

            string apellidoMaterno = txtAMProfesorM.Text.Trim();

            if (string.IsNullOrEmpty(apellidoMaterno) || apellidoMaterno.Length > 30 || !apellidoMaterno.All(c => char.IsLetter(c) || c == ' ' || c == '\b'))
            {
                MessageBox.Show("El apellido materno solo acepta letras");
                return;
            }

            string correoLaboral = txtCLProfesorP.Text.Trim();

            if (string.IsNullOrEmpty(correoLaboral) || correoLaboral.Length > 200 || !correoLaboral.All(c => char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '\b') || correoLaboral.Contains(" "))
            {
                MessageBox.Show("El correo debe estar bien escrito y no contener espacios");
                return;
            }

            string telefonoProfesor = txtTelefonoProfesorP.Text.Trim();

            if (string.IsNullOrEmpty(telefonoProfesor) || telefonoProfesor.Length != 10 || !telefonoProfesor.All(char.IsDigit) || telefonoProfesor.Contains("\b"))
            {
                MessageBox.Show("El número telefónico debe estar bien escrito");
                return;
            }


            foreach (DataGridViewRow row in dtgGeneral.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Equals(txtClaveProfesorP.Text))
                {
                    MessageBox.Show("La clave del profesor ya existe");
                    return;
                }
            }


            if (generalModelo.RegistrarProfesor(txtClaveProfesorP.Text.Trim(), nombre, apellidoPaterno, apellidoMaterno, correoLaboral, telefonoProfesor))
            {
                MessageBox.Show("Exito");
                btnVerMaestros.PerformClick();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnModificarDatosProfesor_Click_1(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();

            if (string.IsNullOrEmpty(txtClaveProfesorP.Text) || txtClaveProfesorP.Text.Trim().Length != 3 || !txtClaveProfesorP.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("La clave del profesor debe contener solo 3 números");
                return;
            }

            string nombre = txtNombreProfesorP.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length > 50 || !Regex.IsMatch(nombre, @"^[\p{L}]+(\s[\p{L}]+){0,1}$"))
            {
                MessageBox.Show("El nombre solo acepta letras y puede contener hasta dos nombres");
                return;
            }

            string apellidoPaterno = txtAPProfesorP.Text.Trim();

            if (string.IsNullOrEmpty(apellidoPaterno) || apellidoPaterno.Length > 30 || !apellidoPaterno.All(c => char.IsLetter(c) || c == ' ' || c == '\b'))
            {
                MessageBox.Show("El apellido paterno solo acepta letras");
                return;
            }

            string apellidoMaterno = txtAMProfesorM.Text.Trim();

            if (string.IsNullOrEmpty(apellidoMaterno) || apellidoMaterno.Length > 30 || !apellidoMaterno.All(c => char.IsLetter(c) || c == ' ' || c == '\b'))
            {
                MessageBox.Show("El apellido materno solo acepta letras");
                return;
            }

            string correoLaboral = txtCLProfesorP.Text.Trim();

            if (string.IsNullOrEmpty(correoLaboral) || correoLaboral.Length > 200 || !correoLaboral.All(c => char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '\b') || correoLaboral.Contains(" "))
            {
                MessageBox.Show("El correo debe estar bien escrito y no contener espacios");
                return;
            }

            string telefonoProfesor = txtTelefonoProfesorP.Text.Trim();

            if (string.IsNullOrEmpty(telefonoProfesor) || telefonoProfesor.Length != 10 || !telefonoProfesor.All(char.IsDigit) || telefonoProfesor.Contains("\b"))
            {
                MessageBox.Show("El número telefónico debe estar bien escrito");
                return;
            }

            bool existeClave = false;
            foreach (DataGridViewRow row in dtgGeneral.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Equals(txtClaveProfesorP.Text))
                {
                    existeClave = true;
                    break;
                }
            }

            if (!existeClave)
            {
                MessageBox.Show("La clave del profesor no existe");
                return;
            }


            if (generalModelo.ModificarProfesor(txtClaveProfesorP.Text.Trim(), txtNombreProfesorP.Text, txtAPProfesorP.Text, txtAMProfesorM.Text, txtCLProfesorP.Text, txtTelefonoProfesorP.Text))
            {
                MessageBox.Show("Exito");
                btnVerMaestros.PerformClick();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnAgregarSecretario_Click_1(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();

            string nombre = txtSeN.Text.Trim();


            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length > 50 || !nombre.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("El nombre solo acepta letras");
                return;
            }


            string apellidoPaterno = txtSeApellidoP.Text.Trim();

            if (string.IsNullOrWhiteSpace(apellidoPaterno) || !apellidoPaterno.All(c => char.IsLetter(c) || apellidoPaterno.Length > 30))
            {
                MessageBox.Show("El apellido paterno es inválido.");
                return;
            }

            string apellidoMaterno = txtSeApellidoM.Text.Trim();

            if (string.IsNullOrWhiteSpace(apellidoMaterno) || !apellidoMaterno.All(c => char.IsLetter(c) || apellidoMaterno.Length > 30))
            {
                MessageBox.Show("El apellido materno es inválido.");
                return;
            }

            string claveAcceso = txtSeClave.Text.Trim();

            if (string.IsNullOrWhiteSpace(claveAcceso) || claveAcceso.Length > 10)
            {
                MessageBox.Show("La clave de acceso es inválida.");
                return;
            }

            string matricula = txtSeMatricula.Text.Trim();

            if (string.IsNullOrWhiteSpace(matricula) || matricula.Length != 6 || !matricula.Trim().All(char.IsDigit))
            {
                MessageBox.Show("La matrícula es inválida.");
                return;
            }

          

            foreach (DataGridViewRow row in dtgGeneral.Rows)
            {
                if (row.Cells[5].Value != null && row.Cells[5].Value.ToString() == matricula)
                {
                    MessageBox.Show("La matrícula ya ha sido registrada");
                    return;
                }
            }



            if (generalModelo.InsertarSecretario(txtSeN.Text.Trim(), txtSeApellidoP.Text.Trim(), txtSeApellidoM.Text.Trim(), txtSeClave.Text.Trim(), txtSeMatricula.Text.Trim()))
            {
                MessageBox.Show("Exito");
                btnVerSecretario.PerformClick();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnModificarSecretario_Click_1(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();

            string nombre = txtSeN.Text.Trim();


            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length > 50 || !nombre.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("El nombre solo acepta letras");
                return;
            }


            string apellidoPaterno = txtSeApellidoP.Text.Trim();

            if (string.IsNullOrWhiteSpace(apellidoPaterno) || !apellidoPaterno.All(c => char.IsLetter(c) || apellidoPaterno.Length > 30))
            {
                MessageBox.Show("El apellido paterno es inválido.");
                return;
            }

            string apellidoMaterno = txtSeApellidoM.Text.Trim();

            if (string.IsNullOrWhiteSpace(apellidoMaterno) || !apellidoMaterno.All(c => char.IsLetter(c) || apellidoMaterno.Length > 30))
            {
                MessageBox.Show("El apellido materno es inválido.");
                return;
            }

            string claveAcceso = txtSeClave.Text.Trim();

            if (string.IsNullOrWhiteSpace(claveAcceso) || claveAcceso.Length > 10)
            {
                MessageBox.Show("La clave de acceso es inválida.");
                return;
            }

            string matricula = txtSeMatricula.Text.Trim();

            if (string.IsNullOrWhiteSpace(matricula) || matricula.Length != 6 || !matricula.Trim().All(char.IsDigit))
            {
                MessageBox.Show("La matrícula es inválida.");
                return;
            }


            bool existeMatricula = false;
            foreach (DataGridViewRow row in dtgGeneral.Rows)
            {
                if (row.Cells[5].Value != null && row.Cells[5].Value.ToString().Equals(matricula))
                {
                    existeMatricula = true;
                    break;
                }
            }

            if (!existeMatricula)
            {
                MessageBox.Show("La clave del profesor no existe");
                return;
            }




            if (generalModelo.ModificarSecretario(txtSeN.Text.Trim(), txtSeApellidoP.Text.Trim(), txtSeApellidoM.Text.Trim(), txtSeClave.Text.Trim(), txtSeMatricula.Text.Trim()))
            {
                MessageBox.Show("Exito");
                btnVerSecretario.PerformClick();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnAgregarCalificacion_Click_1(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();

            int grado = Convert.ToInt16(txtGradoMateria.Text);
            decimal calificacionFinal = Decimal.Parse(txtCalificacionFinal1.Text, CultureInfo.InvariantCulture);
            string claveProfesor = lbClaveProfesor2.SelectedItem.ToString().Substring(0,3).Trim();
            string materia = lbListaMaterias.SelectedItem.ToString();
            string claveMateria = materia.Substring(0, 3);


            if (string.IsNullOrEmpty(txtMatriculaCalif.Text.Trim()) || !Regex.IsMatch(txtMatriculaCalif.Text.Trim(), "^[0-9]{6}$"))
            {
                MessageBox.Show("Error: la matrícula debe tener 6 dígitos numéricos.");
                return;
            }

            if (string.IsNullOrEmpty(claveProfesor) || claveProfesor.Length != 3 || !Regex.IsMatch(claveProfesor, @"^[0-9]+$"))
            {
                MessageBox.Show("Error: la clave del profesor debe tener 3 dígitos numéricos.");
                return;
            }

            if (string.IsNullOrEmpty(grado.ToString()) || grado.ToString().Length != 1 || !(grado.ToString()[0] >= '1' && grado.ToString()[0] <= '6'))
            {
                MessageBox.Show("Error: el grado debe ser un número del 1 al 6.");
                return;
            }

            if (string.IsNullOrEmpty(claveMateria) || claveMateria.Length != 3 || !Regex.IsMatch(claveMateria, @"^[0-9]+$"))
            {
                MessageBox.Show("Error: la clave de la materia debe tener 3 dígitos numéricos.");
                return;
            }

            if (calificacionFinal < 0.0m || calificacionFinal > 10.0m)
            {
                MessageBox.Show("Error: la calificación final debe ser un número decimal válido entre 0.0 y 10.0.");
                return;
            }





            if (generalModelo.agrgarCalif(txtMatriculaCalif.Text.Trim(), claveProfesor, grado, claveMateria, calificacionFinal))
            {
                MessageBox.Show("Exito");
                btnVerCalificaciones.PerformClick();
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            GeneralModelo generalModelo = new GeneralModelo();

            int grado = Convert.ToInt16(txtGradoMateria.Text);
            int idRegistro = Convert.ToInt32(txtIdRegistroCalificaciones.Text);
            decimal calificacionFinal = Decimal.Parse(txtCalificacionFinal1.Text, CultureInfo.InvariantCulture);
            string claveProfesor = lbClaveProfesor2.SelectedItem.ToString().Substring(0, 3).Trim();
            string materia = lbListaMaterias.SelectedItem.ToString();
            string claveMateria = materia.Substring(0, 3);



            if (string.IsNullOrEmpty(txtMatriculaCalif.Text.Trim()) || !Regex.IsMatch(txtMatriculaCalif.Text.Trim(), "^[0-9]{6}$"))
            {
                MessageBox.Show("Error: la matrícula debe tener 6 dígitos numéricos.");
                return;
            }

            if (string.IsNullOrEmpty(claveProfesor) || claveProfesor.Length != 3 || !Regex.IsMatch(claveProfesor, @"^[0-9]+$"))
            {
                MessageBox.Show("Error: la clave del profesor debe tener 3 dígitos numéricos.");
                return;
            }

            if (string.IsNullOrEmpty(grado.ToString()) || grado.ToString().Length != 1 || !(grado.ToString()[0] >= '1' && grado.ToString()[0] <= '6'))
            {
                MessageBox.Show("Error: el grado debe ser un número del 1 al 6.");
                return;
            }

            if (string.IsNullOrEmpty(claveMateria) || claveMateria.Length != 3 || !Regex.IsMatch(claveMateria, @"^[0-9]+$"))
            {
                MessageBox.Show("Error: la clave de la materia debe tener 3 dígitos numéricos.");
                return;
            }

            if (calificacionFinal < 0.0m || calificacionFinal > 10.0m)
            {
                MessageBox.Show("Error: la calificación final debe ser un número decimal válido entre 0.0 y 10.0.");
                return;
            }

            if (!int.TryParse(txtIdRegistroCalificaciones.Text, out idRegistro))
            {
                MessageBox.Show("El valor del ID de registro no es un número válido.");
                return;
            }

            bool existeRegistro = false;
            foreach (DataGridViewRow row in dtgGeneral.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == idRegistro)
                {
                    existeRegistro = true;
                    break;
                }
            }

            if (!existeRegistro)
            {
                MessageBox.Show("No existe ningún registro con ese ID.");
                return;
            }




            if (generalModelo.modifCalif(idRegistro, txtMatriculaCalif.Text.Trim(), claveProfesor, grado, claveMateria, calificacionFinal))
            {
                MessageBox.Show("Exito");
                btnVerCalificaciones.PerformClick();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void dtFechaIngresoA_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabMateria_Click(object sender, EventArgs e)
        {

        }

     

        private void tabAlumno_Enter(object sender, EventArgs e)
        {
            
            txtMatriculaA.ForeColor = Color.Black;
            txtNombreAlumnoA.ForeColor = Color.Black;
            txtApellidoPaternoA.ForeColor = Color.Black;
            txtApellidoMaternoA.ForeColor = Color.Black;
            dtFechaIngresoA.CalendarForeColor = Color.Black;
            lbSexoA.ForeColor = Color.Black;
            txtCurpA.ForeColor = Color.Black;
            txtTelefonoA.ForeColor = Color.Black;
            lbEstadoAlumnoA.ForeColor = Color.Black;
            lbGradoActual.ForeColor = Color.Black;
        }

        private void tabAlumno_Leave(object sender, EventArgs e)
        {
            txtMatriculaA.Clear();
            txtNombreAlumnoA.Clear();
            txtApellidoPaternoA.Clear();
            txtApellidoMaternoA.Clear();
            dtFechaIngresoA.Value = DateTime.Today;
            lbSexoA.ClearSelected();
            txtCurpA.Clear();
            txtTelefonoA.Clear();
            lbEstadoAlumnoA.ClearSelected();
            lbGradoActual.ClearSelected();
        }

        private void tabProfesor_Leave(object sender, EventArgs e)
        {
            txtClaveProfesorP.Clear();
            txtNombreProfesorP.Clear();
            txtAPProfesorP.Clear();
            txtAMProfesorM.Clear();
            txtCLProfesorP.Clear();
            txtTelefonoProfesorP.Clear();
        }

        private void tabProfesor_Enter(object sender, EventArgs e)
        {
            txtClaveProfesorP.ForeColor = Color.Black;
            txtNombreProfesorP.ForeColor = Color.Black;
            txtAPProfesorP.ForeColor = Color.Black;
            txtAMProfesorM.ForeColor = Color.Black;
            txtCLProfesorP.ForeColor = Color.Black;
            txtTelefonoProfesorP.ForeColor = Color.Black;

        }

        private void tabSecretario_Enter(object sender, EventArgs e)
        {
            txtSeN.ForeColor = Color.Black;
            txtSeApellidoP.ForeColor = Color.Black;
            txtSeApellidoM.ForeColor = Color.Black;
            txtSeClave.ForeColor = Color.Black;
            txtSeMatricula.ForeColor = Color.Black;
        }

        private void tabSecretario_Leave(object sender, EventArgs e)
        {
            txtSeN.Clear();
            txtSeApellidoP.Clear();
            txtSeApellidoM.Clear();
            txtSeClave.Clear();
            txtSeMatricula.Clear();
        }

        private void tabCalificaciones_Enter(object sender, EventArgs e)
        {

            // Establecer el color de los campos
            txtIdRegistroCalificaciones.ForeColor = Color.Black;
            txtMatriculaCalif.ForeColor = Color.Black;
            lbClaveProfesor2.ForeColor = Color.Black;
            txtGradoMateria.ForeColor = Color.Black;
            lbListaMaterias.ForeColor = Color.Black;
            txtCalificacionFinal1.ForeColor = Color.Black;
        }

        private void tabCalificaciones_Leave(object sender, EventArgs e)
        {
            txtIdRegistroCalificaciones.Clear();
            txtMatriculaCalif.Clear();
            lbClaveProfesor2.ClearSelected(); 
            txtGradoMateria.Clear();
            lbListaMaterias.ClearSelected();
            txtCalificacionFinal1.Clear();
        }

        private void btnVerMaterias_Enter(object sender, EventArgs e)
        {
            btnVerMaterias.BackColor = Color.LightBlue;
        }

        private void btnVerAlumnos_Enter(object sender, EventArgs e)
        {
            btnVerAlumnos.BackColor = Color.LightBlue;
        }

        private void btnVerMaestros_Enter(object sender, EventArgs e)
        {
            btnVerMaestros.BackColor = Color.LightBlue;
        }

        private void btnVerCalificaciones_Enter(object sender, EventArgs e)
        {
            btnVerCalificaciones.BackColor = Color.LightBlue;
        }

        private void btnVerSecretario_Enter(object sender, EventArgs e)
        {
            btnVerSecretario.BackColor = Color.LightBlue;
        }

        private void btnVerHistorial_Enter(object sender, EventArgs e)
        {
            btnVerHistorial.BackColor = Color.LightBlue;
        }

        private void btnVerHistorial_Leave(object sender, EventArgs e)
        {
            btnVerHistorial.BackColor = Color.MintCream;
        }

        private void btnVerSecretario_Leave(object sender, EventArgs e)
        {
            btnVerSecretario.BackColor = Color.MintCream;
        }

        private void btnVerCalificaciones_Leave(object sender, EventArgs e)
        {

            btnVerCalificaciones.BackColor = Color.MintCream;
        }

        private void btnVerMaestros_Leave(object sender, EventArgs e)
        {
            btnVerMaestros.BackColor = Color.MintCream;
        }

        private void btnVerAlumnos_Leave(object sender, EventArgs e)
        {
            btnVerAlumnos.BackColor = Color.MintCream;
        }

        private void btnVerMaterias_Leave(object sender, EventArgs e)
        {
            btnVerMaterias.BackColor = Color.MintCream;
        }

      
    }
}
