using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernGUI_V3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //Si la propiedad usuario se vaciará y al momento de escribir se muestre en color mas oscuro 
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
                txtUsuario.Text = "";
            txtUsuario.ForeColor = Color.DarkBlue; {
            } // fin if
        }
        // Si el txt esta vacio, la propiedad de txt volvera a tener el texto usuario
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
                txtUsuario.Text = "USUARIO";
            txtUsuario.ForeColor = Color.DimGray; {
            } // fin if

        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
                txtContraseña.Text = "";
            txtContraseña.ForeColor = Color.DarkBlue;
            txtContraseña.UseSystemPasswordChar = true; {
            } // fin if

        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;   
                    txtContraseña.UseSystemPasswordChar = false; {
            }  // fin if



        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                //Boton salir en el cual se le pregunta al cliente si desea salir del programa
            }

        } 


    } // fin clase
        }
    

