using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public partial class frmExistenciasProducto : Form
    {
        object[] arrayInfoProducto;
        int esEntrada = 1;
        bool lExisteEnFecha = false;
        int idProducto;
        bool lExistenciasEntradas = true;
        public frmExistenciasProducto(int _idProducto, bool lEntrada, bool lDesdeModulo = false)
        {
            InitializeComponent();
            dgMovimientos.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            gridInventario.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            idProducto = _idProducto;
            CompruebaCaducidadExistente();
            arrayInfoProducto = ExtraerDato.CadenaArrayFila("select idProducto, Nombre, Descripcion, Presentacion, UMPresentacion, Contenido, UMUso, Maximo, Minimo, Ubicacion, Marca, TipoAlmacenamiento, TemperaturaC, Referencia, FechaAlta, FechaModificacion, Imagen, Activo from productos where idproducto = " + idProducto + " and Activo = 1");
            cmTipoMovimiento.SelectedIndex = lEntrada ? 0 : 1;
            dtCaducidad.Visible = false;
            ckAgregarCaducidad.Checked = false;
            if (lDesdeModulo)
            {
                CargaComboUnidades(idProducto);
                gridInventario.Enabled = false;
                txtBuscar.Enabled = false;
                lblIdProducto.Text = idProducto.ToString();
                cmTipoMovimiento.Enabled = false;
                txtNombreProducto.Text = arrayInfoProducto[1].ToString();
                try
                {
                    pbImagenProducto.Image = ExtraerDato.imagen("select imagen from productos where idproducto = " + idProducto);
                }
                catch (Exception)
                {
                    pbImagenProducto.Image = null;
                }
            }
            else
            {
                ActualizaGrid();
                txtBuscar.Enabled = true;
            }
            ActualizaCombos();
            LlenarGridMovimientos();
            PintaExistencias();
        }
        private void frmExistenciasProducto_Load(object sender, EventArgs e)
        {
        }

        private void CargaComboUnidades(int idProducto)
        {
            cmUnidades.Items.Clear();
            string[] comboUnidades = ExtraerDato.CadenaArrayFila("select presentacion, umuso from productos where idproducto = " + idProducto);
            foreach (string i in comboUnidades)
            {
                cmUnidades.Items.Add(i);
            }
            cmUnidades.SelectedIndex = 0;
        }
        private void LlenaProveedores(bool esEntrada)
        {
            if (esEntrada)
            {
                cbProveedor.DataSource = ExtraerDato.listadoDatos("select distinct cProveedor from ExistenciasProductos where cProveedor is not null order by cProveedor");
                cbProveedor.DisplayMember = "cProveedor";
            }
            else
            {
                ExtraerDato.listadoDatos("select dis cProveedor from ExistenciasProductos where dtCaducidad = '" + Program.FormateoFechaDesdeCombo(cmCaducidad.SelectedValue.ToString()) + "' and cLote = '" + cbLote.Text.Trim() + "' order by cProveedor");
            }
        }
        private void LlenaCaducidad()
        {
            List<string> cFechas = new List<string>();
            DataTable tableCaducidad = ExtraerDato.listadoDatos("select CONVERT (varchar, dtCaducidad, 103) from ExistenciaPorFecha where Cantidad > 0 and idProducto = " + idProducto + " order by dtCaducidad");
            foreach (DataRow rowFecha in tableCaducidad.Rows)
            {
                try
                {
                    cFechas.Add(rowFecha[0].ToString().Replace('.', '/'));
                }
                catch
                {
                    cFechas.Add("");
                }
            }

            if (cFechas.Any())
            {
                cmCaducidad.DataSource = cFechas;
            }
            else
            {
                cmCaducidad.DataSource = null;
            }
        }

        private void LlenarGrid(DataTable _dtDatos)
        {
            gridInventario.DataSource = _dtDatos;

            gridInventario.Columns[0].Visible = false;
            gridInventario.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridInventario.Columns[2].Visible = false;
        }
        private void ActualizaCombos()
        {
            //LlenaProveedores();
        }
        private void RecuperaLote()
        {
            cbLote.DataSource = null;
            if (cmTipoMovimiento.SelectedIndex == 0) //Entrada de almacén
            {
                cbLote.DataSource = ExtraerDato.listadoDatos("select distinct cLote from ExistenciasProductos where idProducto = " + gridInventario.CurrentRow.Cells[0].Value.ToString() + " and cLote != ''");
                cbLote.DisplayMember = "cLote";
                cbLote.DropDownStyle = ComboBoxStyle.DropDown;
                cbProveedor.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else //Salida de almacén
            {
                string cTieneFecha = "";
                if (cmCaducidad.SelectedValue != "")
                {
                    cTieneFecha = "and dtCaducidad = '" + Program.FormateoFechaDesdeCombo(cmCaducidad.SelectedValue.ToString()) + "'";
                }
                DataTable dtLotesFechas = ExtraerDato.listadoDatos("select distinct cLote from ExistenciasProductos where idProducto = " + gridInventario.CurrentRow.Cells[0].Value.ToString() + cTieneFecha);
                cbLote.DataSource = dtLotesFechas;
                cbLote.DisplayMember = "cLote";
                cbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
                cbLote.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            lblLote.Visible = true;
            cbLote.Visible = true;
            cbProveedor.Visible = true;
            lblProveedor.Visible = true;
            //LlenaProveedores(listadoPoveedores);
        }

        private DataTable ActualizaGrid()
        {
            ActualizaCombos();
            DataTable dtInventario = new DataTable();
            dtInventario = ExtraerDato.listadoDatos("select idProducto, Nombre as 'NOMBRE DEL PRODUCTO', imagen from Productos where Activo = 1");
            LlenarGrid(dtInventario);
            return dtInventario;
        }

        private void EliminarMovimiento(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea eliminar este movimiento? Esta operación no se puede deshacer.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ExtraerDato.AccionQuery("update ExistenciasProductos set Activo = 0 where iIdMovimiento = " + lblIdMovimiento);
                MessageBox.Show("Se ha eliminado el movimiento correctamente", "Acción confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizaGrid();
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string Sql;
            if (txtBuscar.Text.Trim().Length > 3)
            {
                Sql = "select idProducto, Nombre as 'NOMBRE DEL PRODUCTO', imagen from Productos where Activo = 1 and (CodigoBarras like '%" + txtBuscar.Text.Trim() + "%' or Area like '%" + txtBuscar.Text.Trim() + "%' or Nombre like '%" + txtBuscar.Text.Trim() + "%' or Descripcion like '%" + txtBuscar.Text.Trim() + "%' or  Marca like '%" + txtBuscar.Text.Trim() + "%' or  Ubicacion like '%" + txtBuscar.Text.Trim() + "%')";
                DataTable dtInventario = new DataTable();
                dtInventario = ExtraerDato.listadoDatos(Sql);
                LlenarGrid(dtInventario);
            }
            if (txtBuscar.TextLength == 0)
            {
                ActualizaGrid();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridInventario_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow fila = gridInventario.CurrentRow;
            if (gridInventario.CurrentCell != null)
            {
                gridInventario.ContextMenuStrip = contextoProducto;
                RecargaDatos(fila);
            }
            else
            {
                gridInventario.ContextMenuStrip = null;
                LimpiaCampos();
            }
            idProducto = int.Parse(lblIdProducto.Text);
            CargaComboUnidades(idProducto);
            LlenaCaducidad();
            PintaExistencias();
            LlenarGridMovimientos();
        }
        private void RecargaDatos(DataGridViewRow fila)
        {
            try
            {
                txtNombreProducto.Text = fila.Cells[1].Value.ToString();
            }
            catch
            {
            }
            try
            {
                byte[] data = (byte[])fila.Cells[2].Value;
                MemoryStream ms = new MemoryStream(data);
                pbImagenProducto.Image = Image.FromStream(ms);
            }
            catch (Exception)
            {
                pbImagenProducto.Image = null;
            }
            lblIdProducto.Text = fila.Cells[0].Value.ToString();
        }
        private void LimpiaCampos()
        {
            nCantidad.Value = 0;
            dtFechaMovimiento.Value = DateTime.Now;
            dtCaducidad.Value = DateTime.Now;
            cbProveedor.Text = "";
            ckAgregarCaducidad.Checked = false;
            cbLote.Text = "";
        }
        private void tbBtnNuevo_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            LimpiaCampos();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string resultado = "Ha ocurrido un error al guardar el movimiento, verifique los datos enviados e intente de nuevo. Si el error persiste, contacte al administrador del sistema.";
            string uMedida;
            decimal nCantidadRedonda = Math.Round(nCantidad.Value, 2);
            if (
                    ExtraerDato.AccionQuery("insert into ExistenciasProductos (lEntrada, idProducto, dCantidadMovimiento, dtFechaMovimiento, " + (esEntrada == 1 ? "cProveedor, " : "") + " lCaducidad,  dtCaducidad," + " cLote, Activo, UnidadMedida, dtCreacionReal) values ('"
                    + esEntrada + "', '" + lblIdProducto.Text + "', '" + nCantidadRedonda + "', '" + Program.FormateoFechaHora(dtFechaMovimiento.Value) + "', " + (esEntrada == 1 ? "'" + cbProveedor.Text + "', " : "") + (esEntrada == 1 ? (ckAgregarCaducidad.Checked == true ? "1, '" + Program.FormateoFecha(dtCaducidad.Value) + "', " : "0, NULL, ") : (cmCaducidad.Text.Length > 0 == true ? "1, '" + Program.FormateoFechaDesdeCombo(cmCaducidad.Text) + "', " : "0, NULL, ")) + "'"
                    + cbLote.Text + "', 1, '" + cmUnidades.Text + "', '" + Program.FormateoFechaHora(DateTime.Now) + "')")
                    )
            {
                resultado = "Se ha guardado el movimiento correctamente.";
                string cFecha = "is null";
                if (esEntrada == 1 & cmUnidades.SelectedIndex == 1) // Es entrada y Unidades de uso
                {
                    string[] datosProducto = ExtraerDato.CadenaArrayFila("select Contenido, UMUso from Productos where idProducto = " + idProducto);
                    decimal dFactor = decimal.Parse(datosProducto[0]);
                    uMedida = datosProducto[1];
                    nCantidadRedonda = nCantidadRedonda / dFactor;
                }
                if (esEntrada == 0 & cmUnidades.SelectedIndex == 0) // Es salida y Unidades de compra
                {
                    string[] datosProducto = ExtraerDato.CadenaArrayFila("select Contenido, UMUso from Productos where idProducto = " + idProducto);
                    decimal dFactor = decimal.Parse(datosProducto[0]);
                    uMedida = datosProducto[1];
                    nCantidadRedonda = nCantidadRedonda * dFactor;
                }
                if (ckAgregarCaducidad.Checked)
                {
                    cFecha = "= '" + Program.FormateoFecha(dtCaducidad.Value) + "'";
                }
                if (cmTipoMovimiento.SelectedIndex == 0) // Es entrada de almacén
                {
                    if (lExisteEnFecha)
                    {
                        ExtraerDato.AccionQuery("update ExistenciaPorFecha set CantidadInicial += '" + nCantidadRedonda + "', Cantidad += '" + nCantidadRedonda + "' where idProducto = " + lblIdProducto.Text + " and dtCaducidad " + cFecha);
                    }
                    else
                    {
                        ExtraerDato.AccionQuery("insert into ExistenciaPorFecha (idProducto, " + (ckAgregarCaducidad.Checked == true ? "dtCaducidad," : "") + " Cantidad, CantidadInicial) values (" + lblIdProducto.Text + "," + (ckAgregarCaducidad.Checked == true ? " '" + Program.FormateoFecha(dtCaducidad.Value) + "', " : "") + nCantidadRedonda + ", " + nCantidadRedonda + ")");
                    }
                }
                else
                {
                    double cantidad = (double)nCantidadRedonda, cantidadBD;
                    string cCaduca = Program.FormateoFechaDesdeCombo(cmCaducidad.Text);
                    if (cmCaducidad.Text != "")
                    {
                        cCaduca = " = '" + cCaduca + "'";
                    }
                    else
                    {
                        cCaduca = " is null";
                    }
                    cantidadBD = ExtraerDato.NumeroReal("select p.Contenido from Productos p join ExistenciaPorFecha e on p.idProducto = e.idProducto where p.idProducto = " + idProducto + " and e.dtCaducidad" + cCaduca);
                    cantidad = Math.Round((cantidad / cantidadBD), 2);
                    cantidadBD = ExtraerDato.NumeroReal("select Cantidad from ExistenciaPorFecha where idProducto = " + lblIdProducto.Text + " and dtCaducidad " + cCaduca);
                    cantidad = Math.Round(cantidadBD - cantidad, 2);
                    ExtraerDato.AccionQuery("update ExistenciaPorFecha set Cantidad = '" + cantidad + "' where idProducto = " + lblIdProducto.Text + " and dtCaducidad " + cCaduca);
                }
                LlenarGridMovimientos();
                //LlenaProveedores();
                LlenaCaducidad();
                LimpiaCampos();
                CalculaMaximasSalidas();
            }
            MessageBox.Show(resultado, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmTipoMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmTipoMovimiento.SelectedIndex == 0)
                {
                    esEntrada = 1;
                    cbLote.DropDownStyle = ComboBoxStyle.DropDown;
                    ckAgregarCaducidad.Visible = true;
                    dtCaducidad.Checked = false;
                    dtCaducidad.Visible = dtCaducidad.Checked;
                    lblCaducidadProducto.Visible = false;
                    cmCaducidad.Visible = false;
                    lblLote.Visible = true;
                    cbLote.Visible = true;
                    lblProveedor.Visible = true;
                    cbProveedor.Visible = true;
                }
                else
                {
                    esEntrada = 0;
                    cbLote.DropDownStyle = ComboBoxStyle.DropDownList;
                    ckAgregarCaducidad.Visible = false;
                    dtCaducidad.Visible = false;
                    lblCaducidadProducto.Visible = true;
                    cmCaducidad.Visible = true;
                    lblLote.Visible = false;
                    cbLote.Visible = false;
                    lblProveedor.Visible = false;
                    cbProveedor.Visible = false;
                    LlenaCaducidad();
                }
            }
            catch (Exception)
            {
            }
        }
        private void ckAgregarCaducidad_CheckedChanged(object sender, EventArgs e)
        {
            dtCaducidad.Visible = ckAgregarCaducidad.Checked;
        }

        private void dtCaducidad_ValueChanged(object sender, EventArgs e)
        {
            CompruebaCaducidadExistente();
        }

        private void CompruebaCaducidadExistente()
        {
            lExisteEnFecha = false;
            string cFecha = "is null";
            if (ckAgregarCaducidad.Checked)
            {
                cFecha = "= '" + Program.FormateoFecha(dtCaducidad.Value) + "'";
            }
            if (ExtraerDato.TieneFilas("select dtCaducidad from ExistenciaPorFecha where idProducto = " + idProducto + " and dtCaducidad " + cFecha))
            {
                lExisteEnFecha = true;
            }
        }

        public void LlenarGridMovimientos()
        {
            string cCondicion = "";
            if (!ckEntrada.Checked & !ckSalida.Checked)
            {
                dgMovimientos.DataSource = null;
                return;
            }
            if (ckEntrada.Checked)
            {
                cCondicion += "lEntrada = 1 ";
            }
            if (ckEntrada.Checked & ckSalida.Checked)
            {
                cCondicion += "or ";
            }
            if (ckSalida.Checked)
            {
                cCondicion += "lEntrada = 0 ";
            }
            if (cCondicion.Length > 0)
            {
                cCondicion = "and (" + cCondicion + ") ";
            }
            DataTable tableMovimientos = ExtraerDato.listadoDatos("select iIdMovimiento, (CASE WHEN lEntrada = 1 THEN 'Entrada de almacén' ELSE 'Salida de Almacén' END) as 'Tipo de movimiento', idProducto, dCantidadMovimiento as 'Cantidad', UnidadMedida as 'U. M.', cProveedor as 'Proveedor', CONCAT(CONVERT (varchar, dtFechaMovimiento, 103), substring(CONVERT (varchar, dtFechaMovimiento, 22), 9, 20))  as 'Fecha del movimiento', CONVERT (varchar, dtCaducidad, 103) as 'Caducidad', cLote as 'Lote', Activo from ExistenciasProductos where idProducto = " + idProducto + " " + cCondicion + "order by dtFechaMovimiento asc");
            if (tableMovimientos.Rows.Count > 0)
            {
                dgMovimientos.DataSource = tableMovimientos;
                dgMovimientos.Columns[0].Visible = false;
                dgMovimientos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgMovimientos.Columns[2].Visible = false;
                dgMovimientos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgMovimientos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgMovimientos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgMovimientos.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgMovimientos.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgMovimientos.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgMovimientos.Columns[9].Visible = false;
            }
        }

        private void ckEntrada_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGridMovimientos();
        }

        private void ckSalida_CheckedChanged(object sender, EventArgs e)
        {
            LlenarGridMovimientos();
        }

        private void CalculaMaximasSalidas()
        {
            if (cmTipoMovimiento.SelectedIndex == 1)
            {
                string cFecha = "";
                bool lEntrada = true;
                try
                {
                    if (cmCaducidad.Text != "")
                    {
                        cFecha = Program.FormateoFechaDesdeCombo(cmCaducidad.Text);
                    }
                }
                catch
                {
                }
                if (cmUnidades.SelectedIndex == 1)
                {
                    lEntrada = false;
                }
                string[] infoExistencias = Program.CalculaExistenciaActual(idProducto, lEntrada, true, cFecha);
                try
                {
                    nCantidad.Maximum = decimal.Parse(infoExistencias[0]);
                }
                catch
                {
                }

            }
            else
            {
                nCantidad.Maximum = 9999999999999;
                nCantidad.Minimum = 0;
            }
        }

        private void cmCaducidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecuperaLote();
            CalculaMaximasSalidas();
        }

        private void nCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (nCantidad.Value > 0)
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        private void cmUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculaMaximasSalidas();
        }

        private void lblExistenciaActual_Click(object sender, EventArgs e)
        {
            PintaExistencias();
        }
        private void PintaExistencias()
        {
            lExistenciasEntradas = !lExistenciasEntradas;
            string[] infoExistencias = Program.CalculaExistenciaActual(idProducto, lExistenciasEntradas, false, "");
            lblExistenciaActual.Text = infoExistencias[0];
            lblUnidadExistencia.Text = infoExistencias[1];
        }

        private void dgMovimientos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                lblIdMovimiento.Text = dgMovimientos.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
            }
        }

        private void verInformaciónDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idProducto = 0;
            try
            {
                idProducto = int.Parse(gridInventario.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
            }
            if (idProducto != 0)
            {
                frmGestionProductos frmGestion = new frmGestionProductos(this.idProducto, true);
                frmGestion.ShowDialog();
                ActualizaFila(idProducto);
            }
        }

        private void ActualizaFila(int idProducto)
        {
            DataTable dtModificado = ExtraerDato.listadoDatos("select idProducto, Nombre as 'NOMBRE DEL PRODUCTO', imagen from Productos where idProducto = " + idProducto + " and Activo = 1");
            gridInventario.CurrentRow.Cells[0].Value = dtModificado.Rows[0][0];
            gridInventario.CurrentRow.Cells[1].Value = dtModificado.Rows[0][1];
            gridInventario.CurrentRow.Cells[2].Value = dtModificado.Rows[0][2];
            RecargaDatos(gridInventario.CurrentRow);
        }

        private void gridInventario_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                int fila;
                DataGridView.HitTestInfo Hitest = gridInventario.HitTest(e.X, e.Y);
                if (Hitest.Type == DataGridViewHitTestType.Cell)
                {
                    if (Hitest.ColumnIndex == 1)
                    {
                        fila = Hitest.RowIndex;
                        if (gridInventario.Rows[fila].Cells[2].Value.ToString() != "")
                        {
                            try
                            {
                                byte[] data = (byte[])gridInventario.Rows[fila].Cells[2].Value;
                                MemoryStream ms = new MemoryStream(data);
                                pbProducto.Image = Image.FromStream(ms);
                            }
                            catch
                            {
                                pbProducto.Visible = false;
                                return;
                            }
                            pbProducto.Left = e.X + 50;
                            pbProducto.Top = e.Y;
                            pbProducto.Visible = true;
                        }
                        else
                        {
                            pbProducto.Visible = false;
                        }
                    }
                    else
                    {
                        pbProducto.Visible = false;
                    }
                }
                else
                {
                    pbProducto.Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void gridInventario_MouseLeave(object sender, EventArgs e)
        {
            pbProducto.Visible = false;
        }

        private void cmEditaCaducidad_Click(object sender, EventArgs e)
        {
            if (dgMovimientos.CurrentRow != null)
            {
                groupBox1.Enabled = false;
                lblEsEntrada.Text = "Entrada de almacén";
                dtEditarCaducidad.Value = Program.FechaDesdeGrid(dgMovimientos.CurrentRow.Cells[7].Value.ToString());
                txtEditaLote.Text = dgMovimientos.CurrentRow.Cells[8].Value.ToString();
                lblMovimiento.Text = lblIdMovimiento.Text;
                gbCaducidad.Visible = true;
            }
            else
            {
                MessageBox.Show("Seleccione un registro para modificar", "Sin registro", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCerrarCaducidad_Click(object sender, EventArgs e)
        {
            gbCaducidad.Visible = false;
        }

        private void EditaCaducidad(string idMovimiento)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool entrada = dgMovimientos.CurrentRow.Cells[1].Value.ToString() == lblEsEntrada.Text;
            EditaCaducidad(lblMovimiento.Text);
        }
    }
}