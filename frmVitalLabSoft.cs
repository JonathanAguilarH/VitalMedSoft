using FontAwesome.Sharp;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.AccessControl;
using System.Threading;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public partial class frmVitalLabSoft : Form
    {
        delegate void InhabilitaTexto(bool lEnable);
        delegate void LlenaGridCaducidad(DataTable dtExistencias);
        delegate void LlenarGridMyM(DataTable dtMym);
        private IconButton btnActual;
        private Panel bordeBtnIzq;
        private Panel bordeBtnIzqSeleccion;
        private int idProducto;
        private string textoBtn = "";
        bool lEsEntrada = true;
        private bool trabajoEnCursoMyM = false;
        private bool trabajoEnCursoExistencias = false;
        public frmVitalLabSoft()
        {
            InitializeComponent();
            bordeBtnIzq = new Panel();
            panelLateral.Controls.Add(bordeBtnIzq);
            bordeBtnIzqSeleccion = new Panel();
            panelLateral.Controls.Add(bordeBtnIzqSeleccion);
        }

        private void InhabilitaCajaTexto(bool lEnable)
        {
            txtBusquedaMyM.Enabled = lEnable;
        }
        private void frmVitalLabSoft_Load(object sender, EventArgs e)
        {
            tbLogin.Text = "Cerrar sesión de " + Program.infoUsuarioConectado[1];
            tbLogin.ForeColor = Color.Green;
            tbConexion.ForeColor = Color.Green;
            panelGestionExistencias.Dock = DockStyle.Fill;
            PanelGestionProductos.Dock = DockStyle.Fill;
            
            ActualizaGrid();
            ActualizaGridCaducidad();
            ActualizarGridMyM();
            OcultaPaneles(0);
            if (Program.infoUsuarioConectado[1] != "JON_AGUILAR" & Program.infoUsuarioConectado[1] != "ADMINISTRADOR")
            {
                tbUsuarios.Enabled = false;
                tsNomina.Enabled = false;
                tbEmpleados.Enabled = false;
            }
        }

        private void OcultaPaneles(int panelActivo)
        {
            // 0 - Panel principal
            // 1 - Gestión de productos.
            // 2 - Gestión de Existencias
            // 3 - Reloj checador
            PanelGestionProductos.Visible = false;
            panelGestionExistencias.Visible = false;
            panelPrincipal.Visible = true;
            
            switch (panelActivo)
            {
                case 0:
                    panelPrincipal.Visible = true;
                    break;
                case 1:
                    PanelGestionProductos.Visible = true;
                    break;
                case 2:
                    panelGestionExistencias.Visible = true;
                    break;
                case 3:
                    break;
            }
        }
        
        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarSistema();
        }
        private void cerrarSistema()
        {
            if (MessageBox.Show("¿Realmente desea salir del sistema? Los datos no guardados se perderán.", "Cerrar sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void conexiónAlServidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConServidor oConexion = new frmConServidor();
            this.BackColor = Color.DarkGray;
            this.Refresh();
            oConexion.ShowDialog();
            if (Program.conexionEstablecida)
            {
                tbConexion.ForeColor = Color.Green;
                if (tbLogin.Text != "Iniciar sesión")
                {
                    this.BackColor = Color.FromArgb(196, 34, 75);
                }
            }
            else
            {
                tbConexion.ForeColor = Color.Black;
                cerrarSesion();
            }
            this.Refresh();
        }
        private void cerrarSesion()
        {
            if (Program.infoConexion[0] != "")
            {
                if (tbLogin.Text == "Iniciar sesión")
                {
                    frmLogin oLogin = new frmLogin();
                    this.BackColor = Color.DarkGray;
                    this.Refresh();
                    oLogin.ShowDialog();
                    if (Program.infoUsuarioConectado[0] != "")
                    {
                        tbLogin.ForeColor = Color.Green;
                        tbLogin.Text = "Cerrar sesión de " + Program.infoUsuarioConectado[1];
                        this.BackColor = Color.White;
                        this.Close();
                    }
                }
                else
                {
                    tbLogin.Text = "Iniciar sesión";
                    Program.infoUsuarioConectado[0] = "";
                    Program.infoUsuarioConectado[1] = "";
                    Program.infoUsuarioConectado[2] = "";
                    Program.infoUsuarioConectado[3] = "";
                    Program.infoUsuarioConectado[4] = "";
                    tbLogin.ForeColor = Color.Black;
                    this.BackColor = Color.DarkGray;
                    this.Refresh();
                }
                csPermisos.comprobarPermisos(Program.infoUsuarioConectado[0] = "");
            }
            else
            {
                MessageBox.Show("No se han establecido parámetros de conexión a la base de datos. Por favor, revise configuraciones de conexión y reintente.", "No conectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void usuariosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios oUsuarios = new frmUsuarios();
            oUsuarios.ShowDialog();
        }
        private void tbLogin_Click(object sender, EventArgs e)
        {
            cerrarSesion();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            cerrarSistema();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Eventos de botones Panel lateral.
        private void resaltaBoton(object sender)
        {
            if (sender != null)
            {
                btnActual = (IconButton)sender;
                if (btnActual.Text != textoBtn)
                {
                    btnActual.BackColor = Color.White;
                    btnActual.ForeColor = Apariencia.colorPrincipal;
                    btnActual.TextAlign = ContentAlignment.MiddleCenter;
                    btnActual.IconColor = Apariencia.colorPrincipal;
                    btnActual.TextImageRelation = TextImageRelation.TextBeforeImage;
                    btnActual.ImageAlign = ContentAlignment.MiddleRight;
                    // Borde izquierdo
                    bordeBtnIzq.Size = new Size(15, btnActual.Height);
                    bordeBtnIzq.BackColor = Apariencia.colorPrincipal;
                    bordeBtnIzq.Location = new Point(0, btnActual.Location.Y);
                    bordeBtnIzq.Visible = true;
                    bordeBtnIzq.BringToFront();
                }
            }
        }
        private void restaurarBoton(object sender)
        {
            if (sender != null)
            {
                btnActual = (IconButton)sender;
                if (btnActual.Text != textoBtn)
                {
                    btnActual.BackColor = Apariencia.colorPrincipal;
                    btnActual.ForeColor = Color.White;
                    btnActual.TextAlign = ContentAlignment.MiddleLeft;
                    btnActual.IconColor = Color.White;
                    btnActual.TextImageRelation = TextImageRelation.ImageBeforeText;
                    btnActual.ImageAlign = ContentAlignment.MiddleLeft;
                    // Borde izquierdo.
                    bordeBtnIzq.Size = new Size(15, btnActual.Height);
                    bordeBtnIzq.BackColor = Apariencia.colorPrincipal;
                    bordeBtnIzq.Location = new Point(0, btnActual.Location.Y);
                    bordeBtnIzq.Visible = true;
                    bordeBtnIzq.BringToFront();
                }
            }
        }
        private void seleccionaBoton(object sender)
        {
            if (sender != null)
            {
                resetBotones();
                btnActual = (IconButton)sender;
                textoBtn = btnActual.Text;
                btnActual = (IconButton)sender;
                btnActual.BackColor = Color.White;
                btnActual.ForeColor = Apariencia.colorBtnActivo;
                btnActual.TextAlign = ContentAlignment.MiddleCenter;
                btnActual.IconColor = Apariencia.colorBtnActivo;
                btnActual.TextImageRelation = TextImageRelation.TextBeforeImage;
                btnActual.ImageAlign = ContentAlignment.MiddleRight;
                // Borde izquierdo.
                bordeBtnIzqSeleccion.Size = new Size(15, btnActual.Height);
                bordeBtnIzqSeleccion.BackColor = Apariencia.colorBtnActivo;
                bordeBtnIzqSeleccion.Location = new Point(0, btnActual.Location.Y);
                bordeBtnIzqSeleccion.Visible = true;
                bordeBtnIzqSeleccion.BringToFront();
            }
        }
        private void resetBotones()
        {
            textoBtn = "";
            foreach (Control btnActual1 in panelLateral.Controls)
            {
                if (btnActual1 is IconButton)
                {
                    btnActual = (IconButton)btnActual1;
                    btnActual.BackColor = Apariencia.colorPrincipal;
                    btnActual.ForeColor = Color.White;
                    btnActual.TextAlign = ContentAlignment.MiddleLeft;
                    btnActual.IconColor = Color.White;
                    btnActual.TextImageRelation = TextImageRelation.ImageBeforeText;
                    btnActual.ImageAlign = ContentAlignment.MiddleLeft;
                    // Borde izquierdo
                    bordeBtnIzqSeleccion.Visible = false;
                    bordeBtnIzq.Visible = false;
                }
            }
        }

        //Boton Nuevo Servicio
        private void btnNuevoServicio_Click(object sender, EventArgs e)
        {
            seleccionaBoton(sender);
            OcultaPaneles(1);
        }

        private void btnNuevoServicio_MouseLeave(object sender, EventArgs e)
        {
            restaurarBoton(sender);
        }
        private void btnNuevoServicio_MouseMove(object sender, MouseEventArgs e)
        {
            resaltaBoton(sender);
        }

        //Boton Clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            seleccionaBoton(sender);
            OcultaPaneles(2);
        }

        private void btnClientes_MouseMove(object sender, MouseEventArgs e)
        {
            resaltaBoton(sender);
        }

        private void btnClientes_MouseLeave(object sender, EventArgs e)
        {
            restaurarBoton(sender);
        }
        //Boton Servicios activos
        private void btnServiciosActivos_Click(object sender, EventArgs e)
        {
            seleccionaBoton(sender);
            OcultaPaneles(3);
        }

        private void btnServiciosActivos_MouseMove(object sender, MouseEventArgs e)
        {
            resaltaBoton(sender);
        }

        private void btnServiciosActivos_MouseLeave(object sender, EventArgs e)
        {
            restaurarBoton(sender);
        }
        private void pbLogoLateral_Click(object sender, EventArgs e)
        {
            resetBotones();
            OcultaPaneles(0);
        }

        private void tbRespaldo_Click(object sender, EventArgs e)
        {
            if (Program.infoConexion[3] != "")
            {
                if (MessageBox.Show("Conexión actual: " + Program.infoConexion[3].ToUpper() + "\n\n¿Desea respaldar esta base de datos?", "Confirma operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveDB.FileName = Program.infoConexion[3].ToUpper() + ".bak";
                    saveDB.Filter = "Respaldos BD|*.bak";
                    DialogResult resultado = saveDB.ShowDialog();
                    if (resultado == DialogResult.OK & saveDB.CheckPathExists)
                    {
                        string ruta = Path.GetDirectoryName(saveDB.FileName);
                        string rutaBat = Path.GetDirectoryName(Environment.CurrentDirectory) + "\\backup.bat";
                        string rutaSQL = Path.GetDirectoryName(Environment.CurrentDirectory) + "\\backupDB.sql";

                        if (File.Exists(rutaBat))
                        {
                            File.Delete(rutaBat);
                        }
                        string aBat = "sqlcmd -S " + Program.infoConexion[0] + " -U" + Program.infoConexion[1] + " -P" + Program.infoConexion[2] + " -i \"" + rutaSQL + "\"";
                        //string aBat = "sqlcmd -S " + Program.infoConexion[0] + " -U" + Program.infoConexion[1] + " -P" + Program.infoConexion[2] + " -i \"" + rutaSQL + "\"";
                        using (StreamWriter txt = new StreamWriter(rutaBat))
                        {
                            txt.WriteLine(aBat);
                        }
                        if (File.Exists(rutaSQL))
                        {
                            File.Delete(rutaSQL);
                        }
                        string[] aSQL = { "DECLARE @name VARCHAR(256)", "DECLARE db_cursor CURSOR FOR", "SELECT name FROM master.dbo.sysdatabases WHERE name IN ('" + Program.infoConexion[3] + "')", "OPEN db_cursor", "FETCH NEXT FROM db_cursor INTO @name", "WHILE @@FETCH_STATUS = 0", "BEGIN", "    BACKUP DATABASE @name TO DISK = '" + saveDB.FileName + "'", "    FETCH NEXT FROM db_cursor INTO @name", "END", "CLOSE db_cursor", "DEALLOCATE db_cursor" };
                        using (StreamWriter txt = new StreamWriter(rutaSQL))
                        {
                            foreach (string linea in aSQL)
                            {
                                txt.WriteLine(linea);
                            }
                        }
                        string mensaje = "Se ha generado el respaldo correctamente.";
                        iniciaRespaldo(rutaBat);
                        if (!File.Exists(saveDB.FileName))
                        {
                            darPermisos(ruta, "EVERYONE", FileSystemRights.Write, AccessControlType.Allow, true);
                            iniciaRespaldo(rutaBat);
                            darPermisos(ruta, "EVERYONE", FileSystemRights.Write, AccessControlType.Allow, false);
                            if (!File.Exists(saveDB.FileName))
                            {
                                mensaje = "Se ha producido un error desconocido. Si el problema continúa contacte al administrador del sistema";
                            }
                        }
                        if (mensaje == "Se ha generado el respaldo correctamente.")
                        {
                            Process.Start(ruta);
                            File.Delete(rutaBat);
                            File.Delete(rutaSQL);
                        }
                        MessageBox.Show(mensaje, "Respaldo de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No está conectado a una base de datos válida. Revise las configuraciones de conexión y reintente", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void iniciaRespaldo(string rutaBat)
        {
            Process proc = Process.Start(rutaBat);
            int i = 0;
            while (!proc.HasExited)
            {
                Thread.Sleep(100);
                i++;
            }
        }
        private void darPermisos(string FileName, string Account, FileSystemRights Rights, AccessControlType ControlType, bool dar)
        {
            DirectoryInfo dInfo = new DirectoryInfo(FileName);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            if (dar)
            {
                dSecurity.AddAccessRule(new FileSystemAccessRule(Account, Rights, ControlType));
            }
            else
            {
                dSecurity.RemoveAccessRule(new FileSystemAccessRule(Account, Rights, ControlType));
            }
            dInfo.SetAccessControl(dSecurity);
        }

        private void calzadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelojChecador oCalzado = new frmRelojChecador();
            oCalzado.ShowDialog();
        }

        private void LlenarGrid(DataTable _dtDatos)
        {
            gridInventario.DataSource = _dtDatos;

            gridInventario.Columns[0].Visible = false;
            gridInventario.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridInventario.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridInventario.Columns[15].Visible = false;
            gridInventario.Columns[16].Visible = false;
        }

        private void tbSucursales_Click(object sender, EventArgs e)
        {

        }

        private DataTable ActualizaGrid()
        {
            DataTable dtInventario = new DataTable();
            dtInventario = ExtraerDato.listadoDatos("select CodigoBarras as 'CÓDIGO DE BARRAS', Area as 'ÁREA', Nombre as 'NOMBRE DEL PRODUCTO', Descripcion as 'DESCRIPCIÓN', Presentacion as 'PRESENTACIÓN', UMPresentacion as 'U. M. PRESENTACIÓN', CONTENIDO, UMUso as 'U. M. USO', Maximo as 'MÁXIMO', Minimo as 'MÍNIMO', Ubicacion as 'UBICACIÓN', MARCA, TipoAlmacenamiento as 'ALMACENAMIENTO', TemperaturaC as 'TEMPERATURA EN ºC', REFERENCIA, idProducto, imagen from Productos where Activo = 1");
            LlenarGrid(dtInventario);
            return dtInventario;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string Sql;
            if (txtBusqueda.TextLength > 3)
            {
                Sql = "select CodigoBarras as 'CÓDIGO DE BARRAS', Area as 'ÁREA', Nombre as 'NOMBRE DEL PRODUCTO', Descripcion as 'DESCRIPCIÓN', Presentacion as 'PRESENTACIÓN', UMPresentacion as 'U. M. PRESENTACIÓN', CONTENIDO, UMUso as 'U. M. USO', Maximo as 'MÁXIMO', Minimo as 'MÍNIMO', Ubicacion as 'UBICACIÓN', MARCA, TipoAlmacenamiento as 'ALMACENAMIENTO', TemperaturaC as 'TEMPERATURA EN ºC', REFERENCIA, idProducto, imagen from Productos where Activo = 1 and (CodigoBarras like '%" + txtBusqueda.Text.Trim() + "%' or Area like '%" + txtBusqueda.Text.Trim() + "%' or Nombre like '%" + txtBusqueda.Text.Trim() + "%' or Descripcion like '%" + txtBusqueda.Text.Trim() + "%' or  Marca like '%" + txtBusqueda.Text.Trim() + "%' or  Ubicacion like '%" + txtBusqueda.Text.Trim() + "%')";
                DataTable dtInventario = new DataTable();
                dtInventario = ExtraerDato.listadoDatos(Sql);
                LlenarGrid(dtInventario);
            }
            if (txtBusqueda.TextLength == 0)
            {
                ActualizaGrid();
            }

        }

        private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionProductos frmGestion = new frmGestionProductos();
            frmGestion.ShowDialog();
            ActualizaGrid();
            ActualizaGridCaducidad();
            ActualizarGridMyM();    
        }

        private void gridInventario_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridInventario.CurrentRow.Cells[0].Value != null)
                {
                    txtDescripcion.Text = GeneraDescripcion();
                    idProducto = (int) gridInventario.CurrentRow.Cells[15].Value;
                    CalculaExistencias();
                    HabilitaBotones(true);
                }
                else
                {
                    HabilitaBotones(false);
                }
            }
            catch {}
        }
        private void HabilitaBotones(bool lActivo)
        {
            btnDetallesProducto.Enabled = lActivo;
            btnEntradaalmacen.Enabled = lActivo;
            if (gbExistenci.Visible & lblExistenciaActual.Text != "0")
            {
                btnSalidaalmacen.Enabled = true;
            }
            else
            {
                btnSalidaalmacen.Enabled = false;
            }
        }

        private string GeneraDescripcion()
        {
            string InformaciónGeneral = "\n\n";
            DataGridViewRow fila = gridInventario.CurrentRow;
            if (gridInventario.CurrentCell != null)
            {
                if (fila.Cells[0].Value.ToString() != "")
                {
                    pbCodigoQR.Image = ExtraerDato.aQR(fila.Cells[0].Value.ToString(), 132);
                }
                else
                {
                    pbCodigoQR.Image = null;
                }
                if (fila.Cells[16].Value != null)
                {
                    try
                    {
                        byte[] data = (byte[])fila.Cells[16].Value;
                        MemoryStream ms = new MemoryStream(data);
                        pbImagen.Image = Image.FromStream(ms);
                    }
                    catch (Exception)
                    {
                        pbImagen.Image = null;
                    }
                }
                else
                {
                    pbImagen.Image = null;
                }
                string cUltimoMov = ExtraerDato.Cadena("select top(1) CONVERT(varchar, dtFechaMovimiento, 22) from ExistenciasProductos where lEntrada = 1 and Activo = 1 and idProducto = " + fila.Cells[15].Value.ToString() + " order by dtFechaMovimiento desc");
                if (cUltimoMov.Length > 0)
                {
                    InformaciónGeneral += "Último entrada de almacén:\n" + cUltimoMov + "\n";
                    cUltimoMov = ExtraerDato.Cadena("select top(1) CONVERT(varchar, dtFechaMovimiento, 22) from ExistenciasProductos where lEntrada = 0 and Activo = 1 and idProducto = " + fila.Cells[15].Value.ToString() + " order by dtFechaMovimiento desc");
                    if (cUltimoMov.Length > 0)
                    {
                        InformaciónGeneral += "Última Salida de almacén:\n" + cUltimoMov + "\n";
                    }
                }

                if (fila.Cells[2].Value.ToString().Length > 0)
                {
                    InformaciónGeneral += "\n\nNombre:\n" + fila.Cells[2].Value.ToString();
                }
                if (fila.Cells[3].Value.ToString().Length > 0)
                {
                    InformaciónGeneral += "\n\nDescripción:\n" + fila.Cells[3].Value.ToString();
                }

                if (fila.Cells[11].Value.ToString().Length > 0)
                {
                    InformaciónGeneral += "\n\nMarca:\n" + fila.Cells[11].Value.ToString();
                }
                if (fila.Cells[9].Value.ToString().Length > 0)
                {
                    InformaciónGeneral += "\n\nMínimo permitido en almacén:\n" + fila.Cells[9].Value.ToString() + " " + fila.Cells[4].Value.ToString();
                }
                if (fila.Cells[8].Value.ToString().Length > 0)
                {
                    InformaciónGeneral += "\n\nMáximo permitido en almacén:\n" + fila.Cells[8].Value.ToString() + " " + fila.Cells[4].Value.ToString();
                }

                if (fila.Cells[1].Value.ToString() != "")
                {
                    InformaciónGeneral += "\n\nÁrea:\n" + fila.Cells[1].Value.ToString();
                }
                InformaciónGeneral = InformaciónGeneral.Replace("\n", "\r\n");
            }
            return InformaciónGeneral;
        }

        private void lblExistenciaActual_Click(object sender, EventArgs e)
        {
            CalculaExistencias();
        }
        private void CalculaExistencias()
        {
            lEsEntrada = !lEsEntrada;
            int idProducto;
            DataGridViewRow fila = gridInventario.CurrentRow;
            if (gridInventario.CurrentCell != null)
            {
                gbExistenci.Visible = true;
                if (int.TryParse(fila.Cells[15].Value.ToString(), out idProducto))
                {
                    string[] infoExistencias = Program.CalculaExistenciaActual(idProducto, lEsEntrada, false, "");
                    lblExistenciaActual.Text = infoExistencias[0];
                    lblUnidadExistencia.Text = infoExistencias[1];
                }
                else
                {
                    gbExistenci.Visible = false;
                }
            }
            else
            {
                gbExistenci.Visible = false;
            }
        }

        #region Panel de Existencias
        private void LlenarGridCaducidad(DataTable dtExistencias)
        {
            dgGridExistencias.DataSource = dtExistencias;
            dgGridExistencias.Columns[0].Visible = false;
            dgGridExistencias.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgGridExistencias.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgGridExistencias.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgGridExistencias.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgGridExistencias.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgGridExistencias.Columns[6].Visible = false;
        }

        private void ActualizaGridCaducidad()
        {
            Thread Cargado = new Thread(new ThreadStart(PintaCaducidad));
            Cargado.Start();
        }

        private void btnActualizarListado_Click(object sender, EventArgs e)
        {
            ActualizaGridCaducidad();
        }
        private void PintaCaducidad()
        {
            if (!this.trabajoEnCursoExistencias)
            {
                this.trabajoEnCursoExistencias = true;
                DataTable dtCaducidad = ExtraerDato.listadoDatos("select p.idproducto, p.NOMBRE, (p.Contenido * ef.Cantidad) as CANTIDAD, p.UMUso as 'U. M.', CONVERT(varchar, ef.dtCaducidad, 103) as 'FECHA DE CADUCIDAD', datediff(day, getdate(), ef.dtCaducidad) as 'DÍAS FALTANTES', p.Imagen from ExistenciaPorFecha ef inner join Productos p on ef.idProducto = p.idProducto where ef.Cantidad > 0 and ef.dtCaducidad is not null and p.Activo = 1 order by 'DÍAS FALTANTES' asc");
                if (dtCaducidad.Rows.Count > 0)
                {
                    if (dgGridExistencias.InvokeRequired)
                    {
                        LlenaGridCaducidad avg = new LlenaGridCaducidad(LlenarGridCaducidad);
                        this.Invoke(avg, dtCaducidad);
                    }
                    else
                    {
                        LlenarGridCaducidad(dtCaducidad);
                    }
                    foreach (DataGridViewRow filaCaducidad in dgGridExistencias.Rows)
                    {
                        int dias = int.Parse(filaCaducidad.Cells[5].Value.ToString());
                        if (dias < 91)
                        {
                            filaCaducidad.DefaultCellStyle.ForeColor = Color.White;
                            filaCaducidad.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                }
                this.trabajoEnCursoExistencias = false;
            }
        }
        private void ActualizarGridMyM()
        {
            Thread Cargado = new Thread(new ThreadStart(PintaMyM));
            Cargado.Start();
        }
        private void LlenarGridMyMd(DataTable dtMyM)
        {
            gridMyM.DataSource = dtMyM;
            gridMyM.Columns[0].Visible = false;
            gridMyM.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridMyM.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridMyM.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridMyM.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridMyM.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void PintaMyM()
        {
            if (!this.trabajoEnCursoMyM)
            {
                try
                {
                    this.trabajoEnCursoMyM = true;
                    DataTable dtMym = ExtraerDato.listadoDatos("select p.idProducto, p.NOMBRE, CONCAT(p.Minimo, ' ', p.Presentacion) as 'MÍNIMO', CONCAT(p.Maximo, ' ', p.Presentacion) as 'MÁXIMO', CONCAT(COALESCE((select sum(Cantidad) from ExistenciaPorFecha where idProducto = p.idProducto), 0), ' ', p.Presentacion) as 'EXISTENCIA ACTUAL', CASE WHEN COALESCE((select sum(Cantidad) from ExistenciaPorFecha where idProducto = p.idProducto), 0) < Minimo THEN 'EXISTENCIAS POR DEBAJO DEL MÍNIMO PERMITIDO' WHEN COALESCE((select sum(Cantidad) from ExistenciaPorFecha where idProducto = p.idProducto), 0) = Minimo THEN 'EXISTENCIAS EN EL LÍMITE DEL MÍNIMO PERMITIDO' WHEN COALESCE((select sum(Cantidad) from ExistenciaPorFecha where idProducto = p.idProducto), 0) > Maximo THEN 'EXISTENCIAS POR ENCIMA DEL MÁXIMO PERMITIDO' END as ESTADO from Productos p where Activo = 1");
                    if (dtMym.Rows.Count > 0)
                    {
                        if (gridMyM.InvokeRequired)
                        {
                            LlenarGridMyM avg = new LlenarGridMyM(LlenarGridMyMd);
                            this.Invoke(avg, dtMym);
                        }
                        else
                        {
                            LlenarGridMyMd(dtMym);
                        }

                        if (txtBusquedaMyM.InvokeRequired)
                        {
                            InhabilitaTexto avg = new InhabilitaTexto(InhabilitaCajaTexto);
                            this.Invoke(avg, false);
                        }
                        else
                        {
                            txtBusquedaMyM.Enabled = true;
                        }
                        foreach (DataGridViewRow filaCaducidad in gridMyM.Rows)
                        {
                            switch (filaCaducidad.Cells[5].Value.ToString())
                            {
                                case "EXISTENCIAS POR DEBAJO DEL MÍNIMO PERMITIDO":
                                    filaCaducidad.DefaultCellStyle.BackColor = Color.Red;
                                    filaCaducidad.DefaultCellStyle.ForeColor = Color.White;
                                    break;
                                case "EXISTENCIAS EN EL LÍMITE DEL MÍNIMO PERMITIDO":
                                    filaCaducidad.DefaultCellStyle.BackColor = Color.DarkGoldenrod;
                                    filaCaducidad.DefaultCellStyle.ForeColor = Color.White;
                                    break;
                                case "EXISTENCIAS POR ENCIMA DEL MÁXIMO PERMITIDO":
                                    filaCaducidad.DefaultCellStyle.BackColor = Color.DarkOrange;
                                    filaCaducidad.DefaultCellStyle.ForeColor = Color.White;
                                    break;
                                default:
                                    filaCaducidad.DefaultCellStyle.BackColor = Color.DarkGreen;
                                    filaCaducidad.DefaultCellStyle.ForeColor = Color.Black;
                                    filaCaducidad.Cells[5].Value = "DENTRO DE LOS PARÁMETROS ESPERADOS";
                                    break;
                            }
                        }
                        if (txtBusquedaMyM.InvokeRequired)
                        {
                            InhabilitaTexto avg = new InhabilitaTexto(InhabilitaCajaTexto);
                            this.Invoke(avg, true);
                        }
                        else
                        {
                            txtBusquedaMyM.Enabled = true;
                        }
                    }
                    this.trabajoEnCursoMyM = false;
                }
                catch (Exception ex) { this.trabajoEnCursoMyM = false; }
            }
        }
        #endregion

        private void dgGridExistencias_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PintaCaducidad();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActualizarGridMyM();
        }

        private void gridMyM_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PintaMyM();
        }
        private void BuscarMym()
        {
            string Sql;
            if (txtBusquedaMyM.TextLength > 3)
            {
                Sql = "select p.idProducto, p.NOMBRE, CONCAT(p.Minimo, ' ', p.Presentacion) as 'MÍNIMO', CONCAT(p.Maximo, ' ', p.Presentacion) as 'MÁXIMO', CONCAT(COALESCE((select sum(Cantidad) from ExistenciaPorFecha where idProducto = p.idProducto), 0), ' ', p.Presentacion) as 'EXISTENCIA ACTUAL', CASE WHEN COALESCE((select sum(Cantidad) from ExistenciaPorFecha where idProducto = p.idProducto), 0) < Minimo THEN 'EXISTENCIAS POR DEBAJO DEL MÍNIMO PERMITIDO' WHEN COALESCE((select sum(Cantidad) from ExistenciaPorFecha where idProducto = p.idProducto), 0) = Minimo THEN 'EXISTENCIAS EN EL LÍMITE DEL MÍNIMO PERMITIDO' WHEN COALESCE((select sum(Cantidad) from ExistenciaPorFecha where idProducto = p.idProducto), 0) > Maximo THEN 'EXISTENCIAS POR ENCIMA DEL MÁXIMO PERMITIDO' END as ESTADO from Productos p where Activo = 1 and (p.CodigoBarras like '%" + txtBusquedaMyM.Text.Trim() + "%' or p.Area like '%" + txtBusquedaMyM.Text.Trim() + "%' or p.Nombre like '%" + txtBusquedaMyM.Text.Trim() + "%' or p.Descripcion like '%" + txtBusquedaMyM.Text.Trim() + "%' or  p.Marca like '%" + txtBusquedaMyM.Text.Trim() + "%' or  Ubicacion like '%" + txtBusquedaMyM.Text.Trim() + "%') order by 'EXISTENCIA ACTUAL' asc";
                DataTable dtMym = new DataTable();
                dtMym = ExtraerDato.listadoDatos(Sql);
                LlenarGridMyMd(dtMym);
            }
            if (txtBusquedaMyM.TextLength == 0)
            {
                ActualizarGridMyM();
            }
            PintaMyM();
        }

        private void BuscarExistencias()
        {
            string Sql;
            if (txtBusquedaExistencias.TextLength > 3)
            {
                Sql = "select p.idproducto, p.NOMBRE, (p.Contenido * ef.Cantidad) as CANTIDAD, p.UMUso as 'U. M.', CONVERT(varchar, ef.dtCaducidad, 103) as 'FECHA DE CADUCIDAD', datediff(day, getdate(), ef.dtCaducidad) as 'DÍAS FALTANTES', p.Imagen from ExistenciaPorFecha ef inner join Productos p on ef.idProducto = p.idProducto where (ef.Cantidad > 0 and ef.dtCaducidad is not null and p.Activo = 1) and (p.CodigoBarras like '%" + txtBusquedaExistencias.Text.Trim() + "%' or p.Area like '%" + txtBusquedaExistencias.Text.Trim() + "%' or p.Nombre like '%" + txtBusquedaExistencias.Text.Trim() + "%' or p.Descripcion like '%" + txtBusquedaExistencias.Text.Trim() + "%' or  p.Marca like '%" + txtBusquedaExistencias.Text.Trim() + "%' or  Ubicacion like '%" + txtBusquedaExistencias.Text.Trim() + "%') order by 'DÍAS FALTANTES' asc";
                DataTable dtInventario = new DataTable();
                dtInventario = ExtraerDato.listadoDatos(Sql);
                LlenarGridCaducidad(dtInventario);
            }
            if (txtBusquedaExistencias.TextLength == 0)
            {
                ActualizaGridCaducidad();
            }
            PintaCaducidad();
        }

        private void txtBusquedaMyM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarMym();
            }
        }

        private void txtBusquedaExistencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarExistencias();
            }
        }

        private void lblExistenciaActual_TextChanged(object sender, EventArgs e)
        {
            if (lblExistenciaActual.Text == "0")
            {
                btnSalidaalmacen.Enabled = false;
            }
            else
            {
                btnSalidaalmacen.Enabled = true;
            }
        }

        private void btnEntradaalmacen_Click(object sender, EventArgs e)
        {
            frmExistenciasProducto entExistencia = new frmExistenciasProducto(idProducto, true, true);
            entExistencia.ShowDialog();
            CalculaExistencias();
        }

        private void btnSalidaalmacen_Click(object sender, EventArgs e)
        {
            frmExistenciasProducto entExistencia = new frmExistenciasProducto(idProducto, false, true);
            entExistencia.ShowDialog();
            CalculaExistencias();
        }

        private void ActualizaFila(int idProducto)
        {
            DataTable dtModificado = ExtraerDato.listadoDatos("select CodigoBarras as 'CÓDIGO DE BARRAS', Area as 'ÁREA', Nombre as 'NOMBRE DEL PRODUCTO', Descripcion as 'DESCRIPCIÓN', Presentacion as 'PRESENTACIÓN', UMPresentacion as 'U. M. PRESENTACIÓN', CONTENIDO, UMUso as 'U. M. USO', Maximo as 'MÁXIMO', Minimo as 'MÍNIMO', Ubicacion as 'UBICACIÓN', MARCA, TipoAlmacenamiento as 'ALMACENAMIENTO', TemperaturaC as 'TEMPERATURA EN ºC', REFERENCIA, idProducto, imagen from Productos where idProducto = " + idProducto + " and Activo = 1");
            gridInventario.CurrentRow.Cells[0].Value = dtModificado.Rows[0][0];
            gridInventario.CurrentRow.Cells[1].Value = dtModificado.Rows[0][1];
            gridInventario.CurrentRow.Cells[2].Value = dtModificado.Rows[0][2];
            gridInventario.CurrentRow.Cells[3].Value = dtModificado.Rows[0][3];
            gridInventario.CurrentRow.Cells[4].Value = dtModificado.Rows[0][4];
            gridInventario.CurrentRow.Cells[5].Value = dtModificado.Rows[0][5];
            gridInventario.CurrentRow.Cells[6].Value = dtModificado.Rows[0][6];
            gridInventario.CurrentRow.Cells[7].Value = dtModificado.Rows[0][7];
            gridInventario.CurrentRow.Cells[8].Value = dtModificado.Rows[0][8];
            gridInventario.CurrentRow.Cells[9].Value = dtModificado.Rows[0][9];
            gridInventario.CurrentRow.Cells[10].Value = dtModificado.Rows[0][10];
            gridInventario.CurrentRow.Cells[11].Value = dtModificado.Rows[0][11];
            gridInventario.CurrentRow.Cells[12].Value = dtModificado.Rows[0][12];
            gridInventario.CurrentRow.Cells[13].Value = dtModificado.Rows[0][13];
            gridInventario.CurrentRow.Cells[14].Value = dtModificado.Rows[0][14];
            gridInventario.CurrentRow.Cells[15].Value = dtModificado.Rows[0][15];
            gridInventario.CurrentRow.Cells[16].Value = dtModificado.Rows[0][16];
        }
        private void btnDetallesProducto_Click(object sender, EventArgs e)
        {
            frmGestionProductos frmGestion = new frmGestionProductos(this.idProducto, true);
            frmGestion.ShowDialog();
            ActualizaFila(idProducto);
            txtDescripcion.Text = GeneraDescripcion();
            ActualizaGridCaducidad();
            ActualizarGridMyM();
        }

        private void generarEntradasalidaDeAlmacénToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExistenciasProducto entExistencia = new frmExistenciasProducto(0, true);
            entExistencia.ShowDialog();
            CalculaExistencias();
        }

        private void gridInventario_MouseMove(object sender, MouseEventArgs e)
        {
            if (ckImagenPrevia.Checked)
            {
                try
                {
                    int fila;
                    DataGridView.HitTestInfo Hitest = gridInventario.HitTest(e.X, e.Y);
                    if (Hitest.Type == DataGridViewHitTestType.Cell)
                    {
                        fila = Hitest.RowIndex;
                        if (gridInventario.Rows[fila].Cells[16].Value.ToString() != "")
                        {
                            try
                            {
                                byte[] data = (byte[])gridInventario.Rows[fila].Cells[16].Value;
                                MemoryStream ms = new MemoryStream(data);
                                pbProducto.Image = Image.FromStream(ms);
                            }
                            catch
                            {
                                pbProducto.Visible = false;
                                return;
                            }
                            pbProducto.Left = e.X + 40;
                            pbProducto.Top = e.Y + 100;
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
                catch (Exception ex)
                {
                }
            }
        }

        private void gridInventario_MouseLeave(object sender, EventArgs e)
        {
            pbProducto.Visible = false;
        }

        private void tbEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados oEmpleados = new frmEmpleados();
            oEmpleados.ShowDialog();
        }

        private void archivosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void tsConfiguracionNomina_Click(object sender, EventArgs e)
        {
            frmConfiguracionNomina oConfigNom = new frmConfiguracionNomina();
            oConfigNom.ShowDialog();
        }
        private void generaNominaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGeneraNomina generaNomina = new frmGeneraNomina();
            generaNomina.ShowDialog();
        }
        private void registrosDelRelojChecadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIncidenciaChecador frmIncidenciaChecador = new frmIncidenciaChecador();
            frmIncidenciaChecador.ShowDialog();
        }
        private void movimientosAdicionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovimientosAdicionalesNomina oMovAdNom = new frmMovimientosAdicionalesNomina();
            oMovAdNom.ShowDialog();
        }
        private void toolChecador_Click(object sender, EventArgs e)
        {
            AbreRelojChecador();
        }
        private void AbreRelojChecador()
        {
            frmRelojChecador oRelojChecador = new frmRelojChecador();
            oRelojChecador.ShowDialog();
        }
    }
}