using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public partial class frmMovimientosAdicionalesNomina : Form
    {
        int iTipoPeriodo = 2;
        int idEmpleadoActual = 0;
        int idPeriodoActual = 0;
        bool carga = true;
        int idPeriodoHoy = 0;
        int idPagoDiferido = 0;

        public frmMovimientosAdicionalesNomina()
        {
            InitializeComponent();
        }
        private void frmConfiguracionNomina_Load(object sender, EventArgs e)
        {
            dgEmpleados.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            dgConceptosFijos.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            dgConceptosPorPeriodo.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            dgPagosDiferidos.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            cbTurno.SelectedIndex = 1;
            ObtienePeriodo();
            cargaTurnosDiferido();
            CargaTurnos();
            cargaGridEmpleados("");
            carga = false;
        }
        private void ActualizaGrid()
        {
            if (dgEmpleados.CurrentRow != null)
            {
                try
                {
                    switch (cbTurno.SelectedItem)
                    {
                        case "SEMANAL":
                            dgEmpleados.CurrentRow.Cells[30].Value = 1;
                            break;
                        case "QUINCENAL":
                            dgEmpleados.CurrentRow.Cells[30].Value = 2;
                            break;
                        case "MENSUAL":
                            dgEmpleados.CurrentRow.Cells[30].Value = 3;
                            break;
                    }
                    dgEmpleados.CurrentRow.Cells[31].Value = cmTurno.SelectedValue; // Turno preferido
                    dgEmpleados.CurrentRow.Cells[32].Value = (ckAsistencia.Checked ? "1" : "0") + (ckPuntualidad.Checked ? "1" : "0") + (ckDespensa.Checked ? "1" : "0") + (ckProductividad.Checked ? "1" : "0") + (ckLibro.Checked ? "1" : "0"); // prestaciones obligatorias
                }
                catch { }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
        }
        private void cargaConceptosFijos(int idEmpleado)
        {
            dgConceptosFijos.DataSource = ExtraerDato.listadoDatos("SELECT idRelacion, idEmpleado, CONCEPTO, CONVERT(VARCHAR, '$ ' + CONVERT(VARCHAR, CAST(PAGO AS MONEY), 1)) as PAGO, case percepcion when 0 then 'Deducción' when 1 then 'Percepción' end as TIPO, pagado FROM ConceptosEmpleados where fijo = 1 and idEmpleado = " + idEmpleado + " order by Concepto, percepcion");
            dgConceptosFijos.Columns[0].Visible = false; // idRelacion
            dgConceptosFijos.Columns[1].Visible = false; // idEmpleado
            dgConceptosFijos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // concepto
            dgConceptosFijos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // pago
            dgConceptosFijos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // pago
            dgConceptosFijos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // percepcion
            dgConceptosFijos.Columns[5].Visible = false; // pagado
        }
        private void cargaConceptosPeriodo(int idEmpleado, int idPeriodo)
        {
            dgConceptosPorPeriodo.DataSource = ExtraerDato.listadoDatos("SELECT idRelacion, idEmpleado, CONCEPTO, CONVERT(VARCHAR, '$ ' + CONVERT(VARCHAR, CAST(PAGO AS MONEY), 1)) as PAGO, case percepcion when 0 then 'Deducción' when 1 then 'Percepción' end as TIPO, pagado FROM ConceptosEmpleados where fijo = 0 and idPeriodo = " + idPeriodo + " and idEmpleado = " + idEmpleado + " order by Concepto, percepcion");
            dgConceptosPorPeriodo.Columns[0].Visible = false; // idRelacion
            dgConceptosPorPeriodo.Columns[1].Visible = false; // idEmpleado
            dgConceptosPorPeriodo.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // concepto
            dgConceptosPorPeriodo.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // pago
            dgConceptosPorPeriodo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // pago
            dgConceptosPorPeriodo.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // percepcion
            dgConceptosPorPeriodo.Columns[5].Visible = false; // pagado
        }
        private void CargaTurnos()
        {
            DataTable dt = ExtraerDato.listadoDatos("select idTurno, nombre from turnos order by nombre");
            if (dt.Rows.Count > 0)
            {
                cmTurno.DataSource = dt;
                cmTurno.DisplayMember = "nombre";
                cmTurno.ValueMember = "idTurno";
            }
            else
            {
                cmTurno.Items.Clear();
                cmTurno.Items.Add("** No se encuentran turnos registrados **");
            }
        }
        private void cargaGridEmpleados(string busqueda)
        {
            string filtro = "";
            if (busqueda != "")
            {
                filtro = "where Nombres like '%" + busqueda + "%' or ApellidoP like '%" + busqueda + "%' or ApellidoM like '%" + busqueda + "%' or CURP like '%" + busqueda + "%' or correo like '%" + busqueda + "%' or Direccion like '%" + busqueda + "%' or Celular like '%" + busqueda + "%' or Escolaridad like '%" + busqueda + "%' or Titulo like '%" + busqueda + "%' or RFC like '%" + busqueda + "%' or NSS like '%" + busqueda + "%' or Puesto like '%" + busqueda + "%' or NominaHora like '%" + busqueda + "%' or SueldoHora like '%" + busqueda + "%' or SueldoTurno like '%" + busqueda + "%' or NotasAdicionales like '%" + busqueda + "'";
            }
            dgEmpleados.DataSource = ExtraerDato.listadoDatos("SELECT empleados.idEmpleado, Codigo, Imagen, Nombres + ' ' + ApellidoP + ' ' + ApellidoM as NOMBRE, fechaNacimiento, CURP, correo, Direccion, Celular, Escolaridad, Titulo, RFC, NSS, Puesto, fechaAlta, fechaInicioLaboral, fechaFinLaboral, NominaHora, SueldoHora, NominaTurno, SueldoTurno, NotasAdicionales, Nombres, ApellidoP, ApellidoM, HuellaImagen, Activo, SueldoTotal, SueldoBase, SueldoPrestaciones, tipoNomina, turnoPreferido, prestacionesObligatorias, idConfiguracion FROM Empleados left join configuracionesAdicionales on Empleados.idEmpleado = configuracionesAdicionales.idEmpleado " + filtro + " order by NOMBRE asc");
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
            dgEmpleados.Columns[27].Visible = false; // Sueldo total
            dgEmpleados.Columns[28].Visible = false; // Sueldo base
            dgEmpleados.Columns[29].Visible = false; // Sueldo prestaciones
            dgEmpleados.Columns[30].Visible = false; // tipoNomina
            dgEmpleados.Columns[31].Visible = false; // turnoPreferido
            dgEmpleados.Columns[32].Visible = false; // prestacionesObligatorias
            dgEmpleados.Columns[33].Visible = false; // idConfiguraciones
            dgEmpleados.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscador.Text.Trim().Length > 2)
            {
                cargaGridEmpleados(txtBuscador.Text.Trim());
            }
            if (txtBuscador.Text.Trim().Length == 0)
            {
                cargaGridEmpleados("");
            }
        }

        private void dgEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            llenarCamposEmpleados();
        }
        private void dgEmpleados_CurrentCellChanged(object sender, EventArgs e)
        {
            llenarCamposEmpleados();
        }
        private void llenarCamposEmpleados()
        {
            lblEstadoGuardado.Text = "";
            lblEstadoGuardado.ForeColor = Color.Green;
            if (dgEmpleados.CurrentRow != null)
            {
                this.carga = true;
                try
                {
                    try
                    {
                        this.idEmpleadoActual = int.Parse(dgEmpleados.CurrentRow.Cells[0].Value.ToString());
                        pbEmpleado.Image = ExtraerDato.imagen("select imagen from empleados where idEmpleado = " + this.idEmpleadoActual);
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
                    if (dgEmpleados.CurrentRow.Cells[27].Value.ToString() != "") // Sueldo Total
                    {
                        lblSTotal.Visible = true;
                        lblSTotal.Text = "Sueldo total: " + ExtraerDato.formatoPesos((double)dgEmpleados.CurrentRow.Cells[27].Value);
                    }
                    else
                    {
                        lblSTotal.Visible = false;
                    }
                    if (dgEmpleados.CurrentRow.Cells[28].Value.ToString() != "") // Sueldo base
                    {
                        lblSBase.Visible = true;
                        lblSBase.Text = "Sueldo base: " + ExtraerDato.formatoPesos((double)dgEmpleados.CurrentRow.Cells[28].Value);
                    }
                    else
                    {
                        lblSBase.Visible = false;
                    }
                    if (dgEmpleados.CurrentRow.Cells[29].Value.ToString() != "") // Sueldo prestaciones
                    {
                        lblSPrestaciones.Visible = true;
                        lblSPrestaciones.Text = "Sueldo prestaciones: " + ExtraerDato.formatoPesos((double)dgEmpleados.CurrentRow.Cells[29].Value);
                    }
                    else
                    {
                        lblSPrestaciones.Visible = false;
                    }
                    txtNombres.Text = dgEmpleados.CurrentRow.Cells[3].Value.ToString(); // Nombre,
                    if (dgEmpleados.CurrentRow.Cells[30].Value.ToString() != "") // tipoNomina,
                    {
                        try
                        {
                            cbTurno.SelectedIndex = (int)dgEmpleados.CurrentRow.Cells[30].Value - 1;
                        }
                        catch { }
                    }
                    else
                    {
                        cbTurno.SelectedIndex = 0;
                    }
                    if (dgEmpleados.CurrentRow.Cells[31].Value.ToString() != "") // turnoPreferido,
                    {
                        cmTurno.SelectedValue = (int) dgEmpleados.CurrentRow.Cells[31].Value;
                    }
                    else
                    {
                        try
                        {
                            cmTurno.SelectedIndex = 0;
                        }
                        catch { }
                    }
                    if (dgEmpleados.CurrentRow.Cells[32].Value.ToString() != "") // prestacionesObligatorias,
                    {
                        string bonos = dgEmpleados.CurrentRow.Cells[32].Value.ToString();
                        ckAsistencia.Checked = bonos.Substring(0, 1) == "1";
                        ckPuntualidad.Checked = bonos.Substring(1, 1) == "1";
                        ckDespensa.Checked = bonos.Substring(2, 1) == "1";
                        ckProductividad.Checked = bonos.Substring(3, 1) == "1";
                        ckLibro.Checked = bonos.Substring(4, 1) == "1";
                    }
                    else
                    {
                        ckAsistencia.Checked = false;
                        ckPuntualidad.Checked = false;
                        ckDespensa.Checked = false;
                        ckProductividad.Checked = false;
                        ckLibro.Checked = false;
                    }
                    cargaConceptosFijos(this.idEmpleadoActual);
                    cargaConceptosPeriodo(this.idEmpleadoActual, this.idPeriodoActual);
                    limpiaDiferidos();
                    cargaPagosDiferidos(this.idEmpleadoActual);
                }
                catch
                {
                }
            }
            this.carga = false;
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
        private void ObtienePeriodo()
        {
            DataTable dt = new DataTable();
            dt = ExtraerDato.listadoDatos("select idperiodo, 'DEL ' + LEFT(CONVERT(VARCHAR, FECHAINICIO, 103), 10) + ' AL ' + LEFT(CONVERT(VARCHAR, FECHAFIN, 103), 10) as fecha from PERIODOS where tipo = " + this.iTipoPeriodo + " ORDER BY fechaInicio asc");
            cmPeriodos.DataSource = dt;
            cmPeriodos.ValueMember = "idperiodo";
            cmPeriodos.DisplayMember = "fecha";
            int idPer = ExtraerDato.Entero16("select idperiodo from periodos where FECHAINICIO <= '" + Program.FormateoFecha(DateTime.Now) + "' and FECHAFIN >= '" + Program.FormateoFecha(DateTime.Now) + "' and tipo = " + this.iTipoPeriodo);
            this.idPeriodoHoy = idPer;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encuentra información del período actual, es posible que no esté dado de alta en el sistema. Contacte al administrador del sistema.", "No se encuentra el período", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgConceptosPorPeriodo.DataSource = null;
            }
        }
        private void cargaTurnosDiferido()
        {
            DataTable dt = new DataTable();
            dt = ExtraerDato.listadoDatos("select idperiodo, 'DEL ' + LEFT(CONVERT(VARCHAR, FECHAINICIO, 103), 10) + ' AL ' + LEFT(CONVERT(VARCHAR, FECHAFIN, 103), 10) as fecha from PERIODOS where tipo = " + this.iTipoPeriodo + " ORDER BY fechaInicio asc");
            cbPeriodoPrimerPago.DataSource = dt;
            cbPeriodoPrimerPago.ValueMember = "idperiodo";
            cbPeriodoPrimerPago.DisplayMember = "fecha";
            cbPeriodoPrimerPago.SelectedValue = this.idPeriodoHoy;
        }
        private void cmTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.carga)
            {
                if (dgEmpleados.CurrentRow != null)
                {
                    if (this.idEmpleadoActual != 0)
                    {
                        if (!ExtraerDato.TieneFilas("select * from ConfiguracionesAdicionales where idEmpleado = " + this.idEmpleadoActual))
                        {
                            ExtraerDato.AccionQuery("insert into ConfiguracionesAdicionales (idEmpleado, turnoPreferido) values (" + this.idEmpleadoActual + ", " + cmTurno.SelectedValue + ")");
                        }
                        else
                        {
                            ExtraerDato.AccionQuery("update ConfiguracionesAdicionales set turnoPreferido = " + cmTurno.SelectedValue + " where idEmpleado = " + this.idEmpleadoActual);
                        }
                        dgEmpleados.CurrentRow.Cells[31].Value = cmTurno.SelectedValue;
                        lblEstadoGuardado.Text = "Se actualizó el TURNO PREFERIDO correctamente.";
                        lblEstadoGuardado.ForeColor = Color.Green;
                    }
                }
                ActualizaGrid();
            }
        }
        private void guardaBonos()
        {
            if (dgEmpleados.CurrentRow != null)
            {
                if (!this.carga)
                {
                    if (this.idEmpleadoActual != 0)
                    {
                        string bonos = (ckAsistencia.Checked ? "1" : "0") + (ckPuntualidad.Checked ? "1" : "0") + (ckDespensa.Checked ? "1" : "0") + (ckProductividad.Checked ? "1" : "0") + (ckLibro.Checked ? "1" : "0");
                        if (!ExtraerDato.TieneFilas("select * from ConfiguracionesAdicionales where idEmpleado = " + this.idEmpleadoActual))
                        {
                            ExtraerDato.AccionQuery("insert into ConfiguracionesAdicionales (idEmpleado, prestacionesobligatorias) values ('" + this.idEmpleadoActual + "', " + bonos + ")");
                        }
                        else
                        {
                            ExtraerDato.AccionQuery("update ConfiguracionesAdicionales set prestacionesobligatorias = '" + bonos + "' where idEmpleado = " + this.idEmpleadoActual);
                        }
                        dgEmpleados.CurrentRow.Cells[32].Value = bonos;
                        lblEstadoGuardado.ForeColor = Color.Green;
                        lblEstadoGuardado.Text = "Se actualizó la información de PRESTACIONES OBLIGATORIAS correctamente.";
                    }
                    ActualizaGrid();
                }
            }
            else
            {
                lblEstadoGuardado.Text = "No se ha seleccionado empleado.";
                lblEstadoGuardado.ForeColor = Color.Red;
            }
        }
        private void ckAsistencia_CheckedChanged(object sender, EventArgs e)
        {
            guardaBonos();
        }

        private void ckPuntualidad_CheckedChanged(object sender, EventArgs e)
        {
            guardaBonos();
        }

        private void ckDespensa_CheckedChanged(object sender, EventArgs e)
        {
            guardaBonos();
        }

        private void ckProductividad_CheckedChanged(object sender, EventArgs e)
        {
            guardaBonos();
        }

        private void ckLibro_CheckedChanged(object sender, EventArgs e)
        {
            guardaBonos();
        }
        private void cmPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (evaluaNominaPeriodo((int)cmPeriodos.SelectedValue, false))
                {
                    this.idPeriodoActual = (int)cmPeriodos.SelectedValue;
                    cargaConceptosPeriodo(this.idEmpleadoActual, this.idPeriodoActual);
                }
            }
            catch
            {
            }
        }
        private void cargaPeriodos()
        {
            if (this.idEmpleadoActual != 0)
            {

            }
        }

        private void nPago_ValueChanged(object sender, EventArgs e)
        {
            CalculaParcialidad();
        }

        private void nNumeroPagos_ValueChanged(object sender, EventArgs e)
        {
            CalculaParcialidad();
        }
        private void CalculaParcialidad()
        {
            lblParcialidad.Text = ExtraerDato.formatoPesos((double) (nPago.Value / nNumeroPagos.Value));
        }
        private void agregarConceptoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Los conceptos que se agreguen se verán reflejados en el siguiente período de nómina que NO se haya guardado.", "Agregar concepto fijo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!ExtraerDato.TieneFilas("select * from ConceptosAdicionales"))
            {
                MessageBox.Show("No se han registrado conceptos fijos. Para aregar conceptos ir a Menú Nómina -> Configuraciones generales", "Sin conceptos adicionales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmAgregaConcepto frmConcepto = new frmAgregaConcepto(this.idEmpleadoActual, 1, 0);
            frmConcepto.ShowDialog();
            cargaConceptosFijos(this.idEmpleadoActual);
        }

        private void elominarConceptoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea eliminar este concepto? Esta acción no se puede deshacer.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Los conceptos que se agreguen se verán reflejados en el siguiente período de nómina que NO se haya guardado.", "Agregar concepto fijo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ExtraerDato.AccionQuery("delete from ConceptosEmpleados where idRelacion = " + dgConceptosFijos.CurrentRow.Cells[0].Value.ToString()))
                {
                    cargaConceptosFijos(this.idEmpleadoActual);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar. Si el problema persiste, contacte al administrador del sistema.", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void agregarConceptoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                this.idPeriodoActual = (int)cmPeriodos.SelectedValue;
                if (evaluaNominaPeriodo(this.idPeriodoActual, true))
                {
                    frmAgregaConcepto frmConcepto = new frmAgregaConcepto(2, this.idEmpleadoActual, this.idPeriodoActual);
                    frmConcepto.ShowDialog();
                    cargaConceptosPeriodo(this.idEmpleadoActual, this.idPeriodoActual);
                }
            }
            catch { }
        }

        private void eliminarConceptoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.idPeriodoActual = (int) cmPeriodos.SelectedValue;
            if (evaluaNominaPeriodo(this.idPeriodoActual, true))
            {
                if (MessageBox.Show("¿Realmente desea eliminar este concepto? Esta acción no se puede deshacer.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ExtraerDato.AccionQuery("delete from ConceptosEmpleados where idRelacion = " + dgConceptosPorPeriodo.CurrentRow.Cells[0].Value.ToString()))
                    {
                        cargaConceptosPeriodo(this.idEmpleadoActual, this.idPeriodoActual);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar. Si el problema persiste, contacte al administrador del sistema.", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void eliminarConceptoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgPagosDiferidos.CurrentRow != null)
            {
                if (evaluaNominaPeriodo(this.idPeriodoActual, true))
                {
                    bool eliminar = true;
                    DataTable dt = ExtraerDato.listadoDatos("select pagosRealizados from pagosDiferidos where idPagoDiferido = " + dgPagosDiferidos.CurrentRow.Cells[0].Value.ToString() + " and pagosRealizados > 0");
                    if (dt.Rows.Count > 0)
                    {
                        if (MessageBox.Show("Este concepto ya tiene pagos realizados. ¿Desea continuar?", "Eliminar concepto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            eliminar = false;
                        }
                    }
                    if (eliminar)
                    {
                        if (!ExtraerDato.AccionQuery("delete from pagosDiferidos where idPagoDiferido = " + dgPagosDiferidos.CurrentRow.Cells[0].Value.ToString()))
                        {
                            MessageBox.Show("Ocurrió un error al eliminar el pago diferido. Si el problema persiste, contacte al adminstrador del sistema", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            cargaPagosDiferidos(this.idEmpleadoActual);
                        }
                    }
                }
            }
        }
        private void btnGuardaConcepto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Al agregar o modificar un pago diferido se eliminarán todas las nóminas guardadas que no se hayan pagado ¿Desea continuar?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ExtraerDato.AccionQuery("update periodos set guardado = 0 where pagado = 0");
                ExtraerDato.AccionQuery("delete from nominaPeriodo where idPeriodo in (select idPeriodo from Periodos where guardado = 0 and pagado = 0)");
                if (idPagoDiferido == 0)
                {
                    if (ExtraerDato.AccionQuery("insert into pagosDiferidos (idEmpleado, idPeriodoInicial, percepcion, concepto, montoTotal, numeroPagos, pagosRealizados, pagosFaltantes, parcialidades, totalPagado, saldoPendiente) values (" + this.idEmpleadoActual + ", " + cbPeriodoPrimerPago.SelectedValue + ", " + (rbPercepcion.Checked ? "1" : "0") + ", '" + txtConceptoDiferido.Text.Trim().ToUpper() + "', " + nPago.Value + ", " + nNumeroPagos.Value + ", 0, " + nNumeroPagos.Value + ", " + lblParcialidad.Text.Replace("$ ", "").Replace(",", "") + ", 0, " + nPago.Value + ")"))
                    {
                        lblEstadoGuardado.Text = "Se ha agregado correctamente el pago diferido";
                        lblEstadoGuardado.ForeColor = Color.Green;
                        cargaPagosDiferidos(this.idEmpleadoActual);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido agregar el pago diferido. Si el problema persiste, contacte al administrador del sistema.", "Error al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    decimal saldo = decimal.Parse(dgPagosDiferidos.CurrentRow.Cells[11].Value.ToString().Replace("$ ", ""));
                    if (nPago.Value < saldo)
                    {
                        MessageBox.Show("El monto total no puede ser menor al saldo", "Monto total inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (ExtraerDato.AccionQuery("update pagosDiferidos set idPeriodoInicial = '" + cbPeriodoPrimerPago.SelectedValue + "', percepcion = '" + (rbPercepcion.Checked ? "1" : "0") + "', concepto = '" + txtConceptoDiferido.Text.Trim().ToUpper() + "', montototal = '" + nPago.Value + "', numeropagos = '" + nNumeroPagos.Value + "', parcialidades = '" + lblParcialidad.Text.Replace("$ ", "").Replace(",", "") + "'  where idpagoDiferido = 1"))
                    {
                        lblEstadoGuardado.Text = "Se ha modificado correctamente el pago diferido";
                        lblEstadoGuardado.ForeColor = Color.Green;
                        cargaPagosDiferidos(this.idEmpleadoActual);
                    }
                }
            }
        }

        private void cbPeriodoPrimerPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string fecha = ExtraerDato.Cadena("select LEFT(CONVERT(VARCHAR, FECHAFIN, 103), 10) from periodos where idperiodo = " + cbPeriodoPrimerPago.SelectedValue);
                lblPrimerPago.Text = fecha;
                evaluaNominaPeriodo((int)cbPeriodoPrimerPago.SelectedValue, false);
            }
            catch
            {
                lblPrimerPago.Text = "";
            }
        }

        private void dgPagosDiferidos_SelectionChanged(object sender, EventArgs e)
        {
            LlenarCamposPagosDiferidos();
        }

        private void dgPagosDiferidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarCamposPagosDiferidos();
        }
        private void cargaPagosDiferidos(int idEmpleado)
        {
            DataTable dt = ExtraerDato.listadoDatos("SELECT idPagoDiferido, idEmpleado, idPeriodoInicial, case percepcion when 0 then 'Deducción' when 1 then 'Percepción' end as TIPO, CONCEPTO, CONVERT(VARCHAR, '$ ' + CONVERT(VARCHAR, CAST(montoTotal AS MONEY), 1)) AS 'MONTO TOTAL', numeroPagos AS 'CANTIDAD DE PAGOS', pagosRealizados, pagosFaltantes, CONVERT(VARCHAR, '$ ' + CONVERT(VARCHAR, CAST(PARCIALIDADES AS MONEY), 1)) as PARCIALIDADES, CONVERT(VARCHAR, '$ ' + CONVERT(VARCHAR, CAST(totalPagado AS MONEY), 1)) AS 'TOTAL PAGADO', CONVERT(VARCHAR, '$ ' + CONVERT(VARCHAR, CAST(saldoPendiente AS MONEY), 1)) AS 'SALDO' FROM pagosDiferidos where idEmpleado = " + idEmpleado);
            dgPagosDiferidos.DataSource = dt;
            dgPagosDiferidos.Columns[0].Visible = false; // idPagoDiferido
            dgPagosDiferidos.Columns[1].Visible = false; // idEmpeado
            dgPagosDiferidos.Columns[2].Visible = false; // idPeriodoInicial
            dgPagosDiferidos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // tipo
            dgPagosDiferidos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // concepto
            dgPagosDiferidos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // monto total
            dgPagosDiferidos.Columns[6].Visible = false; // numero de pagos
            dgPagosDiferidos.Columns[7].Visible = false; // pagosrealizados
            dgPagosDiferidos.Columns[8].Visible = false; // pagos faltantes
            dgPagosDiferidos.Columns[9].Visible = false; // parcialidades
            dgPagosDiferidos.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // total pagado
            dgPagosDiferidos.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // saldo
        }
        private void LlenarCamposPagosDiferidos()
        {
            rbPercepcion.Enabled = false;
            rbDeduccion.Enabled = false;
            if (dgPagosDiferidos.CurrentRow.Cells[3].Value.ToString() == "Percepción")
            {
                rbPercepcion.Checked = true;
            }
            else
            {
                rbDeduccion.Checked = true;
            }
            txtConceptoDiferido.Text = dgPagosDiferidos.CurrentRow.Cells[4].Value.ToString();
            nPago.Value = decimal.Parse(dgPagosDiferidos.CurrentRow.Cells[5].Value.ToString().Substring(2).Trim());
            nNumeroPagos.Value = decimal.Parse(dgPagosDiferidos.CurrentRow.Cells[6].Value.ToString());
            cbPeriodoPrimerPago.SelectedValue = (int)dgPagosDiferidos.CurrentRow.Cells[2].Value;
            this.idPagoDiferido = int.Parse(dgPagosDiferidos.CurrentRow.Cells[0].Value.ToString());
            if (cbPeriodoPrimerPago.SelectedValue == null)
            {
                MessageBox.Show("No se encuentra perìodo de inicio de pago diferido", "No se encuentra período", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevoConcepto_Click(object sender, EventArgs e)
        {
            limpiaDiferidos();
        }

        private void limpiaDiferidos()
        {
            gbTipoDiferido.Enabled = true;
            this.idPagoDiferido = 0;
            rbPercepcion.Checked = true;
            txtConceptoDiferido.Text = "";
            nPago.Value = 0;
            nNumeroPagos.Value = 1;
            lblParcialidad.Text = "$ 0";
            cbPeriodoPrimerPago.SelectedValue = this.idPeriodoHoy;
        }

        private void lblTipoNomina_TextChanged(object sender, EventArgs e)
        {
            switch (lblTipoNomina.Text)
            {
                case "Tipo de nómina: SEMANAL":
                    this.iTipoPeriodo = 1;
                    this.idPeriodoActual = 0;
                    lblidTipoNomina.Text = "1";
                    ObtienePeriodo();
                    break;
                case "Tipo de nómina: QUINCENAL":
                    this.iTipoPeriodo = 2;
                    this.idPeriodoActual = 0;
                    lblidTipoNomina.Text = "2";
                    ObtienePeriodo();
                    break;
                case "Tipo de nómina: MENSUAL":
                    this.iTipoPeriodo = 3;
                    this.idPeriodoActual = 0;
                    lblidTipoNomina.Text = "3";
                    ObtienePeriodo();
                    break;
            }
        }

        private void cbTurno_TextChanged(object sender, EventArgs e)
        {
            lblTipoNomina.Text = "Tipo de nómina: " + cbTurno.Text;
            if (!this.carga)
            {
                if (this.idEmpleadoActual != 0)
                {
                    if (!ExtraerDato.TieneFilas("select * from ConfiguracionesAdicionales where idEmpleado = " + this.idEmpleadoActual))
                    {
                        ExtraerDato.AccionQuery("insert into ConfiguracionesAdicionales (idEmpleado, tipoNomina) values (" + this.idEmpleadoActual + ", " + cbTurno.SelectedIndex + ")");
                    }
                    else
                    {
                        ExtraerDato.AccionQuery("update ConfiguracionesAdicionales set tipoNomina = " + (cbTurno.SelectedIndex + 1) + " where idEmpleado = " + this.idEmpleadoActual);
                    }
                    try
                    {
                        dgEmpleados.CurrentRow.Cells[30].Value = cbTurno.SelectedIndex;
                    }
                    catch { }
                    lblEstadoGuardado.Text = "Se actualizó el TIPO DE NÓMINA correctamente.";
                    lblEstadoGuardado.ForeColor = Color.Green;
                    ActualizaGrid();
                }
            }
        }
        private bool evaluaNominaPeriodo(int idPeriodo, bool movimientoManual)
        {
            if (!this.carga)
            {
                if (ExtraerDato.TieneFilas("select * from Periodos where Pagado = 1 and idPeriodo = " + idPeriodo))
                {
                    MessageBox.Show("No se puede modificar una nómina pagada. Seleccione otro periodo.", "Nómina pagada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                if (!movimientoManual)
                {
                    if (ExtraerDato.TieneFilas("select * from nominaPeriodo where idPeriodo = " + idPeriodo))
                    {
                        MessageBox.Show("Este período pertenece a una nóminas que ya está guardada. Cualquier modificación que realice en los conceptos, eliminará los registros guardados en la nómina.", "Nómina con registros guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return false;
                    }
                }
                else
                {
                    if (ExtraerDato.TieneFilas("select * from nominaPeriodo where idPeriodo = " + idPeriodo))
                    {
                        if (MessageBox.Show("Este período pertenece a una nómina que ya está guardada. Cualquier modificación que realice en los conceptos, eliminará los registros guardados en la nómina. ¿Desea continuar?", "Nómina con registros guardados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ExtraerDato.AccionQuery("delete from nominaPeriodo where idPeriodo = " + idPeriodo);
                            ExtraerDato.AccionQuery("update periodos set guardado = 0 where idPeriodo = " + idPeriodo);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void cmConceptosFijos_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmConceptosFijos.Items[1].Visible = dgConceptosFijos.RowCount > 0;
        }

        private void cmConceptosPeriodo_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cmConceptosPeriodo.Items[1].Visible = dgConceptosPorPeriodo.RowCount > 0;
        }
    }
}


