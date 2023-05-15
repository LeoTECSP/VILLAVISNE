using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Presentacion
{
    public partial class AccesoLogin : Form
    {
        public AccesoLogin()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            //SHOW DIALOG me manda a la parte del ogout, y volver a mostrar el formulairo oculto
            //Lo pongo como 

            //DIALOG RESULT SI CIERRO SESIÓN, seríap para poder identificar si se va a volver a abrir

            //Cuando cierro el formulario prinicipal es que me cierra la sesión y vuelve a mostrarme el login sin
            //cerrar la aplicación


            //Pasa a ser formulario principal, para pode rtrabjar
            //Ocultar el login y mostrar el principal, 

            //El retry para volver a cargar el login 
            //Cancel suelen ser cuando los cierras, pero reintentar abrir el formuario del login
            //Forma formpro = new Forma();

            //Show es que puedes regresarte a un formulario anterior
            //ShowDialog no te permite hasta que hagas una acción específica, que aunque tenga los 2 formularios
            //Abiertos no te deja hacer alguna acción para el anterior

            //Mainform prinicipal y lo cargo con el show dialog





            //if (formpro.ShowDialog()==DialogResult.Retry)
            //{
            //    Environment.Exit(0);
            //}


           
            GeneralModelo generalModelo = new GeneralModelo();
            if (generalModelo.AccederLogin(txtContraseñaA.Text.Trim(), txtMatriculaA.Text.Trim()) )
            {
               

                MessageBox.Show("¡Bienvenido!");
                Forma forma = new Forma();


                string matricula = txtMatriculaA.Text.Trim();

                if (generalModelo.AgregarHistorial(matricula, DateTime.Now))
                {
                   
                }
                else
                {
                    MessageBox.Show("Error");
                    return;

                }

                this.Hide();

                if (forma.ShowDialog() == DialogResult.Retry)
                {
                 


                    this.Show();
                    Reiniciar();

         



                }





            }
            else
            {
                MessageBox.Show("No existe este secretario, verifica tu información");
                
            }




             void Reiniciar()
            {

                txtContraseñaA.Clear();
                txtMatriculaA.Clear();

            }

        }
    }
}
