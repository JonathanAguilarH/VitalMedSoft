using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public partial class frmIncidenciaChecador : Form
    {
        bool evaluarCampos = false;
        int idActual = 0;
        int iTipoPeriodo = 2;
        int idPeriodoActual = 0;

        public frmIncidenciaChecador()
        {
            InitializeComponent();
        }
        private void frmConfiguracionNomina_Load(object sender, EventArgs e)
        {
            ObtienePeriodo();
            cargaGrid("");
        }
        private void ObtienePeriodo()
        {
            cmPeriodos.DataSource = ExtraerDato.listadoDatos("select idperiodo, 'DEL ' + LEFT(CONVERT(VARCHAR, FECHAINICIO, 103), 10) + ' AL ' + LEFT(CONVERT(VARCHAR, FECHAFIN, 103), 10) as fecha from PERIODOS where tipo = " + this.iTipoPeriodo + " ORDER BY IDPERIODO");
            cmPeriodos.ValueMember = "idperiodo";
            cmPeriodos.DisplayMember = "fecha";
            int idPer = ExtraerDato.Entero16("select idperiodo from periodos where FECHAINICIO <= '" + Program.FormateoFecha(DateTime.Now) + "' and FECHAFIN >= '" + Program.FormateoFecha(DateTime.Now) + "' and tipo = " + this.iTipoPeriodo);
            if (cmPeriodos.Items.Count == 0)
            {
                MessageBox.Show("No se encuentra información del período actual, es posible que no esté dado de alta en el sistema. Contacte al administrador del sistema.", "No se encuentra el período", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
            else
            {
                cmPeriodos.SelectedValue = idPer;
            }
        }
        private void cargaGrid(string busqueda, bool nuevo = false)
        {
            string sNuevo = "NOMBRE asc";
            if (nuevo)
            {
                sNuevo = "idEmpleado desc";
            }
            string filtro = "";
            evaluarCampos = false;
            if (busqueda != "")
            {
                filtro = "where Nombres like '%" + busqueda + "%' or ApellidoP like '%" + busqueda + "%' or ApellidoM like '%" + busqueda + "%' or CURP like '%" + busqueda + "%' or correo like '%" + busqueda + "%' or Direccion like '%" + busqueda + "%' or Celular like '%" + busqueda + "%' or Escolaridad like '%" + busqueda + "%' or Titulo like '%" + busqueda + "%' or RFC like '%" + busqueda + "%' or NSS like '%" + busqueda + "%' or Puesto like '%" + busqueda + "%' or NominaHora like '%" + busqueda + "%' or SueldoHora like '%" + busqueda + "%' or SueldoTurno like '%" + busqueda + "%' or NotasAdicionales like '%" + busqueda + "'";
            }
            dgEmpleados.DataSource = ExtraerDato.listadoDatos("SELECT idEmpleado, Codigo, Imagen, Nombres + ' ' + ApellidoP + ' ' + ApellidoM as NOMBRE, fechaNacimiento, CURP, correo, Direccion, Celular, Escolaridad, Titulo, RFC, NSS, Puesto, fechaAlta, fechaInicioLaboral, fechaFinLaboral, NominaHora, SueldoHora, NominaTurno, SueldoTurno, NotasAdicionales, Nombres, ApellidoP, ApellidoM, HuellaImagen, Activo FROM Empleados " + filtro + " order by " + sNuevo);
            try
            {
                dgEmpleados.Columns[0].Visible = false;  //idEmpleado
            }
            catch (Exception)
            {
                return;
            }
            dgEmpleados.Columns[1].Visible = false;   // Codigo,
            dgEmpleados.Columns[2].Visible = false;  // Imagen,
            dgEmpleados.Columns[3].Visible = true;  // Nombres + ApellidoP + Apellido + Nombre,
            dgEmpleados.Columns[4].Visible = false;  // fechaNacimiento,
            dgEmpleados.Columns[5].Visible = false;  // CURP,
            dgEmpleados.Columns[6].Visible = false;  // correo,
            dgEmpleados.Columns[7].Visible = false;  // Direccion,
            dgEmpleados.Columns[8].Visible = false;  // Celular,
            dgEmpleados.Columns[9].Visible = false;  // Escolaridad,
            dgEmpleados.Columns[10].Visible = false; // Titulo,
            dgEmpleados.Columns[11].Visible = false; // RFC,
            dgEmpleados.Columns[12].Visible = false; // NSS,
            dgEmpleados.Columns[13].Visible = false; // Puesto,
            dgEmpleados.Columns[14].Visible = false; // fechaAlta,
            dgEmpleados.Columns[15].Visible = false; // fechaInicioLaboral,
            dgEmpleados.Columns[16].Visible = false; // fechaFinLaboral,
            dgEmpleados.Columns[17].Visible = false; // NominaHora,
            dgEmpleados.Columns[18].Visible = false; // SueldoHora,
            dgEmpleados.Columns[19].Visible = false; // NominaTurno,
            dgEmpleados.Columns[20].Visible = false; // SueldoTurno,
            dgEmpleados.Columns[21].Visible = false; // NotasAdicionales
            dgEmpleados.Columns[22].Visible = false; // Nombre,
            dgEmpleados.Columns[23].Visible = false; // ApellidoP,
            dgEmpleados.Columns[24].Visible = false; // ApellidoM
            dgEmpleados.Columns[25].Visible = false; // HuellaImagen
            dgEmpleados.Columns[26].Visible = false; // Activo
            dgEmpleados.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (nuevo)
            {
                dgEmpleados.Rows[0].Selected = true;
                nuevo = false;
            }

            string enEvaluacion = "";
            foreach (DataGridViewRow item in dgEmpleados.Rows)
            {
                if (enEvaluacion != "")
                {
                    enEvaluacion = enEvaluacion + ", ";
                }
                enEvaluacion = enEvaluacion + item.Cells[0].Value.ToString();
            }
            if (enEvaluacion != "")
            {
                string[] problemas = ExtraerDato.CadenaArray("select idempleado, CONVERT (char(10),FechaHora, 112) as fecha1, count (CONVERT (char(10),FechaHora, 112)) as 'Cantidad' from Asistencias where IdPeriodo = " + cmPeriodos.SelectedValue + " and idEmpleado in (" + enEvaluacion + ") group by IdEmpleado, CONVERT (char(10),FechaHora, 112) having COUNT (CONVERT (char(10), FechaHora, 112)) > 4");
                if (problemas != null)
                {
                    foreach (DataGridViewRow item in dgEmpleados.Rows)
                    {
                        if (problemas.Contains(item.Cells[0].Value.ToString()))
                        {
                            item.DefaultCellStyle.BackColor = Color.DarkRed;
                            item.DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                }
                else
                {

                }
            }
        }
        public void llenarCampos()
        {
            if (dgEmpleados.CurrentRow != null)
            {
                try
                {
                    try
                    {
                        pbEmpleado.Image = ExtraerDato.imagen("select imagen from empleados where idEmpleado = " + idActual);
                        if (pbEmpleado.Image == null)
                        {
                            byte[] data = (byte[])dgEmpleados.CurrentRow.Cells[2].Value;
                            MemoryStream ms = new MemoryStream(data);
                            pbEmpleado.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception)
                    {
                        pbEmpleado.Image = Properties.Resources.Sin_imagen; // Imagen,
                    }
                    txtTitulo.Text = dgEmpleados.CurrentRow.Cells[10].Value.ToString(); // Titulo,
                    txtPuesto.Text = dgEmpleados.CurrentRow.Cells[13].Value.ToString(); // Puesto,
                    if (txtTitulo.Text == "")
                    {
                        lblTitulo.Visible = false;
                        txtTitulo.Visible = false;
                    }
                    else
                    {
                        lblTitulo.Visible = true;
                        txtTitulo.Visible = true;
                    }
                    txtAntiguedad.Text = DiferenciaFechas(DateTime.Now, (DateTime)dgEmpleados.CurrentRow.Cells[15].Value);
                    ckHora.Checked = dgEmpleados.CurrentRow.Cells[17].Value.ToString() == "1"; // NominaHora,
                    nSueldoHora.Value = Convert.ToDecimal(dgEmpleados.CurrentRow.Cells[18].Value); // SueldoHora,
                    ckTurno.Checked = dgEmpleados.CurrentRow.Cells[19].Value.ToString() == "1"; // NominaTurno,
                    nSueldoTurno.Value = Convert.ToDecimal(dgEmpleados.CurrentRow.Cells[20].Value); // SueldoTurno,
                    txtNombres.Text = dgEmpleados.CurrentRow.Cells[3].Value.ToString(); // Nombre,
                }
                catch
                {
                }
            }
        }
        private void dgEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            llenarCampos();
        }
        private void dgClientes_SelectionChanged(object sender, EventArgs e)
        {
            llenarCampos();
        }
        private String DiferenciaFechas(DateTime newdt, DateTime olddt)
        {
            Int32 anios;
            Int32 meses;
            Int32 dias;
            String str = "";

            anios = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day);

            if (meses < 0)
            {
                anios -= 1;
                meses += 12;
            }
            if (dias < 0)
            {
                meses -= 1;
                dias += DateTime.DaysInMonth(newdt.Year, newdt.Month);
            }

            if (anios < 0)
            {
                return "Fecha Invalida";
            }
            if (anios > 0)
                str = str + anios.ToString() + " años ";
            if (meses > 0)
                str = str + meses.ToString() + " meses ";
            if (dias > 0)
                str = str + dias.ToString() + " dias ";

            return str;
        }

        private void rbSemanal_CheckedChanged(object sender, EventArgs e)
        {
            this.iTipoPeriodo = 1;
            this.idPeriodoActual = 0;
            ObtienePeriodo();
        }

        private void rbQuincenal_CheckedChanged(object sender, EventArgs e)
        {
            this.iTipoPeriodo = 2;
            this.idPeriodoActual = 0;
            ObtienePeriodo();
        }
        private void rbMensual_CheckedChanged(object sender, EventArgs e)
        {
            this.iTipoPeriodo = 3;
            this.idPeriodoActual = 0;
            ObtienePeriodo();
        }

        private void ckTurno_CheckedChanged(object sender, EventArgs e)
        {
            lblSignoPeso.Visible = ckTurno.Checked;
            nSueldoTurno.Visible = ckTurno.Checked;
        }

        private void ckHora_CheckedChanged(object sender, EventArgs e)
        {
            lblSignoPesos1.Visible = ckHora.Checked;
            nSueldoHora.Visible = ckHora.Checked;
        }
    }
}