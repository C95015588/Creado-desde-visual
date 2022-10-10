using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MSM
{
    public partial class Login : Form
    {
        DBHelper DBHelper = new DBHelper();
        private bool mouseIsDown = false;
        private Point firstPoint;

        public Login()
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

        public void validacionCredenciales()
        {
            //Metodo en la clase DBHelper que obtiene la conexion a utcain.com para obtener datos
            DBHelper.connectionDomain(textBoxUsuario.Text);
            //Metodo para comprobar que tipo de usuario es
            DBHelper.EsAdministrador();
            DBHelper.EsSupervisor();
            //Open the homescreen and hide this form
            Menu openForm = new Menu();
            openForm.Show();
            //MessageBox.Show("Abrir menu con privilegios para " + Data.CUENTA);

            this.Hide();

        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (checkBoxNoTengoCredenciales.Checked == false)
            {
                if (textBoxContraseña.Text == "" || textBoxUsuario.Text == "")
                {
                    MessageBox.Show("Escribe tu usuario y contraseña correcto / Enter your correct username and password" ,                              
                        "Mensaje / Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "utcain.com"))
                    {
                        //Variable booleana que comprueba si son validas las credenciales
                        bool esValido = pc.ValidateCredentials(textBoxUsuario.Text, textBoxContraseña.Text);

                        if (!esValido)
                        {
                            // Si no es valido
                            MessageBox.Show("Credenciales Invalidas");
                        }
                        else
                        {
                            //Las ccredenciales son validas
                            validacionCredenciales();

                        }
                    }
                }
            }
            else
            {
                if (checkBoxNoTengoCredenciales.Checked == true)
                {
                    Menu openForm = new Menu();
                    openForm.Show();
                    this.Hide();
                }
            }


        }

        private void checkBoxNoTengoCredenciales_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNoTengoCredenciales.Checked == true)
            {
                panelCredenciales.Visible = false;
                textBoxContraseña.Text = "";
                textBoxUsuario.Text = "";
                //panelInvitado.Visible = true;
                buttonModoLectura.Visible = true;
                buttonLogin.Visible = false;

            }
            if (checkBoxNoTengoCredenciales.Checked == false)
            {
                panelCredenciales.Visible = true;
                //panelInvitado.Visible = false;
                buttonModoLectura.Visible = false;
                buttonLogin.Visible = true;


            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
          
            label10.BackColor = Color.Transparent;
            


        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBoxManual_Click(object sender, EventArgs e)
        {
            //Metodo para mostrar el manual de usuario 

            Process proceso = new Process();
            proceso.StartInfo.FileName = @"C:\Users\C95023032\Desktop\Training App - USER MANUAL.pdf";
            proceso.Start();



        }

        private void textBoxUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(this, new EventArgs());
            }
        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
