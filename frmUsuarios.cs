using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public partial class frmUsuarios : Form
    {
        bool formatoCorrecto = true;
        string idUsuario = "0";
        public frmUsuarios()
        {
            InitializeComponent();
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cargaUsuarios();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!formatoCorrecto)
            {
                MessageBox.Show("El email es inválido","Verificar campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.BackColor = Color.Red;
                txtCorreo.ForeColor = Color.White;
                return;
            }
            else
            {
                txtCorreo.BackColor = Color.White;
                txtCorreo.ForeColor = Color.Black;
            }
            if (Program.infoUsuarioConectado[2].Substring(13, 1) == "1")
            {
                bool correcto = false;
                string mensaje = "Se agregó correctamente";
                string idEmpleado = "";
                if (txtUsuario.Text.Trim() == "" | txtPass.Text.Trim() == "")
                {
                    MessageBox.Show("Los campos USUARIO y CONTRASEÑA son obligatorios.", "Datos imcompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (idUsuario == "0")
                    {
                        correcto = ExtraerDato.AccionQuery("insert into usuarios (nUsuario, pass, permisos, correo, idEmpleado, activo) values ('" + txtUsuario.Text.Trim().ToUpper() + "', '" + Program.codificaSHA1(txtPass.Text.Trim()) + "', '', '" + txtCorreo.Text.Trim() + "', '', '1')");
                        idUsuario = ExtraerDato.Cadena("select top(1) idUsuario from usuarios where nUsuario = '" + txtUsuario.Text.Trim().ToUpper() + "' and correo = '" + txtCorreo.Text.Trim() + "' order by idUsuario desc");
                        if (idUsuario == "")
                        {
                            idUsuario = "0";
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Ya existe este usuario, ¿Desea modificarlo?", "Usuario existente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string consulta = "";
                            mensaje = "Se ha modificado correctamente el usuario";
                            if (txtPass.Text != "sinpass:1")
                            {
                                consulta = "update usuarios set nUsuario = '" + txtUsuario.Text.Trim() + "', pass = '" + Program.codificaSHA1(txtPass.Text.Trim()) + "', correo = '" + txtCorreo.Text.Trim() + "', idEmpleado = '" + idEmpleado + "' where idUsuario = " + idUsuario;
                            }
                            else
                            {
                                consulta = "update usuarios set nUsuario = '" + txtUsuario.Text.Trim() + "', correo = '" + txtCorreo.Text.Trim() + "', idEmpleado = '" + idEmpleado + "' where idUsuario = " + idUsuario;
                            }
                            if (ExtraerDato.AccionQuery(consulta))
                            {
                                correcto = true;
                                mensaje = "Se ha modificado correctamente el usuario";
                            }
                        }
                    }
                }
                if (correcto)
                {
                    if (guardaPermisos(idUsuario))
                    {
                        MessageBox.Show(mensaje, "Acción completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    int index = dgUsuarios.CurrentRow.Index;
                    cargaUsuarios();
                    dgUsuarios.Rows[index].Selected = true;
                }
            }
            else
            {
                MessageBox.Show("No cuenta con los permisos para guardar o modificar en este módulo.", "Permisos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ckNominas_CheckedChanged(object sender, EventArgs e)
        { 
            gbNominas.Visible = ckNominas.Checked;
        }
        private void ckMovimientos_CheckedChanged(object sender, EventArgs e) 
        {
            ckGuardarMovtos.Enabled = ckMovimientos.Checked;
        }
        private bool guardaPermisos(string idUsuario)
        {
            string permisos = "";
            permisos = permisos + (Convert.ToByte(ckNominas.Checked).ToString()); //0
            permisos = permisos + (Convert.ToByte(ckMovimientos.Checked).ToString()); //1
            permisos = permisos + (Convert.ToByte(ckGuardarMovtos.Checked).ToString()); //2
            permisos = permisos + (Convert.ToByte(ckGenerar.Checked).ToString()); //3
            permisos = permisos + (Convert.ToByte(ckAutorizar.Checked).ToString()); //4
            permisos = permisos + (Convert.ToByte(ckImprimir.Checked).ToString()); //5
            permisos = permisos + (Convert.ToByte(ckApariencia.Checked).ToString()); //6
            permisos = permisos + (Convert.ToByte(ckCambioEpmpresa.Checked).ToString()); //7
            permisos = permisos + (Convert.ToByte(ckRespalda.Checked).ToString()); //8
            permisos = permisos + (Convert.ToByte(ckTurnos.Checked).ToString()); //9
            permisos = permisos + (Convert.ToByte(ckGuardaTurnos.Checked).ToString()); //10
            permisos = permisos + (Convert.ToByte(ckEmpleados.Checked).ToString()); //11
            permisos = permisos + (Convert.ToByte(ckGuardaEmpleados.Checked).ToString()); //12
            permisos = permisos + (Convert.ToByte(ckUsuarios.Checked).ToString()); //13
            permisos = permisos + (Convert.ToByte(ckGuardaUsuarios.Checked).ToString()); //14
            permisos = permisos + (Convert.ToByte(ckSucursales.Checked).ToString()); //15
            permisos = permisos + (Convert.ToByte(ckGuardaSucursales.Checked).ToString()); //16
            permisos = permisos + (Convert.ToByte(ckRemoto.Checked).ToString()); //17
            permisos = permisos + (Convert.ToByte(chkDetalleTurnos.Checked).ToString()); //18
            permisos = permisos + (Convert.ToByte(ckImprimirId.Checked).ToString()); //19
            permisos = permisos + (Convert.ToByte(chkExcelEmpleados.Checked).ToString()); //20
            permisos = permisos + (Convert.ToByte(ckAgregaAreas.Checked).ToString()); //21
            permisos = permisos + (Convert.ToByte(ckAreas.Checked).ToString()); //22
            permisos = permisos + (Convert.ToByte(ckGuardaAreas.Checked).ToString()); //23
            permisos = permisos + "0000";
            if (ExtraerDato.AccionQuery("update usuarios set permisos = '" + permisos + "' where idUsuario = " + idUsuario))
            {
                if (idUsuario == Program.infoUsuarioConectado[0])
                {
                    Program.infoUsuarioConectado[1] = txtUsuario.Text.Trim().ToUpper();
                    Program.infoUsuarioConectado[2] = permisos;
                    Program.infoUsuarioConectado[3] = txtCorreo.Text.Trim();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cargaUsuarios()
        {
            DataTable dtUsuarios = ExtraerDato.listadoDatos("select idUsuario, nUsuario as 'NOMBRE DE USUARIO', pass, Permisos, correo, idEmpleado FROM usuarios order by nUsuario");
            if (dtUsuarios.Rows.Count > 0)
            {
                dgUsuarios.DataSource = dtUsuarios;
                dgUsuarios.Columns[0].Visible = false;
                dgUsuarios.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgUsuarios.Columns[2].Visible = false;
                dgUsuarios.Columns[3].Visible = false;
                dgUsuarios.Columns[4].Visible = false;
                dgUsuarios.Columns[5].Visible = false;
            }
        }
        private void cargaInfo(string idUsuario)
        {
            if (idUsuario != "")
            {
                try
                {
                    txtUsuario.Text = dgUsuarios.CurrentRow.Cells[1].Value.ToString().ToUpper().Trim();
                }
                catch (Exception)
                {
                    return;
                }
                txtPass.Text = "sinpass:1";
                txtCorreo.Text = dgUsuarios.CurrentRow.Cells[4].Value.ToString();
                cargaPermisos();
            }
            else
            {
                idUsuario = "";
            }
        }
        private void cargaPermisos()
        {
            ckNominas.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(0, 1) == "1"; //0
            ckMovimientos.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(1, 1) == "1"; //1
            ckGuardarMovtos.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(2, 1) == "1"; //2
            ckGenerar.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(3, 1) == "1"; //3
            ckAutorizar.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(4, 1) == "1"; //4
            ckImprimir.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(5, 1) == "1"; //5
            ckApariencia.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(6, 1) == "1"; //6
            ckCambioEpmpresa.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(7, 1) == "1"; //7
            ckRespalda.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(8, 1) == "1"; //8
            ckTurnos.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(9, 1) == "1"; //9
            ckGuardaTurnos.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(10, 1) == "1"; //10
            ckEmpleados.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(11, 1) == "1"; //11
            ckGuardaEmpleados.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(12, 1) == "1"; //12
            ckUsuarios.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(13, 1) == "1"; //13
            ckGuardaUsuarios.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(14, 1) == "1"; //14
            ckSucursales.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(15, 1) == "1"; //15
            ckGuardaSucursales.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(16, 1) == "1"; //16
            ckRemoto.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(17, 1) == "1"; // 17
            chkDetalleTurnos.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(18, 1) == "1"; // 18
            ckImprimirId.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(19, 1) == "1"; // 19
            chkExcelEmpleados.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(20, 1) == "1"; // 20
            ckAgregaAreas.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(21, 1) == "1"; // 21
            ckAreas.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(22, 1) == "1"; // 22
            ckGuardaAreas.Checked = dgUsuarios.CurrentRow.Cells[3].Value.ToString().Substring(23, 1) == "1"; // 23
        }
        private void tbNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            idUsuario = "0";
            txtUsuario.Text = "";
            txtCorreo.Text = "";
            txtPass.Text = "";
            ckNominas.Checked = false;
            ckMovimientos.Checked = false;
            ckGuardarMovtos.Checked = false;
            ckGenerar.Checked = false;
            ckAutorizar.Checked = false;
            ckImprimir.Checked = false;
            ckApariencia.Checked = false;
            ckCambioEpmpresa.Checked = false;
            ckRespalda.Checked = false;
            ckTurnos.Checked = false;
            ckGuardaTurnos.Checked = false;
            ckEmpleados.Checked = false;
            ckGuardaEmpleados.Checked = false;
            ckUsuarios.Checked = false;
            ckGuardaUsuarios.Checked = false;
            ckSucursales.Checked = false;
            ckGuardaSucursales.Checked = false;
            ckRemoto.Checked = false;
            chkDetalleTurnos.Checked = false;
            ckImprimirId.Checked = false;
            chkExcelEmpleados.Checked = false;
            ckAgregaAreas.Checked = false;
            ckAreas.Checked = false;
            ckGuardaAreas.Checked = false;
            tConfiguraciones.SelectedIndex = 0;
        }
        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idUsuario = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                idUsuario = "0";
            }
            cargaInfo(idUsuario);
        }
        private void dgUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idUsuario = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                idUsuario = "0";
            }
            cargaInfo(idUsuario);
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            formatoCorrecto = Program.formateoEmail(txtCorreo.Text.Trim());
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtUsuario.Text = Program.evaluaCamposFuerte(txtUsuario).Text.Trim();
        }
    }
}
