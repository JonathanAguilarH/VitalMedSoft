using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AxZKFPEngXControl;

namespace VitalLabSoft
{
    public partial class frmEmpleados : Form
    {
        bool evaluarCampos = false;
        int idActual = 0;
        int iActivo = 1;
        int iNominaTurno = 0;
        int iNominaHora = 0;
        bool lIgnora = false;

        bool preparado = false;
        bool esperando = false;
        bool calidad = false;
        string template = "";
        string rutaArchivos = "";

        FileExplorer fe = new FileExplorer();
        private AxZKFPEngX ZkFprint = new AxZKFPEngX();
        public frmEmpleados()
        {
            InitializeComponent();
            listView1.AllowDrop = true;
            gbArchivos.AllowDrop = true;
            splitContainer1.AllowDrop = true;
            colorTexto(Apariencia.colorTextosUsuario);
            cargaGrid("");
        }
        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            this.rutaArchivos = Program.infoConexion[4];
            Controls.Add(ZkFprint);
            preparaHuella();
            limpiarCampos();
            
        }
        private void preparaHuella()
        {
            try
            {
                ZkFprint.OnImageReceived += zkFprint_OnImageReceived;
                ZkFprint.OnFeatureInfo += zkFprint_OnFeatureInfo;
                ZkFprint.OnEnroll += zkFprint_OnEnroll;
                if (ZkFprint.InitEngine() == 0)
                {
                    ZkFprint.FPEngineVersion = "9";
                    ZkFprint.EnrollCount = 3;
                    lblInfoLector.Text = "Dispositivo detectado";
                    this.preparado = true;
                }
            }
            catch (Exception ex)
            {
                this.preparado = false;
                lblInfoLector.Text = "Error al inicializar.";
                MessageBox.Show("Error al inicializar el lector de huella. Error: " + ex.Message);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try { ZkFprint.CancelEnroll(); } catch { }
        }
        public void colorTexto(Color _color)
        {
            txtNombres.ForeColor = _color;
            txtCodigo.ForeColor = _color;
            txtNombres.ForeColor = _color;
            txtAMaterno.ForeColor = _color;
            txtAPaterno.ForeColor = _color;
            txtDireccion.ForeColor = _color;
            txtPuesto.ForeColor = _color;
            txtNss.ForeColor = _color;
            txtBuscador.ForeColor = _color;
            txtPuesto.ForeColor = _color;
            dgEmpleados.ForeColor = _color;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (pbEmpleado.Image == null)
            {
                pbEmpleado.Image = Properties.Resources.Sin_imagen;
            }
            if (idActual == 0)
            {
                if (ExtraerDato.guardaImagen("insert into Empleados (Imagen, Nombres, ApellidoP, ApellidoM, fechaNacimiento, CURP, correo, Direccion, Celular, Escolaridad, Titulo, RFC, NSS, Puesto, fechaAlta, fechaInicioLaboral, NominaHora, SueldoHora, NominaTurno, SueldoTurno, NotasAdicionales, Activo, SueldoTotal, SueldoBase, SueldoPrestaciones) values (@imagen, '" + txtNombres.Text.ToUpper().Trim() + "', '" + txtAPaterno.Text.ToUpper().Trim() + "', '" + txtAMaterno.Text.ToUpper().Trim() + "', '" + Program.FormateoFecha(dtNacimiento.Value) + "', '" + txtCurp.Text.ToUpper().Trim() + "', '" + txtMail.Text.ToUpper().Trim() + "', '" + txtDireccion.Text.ToUpper().Trim() + "', '" + txtCelular.Text.ToUpper().Trim() + "', '" + cbEscolaridad.Text + "', '" + txtTitulo.Text.ToUpper().Trim() + "', '" + txtRfc.Text.ToUpper().Trim() + "', '" + txtNss.Text.ToUpper().Trim() + "', '" + txtPuesto.Text.ToUpper().Trim() + "', '" + Program.FormateoFechaHora(DateTime.Now) + "', '" + Program.FormateoFechaHora(dtFechaInicio.Value) + "', " + iNominaHora + ", '" + nSueldoHora.Value + "', " + iNominaTurno + ", '" + nSueldoTurno.Value + "', '" + txtNotasAdicionales.Text.Trim().ToUpper() + "', 1, " + nStotal.Value + ", " + nSbase.Value + ", " + nSprestaciones.Value + ")", pbEmpleado))
                {
                    MessageBox.Show("Se ha agregado correctamente.", "Guardado exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargaGrid("", true);
                    string ruta = this.rutaArchivos + "Empleados\\" + idActual + " - " + txtRfc.Text.Trim().ToUpper();
                    try
                    {
                        Directory.CreateDirectory(rutaArchivos);
                        cargaArchivos();
                    }
                    catch { }
                    ActivarHuella(true);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al guardar. Por favor, revise los datos introducidos y reintente. Si el problema persiste, contacte al administrador del sistema.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (ExtraerDato.guardaImagen("update Empleados set Imagen = @imagen, Nombres = '" + txtNombres.Text.Trim().ToUpper() + "', ApellidoP = '" + txtAPaterno.Text.Trim().ToUpper() + "', ApellidoM = '" + txtAMaterno.Text.Trim().ToUpper() + "', fechaNacimiento = '" + Program.FormateoFecha(dtNacimiento.Value) + "', CURP = '" + txtCurp.Text.Trim().ToUpper() + "', correo = '" + txtMail.Text.Trim().ToUpper() + "', Direccion = '" + txtDireccion.Text.Trim().ToUpper() + "', Celular = '" + txtCelular.Text.Trim().ToUpper() + "', Escolaridad = '" + cbEscolaridad.Text + "', Titulo = '" + txtTitulo.Text.Trim().ToUpper() + "', RFC = '" + txtRfc.Text.Trim().ToUpper() + "', NSS = '" + txtNss.Text.Trim().ToUpper() + "', Puesto = '" + txtPuesto.Text.Trim().ToUpper() + "', fechaInicioLaboral = '" + Program.FormateoFecha(dtFechaInicio.Value) + "', Activo = " + iActivo + ", fechaFinLaboral = '" + Program.FormateoFecha(dtBaja.Value) + "', NominaHora = '" + iNominaHora + "', SueldoHora = '" + nSueldoHora.Value + "', NominaTurno = '" + iNominaTurno + "', SueldoTurno = '" + nSueldoTurno.Value + "', codigo = '" + txtCodigo.Text.Trim() + "', NotasAdicionales = '" + txtNotasAdicionales.Text.Trim().ToUpper() + "', SueldoTotal = " + nStotal.Value + ", SueldoBase = " + nSbase.Value + ", SueldoPrestaciones = " + nSprestaciones.Value + " where idEmpleado = " + idActual, pbEmpleado))
                {
                    MessageBox.Show("Se ha agregado modificado.", "Guardado exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarFila();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al modificar. Por favor, revise los datos introducidos y reintente. Si el problema persiste, contacte al administrador del sistema.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cargaGrid(string busqueda, bool nuevo = false)
        {
            string sNuevo = "NOMBRE asc";
            if (nuevo)
            {
                sNuevo = "idEmpleado desc";
            }
            string filtro = "where Activo = 1";
            if (!ckEmpleadosActivos.Checked)
            {
                filtro = "";
            }
            evaluarCampos = false;
            if (busqueda != "")
            {
                if (filtro != "")
                {
                    filtro = filtro + " and";
                }
                else
                {
                    filtro = "where ";
                }
                filtro = filtro + "(Nombres like '%" + busqueda + "%' or ApellidoP like '%" + busqueda + "%' or ApellidoM like '%" + busqueda + "%' or CURP like '%" + busqueda + "%' or correo like '%" + busqueda + "%' or Direccion like '%" + busqueda + "%' or Celular like '%" + busqueda + "%' or Escolaridad like '%" + busqueda + "%' or Titulo like '%" + busqueda + "%' or RFC like '%" + busqueda + "%' or NSS like '%" + busqueda + "%' or Puesto like '%" + busqueda + "%' or NominaHora like '%" + busqueda + "%' or SueldoHora like '%" + busqueda + "%' or SueldoTurno like '%" + busqueda + "%' or NotasAdicionales like '%" + busqueda + "')";
            }
            dgEmpleados.DataSource = ExtraerDato.listadoDatos("SELECT idEmpleado, Codigo, Imagen, Nombres + ' ' + ApellidoP + ' ' + ApellidoM as NOMBRE, fechaNacimiento, CURP, correo, Direccion, Celular, Escolaridad, Titulo, RFC, NSS, Puesto, fechaAlta, fechaInicioLaboral, fechaFinLaboral, NominaHora, SueldoHora, NominaTurno, SueldoTurno, NotasAdicionales, Nombres, ApellidoP, ApellidoM, HuellaImagen, Activo, SueldoTotal, SueldoBase, SueldoPrestaciones FROM Empleados " + filtro + " order by " + sNuevo);
            if (dgEmpleados.Rows.Count == 0)
            {
                limpiarCampos(false);
            }
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
            dgEmpleados.Columns[27].Visible = false; // Sueldo Base
            dgEmpleados.Columns[28].Visible = false; // Sueldo Total
            dgEmpleados.Columns[29].Visible = false; // Sueldo PRestaciones
            dgEmpleados.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colorTexto(Apariencia.colorTextosUsuario);
            if (nuevo)
            {
                dgEmpleados.Rows[0].Selected = true;
                nuevo = false;
            }
        }
        public void llenarCampos()
        {
            if (dgEmpleados.CurrentRow != null)
            {
                try
                {
                    ActivarHuella(true);
                    lblIdEmpleado.Text = dgEmpleados.CurrentRow.Cells[0].Value.ToString();
                    txtCodigo.Text = String.Format("{0:00000}", dgEmpleados.CurrentRow.Cells[0].Value);   // Codigo,
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
                    try
                    {
                        byte[] data = (byte[])dgEmpleados.CurrentRow.Cells[25].Value;
                        MemoryStream ms = new MemoryStream(data);
                        pbHuella.Image = Image.FromStream(ms);
                        pbHuella.Visible = true;
                    }
                    catch (Exception)
                    {
                        pbHuella.Image = null; // Imagen,
                        pbHuella.Visible = false;
                    }
                    dtNacimiento.Value = (DateTime)(dgEmpleados.CurrentRow.Cells[4].Value.ToString() == "" ? DateTime.Now.AddYears(-18) : dgEmpleados.CurrentRow.Cells[4].Value);  // fechaNacimiento,
                    txtCurp.Text = dgEmpleados.CurrentRow.Cells[5].Value.ToString();  // CURP,
                    txtMail.Text = dgEmpleados.CurrentRow.Cells[6].Value.ToString();  // correo,
                    txtDireccion.Text = dgEmpleados.CurrentRow.Cells[7].Value.ToString();  // Direccion,
                    txtCelular.Text = dgEmpleados.CurrentRow.Cells[8].Value.ToString();  // Celular,
                    cbEscolaridad.Text = dgEmpleados.CurrentRow.Cells[9].Value.ToString();  // Escolaridad,
                    txtTitulo.Text = dgEmpleados.CurrentRow.Cells[10].Value.ToString(); // Titulo,
                    txtRfc.Text = dgEmpleados.CurrentRow.Cells[11].Value.ToString(); // RFC,
                    txtNss.Text = dgEmpleados.CurrentRow.Cells[12].Value.ToString(); // NSS,
                    txtPuesto.Text = dgEmpleados.CurrentRow.Cells[13].Value.ToString(); // Puesto,
                    dtFechaInicio.Value = (DateTime)(dgEmpleados.CurrentRow.Cells[15].Value.ToString() == "" ? DateTime.Now : dgEmpleados.CurrentRow.Cells[15].Value); // fechaInicioLaboral,
                    dtBaja.Value = (DateTime)(dgEmpleados.CurrentRow.Cells[16].Value.ToString() == "" ? DateTime.Now : dgEmpleados.CurrentRow.Cells[16].Value); // fechaFinLaboral,
                    ckHora.Checked = dgEmpleados.CurrentRow.Cells[17].Value.ToString() == "1"; // NominaHora,
                    nSueldoHora.Value = Convert.ToDecimal(dgEmpleados.CurrentRow.Cells[18].Value); // SueldoHora,
                    ckTurno.Checked = dgEmpleados.CurrentRow.Cells[19].Value.ToString() == "1"; // NominaTurno,
                    nSueldoTurno.Value = Convert.ToDecimal(dgEmpleados.CurrentRow.Cells[20].Value); // SueldoTurno,
                    txtNotasAdicionales.Text = dgEmpleados.CurrentRow.Cells[21].Value.ToString(); // NotasAdicionales
                    txtNombres.Text = dgEmpleados.CurrentRow.Cells[22].Value.ToString(); // Nombre,
                    txtAPaterno.Text = dgEmpleados.CurrentRow.Cells[23].Value.ToString(); // ApellidoP,
                    txtAMaterno.Text = dgEmpleados.CurrentRow.Cells[24].Value.ToString(); // ApellidoM
                    ckActivo.Checked = dgEmpleados.CurrentRow.Cells[26].Value.ToString() == "1" ? true : false; // Activo
                    nStotal.Value = Convert.ToDecimal(dgEmpleados.CurrentRow.Cells[27].Value.ToString()); // Sueldo total
                    nSbase.Value = Convert.ToDecimal(dgEmpleados.CurrentRow.Cells[28].Value.ToString()); // Sueldo base
                    nSprestaciones.Value = Convert.ToDecimal(dgEmpleados.CurrentRow.Cells[29].Value.ToString()); // Sueldo prestaciones
                    cargaArchivos();
                }
                catch
                {
                }
            }
        }
        private void ActivarHuella(bool activa)
        {
            pbHuella.Image = null;
            gbHuella.Visible = activa;
            lblInfoLector.Text = "";
        }
        private void tbNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
        public void alteraCampo(object sender, EventArgs e)
        {
            TextBox evaluo = (TextBox)sender;
            if (this.evaluarCampos)
            {
                evaluo.ForeColor = Color.Green;
            }
            else
            {
                evaluo.ForeColor = Apariencia.colorTextosUsuario;
            }
            evaluo = Program.evaluaCamposLigero(evaluo, evaluo.SelectionStart);
        }
        public void limpiarCampos(bool limpiaTexto = true)
        {
            lblIdEmpleado.Text = "0";
            if (limpiaTexto)
            {
                txtBuscador.Text = "";
            }
            ckActivo.Checked = true;
            txtCodigo.Text = "";
            txtNombres.Text = "";
            txtAMaterno.Text = "";
            txtAPaterno.Text = "";
            dtNacimiento.Value = DateTime.Today.AddYears(-18);
            dtNacimiento.MaxDate = DateTime.Today.AddDays(-1);
            txtCurp.Text = "";
            txtMail.Text = "";
            txtDireccion.Text = "";
            txtCelular.Text = "";
            cbEscolaridad.SelectedIndex = 0;
            txtTitulo.Text = "";
            txtRfc.Text = "";
            txtNss.Text = "";
            dtFechaInicio.Value = DateTime.Today;
            txtPuesto.Text = "";
            txtNotasAdicionales.Text = "";
            nSueldoTurno.Value = 0;
            ckTurno.Checked = false;
            ckHora.Checked = false;
            pbEmpleado.Image = null;
            listView1.Items.Clear();
            twFileExplorer.Nodes.Clear();
            splitContainer1.Enabled = false;
            nStotal.Value = 0;
            nSbase.Value = 0;
            nSprestaciones.Value = 0;
            ActivarHuella(false);
        }
        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscador.Text.Trim().Length > 2)
            {
                cargaGrid(txtBuscador.Text.Trim());
            }
            if (txtBuscador.Text.Trim().Length == 0)
            {
                cargaGrid("");
            }
        }
        private void cargaArchivos()
        {
            twFileExplorer.Nodes.Clear();
            listView1.Items.Clear();
            if (idActual != 0)
            {
                TreeNode rootNode;
                //string rutaArchivos = ExtraerDato.Cadena("select rutaArchivos from conexion where baseDatos = '" + Program.infoConexion[3] + "'");
                string rutaArchivosEmpleado = this.rutaArchivos + "\\Empleados\\" + lblIdEmpleado.Text + " - " + txtRfc.Text.Trim().ToUpper();
                if (rutaArchivosEmpleado != "")
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(rutaArchivosEmpleado);
                    if (dirInfo.Exists)
                    {
                        rootNode = new TreeNode(dirInfo.Name);
                        rootNode.Tag = dirInfo;
                        GetDirectories(dirInfo.GetDirectories(), rootNode);
                        twFileExplorer.Nodes.Add(rootNode);
                        splitContainer1.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("No se ha configurado la ruta de archivos", "Sin ruta de archivos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                splitContainer1.Enabled = false;
            }
        }
        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }
        private void twFileExplorer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"),
             new ListViewItem.ListViewSubItem(item,
                dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"),
             new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
        }

        private void ckTurno_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTurno.Checked)
            {
                iNominaTurno = 1;
            }
            else
            {
                iNominaTurno = 0;
                nSueldoTurno.Value = 0;
            }
            nSueldoTurno.Visible = ckTurno.Checked;
        }

        private void ckHora_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHora.Checked)
            {
                iNominaHora = 1;
            }
            else
            {
                iNominaHora = 0;
                nSueldoHora.Value = 0;
            }
            nSueldoHora.Visible = ckHora.Checked;
        }

        private void cbEscolaridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEscolaridad.SelectedIndex > 2)
            {
                lblTitulo.Visible = true;
                txtTitulo.Visible = true;
            }
            else
            {
                txtTitulo.Visible = false;
                lblTitulo.Visible = false;
                txtTitulo.Text = "";
            }
        }
        private void agregarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbAgregarImagen(sender, e);
        }

        private void pegarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbEmpleado.Image = Clipboard.GetImage();
            if (pbEmpleado.Image == null)
            {
                MessageBox.Show("No se pudo copiar el elemento del portapapeles", "Elemento incompatible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void copiarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pbEmpleado.Image != null)
            {
                Image imgCopiar = (Image)pbEmpleado.Image;
                Clipboard.SetImage(imgCopiar);
            }
        }

        private void eliminarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbEmpleado.Image = null;
        }
        private void pbAgregarImagen(object sender, EventArgs e)
        {
            try
            {
                Abrir.FileName = "";
                Abrir.Multiselect = false;
                Abrir.Filter = "Archivo de imagen |*.jpg;*.jpeg;*.png";
                Abrir.ShowDialog();
                string rutaReal = Abrir.FileName;
                int i = -1;
                if (rutaReal != "" & idActual != 0)
                {
                    Image imagenProducto = Image.FromFile(rutaReal);
                    if (imagenProducto != null)
                    {
                        pbEmpleado.Image = ExtraerDato.redimensionar(imagenProducto, 2);
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

        private void ckActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckActivo.Checked == false & idActual == 0)
            {
                MessageBox.Show("No se puede dar de alta un nuevo empleado con el estatus de Inactivo", "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lIgnora = true;
                ckActivo.Checked = true;
            }
            else
            {
                if (lIgnora == false)
                {
                    if (ckActivo.Checked)
                    {
                        ckActivo.BackColor = Color.FromArgb(192, 255, 192);
                        iActivo = 1;
                        lblFechaBaja.Visible = false;
                        dtBaja.Visible = false;
                    }
                    else
                    {
                        ckActivo.BackColor = Color.FromArgb(255, 192, 192);
                        iActivo = 0;
                        dtBaja.Value = DateTime.Now;
                        lblFechaBaja.Visible = true;
                        dtBaja.Visible = true;
                    }
                }
                else
                {
                    lIgnora = false;
                }
            }
        }

        private void lblIdEmpleado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                idActual = int.Parse(lblIdEmpleado.Text);
            }
            catch { }
        }

        private void dgEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            llenarCampos();
        }
        private void dgClientes_SelectionChanged(object sender, EventArgs e)
        {
            llenarCampos();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string rutaArchivos = this.rutaArchivos + "\\Empleados\\" + idActual + " - " + txtRfc.Text.Trim().ToUpper() + "\\" + listView1.SelectedItems[0].Text;
                if (File.Exists(rutaArchivos))
                {
                    System.Diagnostics.Process.Start(rutaArchivos);
                }
                else
                {
                    if (Directory.Exists(rutaArchivos))
                    {
                        System.Diagnostics.Process.Start(rutaArchivos);
                    }
                }
            }
        }
        private void abrirCarpetaPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rutaArchivos = this.rutaArchivos + "\\Empleados\\" + twFileExplorer.Nodes[0].Text;
            if (Directory.Exists(rutaArchivos))
            {
                System.Diagnostics.Process.Start(rutaArchivos);
            }
        }

        private void btnHuella_Click(object sender, EventArgs e)
        {
            this.esperando = true;
            lblInfoLector.Text = "Esperando huella...";
            activaEsperando();
        }

        private void activaEsperando()
        {
            ZkFprint.CancelEnroll();
            ZkFprint.EnrollCount = 1;
            ZkFprint.BeginEnroll();
        }
        private bool guardaHuella()
        {
            bool exitoso = false;
            try
            {
                exitoso = ExtraerDato.guardaImagen("update Empleados set HuellaImagen = @imagen, HuellaTemplateTexto = '" + this.template.Trim() + "' where idEmpleado = " + idActual, pbHuella);
            }
            catch { }
            return exitoso;
        }

        private void zkFprint_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            this.template = "";
            if (this.preparado & gbHuella.Visible & this.esperando)
            {
                Graphics g = pbHuella.CreateGraphics();
                Bitmap bmp = new Bitmap(pbHuella.Width, pbHuella.Height);
                g = Graphics.FromImage(bmp);
                int dc = g.GetHdc().ToInt32();
                ZkFprint.PrintImageAt(dc, 0, 0, bmp.Width, bmp.Height);
                g.Dispose();
                pbHuella.Image = bmp;
            }
        }
        private void zkFprint_OnFeatureInfo(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            if (this.preparado & gbHuella.Visible & this.esperando)
            {
                String strTemp = string.Empty;
                if (ZkFprint.LastQuality > 85)
                {
                    this.calidad = true;
                    lblInfoLector.Text = "Calidad de imagen: " + ZkFprint.LastQuality;
                    activaEsperando();
                }
                else
                {
                    this.calidad = false;
                    lblInfoLector.Text = "Calidad insuficiente. Intente de nuevo";
                }
            }
        }
        private void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            if (e.actionResult & this.esperando & this.calidad)
            {
                this.template = ZkFprint.EncodeTemplate1(e.aTemplate);
                if (this.template != "")
                {
                    if (guardaHuella())
                    {
                        lblInfoLector.Text = "Se ha agregado correctamente";
                    }
                    else
                    {
                        lblInfoLector.Text = "Ocurrió un problema. Intente de nuevo";
                    }
                }
            }
        }
        private void ActualizarFila()
        {
            dgEmpleados.CurrentRow.Cells[2].Value = ImagenAbyteArray(pbEmpleado.Image); // Imagen
            dgEmpleados.CurrentRow.Cells[3].Value = txtNombres.Text.Trim().ToUpper() + " " + txtAPaterno.Text.Trim().ToUpper() + " " + txtAMaterno.Text.Trim().ToUpper(); //  Nombres
            dgEmpleados.CurrentRow.Cells[4].Value = dtNacimiento.Value; // fechaNacimiento,
            dgEmpleados.CurrentRow.Cells[5].Value = txtCurp.Text.Trim().ToUpper(); // CURP,
            dgEmpleados.CurrentRow.Cells[6].Value = txtMail.Text.Trim().ToUpper(); // correo,
            dgEmpleados.CurrentRow.Cells[7].Value = txtDireccion.Text.Trim().ToUpper(); // Direccion,
            dgEmpleados.CurrentRow.Cells[8].Value = txtCelular.Text.Trim().ToUpper(); // Celular,
            dgEmpleados.CurrentRow.Cells[9].Value = cbEscolaridad.Text.Trim().ToUpper(); // Escolaridad,
            dgEmpleados.CurrentRow.Cells[10].Value = txtTitulo.Text.Trim().ToUpper(); // Titulo,
            dgEmpleados.CurrentRow.Cells[11].Value = txtRfc.Text.Trim().ToUpper(); // RFC,
            dgEmpleados.CurrentRow.Cells[12].Value = txtNss.Text.Trim().ToUpper(); // NSS,
            dgEmpleados.CurrentRow.Cells[13].Value = txtPuesto.Text.Trim().ToUpper(); // Puesto,
            dgEmpleados.CurrentRow.Cells[15].Value = dtFechaInicio.Value; // fechaInicioLaboral,
            dgEmpleados.CurrentRow.Cells[16].Value = dtBaja.Value; // fechaFinLaboral,
            dgEmpleados.CurrentRow.Cells[17].Value = ckHora.Checked ? "1" : "0"; // NominaHora,
            dgEmpleados.CurrentRow.Cells[18].Value = nSueldoHora.Value; // SueldoHora,
            dgEmpleados.CurrentRow.Cells[19].Value = ckTurno.Checked ? "1" : "0"; // NominaTurno,
            dgEmpleados.CurrentRow.Cells[20].Value = nSueldoTurno.Value; // SueldoTurno,
            dgEmpleados.CurrentRow.Cells[21].Value = txtNotasAdicionales.Text.Trim().ToUpper(); // NotasAdicionales
            dgEmpleados.CurrentRow.Cells[22].Value = txtNombres.Text.Trim().ToUpper(); // Nombre,
            dgEmpleados.CurrentRow.Cells[23].Value = txtAPaterno.Text.Trim().ToUpper(); // ApellidoP,
            dgEmpleados.CurrentRow.Cells[24].Value = txtAMaterno.Text.Trim().ToUpper(); // ApellidoM
            dgEmpleados.CurrentRow.Cells[25].Value = ImagenAbyteArray(pbHuella.Image); // Imagen huella
            dgEmpleados.CurrentRow.Cells[26].Value = ckActivo.Checked ? "1" : "0"; // Activo
            dgEmpleados.CurrentRow.Cells[27].Value = nStotal.Value; // S. total
            dgEmpleados.CurrentRow.Cells[28].Value = nSbase.Value; // S. base
            dgEmpleados.CurrentRow.Cells[29].Value = nSprestaciones.Value; // S. prestaciones
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
            { }
            return xByte;
        }

        private void ckEmpleadosActivos_CheckedChanged(object sender, EventArgs e)
        {
            cargaGrid(txtBuscador.Text.Trim());
        }

        private void nSbase_ValueChanged(object sender, EventArgs e)
        {
            CalculaSueldoTotal();
        }

        private void nSprestaciones_ValueChanged(object sender, EventArgs e)
        {
            CalculaSueldoTotal();
        }
        private void CalculaSueldoTotal()
        {
            nStotal.Value = nSbase.Value + nSprestaciones.Value;
        }
    }
}