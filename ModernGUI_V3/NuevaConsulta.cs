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
    public partial class NuevaConsulta : Form
    {
        public NuevaConsulta()
        {
            InitializeComponent();
            txtId.Text = obj.sigNumeroUsuarioCtl().ToString();
        }
        
        private controladorConsultas obj = new controladorConsultas(Login.config);

        private int id_consulta;

        private bool usuarioExistente = false;

        //nos quedamos en validar en que el usuario tecleado exista para poder realizar la consulta.

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


   
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                //Boton salir en el cual se le pregunta al cliente si desea salir del programa
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
            FormPrincipal log = new FormPrincipal();
            log.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (txtNombre.Text.Trim() == "" || txtA.Text.Trim() == "" || txtO.Text.Trim() == "" || txtP.Text.Trim() == "" || txtPlan.Text.Trim() == "" || txtS.Text.Trim() == ""|| txtSub.Text.Trim() == "")
            //{
            //    MessageBox.Show("Complete todo los campos!");
            //    return;
            //}
            DateTimeFecha.Format = DateTimePickerFormat.Custom;
            DateTimeFecha.CustomFormat = "yyyy-MM-dd";

            this.id_consulta =  Convert.ToInt32(txtId.Text.Trim());

            object[] datosA = {id_consulta , txtNombre.Text.Trim(), txtS.Text.Trim(), txtO.Text.Trim(), txtA.Text.Trim(), txtP.Text.Trim(), txtPlan.Text.Trim(), txtSub.Text.Trim(), DateTimeFecha.Text.Trim() };

            if (obj.agregarConsultaCtl(datosA))
            {
                MessageBox.Show("Usuario guardado con exito!");
                this.limpiarCampos();
            }
            else
                MessageBox.Show("Ocurrio un error inesperado intente de nuevo.");
        }

        public void limpiarCampos()
        {

        }

        private void NuevaConsulta_Load(object sender, EventArgs e)
        {
            DateTimeFecha.Format = DateTimePickerFormat.Custom;
            DateTimeFecha.CustomFormat = "yyyy-MM-dd";
        }

        private void txtS_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if(txtNombre.Text != "")
            {
                lavelUsuarioRegistrado.Visible = true;
            }
            else
            {
                lavelUsuarioRegistrado.Visible = false;
            }
            this.usuarioExistente = obj.usuarioExistenteCtl(txtNombre.Text.Trim());
            if (this.usuarioExistente)
            {
                lavelUsuarioRegistrado.Text = "Usuario existente";
                lavelUsuarioRegistrado.ForeColor = Color.LimeGreen;
                txtA.Enabled = true;
                txtO.Enabled = true;
                txtP.Enabled = true;
                txtS.Enabled = true;
                txtPlan.Enabled = true;
            }
            else
            { 
                lavelUsuarioRegistrado.Text = "Usuario no registrado";
                lavelUsuarioRegistrado.ForeColor = Color.Red;
                txtA.Enabled = false;
                txtO.Enabled = false;
                txtP.Enabled = false;
                txtS.Enabled = false;
                txtPlan.Enabled = false;
            }
        }
    }
}
