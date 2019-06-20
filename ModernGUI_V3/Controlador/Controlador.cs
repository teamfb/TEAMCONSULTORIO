﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernGUI_V3.Modelo;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace ModernGUI_V3.Controlador
{
    public class ControlConfig
    {   //Atributos:
        private string _DBMS;       // El motor de base de datos 
        private string _cadconn;    // La cadena de conexión a la base de datos

        public string DBMS { get { return _DBMS; } }        //Propiedad de solo lectura
        public string cadconn { get { return _cadconn; } }  //Propiedad de solo lectura


        //Métodos:
        public ControlConfig(string DBMS, string cadconn)
        {
            this._DBMS = DBMS;
            this._cadconn = cadconn;
        }
    }

    public abstract class ControlBD
    {   //Atributos:
        protected BDMySQL bd;   // Objeto base de datos
        protected string iSql;

        //Métodos:
        public ControlBD()  // Constructor vacío (requisito de la herencia).
        { }
    }

    public class controladorUsuarios : ControlBD
    {
        public controladorUsuarios(ControlConfig _cfg)  // Constructor que asocia un archivo de configuración que ya
        {                                            // fue leído. (Para no releer el config.ini innecesariamente)
            bd = new BDMySQL(_cfg.cadconn);
        }
        private string obtieneMD5(string _txt)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(_txt));
            string result = BitConverter.ToString(hash).Replace("-", "").ToLower();
            return result;
        }

        public bool validarUsuario(string _usu, string _cve)
        {
            string error = "";

            DataRow dr = bd.Leer1Registro("SELECT * FROM usuarios WHERE usuario = '" + _usu + "';", ref error);
            if (error.Contains("Unable to connect"))
            {
                MessageBox.Show("Error al conectar con el servidor de la base de datos");
                Application.Exit();
                return false;
            }
            if (dr == null)
            {
                if (error.Contains("Authentication"))
                {
                    MessageBox.Show("Error al conectar con el servidor, revice la cadena de conexion");
                    return false;
                }
                else
                {
                    MessageBox.Show("Error el usuario no esta registrado");
                    return false;
                }
            }
            else if (error.Contains("No hay ninguna fila"))
            {
                MessageBox.Show("Error el usuario no esta registrado");
                return false;
            }
            else
            {
                //if(_cve == dr["clave"].ToString())
                if (obtieneMD5(_cve) == dr["clave"].ToString())
                {
                    MessageBox.Show("Bienvenido(a) " + _usu);
                    return true;
                }
                else
                {
                    MessageBox.Show("Eroor contraseña invalida");
                    return false;
                }
                //return true;
            }
        }

        public DataSet listarUsuariosCtl()
        {
            iSql = "SELECT usuario, nombres, apellidos,  tipo FROM usuarios ORDER BY nombres ASC";
            return (bd.LeerRegistros(iSql));
        }

        public DataSet listarUsuarios2Ctl(string _dato_a_buscar)
        {
            iSql = "SELECT usuario, nombres, apellidos,  tipo FROM usuarios WHERE nombres LIKE ('" + _dato_a_buscar + "%') ORDER BY nombres ASC";
            return (bd.LeerRegistros(iSql));
        }
        public bool agregarUsuarioCtl(object[] _datos, ref string _error)
        {
            //mandar el nombre de la tabla y de los datos de la tabla al metodo al modelo
            _datos[3] = obtieneMD5(_datos[3].ToString());
            return (bd.InsertarRegistro("usuarios", _datos, ref _error));
        }

        public bool modificarUsuarioCtl(string _tbl, string[] _campos, object[] _datos, string _key, object _valorkey)
        {
            return (bd.ModificarRegistro(_tbl, _campos, _datos, _key, _valorkey));
        }

        public bool modificarUsuarioCtl(string _tbl, string[] _campos, object[] _datos, string _key, object _valorkey, ref string _error)
        {
            if (_datos[3].ToString() == "")
            {

                List<object> list = _datos.ToList();
                List<string> list2 = _campos.ToList();

                list.RemoveAt(3);
                list2.RemoveAt(3);

                return (bd.ModificarRegistro(_tbl, list2.ToArray(), list.ToArray(), _key, _valorkey, ref _error));
            }
            else
            {
                _datos[3] = obtieneMD5(_datos[3].ToString());
                return (bd.ModificarRegistro(_tbl, _campos, _datos, _key, _valorkey, ref _error));
            }
        }

        public bool eliminarUsuarioCtl(string _usr)
        {
            return (bd.EjecutarSQL("DELETE FROM usuarios WHERE usuario = '" + _usr + "';"));
        }

        public bool eliminarUsuarioCtl(string _clave, ref string _error)
        {
            return this.bd.EjecutarSQL("DELETE FROM usuarios WHERE usuario ='" + _clave + "';", ref _error);
        }
    }

    public class controladorConsultas : ControlBD
    {
        public controladorConsultas(ControlConfig _cfg)  // Constructor que asocia un archivo de configuración que ya
        {                                            // fue leído. (Para no releer el config.ini innecesariamente)
            bd = new BDMySQL(_cfg.cadconn);
        }
        //metodo para hacer un ficticio autoincrement en la bd pero mediante c# reinventar la rueda ._.
        public int sigNumeroUsuarioCtl()
        {
            int sgte = Convert.ToInt32(bd.LeerNumerico("SELECT MAX(id_consulta) FROM consultas;")) + 1;
            return (sgte);
        }
        public bool agregarConsultaCtl(object[] _datos)
        {
            //mandar el nombre de la tabla y de los datos de la tabla al metodo al 
            return (bd.InsertarRegistro("consultas", _datos));
        }

        public bool usuarioExistenteCtl(string usuario)
        {
            string error = "";
            DataRow registro = bd.Leer1Registro("SELECT * FROM usuarios WHERE usuario='" + usuario + "';", ref error);
            if (error != "") return false;
            else return true;
        }

    }

}
