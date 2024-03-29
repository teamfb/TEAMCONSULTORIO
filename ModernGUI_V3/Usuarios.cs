﻿using System;
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
            this.listarUsuarios();
        }

        private DataSet ds;
        private controladorUsuarios obj = new controladorUsuarios(Login.config);
        private string usuario = "";
  
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
           

            object[] datosA = { txtUsuario.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(),  txtContraseña.Text.Trim(), ComboTipo.Text.Trim() };

            string error = "";
            if (obj.agregarUsuarioCtl(datosA, ref error))
            {
                MessageBox.Show("Usuario guardado con exito!");

                this.listarUsuarios();
                this.limpiarCampos();
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

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            listarUsuarios();
        }

        private void limpiarCampos()
        {
            this.usuario = "";
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtContraseña.Text = "";
            ComboTipo.Text = "";
        }
          
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text.Trim() == ""  || txtNombre.Text.Trim() == "" || txtUsuario.Text.Trim() == "" || ComboTipo.Text.Trim() == "")
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

            object[] datosB = { txtUsuario.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtContraseña.Text.Trim(), ComboTipo.Text.Trim() };

            string[] campos = { "usuario", "nombres", "apellidos", "clave", "tipo" };

            string error = "";

            if (obj.modificarUsuarioCtl("usuarios", campos, datosB, "usuario", this.usuario, ref error))
            {
                MessageBox.Show("Los datos del usaurios han sido modificados con exito!");
                this.listarUsuarios();
                this.limpiarCampos();
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

        private void DataGridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.usuario = DataGridUsuarios[0, DataGridUsuarios.CurrentRow.Index].Value.ToString();
            txtUsuario.Text = DataGridUsuarios[0, DataGridUsuarios.CurrentRow.Index].Value.ToString();
            txtNombre.Text = DataGridUsuarios[1, DataGridUsuarios.CurrentRow.Index].Value.ToString();
            txtApellido.Text = DataGridUsuarios[2, DataGridUsuarios.CurrentRow.Index].Value.ToString();
            ComboTipo.Text = DataGridUsuarios[3, DataGridUsuarios.CurrentRow.Index].Value.ToString();
        }

        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            if (this.usuario == "")
            {
                MessageBox.Show("Por favor seleccione un registro de la lista.",
                 "Error",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1);

                 return;
            }

            string text2 = "";
            DialogResult dialogResult = MessageBox.Show(string.Concat(new object[]
            {
                "¿Está seguro(a) de que desea ELIMINAR el registro del usuario? \n\n",
                this.usuario,
            }), "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool flag = dialogResult == DialogResult.Yes;
            if (flag)
            {
                this.obj.eliminarUsuarioCtl(this.usuario, ref text2);
                bool flag2 = text2.Contains("foreign key constrain");
                if (flag2)
                {
                    MessageBox.Show("El usuario no se puede eliminar porque tiene registros asociados.");
                }
                else
                {
                    bool flag3 = text2 != "";
                    if (flag3)
                    {
                        MessageBox.Show(text2);
                    }
                    else
                    {
                        this.listarUsuarios();
                        this.limpiarCampos();
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.usuario == "")
            {
                MessageBox.Show("Por favor seleccione un registro de la lista.",
                 "Error",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error,
                 MessageBoxDefaultButton.Button1);

                return;
            }

            string text2 = "";
            DialogResult dialogResult = MessageBox.Show(string.Concat(new object[]
            {
                "¿Está seguro(a) de que desea ELIMINAR el registro del usuario? \n\n",
                this.usuario,
            }), "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool flag = dialogResult == DialogResult.Yes;
            if (flag)
            {
                this.obj.eliminarUsuarioCtl(this.usuario, ref text2);
                bool flag2 = text2.Contains("foreign key constrain");
                if (flag2)
                {
                    MessageBox.Show("El usuario no se puede eliminar porque tiene registros asociados.");
                }
                else
                {
                    bool flag3 = text2 != "";
                    if (flag3)
                    {
                        MessageBox.Show(text2);
                    }
                    else
                    {
                        this.listarUsuarios();
                        this.limpiarCampos();
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void BtnLimpiar2_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text.Trim() == "" || txtNombre.Text.Trim() == "" || txtUsuario.Text.Trim() == "" || ComboTipo.Text.Trim() == "")
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

            object[] datosB = { txtUsuario.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtContraseña.Text.Trim(), ComboTipo.Text.Trim() };

            string[] campos = { "usuario", "nombres", "apellidos", "clave", "tipo" };

            string error = "";

            if (obj.modificarUsuarioCtl("usuarios", campos, datosB, "usuario", usuario, ref error))
            {
                MessageBox.Show("Los datos del usaurios han sido modificados con exito!");
                this.listarUsuarios();
                this.limpiarCampos();
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

        private void BtnAgregar_Click(object sender, EventArgs e)
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


            object[] datosA = { txtUsuario.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtContraseña.Text.Trim(), ComboTipo.Text.Trim() };

            string error = "";
            if (obj.agregarUsuarioCtl(datosA, ref error))
            {
                MessageBox.Show("Usuario guardado con exito!");

                this.listarUsuarios();
                this.limpiarCampos();
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

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}