using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public partial class frmConfiguracionNomina : Form
    {
        int idActual = 0;
        int idConceptoActual = 0;
        int iTurnoActual = 0;
        int idPeriodo = 0;
        int iTipoPeriodo = 2;

        public frmConfiguracionNomina()
        {
            InitializeComponent();
            ActualizaGridsConceptos();
        }
        private void frmConfiguracionNomina_Load(object sender, EventArgs e)
        {
            dtFinPeriodo.MinDate = dtInicioPeriodo.Value;
            CargaPeriodos();
            CargaTurnos();
            dgPeriodos.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            dgPercepciones.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            dgDeducciones.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            dgTurnos.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
        }

        private void ActualizaGridsConceptos()
        {
            DataTable dtPercepciones;
            DataTable dtDeducciones;
            dgPercepciones.ContextMenuStrip = null;
            dgDeducciones.ContextMenuStrip = null;

            dtPercepciones = ExtraerDato.listadoDatos("select idConcepto, percepcion, CONCEPTO, PAGO from ConceptosAdicionales where percepcion = 1 order by idConcepto desc");
            dgPercepciones.DataSource = dtPercepciones;
            try
            {
                dgPercepciones.Columns[0].Visible = false;
                dgPercepciones.Columns[1].Visible = false;
                dgPercepciones.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgPercepciones.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgPercepciones.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgPercepciones.ContextMenuStrip = cmsEliminarConcepto;
            }
            catch { }

            dtDeducciones = ExtraerDato.listadoDatos("select idConcepto, percepcion, CONCEPTO, PAGO from ConceptosAdicionales where percepcion = 0 order by idConcepto desc");
            dgDeducciones.DataSource = dtDeducciones;
            try
            {
                dgDeducciones.Columns[0].Visible = false;
                dgDeducciones.Columns[1].Visible = false;
                dgDeducciones.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgDeducciones.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgPercepciones.ContextMenuStrip = cmsEliminarConcepto;
            }
            catch { }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }
        private void lblIdEmpleado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                idActual = int.Parse(lblIdEmpleado.Text);
            }
            catch { }
        }

        private void rbSemanal_CheckedChanged(object sender, EventArgs e)
        {
            this.iTipoPeriodo = 1;
            this.idPeriodo = 0;
            CargaPeriodos();
        }

        private void rbQuincenal_CheckedChanged(object sender, EventArgs e)
        {
            this.iTipoPeriodo = 2;
            this.idPeriodo = 0;
            CargaPeriodos();
        }

        private void rbMensual_CheckedChanged(object sender, EventArgs e)
        {
            this.iTipoPeriodo = 3;
            this.idPeriodo = 0;
            CargaPeriodos();
        }
        private void CargaPeriodos()
        {
            DataTable dtPeriodos = ExtraerDato.listadoDatos("select idPeriodo, fechaInicio as 'Fecha de inicial', fechaFin as 'Fecha de final', Pagado from Periodos where tipo = " + this.iTipoPeriodo + " order by fechaInicio asc");
            if (dtPeriodos.Rows.Count > 0)
            {
                dgPeriodos.ContextMenuStrip = cmPeriodos;
                dgPeriodos.DataSource = dtPeriodos;
                dgPeriodos.Columns[0].Visible = false;
                dgPeriodos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgPeriodos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgPeriodos.Columns[3].Visible = false;
            }
            else
            {
                dgPeriodos.DataSource = null;
                dgPeriodos.ContextMenuStrip = null;
            }
        }
        private void btnGuardaPeriodo_Click(object sender, EventArgs e)
        {
            if (evaluaFechas(dtInicioPeriodo.Value, dtFinPeriodo.Value))
            {
                if (this.idPeriodo == 0)
                {
                    if (ExtraerDato.AccionQuery("insert into periodos (tipo, fechaInicio, fechaFin, Pagado, guardado) values (" + this.iTipoPeriodo + ", '" + Program.FormateoFecha(dtInicioPeriodo.Value) + "', '" + Program.FormateoFecha(dtFinPeriodo.Value) + "', 0, 0)"))
                    {
                        MessageBox.Show("Se ha guardado correctamente el período nuevo.", "Período nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaPeriodos();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar el período nuevo.", "Error en período nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (!EvaluaPeriodo(this.idPeriodo))
                    {
                        if (ExtraerDato.TieneFilas("select * from periodos where pagado = 0 and idPeriodo = " + this.idPeriodo))
                        {
                            if (ExtraerDato.AccionQuery("update periodos set fechaInicio = '" + Program.FormateoFecha(dtInicioPeriodo.Value) + "', fechaFin = '" + Program.FormateoFecha(dtFinPeriodo.Value) + "' where tipo = " + this.iTipoPeriodo + " and idPeriodo = " + this.idPeriodo))
                            {
                                MessageBox.Show("Se ha modificado corrrectamente el período.", "Período modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargaPeriodos();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puede modificar un período que ya ha sido pagado.", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede modificar un período PAGADO o que tiene movimientos guardados en el módulo de Nómina.", "No se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Las fechas seleccionadas no pueden pertenecer a otro período.", "Conflicto en fechas de período", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool EvaluaPeriodo(int idPeriodo)
        {
            return ExtraerDato.AccionQuery("select * from periodos where idPeriodo = " + idPeriodo + " and (Pagado = 1 or guardado = 1)");
        }
        private void btnNuevoPeriodo_Click(object sender, EventArgs e)
        {
            this.idPeriodo = 0;
            dtInicioPeriodo.Value = DateTime.Now;
        }
        private bool evaluaFechas(DateTime dtInicio, DateTime dtFin)
        {
            bool exitoso = true;
            do
            {
                if (ExtraerDato.TieneFilas("select * from periodos where fechaInicio <= '" + Program.FormateoFecha(dtInicio) + "' and fechaFin >= '" + Program.FormateoFecha(dtInicio) + "' and idPeriodo != " + this.idPeriodo + " and Tipo = " + this.iTipoPeriodo))
                {
                    exitoso = false;
                    break;
                }
                dtInicio = dtInicio.AddDays(1);
            } while (dtFin >= dtInicio);
            return exitoso;
        }

        private void dtInicioPeriodo_ValueChanged(object sender, EventArgs e)
        {
            dtFinPeriodo.MinDate = dtInicioPeriodo.Value;
        }

        private void eliminaPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.idPeriodo != 0)
            {
                if (MessageBox.Show("Realmente desea eliminar el período seleccionado? Esta acción no se puede deshacer", "Eliminar período", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgPeriodos.CurrentRow.Cells[3].Value.ToString() == "0")
                    {
                        if (ExtraerDato.AccionQuery("delete from periodos where idPeriodo = " + this.idPeriodo))
                        {
                            MessageBox.Show("Se ha eliminado el período seleccionado", "Período eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al eliminar el período seleccionado. Si el error persiste, contacte con el administrador del sistema", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar un período que ya ha sido pagado.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dgPeriodos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionaPeriodo();
        }

        private void dgPeriodos_SelectionChanged(object sender, EventArgs e)
        {
            SeleccionaPeriodo();
        }
        private void SeleccionaPeriodo()
        {
            try
            {
                this.idPeriodo = int.Parse(dgPeriodos.CurrentRow.Cells[0].Value.ToString());
                dtInicioPeriodo.Value = (DateTime)dgPeriodos.CurrentRow.Cells[1].Value;
                dtFinPeriodo.Value = (DateTime)dgPeriodos.CurrentRow.Cells[2].Value;
            }
            catch { }
        }

        private void btnGuardaConcepto_Click(object sender, EventArgs e)
        {
            if (txtConcepto.Text != "")
            {
                if (this.idConceptoActual == 0)
                {
                    if (ExtraerDato.AccionQuery("insert into ConceptosAdicionales (percepcion, concepto, pago) values (" + (rbPercepcion.Checked ? "1" : "0") + ", '" + txtConcepto.Text.Trim().ToUpper() + "', " + nPago.Value.ToString() + ")"))
                    {
                        MessageBox.Show("Se ha guardado correctamente.", "Concepto guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizaGridsConceptos();
                        LimpiaCamposConceptos();
                    }
                    else
                    {
                        MessageBox.Show("El concepto no se pudo guardar. Si el problema persiste, contacte al administrador del sistema.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (ExtraerDato.AccionQuery("update ConceptosAdicionales set percepcion = " + (rbPercepcion.Checked ? "1" : "0") + ", concepto = '" + txtConcepto.Text.Trim().ToUpper() + "', pago = " + nPago.Value.ToString() + " where idConcepto = " + this.idConceptoActual))
                    {
                        MessageBox.Show("Se ha modificado correctamente.", "Concepto guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizaGridsConceptos();
                        LimpiaCamposConceptos();
                    }
                    else
                    {
                        MessageBox.Show("El concepto no se pudo modificar. Si el problema persiste, contacte al administrador del sistema.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("El concepto no puede estar vacío.", "Sin concepto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LimpiaCamposConceptos()
        {
            rbPercepcion.Checked = true;
            txtConcepto.Text = "";
            nPago.Value = 0;
            this.idConceptoActual = 0;
        }

        private void eliminarConceptoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.idConceptoActual != 0)
            {
                if (MessageBox.Show("¿Realmente desea eliminar este concepto?", "Eliminar concepto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ExtraerDato.AccionQuery("delete from ConceptosAdicionales where idConcepto = " + this.idConceptoActual))
                    {
                        MessageBox.Show("Se ha eliminado correctamente.", "Concepto eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizaGridsConceptos();
                    }
                    else
                    {
                        MessageBox.Show("El concepto no se pudo eliminar. Si el problema persiste, contacte al administrador del sistema.", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgPercepciones_SelectionChanged(object sender, EventArgs e)
        {
            LlenarCamposConceptos(dgPercepciones.CurrentRow);
        }
        private void dgPercepciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarCamposConceptos(dgPercepciones.CurrentRow);
        }
        private void dgDeducciones_SelectionChanged(object sender, EventArgs e)
        {
            LlenarCamposConceptos(dgDeducciones.CurrentRow);
        }
        private void dgDeducciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarCamposConceptos(dgDeducciones.CurrentRow);
        }
        private void LlenarCamposConceptos(DataGridViewRow fila)
        {
            try
            {
                this.idConceptoActual = int.Parse(fila.Cells[0].Value.ToString());
                rbPercepcion.Checked = fila.Cells[1].Value.ToString() == "1" ? true : false;
                rbDeduccion.Checked = fila.Cells[1].Value.ToString() != "1" ? true : false;
                txtConcepto.Text = fila.Cells[2].Value.ToString();
                nPago.Value = decimal.Parse(fila.Cells[3].Value.ToString());
            }
            catch { }
        }

        private void btnNuevoConcepto_Click(object sender, EventArgs e)
        {
            LimpiaCamposConceptos();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea eliminar el turno " + dgTurnos.CurrentRow.Cells[1].Value.ToString() + "? Esta acción no se puede deshacer.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ExtraerDato.AccionQuery("delete from turnos where idTurno = " + dgTurnos.CurrentRow.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Se ha eliminado el turno.", "Turno eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargaTurnos();
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminar el turno. Si el problema persiste, contacte al administrasdor del sistema", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            limpiaCamposTurnos();
        }
        private void btnGuardaTurno_Click(object sender, EventArgs e)
        {
            if (dtHoraEntrada.Value < dtHoraSalida.Value)
            {
                if (txtNombreTurno.Text.Trim() != "")
                {
                    if (this.iTurnoActual == 0)
                    {
                        if (ExtraerDato.AccionQuery("insert into turnos (nombre, entrada, salida, comida) values ('" + txtNombreTurno.Text.Trim().ToUpper() + "', '" + Program.FormateoFechaHora(dtHoraEntrada.Value) + "', '" + Program.FormateoFechaHora(dtHoraSalida.Value) + "', '" + nMinutosComida.Value + "')"))
                        {
                            MessageBox.Show("Se ha guardado correctamente el turno.", "Turno guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargaTurnos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el turno. Si el problema persiste, contacte con el administrador de sistema.", "Error al guardar el turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (ExtraerDato.AccionQuery("update turnos set nombre = '" + txtNombreTurno.Text.Trim().ToUpper() + "', entrada = '" + Program.FormateoFechaHora(dtHoraEntrada.Value) + "', salida = '" + Program.FormateoFechaHora(dtHoraSalida.Value) + "', comida = '" + nMinutosComida.Value + "' where idTurno = " + this.iTurnoActual))
                        {
                            MessageBox.Show("Se ha modificado correctamente el turno.", "Turno modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargaTurnos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el turno. Si el problema persiste, contacte con el administrador de sistema.", "Error al guardar el turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El turno debe tener un nombre.", "Horario sin nombre", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("La hora de entrada no puede ser mayor a la hora de salida.", "Hora inválida", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void CargaTurnos()
        {
            try
            {
                dgTurnos.DataSource = ExtraerDato.listadoDatos("select idTurno, nombre as TURNO, ENTRADA, SALIDA, comida as 'MINUTOS DE COMIDA' from turnos order by idTurno desc");
                dgTurnos.ContextMenuStrip = null;
                if (dgTurnos.Rows.Count > 0)
                {
                    dgTurnos.ContextMenuStrip = cmTurnos;
                }
                dgTurnos.Columns[0].Visible = false;
                dgTurnos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgTurnos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgTurnos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTurnos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgTurnos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTurnos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch { }
        }
        private void limpiaCamposTurnos()
        {
            dtHoraEntrada.Value = new DateTime(2022, 1, 1, 8, 0, 0, 0);
            dtHoraSalida.Value = new DateTime(2022, 1, 1, 9, 0, 0, 0);
            txtNombreTurno.Text = "";
            nMinutosComida.Value = 0;
            this.iTurnoActual = 0;
        }

        private void dgTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionaTurno();
        }

        private void dgTurnos_SelectionChanged(object sender, EventArgs e)
        {
            SeleccionaTurno();
        }
        private void SeleccionaTurno()
        {
            try
            {
                DateTime fecha = new DateTime(2022, 1, 1);;
                this.iTurnoActual = (int) dgTurnos.CurrentRow.Cells[0].Value;
                txtNombreTurno.Text = dgTurnos.CurrentRow.Cells[1].Value.ToString();
                dtHoraEntrada.Value = fecha.Add((TimeSpan)dgTurnos.CurrentRow.Cells[2].Value);
                dtHoraSalida.Value = fecha.Add((TimeSpan)dgTurnos.CurrentRow.Cells[3].Value);
                nMinutosComida.Value = (int) dgTurnos.CurrentRow.Cells[4].Value;
            }
            catch { }
        }
    }
}