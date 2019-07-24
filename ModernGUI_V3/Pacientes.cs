using ModernGUI_V3.Controlador;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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

        private DateTime localDate = DateTime.Now;
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

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" || txtEdad.Text.Trim() == "")
            {
                MessageBox.Show("El campo nombre y edad son obligatorios!");
                return;
            }

            if (Validaciones.soloLetras(txtNombre.Text) == false)
            {
                MessageBox.Show("Solo se permiten letras en el campo 'Nombre'.");
                txtNombre.Focus();
                return;
            }

            if (Validaciones.soloLetras(txtOcupacion.Text) == false && txtOcupacion.Text != "")
            {
                MessageBox.Show("Solo se permiten letras en el campo 'Ocupacion'.");
                txtOcupacion.Focus();
                return;
            }

            if (Validaciones.soloLetras(txtEscolaridad.Text) == false && txtEscolaridad.Text != "")
            {
                MessageBox.Show("Solo se permiten letras en el campo 'Escolaridad'.");
                txtEscolaridad.Focus();
                return;
            }

            if (Validaciones.soloLetras(txtReligion.Text) == false && txtReligion.Text != "")
            {
                MessageBox.Show("Solo se permiten letras en el campo 'Religion'.");
                txtReligion.Focus();
                return;
            }

            if (Validaciones.soloDigitos(txtEdad.Text) == false)
            {
                MessageBox.Show("Solo se permiten numeros en el campo 'Edad'.");
                txtEdad.Focus();
                return;
            }

            if (Validaciones.soloLetras(txtLugar.Text) == false && txtLugar.Text != "")
            {
                MessageBox.Show("Solo se permiten letras en el campo 'Lugar de nacimiento'.");
                txtLugar.Focus();
                return;
            }

            DateTimeFecha.Format = DateTimePickerFormat.Custom;
            DateTimeFecha.CustomFormat = "yyyy-MM-dd";

            this.folio = Convert.ToInt32(txtFolio.Text.Trim());

            if (RadioF.Checked)
                this.sexo = "Femenino";
            else
                this.sexo = "Masculino";

            object[] datosP = { this.folio, txtNombre.Text.Trim(), this.sexo, txtSangre.Text.Trim(), DateTimeFecha.Text.Trim(), txtDomicilio.Text.Trim(), txtOcupacion.Text.Trim(), txtEscolaridad.Text.Trim(), cboEdoCivil.Text.Trim(), txtReligion.Text.Trim(), txtEdad.Text.Trim(), txtLugar.Text.Trim(), txtTelefono.Text.Trim() };

            if (obj.agregarPacienteCtl(datosP))
            {
                MessageBox.Show("Usuario guardado con exito!");
                this.listarPacientes();
                this.limpiarCampos();
                txtFolio.Text = obj.sigNumeroUsuarioCtl().ToString();
            }
            else
                MessageBox.Show("Ocurrio un error inesperado intente de nuevo.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "" || txtEdad.Text.Trim() == "")
            {
                MessageBox.Show("El campo nombre y edad son obligatorios!");
                return;
            }

            if (Validaciones.soloLetras(txtNombre.Text) == false)
            {
                MessageBox.Show("Solo se permiten letras en el campo 'Nombre'.");
                txtNombre.Focus();
                return;
            }

            if (Validaciones.soloLetras(txtOcupacion.Text) == false && txtOcupacion.Text != "")
            {
                MessageBox.Show("Solo se permiten letras en el campo 'Ocupacion'.");
                txtOcupacion.Focus();
                return;
            }

            if (Validaciones.soloLetras(txtEscolaridad.Text) == false && txtEscolaridad.Text != "")
            {
                MessageBox.Show("Solo se permiten letras en el campo 'Escolaridad'.");
                txtEscolaridad.Focus();
                return;
            }

            if (Validaciones.soloLetras(txtReligion.Text) == false && txtReligion.Text != "")
            {
                MessageBox.Show("Solo se permiten letras en el campo 'Religion'.");
                txtReligion.Focus();
                return;
            }

            if (Validaciones.soloDigitos(txtEdad.Text) == false)
            {
                MessageBox.Show("Solo se permiten numeros en el campo 'Edad'.");
                txtEdad.Focus();
                return;
            }

            if (Validaciones.soloLetras(txtLugar.Text) == false && txtLugar.Text != "")
            {
                MessageBox.Show("Solo se permiten letras en el campo 'Lugar de nacimiento'.");
                txtLugar.Focus();
                return;
            }

            DateTimeFecha.Format = DateTimePickerFormat.Custom;
            DateTimeFecha.CustomFormat = "yyyy-MM-dd";

            if (RadioF.Checked)
                this.sexo = "Femenino";
            else
                this.sexo = "Masculino";

            object[] datosP = { this.folio, txtNombre.Text.Trim(), this.sexo, txtSangre.Text.Trim(),
                                DateTimeFecha.Text.Trim(), txtDomicilio.Text.Trim(), txtOcupacion.Text.Trim(),
                                txtEscolaridad.Text.Trim(), cboEdoCivil.Text.Trim(), txtReligion.Text.Trim(),
                                txtEdad.Text.Trim(), txtLugar.Text.Trim(), txtTelefono.Text.Trim() };

            string[] campos = { "folio","nombre","sexo","tipo_sangre","fecha_naci",
                                "domicilio","ocupacion","escolaridad","estado_civil",
                                "religion","edad","lugar_naci","telefono" };

            if (obj.modificarPacienteCtl("pacientes", campos, datosP, "folio", this.folio))
            {
                MessageBox.Show("Paciente actualizado con exito!");
                this.listarPacientes();
                this.limpiarCampos();
            }
            else
                MessageBox.Show("Ocurrio un error inesperado intente de nuevo.");
        }

        private void limpiarCampos()
        {
            this.folio = 0;
            txtFolioSelec.Text = "";
            txtNombre.Text = "";
            RadioF.Checked = true;
            txtSangre.Text = "";
            DateTimeFecha.Text = this.localDate.ToString();
            txtDomicilio.Text = "";
            txtOcupacion.Text = "";
            txtEscolaridad.Text = "";
            cboEdoCivil.Text = "";
            txtReligion.Text = "";
            txtEdad.Text = "";
            txtLugar.Text = "";
            txtTelefono.Text = "";
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
            txtFolioSelec.Text = DataGridPacientes[0, DataGridPacientes.CurrentRow.Index].Value.ToString();
            txtNombre.Text = DataGridPacientes[1, DataGridPacientes.CurrentRow.Index].Value.ToString();
            this.sexo = DataGridPacientes[2, DataGridPacientes.CurrentRow.Index].Value.ToString();

            if (sexo == "Femenino")
                RadioF.Checked = true;
            else
                RadioM.Checked = true;

            txtSangre.Text = DataGridPacientes[3, DataGridPacientes.CurrentRow.Index].Value.ToString();
            DateTimeFecha.Text = DataGridPacientes[4, DataGridPacientes.CurrentRow.Index].Value.ToString();
            txtDomicilio.Text = DataGridPacientes[5, DataGridPacientes.CurrentRow.Index].Value.ToString();
            txtOcupacion.Text = DataGridPacientes[6, DataGridPacientes.CurrentRow.Index].Value.ToString();
            txtEscolaridad.Text = DataGridPacientes[7, DataGridPacientes.CurrentRow.Index].Value.ToString();
            cboEdoCivil.Text = DataGridPacientes[8, DataGridPacientes.CurrentRow.Index].Value.ToString();
            txtReligion.Text = DataGridPacientes[9, DataGridPacientes.CurrentRow.Index].Value.ToString();
            txtEdad.Text = DataGridPacientes[10, DataGridPacientes.CurrentRow.Index].Value.ToString();
            txtLugar.Text = DataGridPacientes[11, DataGridPacientes.CurrentRow.Index].Value.ToString();
            txtTelefono.Text = DataGridPacientes[12, DataGridPacientes.CurrentRow.Index].Value.ToString();
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.listarPacientes();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

       
    }
}
