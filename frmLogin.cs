using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;

namespace VitalLabSoft
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            string ruta = Path.GetDirectoryName(Environment.CurrentDirectory) + "\\config";
            if (File.Exists(ruta))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(ruta);
                string[] archivo = file.ReadLine().Split('$');
                for (int i = 0; i < 5; i++)
                {
                    Program.infoConexion[i] = Program.deCodifica(archivo[i]);
                }
                file.Close();
                if (probarConexion(Program.infoConexion))
                {
                    Program.infoConexion[0] = Program.infoConexion[0];
                    Program.infoConexion[1] = Program.infoConexion[1];
                    Program.infoConexion[2] = Program.infoConexion[2];
                    Program.infoConexion[3] = Program.infoConexion[3];
                    Program.infoConexion[4] = Program.infoConexion[4];
                }
                else
                {
                    sinConexion();
                }
            }
            else
            {
                sinConexion();
            }
        }
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acceso();
            }
        }
        private bool probarConexion(string[] info)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader lee;
            bool Salida = false;
            try
            {
                cnn = new SqlConnection("Server=" + info[0] + "; database=" + info[3] + "; user=" + info[1] + "; pwd=" + info[2]);
                cnn.Open();
                try
                {
                    cmd = new SqlCommand("select sconexion from conexion", cnn);
                    lee = cmd.ExecuteReader();
                    if (lee.Read())
                    {
                        Salida = true;
                        Program.textoBitacora = "Conectado a " + info[0];
                    }
                    lee.Close();
                }
                catch (Exception ex1)
                {
                    // MessageBox.Show("Ocurrio el siguiente error al intentar cargar los datos:\n" + ex1.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                cnn.Close();
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Ocurrio el siguiente error al intentar conectar con la base de datos:\n" + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return Salida;
        }
        private void sinConexion()
        {
            MessageBox.Show("Para tener accesos a las características del sistema, necesita una conexión a base de datos. Favor de llenar el siguiente formulario.", "Configure conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmConServidor oConexion = new frmConServidor();
            oConexion.ShowDialog();
            if (Program.infoConexion[0] == "")
            {
                MessageBox.Show("No se pudo establecer la conexión, la aplicación se cerrará. Contacte al administrador del sistema.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.textoBitacora = "Conexión al servidor";
                this.Close();
            }
            else
            {
                if (!probarConexion(Program.infoConexion))
                {
                    MessageBox.Show("No se pudo establecer la conexión, favor de revisar los datos en el menú Configuración -> Conexión al servidor", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            acceso();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void acceso()
        {
            Program.infoUsuarioConectado = ExtraerDato.CadenaArrayFila("select idUsuario, nUsuario, Permisos, correo, idempleado from usuarios where nUsuario = '" + txtUsuario.Text.ToUpper().ToString() + "' and pass = '" + Program.codificaSHA1(txtPass.Text.Trim()) + "'");
            string idUsuario;
            try
            {
                idUsuario = Program.infoUsuarioConectado[0].ToString();
            }
            catch
            {
                idUsuario = "";
            }
            if (idUsuario != "")
            {
                ExtraerDato.AccionQuery("insert into bitacora (usuarioWin, tarea, fechaHora, formulario, usuarioSis) values ('" + WindowsIdentity.GetCurrent().Name + "','Inició Sesión.','" + Program.FormateoFechaHora(DateTime.Now) + "', '" + this.Name.ToString() + "', '" + Program.infoUsuarioConectado[1] + "')");
                frmVitalLabSoft oSG = new frmVitalLabSoft();
                oSG.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Verifique el nombre de usuario y la contraseña", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPass.Text = "";
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtUsuario = Program.evaluaCamposFuerte(txtUsuario);
        }
    }
}
