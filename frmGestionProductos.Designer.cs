namespace VitalLabSoft
{
    partial class frmGestionProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionProductos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCargaExcel = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevoPaquete = new System.Windows.Forms.Button();
            this.txtNuevoPaquete = new System.Windows.Forms.TextBox();
            this.gbInfoProducto = new System.Windows.Forms.GroupBox();
            this.gbExistenci = new System.Windows.Forms.GroupBox();
            this.lblUnidadExistencia = new System.Windows.Forms.Label();
            this.lblExistenciaActual = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.txtArea = new System.Windows.Forms.ComboBox();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.gbAlmacenamiento = new System.Windows.Forms.GroupBox();
            this.txtUbicacionAlmacen = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTemperatura = new System.Windows.Forms.TextBox();
            this.lblUbicacionAlmacen = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlmacenamiento = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUnidadMaxima = new System.Windows.Forms.Label();
            this.txtMaximo = new System.Windows.Forms.NumericUpDown();
            this.txtMinimo = new System.Windows.Forms.NumericUpDown();
            this.lmlMinimo = new System.Windows.Forms.Label();
            this.lblMaximo = new System.Windows.Forms.Label();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.gbUnidadesUso = new System.Windows.Forms.GroupBox();
            this.txtPresentacionUso = new System.Windows.Forms.NumericUpDown();
            this.txtUnidadesUso = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbUnidadesCompra = new System.Windows.Forms.GroupBox();
            this.txtUnidadesCompra = new System.Windows.Forms.NumericUpDown();
            this.txtPresentacionCompra = new System.Windows.Forms.ComboBox();
            this.lblUnidades = new System.Windows.Forms.Label();
            this.lblPresentación = new System.Windows.Forms.Label();
            this.pbCodigoQR = new System.Windows.Forms.PictureBox();
            this.lblCodigoQR = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.pbImagenProducto = new System.Windows.Forms.PictureBox();
            this.cmImagenProducto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarImagenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarImagenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarImagenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarImagenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblImagenProducto = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.Abrir = new System.Windows.Forms.OpenFileDialog();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.gbProductosExistentes = new System.Windows.Forms.GroupBox();
            this.gridInventario = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.gbInfoProducto.SuspendLayout();
            this.gbExistenci.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbAlmacenamiento.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimo)).BeginInit();
            this.gbUnidadesUso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPresentacionUso)).BeginInit();
            this.gbUnidadesCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidadesCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCodigoQR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenProducto)).BeginInit();
            this.cmImagenProducto.SuspendLayout();
            this.gbProductosExistentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbBtnNuevo,
            this.toolStripSeparator1,
            this.btnCargaExcel,
            this.btnCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1374, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbBtnNuevo
            // 
            this.tbBtnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBtnNuevo.Name = "tbBtnNuevo";
            this.tbBtnNuevo.Size = new System.Drawing.Size(121, 22);
            this.tbBtnNuevo.Text = "Nuevo producto";
            this.tbBtnNuevo.Click += new System.EventHandler(this.tbBtnNuevo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCargaExcel
            // 
            this.btnCargaExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCargaExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnCargaExcel.Image")));
            this.btnCargaExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCargaExcel.Name = "btnCargaExcel";
            this.btnCargaExcel.Size = new System.Drawing.Size(143, 22);
            this.btnCargaExcel.Text = "Carga desde Excel";
            this.btnCargaExcel.Visible = false;
            this.btnCargaExcel.Click += new System.EventHandler(this.btnCargaExcel_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCerrar.Image = global::VitalLabSoft.Properties.Resources.btnCerrar;
            this.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(23, 22);
            this.btnCerrar.Text = "toolStripButton1";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnEliminar.Location = new System.Drawing.Point(1233, 307);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(92, 29);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnGuardar.Location = new System.Drawing.Point(1120, 307);
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
            this.gbInfoProducto.Controls.Add(this.gbExistenci);
            this.gbInfoProducto.Controls.Add(this.groupBox2);
            this.gbInfoProducto.Controls.Add(this.txtArea);
            this.gbInfoProducto.Controls.Add(this.txtCodigoBarras);
            this.gbInfoProducto.Controls.Add(this.btnEliminar);
            this.gbInfoProducto.Controls.Add(this.lblIdProducto);
            this.gbInfoProducto.Controls.Add(this.gbAlmacenamiento);
            this.gbInfoProducto.Controls.Add(this.groupBox1);
            this.gbInfoProducto.Controls.Add(this.lblReferencia);
            this.gbInfoProducto.Controls.Add(this.txtReferencia);
            this.gbInfoProducto.Controls.Add(this.lblMarca);
            this.gbInfoProducto.Controls.Add(this.txtMarca);
            this.gbInfoProducto.Controls.Add(this.gbUnidadesUso);
            this.gbInfoProducto.Controls.Add(this.gbUnidadesCompra);
            this.gbInfoProducto.Controls.Add(this.pbCodigoQR);
            this.gbInfoProducto.Controls.Add(this.lblCodigoQR);
            this.gbInfoProducto.Controls.Add(this.txtDescripcion);
            this.gbInfoProducto.Controls.Add(this.label1);
            this.gbInfoProducto.Controls.Add(this.lblArea);
            this.gbInfoProducto.Controls.Add(this.pbImagenProducto);
            this.gbInfoProducto.Controls.Add(this.lblImagenProducto);
            this.gbInfoProducto.Controls.Add(this.lblNombre);
            this.gbInfoProducto.Controls.Add(this.txtNombreProducto);
            this.gbInfoProducto.Controls.Add(this.btnGuardar);
            this.gbInfoProducto.ForeColor = System.Drawing.Color.White;
            this.gbInfoProducto.Location = new System.Drawing.Point(12, 39);
            this.gbInfoProducto.Name = "gbInfoProducto";
            this.gbInfoProducto.Size = new System.Drawing.Size(1350, 342);
            this.gbInfoProducto.TabIndex = 44;
            this.gbInfoProducto.TabStop = false;
            this.gbInfoProducto.Text = "Información de Producto";
            // 
            // gbExistenci
            // 
            this.gbExistenci.Controls.Add(this.lblUnidadExistencia);
            this.gbExistenci.Controls.Add(this.lblExistenciaActual);
            this.gbExistenci.ForeColor = System.Drawing.Color.White;
            this.gbExistenci.Location = new System.Drawing.Point(315, 73);
            this.gbExistenci.Name = "gbExistenci";
            this.gbExistenci.Size = new System.Drawing.Size(137, 76);
            this.gbExistenci.TabIndex = 67;
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
            this.lblUnidadExistencia.Click += new System.EventHandler(this.lblExistenciaActual_Click);
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
            this.lblExistenciaActual.TextChanged += new System.EventHandler(this.lblExistenciaActual_TextChanged);
            this.lblExistenciaActual.Click += new System.EventHandler(this.lblExistenciaActual_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEntrada);
            this.groupBox2.Controls.Add(this.btnSalida);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(1100, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 71);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control de existencias";
            // 
            // btnEntrada
            // 
            this.btnEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnEntrada.Location = new System.Drawing.Point(8, 20);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(227, 21);
            this.btnEntrada.TabIndex = 19;
            this.btnEntrada.Text = "Genera entrada de almacén";
            this.btnEntrada.UseVisualStyleBackColor = true;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // btnSalida
            // 
            this.btnSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnSalida.Location = new System.Drawing.Point(8, 43);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(227, 21);
            this.btnSalida.TabIndex = 20;
            this.btnSalida.Text = "Genera salida de almacén";
            this.btnSalida.UseVisualStyleBackColor = true;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // txtArea
            // 
            this.txtArea.FormattingEnabled = true;
            this.txtArea.Location = new System.Drawing.Point(504, 138);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(332, 23);
            this.txtArea.TabIndex = 3;
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtCodigoBarras.Location = new System.Drawing.Point(312, 304);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(132, 21);
            this.txtCodigoBarras.TabIndex = 10;
            this.txtCodigoBarras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoBarras_KeyDown);
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.Location = new System.Drawing.Point(184, 19);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(40, 15);
            this.lblIdProducto.TabIndex = 65;
            this.lblIdProducto.Text = "vacio";
            this.lblIdProducto.Visible = false;
            this.lblIdProducto.TextChanged += new System.EventHandler(this.lblIdProducto_TextChanged);
            // 
            // gbAlmacenamiento
            // 
            this.gbAlmacenamiento.Controls.Add(this.txtUbicacionAlmacen);
            this.gbAlmacenamiento.Controls.Add(this.label4);
            this.gbAlmacenamiento.Controls.Add(this.txtTemperatura);
            this.gbAlmacenamiento.Controls.Add(this.lblUbicacionAlmacen);
            this.gbAlmacenamiento.Controls.Add(this.label5);
            this.gbAlmacenamiento.Controls.Add(this.txtAlmacenamiento);
            this.gbAlmacenamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAlmacenamiento.ForeColor = System.Drawing.Color.White;
            this.gbAlmacenamiento.Location = new System.Drawing.Point(450, 225);
            this.gbAlmacenamiento.Name = "gbAlmacenamiento";
            this.gbAlmacenamiento.Size = new System.Drawing.Size(394, 111);
            this.gbAlmacenamiento.TabIndex = 11;
            this.gbAlmacenamiento.TabStop = false;
            this.gbAlmacenamiento.Text = "Especificaciones de almacenamiento";
            // 
            // txtUbicacionAlmacen
            // 
            this.txtUbicacionAlmacen.FormattingEnabled = true;
            this.txtUbicacionAlmacen.Location = new System.Drawing.Point(171, 20);
            this.txtUbicacionAlmacen.Name = "txtUbicacionAlmacen";
            this.txtUbicacionAlmacen.Size = new System.Drawing.Size(215, 23);
            this.txtUbicacionAlmacen.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 57;
            this.label4.Text = "Temperatura (ºC):";
            // 
            // txtTemperatura
            // 
            this.txtTemperatura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtTemperatura.Location = new System.Drawing.Point(138, 76);
            this.txtTemperatura.Name = "txtTemperatura";
            this.txtTemperatura.Size = new System.Drawing.Size(248, 21);
            this.txtTemperatura.TabIndex = 14;
            // 
            // lblUbicacionAlmacen
            // 
            this.lblUbicacionAlmacen.AutoSize = true;
            this.lblUbicacionAlmacen.Location = new System.Drawing.Point(11, 25);
            this.lblUbicacionAlmacen.Name = "lblUbicacionAlmacen";
            this.lblUbicacionAlmacen.Size = new System.Drawing.Size(154, 15);
            this.lblUbicacionAlmacen.TabIndex = 55;
            this.lblUbicacionAlmacen.Text = "Ubicación en almacén:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 15);
            this.label5.TabIndex = 53;
            this.label5.Text = "Tipo de almacenamiento:";
            // 
            // txtAlmacenamiento
            // 
            this.txtAlmacenamiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtAlmacenamiento.Location = new System.Drawing.Point(187, 49);
            this.txtAlmacenamiento.Name = "txtAlmacenamiento";
            this.txtAlmacenamiento.Size = new System.Drawing.Size(199, 21);
            this.txtAlmacenamiento.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUnidadMaxima);
            this.groupBox1.Controls.Add(this.txtMaximo);
            this.groupBox1.Controls.Add(this.txtMinimo);
            this.groupBox1.Controls.Add(this.lmlMinimo);
            this.groupBox1.Controls.Add(this.lblMaximo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(854, 225);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 111);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestión de existencias";
            // 
            // lblUnidadMaxima
            // 
            this.lblUnidadMaxima.Location = new System.Drawing.Point(116, 52);
            this.lblUnidadMaxima.Name = "lblUnidadMaxima";
            this.lblUnidadMaxima.Size = new System.Drawing.Size(118, 26);
            this.lblUnidadMaxima.TabIndex = 56;
            this.lblUnidadMaxima.Text = "UM";
            this.lblUnidadMaxima.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaximo
            // 
            this.txtMaximo.DecimalPlaces = 2;
            this.txtMaximo.Location = new System.Drawing.Point(13, 80);
            this.txtMaximo.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtMaximo.Name = "txtMaximo";
            this.txtMaximo.Size = new System.Drawing.Size(94, 21);
            this.txtMaximo.TabIndex = 17;
            this.txtMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaximo.ThousandsSeparator = true;
            this.txtMaximo.ValueChanged += new System.EventHandler(this.txtMaximo_ValueChanged);
            // 
            // txtMinimo
            // 
            this.txtMinimo.DecimalPlaces = 2;
            this.txtMinimo.Location = new System.Drawing.Point(13, 39);
            this.txtMinimo.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtMinimo.Name = "txtMinimo";
            this.txtMinimo.Size = new System.Drawing.Size(97, 21);
            this.txtMinimo.TabIndex = 16;
            this.txtMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinimo.ThousandsSeparator = true;
            this.txtMinimo.ValueChanged += new System.EventHandler(this.txtMaximo_ValueChanged);
            // 
            // lmlMinimo
            // 
            this.lmlMinimo.AutoSize = true;
            this.lmlMinimo.Location = new System.Drawing.Point(10, 21);
            this.lmlMinimo.Name = "lmlMinimo";
            this.lmlMinimo.Size = new System.Drawing.Size(66, 15);
            this.lmlMinimo.TabIndex = 55;
            this.lmlMinimo.Text = "Mínimas:";
            // 
            // lblMaximo
            // 
            this.lblMaximo.AutoSize = true;
            this.lblMaximo.Location = new System.Drawing.Point(10, 63);
            this.lblMaximo.Name = "lblMaximo";
            this.lblMaximo.Size = new System.Drawing.Size(69, 15);
            this.lblMaximo.TabIndex = 53;
            this.lblMaximo.Text = "Máximas:";
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(447, 197);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(81, 15);
            this.lblReferencia.TabIndex = 64;
            this.lblReferencia.Text = "Referencia:";
            // 
            // txtReferencia
            // 
            this.txtReferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtReferencia.Location = new System.Drawing.Point(534, 194);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(302, 21);
            this.txtReferencia.TabIndex = 5;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(447, 170);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(51, 15);
            this.lblMarca.TabIndex = 62;
            this.lblMarca.Text = "Marca:";
            // 
            // txtMarca
            // 
            this.txtMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtMarca.Location = new System.Drawing.Point(504, 167);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(332, 21);
            this.txtMarca.TabIndex = 4;
            // 
            // gbUnidadesUso
            // 
            this.gbUnidadesUso.Controls.Add(this.txtPresentacionUso);
            this.gbUnidadesUso.Controls.Add(this.txtUnidadesUso);
            this.gbUnidadesUso.Controls.Add(this.label2);
            this.gbUnidadesUso.Controls.Add(this.label3);
            this.gbUnidadesUso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUnidadesUso.ForeColor = System.Drawing.Color.White;
            this.gbUnidadesUso.Location = new System.Drawing.Point(1100, 127);
            this.gbUnidadesUso.Name = "gbUnidadesUso";
            this.gbUnidadesUso.Size = new System.Drawing.Size(241, 92);
            this.gbUnidadesUso.TabIndex = 60;
            this.gbUnidadesUso.TabStop = false;
            this.gbUnidadesUso.Text = "Unidades de uso";
            // 
            // txtPresentacionUso
            // 
            this.txtPresentacionUso.DecimalPlaces = 2;
            this.txtPresentacionUso.Location = new System.Drawing.Point(105, 29);
            this.txtPresentacionUso.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtPresentacionUso.Name = "txtPresentacionUso";
            this.txtPresentacionUso.Size = new System.Drawing.Size(120, 21);
            this.txtPresentacionUso.TabIndex = 8;
            this.txtPresentacionUso.ThousandsSeparator = true;
            // 
            // txtUnidadesUso
            // 
            this.txtUnidadesUso.FormattingEnabled = true;
            this.txtUnidadesUso.Location = new System.Drawing.Point(106, 55);
            this.txtUnidadesUso.Name = "txtUnidadesUso";
            this.txtUnidadesUso.Size = new System.Drawing.Size(119, 23);
            this.txtUnidadesUso.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 59;
            this.label2.Text = "Unidades:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 57;
            this.label3.Text = "Presentación:";
            // 
            // gbUnidadesCompra
            // 
            this.gbUnidadesCompra.Controls.Add(this.txtUnidadesCompra);
            this.gbUnidadesCompra.Controls.Add(this.txtPresentacionCompra);
            this.gbUnidadesCompra.Controls.Add(this.lblUnidades);
            this.gbUnidadesCompra.Controls.Add(this.lblPresentación);
            this.gbUnidadesCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUnidadesCompra.ForeColor = System.Drawing.Color.White;
            this.gbUnidadesCompra.Location = new System.Drawing.Point(842, 127);
            this.gbUnidadesCompra.Name = "gbUnidadesCompra";
            this.gbUnidadesCompra.Size = new System.Drawing.Size(241, 92);
            this.gbUnidadesCompra.TabIndex = 59;
            this.gbUnidadesCompra.TabStop = false;
            this.gbUnidadesCompra.Text = "Unidades de compra";
            // 
            // txtUnidadesCompra
            // 
            this.txtUnidadesCompra.DecimalPlaces = 2;
            this.txtUnidadesCompra.Location = new System.Drawing.Point(110, 55);
            this.txtUnidadesCompra.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtUnidadesCompra.Name = "txtUnidadesCompra";
            this.txtUnidadesCompra.Size = new System.Drawing.Size(125, 21);
            this.txtUnidadesCompra.TabIndex = 7;
            this.txtUnidadesCompra.ThousandsSeparator = true;
            // 
            // txtPresentacionCompra
            // 
            this.txtPresentacionCompra.FormattingEnabled = true;
            this.txtPresentacionCompra.Location = new System.Drawing.Point(110, 26);
            this.txtPresentacionCompra.Name = "txtPresentacionCompra";
            this.txtPresentacionCompra.Size = new System.Drawing.Size(119, 23);
            this.txtPresentacionCompra.TabIndex = 6;
            this.txtPresentacionCompra.TextChanged += new System.EventHandler(this.txtPresentacionCompra_SelectedIndexChanged);
            // 
            // lblUnidades
            // 
            this.lblUnidades.AutoSize = true;
            this.lblUnidades.Location = new System.Drawing.Point(32, 55);
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Size = new System.Drawing.Size(72, 15);
            this.lblUnidades.TabIndex = 55;
            this.lblUnidades.Text = "Unidades:";
            // 
            // lblPresentación
            // 
            this.lblPresentación.AutoSize = true;
            this.lblPresentación.Location = new System.Drawing.Point(9, 31);
            this.lblPresentación.Name = "lblPresentación";
            this.lblPresentación.Size = new System.Drawing.Size(95, 15);
            this.lblPresentación.TabIndex = 53;
            this.lblPresentación.Text = "Presentación:";
            // 
            // pbCodigoQR
            // 
            this.pbCodigoQR.Location = new System.Drawing.Point(312, 170);
            this.pbCodigoQR.Name = "pbCodigoQR";
            this.pbCodigoQR.Size = new System.Drawing.Size(132, 132);
            this.pbCodigoQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCodigoQR.TabIndex = 58;
            this.pbCodigoQR.TabStop = false;
            // 
            // lblCodigoQR
            // 
            this.lblCodigoQR.AutoSize = true;
            this.lblCodigoQR.Location = new System.Drawing.Point(309, 152);
            this.lblCodigoQR.Name = "lblCodigoQR";
            this.lblCodigoQR.Size = new System.Drawing.Size(76, 15);
            this.lblCodigoQR.TabIndex = 57;
            this.lblCodigoQR.Text = "Código QR";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtDescripcion.Location = new System.Drawing.Point(485, 46);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(857, 78);
            this.txtDescripcion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 15);
            this.label1.TabIndex = 55;
            this.label1.Text = "Descripción de producto:";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(458, 143);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(40, 15);
            this.lblArea.TabIndex = 51;
            this.lblArea.Text = "Área:";
            // 
            // pbImagenProducto
            // 
            this.pbImagenProducto.ContextMenuStrip = this.cmImagenProducto;
            this.pbImagenProducto.ErrorImage = global::VitalLabSoft.Properties.Resources.Sin_imagen;
            this.pbImagenProducto.Image = global::VitalLabSoft.Properties.Resources.SG;
            this.pbImagenProducto.Location = new System.Drawing.Point(6, 46);
            this.pbImagenProducto.Name = "pbImagenProducto";
            this.pbImagenProducto.Size = new System.Drawing.Size(300, 284);
            this.pbImagenProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagenProducto.TabIndex = 47;
            this.pbImagenProducto.TabStop = false;
            // 
            // cmImagenProducto
            // 
            this.cmImagenProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarImagenToolStripMenuItem,
            this.pegarImagenToolStripMenuItem,
            this.copiarImagenToolStripMenuItem,
            this.eliminarImagenToolStripMenuItem});
            this.cmImagenProducto.Name = "cmImagenProducto";
            this.cmImagenProducto.Size = new System.Drawing.Size(161, 92);
            // 
            // agregarImagenToolStripMenuItem
            // 
            this.agregarImagenToolStripMenuItem.Name = "agregarImagenToolStripMenuItem";
            this.agregarImagenToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.agregarImagenToolStripMenuItem.Text = "Agregar imagen";
            this.agregarImagenToolStripMenuItem.Click += new System.EventHandler(this.agregarImagenToolStripMenuItem_Click);
            // 
            // pegarImagenToolStripMenuItem
            // 
            this.pegarImagenToolStripMenuItem.Name = "pegarImagenToolStripMenuItem";
            this.pegarImagenToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.pegarImagenToolStripMenuItem.Text = "Pegar imagen";
            this.pegarImagenToolStripMenuItem.Click += new System.EventHandler(this.pegarImagenToolStripMenuItem_Click);
            // 
            // copiarImagenToolStripMenuItem
            // 
            this.copiarImagenToolStripMenuItem.Name = "copiarImagenToolStripMenuItem";
            this.copiarImagenToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.copiarImagenToolStripMenuItem.Text = "Copiar imagen";
            this.copiarImagenToolStripMenuItem.Click += new System.EventHandler(this.copiarImagenToolStripMenuItem_Click);
            // 
            // eliminarImagenToolStripMenuItem
            // 
            this.eliminarImagenToolStripMenuItem.Name = "eliminarImagenToolStripMenuItem";
            this.eliminarImagenToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.eliminarImagenToolStripMenuItem.Text = "Eliminar imagen";
            this.eliminarImagenToolStripMenuItem.Click += new System.EventHandler(this.eliminarImagenToolStripMenuItem_Click);
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
            this.lblNombre.Location = new System.Drawing.Point(312, 22);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(142, 15);
            this.lblNombre.TabIndex = 31;
            this.lblNombre.Text = "Nombre de producto:";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtNombreProducto.Location = new System.Drawing.Point(460, 19);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(882, 21);
            this.txtNombreProducto.TabIndex = 1;
            // 
            // Abrir
            // 
            this.Abrir.FileName = "openFileDialog1";
            // 
            // txtBuscar
            // 
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtBuscar.Location = new System.Drawing.Point(72, 21);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(1269, 21);
            this.txtBuscar.TabIndex = 23;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
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
            this.gbProductosExistentes.Controls.Add(this.gridInventario);
            this.gbProductosExistentes.Controls.Add(this.lblBuscar);
            this.gbProductosExistentes.Controls.Add(this.txtBuscar);
            this.gbProductosExistentes.ForeColor = System.Drawing.Color.White;
            this.gbProductosExistentes.Location = new System.Drawing.Point(12, 381);
            this.gbProductosExistentes.Name = "gbProductosExistentes";
            this.gbProductosExistentes.Size = new System.Drawing.Size(1350, 411);
            this.gbProductosExistentes.TabIndex = 22;
            this.gbProductosExistentes.TabStop = false;
            this.gbProductosExistentes.Text = "Productos existentes";
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
            this.gridInventario.Name = "gridInventario";
            this.gridInventario.ReadOnly = true;
            this.gridInventario.RowHeadersVisible = false;
            this.gridInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInventario.Size = new System.Drawing.Size(1334, 353);
            this.gridInventario.TabIndex = 24;
            this.gridInventario.SelectionChanged += new System.EventHandler(this.gridInventario_SelectionChanged);
            // 
            // frmGestionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1374, 804);
            this.Controls.Add(this.gbInfoProducto);
            this.Controls.Add(this.gbProductosExistentes);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmGestionProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmGestionProductos_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbInfoProducto.ResumeLayout(false);
            this.gbInfoProducto.PerformLayout();
            this.gbExistenci.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbAlmacenamiento.ResumeLayout(false);
            this.gbAlmacenamiento.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimo)).EndInit();
            this.gbUnidadesUso.ResumeLayout(false);
            this.gbUnidadesUso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPresentacionUso)).EndInit();
            this.gbUnidadesCompra.ResumeLayout(false);
            this.gbUnidadesCompra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidadesCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCodigoQR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenProducto)).EndInit();
            this.cmImagenProducto.ResumeLayout(false);
            this.gbProductosExistentes.ResumeLayout(false);
            this.gbProductosExistentes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ToolStripButton btnCerrar;
        private System.Windows.Forms.Button btnNuevoPaquete;
        private System.Windows.Forms.TextBox txtNuevoPaquete;
        private System.Windows.Forms.ToolStripButton tbBtnNuevo;
        private System.Windows.Forms.GroupBox gbInfoProducto;
        private System.Windows.Forms.OpenFileDialog Abrir;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.PictureBox pbImagenProducto;
        private System.Windows.Forms.Label lblImagenProducto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.GroupBox gbProductosExistentes;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbCodigoQR;
        private System.Windows.Forms.Label lblCodigoQR;
        private System.Windows.Forms.GroupBox gbUnidadesUso;
        private System.Windows.Forms.GroupBox gbUnidadesCompra;
        private System.Windows.Forms.Label lblUnidades;
        private System.Windows.Forms.Label lblPresentación;
        private System.Windows.Forms.GroupBox gbAlmacenamiento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTemperatura;
        private System.Windows.Forms.Label lblUbicacionAlmacen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAlmacenamiento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lmlMinimo;
        private System.Windows.Forms.Label lblMaximo;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView gridInventario;
        private System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCargaExcel;
        private System.Windows.Forms.ContextMenuStrip cmImagenProducto;
        private System.Windows.Forms.ToolStripMenuItem copiarImagenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarImagenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarImagenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarImagenToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.ComboBox txtArea;
        private System.Windows.Forms.ComboBox txtUbicacionAlmacen;
        private System.Windows.Forms.ComboBox txtUnidadesUso;
        private System.Windows.Forms.ComboBox txtPresentacionCompra;
        private System.Windows.Forms.NumericUpDown txtPresentacionUso;
        private System.Windows.Forms.NumericUpDown txtUnidadesCompra;
        private System.Windows.Forms.NumericUpDown txtMaximo;
        private System.Windows.Forms.NumericUpDown txtMinimo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Label lblUnidadMaxima;
        private System.Windows.Forms.GroupBox gbExistenci;
        private System.Windows.Forms.Label lblUnidadExistencia;
        private System.Windows.Forms.Label lblExistenciaActual;
    }
}