using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public partial class frmGeneraNomina : Form
    {
        bool evaluarCampos = false;
        int idActual = 0;
        int iTipoPeriodo = 2;
        int idPeriodoActual = 0;
        bool ActualizaTotales = false;
        bool gridModificado = false;
        private bool bPrimerRecibo = false;
        private SqlConnection Pcnn;
        private SqlCommand Pcmd;
        private SqlDataReader Plee;

        public frmGeneraNomina()
        {
            InitializeComponent();
            dgPercepciones.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            dgDeducciones.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            dgPercepcionesPrevio.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            dgDeduccionesPrevio.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            gbConceptos.Visible = false;
        }
        private void frmConfiguracionNomina_Load(object sender, EventArgs e)
        {
            btnCalcularNomina.Enabled = false;
            btnGuardar.Enabled = false;
            btnPagar.Enabled = false;
            dgEmpleados.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            ObtienePeriodo();
        }
        
        private void agregarConceptoDesdeListadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizaGridsConceptos(dgEmpleados.CurrentRow.Cells[1].Value.ToString(), (int) dgEmpleados.CurrentRow.Cells[0].Value);
            gbConceptos.Visible = true;
        }
        private void ActualizaGridsConceptos(string cNombre, int idEmpleado)
        {
            DataTable dtPercepciones;
            DataTable dtDeducciones;
            DataTable dtConceptos = ExtraerDato.listadoDatos("select idRelacion, idConcepto, pago, Percepcion from ConceptosEmpleados where fijo = 1 and idEmpleado = " + idEmpleado);
            lblNombre.Text = cNombre;
            dtPercepciones = ExtraerDato.listadoDatos("select idConcepto, percepcion, CONCEPTO, PAGO as 'PAGO SUGERIDO', '0' as PAGO from ConceptosAdicionales where percepcion = 1 order by idConcepto desc");
            dgPercepciones.DataSource = dtPercepciones;
            dtDeducciones = ExtraerDato.listadoDatos("select idConcepto, percepcion, CONCEPTO, PAGO as 'PAGO SUGERIDO', '0' as PAGO from ConceptosAdicionales where percepcion = 0 order by idConcepto desc");
            dgDeducciones.DataSource = dtDeducciones;
            
            foreach (DataRow dr in dtConceptos.Rows)
            {
                if (dr[3].ToString() == "1")
                {
                    var items = dgPercepciones.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[0].Value.ToString() == dr[1].ToString());

                    foreach (DataGridViewRow row in items)
                    {
                        row.Cells[4].Value = dr[2].ToString();
                    }
                }
                else
                {
                    var items = dgDeducciones.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[0].Value.ToString() == dr[1].ToString());

                    foreach (DataGridViewRow row in items)
                    {
                        row.Cells[4].Value = dr[2].ToString();
                    }
                }
            }
            try
            {
                dgDeducciones.Columns[0].Visible = false;
                dgDeducciones.Columns[1].Visible = false;
                dgDeducciones.Columns[2].ReadOnly = true;
                dgDeducciones.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgDeducciones.Columns[3].ReadOnly = true;
                dgDeducciones.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgDeducciones.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgDeducciones.Columns[4].ReadOnly = false;
                dgDeducciones.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgDeducciones.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgDeducciones.Columns[4].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            catch { }
            try
            {
                dgPercepciones.Columns[0].Visible = false;
                dgPercepciones.Columns[1].Visible = false;
                dgPercepciones.Columns[2].ReadOnly = true;
                dgPercepciones.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgPercepciones.Columns[3].ReadOnly = true;
                dgPercepciones.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgPercepciones.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgPercepciones.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgPercepciones.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgPercepciones.Columns[4].ReadOnly = false;
                dgPercepciones.Columns[4].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            catch { }
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
                VisibilidadTotales(false);
                btnGuardar.Enabled = false;
            }
            else
            {
                btnCalcularNomina.Enabled = true;
                cmPeriodos.SelectedValue = idPer;
                DataTable infoNomina = ExtraerDato.listadoDatos("select idEmpleado, Nombre, sueldoBase, sueldoTotal, sueldoPrestaciones, turnoPreferido, prestacionesObligatorias, nombreTurno, entrada, salida, comida, faltas, retardos, bonoAsistencia as 'BONO ASISTENCIA', bonoPuntualidad AS 'BONO PUNTUALIDAD', bonoDespensa AS 'BONO DESPENSA', bonoProductividad AS 'BONO PRODUCTIVIDAD', bonoLibro AS 'BONO LIBRO', percepciones AS 'PERCEPCIONES ADICIONALES', deducciones AS 'DEDUCCIONES ADICIONALES', BANCO, EFECTIVO, totalPagar AS 'TOTAL A PAGAR', idPeriodo from nominaPeriodo where idPeriodo = " + cmPeriodos.SelectedValue);
                if (infoNomina.Rows.Count > 0)
                {
                    btnGuardar.Enabled = true;
                    cargaGrid(infoNomina);
                    return;
                }
            }
            cargaGrid();
        }
        private void cargaGrid(DataTable dtDatos = null)
        {
            dgEmpleados.Enabled = true;
            if (ExtraerDato.TieneFilas("select * from periodos where idPeriodo = " + cmPeriodos.SelectedValue + " and pagado = 1"))
            {
                btnImprimeRecibo.Enabled = true;
                btnCalcularNomina.Enabled = false;
                btnGuardar.Enabled = false;
                lblPagada.Visible = true;
                btnPagar.Enabled = false;
                dgEmpleados.Enabled = false;
            }
            else
            {
                btnImprimeRecibo.Enabled = false;
                btnCalcularNomina.Enabled = true;
                lblPagada.Visible = false;
                btnPagar.Enabled = true;
            }
            if (ExtraerDato.TieneFilas("select * from periodos where idPeriodo = " + cmPeriodos.SelectedValue + " and guardado = 1 and pagado = 0"))
            {
                btnPagar.Enabled = true;
            }
            else
            {
                btnPagar.Enabled = false;
            }
            if (dtDatos != null)
            {
                dgEmpleados.DataSource = dtDatos;
                dgEmpleados.Columns[23].Visible = false; // idPeriodo
            }
            else
            {
                dgEmpleados.DataSource = ExtraerDato.listadoDatos("select Empleados.idEmpleado, concat(Nombres, ' ', ApellidoP, ' ', ApellidoM) as NOMBRE, SueldoBase as 'SUELDO BASE', SueldoTotal, SueldoPrestaciones, turnoPreferido, prestacionesObligatorias, turnos.nombre, entrada, salida, comida, '' AS 'FALTAS', '' AS 'RETARDOS', '' AS 'BONO ASISTENCIA', '' AS 'BONO PUNTUALIDAD', '' AS 'BONO DESPENSA', '' AS 'BONO PRODUCTIVIDAD', '' AS 'BONO LIBRO', '' AS 'PERCEPCIONES ADICIONALES', '' AS 'DEDUCCIONES ADICIONALES', '' AS 'BANCO', '' AS 'EFECTIVO', '' AS 'TOTAL A PAGAR' from Empleados left join configuracionesAdicionales on Empleados.idEmpleado = configuracionesAdicionales.idEmpleado left join turnos on turnos.idTurno = configuracionesAdicionales.turnoPreferido where Activo = 1 and configuracionesAdicionales.tipoNomina = " + this.iTipoPeriodo);
            }
            try
            {
                dgEmpleados.Columns[0].Visible = false; //idEmpleado
            }
            catch (Exception)
            {
                return;
            }
            dgEmpleados.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Nombre
            dgEmpleados.Columns[1].ReadOnly = true;
            dgEmpleados.Columns[2].Visible = false; // Sueldo base
            dgEmpleados.Columns[3].Visible = false; // Sueldo total
            dgEmpleados.Columns[4].Visible = false; // Sueldo prestaciones
            dgEmpleados.Columns[5].Visible = false; // turnoPreferido
            dgEmpleados.Columns[6].Visible = false; // prestaciones obligatorias
            dgEmpleados.Columns[7].Visible = false; // Nombre turno
            dgEmpleados.Columns[8].Visible = false; // Entrada
            dgEmpleados.Columns[9].Visible = false;  // Salida
            dgEmpleados.Columns[10].Visible = false; // Comida
            dgEmpleados.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Faltas
            dgEmpleados.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Retardos
            dgEmpleados.Columns[11].ReadOnly = true;
            dgEmpleados.Columns[12].ReadOnly = true;
            dgEmpleados.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Bono asistencia
            dgEmpleados.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Bono puntualidad
            dgEmpleados.Columns[15].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Bono despensa
            dgEmpleados.Columns[16].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Bono productiad
            dgEmpleados.Columns[17].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Bono libro
            dgEmpleados.Columns[18].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Percepciones adicionales
            dgEmpleados.Columns[18].ReadOnly = true;
            dgEmpleados.Columns[19].ReadOnly = true;
            dgEmpleados.Columns[19].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Deducciones adicionales
            dgEmpleados.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Banco
            dgEmpleados.Columns[20].ReadOnly = true;
            dgEmpleados.Columns[21].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Efectivo
            dgEmpleados.Columns[21].ReadOnly = true;
            dgEmpleados.Columns[22].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Total a pagar
            dgEmpleados.Columns[22].ReadOnly = true;
        }
        private void dgEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 2)
            {
                if (gridModificado)
                {
                    MessageBox.Show("Se han modificado los detalles de nómina, para generar el previo de recibo debe guardar los cambios", "Nómina modificada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CalculaPrevioNomina(dgEmpleados.CurrentRow.Cells[1].Value.ToString());
            }
        }
        private void CalculaPrevioNomina(string nombreEmpleado)
        {
            lblNombreEmpleadoRecibo.Text = nombreEmpleado;
            DataTable tbPercepcionesPrevio = new DataTable();
            double dPercepciones = 0, dDeducciones = 0;
            tbPercepcionesPrevio.Columns.Add("CONCEPTO");
            tbPercepcionesPrevio.Columns.Add("PAGO");
            DataTable tbDeduccionesPrevio = new DataTable();
            tbDeduccionesPrevio.Columns.Add("CONCEPTO");
            tbDeduccionesPrevio.Columns.Add("PAGO");

            if (ExtraerDato.TieneFilas("select * from periodos where idperiodo = " + cmPeriodos.SelectedValue.ToString() + " and guardado = 1"))
            {
                DataTable infoEmpleado = ExtraerDato.listadoDatos("select bonoAsistencia as 'BONO DE ASISTENCIA', bonoPuntualidad as 'BONO DE PUNTUALIDAD', bonoDespensa as 'BONO DE DESPENSA', bonoProductividad as 'BONO DE PRODUCTIVIDAD', bonoLibro as 'BONO LIBRO', percepciones, deducciones, banco, efectivo, totalPagar from nominaPeriodo where idPeriodo = " + cmPeriodos.SelectedValue + " and idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value);
                for (int i = 0; i < 10; i++)
                {
                    if (i < 5)
                    {
                        if (infoEmpleado.Rows[0][i].ToString().Trim() != "0" & infoEmpleado.Rows[0][i].ToString().Trim() != "")
                        {
                            DataRow row = tbPercepcionesPrevio.NewRow();
                            row[0] = infoEmpleado.Columns[i].ColumnName.ToString();
                            row[1] = ExtraerDato.formatoPesos(double.Parse(infoEmpleado.Rows[0][i].ToString())).Replace("$ ", "");
                            dPercepciones = dPercepciones + double.Parse(infoEmpleado.Rows[0][i].ToString());
                            tbPercepcionesPrevio.Rows.Add(row);
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 5:
                                // Percepciones adicionales
                                DataTable dtPeriodo = new DataTable();
                                DataTable dtFijos = new DataTable();
                                DataTable dtDiferidos = new DataTable();
                                dtPeriodo = ExtraerDato.listadoDatos("select Concepto, pago from ConceptosEmpleados where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value + " and percepcion = 1 and idPeriodo = " + cmPeriodos.SelectedValue);
                                dtFijos = ExtraerDato.listadoDatos("select Concepto, pago from ConceptosEmpleados where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value + " and percepcion = 1 and fijo = 1");
                                DateTime fechaInicioDiferido = ExtraerDato.Fecha("select fechaInicio from Periodos where idPeriodo = " + cmPeriodos.SelectedValue);
                                dtDiferidos = ExtraerDato.listadoDatos("select concepto + ' (Pago ' + Cast((pagosRealizados + 1) as varchar) + ' de ' + Cast(numeroPagos as varchar) + ' )', parcialidades, fechaInicio from pagosDiferidos left join Periodos on pagosDiferidos.idPeriodoInicial = Periodos.idPeriodo where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value + " and pagosFaltantes > 0 and percepcion = 1");
                                foreach (DataRow filaConsulta in dtFijos.Rows)
                                {
                                    DataRow row = tbPercepcionesPrevio.NewRow();
                                    row[0] = filaConsulta[0].ToString();
                                    row[1] = ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())).Replace("$ ", "");
                                    dPercepciones = dPercepciones + double.Parse(filaConsulta[1].ToString());
                                    tbPercepcionesPrevio.Rows.Add(row);
                                }
                                foreach (DataRow filaConsulta in dtPeriodo.Rows)
                                {
                                    DataRow row = tbPercepcionesPrevio.NewRow();
                                    row[0] = filaConsulta[0].ToString();
                                    row[1] = ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())).Replace("$ ", "");
                                    dPercepciones = dPercepciones + double.Parse(filaConsulta[1].ToString());
                                    tbPercepcionesPrevio.Rows.Add(row);
                                }
                                foreach (DataRow filaConsulta in dtDiferidos.Rows)
                                {
                                    DateTime fechaDiferido = (DateTime)filaConsulta[2];
                                    if (fechaDiferido <= fechaInicioDiferido)
                                    {
                                        DataRow row = tbPercepcionesPrevio.NewRow();
                                        row[0] = filaConsulta[0].ToString();
                                        row[1] = ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())).Replace("$ ", "");
                                        dPercepciones = dPercepciones + double.Parse(filaConsulta[1].ToString());
                                        tbPercepcionesPrevio.Rows.Add(row);
                                    }
                                }
                                break;
                            case 6:
                                // Deducciones adicionales
                                dtPeriodo = ExtraerDato.listadoDatos("select Concepto, pago from ConceptosEmpleados where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value + " and percepcion = 0 and idPeriodo = " + cmPeriodos.SelectedValue);
                                dtFijos = ExtraerDato.listadoDatos("select Concepto, pago from ConceptosEmpleados where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value + " and percepcion = 0 and fijo = 1");
                                fechaInicioDiferido = ExtraerDato.Fecha("select fechaInicio from Periodos where idPeriodo = " + cmPeriodos.SelectedValue);
                                dtDiferidos = ExtraerDato.listadoDatos("select concepto + ' (Pago ' + Cast((pagosRealizados + 1) as varchar) + ' de ' + Cast(numeroPagos as varchar) + ' )', parcialidades, fechaInicio from pagosDiferidos left join Periodos on pagosDiferidos.idPeriodoInicial = Periodos.idPeriodo where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value + " and pagosFaltantes > 0 and percepcion = 0");
                                foreach (DataRow filaConsulta in dtFijos.Rows)
                                {
                                    DataRow row = tbDeduccionesPrevio.NewRow();
                                    row[0] = filaConsulta[0].ToString();
                                    row[1] = ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())).Replace("$ ", "");
                                    dDeducciones = dDeducciones + double.Parse(filaConsulta[1].ToString());
                                    tbDeduccionesPrevio.Rows.Add(row);
                                }
                                foreach (DataRow filaConsulta in dtPeriodo.Rows)
                                {
                                    DataRow row = tbDeduccionesPrevio.NewRow();
                                    row[0] = filaConsulta[0].ToString();
                                    row[1] = ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())).Replace("$ ", "");
                                    dDeducciones = dDeducciones + double.Parse(filaConsulta[1].ToString());
                                    tbDeduccionesPrevio.Rows.Add(row);
                                }
                                foreach (DataRow filaConsulta in dtDiferidos.Rows)
                                {
                                    DateTime fechaDiferido = (DateTime)filaConsulta[2];
                                    if (fechaDiferido <= fechaInicioDiferido)
                                    {
                                        DataRow row = tbDeduccionesPrevio.NewRow();
                                        row[0] = filaConsulta[0].ToString();
                                        row[1] = ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())).Replace("$ ", "");
                                        dDeducciones = dDeducciones + double.Parse(filaConsulta[1].ToString());
                                        tbDeduccionesPrevio.Rows.Add(row);
                                    }
                                }
                                break;
                            case 7:
                                txtPagoBanco.Text = ExtraerDato.formatoPesos(double.Parse(infoEmpleado.Rows[0][i].ToString())).Replace("$ ", "");
                                break;
                            case 8:
                                txtPagoEfectivo.Text = ExtraerDato.formatoPesos(double.Parse(infoEmpleado.Rows[0][i].ToString())).Replace("$ ", "");
                                break;
                            case 9:
                                txtTotalPagar.Text = ExtraerDato.formatoPesos(double.Parse(infoEmpleado.Rows[0][i].ToString())).Replace("$ ", "");
                                break;
                        }
                    }
                }
                txtTotalPercepciones.Text = ExtraerDato.formatoPesos(Math.Round(dPercepciones, 2)).ToString().Replace("$ ", "");
                txtTotalDeducciones.Text = ExtraerDato.formatoPesos(Math.Round(dDeducciones, 2)).ToString().Replace("$ ", "");
                dgPercepcionesPrevio.DataSource = tbPercepcionesPrevio;
                dgPercepcionesPrevio.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgPercepcionesPrevio.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgPercepcionesPrevio.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgDeduccionesPrevio.DataSource = tbDeduccionesPrevio;
                dgDeduccionesPrevio.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgDeduccionesPrevio.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgDeduccionesPrevio.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gbPrevioRecibo.Visible = true;
            }
            else
            {
                MessageBox.Show("Para obtener el previo del recibo, primero debe  de guardar la nómina", "No se ha guardado la nómina", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void dgClientes_SelectionChanged(object sender, EventArgs e)
        {
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
            if (rbSemanal.Checked)
            {
                this.iTipoPeriodo = 1;
                this.idPeriodoActual = 0;
                ObtienePeriodo();
            }
        }

        private void rbQuincenal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbQuincenal.Checked)
            {
                this.iTipoPeriodo = 2;
                this.idPeriodoActual = 0;
                ObtienePeriodo();
            }
        }
        private void rbMensual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMensual.Checked)
            {
                this.iTipoPeriodo = 3;
                this.idPeriodoActual = 0;
                ObtienePeriodo();
            }
        }

        private void tbActualiza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Al recargar el listado, se eliminarán las modificaciones que se hayan realizado, incluyendo las que se han guardado. ¿Desea continuar?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cargaGrid();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ExtraerDato.TieneFilas("select * from periodos where idPeriodo = " + cmPeriodos.SelectedValue + " and pagado = 1"))
            {
                MessageBox.Show("No se puede modificar o eliminar un período pagado.", "Período guardado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lblPagada.Visible = true;
            }
            else
            {
                btnCalcularNomina.Enabled = true;
                btnGuardar.Enabled = true;
                btnPagar.Enabled = true;
                lblPagada.Visible = false;
                if (ExtraerDato.TieneFilas("select * from nominaPeriodo where idPeriodo = " + cmPeriodos.SelectedValue))
                {
                    ExtraerDato.AccionQuery("delete from nominaPeriodo where idPeriodo = " + cmPeriodos.SelectedValue);
                }
                GuardaNomina((int)cmPeriodos.SelectedValue);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (ExtraerDato.TieneFilas("select * from periodos where idPeriodo = " + cmPeriodos.SelectedValue + " and pagado = 1"))
            {
                MessageBox.Show("No se puede modificar o eliminar un período pagado.", "Período guardado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lblPagada.Visible = true;
            }
            else
            {
                if (gridModificado)
                {
                    MessageBox.Show("Se han modificado los detalles de nómina, para generar el previo de recibo debe guardar los cambios", "Nómina modificada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                btnCalcularNomina.Enabled = false;
                btnGuardar.Enabled = false;
                btnPagar.Enabled = false;
                lblPagada.Visible = false;
                
                PagarNomina((int)cmPeriodos.SelectedValue);
            }
        }

        private void PagarNomina(int idPeriodo)
        {
            DataTable tbPercepcionesPrevio = new DataTable();
            double dPercepciones = 0, dDeducciones = 0;
            tbPercepcionesPrevio.Columns.Add("CONCEPTO");
            tbPercepcionesPrevio.Columns.Add("PAGO");
            DataTable tbDeduccionesPrevio = new DataTable();
            tbDeduccionesPrevio.Columns.Add("CONCEPTO");
            tbDeduccionesPrevio.Columns.Add("PAGO");
            bool error = false;
            DataTable infoNominas = ExtraerDato.listadoDatos("select idEmpleado from nominaPeriodo where idPeriodo = " + cmPeriodos.SelectedValue);
            foreach (DataRow item in infoNominas.Rows)
            {
                DataTable infoEmpleado = ExtraerDato.listadoDatos("select bonoAsistencia as 'BONO DE ASISTENCIA', bonoPuntualidad as 'BONO DE PUNTUALIDAD', bonoDespensa as 'BONO DE DESPENSA', bonoProductividad as 'BONO DE PRODUCTIVIDAD', bonoLibro as 'BONO LIBRO', percepciones, deducciones, banco, efectivo, totalPagar from nominaPeriodo where idPeriodo = " + cmPeriodos.SelectedValue + " and idEmpleado = " + item[0].ToString());
                for (int i = 0; i < 10; i++)
                {
                    if (i < 5)
                    {
                        if (infoEmpleado.Rows[0][i].ToString().Trim() != "0" & infoEmpleado.Rows[0][i].ToString().Trim() != "")
                        {
                            DataRow row = tbPercepcionesPrevio.NewRow();
                            row[0] = infoEmpleado.Columns[i].ColumnName.ToString();
                            row[1] = ExtraerDato.formatoPesos(double.Parse(infoEmpleado.Rows[0][i].ToString())).Replace("$ ", "");
                            dPercepciones = dPercepciones + double.Parse(infoEmpleado.Rows[0][i].ToString());
                            tbPercepcionesPrevio.Rows.Add(row);
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 5:
                                // Percepciones adicionales
                                DataTable dtPeriodo = new DataTable();
                                DataTable dtFijos = new DataTable();
                                DataTable dtDiferidos = new DataTable();
                                dtPeriodo = ExtraerDato.listadoDatos("select Concepto, pago from ConceptosEmpleados where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value + " and percepcion = 1 and idPeriodo = " + cmPeriodos.SelectedValue);
                                dtFijos = ExtraerDato.listadoDatos("select Concepto, pago from ConceptosEmpleados where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value + " and percepcion = 1 and fijo = 1");
                                DateTime fechaInicioDiferido = ExtraerDato.Fecha("select fechaInicio from Periodos where idPeriodo = " + cmPeriodos.SelectedValue);
                                dtDiferidos = ExtraerDato.listadoDatos("select concepto + ' (Pago ' + Cast((pagosRealizados + 1) as varchar) + ' de ' + Cast(numeroPagos as varchar) + ' )', parcialidades, fechaInicio, idPagoDiferido from pagosDiferidos left join Periodos on pagosDiferidos.idPeriodoInicial = Periodos.idPeriodo where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value + " and pagosFaltantes > 0 and percepcion = 1");
                                foreach (DataRow filaConsulta in dtFijos.Rows)
                                {
                                    DataRow row = tbPercepcionesPrevio.NewRow();
                                    row[0] = filaConsulta[0].ToString();
                                    row[1] = ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())).Replace("$ ", "");
                                    dPercepciones = dPercepciones + double.Parse(filaConsulta[1].ToString());
                                    tbPercepcionesPrevio.Rows.Add(row);
                                }
                                foreach (DataRow filaConsulta in dtPeriodo.Rows)
                                {
                                    DataRow row = tbPercepcionesPrevio.NewRow();
                                    row[0] = filaConsulta[0].ToString();
                                    row[1] = ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())).Replace("$ ", "");
                                    dPercepciones = dPercepciones + double.Parse(filaConsulta[1].ToString());
                                    tbPercepcionesPrevio.Rows.Add(row);
                                }
                                foreach (DataRow filaConsulta in dtDiferidos.Rows)
                                {
                                    DateTime fechaDiferido = (DateTime)filaConsulta[2];
                                    if (fechaDiferido <= fechaInicioDiferido)
                                    {
                                        DataRow row = tbPercepcionesPrevio.NewRow();
                                        row[0] = filaConsulta[0].ToString();
                                        row[1] = ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())).Replace("$ ", "");
                                        ExtraerDato.AccionQuery("update pagosDiferidos set pagosRealizados = pagosRealizados + 1, pagosFaltantes = pagosFaltantes - 1, totalPagado = totalPagado + parcialidades, saldoPendiente = saldoPendiente - parcialidades where idPagoDiferido = " + filaConsulta[3].ToString());
                                        dPercepciones = dPercepciones + double.Parse(filaConsulta[1].ToString());
                                        tbPercepcionesPrevio.Rows.Add(row);
                                    }
                                }
                                break;
                            case 6:
                                // Deducciones adicionales
                                dtPeriodo = ExtraerDato.listadoDatos("select Concepto, pago from ConceptosEmpleados where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value + " and percepcion = 0 and idPeriodo = " + cmPeriodos.SelectedValue);
                                dtFijos = ExtraerDato.listadoDatos("select Concepto, pago from ConceptosEmpleados where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value + " and percepcion = 0 and fijo = 1");
                                fechaInicioDiferido = ExtraerDato.Fecha("select fechaInicio from Periodos where idPeriodo = " + cmPeriodos.SelectedValue);
                                dtDiferidos = ExtraerDato.listadoDatos("select concepto + ' (Pago ' + Cast((pagosRealizados + 1) as varchar) + ' de ' + Cast(numeroPagos as varchar) + ' )', parcialidades, fechaInicio, idPagoDiferido from pagosDiferidos left join Periodos on pagosDiferidos.idPeriodoInicial = Periodos.idPeriodo where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value + " and pagosFaltantes > 0 and percepcion = 0");
                                foreach (DataRow filaConsulta in dtFijos.Rows)
                                {
                                    DataRow row = tbDeduccionesPrevio.NewRow();
                                    row[0] = filaConsulta[0].ToString();
                                    row[1] = ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())).Replace("$ ", "");
                                    dDeducciones = dDeducciones + double.Parse(filaConsulta[1].ToString());
                                    tbDeduccionesPrevio.Rows.Add(row);
                                }
                                foreach (DataRow filaConsulta in dtPeriodo.Rows)
                                {
                                    DataRow row = tbDeduccionesPrevio.NewRow();
                                    row[0] = filaConsulta[0].ToString();
                                    row[1] = ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())).Replace("$ ", "");
                                    dDeducciones = dDeducciones + double.Parse(filaConsulta[1].ToString());
                                    tbDeduccionesPrevio.Rows.Add(row);
                                }
                                foreach (DataRow filaConsulta in dtDiferidos.Rows)
                                {
                                    DateTime fechaDiferido = (DateTime)filaConsulta[2];
                                    if (fechaDiferido <= fechaInicioDiferido)
                                    {
                                        DataRow row = tbDeduccionesPrevio.NewRow();
                                        row[0] = filaConsulta[0].ToString();
                                        row[1] = ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())).Replace("$ ", "");
                                        ExtraerDato.AccionQuery("update pagosDiferidos set pagosRealizados = pagosRealizados + 1, pagosFaltantes = pagosFaltantes - 1, totalPagado = totalPagado + parcialidades, saldoPendiente = saldoPendiente - parcialidades where idPagoDiferido = " + filaConsulta[3].ToString());
                                        dDeducciones = dDeducciones + double.Parse(filaConsulta[1].ToString());
                                        tbDeduccionesPrevio.Rows.Add(row);
                                    }
                                }
                                break;
                        }
                    }
                }
                foreach (DataRow rowConcepto in tbPercepcionesPrevio.Rows)
                {
                    if (!ExtraerDato.AccionQuery("insert into ConceptosReciboNomina (idPeriodo, idEmpleado, concepto, monto, percepcion) values (" + idPeriodo + ", " + item[0].ToString() + ", '" + rowConcepto[0].ToString() + "', " + rowConcepto[1].ToString().Trim().Replace(",", "") + ", 1)"))
                    {
                        error = true;
                    }
                }
                foreach (DataRow rowConcepto in tbDeduccionesPrevio.Rows)
                {
                    if (!ExtraerDato.AccionQuery("insert into ConceptosReciboNomina (idPeriodo, idEmpleado, concepto, monto, percepcion) values (" + idPeriodo + ", " + item[0].ToString() + ", '" + rowConcepto[0].ToString() + "', " + rowConcepto[1].ToString().Trim().Replace(",", "") + ", 0)"))
                    {
                        error = true;
                    }
                }
            }
            if (error)
            {
                MessageBox.Show("Se presentó un error al generar la nómina. Si el problema persiste contacte con el administrador del sistema", "Error al generar nómina", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExtraerDato.AccionQuery("update Periodos set Pagado = 0 where idPeriodo = " + idPeriodo);
                ExtraerDato.AccionQuery("delete from ConceptosReciboNomina where idPeriodo = " + idPeriodo);
            }
            else
            {
                ExtraerDato.AccionQuery("update Periodos set Pagado = 1 where idPeriodo = " + idPeriodo);
                ExtraerDato.AccionQuery("update ConceptosEmpleados set pagado = 1 where idPeriodo = " + idPeriodo);
                MessageBox.Show("Se ha generado correctamente la nómina.", "Nómina generada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnImprimeRecibo.Enabled = true;
            }
        }
        private void btnCaerrar_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcularNomina_Click(object sender, EventArgs e)
        {
            if (ExtraerDato.TieneFilas("select * from periodos where idPeriodo = " + cmPeriodos.SelectedValue + " and pagado = 1"))
            {
                MessageBox.Show("No se puede modificar o eliminar un período pagado.", "Período guardado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnCalcularNomina.Enabled = false;
                btnGuardar.Enabled = false;
                btnPagar.Enabled = false;
                lblPagada.Visible = true;
            }
            else
            {
                if (ExtraerDato.TieneFilas("select * from periodos where guardado = 1 and idPeriodo = " + cmPeriodos.SelectedValue))
                {
                    if (MessageBox.Show("Este período tiene movimientos guardados, al generar la nómina de nuevo, estos cambios se perderán. ¿Desea continuar?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ExtraerDato.AccionQuery("update periodos set guardado = 0 where Pagado = 0 and idPeriodo = " + cmPeriodos.SelectedValue);
                        ExtraerDato.AccionQuery("delete from nominaPeriodo where idPeriodo = " + cmPeriodos.SelectedValue);
                    }
                    else
                    {
                        return;
                    }
                }
                btnCalcularNomina.Enabled = true;
                btnGuardar.Enabled = true;
                btnPagar.Enabled = true;
                lblPagada.Visible = false;
                this.ActualizaTotales = false;
                gridModificado = true;
                bool UnaAsistencia = false;
                foreach (DataGridViewRow fila in dgEmpleados.Rows)
                {
                    int idPeriodo = int.Parse(cmPeriodos.SelectedValue.ToString());
                    // Calcula faltas y retardos
                    int faltas = 0;
                    int retardos = 0;
                    DateTime dtInicio = ExtraerDato.Fecha("select fechainicio from periodos where idPeriodo = " + idPeriodo);
                    DateTime dtFin = ExtraerDato.Fecha("select fechaFin from periodos where idPeriodo = " + idPeriodo);
                    do
                    {
                        DateTime dtPrimerRegistro = ExtraerDato.Fecha("select top(1) fechaHora from asistencias where fechaHora <= '" + Program.FormateoFechaHora(dtInicio.AddDays(1).AddMilliseconds(-1)) + "' and fechaHora >= '" + Program.FormateoFechaHora(dtInicio) + "' and idEmpleado = " + fila.Cells[0].Value.ToString());
                        if (dtPrimerRegistro != Convert.ToDateTime("01/01/1900"))
                        {
                            UnaAsistencia = true;
                            TimeSpan Entrada = (TimeSpan)fila.Cells[8].Value;
                            int retardoDia = (int)Math.Round(dtPrimerRegistro.TimeOfDay.TotalMinutes) - (int)Math.Round(Entrada.TotalMinutes);
                            if (retardoDia > 0)
                            {
                                retardos = retardos + retardoDia;
                            }
                        }
                        else
                        {
                            if (dtInicio.DayOfWeek != 0)
                            {
                                faltas++;
                                fila.Cells[11].Style.BackColor = Color.LightPink;
                            }
                        }
                        dtInicio = dtInicio.AddDays(1);
                    } while (dtFin >= dtInicio);
                    fila.Cells[11].Value = faltas;
                    if (int.Parse(fila.Cells[11].Value.ToString()) > 0)
                    {
                        fila.Cells[11].Style.BackColor = Color.LightPink;
                    }
                    else
                    {
                        fila.Cells[11].Style.BackColor = Color.LightGreen;
                    }
                    fila.Cells[12].Value = retardos;
                    if (retardos > 15)
                    {
                        fila.Cells[12].Style.BackColor = Color.LightPink;
                    }
                    else
                    {
                        fila.Cells[12].Style.BackColor = Color.LightGreen;
                    }

                    // Cálculo de bonos
                    if (fila.Cells[6].Value.ToString().Substring(0, 1) == "1") // asistencia
                    {
                        fila.Cells[13].Value = Math.Round(double.Parse(fila.Cells[4].Value.ToString()) * 0.2, 2);
                    }
                    else
                    {
                        if (faltas > 0)
                        {
                            fila.Cells[13].Value = 0;
                        }
                        else
                        {
                            fila.Cells[13].Value = Math.Round(double.Parse(fila.Cells[4].Value.ToString()) * 0.2, 2);
                        }
                    }
                    if (fila.Cells[6].Value.ToString().Substring(1, 1) == "1") // puntualidad
                    {
                        fila.Cells[14].Value = Math.Round(double.Parse(fila.Cells[4].Value.ToString()) * 0.2, 2);
                    }
                    else
                    {
                        if (retardos > 15)
                        {
                            fila.Cells[14].Value = 0;
                        }
                        else
                        {
                            fila.Cells[14].Value = Math.Round(double.Parse(fila.Cells[4].Value.ToString()) * 0.2, 2);
                        }
                    }
                    if (fila.Cells[6].Value.ToString().Substring(2, 1) == "1") // despensa
                    {
                        fila.Cells[15].Value = Math.Round(double.Parse(fila.Cells[4].Value.ToString()) * 0.1, 2);
                    }
                    else
                    {
                        fila.Cells[15].Value = 0;
                    }
                    if (fila.Cells[6].Value.ToString().Substring(3, 1) == "1") // productividad
                    {
                        fila.Cells[16].Value = Math.Round(double.Parse(fila.Cells[4].Value.ToString()) * 0.4, 2);
                    }
                    else
                    {
                        fila.Cells[16].Value = 0;
                    }
                    if (fila.Cells[6].Value.ToString().Substring(4, 1) == "1") // libro
                    {
                        fila.Cells[17].Value = Math.Round(double.Parse(fila.Cells[4].Value.ToString()) * 0.1, 2);
                    }
                    else
                    {
                        fila.Cells[17].Value = 0;
                    }

                    //Conceptos percepciones
                    double percepciones = ExtraerDato.NumeroReal("select sum(pago) from conceptosempleados where idEmpleado = " + fila.Cells[0].Value + " and Percepcion = 1 and fijo = 1");
                    percepciones = percepciones + ExtraerDato.NumeroReal("select sum(pago) from conceptosempleados where idEmpleado = " + fila.Cells[0].Value + " and Percepcion = 1 and fijo = 0 and idPeriodo = " + idPeriodo);

                    //Conceptos percepciones
                    double deducciones = ExtraerDato.NumeroReal("select sum(pago) from conceptosempleados where idEmpleado = " + fila.Cells[0].Value + " and Percepcion = 0 and fijo = 1");
                    deducciones = deducciones + ExtraerDato.NumeroReal("select sum(pago) from conceptosempleados where idEmpleado = " + fila.Cells[0].Value + " and Percepcion = 0 and fijo = 0 and idPeriodo = " + idPeriodo);

                    // Pagos diferidos
                    DateTime fechaInicioDiferido = ExtraerDato.Fecha("select fechaInicio from Periodos where idPeriodo = " + idPeriodo);
                    DataTable dtDiferidos = ExtraerDato.listadoDatos("select idPagoDiferido, Periodos.fechaInicio, parcialidades, percepcion from pagosDiferidos left join Periodos on pagosDiferidos.idPeriodoInicial = Periodos.idPeriodo where idEmpleado = " + fila.Cells[0].Value.ToString() + " and pagosFaltantes > 0");
                    foreach (DataRow filaRow in dtDiferidos.Rows)
                    {
                        DateTime fechaDiferido = (DateTime)filaRow[1];
                        if (fechaDiferido <= fechaInicioDiferido)
                        {
                            if (filaRow[3].ToString() == "1")
                            {
                                percepciones = percepciones + double.Parse(filaRow[2].ToString());
                            }
                            else
                            {
                                deducciones = deducciones + double.Parse(filaRow[2].ToString());
                            }
                        }
                    }
                    fila.Cells[18].Value = percepciones;
                    fila.Cells[18].Style.BackColor = Color.LightGreen;

                    fila.Cells[19].Value = deducciones;
                    fila.Cells[19].Style.BackColor = Color.LightPink;
                    // Total a pagar
                    double totalPagarEfectivo = double.Parse(fila.Cells[13].Value.ToString()) + double.Parse(fila.Cells[14].Value.ToString()) + double.Parse(fila.Cells[15].Value.ToString()) + double.Parse(fila.Cells[16].Value.ToString()) + double.Parse(fila.Cells[17].Value.ToString()) + percepciones - deducciones;

                    if (ckAsistenciaObligatoria.Checked)
                    {
                        if (UnaAsistencia)
                        {
                            fila.Cells[20].Value = Math.Round((double)fila.Cells[2].Value, 2);
                        }
                        else
                        {
                            fila.Cells[20].Value = 0;
                        }
                    }
                    else
                    {
                        fila.Cells[20].Value = Math.Round((double)fila.Cells[2].Value, 2);
                    }
                    fila.Cells[21].Value = Math.Round(totalPagarEfectivo, 2);
                    fila.Cells[22].Value = Math.Round(totalPagarEfectivo + Math.Round(double.Parse(fila.Cells[20].Value.ToString()), 2), 2);
                }
                dgEmpleados.Columns[18].ContextMenuStrip = cmAgregaConcepto;
                dgEmpleados.Columns[19].ContextMenuStrip = cmAgregaConcepto;
                this.ActualizaTotales = true;
                btnGuardar.Enabled = true;
                btnPagar.Enabled = true;
                ActualizaTotalesGenerales();
                VisibilidadTotales(true);
            }
        }

        private void cmPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable infoNomina = ExtraerDato.listadoDatos("select idEmpleado, Nombre, sueldoBase, sueldoTotal, sueldoPrestaciones, turnoPreferido, prestacionesObligatorias, nombreTurno, entrada, salida, comida, faltas, retardos, bonoAsistencia as 'BONO ASISTENCIA', bonoPuntualidad AS 'BONO PUNTUALIDAD', bonoDespensa AS 'BONO DESPENSA', bonoProductividad AS 'BONO PRODUCTIVIDAD', bonoLibro AS 'BONO LIBRO', percepciones AS 'PERCEPCIONES ADICIONALES', deducciones AS 'DEDUCCIONES ADICIONALES', BANCO, EFECTIVO, totalPagar AS 'TOTAL A PAGAR', idPeriodo from nominaPeriodo where idPeriodo = " + cmPeriodos.SelectedValue);
            if (infoNomina.Rows.Count > 0)
            {
                cargaGrid(infoNomina);
                btnGuardar.Enabled = true;
                dgEmpleados.Columns[18].DefaultCellStyle.BackColor = Color.LightGreen;
                dgEmpleados.Columns[19].DefaultCellStyle.BackColor = Color.LightPink;
                dgEmpleados.ContextMenuStrip = cmAgregaConcepto;
                VisibilidadTotales(true);
                ActualizaTotalesGenerales();
                btnPagar.Enabled = true;
            }
            else
            {
                dgEmpleados.ContextMenuStrip = null;
                btnGuardar.Enabled = false;
                dgEmpleados.Enabled = false;
                cargaGrid();
                VisibilidadTotales(false);
            }
        }
        private void GuardaNomina(int idPeriodo)
        {
            bool correcto = false;
            if (ExtraerDato.TieneFilas("select * from nominaPeriodo where idPeriodo = " + idPeriodo))
            {
                if (MessageBox.Show("Este período tiene una nómina guardada. ¿Desea sobreescribir los datos guardados?", "Existen registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            foreach (DataGridViewRow fila in dgEmpleados.Rows)
            {
                if (ExtraerDato.AccionQuery("insert into nominaPeriodo (idEmpleado, Nombre, sueldoBase, sueldoTotal, sueldoPrestaciones, turnoPreferido, prestacionesObligatorias, nombreTurno, entrada, salida, comida, faltas, retardos, bonoAsistencia, bonoPuntualidad, bonoDespensa, bonoProductividad, bonoLibro, percepciones, deducciones, banco, efectivo, totalPagar, idPeriodo) values (" + fila.Cells[0].Value.ToString() + ", '" + fila.Cells[1].Value.ToString() + "', " + fila.Cells[2].Value.ToString() + ", " + fila.Cells[3].Value.ToString() + ", " + fila.Cells[4].Value.ToString() + ", '" + fila.Cells[5].Value.ToString() + "', " + fila.Cells[6].Value.ToString() + ", '" + fila.Cells[7].Value.ToString() + "', '" + Program.FormateoFechaHora((DateTime.Today + (TimeSpan)fila.Cells[8].Value)) + "', '" + Program.FormateoFechaHora((DateTime.Today + (TimeSpan)fila.Cells[9].Value)) + "', " + fila.Cells[10].Value.ToString().ToString() + ", " + fila.Cells[11].Value.ToString() + ", " + fila.Cells[12].Value.ToString() + ", '" + fila.Cells[13].Value.ToString() + "', " + fila.Cells[14].Value.ToString() + ", " + fila.Cells[15].Value.ToString() + ", " + fila.Cells[16].Value.ToString() + ", '" + fila.Cells[17].Value.ToString() + "', " + fila.Cells[18].Value.ToString() + ", " + fila.Cells[19].Value.ToString() + ", " + fila.Cells[20].Value.ToString() + ", '" + fila.Cells[21].Value.ToString() + "', " + fila.Cells[22].Value.ToString() + ", " + idPeriodo + ") "))
                {
                    correcto = true;
                    ExtraerDato.AccionQuery("update periodos set guardado = 1 where idPeriodo = " + idPeriodo);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro de nómina de " + fila.Cells[1].Value.ToString() + ". Si el problema persiste, consulte al administrador del sistema.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (correcto)
            {
                MessageBox.Show("Se han guardado correctamente los registros de nómina.", "Nómina guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridModificado = false;
            }
        }

        private void dgEmpleados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.ActualizaTotales)
            {
                if (dgEmpleados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                {
                    if (e.ColumnIndex > 12 & e.ColumnIndex < 18)
                    {
                        calculaTotales(e.RowIndex);
                    }
                }
            }
        }
        private void calculaTotales(int fila)
        {
            try
            {
                double pagoBanco = Math.Round(double.Parse(dgEmpleados.Rows[fila].Cells[20].Value.ToString()), 2);
                double total = Math.Round(
                    double.Parse(dgEmpleados.Rows[fila].Cells[13].Value.ToString().Replace(" ", "")) + // Bono asistencia
                    double.Parse(dgEmpleados.Rows[fila].Cells[14].Value.ToString().Replace(" ", "")) + // Bono puntualidad
                    double.Parse(dgEmpleados.Rows[fila].Cells[15].Value.ToString().Replace(" ", "")) + // Bono despensa
                    double.Parse(dgEmpleados.Rows[fila].Cells[16].Value.ToString().Replace(" ", "")) + // Bono productiad
                    double.Parse(dgEmpleados.Rows[fila].Cells[17].Value.ToString().Replace(" ", "")) + // Bono libro
                    double.Parse(dgEmpleados.Rows[fila].Cells[18].Value.ToString().Replace(" ", "")) - // Percepciones adicionales
                    double.Parse(dgEmpleados.Rows[fila].Cells[19].Value.ToString().Replace(" ", "")) + // Deducciones adicionales
                    pagoBanco, 2); // Monto banco
                dgEmpleados.Rows[fila].Cells[20].Value = pagoBanco;
                dgEmpleados.Rows[fila].Cells[21].Value = Math.Round(total - pagoBanco, 2);
                dgEmpleados.Rows[fila].Cells[22].Value = total;
            }
            catch { }
        }

        private void agregarConceptoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregaConcepto agrega = new frmAgregaConcepto(0, (int) dgEmpleados.CurrentRow.Cells[0].Value, (int) cmPeriodos.SelectedValue);
            agrega.ShowDialog();
            gridModificado = true;
            ActualizaTotalesBonos();
        }
        private void ActualizaTotalesBonos()
        {
            int idEmpleado = int.Parse(dgEmpleados.CurrentRow.Cells[0].Value.ToString());
            int idPeriodo = (int)cmPeriodos.SelectedValue;
            //Conceptos percepciones
            double percepciones = ExtraerDato.NumeroReal("select sum(pago) from conceptosempleados where idEmpleado = " + idEmpleado + " and Percepcion = 1 and fijo = 1");
            percepciones = percepciones + ExtraerDato.NumeroReal("select sum(pago) from conceptosempleados where idEmpleado = " + idEmpleado + " and Percepcion = 1 and fijo = 0 and idPeriodo = " + idPeriodo);

            //Conceptos percepciones
            double deducciones = ExtraerDato.NumeroReal("select sum(pago) from conceptosempleados where idEmpleado = " + idEmpleado + " and Percepcion = 0 and fijo = 1");
            deducciones = deducciones + ExtraerDato.NumeroReal("select sum(pago) from conceptosempleados where idEmpleado = " + idEmpleado + " and Percepcion = 0 and fijo = 0 and idPeriodo = " + idPeriodo);

            // Pagos diferidos
            DateTime fechaInicioDiferido = ExtraerDato.Fecha("select fechaInicio from Periodos where idPeriodo = " + idPeriodo);
            DataTable dtDiferidos = ExtraerDato.listadoDatos("select idPagoDiferido, Periodos.fechaInicio, parcialidades, percepcion from pagosDiferidos left join Periodos on pagosDiferidos.idPeriodoInicial = Periodos.idPeriodo where idEmpleado = " + idEmpleado + " and pagosFaltantes > 0");
            foreach (DataRow filaRow in dtDiferidos.Rows)
            {
                DateTime fechaDiferido = (DateTime)filaRow[1];
                if (fechaDiferido <= fechaInicioDiferido)
                {
                    if (filaRow[3].ToString() == "1")
                    {
                        percepciones = percepciones + double.Parse(filaRow[2].ToString());
                    }
                    else
                    {
                        deducciones = deducciones + double.Parse(filaRow[2].ToString());
                    }
                }
            }
            dgEmpleados.CurrentRow.Cells[18].Value = percepciones;
            dgEmpleados.CurrentRow.Cells[18].Style.BackColor = Color.LightGreen;

            dgEmpleados.CurrentRow.Cells[19].Value = deducciones;
            dgEmpleados.CurrentRow.Cells[19].Style.BackColor = Color.LightPink;
            // Total a pagar
            double totalPagarEfectivo = double.Parse(dgEmpleados.CurrentRow.Cells[13].Value.ToString()) + double.Parse(dgEmpleados.CurrentRow.Cells[14].Value.ToString()) + double.Parse(dgEmpleados.CurrentRow.Cells[15].Value.ToString()) + double.Parse(dgEmpleados.CurrentRow.Cells[16].Value.ToString()) + double.Parse(dgEmpleados.CurrentRow.Cells[17].Value.ToString()) + percepciones - deducciones;

            dgEmpleados.CurrentRow.Cells[20].Value = Math.Round((double)dgEmpleados.CurrentRow.Cells[2].Value, 2);
            dgEmpleados.CurrentRow.Cells[21].Value = Math.Round(totalPagarEfectivo, 2);
            dgEmpleados.CurrentRow.Cells[22].Value = Math.Round(totalPagarEfectivo + Math.Round((double)dgEmpleados.CurrentRow.Cells[2].Value, 2), 2);
            ActualizaTotalesGenerales();
        }
        private void eliminarConceptoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgEmpleados_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView.HitTestInfo Hitest = dgEmpleados.HitTest(e.X, e.Y);
                string valor = dgEmpleados.Rows[Hitest.RowIndex].Cells[Hitest.ColumnIndex].Value.ToString();
                if (valor == "" | valor == "0")
                {
                    return;
                }
                if (Hitest.Type == DataGridViewHitTestType.Cell)
                {
                    switch (Hitest.ColumnIndex)
                    {
                        case 18:
                            EnlistarMovimientos(1, Hitest.RowIndex, e.X, e.Y);
                            break;
                        case 19:
                            EnlistarMovimientos(0, Hitest.RowIndex, e.X, e.Y);
                            break;
                    }
                }
                else
                {
                    lblInfoMovimientos.Visible = false;
                }
            }
            catch
            {
                lblInfoMovimientos.Visible = false;
            }
        }
        private void EnlistarMovimientos(int percepcion, int fila, int X, int Y)
        {
            int idPeriodo = (int)cmPeriodos.SelectedValue;
            int idEmpleado = (int)dgEmpleados.Rows[fila].Cells[0].Value;
            DataTable dtPeriodo = new DataTable();
            DataTable dtFijos = new DataTable();
            DataTable dtDiferidos = new DataTable();
            dtPeriodo = ExtraerDato.listadoDatos("select Concepto, pago from ConceptosEmpleados where idEmpleado = " + idEmpleado + " and percepcion = " + percepcion + " and idPeriodo = " + idPeriodo);
            dtFijos = ExtraerDato.listadoDatos("select Concepto, pago from ConceptosEmpleados where idEmpleado = " + idEmpleado + " and percepcion = " + percepcion + " and fijo = 1");
            DateTime fechaInicioDiferido = ExtraerDato.Fecha("select fechaInicio from Periodos where idPeriodo = " + idPeriodo);
            dtDiferidos = ExtraerDato.listadoDatos("select concepto, parcialidades, fechaInicio from pagosDiferidos left join Periodos on pagosDiferidos.idPeriodoInicial = Periodos.idPeriodo where idEmpleado = " + idEmpleado + " and pagosFaltantes > 0 and percepcion = " + percepcion);
            lblInfoMovimientos.Text = "";
            string textoInfo = "";
            if (dtPeriodo.Rows.Count > 0)
            {
                textoInfo = "*** MOVIMIENTOS POR PERÍODO ***";
                foreach (DataRow filaConsulta in dtPeriodo.Rows)
                {
                    textoInfo += "\n" + ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())) + "        \t" + filaConsulta[0].ToString();
                }
            }
            if (dtFijos.Rows.Count > 0)
            {
                textoInfo += "\n\n*** MOVIMIENTOS FIJOS ***";
                foreach (DataRow filaConsulta in dtFijos.Rows)
                {
                    textoInfo += "\n" + ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())) + "        \t" + filaConsulta[0].ToString();
                }
            }
            if (dtDiferidos.Rows.Count > 0)
            {
                textoInfo += "\n\n*** PAGOS DIFERIDOS ***";
                int iConceptos = 0;
                foreach (DataRow filaConsulta in dtDiferidos.Rows)
                {
                    DateTime fechaDiferido = (DateTime)filaConsulta[2];
                    if (fechaDiferido <= fechaInicioDiferido)
                    {
                        iConceptos++;
                        textoInfo += "\n" + ExtraerDato.formatoPesos(double.Parse(filaConsulta[1].ToString())) + "        \t" + filaConsulta[0].ToString();
                    }
                }
                if (iConceptos == 0 )
                {
                    textoInfo = textoInfo.Replace("*** PAGOS DIFERIDOS ***", "").Trim();
                }
            }
            lblInfoMovimientos.Text = textoInfo.Trim();
            lblInfoMovimientos.Left = X + 10;
            lblInfoMovimientos.Top = Y + 16;
            lblInfoMovimientos.Visible = true;
        }

        private void btnImprimeRecibo_Click(object sender, EventArgs e)
        {
            Impresoras.ShowDialog();
            if (Impresoras != null)
            {
                Impresion.PrinterSettings.PrinterName = Impresoras.PrinterSettings.PrinterName;
                string StrSQL = "select distinct(idEmpleado), idPeriodo from ConceptosReciboNomina where idPeriodo = " + cmPeriodos.SelectedValue;
                bPrimerRecibo = true;

                Pcnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
                Pcnn.Open();

                Pcmd = new SqlCommand(StrSQL, Pcnn);
                Plee = Pcmd.ExecuteReader();
                Impresion.Print();
            }
        }

        private void Impresion_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font Font10B = new Font("Arial", 10, FontStyle.Bold);
            Font Font10N = new Font("Arial", 10, FontStyle.Regular);
            Font Font8N = new Font("Arial", 8, FontStyle.Regular);
            Font Font8B = new Font("Arial", 8, FontStyle.Bold);
            int iPos = 50;
            int iRelP = 0;
            int iRelD = 0;

            string sTemp;
            string sTem2;

            string sNombre = "";

            #region Variables matriz
            string[,] sVariables = new string[1, 2];
            int iVariables = 0;

            string[,] sVariablesP = new string[1, 3];
            int iVariablesP = 0;

            string[,] sVariablesD = new string[1, 3];
            int iVariablesD = 0;

            double dbTotalPer = 0;
            double dbTotalDed = 0;
            double dbMonto = 0;

            #endregion

            Point Punto = new Point(10, iPos);
            Rectangle Rectangulo = new Rectangle(Punto, new Size(55, 100));

            // Construct 2 new StringFormat objects
            StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);

            //formatos de alineación
            StringFormat CentradoTotal = new StringFormat(format1);
            CentradoTotal.LineAlignment = StringAlignment.Center;
            CentradoTotal.Alignment = StringAlignment.Center;

            StringFormat CentradoDerecho = new StringFormat(format1);
            CentradoDerecho.LineAlignment = StringAlignment.Center;
            CentradoDerecho.Alignment = StringAlignment.Far;

            StringFormat CentradoIzquierdo = new StringFormat(format1);
            CentradoIzquierdo.LineAlignment = StringAlignment.Center;
            CentradoIzquierdo.Alignment = StringAlignment.Near;

            int iConP = 0;
            int iConD = 0;
            DateTime fechaInicio = ExtraerDato.Fecha("SELECT FECHAINICIO FROM PERIODOS WHERE IDPERIODO = " + cmPeriodos.SelectedValue);
            DateTime fechaFinal = ExtraerDato.Fecha("SELECT FECHAFIN FROM PERIODOS WHERE IDPERIODO = " + cmPeriodos.SelectedValue);

            DataTable dtEmpleadoPeriodo = ExtraerDato.listadoDatos("select distinct(idEmpleado), idPeriodo from ConceptosReciboNomina where idPeriodo = " + cmPeriodos.SelectedValue);

            foreach (DataRow fila in dtEmpleadoPeriodo.Rows)
            {
                string[] infoEmpleado = ExtraerDato.CadenaArrayFila("select Codigo, Concat(ApellidoP, ' ', ApellidoM, ' ', Nombres) as Nombre, Puesto from Empleados where idEmpleado = " + fila[0].ToString());

                SqlConnection cnn;
                SqlCommand cmd;
                SqlDataReader lee;

                SizeF MedidaTexto;

                string StrSQL;

                try
                {
                    cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
                    cnn.Open();

                    

                    while (Plee.Read())
                    {
                        if (bPrimerRecibo)
                        {
                            iPos = 50;
                            e.Graphics.DrawRectangle(Pens.Black, 10f, 50f, 690f, 450f);
                        }
                        else
                        {
                            iPos = 550;
                            e.Graphics.DrawRectangle(Pens.Black, 10f, 550f, 690f, 450f);
                        }
                        //Codigo
                        Punto = new Point(10, iPos + Font10B.Height);
                        Rectangulo = new Rectangle(Punto, new Size(70, Font10B.Height));
                        e.Graphics.DrawString("Codigo", Font10B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                        //Codigo VALOR
                        Punto = new Point(80, iPos + Font10B.Height);
                        Rectangulo = new Rectangle(Punto, new Size(30, Font10B.Height));
                        e.Graphics.DrawString(Plee.GetValue(1).ToString(), Font10N, Brushes.Black, (Rectangle)Rectangulo, CentradoTotal);
                        //Nombre
                        Punto = new Point(110, iPos + Font10B.Height);
                        Rectangulo = new Rectangle(Punto, new Size(90, Font10B.Height));
                        e.Graphics.DrawString("Nombre", Font10B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                        //Nombre VALOR
                        Punto = new Point(200, iPos + Font10B.Height);
                        Rectangulo = new Rectangle(Punto, new Size(500, Font10B.Height));
                        e.Graphics.DrawString(Plee.GetValue(2).ToString(), Font10N, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                        //PERIODO
                        Punto = new Point(490, iPos + Font10B.Height);
                        Rectangulo = new Rectangle(Punto, new Size(100, Font10B.Height));
                        e.Graphics.DrawString("PERIODO", Font10B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                        //VALOR PERIODO
                        Punto = new Point(590, iPos + Font10B.Height);
                        Rectangulo = new Rectangle(Punto, new Size(150, Font10B.Height));
                        e.Graphics.DrawString(ExtraerDato.Cadena("SELECT NPERIODO FROM PERIODOS WHERE IDPERIODO = " + cmPeriodos.SelectedValue), Font10N, Brushes.Black, (Rectangle)Rectangulo, CentradoTotal);
                        //RANGO PERIODO
                        Punto = new Point(490, iPos + Font10B.Height * 2);
                        Rectangulo = new Rectangle(Punto, new Size(35, Font10B.Height));
                        e.Graphics.DrawString("DEL", Font10B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                        //VALOR RANGO PERIODO
                        Punto = new Point(525, iPos + Font10B.Height * 2);
                        Rectangulo = new Rectangle(Punto, new Size(175, Font10B.Height));
                        e.Graphics.DrawString(Program.FechaDiagonales(ExtraerDato.Fecha("SELECT FECHAINICIO FROM PERIODOS WHERE IDPERIODO = " + cmPeriodos.SelectedValue)) + " AL " + Program.FechaDiagonales(ExtraerDato.Fecha("SELECT FECHAFIN FROM PERIODOS WHERE IDPERIODO = " + cmPeriodos.SelectedValue)), Font10N, Brushes.Black, (Rectangle)Rectangulo, CentradoTotal);
                        if (!rbSemanal.Checked)
                        {
                            string[] horasT = ExtraerDato.CadenaArrayFila("select horas, HorasExtras from AsisPeriodo where IdPeriodo = " + cmPeriodos.SelectedValue + " and IdEmpleado = (select IdEmpleado from EMPLEADOS where codigo = " + Plee.GetValue(1).ToString() + ")");
                            //HORAS LABORALES
                            Punto = new Point(490, iPos + Font10B.Height * 3);
                            Rectangulo = new Rectangle(Punto, new Size(200, Font10B.Height));
                            e.Graphics.DrawString("HORAS LABORALES: ", Font10B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                            //VALOR HORAS LABORALES
                            Punto = new Point(590, iPos + Font10B.Height * 3);
                            Rectangulo = new Rectangle(Punto, new Size(150, Font10B.Height));
                            //e.Graphics.DrawString(calculaHoras(fechaInicio, fechaFinal, ExtraerDato.Cadena("select IDTURNO from EMPLEADOS where CODIGO = " + Plee.GetValue(1).ToString())).ToString(), Font10N, Brushes.Black, (Rectangle)Rectangulo, CentradoTotal);
                            //HORAS TRABAJADAS
                            Punto = new Point(10, iPos + Font10B.Height * 3);
                            Rectangulo = new Rectangle(Punto, new Size(170, Font10B.Height));
                            e.Graphics.DrawString("HORAS TRABAJADAS: ", Font10B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                            //VALOR HORAS TRABAJADAS
                            Punto = new Point(160, iPos + Font10B.Height * 3);
                            Rectangulo = new Rectangle(Punto, new Size(40, Font10B.Height));
                            e.Graphics.DrawString(horasT[0], Font10N, Brushes.Black, (Rectangle)Rectangulo, CentradoTotal);
                            //HORAS LEXTRA
                            Punto = new Point(250, iPos + Font10B.Height * 3);
                            Rectangulo = new Rectangle(Punto, new Size(150, Font10B.Height));
                            e.Graphics.DrawString("HORAS EXTRA: ", Font10B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                            //VALOR HORAS EXTRA
                            Punto = new Point(350, iPos + Font10B.Height * 3);
                            Rectangulo = new Rectangle(Punto, new Size(40, Font10B.Height));
                            e.Graphics.DrawString(horasT[1], Font10N, Brushes.Black, (Rectangle)Rectangulo, CentradoTotal);
                        }
                        //SUELDOXHORA
                        Punto = new Point(10, iPos + Font10B.Height * 2);
                        Rectangulo = new Rectangle(Punto, new Size(150, Font10B.Height));
                        e.Graphics.DrawString("SUELDO POR HORA", Font10B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                        //VALOR SUELDOHORA
                        Punto = new Point(160, iPos + Font10B.Height * 2);
                        Rectangulo = new Rectangle(Punto, new Size(75, Font10B.Height));
                        e.Graphics.DrawString(Plee.GetValue(3).ToString(), Font10N, Brushes.Black, (Rectangle)Rectangulo, CentradoTotal);
                        //encabezado PD
                        Punto = new Point(10, iPos + Font10B.Height * 4);
                        Rectangulo = new Rectangle(Punto, new Size(345, Font10B.Height));
                        e.Graphics.DrawRectangle(Pens.Black, Rectangulo);
                        e.Graphics.DrawString("PERCEPCIONES", Font10B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                        Punto = new Point(355, iPos + Font10B.Height * 4);
                        Rectangulo = new Rectangle(Punto, new Size(345, Font10B.Height));
                        e.Graphics.DrawRectangle(Pens.Black, Rectangulo);
                        e.Graphics.DrawString("DEDUCCIONES", Font10B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                        //CUADRO PD
                        Punto = new Point(10, iPos + Font10B.Height * 5);
                        Rectangulo = new Rectangle(Punto, new Size(345, 450 - (Font10B.Height * 6 + Font8N.Height * 7))); //345
                        e.Graphics.DrawRectangle(Pens.Black, Rectangulo);
                        Punto = new Point(355, iPos + Font10B.Height * 5);
                        Rectangulo = new Rectangle(Punto, new Size(345, 450 - (Font10B.Height * 6 + Font8N.Height * 7)));
                        e.Graphics.DrawRectangle(Pens.Black, Rectangulo);
                        //MOVIMIENTOS

                        int iAlto;

                        StrSQL = "SELECT IDNOMINA FROM NOMINADIRECCION WHERE IDPERIODO = " + cmPeriodos.SelectedValue + " AND IDEMPLEADO = " + Plee.GetValue(0).ToString();
                        cmd = new SqlCommand(StrSQL, cnn);
                        lee = cmd.ExecuteReader();
                        if (lee.HasRows == true)
                        {
                            lee.Read();
                            string sIdNomina = lee.GetValue(0).ToString();
                            lee.Close();

                            iRelP = 1;
                            iRelD = 1;

                            dbTotalPer = 0;
                            dbTotalDed = 0;
                            iConP = 0;
                            iConD = 0;
                            #region Percepciones y deducciones
                            //StrSQL = "SELECT FORMULASNOM.Codigo, MOVTOSFORMULAS.MONTO, FORMULASNOM.DEDUCCION FROM FORMULASNOM INNER JOIN MOVTOSFORMULAS ON FORMULASNOM.IDFORMULA = MOVTOSFORMULAS.IDFORMULA WHERE MOVTOSFORMULAS.IDNOMINA IN (SELECT IDNOMINA FROM NOMINADIRECCION WHERE IDPERIODO = " + cmPeriodos.SelectedValue + " AND IDEMPLEADO = " + Plee.GetValue(0).ToString() + ")";
                            StrSQL = "select concepto, cantidad, deduccion from imprimeRecibos where IDPERIODO = " + cmPeriodos.SelectedValue + " AND IDEMPLEADO = " + Plee.GetValue(0).ToString() + " order by id";
                            cmd = new SqlCommand(StrSQL, cnn);
                            lee = cmd.ExecuteReader();
                            while (lee.Read())
                            {
                                //if (Plee.GetValue(0).ToString() == "64")
                                // {
                                //     int uno = 1;
                                // }

                                if (!Convert.ToBoolean(lee.GetValue(2)))
                                {
                                    dbTotalPer = dbTotalPer + Convert.ToDouble(lee.GetValue(1));

                                    dbMonto = Convert.ToDouble(lee.GetValue(1));
                                    if (dbMonto > 0)
                                    {
                                        sNombre = lee.GetValue(0).ToString().Replace("_", " ");
                                        MedidaTexto = e.Graphics.MeasureString(sNombre, Font8B);

                                        iAlto = 1;
                                        if (Convert.ToInt16(MedidaTexto.Width) > 245)
                                            iAlto = (Convert.ToInt16(MedidaTexto.Width) / 245) + 2;


                                        Punto = new Point(10, iPos + (Font10B.Height * 5) + iConP);
                                        Rectangulo = new Rectangle(Punto, new Size(245, Font8B.Height * iAlto));

                                        if (sNombre.Substring(sNombre.Length - 1) == "2")
                                            sNombre = sNombre.Substring(0, sNombre.Length - 1);

                                        e.Graphics.DrawString(sNombre, Font8B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                                        Punto = new Point(255, iPos + (Font10B.Height * 5) + iConP);
                                        Rectangulo = new Rectangle(Punto, new Size(100, Font8B.Height));
                                        e.Graphics.DrawString(dbMonto.ToString("0.00"), Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoDerecho);
                                        iRelP = iRelP + 1;

                                        iConP = iConP + Font8B.Height * iAlto;

                                    }
                                }
                                else
                                {
                                    dbTotalDed = dbTotalDed + +Convert.ToDouble(lee.GetValue(1));

                                    sNombre = lee.GetValue(0).ToString().Replace("_", " ");
                                    MedidaTexto = e.Graphics.MeasureString(sNombre, Font8B);

                                    iAlto = 1;
                                    if (Convert.ToInt16(MedidaTexto.Width) > 245)
                                        iAlto = (Convert.ToInt16(MedidaTexto.Width) / 245) + 2;



                                    Punto = new Point(355, iPos + (Font10B.Height * 5) + iConD);
                                    Rectangulo = new Rectangle(Punto, new Size(245, Font8B.Height * iAlto));

                                    e.Graphics.DrawString(lee.GetValue(0).ToString().Replace("_", " "), Font8B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                                    Punto = new Point(600, iPos + (Font10B.Height * 5) + iConD);
                                    Rectangulo = new Rectangle(Punto, new Size(100, Font8B.Height));
                                    dbMonto = Convert.ToDouble(lee.GetValue(1));
                                    e.Graphics.DrawString(dbMonto.ToString("0.00"), Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoDerecho);

                                    iRelD = iRelD + 1;
                                    iConD = iConD + Font10B.Height * iAlto;
                                }
                            }
                            lee.Close();
                            #endregion
                        }
                        else
                        {
                            lee.Close();
                            //AsignaEspacios();
                            //AsignaEspaciosF();

                            dbTotalPer = 0;
                            dbTotalDed = 0;

                            iConP = 0;
                            iConD = 0;

                            #region Movimientos Formulas

                            try
                            {
                                string sCondicion;
                                string sCondicionT;
                                string sCondicionF;

                                string sAnteC;
                                string sDespC;

                                sNombre = "";

                                int iPosC1 = 0;
                                int iPosC2 = 0;

                                int i;
                                int j;
                                int iInd = -1;

                                /*
                                //lleno variables
                                sTemp = sVariables[1, 0];
                                for (i = 2; i < iVariables; i++)
                                {
                                    sTemp = sTemp + ", " + sVariables[i, 0];
                                }
                                StrSQL = "SELECT " + sTemp + " FROM ASISPERIODO WHERE IDEMPLEADO = " + Plee.GetValue(0).ToString() + " AND IDPERIODO = " + cmPeriodos.SelectedValue;
                                */
                                StrSQL = "SELECT IDEMPLEADO, IDPERIODO FROM ASISPERIODO WHERE IDEMPLEADO = " + Plee.GetValue(0).ToString() + " AND IDPERIODO = " + cmPeriodos.SelectedValue;
                                cmd = new SqlCommand(StrSQL, cnn);
                                lee = cmd.ExecuteReader();
                                if (lee.HasRows == true)
                                {
                                    /*
                                    lee.Read();
                                    iPosF = lee.FieldCount;
                                    for (i = 0; i < iPosF; i++)
                                    {
                                        sVariables[i + 1, 1] = Convert.ToString(lee.GetValue(i));
                                    }
                                     */
                                    lee.Close();
                                    //CargaValores(Plee.GetValue(0).ToString(), cmPeriodos.SelectedValue);

                                    iRelP = 1;
                                    //Percepciones
                                    for (i = 0; i < iVariablesP; i++)
                                    {
                                        for (j = 0; j < iVariables; j++)
                                        {
                                            sTemp = sVariablesP[i, 1].ToLower();
                                            sTem2 = sVariables[j, 0].ToLower();
                                            iInd = sTemp.IndexOf(sTem2);
                                            if (iInd > -1)
                                            {
                                                sVariablesP[i, 1] = sTemp.Replace(sTem2, sVariables[j, 1]);
                                            }
                                        }
                                        for (j = 0; j < iVariablesP; j++)
                                        {
                                            sTemp = sVariablesP[i, 1].ToLower();
                                            sTem2 = sVariablesP[j, 0].ToLower();
                                            iInd = sTemp.IndexOf(sTem2);
                                            if (iInd > -1)
                                            {
                                                sVariablesP[i, 1] = sTemp.Replace(sTem2, sVariablesP[j, 1]);
                                            }
                                        }
                                        //Falta validar si muestra
                                        if (sVariablesP[i, 1].Substring(0, 3).ToUpper() == "SSI")
                                        {
                                            sTemp = sVariablesP[i, 1];
                                            iPosC1 = sTemp.IndexOf(",");
                                            iPosC2 = sTemp.IndexOf(",", iPosC1 + 1);
                                            sCondicion = sTemp.Substring(4, iPosC1 - 4);
                                            sCondicionT = sTemp.Substring(iPosC1 + 1, iPosC2 - iPosC1 - 1);
                                            sCondicionF = sTemp.Substring(iPosC2 + 1);
                                            sCondicionF = sCondicionF.Replace(">", "");
                                            //<
                                            iPosC1 = sCondicion.IndexOf("<");
                                            if (iPosC1 > -1)
                                            {
                                                sAnteC = sCondicion.Substring(0, iPosC1);
                                                if (sCondicion.Contains("="))
                                                {
                                                    sDespC = sCondicion.Substring(iPosC1 + 1);
                                                    if (Convert.ToDouble(sAnteC) <= Convert.ToDouble(sDespC))
                                                        sTemp = sCondicionT;
                                                    else
                                                        sTemp = sCondicionF;
                                                }
                                                else
                                                {
                                                    sDespC = sCondicion.Substring(iPosC1 + 2);
                                                    if (Convert.ToDouble(sAnteC) < Convert.ToDouble(sDespC))
                                                        sTemp = sCondicionT;
                                                    else
                                                        sTemp = sCondicionF;
                                                }
                                            }
                                            //>
                                            iPosC1 = sCondicion.IndexOf(">");
                                            if (iPosC1 > -1)
                                            {
                                                sAnteC = sCondicion.Substring(0, iPosC1);
                                                if (sCondicion.Contains("="))
                                                {
                                                    sDespC = sCondicion.Substring(iPosC1 + 2);
                                                    if (Convert.ToDouble(sAnteC) >= Convert.ToDouble(sDespC))
                                                        sTemp = sCondicionT;
                                                    else
                                                        sTemp = sCondicionF;
                                                }
                                                else
                                                {
                                                    sDespC = sCondicion.Substring(iPosC1 + 1);
                                                    if (Convert.ToDouble(sAnteC) > Convert.ToDouble(sDespC))
                                                        sTemp = sCondicionT;
                                                    else
                                                        sTemp = sCondicionF;
                                                }
                                            }
                                            //=
                                            iPosC1 = sCondicion.IndexOf("=");
                                            if (iPosC1 > -1)
                                            {
                                                sAnteC = sCondicion.Substring(0, iPosC1);
                                                sDespC = sCondicion.Substring(iPosC1 + 1);
                                                if (Convert.ToDouble(sAnteC) == Convert.ToDouble(sDespC))
                                                    sTemp = sCondicionT;
                                                else
                                                    sTemp = sCondicionF;
                                            }
                                            //sTemp = EvaluarExpresiones.Evaluar(sTemp);
                                        }
                                        else
                                            //sTemp = EvaluarExpresiones.Evaluar(sVariablesP[i, 1]);
                                            sVariablesP[i, 1] = null;
                                        if (sVariablesP[i, 2] == "Si")
                                        {
                                            dbTotalPer = dbTotalPer + Convert.ToDouble(55);

                                            dbMonto = Convert.ToDouble(55);
                                            if (dbMonto > 0)
                                            {
                                                //Punto = new Point(10, iPos + (Font10B.Height * 5) + Font8N.Height * iRelP);
                                                // Rectangulo = new Rectangle(Punto, new Size(245, Font10B.Height));
                                                // sNombre = sVariablesP[i, 0].Replace("_", " ");
                                                //  e.Graphics.DrawString(sNombre.Replace("2", ""), Font8B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                                                //  Punto = new Point(255, iPos + (Font10B.Height * 5) + Font8N.Height * iRelP);
                                                //  Rectangulo = new Rectangle(Punto, new Size(100, Font10B.Height));
                                                //  e.Graphics.DrawString(dbMonto.ToString("0.00"), Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoDerecho);
                                                //   iRelP = iRelP + 1;

                                                sNombre = sVariablesP[i, 0].Replace("_", " ");
                                                MedidaTexto = e.Graphics.MeasureString(sNombre, Font8B);

                                                iAlto = 1;
                                                if (Convert.ToInt16(MedidaTexto.Width) > 245)
                                                    iAlto = (Convert.ToInt16(MedidaTexto.Width) / 245) + 2;


                                                Punto = new Point(10, iPos + (Font10B.Height * 5) + iConP);
                                                Rectangulo = new Rectangle(Punto, new Size(245, Font8B.Height * iAlto));

                                                if (sNombre.Substring(sNombre.Length - 1) == "2")
                                                    sNombre = sNombre.Substring(0, sNombre.Length - 1);

                                                e.Graphics.DrawString(sNombre, Font8B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                                                Punto = new Point(255, iPos + (Font10B.Height * 5) + iConP);
                                                Rectangulo = new Rectangle(Punto, new Size(100, Font8B.Height));
                                                e.Graphics.DrawString(dbMonto.ToString("0.00"), Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoDerecho);
                                                iRelP = iRelP + 1;

                                                iConP = iConP + Font8B.Height * iAlto;
                                            }
                                        }
                                    }
                                    if (true)
                                    {
                                        //Deducciones
                                        iRelD = 1;
                                        for (i = 0; i < iVariablesD; i++)
                                        {
                                            for (j = 0; j < iVariables; j++)
                                            {
                                                sTemp = sVariablesD[i, 1].ToLower();
                                                sTem2 = sVariables[j, 0].ToLower();
                                                iInd = sTemp.IndexOf(sTem2);
                                                if (iInd > -1)
                                                {
                                                    sVariablesD[i, 1] = sTemp.Replace(sTem2, sVariables[j, 1]);
                                                }
                                            }
                                            for (j = 0; j < iVariablesD; j++)
                                            {
                                                sTemp = sVariablesD[i, 1].ToLower();
                                                sTem2 = sVariablesD[j, 0].ToLower();
                                                iInd = sTemp.IndexOf(sTem2);
                                                if (iInd > -1)
                                                {
                                                    sVariablesD[i, 1] = sTemp.Replace(sTem2, sVariablesD[j, 1]);
                                                }
                                            }
                                            //Falta validar si muestra
                                            if (sVariablesD[i, 1].Substring(0, 3).ToUpper() == "SSI")
                                            {
                                                sTemp = sVariablesD[i, 1];
                                                iPosC1 = sTemp.IndexOf(",");
                                                iPosC2 = sTemp.IndexOf(",", iPosC1 + 1);
                                                sCondicion = sTemp.Substring(4, iPosC1 - 4);
                                                sCondicionT = sTemp.Substring(iPosC1 + 1, iPosC2 - iPosC1 - 1);
                                                sCondicionF = sTemp.Substring(iPosC2 + 1);
                                                sCondicionF = sCondicionF.Replace(">", "");
                                                //<
                                                iPosC1 = sCondicion.IndexOf("<");
                                                if (iPosC1 > -1)
                                                {
                                                    sAnteC = sCondicion.Substring(0, iPosC1);
                                                    if (sCondicion.Contains("="))
                                                    {
                                                        sDespC = sCondicion.Substring(iPosC1 + 2);
                                                        if (Convert.ToDouble(sAnteC) <= Convert.ToDouble(sDespC))
                                                            sTemp = sCondicionT;
                                                        else
                                                            sTemp = sCondicionF;
                                                    }
                                                    else
                                                    {
                                                        sDespC = sCondicion.Substring(iPosC1 + 1);
                                                        if (Convert.ToDouble(sAnteC) < Convert.ToDouble(sDespC))
                                                            sTemp = sCondicionT;
                                                        else
                                                            sTemp = sCondicionF;
                                                    }
                                                }
                                                //>
                                                iPosC1 = sCondicion.IndexOf(">");
                                                if (iPosC1 > -1)
                                                {
                                                    sAnteC = sCondicion.Substring(0, iPosC1);
                                                    if (sCondicion.Contains("="))
                                                    {
                                                        sDespC = sCondicion.Substring(iPosC1 + 1);
                                                        if (Convert.ToDouble(sAnteC) >= Convert.ToDouble(sDespC))
                                                            sTemp = sCondicionT;
                                                        else
                                                            sTemp = sCondicionF;
                                                    }
                                                    else
                                                    {
                                                        sDespC = sCondicion.Substring(iPosC1 + 2);
                                                        if (Convert.ToDouble(sAnteC) > Convert.ToDouble(sDespC))
                                                            sTemp = sCondicionT;
                                                        else
                                                            sTemp = sCondicionF;
                                                    }
                                                }
                                                //=
                                                iPosC1 = sCondicion.IndexOf("=");
                                                if (iPosC1 > -1)
                                                {
                                                    sAnteC = sCondicion.Substring(0, iPosC1);
                                                    sDespC = sCondicion.Substring(iPosC1 + 1);
                                                    if (Convert.ToDouble(sAnteC) == Convert.ToDouble(sDespC))
                                                        sTemp = sCondicionT;
                                                    else
                                                        sTemp = sCondicionF;
                                                }
                                                sTemp = null;// EvaluarExpresiones.Evaluar(sTemp);
                                            }
                                            else
                                                sTemp = null; // EvaluarExpresiones.Evaluar(sVariablesD[i, 1]);
                                            sVariablesD[i, 1] = sTemp;
                                            if (sVariablesD[i, 2] == "Si")
                                            {
                                                dbTotalDed = dbTotalDed + +Convert.ToDouble(sTemp);

                                                //  Punto = new Point(355, iPos + (Font10B.Height * 5) + Font8N.Height * iRelD);
                                                //  Rectangulo = new Rectangle(Punto, new Size(245, Font10B.Height));
                                                //  e.Graphics.DrawString(sVariablesD[i, 0].Replace("_", " "), Font8B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                                                // Punto = new Point(600, iPos + (Font10B.Height * 5) + Font8N.Height * iRelD);
                                                // Rectangulo = new Rectangle(Punto, new Size(100, Font10B.Height));
                                                // dbMonto = Convert.ToDouble(sTemp);
                                                //e.Graphics.DrawString(dbMonto.ToString("0.00"), Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoDerecho);

                                                //iRelD = iRelD + 1;

                                                sNombre = sVariablesD[i, 0].Replace("_", " ");
                                                MedidaTexto = e.Graphics.MeasureString(sNombre, Font8B);

                                                iAlto = 1;
                                                if (Convert.ToInt16(MedidaTexto.Width) > 245)
                                                    iAlto = (Convert.ToInt16(MedidaTexto.Width) / 245) + 2;

                                                Punto = new Point(355, iPos + (Font10B.Height * 5) + iConD);
                                                Rectangulo = new Rectangle(Punto, new Size(245, Font8B.Height * iAlto));

                                                e.Graphics.DrawString(lee.GetValue(0).ToString().Replace("_", " "), Font8B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                                                Punto = new Point(600, iPos + (Font10B.Height * 5) + Font8B.Height + iConD);
                                                Rectangulo = new Rectangle(Punto, new Size(100, Font8B.Height));
                                                dbMonto = Convert.ToDouble(lee.GetValue(1));
                                                e.Graphics.DrawString(dbMonto.ToString("0.00"), Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoDerecho);

                                                iRelD = iRelD + 1;
                                                iConD = iConD + Font10B.Height * iAlto;
                                            }
                                        }//Termina deducciones
                                    }
                                }
                                else
                                    lee.Close();
                            }
                            catch
                            {

                            }

                            #endregion

                            #region movimientos

                            try
                            {
                                StrSQL = "SELECT CONCEPTO, MONTO, AUTORIZADO, IDCONCEPTO FROM CONCEPTODEDUC WHERE DEDUCCION = 0 AND IDEMPLEADO = " + Plee.GetValue(0).ToString() + "  AND (PAGOS = -1 OR PAGOS > REALIZADOS AND FECHADOC >= '" + Program.FormateoFecha(ExtraerDato.Fecha("SELECT FECHAINICIO FROM PERIODOS WHERE IDPERIODO = " + cmPeriodos.SelectedValue)) + "') AND AUTORIZADO = 0";
                                cmd = new SqlCommand(StrSQL, cnn);
                                lee = cmd.ExecuteReader();
                                while (lee.Read())
                                {
                                    dbTotalPer = dbTotalPer + Convert.ToDouble(lee.GetValue(1));

                                    // Punto = new Point(10, iPos + (Font10B.Height * 5) + Font8N.Height * iRelP);
                                    //Rectangulo = new Rectangle(Punto, new Size(245, Font10B.Height));
                                    //  e.Graphics.DrawString(lee.GetValue(0).ToString(), Font8B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                                    //  Punto = new Point(255, iPos + (Font10B.Height * 5) + Font8N.Height * iRelP);
                                    //  Rectangulo = new Rectangle(Punto, new Size(100, Font10B.Height));
                                    dbMonto = Convert.ToDouble(lee.GetValue(1));
                                    //  e.Graphics.DrawString(dbMonto.ToString("0.00"), Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoDerecho);
                                    //  iRelP = iRelP + 1;

                                    sNombre = lee.GetValue(0).ToString().Replace("_", " ");
                                    MedidaTexto = e.Graphics.MeasureString(sNombre, Font8B);

                                    iAlto = 1;
                                    if (Convert.ToInt16(MedidaTexto.Width) > 245)
                                        iAlto = (Convert.ToInt16(MedidaTexto.Width) / 245) + 2;


                                    Punto = new Point(10, iPos + (Font10B.Height * 5) + iConP);
                                    Rectangulo = new Rectangle(Punto, new Size(245, Font8B.Height * iAlto));

                                    if (sNombre.Substring(sNombre.Length - 1) == "2")
                                        sNombre = sNombre.Substring(0, sNombre.Length - 1);

                                    e.Graphics.DrawString(sNombre, Font8B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                                    Punto = new Point(255, iPos + (Font10B.Height * 5) + iConP);
                                    Rectangulo = new Rectangle(Punto, new Size(100, Font8B.Height));
                                    e.Graphics.DrawString(dbMonto.ToString("0.00"), Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoDerecho);
                                    iRelP = iRelP + 1;

                                    iConP = iConP + Font8B.Height * iAlto;
                                }
                                lee.Close();
                            }
                            catch
                            {

                            }


                            #endregion
                        }
                        //TOTAL PERCEPCIONES
                        Punto = new Point(10, iPos + (Font10B.Height * 5) + (450 - (Font10B.Height * 6 + Font8N.Height * 7)));
                        Rectangulo = new Rectangle(Punto, new Size(345, Font10B.Height));
                        e.Graphics.DrawRectangle(Pens.Black, Rectangulo);
                        Rectangulo = new Rectangle(Punto, new Size(245, Font10B.Height));
                        e.Graphics.DrawString("TOTAL PERCEPCIONES", Font8B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                        Punto = new Point(255, iPos + (Font10B.Height * 5) + (450 - (Font10B.Height * 6 + Font8N.Height * 7)));
                        Rectangulo = new Rectangle(Punto, new Size(100, Font10B.Height));
                        e.Graphics.DrawRectangle(Pens.Black, Rectangulo);
                        e.Graphics.DrawString(dbTotalPer.ToString("0.00"), Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoDerecho);
                        //TOTAL DEDUCCIONES
                        Punto = new Point(355, iPos + (Font10B.Height * 5) + (450 - (Font10B.Height * 6 + Font8N.Height * 7)));
                        Rectangulo = new Rectangle(Punto, new Size(345, Font10B.Height));
                        e.Graphics.DrawRectangle(Pens.Black, Rectangulo);
                        Rectangulo = new Rectangle(Punto, new Size(245, Font10B.Height));
                        e.Graphics.DrawString("TOTAL DEDUCCIONES", Font8B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                        Punto = new Point(600, iPos + (Font10B.Height * 5) + (450 - (Font10B.Height * 6 + Font8N.Height * 7)));
                        Rectangulo = new Rectangle(Punto, new Size(100, Font10B.Height));
                        e.Graphics.DrawRectangle(Pens.Black, Rectangulo);
                        e.Graphics.DrawString(dbTotalDed.ToString("0.00"), Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoDerecho);
                        //TOTAL A PAGAR
                        Punto = new Point(355, iPos + (Font10B.Height * 6) + (450 - (Font10B.Height * 6 + Font8N.Height * 7)));
                        Rectangulo = new Rectangle(Punto, new Size(345, Font10B.Height));
                        e.Graphics.DrawRectangle(Pens.Black, Rectangulo);
                        Rectangulo = new Rectangle(Punto, new Size(245, Font10B.Height));
                        e.Graphics.DrawString("TOTAL SALARIO", Font8B, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                        Punto = new Point(600, iPos + (Font10B.Height * 6) + (450 - (Font10B.Height * 6 + Font8N.Height * 7)));
                        Rectangulo = new Rectangle(Punto, new Size(100, Font10B.Height));
                        e.Graphics.DrawRectangle(Pens.Black, Rectangulo);
                        dbMonto = dbTotalPer - dbTotalDed;
                        e.Graphics.DrawString(dbMonto.ToString("0.00"), Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoDerecho);
                        //LEYENDA
                        Punto = new Point(10, iPos + (Font10B.Height * 8) + (450 - (Font10B.Height * 6 + Font8N.Height * 7)));
                        Rectangulo = new Rectangle(Punto, new Size(345, Font8N.Height * 4));
                        e.Graphics.DrawString("Recibí de la empresa la cantidad total de salario a que este documento se refiere, estando conforme con las percepciones y deducciones que en el aparecen especificados", Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);
                        //FIRMA EMPLEADO
                        Punto = new Point(355, iPos + (Font10B.Height * 8) + (450 - (Font10B.Height * 6 + Font8N.Height * 7)));
                        Rectangulo = new Rectangle(Punto, new Size(345, Font8N.Height * 4));
                        e.Graphics.DrawString("                              Firma empleado                                                                  ________________________________________________", Font8N, Brushes.Black, (Rectangle)Rectangulo, CentradoIzquierdo);

                        //termino
                        if (bPrimerRecibo)
                            bPrimerRecibo = false;
                        else
                        {
                            bPrimerRecibo = true;
                            break;
                        }
                    }
                    try
                    {
                        if (Plee.IsDBNull(0) == false)
                            e.HasMorePages = true;
                    }
                    catch
                    {

                    }

                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ocurrio el siguiente error");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GuardaConceptoListado();
            ActualizaTotalesBonos();
            gbConceptos.Visible = false;
        }
        private void GuardaConceptoListado()
        {
            gridModificado = true;
            ExtraerDato.AccionQuery("delete from ConceptosEmpleados where idEmpleado = " + dgEmpleados.CurrentRow.Cells[0].Value.ToString() + " and fijo = 1");
            foreach (DataGridViewRow filaPercepcion in dgPercepciones.Rows)
            {
                // (dgPercepciones) idConcepto, percepcion, CONCEPTO, PAGO as 'PAGO SUGERIDO', '0' as PAGO
                if (filaPercepcion.Cells[4].Value.ToString().Trim() != "" & filaPercepcion.Cells[4].Value.ToString().Trim() != "0")
                {
                    ExtraerDato.AccionQuery("insert into ConceptosEmpleados (idEmpleado, idConcepto, fijo, Concepto, Pago, Percepcion) values (" + dgEmpleados.CurrentRow.Cells[0].Value.ToString() + ", " + filaPercepcion.Cells[0].Value.ToString() + ", 1, '" + filaPercepcion.Cells[2].Value.ToString() + "', " + filaPercepcion.Cells[4].Value.ToString() + ", 1)");
                }
            }
            foreach (DataGridViewRow filaDeduccion in dgDeducciones.Rows)
            {
                // (dgPercepciones) idConcepto, percepcion, CONCEPTO, PAGO as 'PAGO SUGERIDO', '0' as PAGO
                if (filaDeduccion.Cells[4].Value.ToString().Trim() != "" & filaDeduccion.Cells[4].Value.ToString().Trim() != "0")
                {
                    ExtraerDato.AccionQuery("insert into ConceptosEmpleados (idEmpleado, idConcepto, fijo, Concepto, Pago, Percepcion) values (" + dgEmpleados.CurrentRow.Cells[0].Value.ToString() + ", " + filaDeduccion.Cells[0].Value.ToString() + ", 1, '" + filaDeduccion.Cells[2].Value.ToString() + "', " + filaDeduccion.Cells[4].Value.ToString() + ", 0)");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            gbConceptos.Visible = false;
        }

        private void dgPercepciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double valor = double.Parse(dgPercepciones.CurrentCell.Value.ToString());
                dgPercepciones.CurrentCell.Value = Math.Round(valor, 2);
            }
            catch
            {
                MessageBox.Show("Solo se aceptan valores numéricos.", "Error en datos de entrada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dgPercepciones.CurrentCell.Value = 0;
            }
        }

        private void dgDeducciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double valor = double.Parse(dgDeducciones.CurrentCell.Value.ToString());
                dgDeducciones.CurrentCell.Value = Math.Round(valor, 2);
            }
            catch
            {
                MessageBox.Show("Solo se aceptan valores numéricos.", "Error en datos de entrada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dgDeducciones.CurrentCell.Value = 0;
            }
        }

        private void dgEmpleados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double valor = double.Parse(dgEmpleados.CurrentCell.Value.ToString().Replace(" ", ""));
                dgEmpleados.CurrentCell.Value = Math.Round(valor, 2);
                calculaTotales(e.RowIndex);
                gridModificado = true;
            }
            catch
            {
                MessageBox.Show("Solo se aceptan valores numéricos.", "Error en datos de entrada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dgEmpleados.CurrentCell.Value = 0;
            }
        }
        private void VisibilidadTotales(bool ver)
        {
            textBox1.Visible = ver;
            textBox2.Visible = ver;
            textBox3.Visible = ver;
            label1.Visible = ver;
            label2.Visible = ver;
            label3.Visible = ver;
            label4.Visible = ver;
        }
        private void ActualizaTotalesGenerales()
        {
            double totalBanco = 0; //20
            double totalEfectivo = 0; //21
            double totalPagar = 0; //22
            foreach (DataGridViewRow fila in dgEmpleados.Rows)
            {
                totalBanco = totalBanco + double.Parse(fila.Cells[20].Value.ToString());
                totalEfectivo = totalEfectivo + double.Parse(fila.Cells[21].Value.ToString());
                totalPagar = totalPagar + double.Parse(fila.Cells[22].Value.ToString());
            }
            textBox1.Text = ExtraerDato.formatoPesos(totalBanco).Replace("$ ", "").Trim();
            textBox2.Text = ExtraerDato.formatoPesos(totalEfectivo).Replace("$ ", "").Trim();
            textBox3.Text = ExtraerDato.formatoPesos(totalPagar).Replace("$ ", "").Trim();
        }

        private void btnCerrarPrevio_Click(object sender, EventArgs e)
        {
            gbPrevioRecibo.Visible = false;
        }
    }
}