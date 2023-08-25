using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public partial class frmGestionProductos : Form
    {
        bool lEsEntrada = true;
        bool lDesdeModulo;
        int idProducto;
        public frmGestionProductos(int idProducto = 0, bool lDesdeModulo = false)
        {
            this.idProducto = idProducto;
            this.lDesdeModulo= lDesdeModulo;
            InitializeComponent();
        }
        private void frmGestionProductos_Load(object sender, EventArgs e)
        {
            DataTable dtInventario = new DataTable();
            gridInventario.DefaultCellStyle.ForeColor = Color.FromArgb(196, 34, 75);
            ActualizaGrid();
        }

        private void LlenarGrid(DataTable _dtDatos)
        {
            gridInventario.DataSource = _dtDatos;
            gridInventario.Columns[0].Visible = false;
            gridInventario.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gridInventario.Columns[15].Visible = false;
            gridInventario.Columns[16].Visible = false;
        }
        private void ActualizaCombos()
        {
            DataTable dtDatos = new DataTable();
            dtDatos = ExtraerDato.listadoDatos("select distinct Area from Productos where Activo = 1 order by Area");
            txtArea.DataSource = dtDatos;
            txtArea.DisplayMember = "Area";
            dtDatos = new DataTable();
            dtDatos = ExtraerDato.listadoDatos("select distinct Presentacion from Productos where Activo = 1 order by Presentacion");
            txtPresentacionCompra.DataSource = dtDatos;
            txtPresentacionCompra.DisplayMember = "Presentacion";
            dtDatos = new DataTable();
            dtDatos = ExtraerDato.listadoDatos("select distinct UMUso from Productos where Activo = 1 order by UMUso");
            txtUnidadesUso.DataSource = dtDatos;
            txtUnidadesUso.DisplayMember = "UMUso";
            dtDatos = new DataTable();
            dtDatos = ExtraerDato.listadoDatos("select distinct Ubicacion from Productos where Activo = 1 order by Ubicacion");
            txtUbicacionAlmacen.DataSource = dtDatos;
            txtUbicacionAlmacen.DisplayMember = "Ubicacion";
        }

        public void ActualizarFila()
        {
            try
            {
                gridInventario.CurrentRow.Cells[0].Value = txtCodigoBarras.Text;
                gridInventario.CurrentRow.Cells[1].Value = txtArea.Text;
                gridInventario.CurrentRow.Cells[2].Value = txtNombreProducto.Text;
                gridInventario.CurrentRow.Cells[3].Value = txtDescripcion.Text;
                gridInventario.CurrentRow.Cells[4].Value = txtPresentacionCompra.Text;
                gridInventario.CurrentRow.Cells[5].Value = txtUnidadesCompra.Value.ToString();
                gridInventario.CurrentRow.Cells[6].Value = txtPresentacionUso.Value.ToString();
                gridInventario.CurrentRow.Cells[7].Value = txtUnidadesUso.Text;
                gridInventario.CurrentRow.Cells[8].Value = txtMaximo.Value;
                gridInventario.CurrentRow.Cells[9].Value = txtMinimo.Value;
                gridInventario.CurrentRow.Cells[10].Value = txtUbicacionAlmacen.Text;
                gridInventario.CurrentRow.Cells[11].Value = txtMarca.Text;
                gridInventario.CurrentRow.Cells[12].Value = txtAlmacenamiento.Text;
                gridInventario.CurrentRow.Cells[13].Value = txtTemperatura.Text;
                gridInventario.CurrentRow.Cells[14].Value = txtReferencia.Text;
                gridInventario.CurrentRow.Cells[16].Value = ImagenAbyteArray(pbImagenProducto.Image);
            }
            catch
            {
            }
        }

        private DataTable ActualizaGrid()
        {
            ActualizaCombos();
            DataTable dtInventario = new DataTable();
            string filtro = "";
            if (lDesdeModulo)
            {
                filtro = " idProducto = " + this.idProducto + " and ";
            }
            dtInventario = ExtraerDato.listadoDatos("select CodigoBarras, Area as 'ÁREA', Nombre as 'NOMBRE DEL PRODUCTO', Descripcion as 'DESCRIPCIÓN', Presentacion as 'PRESENTACIÓN', UMPresentacion as 'U. M. PRESENTACIÓN', CONTENIDO, UMUso as 'U. M. USO', Maximo as 'MÁXIMO', Minimo as 'MÍNIMO', Ubicacion as 'UBICACIÓN', MARCA, TipoAlmacenamiento as 'ALMACENAMIENTO', TemperaturaC as 'TEMPERATURA EN ºC', REFERENCIA, idProducto, Imagen from Productos where " + filtro + "Activo = 1");
            LlenarGrid(dtInventario);
            return dtInventario;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea eliminar este producto? Esta operación no se puede deshacer.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ExtraerDato.AccionQuery("update productos set Activo = 0 where idproducto = " + lblIdProducto.Text);
                MessageBox.Show("Se ha eliminado el producto correctamente", "Acción confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizaGrid();
            }
        }

        private void pbAgregarImagen(object sender, EventArgs e)
        {
            try
            {
                Abrir.FileName = "";
                Abrir.Multiselect = false;
                Abrir.Filter = "Archivo de imagen |*.jpg;*.jpeg;*.png";
                Abrir.ShowDialog();
                bool Carga = true;
                string rutaReal = Abrir.FileName;
                int i = -1;
                if (rutaReal != "" & lblIdProducto.Text != "Nuevo")
                {
                    Image imagenProducto = Image.FromFile(rutaReal);
                    if (imagenProducto != null)
                    {
                        pbImagenProducto.Image = ExtraerDato.redimensionar(imagenProducto, 2);
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una imagen válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocurrio el siguiente error");
            }
        }
        public byte[] ImagenAbyteArray(Image imageIn)
        {
            ImageConverter converter = new ImageConverter();
            byte[] xByte = null;
            try
            {
                xByte = (byte[])converter.ConvertTo(imageIn, typeof(byte[]));
            }
            catch (Exception)
            {}
            return xByte;
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
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
                btnEntrada.Enabled = true;
                txtCodigoBarras.Text = fila.Cells[0].Value.ToString();
                if (txtCodigoBarras.Text != "")
                {
                    pbCodigoQR.Image = ExtraerDato.aQR(fila.Cells[0].Value.ToString(), 132);
                }
                else
                {
                    pbCodigoQR.Image = null;
                }
                decimal dMaximo, dMinimo;
                try
                {
                    dMaximo = decimal.Parse(fila.Cells[8].Value.ToString());
                    dMinimo = decimal.Parse(fila.Cells[9].Value.ToString());
                }
                catch
                {
                    dMaximo = 0;
                    dMinimo = 0;
                }
                txtArea.Text = fila.Cells[1].Value.ToString();
                txtNombreProducto.Text = fila.Cells[2].Value.ToString();
                txtDescripcion.Text = fila.Cells[3].Value.ToString();
                txtPresentacionCompra.Text = fila.Cells[4].Value.ToString();
                txtUnidadesCompra.Value = fila.Cells[5].Value.ToString() != "" ? decimal.Parse(fila.Cells[5].Value.ToString()) : 0;
                txtPresentacionUso.Value = fila.Cells[6].Value.ToString() != "" ? decimal.Parse(fila.Cells[6].Value.ToString()) : 0;
                txtUnidadesUso.Text = fila.Cells[7].Value.ToString();
                CalculaMyM(dMaximo, dMinimo);
                txtMaximo.Value = dMaximo;
                txtMinimo.Value = dMinimo;
                txtUbicacionAlmacen.Text = fila.Cells[10].Value.ToString();
                txtMarca.Text = fila.Cells[11].Value.ToString();
                txtAlmacenamiento.Text = fila.Cells[12].Value.ToString();
                txtTemperatura.Text = fila.Cells[13].Value.ToString();
                txtReferencia.Text = fila.Cells[14].Value.ToString();
                try
                {
                    byte[] data = (byte[])fila.Cells[16].Value;
                    MemoryStream ms = new MemoryStream(data);
                    pbImagenProducto.Image = Image.FromStream(ms);
                }
                catch (Exception)
                {
                    pbImagenProducto.Image = null;
                }
                lblIdProducto.Text = fila.Cells[15].Value.ToString();
            }
            else
            {
                LimpiaCampos();
            }
        }
        private void LimpiaCampos()
        {
            pbCodigoQR.Image = null;
            pbImagenProducto.Image = null;
            txtCodigoBarras.Text = "";
            txtArea.Text = "";
            txtNombreProducto.Text = "";
            txtDescripcion.Text = "";
            txtPresentacionCompra.Text = "";
            txtUnidadesCompra.Value = 0;
            txtPresentacionUso.Value = 0;
            txtUnidadesUso.Text = "";
            txtMarca.Text = "";
            txtReferencia.Text = "";
            txtMaximo.Text = "";
            txtMinimo.Text = "";
            txtUbicacionAlmacen.Text = "";
            txtMarca.Text = "";
            txtAlmacenamiento.Text = "";
            txtTemperatura.Text = "";
            txtReferencia.Text = "";
            lblIdProducto.Text = "vacio";
        }
        private void tbBtnNuevo_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            LimpiaCampos();
            lblIdProducto.Text = "Nuevo";
            btnEntrada.Enabled = false;
        }

        private void btnCargaExcel_Click(object sender, EventArgs e)
        {
            frmCargaDesdeExcel oCargaExcel = new frmCargaDesdeExcel();
            oCargaExcel.ShowDialog();
            ActualizaGrid();
        }

        private void lblIdProducto_TextChanged(object sender, EventArgs e)
        {
            if (pbImagenProducto.Image == null)
            {
                cmImagenProducto.Items[2].Enabled = false;
                cmImagenProducto.Items[3].Enabled = false;
            }
            else
            {
                cmImagenProducto.Items[2].Enabled = true;
                cmImagenProducto.Items[3].Enabled = true;
            }
            CalculaExistencias(false, "");
        }

        private void CalculaExistencias(bool _lPorFechas, string _cFecha)
        {
            int idProducto;
            if (int.TryParse(lblIdProducto.Text, out idProducto))
            {
                string[] infoExistencias = Program.CalculaExistenciaActual(idProducto, lEsEntrada, _lPorFechas, _cFecha);
                lblExistenciaActual.Text = infoExistencias[0];
                lblUnidadExistencia.Text = infoExistencias[1];
            }
        }
        private void agregarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbAgregarImagen(sender, e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string resultado = "Ha ocurrido un error al guardar el producto, verifique los datos enviados e intente de nuevo. Si el error persiste, contacte al administrador del sistema.";
            if (pbImagenProducto.Image == null)
            {
                pbImagenProducto.Image = Properties.Resources.Sin_imagen;
            }
            if (lblIdProducto.Text == "Nuevo")
            {
                if (
                    ExtraerDato.guardaImagen("insert into productos ( CodigoBarras, Area, Nombre, Descripcion, Presentacion, UMPresentacion, Contenido, UMUso, Maximo, Minimo, Ubicacion, Marca, TipoAlmacenamiento, TemperaturaC, Referencia, FechaAlta, Imagen, Activo) values ('"
                    + txtCodigoBarras.Text.Trim() + "', '" + txtArea.Text.Trim() + "', '" + txtNombreProducto.Text + "', '"
                    + txtDescripcion.Text + "', '" + txtPresentacionCompra.Text + "', '" + txtUnidadesCompra.Value.ToString() + "', '"
                    + txtPresentacionUso.Value.ToString() + "', '" + txtUnidadesUso.Text + "', '" + txtMaximo.Value + "', '" + txtMinimo.Value + "', '" + txtUbicacionAlmacen.Text + "', '" + txtMarca.Text + "', '" + txtAlmacenamiento.Text + "', '" + txtTemperatura.Text + "', '" + txtReferencia.Text + "', '" + Program.FormateoFechaHora(DateTime.Now) + "', @imagen, 1)", pbImagenProducto)
                    )
                {
                    resultado = "Se ha guardado el producto correctamente.";
                    LimpiaCampos();
                    ActualizaCombos();
                    ActualizaGrid();
                }
                
            }
            else
            {
                if (lblIdProducto.Text == "vacio")
                {
                    resultado = "Seleccione un producto para modificarlo o presione \"Nuevo producto\" para agregar un producto nuevo.";
                }
                else
                {
                    if (ExtraerDato.guardaImagen("update productos set CodigoBarras = '" + txtCodigoBarras.Text.Trim() + "', Area = '" + txtArea.Text.Trim() + "', Nombre = '" + txtNombreProducto.Text.Trim() + "', Descripcion = '" + txtDescripcion.Text.Trim() + "', Presentacion = '" + txtPresentacionCompra.Text.Trim() + "', UMPresentacion = '" + txtUnidadesCompra.Value.ToString() + "', Contenido = '" + txtPresentacionUso.Value.ToString().Trim() + "', UMUso = '" + txtUnidadesUso.Text.Trim() + "', Maximo = '" + txtMaximo.Value + "', Minimo = '" + txtMinimo.Value + "', Ubicacion = '" + txtUbicacionAlmacen.Text.Trim() + "', Marca = '" + txtMarca.Text.Trim() + "', TipoAlmacenamiento = '" + txtAlmacenamiento.Text.Trim() + "', TemperaturaC = '" + txtTemperatura.Text.Trim() + "', Referencia = '" + txtReferencia.Text.Trim() + "', FechaModificacion = '" + Program.FormateoFechaHora(DateTime.Now) + "', Imagen = @imagen, Activo = 1 where idProducto = " + lblIdProducto.Text, pbImagenProducto))
                    {
                        resultado = "Se ha modificado el producto correctamente.";
                        ActualizarFila();
                    }
                }
            }
            if (resultado != "Ha ocurrido un error al guardar el producto, verifique los datos enviados e intente de nuevo. Si el error persiste, contacte al administrador del sistema.")
            {
                txtBuscar.Text += " "; 
            }
            MessageBox.Show(resultado, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pbCodigoQR.Image = ExtraerDato.aQR(txtCodigoBarras.Text, 132);
                e.SuppressKeyPress = true;
            }
        }
        public void CalculaMyM(decimal dMaximo, decimal dMinimo)
        {
            if (dMinimo > 0)
            {
                txtMaximo.Minimum = dMinimo + (decimal) 0.01;
            }
            if (dMaximo != 0)
            {
                txtMinimo.Maximum = dMaximo - (decimal) 0.01;
            }
        }

        private void txtPresentacionCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblUnidadMaxima.Text = txtPresentacionCompra.Text;
        }

        private void copiarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbImagenProducto.Image != null)
            {
                Image imgCopiar = (Image) pbImagenProducto.Image;
                Clipboard.SetImage(imgCopiar);
            }
        }

        private void pegarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbImagenProducto.Image = Clipboard.GetImage();
            if (pbImagenProducto.Image == null)
            {
                MessageBox.Show("No se pudo copiar el elemento del portapapeles", "Elemento incompatible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void eliminarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbImagenProducto = null;
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            frmExistenciasProducto entExistencia = new frmExistenciasProducto(int.Parse(lblIdProducto.Text), true, true);
            entExistencia.ShowDialog();
            CalculaExistencias(false, "");
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            frmExistenciasProducto entExistencia = new frmExistenciasProducto(int.Parse(lblIdProducto.Text), false, true);
            entExistencia.ShowDialog();
            CalculaExistencias(false, "");
        }

        private void lblExistenciaActual_Click(object sender, EventArgs e)
        {
            lEsEntrada = !lEsEntrada;
            CalculaExistencias(false, "");
        }

        private void lblExistenciaActual_TextChanged(object sender, EventArgs e)
        {
            if (lblExistenciaActual.Text == "0")
            {
                btnSalida.Enabled = false;
            }
            else
            {
                btnSalida.Enabled = true;
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Sql;
                if (txtBuscar.Text.Trim().Length > 1)
                {
                    Sql = "select CodigoBarras as 'CÓDIGO DE BARRAS', Area as 'ÁREA', Nombre as 'NOMBRE DEL PRODUCTO', Descripcion as 'DESCRIPCIÓN', Presentacion as 'PRESENTACIÓN', UMPresentacion as 'U. M. PRESENTACIÓN', CONTENIDO, UMUso as 'U. M. USO', Maximo as 'MÁXIMO', Minimo as 'MÍNIMO', Ubicacion as 'UBICACIÓN', MARCA, TipoAlmacenamiento as 'ALMACENAMIENTO', TemperaturaC as 'TEMPERATURA EN ºC', REFERENCIA, idProducto, imagen from Productos where Activo = 1 and (CodigoBarras like '%" + txtBuscar.Text.Trim() + "%' or Area like '%" + txtBuscar.Text.Trim() + "%' or Nombre like '%" + txtBuscar.Text.Trim() + "%' or Descripcion like '%" + txtBuscar.Text.Trim() + "%' or  Marca like '%" + txtBuscar.Text.Trim() + "%' or  Ubicacion like '%" + txtBuscar.Text.Trim() + "%')";
                    DataTable dtInventario = new DataTable();
                    dtInventario = ExtraerDato.listadoDatos(Sql);
                    LlenarGrid(dtInventario);
                }
                if (txtBuscar.TextLength == 0)
                {
                    ActualizaGrid();
                }
            }
        }

        private void txtMaximo_ValueChanged(object sender, EventArgs e)
        {
            decimal dMaximo = txtMaximo.Value;
            decimal dMinimo = txtMinimo.Value;
            CalculaMyM(dMaximo, dMinimo);
        }
    }
}