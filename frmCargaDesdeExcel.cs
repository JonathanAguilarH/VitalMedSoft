using SpreadsheetLight;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public partial class frmCargaDesdeExcel: Form
    {
        public frmCargaDesdeExcel()
        {
            InitializeComponent();
        }
        private void frmCargaDesdeExcel_Load(object sender, EventArgs e)
        {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void CargaExcel()
        {
            try
            {
                Abrir.FileName = "";
                Abrir.Multiselect = false;
                Abrir.Filter = "Archivos de Excel |*.xlsx";
                Abrir.ShowDialog();
                string rutaReal = Abrir.FileName;
                rutaReal = Abrir.FileName;
                bool lValido = false;
                if (rutaReal != "")
                {
                    lValido = EvaluaArchivo(rutaReal);
                    if (lValido)
                    {
                        lblInfo.Text = "Archivo preparado para guardar";
                        gbVistaPrevia.Visible = true;
                        gbVistaPrevia.Enabled = true;
                        btnGuardar.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocurrio el siguiente error");
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnCargaExcel_Click(object sender, EventArgs e)
        {
            CargaExcel();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool EvaluaArchivo(string _rutaArchivo)
        {
            bool lValido = false;
            int iRow = 1;

            DataTable dtDatosProducto = new DataTable();
            string[] columnas = new string[] { "Código de barras", "Área", "Nombre del producto", "Descripción de producto", "Presentación", "Unidades por presentación", "Contenido", "Unidades por Uso", "Máximo",  "Mínimo", "UBICACIÓN", "Marca", "Tipo de Almacenamiento", "Temperatura en Centígrados", "Referencia", "FechaAlta", "Activo"};
            foreach (string _columna in columnas)
            {
                DataColumn dtColumna = new DataColumn(_columna);
                dtDatosProducto.Columns.Add(dtColumna);
            }

            SLDocument slDocument = new SLDocument(_rutaArchivo);

            for (int i = 0; i < 15; i++)
            {
                if (!string.IsNullOrEmpty(slDocument.GetCellValueAsString(1, iRow)) & slDocument.GetCellValueAsString(1, iRow).ToString().ToUpper() == columnas[i].ToUpper())
                {
                    iRow++;
                }
                else
                {
                    lblInfo.Text = "El archivo no es compatible. Elija otro.";
                    lblInfo.ForeColor = Color.Red;
                    return false;
                }
            }
            iRow = 2;
            while (!string.IsNullOrEmpty(slDocument.GetCellValueAsString(iRow, 3)))
            {
                DataRow newRow = dtDatosProducto.NewRow();
                newRow[0] = slDocument.GetCellValueAsString(iRow, 1); //"Código de barras";
                newRow[1] = slDocument.GetCellValueAsString(iRow, 2); //"Área";
                newRow[2] = slDocument.GetCellValueAsString(iRow, 3); //"Nombre del poducto";
                newRow[3] = slDocument.GetCellValueAsString(iRow, 4);  //"Descripción de Producto";
                newRow[4] = slDocument.GetCellValueAsString(iRow, 5);  //"Presentación";
                newRow[5] = slDocument.GetCellValueAsDouble(iRow, 6);  //"Unidades por presentación";
                newRow[6] = slDocument.GetCellValueAsDouble(iRow, 7);  //"Contenido";
                newRow[7] = slDocument.GetCellValueAsString(iRow, 8);  //"Unidades por Uso";
                newRow[8] = slDocument.GetCellValueAsDouble(iRow, 9);  //"Máximo";
                newRow[9] = slDocument.GetCellValueAsDouble(iRow, 10);  //"Mínimo";
                newRow[10] = slDocument.GetCellValueAsString(iRow, 11); // "UBICACIÓN";
                newRow[11] = slDocument.GetCellValueAsString(iRow, 12); //Marca";
                newRow[12] = slDocument.GetCellValueAsString(iRow, 13); //Tipo de Almacenamiento";
                newRow[13] = slDocument.GetCellValueAsString(iRow, 14); //Temperatura en Centígrados";
                newRow[14] = slDocument.GetCellValueAsString(iRow, 15); //Referencia";
                newRow[15] = Program.FormateoFechaHora(DateTime.Now); //FechaAlta";
                newRow[16] = 1; //"Activo";
                dtDatosProducto.Rows.Add(newRow);

                iRow++;
            }
            if (dtDatosProducto.Rows.Count > 0)
            {
                lblInfo.Text = "Archivo seleccionado.";
                lblInfo.ForeColor = Color.Green;
                lValido = true;
                dgVistaPrevia.DataSource = dtDatosProducto;
                dgVistaPrevia.Columns[0].Visible = false;
                dgVistaPrevia.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgVistaPrevia.Columns[15].Visible = false;
                dgVistaPrevia.Columns[16].Visible = false;
            }
            return lValido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int correcto = 0, error = 0;
            
            pbGuardado.Maximum = dgVistaPrevia.RowCount;
            pbGuardado.Step = 1;
            gbProgreso.Visible = true; 
            
            foreach (DataGridViewRow fila in dgVistaPrevia.Rows)
            {
                if (!string.IsNullOrEmpty(fila.Cells[2].ToString()))
                {
                    try
                    {
                        ExtraerDato.AccionQuery("insert into Productos ( CodigoBarras, Area, Nombre, Descripcion, Presentacion, UMPresentacion, Contenido, UMUso, Maximo, Minimo, Ubicacion, Marca, TipoAlmacenamiento, TemperaturaC, Referencia, FechaAlta, Activo) values ('" + fila.Cells[0].Value + "', '" + fila.Cells[1].Value + "','" + fila.Cells[2].Value + "','" + fila.Cells[3].Value + "','" + fila.Cells[4].Value + "','" + fila.Cells[5].Value + "','" + fila.Cells[6].Value + "','" + fila.Cells[7].Value + "','" + fila.Cells[8].Value + "','" + fila.Cells[9].Value + "','" + fila.Cells[10].Value + "','" + fila.Cells[11].Value + "','" + fila.Cells[12].Value + "','" + fila.Cells[13].Value + "','" + fila.Cells[14].Value + "', '" + fila.Cells[15].Value + "', " + fila.Cells[16].Value + ")");
                        correcto++;
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    catch (Exception)
                    {
                        error++;
                        fila.DefaultCellStyle.BackColor = Color.Red;
                        fila.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
                pbGuardado.Increment(1);
            }
            dgVistaPrevia.Enabled = false;
            MessageBox.Show("Se agregaron " + correcto + " nuevos registros a la base de datos.\nErrores encontrados: " + error, "Guardar en base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnEliminaTodo_Click(object sender, EventArgs e)
        {
            ExtraerDato.AccionQuery("truncate table Productos");
            MessageBox.Show("Se eliminaron todos los registros de Productos de la base de datos.", "Eliminar registros", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}