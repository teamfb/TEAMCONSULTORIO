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
    public partial class Pacientes : Form
    {
        public Pacientes()
        {
            InitializeComponent();
            txtFolio.Text = obj.sigNumeroUsuarioCtl().ToString();
            this.listarPacientes();
            RadioF.Checked = true;
        }
        
        private DataSet ds;
        private controladorPacientes obj = new controladorPacientes(Login.config);
        private int folio = 0;
        private string sexo;

        private void listarPacientes()
        {
            if (txtBusqueda.Text.Trim() == "")
                ds = obj.listarPacientesCtl();
            else
                ds = obj.listarPacientes2Ctl(txtBusqueda.Text);

            DataGridPacientes.DataSource = ds.Tables[0];
            Font negrita = new Font(this.Font, FontStyle.Bold);
            DataGridPacientes.ColumnHeadersDefaultCellStyle.Font = negrita;
            DataGridPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void BarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

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

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" || txtEdad.Text.Trim() == "" )
            {
                MessageBox.Show("El campo nombre y edad son obligatorios!");
                return;
            }

            DateTimeFecha.Format = DateTimePickerFormat.Custom;
            DateTimeFecha.CustomFormat = "yyyy-MM-dd";

            this.folio = Convert.ToInt32(txtFolio.Text.Trim());
        
            if (RadioF.Checked)
                this.sexo = "Femenimo";
            else
                this.sexo = "Masculino";

            object[] datosP = { this.folio, txtNombre.Text.Trim(), this.sexo, txtSangre.Text.Trim(), DateTimeFecha.Text.Trim(), txtDomicilio.Text.Trim(), txtOcupacion.Text.Trim(), txtEscolaridad.Text.Trim(), cboEdoCivil.Text.Trim(), txtReligion.Text.Trim(), txtEdad.Text.Trim(), txtLugar.Text.Trim(), txtTelefono.Text.Trim()};

            if (obj.agregarConsultaCtl(datosP))
            {
                MessageBox.Show("Usuario guardado con exito!");
                this.listarPacientes();
                this.limpiarCampos();
            }
            else
                MessageBox.Show("Ocurrio un error inesperado intente de nuevo.");
        }

        private void limpiarCampos()
        {
            this.folio = 0;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.folio < 1)
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
                "¿Está seguro(a) de que desea ELIMINAR el paciente del folio: \n\n",
                this.folio, " ?"
            }), "ATENCIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool flag = dialogResult == DialogResult.Yes;
            if (flag)
            {
                this.obj.eliminarPacienteCtl(this.folio, ref text2);
                bool flag2 = text2.Contains("foreign key constrain");
                if (flag2)
                {
                    MessageBox.Show("El paciente no se puede eliminar porque tiene registros asociados.");
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
                        this.listarPacientes();
                        this.limpiarCampos();
                    }
                }
            }
        }

        private void DataGridPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.folio = int.Parse(DataGridPacientes[0, DataGridPacientes.CurrentRow.Index].Value.ToString());
            //txtUsuario.Text = DataGridPacientes[0, DataGridPacientes.CurrentRow.Index].Value.ToString();
            //txtNombre.Text = DataGridPacientes[1, DataGridPacientes.CurrentRow.Index].Value.ToString();
            //txtApellido.Text = DataGridPacientes[2, DataGridPacientes.CurrentRow.Index].Value.ToString();
            //ComboTipo.Text = DataGridPacientes[3, DataGridPacientes.CurrentRow.Index].Value.ToString();
        }
    }
}
