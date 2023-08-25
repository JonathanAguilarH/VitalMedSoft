namespace VitalLabSoft
{
    partial class frmExistenciasProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevoPaquete = new System.Windows.Forms.Button();
            this.txtNuevoPaquete = new System.Windows.Forms.TextBox();
            this.gbInfoProducto = new System.Windows.Forms.GroupBox();
            this.cbLote = new System.Windows.Forms.ComboBox();
            this.gbExistenci = new System.Windows.Forms.GroupBox();
            this.lblUnidadExistencia = new System.Windows.Forms.Label();
            this.lblExistenciaActual = new System.Windows.Forms.Label();
            this.cmUnidades = new System.Windows.Forms.ComboBox();
            this.lblLote = new System.Windows.Forms.Label();
            this.lblCaducidadProducto = new System.Windows.Forms.Label();
            this.cmCaducidad = new System.Windows.Forms.ComboBox();
            this.dtCaducidad = new System.Windows.Forms.DateTimePicker();
            this.ckAgregarCaducidad = new System.Windows.Forms.CheckBox();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.dtFechaMovimiento = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.nCantidad = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.lblIdMovimiento = new System.Windows.Forms.Label();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.pbImagenProducto = new System.Windows.Forms.PictureBox();
            this.lblImagenProducto = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.gbProductosExistentes = new System.Windows.Forms.GroupBox();
            this.pbProducto = new System.Windows.Forms.PictureBox();
            this.gridInventario = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckEntrada = new System.Windows.Forms.CheckBox();
            this.ckSalida = new System.Windows.Forms.CheckBox();
            this.dgMovimientos = new System.Windows.Forms.DataGridView();
            this.contextCaducidad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmEditaCaducidad = new System.Windows.Forms.ToolStripMenuItem();
            this.gbCaducidad = new System.Windows.Forms.GroupBox();
            this.lblEsEntrada = new System.Windows.Forms.Label();
            this.lblMovimiento = new System.Windows.Forms.Label();
            this.txtEditaLote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtEditarCaducidad = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCerrarCaducidad = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextoProducto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verInformaciónDeProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.gbInfoProducto.SuspendLayout();
            this.gbExistenci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenProducto)).BeginInit();
            this.gbProductosExistentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventario)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovimientos)).BeginInit();
            this.contextCaducidad.SuspendLayout();
            this.gbCaducidad.SuspendLayout();
            this.contextoProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbBtnNuevo,
            this.toolStripSeparator1,
            this.btnCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1137, 39);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbBtnNuevo
            // 
            this.tbBtnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBtnNuevo.Name = "tbBtnNuevo";
            this.tbBtnNuevo.Size = new System.Drawing.Size(139, 36);
            this.tbBtnNuevo.Text = "Nuevo movimiento";
            this.tbBtnNuevo.Click += new System.EventHandler(this.tbBtnNuevo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCerrar.Image = global::VitalLabSoft.Properties.Resources.btnCerrar;
            this.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(36, 36);
            this.btnCerrar.Text = "toolStripButton1";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Enabled = false;
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnGuardar.Location = new System.Drawing.Point(514, 277);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 29);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevoPaquete
            // 
            this.btnNuevoPaquete.Location = new System.Drawing.Point(0, 0);
            this.btnNuevoPaquete.Name = "btnNuevoPaquete";
            this.btnNuevoPaquete.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoPaquete.TabIndex = 0;
            // 
            // txtNuevoPaquete
            // 
            this.txtNuevoPaquete.Location = new System.Drawing.Point(0, 0);
            this.txtNuevoPaquete.Name = "txtNuevoPaquete";
            this.txtNuevoPaquete.Size = new System.Drawing.Size(100, 20);
            this.txtNuevoPaquete.TabIndex = 0;
            // 
            // gbInfoProducto
            // 
            this.gbInfoProducto.Controls.Add(this.cbLote);
            this.gbInfoProducto.Controls.Add(this.gbExistenci);
            this.gbInfoProducto.Controls.Add(this.cmUnidades);
            this.gbInfoProducto.Controls.Add(this.lblLote);
            this.gbInfoProducto.Controls.Add(this.lblCaducidadProducto);
            this.gbInfoProducto.Controls.Add(this.cmCaducidad);
            this.gbInfoProducto.Controls.Add(this.dtCaducidad);
            this.gbInfoProducto.Controls.Add(this.ckAgregarCaducidad);
            this.gbInfoProducto.Controls.Add(this.cbProveedor);
            this.gbInfoProducto.Controls.Add(this.lblProveedor);
            this.gbInfoProducto.Controls.Add(this.dtFechaMovimiento);
            this.gbInfoProducto.Controls.Add(this.label3);
            this.gbInfoProducto.Controls.Add(this.nCantidad);
            this.gbInfoProducto.Controls.Add(this.label2);
            this.gbInfoProducto.Controls.Add(this.label1);
            this.gbInfoProducto.Controls.Add(this.cmTipoMovimiento);
            this.gbInfoProducto.Controls.Add(this.lblIdMovimiento);
            this.gbInfoProducto.Controls.Add(this.lblIdProducto);
            this.gbInfoProducto.Controls.Add(this.pbImagenProducto);
            this.gbInfoProducto.Controls.Add(this.lblImagenProducto);
            this.gbInfoProducto.Controls.Add(this.lblNombre);
            this.gbInfoProducto.Controls.Add(this.txtNombreProducto);
            this.gbInfoProducto.Controls.Add(this.btnGuardar);
            this.gbInfoProducto.ForeColor = System.Drawing.Color.White;
            this.gbInfoProducto.Location = new System.Drawing.Point(496, 38);
            this.gbInfoProducto.Name = "gbInfoProducto";
            this.gbInfoProducto.Size = new System.Drawing.Size(631, 313);
            this.gbInfoProducto.TabIndex = 1;
            this.gbInfoProducto.TabStop = false;
            this.gbInfoProducto.Text = "Información de movimiento";
            // 
            // cbLote
            // 
            this.cbLote.FormattingEnabled = true;
            this.cbLote.Location = new System.Drawing.Point(252, 250);
            this.cbLote.Name = "cbLote";
            this.cbLote.Size = new System.Drawing.Size(354, 23);
            this.cbLote.TabIndex = 69;
            // 
            // gbExistenci
            // 
            this.gbExistenci.Controls.Add(this.lblUnidadExistencia);
            this.gbExistenci.Controls.Add(this.lblExistenciaActual);
            this.gbExistenci.ForeColor = System.Drawing.Color.White;
            this.gbExistenci.Location = new System.Drawing.Point(37, 224);
            this.gbExistenci.Name = "gbExistenci";
            this.gbExistenci.Size = new System.Drawing.Size(137, 76);
            this.gbExistenci.TabIndex = 68;
            this.gbExistenci.TabStop = false;
            this.gbExistenci.Text = "Existencia actual:";
            // 
            // lblUnidadExistencia
            // 
            this.lblUnidadExistencia.Location = new System.Drawing.Point(6, 54);
            this.lblUnidadExistencia.Name = "lblUnidadExistencia";
            this.lblUnidadExistencia.Size = new System.Drawing.Size(123, 19);
            this.lblUnidadExistencia.TabIndex = 67;
            this.lblUnidadExistencia.Text = "Unidades";
            this.lblUnidadExistencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExistenciaActual
            // 
            this.lblExistenciaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExistenciaActual.Location = new System.Drawing.Point(9, 17);
            this.lblExistenciaActual.Name = "lblExistenciaActual";
            this.lblExistenciaActual.Size = new System.Drawing.Size(120, 34);
            this.lblExistenciaActual.TabIndex = 66;
            this.lblExistenciaActual.Text = ".";
            this.lblExistenciaActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExistenciaActual.Click += new System.EventHandler(this.lblExistenciaActual_Click);
            // 
            // cmUnidades
            // 
            this.cmUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmUnidades.FormattingEnabled = true;
            this.cmUnidades.Location = new System.Drawing.Point(427, 107);
            this.cmUnidades.Name = "cmUnidades";
            this.cmUnidades.Size = new System.Drawing.Size(179, 23);
            this.cmUnidades.TabIndex = 66;
            this.cmUnidades.SelectedIndexChanged += new System.EventHandler(this.cmUnidades_SelectedIndexChanged);
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Location = new System.Drawing.Point(207, 253);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(39, 15);
            this.lblLote.TabIndex = 64;
            this.lblLote.Text = "Lote:";
            // 
            // lblCaducidadProducto
            // 
            this.lblCaducidadProducto.AutoSize = true;
            this.lblCaducidadProducto.Location = new System.Drawing.Point(207, 224);
            this.lblCaducidadProducto.Name = "lblCaducidadProducto";
            this.lblCaducidadProducto.Size = new System.Drawing.Size(159, 15);
            this.lblCaducidadProducto.TabIndex = 63;
            this.lblCaducidadProducto.Text = "Caducidad de producto:";
            // 
            // cmCaducidad
            // 
            this.cmCaducidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmCaducidad.FormattingEnabled = true;
            this.cmCaducidad.Location = new System.Drawing.Point(372, 221);
            this.cmCaducidad.Name = "cmCaducidad";
            this.cmCaducidad.Size = new System.Drawing.Size(234, 23);
            this.cmCaducidad.TabIndex = 62;
            this.cmCaducidad.SelectedIndexChanged += new System.EventHandler(this.cmCaducidad_SelectedIndexChanged);
            // 
            // dtCaducidad
            // 
            this.dtCaducidad.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtCaducidad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCaducidad.Location = new System.Drawing.Point(357, 194);
            this.dtCaducidad.Name = "dtCaducidad";
            this.dtCaducidad.Size = new System.Drawing.Size(249, 21);
            this.dtCaducidad.TabIndex = 61;
            this.dtCaducidad.ValueChanged += new System.EventHandler(this.dtCaducidad_ValueChanged);
            // 
            // ckAgregarCaducidad
            // 
            this.ckAgregarCaducidad.AutoSize = true;
            this.ckAgregarCaducidad.Location = new System.Drawing.Point(210, 194);
            this.ckAgregarCaducidad.Name = "ckAgregarCaducidad";
            this.ckAgregarCaducidad.Size = new System.Drawing.Size(146, 19);
            this.ckAgregarCaducidad.TabIndex = 60;
            this.ckAgregarCaducidad.Text = "Agregar caducidad";
            this.ckAgregarCaducidad.UseVisualStyleBackColor = true;
            this.ckAgregarCaducidad.CheckedChanged += new System.EventHandler(this.ckAgregarCaducidad_CheckedChanged);
            // 
            // cbProveedor
            // 
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(289, 165);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(317, 23);
            this.cbProveedor.TabIndex = 59;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(207, 168);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(76, 15);
            this.lblProveedor.TabIndex = 58;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // dtFechaMovimiento
            // 
            this.dtFechaMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaMovimiento.Location = new System.Drawing.Point(357, 136);
            this.dtFechaMovimiento.Name = "dtFechaMovimiento";
            this.dtFechaMovimiento.Size = new System.Drawing.Size(249, 21);
            this.dtFechaMovimiento.TabIndex = 57;
            this.dtFechaMovimiento.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 15);
            this.label3.TabIndex = 56;
            this.label3.Text = "Fecha de movimiento:";
            this.label3.Visible = false;
            // 
            // nCantidad
            // 
            this.nCantidad.DecimalPlaces = 4;
            this.nCantidad.Location = new System.Drawing.Point(281, 108);
            this.nCantidad.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nCantidad.Name = "nCantidad";
            this.nCantidad.Size = new System.Drawing.Size(136, 21);
            this.nCantidad.TabIndex = 54;
            this.nCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nCantidad.ValueChanged += new System.EventHandler(this.nCantidad_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 52;
            this.label2.Text = "Cantidad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 15);
            this.label1.TabIndex = 51;
            this.label1.Text = "Tipo de movimiento:";
            // 
            // cmTipoMovimiento
            // 
            this.cmTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmTipoMovimiento.FormattingEnabled = true;
            this.cmTipoMovimiento.Items.AddRange(new object[] {
            "Entrada de almacén",
            "Salida de almacén"});
            this.cmTipoMovimiento.Location = new System.Drawing.Point(350, 78);
            this.cmTipoMovimiento.Name = "cmTipoMovimiento";
            this.cmTipoMovimiento.Size = new System.Drawing.Size(256, 23);
            this.cmTipoMovimiento.TabIndex = 50;
            this.cmTipoMovimiento.SelectedIndexChanged += new System.EventHandler(this.cmTipoMovimiento_SelectedIndexChanged);
            // 
            // lblIdMovimiento
            // 
            this.lblIdMovimiento.AutoSize = true;
            this.lblIdMovimiento.Location = new System.Drawing.Point(530, 17);
            this.lblIdMovimiento.Name = "lblIdMovimiento";
            this.lblIdMovimiento.Size = new System.Drawing.Size(93, 15);
            this.lblIdMovimiento.TabIndex = 49;
            this.lblIdMovimiento.Text = "idMovimiento";
            this.lblIdMovimiento.Visible = false;
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.Location = new System.Drawing.Point(424, 17);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(76, 15);
            this.lblIdProducto.TabIndex = 48;
            this.lblIdProducto.Text = "idProducto";
            this.lblIdProducto.Visible = false;
            // 
            // pbImagenProducto
            // 
            this.pbImagenProducto.ErrorImage = global::VitalLabSoft.Properties.Resources.SG;
            this.pbImagenProducto.Location = new System.Drawing.Point(14, 46);
            this.pbImagenProducto.Name = "pbImagenProducto";
            this.pbImagenProducto.Size = new System.Drawing.Size(179, 159);
            this.pbImagenProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagenProducto.TabIndex = 47;
            this.pbImagenProducto.TabStop = false;
            // 
            // lblImagenProducto
            // 
            this.lblImagenProducto.AutoSize = true;
            this.lblImagenProducto.Location = new System.Drawing.Point(16, 28);
            this.lblImagenProducto.Name = "lblImagenProducto";
            this.lblImagenProducto.Size = new System.Drawing.Size(139, 15);
            this.lblImagenProducto.TabIndex = 46;
            this.lblImagenProducto.Text = "Imagen del producto";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(202, 28);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(142, 15);
            this.lblNombre.TabIndex = 31;
            this.lblNombre.Text = "Nombre de producto:";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Enabled = false;
            this.txtNombreProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtNombreProducto.Location = new System.Drawing.Point(205, 46);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(401, 21);
            this.txtNombreProducto.TabIndex = 2;
            // 
            // txtBuscar
            // 
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtBuscar.Location = new System.Drawing.Point(72, 21);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(398, 21);
            this.txtBuscar.TabIndex = 23;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(11, 24);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(55, 15);
            this.lblBuscar.TabIndex = 56;
            this.lblBuscar.Text = "Buscar:";
            // 
            // gbProductosExistentes
            // 
            this.gbProductosExistentes.Controls.Add(this.pbProducto);
            this.gbProductosExistentes.Controls.Add(this.lblBuscar);
            this.gbProductosExistentes.Controls.Add(this.txtBuscar);
            this.gbProductosExistentes.Controls.Add(this.gridInventario);
            this.gbProductosExistentes.ForeColor = System.Drawing.Color.White;
            this.gbProductosExistentes.Location = new System.Drawing.Point(12, 38);
            this.gbProductosExistentes.Name = "gbProductosExistentes";
            this.gbProductosExistentes.Size = new System.Drawing.Size(478, 313);
            this.gbProductosExistentes.TabIndex = 22;
            this.gbProductosExistentes.TabStop = false;
            this.gbProductosExistentes.Text = "Productos existentes";
            // 
            // pbProducto
            // 
            this.pbProducto.BackColor = System.Drawing.Color.White;
            this.pbProducto.Location = new System.Drawing.Point(208, 122);
            this.pbProducto.Name = "pbProducto";
            this.pbProducto.Size = new System.Drawing.Size(185, 175);
            this.pbProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProducto.TabIndex = 57;
            this.pbProducto.TabStop = false;
            this.pbProducto.Visible = false;
            // 
            // gridInventario
            // 
            this.gridInventario.AllowUserToAddRows = false;
            this.gridInventario.AllowUserToDeleteRows = false;
            this.gridInventario.AllowUserToResizeRows = false;
            this.gridInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInventario.BackgroundColor = System.Drawing.Color.White;
            this.gridInventario.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.gridInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridInventario.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridInventario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.gridInventario.Location = new System.Drawing.Point(8, 50);
            this.gridInventario.Margin = new System.Windows.Forms.Padding(5);
            this.gridInventario.MultiSelect = false;
            this.gridInventario.Name = "gridInventario";
            this.gridInventario.ReadOnly = true;
            this.gridInventario.RowHeadersVisible = false;
            this.gridInventario.RowHeadersWidth = 82;
            this.gridInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInventario.Size = new System.Drawing.Size(462, 255);
            this.gridInventario.TabIndex = 24;
            this.gridInventario.SelectionChanged += new System.EventHandler(this.gridInventario_SelectionChanged);
            this.gridInventario.MouseLeave += new System.EventHandler(this.gridInventario_MouseLeave);
            this.gridInventario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridInventario_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckEntrada);
            this.groupBox1.Controls.Add(this.ckSalida);
            this.groupBox1.Controls.Add(this.dgMovimientos);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 357);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1115, 503);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movimientos del producto";
            // 
            // ckEntrada
            // 
            this.ckEntrada.AutoSize = true;
            this.ckEntrada.Checked = true;
            this.ckEntrada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckEntrada.Location = new System.Drawing.Point(937, 20);
            this.ckEntrada.Name = "ckEntrada";
            this.ckEntrada.Size = new System.Drawing.Size(83, 19);
            this.ckEntrada.TabIndex = 65;
            this.ckEntrada.Text = "Entradas";
            this.ckEntrada.UseVisualStyleBackColor = true;
            this.ckEntrada.CheckedChanged += new System.EventHandler(this.ckEntrada_CheckedChanged);
            // 
            // ckSalida
            // 
            this.ckSalida.AutoSize = true;
            this.ckSalida.Checked = true;
            this.ckSalida.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSalida.Location = new System.Drawing.Point(1033, 20);
            this.ckSalida.Name = "ckSalida";
            this.ckSalida.Size = new System.Drawing.Size(74, 19);
            this.ckSalida.TabIndex = 64;
            this.ckSalida.Text = "Salidas";
            this.ckSalida.UseVisualStyleBackColor = true;
            this.ckSalida.CheckedChanged += new System.EventHandler(this.ckSalida_CheckedChanged);
            // 
            // dgMovimientos
            // 
            this.dgMovimientos.AllowUserToAddRows = false;
            this.dgMovimientos.AllowUserToDeleteRows = false;
            this.dgMovimientos.AllowUserToResizeRows = false;
            this.dgMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMovimientos.BackgroundColor = System.Drawing.Color.White;
            this.dgMovimientos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMovimientos.ContextMenuStrip = this.contextCaducidad;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMovimientos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgMovimientos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.dgMovimientos.Location = new System.Drawing.Point(8, 46);
            this.dgMovimientos.Margin = new System.Windows.Forms.Padding(5);
            this.dgMovimientos.Name = "dgMovimientos";
            this.dgMovimientos.ReadOnly = true;
            this.dgMovimientos.RowHeadersVisible = false;
            this.dgMovimientos.RowHeadersWidth = 82;
            this.dgMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMovimientos.Size = new System.Drawing.Size(1099, 449);
            this.dgMovimientos.TabIndex = 25;
            this.dgMovimientos.SelectionChanged += new System.EventHandler(this.dgMovimientos_SelectionChanged);
            // 
            // contextCaducidad
            // 
            this.contextCaducidad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmEditaCaducidad});
            this.contextCaducidad.Name = "contextoProducto";
            this.contextCaducidad.Size = new System.Drawing.Size(196, 26);
            // 
            // cmEditaCaducidad
            // 
            this.cmEditaCaducidad.Name = "cmEditaCaducidad";
            this.cmEditaCaducidad.Size = new System.Drawing.Size(195, 22);
            this.cmEditaCaducidad.Text = "Editar caducidad o lote";
            this.cmEditaCaducidad.Click += new System.EventHandler(this.cmEditaCaducidad_Click);
            // 
            // gbCaducidad
            // 
            this.gbCaducidad.Controls.Add(this.lblEsEntrada);
            this.gbCaducidad.Controls.Add(this.lblMovimiento);
            this.gbCaducidad.Controls.Add(this.txtEditaLote);
            this.gbCaducidad.Controls.Add(this.label5);
            this.gbCaducidad.Controls.Add(this.dtEditarCaducidad);
            this.gbCaducidad.Controls.Add(this.label4);
            this.gbCaducidad.Controls.Add(this.btnCerrarCaducidad);
            this.gbCaducidad.Controls.Add(this.button1);
            this.gbCaducidad.ForeColor = System.Drawing.Color.White;
            this.gbCaducidad.Location = new System.Drawing.Point(362, 549);
            this.gbCaducidad.Name = "gbCaducidad";
            this.gbCaducidad.Size = new System.Drawing.Size(362, 116);
            this.gbCaducidad.TabIndex = 66;
            this.gbCaducidad.TabStop = false;
            this.gbCaducidad.Text = "Editar caducidad y lote";
            this.gbCaducidad.Visible = false;
            // 
            // lblEsEntrada
            // 
            this.lblEsEntrada.AutoSize = true;
            this.lblEsEntrada.Location = new System.Drawing.Point(14, 54);
            this.lblEsEntrada.Name = "lblEsEntrada";
            this.lblEsEntrada.Size = new System.Drawing.Size(72, 15);
            this.lblEsEntrada.TabIndex = 69;
            this.lblEsEntrada.Text = "esEntrada";
            this.lblEsEntrada.Visible = false;
            // 
            // lblMovimiento
            // 
            this.lblMovimiento.AutoSize = true;
            this.lblMovimiento.Location = new System.Drawing.Point(38, 78);
            this.lblMovimiento.Name = "lblMovimiento";
            this.lblMovimiento.Size = new System.Drawing.Size(93, 15);
            this.lblMovimiento.TabIndex = 68;
            this.lblMovimiento.Text = "idMovimiento";
            this.lblMovimiento.Visible = false;
            // 
            // txtEditaLote
            // 
            this.txtEditaLote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtEditaLote.Location = new System.Drawing.Point(162, 51);
            this.txtEditaLote.Name = "txtEditaLote";
            this.txtEditaLote.Size = new System.Drawing.Size(189, 21);
            this.txtEditaLote.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 66;
            this.label5.Text = "Lote:";
            // 
            // dtEditarCaducidad
            // 
            this.dtEditarCaducidad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEditarCaducidad.Location = new System.Drawing.Point(161, 24);
            this.dtEditarCaducidad.Name = "dtEditarCaducidad";
            this.dtEditarCaducidad.Size = new System.Drawing.Size(190, 21);
            this.dtEditarCaducidad.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 15);
            this.label4.TabIndex = 58;
            this.label4.Text = "Fecha de caducidad:";
            // 
            // btnCerrarCaducidad
            // 
            this.btnCerrarCaducidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarCaducidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnCerrarCaducidad.Location = new System.Drawing.Point(259, 78);
            this.btnCerrarCaducidad.Name = "btnCerrarCaducidad";
            this.btnCerrarCaducidad.Size = new System.Drawing.Size(92, 29);
            this.btnCerrarCaducidad.TabIndex = 23;
            this.btnCerrarCaducidad.Text = "Cancelar";
            this.btnCerrarCaducidad.UseVisualStyleBackColor = true;
            this.btnCerrarCaducidad.Click += new System.EventHandler(this.btnCerrarCaducidad_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.button1.Location = new System.Drawing.Point(156, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 29);
            this.button1.TabIndex = 22;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextoProducto
            // 
            this.contextoProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verInformaciónDeProductoToolStripMenuItem});
            this.contextoProducto.Name = "contextoProducto";
            this.contextoProducto.Size = new System.Drawing.Size(227, 26);
            // 
            // verInformaciónDeProductoToolStripMenuItem
            // 
            this.verInformaciónDeProductoToolStripMenuItem.Name = "verInformaciónDeProductoToolStripMenuItem";
            this.verInformaciónDeProductoToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.verInformaciónDeProductoToolStripMenuItem.Text = "Ver información de producto";
            this.verInformaciónDeProductoToolStripMenuItem.Click += new System.EventHandler(this.verInformaciónDeProductoToolStripMenuItem_Click);
            // 
            // frmExistenciasProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1137, 872);
            this.Controls.Add(this.gbCaducidad);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbProductosExistentes);
            this.Controls.Add(this.gbInfoProducto);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmExistenciasProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmExistenciasProducto_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbInfoProducto.ResumeLayout(false);
            this.gbInfoProducto.PerformLayout();
            this.gbExistenci.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenProducto)).EndInit();
            this.gbProductosExistentes.ResumeLayout(false);
            this.gbProductosExistentes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventario)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMovimientos)).EndInit();
            this.contextCaducidad.ResumeLayout(false);
            this.gbCaducidad.ResumeLayout(false);
            this.gbCaducidad.PerformLayout();
            this.contextoProducto.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ToolStripButton btnCerrar;
        private System.Windows.Forms.Button btnNuevoPaquete;
        private System.Windows.Forms.TextBox txtNuevoPaquete;
        private System.Windows.Forms.ToolStripButton tbBtnNuevo;
        private System.Windows.Forms.GroupBox gbInfoProducto;
        private System.Windows.Forms.PictureBox pbImagenProducto;
        private System.Windows.Forms.Label lblImagenProducto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.GroupBox gbProductosExistentes;
        public System.Windows.Forms.DataGridView gridInventario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblIdMovimiento;
        private System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.NumericUpDown nCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmTipoMovimiento;
        private System.Windows.Forms.DateTimePicker dtFechaMovimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.DateTimePicker dtCaducidad;
        private System.Windows.Forms.CheckBox ckAgregarCaducidad;
        private System.Windows.Forms.Label lblCaducidadProducto;
        private System.Windows.Forms.ComboBox cmCaducidad;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView dgMovimientos;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.CheckBox ckEntrada;
        private System.Windows.Forms.CheckBox ckSalida;
        private System.Windows.Forms.ComboBox cmUnidades;
        private System.Windows.Forms.GroupBox gbExistenci;
        private System.Windows.Forms.Label lblUnidadExistencia;
        private System.Windows.Forms.Label lblExistenciaActual;
        private System.Windows.Forms.ContextMenuStrip contextoProducto;
        private System.Windows.Forms.ToolStripMenuItem verInformaciónDeProductoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbProducto;
        private System.Windows.Forms.GroupBox gbCaducidad;
        private System.Windows.Forms.ContextMenuStrip contextCaducidad;
        private System.Windows.Forms.ToolStripMenuItem cmEditaCaducidad;
        private System.Windows.Forms.Button btnCerrarCaducidad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtEditarCaducidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEditaLote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMovimiento;
        private System.Windows.Forms.ComboBox cbLote;
        private System.Windows.Forms.Label lblEsEntrada;
    }
}