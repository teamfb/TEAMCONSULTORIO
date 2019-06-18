using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModernGUI_V3.Controlador;

namespace ModernGUI_V3
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            listarUsuarios();
        }

        private DataSet ds;
        private controladorUsuarios obj = new controladorUsuarios(Login.config);
        private string cuenta;
        private string estado;

        private void BarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // METODO PARA ARRASTRAR FORMULARIO  
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                //Boton salir en el cual se le pregunta al cliente si desea salir del programa
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void listarUsuarios()
        {
            if (txtBusqueda.Text.Trim() == "")
                ds = obj.listarUsuariosCtl();
            else
                ds = obj.listarUsuarios2Ctl(txtBusqueda.Text);

            DataGridUsuarios.DataSource = ds.Tables[0];
            Font negrita = new Font(this.Font, FontStyle.Bold);
            DataGridUsuarios.ColumnHeadersDefaultCellStyle.Font = negrita;
            DataGridUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        { 
            if (txtApellido.Text.Trim() == "" || txtContraseña.Text.Trim() == "" || txtNombre.Text.Trim() == "" || txtUsuario.Text.Trim() == "" || ComboTipo.Text.Trim() == "")
            {
                MessageBox.Show("Complete todo los campos!");
                return;
            }

            if (Validaciones.soloLetras(txtNombre.Text) == false)
            {
                MessageBox.Show("Solo se permiten letras en el campo 'nombres'.");
                txtNombre.Focus();
                return;
            }

            if (Validaciones.soloLetras(txtApellido.Text) == false)
            {
                MessageBox.Show("Solo se permiten letras en el campo 'apellidos'.");
                txtApellido.Focus();
                return;
            }
            if (Validaciones.LetrasNumeros(txtUsuario.Text) == false)
            {
                MessageBox.Show("Solo se permiten letras y numeros en el campo 'Nombre de usuario'.");
                txtApellido.Focus();
                return;
            }

            object[] datosA = { txtUsuario.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(),  txtContraseña.Text.Trim(), ComboTipo.Text.Trim() };

            string error = "";
            if (obj.agregarUsuarioCtl(datosA, ref error))
            {
                MessageBox.Show("Usuario guardado con exito!");

                this.listarUsuarios();
                //this.limpiarCampos();
            }
            else
            {
                if (error.Contains("Duplicate entry"))
                {
                    MessageBox.Show("Error: El nombre de usuario ya esta asignado.");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error inesperado intente de nuevo.");
                }

                return;
            }
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            listarUsuarios();
        }
    }
}
