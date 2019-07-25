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
            RadioCompleto.Checked = true;
            RadioBuena.Checked = true;
            Radiobuen.Checked = true;

        }

        private DateTime localDate = DateTime.Now;
        private DataSet ds;
        private controladorPacientes obj = new controladorPacientes(Login.config);
        private controladorAntFamiliares obj2 = new controladorAntFamiliares(Login.config);
        private controladorAntNoPatologicos obj3 = new controladorAntNoPatologicos(Login.config);
        private controladorAntPatologicos obj4 = new controladorAntPatologicos(Login.config);
        private controladorAntAparatos obj5 = new controladorAntAparatos(Login.config);
        private controladorAntGinecolo obj6 = new controladorAntGinecolo(Login.config);
        private int folio = 0;
        private string sexo;
        private int id_antecedente;
        private int id_antecedente2;
        private int id_antecedente3;
        private int id_antecedente4;
        private int id_antecedente5;
        private string vacunacion;
        private string higiene;
        private string alimentacion;
        private string familiares = "";
        private string familiares2 = "";
        private string familiares3 = "";
        private string insuficienciaIntra;
        private string plan_familiar = "";
        private string prop_lactancia = "";
        private string cancer_matriz = "";
        private string cancer_mama = "";


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
            this.agregarPaciente();
        }

        public void agregarPaciente()
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

            obj.agregarPacienteCtl(datosP);
            //aqui terminar el guardado de la tabla pacientes.

            //aqui comienza la recoleccion de datos para el guardado de la tabla ant_familiares
            this.id_antecedente = int.Parse(obj2.sigNumeroAntFamiliarCtl().ToString());
            object[] datosAntFam1 = { this.id_antecedente, this.folio, "Padre", ComboPadre.Text, txtDiabPadre.Text, txtCardioPadre.Text, txtCancerPadre.Text, txtObesiPadre.Text, txtTubePadre.Text, txtAlerPadre.Text, txtVeneroPadre.Text };
            object[] datosAntFam2 = { this.id_antecedente + 1, this.folio, "Madre", ComboMadre.Text, txtDiabMadre.Text, txtCardioMadre.Text, txtCancerMadre.Text, txtObesiMadre.Text, txtTubeMadre.Text, txtAlerMadre.Text, txtVeneroMadre.Text };
            object[] datosAntFam3 = { this.id_antecedente + 2, this.folio, "Conyuge", ComboConyu.Text, txtDiabConyu.Text, txtCardioPadre.Text, txtCancerConyu.Text, txtObesiConyu.Text, txtTubeConyu.Text, txtAlerConyu.Text, txtVeneroConyu.Text };
            object[] datosAntFam4 = { this.id_antecedente + 3, this.folio, "Hijos", ComboHijo.Text, txtDiabHijos.Text, txtCardioHijo.Text, txtCancerHijos.Text, txtObesiHijos.Text, txtTubeHijo.Text, txtAlerHijo.Text, txtVeneroHijo.Text };
            object[] datosAntFam5 = { this.id_antecedente + 4, this.folio, "Hermanos", ComboHermano.Text, txtDiabHermano.Text, txtCardioHermano.Text, txtCancerHermanos.Text, txtObesiHermano.Text, txtTubeHermano.Text, txtAlerHermano.Text, txtVeneroHermano.Text };
            object[] datosAntFam6 = { this.id_antecedente + 5, this.folio, "Abuelos", ComboAbuelo.Text, txtDiabAbue.Text, txtCardioAbuelos.Text, txtCancerAbuelos.Text, txtObesiAbuelos.Text, txtTubeAbuelos.Text, txtAlerAbuelos.Text, txtVeneroAbuelos.Text };
            object[] datosAntFam7 = { this.id_antecedente + 6, this.folio, "Tios", ComboTios.Text, txtDiabTios.Text, txtCardioTios.Text, txtCancerTios.Text, txtObesiTios.Text, txtTubeTios.Text, txtAlerTios.Text, txtVeneroTios.Text };
            //aqui termina la recoleccion de datos para el guardado de la tabla ant_familiares

            //aqui comienza la recoleccion de datos para el guardado de la tabla ant_no_pato
            if (RadioCompleto.Checked)
                this.vacunacion = "Completo";
            else
                this.vacunacion = "Incompleto";

            if (RadioBuena.Checked)
                this.higiene = "Buena";
            if (RadioRegular.Checked)
                this.higiene = "Regular";
            if (RadioMala.Checked)
                this.higiene = "Mala";


            if (Radiobuen.Checked)
                this.alimentacion = "Buena";
            if (RadioRegula.Checked)
                this.alimentacion = "Regular";
            if (RadioMal.Checked)
                this.alimentacion = "Mala";

            if (CheckAlcohol.Checked)
                this.familiares2 = "Alcoholismo";
            if (CheckTabaco.Checked)
                this.familiares2 = "Tabaquismo";
            if (CheckAlcohol.Checked && CheckTabaco.Checked)
                this.familiares2 = "Alcoholismo y tabaquismo";


            this.id_antecedente2 = int.Parse(obj3.sigNumeroAntNoPatoCtl().ToString());

            object[] datosAntNoPato = { this.id_antecedente2, this.folio, this.vacunacion, this.higiene, this.alimentacion, this.familiares2, txtAlco.Text, txtTaba.Text, txtTaxo.Text, txtQuir.Text, txtTran.Text, txtAle.Text };
            //aqui termina la recoleccion de datos para el guardado de la tabla ant_no_pato

            //aqui comienza la recoleccion de datos para el guardado de la tabla ant_pato
            if (CheckHipe.Checked)
                this.familiares = "Hipertencion";
            if (CheckDia.Checked)
                this.familiares = "Diabetes mellitus";
            if (CheckInsu.Checked)
                this.familiares = "Insuficiencia intravenosa";

            if (CheckHipe.Checked && CheckDia.Checked)
                this.familiares = "Hipertencion y diabetes mellitus";
            if (CheckHipe.Checked && CheckInsu.Checked)
                this.familiares = "Hipertencion e insuficiencia intravenosa";
            if (CheckDia.Checked && CheckInsu.Checked)
                this.familiares = "Diabetes mellitus e insuficiencia intravenosa";

            if (CheckHipe.Checked && CheckDia.Checked && CheckInsu.Checked)
                this.familiares = "Hipertencion, insuficiencia intravenosa y diabetes mellitus";

            if (CheckIntra.Checked)
                this.insuficienciaIntra = "Si";
            else
                this.insuficienciaIntra = "No";

            this.id_antecedente3 = int.Parse(obj4.sigNumeroAntPatoCtl().ToString());

            object[] datosAntPato = { this.id_antecedente3, this.folio, txtCardio.Text, txtEndo.Text, this.familiares, this.insuficienciaIntra, txtMusc.Text, txtNeu.Text, txtNeo.Text, txtMusObes.Text, txtPsi.Text, txtGas.Text, txtHema.Text, txtVene.Text, txtHepa.Text };
            //aqui termina la recoleccion de datos para el guardado de la tabla ant_pato

            //aqui comienza la recoleccion de datos para el guardado de la tabla ant_aparatos

            this.id_antecedente4 = int.Parse(obj5.sigNumeroAntAparatosCtl().ToString());
            object[] datosAntAparatos = { this.id_antecedente4, this.folio, txtPadeAct.Text, txtEndocrino.Text, txtSintomas.Text, txtUrinario.Text, txtCircularorio.Text, txtPsiquico.Text, txtLinfSang.Text, txtPielMucosas.Text, txtNervioso.Text, txtMusculoEsque.Text, txtGenital.Text };
            //aqui termina la recoleccion de datos para el guardado de la tabla ant_aparatos

            //aqui comienza la recoleccion de datos para el guardado de la tabla ant_ginecolo

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "yyyy-MM-dd";

            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "yyyy-MM-dd";

            if (!checkPlanFam.Checked)
                this.plan_familiar = "";
            else
            {
                if (checkHormonal.Checked)
                    this.plan_familiar = "Hormonal";

                if (checkInyectable.Checked)
                    this.plan_familiar = "Inyectable";

                if (checkQuirurgico.Checked)
                    this.plan_familiar = "Quirurgico";

                if (checkBaja.Checked)
                    this.plan_familiar = "Baja";

                if (checkOral.Checked)
                    this.plan_familiar = "Oral";

                if (checkDiu.Checked)
                    this.plan_familiar = "Diu";

                if (checkLocal.Checked)
                    this.plan_familiar = "Local";


                if (checkHormonal.Checked && checkInyectable.Checked)
                    this.plan_familiar = "Hormonal e inyectable";

                if (checkHormonal.Checked && checkQuirurgico.Checked)
                    this.plan_familiar = "Hormonal y quirurgico";

                if (checkHormonal.Checked && checkBaja.Checked)
                    this.plan_familiar = "Hormonal y baja";

                if (checkHormonal.Checked && checkOral.Checked)
                    this.plan_familiar = "Hormonal y oral";

                if (checkHormonal.Checked && checkDiu.Checked)
                    this.plan_familiar = "Hormonal y diu";

                if (checkHormonal.Checked && checkLocal.Checked)
                    this.plan_familiar = "Hormonal y local";


                if (checkQuirurgico.Checked && checkInyectable.Checked)
                    this.plan_familiar = "Inyectable y quirurgico";

                if (checkBaja.Checked && checkInyectable.Checked)
                    this.plan_familiar = "Inyectable y baja";

                if (checkOral.Checked && checkInyectable.Checked)
                    this.plan_familiar = "Inyectable y oral";

                if (checkDiu.Checked && checkInyectable.Checked)
                    this.plan_familiar = "Inyectable y diu";

                if (checkLocal.Checked && checkInyectable.Checked)
                    this.plan_familiar = "Inyectable y local";


                if (checkQuirurgico.Checked && checkBaja.Checked)
                    this.plan_familiar = "Quirurgico y baja";

                if (checkQuirurgico.Checked && checkOral.Checked)
                    this.plan_familiar = "Quirurgico y oral";

                if (checkQuirurgico.Checked && checkDiu.Checked)
                    this.plan_familiar = "Quirurgico y diu";

                if (checkQuirurgico.Checked && checkLocal.Checked)
                    this.plan_familiar = "Quirurgico y local";


                if (checkOral.Checked && checkBaja.Checked)
                    this.plan_familiar = "Baja y oral";

                if (checkDiu.Checked && checkBaja.Checked)
                    this.plan_familiar = "Baja y diu";

                if (checkLocal.Checked && checkBaja.Checked)
                    this.plan_familiar = "Baja y local";


                if (checkOral.Checked && checkDiu.Checked)
                    this.plan_familiar = "Oral y diu";

                if (checkOral.Checked && checkLocal.Checked)
                    this.plan_familiar = "Oral y local";


                if (checkLocal.Checked && checkDiu.Checked)
                    this.plan_familiar = "Diu y local";


                //aqui faltan un millon de combinaciones :v
                if (checkHormonal.Checked && checkInyectable.Checked && checkQuirurgico.Checked && checkBaja.Checked && checkOral.Checked && checkDiu.Checked && checkLocal.Checked)
                    this.plan_familiar = "Hormonal, inyectable, quirurgico, baja, oral, diu y local";
            }

            if (checkLactancia.Checked)
                this.prop_lactancia = "Si";
            else
                this.prop_lactancia = "No";


            if (checkCancerMatriz.Checked)
                this.cancer_matriz= "Si";
            else
                this.cancer_matriz = "No";

            if (checkCancerMama.Checked)
                this.cancer_mama = "Si";
            else
                this.cancer_mama = "No";

            if (checkBox12.Checked)
                this.familiares3 = "Cancer de mama";

            if (checkBox13.Checked)
                this.familiares3 = "Cancer de mamtriz";

            if (checkBox13.Checked && checkBox12.Checked)
                this.familiares3 = "Cancer de mamtriz y cancer de mama";


            this.id_antecedente5 = int.Parse(obj6.sigNumeroAntGinecoloCtl().ToString());
            object[] datosAntGinecolo = { this.id_antecedente5, this.folio, textBox1.Text, textBox2.Text, dateTimePicker1.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, dateTimePicker2.Text, textBox10.Text, dateTimePicker3.Text, textBox11.Text, this.plan_familiar,textBox12.Text,textBox13.Text,textBox14.Text, dateTimePicker4.Text, this.prop_lactancia, this.cancer_matriz, this.cancer_mama, this.familiares3};
            //aqui termina la recoleccion de datos para el guardado de la tabla ant_ginecolo

            if (obj2.agregarAntFamiliarCtl(datosAntFam1, datosAntFam2, datosAntFam3, datosAntFam4, datosAntFam5, datosAntFam6, datosAntFam7) && obj3.agregarAntNoPatoCtl(datosAntNoPato) && obj4.agregarAntPatoCtl(datosAntPato) && obj5.agregarAntAparatosCtl(datosAntAparatos) && obj6.agregarAntGinecoloCtl(datosAntGinecolo))
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

        private void BtnAgregar2_Click(object sender, EventArgs e)
        {
            this.agregarPaciente();
        }

        private void BtnAgreg_Click(object sender, EventArgs e)
        {
            this.agregarPaciente();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void BtnLimpiar3_Click(object sender, EventArgs e)
        {
            this.limpiarCamposNoPato();
        }

        private void limpiarCamposNoPato()
        {

        }

        private void limpiarCamposAntFami()
        {

        }

        private void limpiarCamposAparatos()
        {

        }

        private void limpiarCamposGinecolo()
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            limpiarCamposAntFami();
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            this.agregarPaciente();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.limpiarCamposAparatos();
        }

        private void BtnElimina_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button25_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            this.agregarPaciente();
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            this.limpiarCamposGinecolo();
        }
    }
}