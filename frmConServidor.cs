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

namespace VitalLabSoft
{
    public partial class frmConServidor : Form
    {
        string conexion;
        public frmConServidor()
        {
            InitializeComponent();
        }
        private void frmConServidor_Load(object sender, EventArgs e)
        {
            txtInstancia.Text = Program.infoConexion[0];
            txtUsuario.Text = Program.infoConexion[1];
            txtPass.Text = Program.infoConexion[2];
            txtBD.Text = Program.infoConexion[3];
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnProbar_Click(object sender, EventArgs e)
        {
            if (txtBD.Text.Trim() != "" | txtInstancia.Text.Trim() != "" | txtPass.Text.Trim() != "" | txtUsuario.Text.Trim() != "")
            {
                if (MessageBox.Show("Al probar la nueva configuración de conexión, se desconectará de la actual (en caso de estar conectado). Tendrá que configurar de nuevo esta conexión. Esta operación puede tardar hasta 1 minuto. ¿Desea continuar?", "Conexión actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Program.conexionEstablecida = false;
                    if (probarConexion())
                    {
                        lblEstado.Text = this.conexion;
                        lblEstado.Text = "CONEXIÓN ESTABLECIDA";
                        lblEstado.ForeColor = Color.Lime;
                        Program.infoConexion[0] = txtInstancia.Text.Trim();
                        Program.infoConexion[1] = txtUsuario.Text.Trim();
                        Program.infoConexion[2] = txtPass.Text.Trim();
                        Program.infoConexion[3] = txtBD.Text.Trim();
                        Program.infoConexion[4] = txtRutaArchivos.Text.Trim();
                        lblEstado.Visible = true;
                        btnGuardar.Visible = true;
                        Program.textoBitacora = "Conectado a " + Program.infoConexion[0].ToUpper();
                    }
                    else
                    {
                        lblEstado.Text = "NO SE ENCUENTRA EL SERVIDOR";
                        lblEstado.ForeColor = Color.Red;
                        Program.infoConexion[0] = "";
                        Program.infoConexion[1] = "";
                        Program.infoConexion[2] = "";
                        Program.infoConexion[3] = "";
                        Program.infoConexion[4] = "";
                        txtPass.Text = "";
                        lblEstado.Visible = true;
                        btnGuardar.Visible = false;
                        Program.textoBitacora = "Conexión al servidor";
                    }
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son obligtorios", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool probarConexion()
        {
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader lee;
            this.conexion = "";
            bool salida = true;
            try
            {
                cnn = new SqlConnection("Server=" + txtInstancia.Text.Trim() + "; database=" + txtBD.Text.Trim() + "; user=" + txtUsuario.Text.Trim() + "; pwd=" + txtPass.Text.Trim());
                cnn.Open();
                {
                    cmd = new SqlCommand("select sconexion from conexion where instancia = '" + txtInstancia.Text.Trim() + "' and baseDatos = '" + txtBD.Text.Trim() + "'", cnn);
                    lee = cmd.ExecuteReader();
                    if (lee.Read())
                    {
                        if (!lee.IsDBNull(0))
                            this.conexion = lee.GetValue(0).ToString();
                    }
                    lee.Close();
                }
                cnn.Close();
            }
            catch
            {
                salida = false;
            }
            return salida;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string ruta = Path.GetDirectoryName(Environment.CurrentDirectory) + "\\config";
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }
            string[] aTxt = { Program.infoConexion[0], Program.infoConexion[1], Program.infoConexion[2], Program.infoConexion[3], Program.infoConexion[4] };
            using (StreamWriter txt = new StreamWriter(ruta))
            {
                txt.WriteLine(Program.codifica(aTxt[0]) + "$" + Program.codifica(aTxt[1]) + "$" + Program.codifica(aTxt[2]) + "$" + Program.codifica(aTxt[3]) + "$" + Program.codifica(aTxt[4]));
            }
            Program.conexionEstablecida = true;
            this.Close();
        }
        private void ocultaGuardar()
        {
            btnGuardar.Visible = false;
            lblEstado.Visible = false;
        }
        private void txtInstancia_TextChanged(object sender, EventArgs e)
        {
            ocultaGuardar();
        }
        private void txtBD_TextChanged(object sender, EventArgs e)
        {
            ocultaGuardar();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            ocultaGuardar();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            ocultaGuardar();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnProbar_Click(sender, e);
            }
        }
    }
}
