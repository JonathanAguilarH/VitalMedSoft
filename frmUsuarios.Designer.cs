namespace VitalLabSoft
{
    partial class frmUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarios));
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.dgUsuarios = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tConfiguraciones = new System.Windows.Forms.TabControl();
            this.tabPrincipal = new System.Windows.Forms.TabPage();
            this.gbNominas = new System.Windows.Forms.GroupBox();
            this.ckGuardarMovtos = new System.Windows.Forms.CheckBox();
            this.ckImprimir = new System.Windows.Forms.CheckBox();
            this.ckAutorizar = new System.Windows.Forms.CheckBox();
            this.ckGenerar = new System.Windows.Forms.CheckBox();
            this.ckMovimientos = new System.Windows.Forms.CheckBox();
            this.ckNominas = new System.Windows.Forms.CheckBox();
            this.tabConfiguraciones = new System.Windows.Forms.TabPage();
            this.ckRespalda = new System.Windows.Forms.CheckBox();
            this.ckCambioEpmpresa = new System.Windows.Forms.CheckBox();
            this.ckApariencia = new System.Windows.Forms.CheckBox();
            this.tabCatalogos = new System.Windows.Forms.TabPage();
            this.ckAgregaAreas = new System.Windows.Forms.CheckBox();
            this.ckGuardaAreas = new System.Windows.Forms.CheckBox();
            this.ckAreas = new System.Windows.Forms.CheckBox();
            this.chkExcelEmpleados = new System.Windows.Forms.CheckBox();
            this.ckImprimirId = new System.Windows.Forms.CheckBox();
            this.chkDetalleTurnos = new System.Windows.Forms.CheckBox();
            this.ckGuardaSucursales = new System.Windows.Forms.CheckBox();
            this.ckSucursales = new System.Windows.Forms.CheckBox();
            this.ckGuardaUsuarios = new System.Windows.Forms.CheckBox();
            this.ckGuardaEmpleados = new System.Windows.Forms.CheckBox();
            this.ckGuardaTurnos = new System.Windows.Forms.CheckBox();
            this.ckUsuarios = new System.Windows.Forms.CheckBox();
            this.ckEmpleados = new System.Windows.Forms.CheckBox();
            this.ckTurnos = new System.Windows.Forms.CheckBox();
            this.tabRemoto = new System.Windows.Forms.TabPage();
            this.ckRemoto = new System.Windows.Forms.CheckBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbNuevo = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsuarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tConfiguraciones.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.gbNominas.SuspendLayout();
            this.tabConfiguraciones.SuspendLayout();
            this.tabCatalogos.SuspendLayout();
            this.tabRemoto.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(6, 32);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(49, 16);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(246, 32);
            this.lblPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(74, 16);
            this.lblPass.TabIndex = 1;
            this.lblPass.Text = "Contraseña:";
            // 
            // dgUsuarios
            // 
            this.dgUsuarios.AllowUserToAddRows = false;
            this.dgUsuarios.AllowUserToDeleteRows = false;
            this.dgUsuarios.AllowUserToResizeRows = false;
            this.dgUsuarios.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(78)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(78)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(78)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgUsuarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUsuarios.Location = new System.Drawing.Point(3, 18);
            this.dgUsuarios.MultiSelect = false;
            this.dgUsuarios.Name = "dgUsuarios";
            this.dgUsuarios.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(78)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(78)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUsuarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgUsuarios.RowHeadersVisible = false;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(78)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(78)))), ((int)(((byte)(106)))));
            this.dgUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUsuarios.Size = new System.Drawing.Size(221, 530);
            this.dgUsuarios.TabIndex = 2;
            this.dgUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUsuarios_CellContentClick);
            this.dgUsuarios.SelectionChanged += new System.EventHandler(this.dgUsuarios_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgUsuarios);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(10, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 551);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuarios registrados";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtCorreo);
            this.groupBox2.Controls.Add(this.txtPass);
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblUsuario);
            this.groupBox2.Controls.Add(this.lblPass);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(242, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(908, 525);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de Usuario";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(811, 476);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 43);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(718, 476);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(88, 43);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tConfiguraciones);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(9, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(893, 362);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permisos";
            // 
            // tConfiguraciones
            // 
            this.tConfiguraciones.Controls.Add(this.tabPrincipal);
            this.tConfiguraciones.Controls.Add(this.tabConfiguraciones);
            this.tConfiguraciones.Controls.Add(this.tabCatalogos);
            this.tConfiguraciones.Controls.Add(this.tabRemoto);
            this.tConfiguraciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tConfiguraciones.Location = new System.Drawing.Point(3, 18);
            this.tConfiguraciones.Name = "tConfiguraciones";
            this.tConfiguraciones.SelectedIndex = 0;
            this.tConfiguraciones.Size = new System.Drawing.Size(887, 341);
            this.tConfiguraciones.TabIndex = 8;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.gbNominas);
            this.tabPrincipal.Controls.Add(this.ckNominas);
            this.tabPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPrincipal.ForeColor = System.Drawing.Color.Black;
            this.tabPrincipal.Location = new System.Drawing.Point(4, 25);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipal.Size = new System.Drawing.Size(879, 312);
            this.tabPrincipal.TabIndex = 0;
            this.tabPrincipal.Text = "Principal";
            this.tabPrincipal.UseVisualStyleBackColor = true;
            // 
            // gbNominas
            // 
            this.gbNominas.Controls.Add(this.ckGuardarMovtos);
            this.gbNominas.Controls.Add(this.ckImprimir);
            this.gbNominas.Controls.Add(this.ckAutorizar);
            this.gbNominas.Controls.Add(this.ckGenerar);
            this.gbNominas.Controls.Add(this.ckMovimientos);
            this.gbNominas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbNominas.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNominas.Location = new System.Drawing.Point(15, 31);
            this.gbNominas.Name = "gbNominas";
            this.gbNominas.Size = new System.Drawing.Size(152, 167);
            this.gbNominas.TabIndex = 11;
            this.gbNominas.TabStop = false;
            this.gbNominas.Text = "Gestión de nóminas";
            this.gbNominas.Visible = false;
            // 
            // ckGuardarMovtos
            // 
            this.ckGuardarMovtos.AutoSize = true;
            this.ckGuardarMovtos.Enabled = false;
            this.ckGuardarMovtos.Location = new System.Drawing.Point(23, 45);
            this.ckGuardarMovtos.Name = "ckGuardarMovtos";
            this.ckGuardarMovtos.Size = new System.Drawing.Size(129, 36);
            this.ckGuardarMovtos.TabIndex = 2;
            this.ckGuardarMovtos.Text = "Guardar/Modificar\r\nmovimientos extra";
            this.ckGuardarMovtos.UseVisualStyleBackColor = true;
            // 
            // ckImprimir
            // 
            this.ckImprimir.AutoSize = true;
            this.ckImprimir.Location = new System.Drawing.Point(5, 131);
            this.ckImprimir.Name = "ckImprimir";
            this.ckImprimir.Size = new System.Drawing.Size(112, 20);
            this.ckImprimir.TabIndex = 5;
            this.ckImprimir.Text = "Imprimir Recibos";
            this.ckImprimir.UseVisualStyleBackColor = true;
            // 
            // ckAutorizar
            // 
            this.ckAutorizar.AutoSize = true;
            this.ckAutorizar.Location = new System.Drawing.Point(5, 107);
            this.ckAutorizar.Name = "ckAutorizar";
            this.ckAutorizar.Size = new System.Drawing.Size(117, 20);
            this.ckAutorizar.TabIndex = 4;
            this.ckAutorizar.Text = "Autorizar Nómina";
            this.ckAutorizar.UseVisualStyleBackColor = true;
            // 
            // ckGenerar
            // 
            this.ckGenerar.AutoSize = true;
            this.ckGenerar.Location = new System.Drawing.Point(5, 82);
            this.ckGenerar.Name = "ckGenerar";
            this.ckGenerar.Size = new System.Drawing.Size(116, 20);
            this.ckGenerar.TabIndex = 3;
            this.ckGenerar.Text = "Generar Nómina";
            this.ckGenerar.UseVisualStyleBackColor = true;
            // 
            // ckMovimientos
            // 
            this.ckMovimientos.AutoSize = true;
            this.ckMovimientos.Location = new System.Drawing.Point(5, 20);
            this.ckMovimientos.Name = "ckMovimientos";
            this.ckMovimientos.Size = new System.Drawing.Size(145, 20);
            this.ckMovimientos.TabIndex = 1;
            this.ckMovimientos.Text = "Ver movimientos extra";
            this.ckMovimientos.UseVisualStyleBackColor = true;
            this.ckMovimientos.CheckedChanged += new System.EventHandler(this.ckMovimientos_CheckedChanged);
            // 
            // ckNominas
            // 
            this.ckNominas.AutoSize = true;
            this.ckNominas.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNominas.Location = new System.Drawing.Point(5, 6);
            this.ckNominas.Name = "ckNominas";
            this.ckNominas.Size = new System.Drawing.Size(134, 20);
            this.ckNominas.TabIndex = 0;
            this.ckNominas.Text = "Gestión de Nóminas";
            this.ckNominas.UseVisualStyleBackColor = true;
            this.ckNominas.CheckedChanged += new System.EventHandler(this.ckNominas_CheckedChanged);
            // 
            // tabConfiguraciones
            // 
            this.tabConfiguraciones.Controls.Add(this.ckRespalda);
            this.tabConfiguraciones.Controls.Add(this.ckCambioEpmpresa);
            this.tabConfiguraciones.Controls.Add(this.ckApariencia);
            this.tabConfiguraciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabConfiguraciones.Location = new System.Drawing.Point(4, 25);
            this.tabConfiguraciones.Name = "tabConfiguraciones";
            this.tabConfiguraciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfiguraciones.Size = new System.Drawing.Size(467, 314);
            this.tabConfiguraciones.TabIndex = 1;
            this.tabConfiguraciones.Text = "Configuraciones";
            this.tabConfiguraciones.UseVisualStyleBackColor = true;
            // 
            // ckRespalda
            // 
            this.ckRespalda.AutoSize = true;
            this.ckRespalda.ForeColor = System.Drawing.Color.Black;
            this.ckRespalda.Location = new System.Drawing.Point(5, 55);
            this.ckRespalda.Name = "ckRespalda";
            this.ckRespalda.Size = new System.Drawing.Size(147, 17);
            this.ckRespalda.TabIndex = 2;
            this.ckRespalda.Text = "Respaldar Base de Datos";
            this.ckRespalda.UseVisualStyleBackColor = true;
            // 
            // ckCambioEpmpresa
            // 
            this.ckCambioEpmpresa.AutoSize = true;
            this.ckCambioEpmpresa.ForeColor = System.Drawing.Color.Black;
            this.ckCambioEpmpresa.Location = new System.Drawing.Point(5, 31);
            this.ckCambioEpmpresa.Name = "ckCambioEpmpresa";
            this.ckCambioEpmpresa.Size = new System.Drawing.Size(120, 17);
            this.ckCambioEpmpresa.TabIndex = 1;
            this.ckCambioEpmpresa.Text = "Cambio de Empresa";
            this.ckCambioEpmpresa.UseVisualStyleBackColor = true;
            // 
            // ckApariencia
            // 
            this.ckApariencia.AutoSize = true;
            this.ckApariencia.ForeColor = System.Drawing.Color.Black;
            this.ckApariencia.Location = new System.Drawing.Point(5, 6);
            this.ckApariencia.Name = "ckApariencia";
            this.ckApariencia.Size = new System.Drawing.Size(133, 17);
            this.ckApariencia.TabIndex = 0;
            this.ckApariencia.Text = "Apariencia del Sistema";
            this.ckApariencia.UseVisualStyleBackColor = true;
            // 
            // tabCatalogos
            // 
            this.tabCatalogos.Controls.Add(this.ckAgregaAreas);
            this.tabCatalogos.Controls.Add(this.ckGuardaAreas);
            this.tabCatalogos.Controls.Add(this.ckAreas);
            this.tabCatalogos.Controls.Add(this.chkExcelEmpleados);
            this.tabCatalogos.Controls.Add(this.ckImprimirId);
            this.tabCatalogos.Controls.Add(this.chkDetalleTurnos);
            this.tabCatalogos.Controls.Add(this.ckGuardaSucursales);
            this.tabCatalogos.Controls.Add(this.ckSucursales);
            this.tabCatalogos.Controls.Add(this.ckGuardaUsuarios);
            this.tabCatalogos.Controls.Add(this.ckGuardaEmpleados);
            this.tabCatalogos.Controls.Add(this.ckGuardaTurnos);
            this.tabCatalogos.Controls.Add(this.ckUsuarios);
            this.tabCatalogos.Controls.Add(this.ckEmpleados);
            this.tabCatalogos.Controls.Add(this.ckTurnos);
            this.tabCatalogos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCatalogos.Location = new System.Drawing.Point(4, 25);
            this.tabCatalogos.Name = "tabCatalogos";
            this.tabCatalogos.Size = new System.Drawing.Size(467, 314);
            this.tabCatalogos.TabIndex = 2;
            this.tabCatalogos.Text = "Catálogos";
            this.tabCatalogos.UseVisualStyleBackColor = true;
            // 
            // ckAgregaAreas
            // 
            this.ckAgregaAreas.AutoSize = true;
            this.ckAgregaAreas.ForeColor = System.Drawing.Color.Black;
            this.ckAgregaAreas.Location = new System.Drawing.Point(23, 199);
            this.ckAgregaAreas.Name = "ckAgregaAreas";
            this.ckAgregaAreas.Size = new System.Drawing.Size(182, 17);
            this.ckAgregaAreas.TabIndex = 16;
            this.ckAgregaAreas.Text = "Agrega/Elimina Áreas por Turnos";
            this.ckAgregaAreas.UseVisualStyleBackColor = true;
            // 
            // ckGuardaAreas
            // 
            this.ckGuardaAreas.AutoSize = true;
            this.ckGuardaAreas.ForeColor = System.Drawing.Color.Black;
            this.ckGuardaAreas.Location = new System.Drawing.Point(212, 28);
            this.ckGuardaAreas.Name = "ckGuardaAreas";
            this.ckGuardaAreas.Size = new System.Drawing.Size(136, 17);
            this.ckGuardaAreas.TabIndex = 15;
            this.ckGuardaAreas.Text = "Guarda/Modifica Áreas";
            this.ckGuardaAreas.UseVisualStyleBackColor = true;
            // 
            // ckAreas
            // 
            this.ckAreas.AutoSize = true;
            this.ckAreas.ForeColor = System.Drawing.Color.Black;
            this.ckAreas.Location = new System.Drawing.Point(193, 3);
            this.ckAreas.Name = "ckAreas";
            this.ckAreas.Size = new System.Drawing.Size(53, 17);
            this.ckAreas.TabIndex = 14;
            this.ckAreas.Text = "Áreas";
            this.ckAreas.UseVisualStyleBackColor = true;
            // 
            // chkExcelEmpleados
            // 
            this.chkExcelEmpleados.AutoSize = true;
            this.chkExcelEmpleados.ForeColor = System.Drawing.Color.Black;
            this.chkExcelEmpleados.Location = new System.Drawing.Point(23, 101);
            this.chkExcelEmpleados.Name = "chkExcelEmpleados";
            this.chkExcelEmpleados.Size = new System.Drawing.Size(118, 17);
            this.chkExcelEmpleados.TabIndex = 8;
            this.chkExcelEmpleados.Text = "Cargar desde Excel";
            this.chkExcelEmpleados.UseVisualStyleBackColor = true;
            // 
            // ckImprimirId
            // 
            this.ckImprimirId.AutoSize = true;
            this.ckImprimirId.ForeColor = System.Drawing.Color.Black;
            this.ckImprimirId.Location = new System.Drawing.Point(23, 126);
            this.ckImprimirId.Name = "ckImprimirId";
            this.ckImprimirId.Size = new System.Drawing.Size(137, 17);
            this.ckImprimirId.TabIndex = 8;
            this.ckImprimirId.Text = "Imprimir identificaciones";
            this.ckImprimirId.UseVisualStyleBackColor = true;
            // 
            // chkDetalleTurnos
            // 
            this.chkDetalleTurnos.AutoSize = true;
            this.chkDetalleTurnos.ForeColor = System.Drawing.Color.Black;
            this.chkDetalleTurnos.Location = new System.Drawing.Point(23, 224);
            this.chkDetalleTurnos.Name = "chkDetalleTurnos";
            this.chkDetalleTurnos.Size = new System.Drawing.Size(187, 17);
            this.chkDetalleTurnos.TabIndex = 11;
            this.chkDetalleTurnos.Text = "Guarda/Modifica detalle de turnos";
            this.chkDetalleTurnos.UseVisualStyleBackColor = true;
            // 
            // ckGuardaSucursales
            // 
            this.ckGuardaSucursales.AutoSize = true;
            this.ckGuardaSucursales.ForeColor = System.Drawing.Color.Black;
            this.ckGuardaSucursales.Location = new System.Drawing.Point(23, 273);
            this.ckGuardaSucursales.Name = "ckGuardaSucursales";
            this.ckGuardaSucursales.Size = new System.Drawing.Size(161, 17);
            this.ckGuardaSucursales.TabIndex = 13;
            this.ckGuardaSucursales.Text = "Guarda/Modifica Sucursales";
            this.ckGuardaSucursales.UseVisualStyleBackColor = true;
            // 
            // ckSucursales
            // 
            this.ckSucursales.AutoSize = true;
            this.ckSucursales.ForeColor = System.Drawing.Color.Black;
            this.ckSucursales.Location = new System.Drawing.Point(3, 249);
            this.ckSucursales.Name = "ckSucursales";
            this.ckSucursales.Size = new System.Drawing.Size(78, 17);
            this.ckSucursales.TabIndex = 12;
            this.ckSucursales.Text = "Sucursales";
            this.ckSucursales.UseVisualStyleBackColor = true;
            // 
            // ckGuardaUsuarios
            // 
            this.ckGuardaUsuarios.AutoSize = true;
            this.ckGuardaUsuarios.ForeColor = System.Drawing.Color.Black;
            this.ckGuardaUsuarios.Location = new System.Drawing.Point(23, 28);
            this.ckGuardaUsuarios.Name = "ckGuardaUsuarios";
            this.ckGuardaUsuarios.Size = new System.Drawing.Size(150, 17);
            this.ckGuardaUsuarios.TabIndex = 5;
            this.ckGuardaUsuarios.Text = "Guarda/Modifica Usuarios";
            this.ckGuardaUsuarios.UseVisualStyleBackColor = true;
            // 
            // ckGuardaEmpleados
            // 
            this.ckGuardaEmpleados.AutoSize = true;
            this.ckGuardaEmpleados.ForeColor = System.Drawing.Color.Black;
            this.ckGuardaEmpleados.Location = new System.Drawing.Point(23, 77);
            this.ckGuardaEmpleados.Name = "ckGuardaEmpleados";
            this.ckGuardaEmpleados.Size = new System.Drawing.Size(161, 17);
            this.ckGuardaEmpleados.TabIndex = 7;
            this.ckGuardaEmpleados.Text = "Guarda/Modifica Empleados";
            this.ckGuardaEmpleados.UseVisualStyleBackColor = true;
            // 
            // ckGuardaTurnos
            // 
            this.ckGuardaTurnos.AutoSize = true;
            this.ckGuardaTurnos.ForeColor = System.Drawing.Color.Black;
            this.ckGuardaTurnos.Location = new System.Drawing.Point(23, 175);
            this.ckGuardaTurnos.Name = "ckGuardaTurnos";
            this.ckGuardaTurnos.Size = new System.Drawing.Size(142, 17);
            this.ckGuardaTurnos.TabIndex = 10;
            this.ckGuardaTurnos.Text = "Guarda/Modifica Turnos";
            this.ckGuardaTurnos.UseVisualStyleBackColor = true;
            // 
            // ckUsuarios
            // 
            this.ckUsuarios.AutoSize = true;
            this.ckUsuarios.ForeColor = System.Drawing.Color.Black;
            this.ckUsuarios.Location = new System.Drawing.Point(5, 3);
            this.ckUsuarios.Name = "ckUsuarios";
            this.ckUsuarios.Size = new System.Drawing.Size(122, 17);
            this.ckUsuarios.TabIndex = 4;
            this.ckUsuarios.Text = "Usuarios del sistema";
            this.ckUsuarios.UseVisualStyleBackColor = true;
            // 
            // ckEmpleados
            // 
            this.ckEmpleados.AutoSize = true;
            this.ckEmpleados.ForeColor = System.Drawing.Color.Black;
            this.ckEmpleados.Location = new System.Drawing.Point(5, 52);
            this.ckEmpleados.Name = "ckEmpleados";
            this.ckEmpleados.Size = new System.Drawing.Size(78, 17);
            this.ckEmpleados.TabIndex = 6;
            this.ckEmpleados.Text = "Empleados";
            this.ckEmpleados.UseVisualStyleBackColor = true;
            // 
            // ckTurnos
            // 
            this.ckTurnos.AutoSize = true;
            this.ckTurnos.ForeColor = System.Drawing.Color.Black;
            this.ckTurnos.Location = new System.Drawing.Point(5, 150);
            this.ckTurnos.Name = "ckTurnos";
            this.ckTurnos.Size = new System.Drawing.Size(59, 17);
            this.ckTurnos.TabIndex = 9;
            this.ckTurnos.Text = "Turnos";
            this.ckTurnos.UseVisualStyleBackColor = true;
            // 
            // tabRemoto
            // 
            this.tabRemoto.Controls.Add(this.ckRemoto);
            this.tabRemoto.Location = new System.Drawing.Point(4, 25);
            this.tabRemoto.Name = "tabRemoto";
            this.tabRemoto.Size = new System.Drawing.Size(467, 314);
            this.tabRemoto.TabIndex = 3;
            this.tabRemoto.Text = "Conexión remota";
            this.tabRemoto.UseVisualStyleBackColor = true;
            // 
            // ckRemoto
            // 
            this.ckRemoto.AutoSize = true;
            this.ckRemoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckRemoto.ForeColor = System.Drawing.Color.Black;
            this.ckRemoto.Location = new System.Drawing.Point(5, 3);
            this.ckRemoto.Name = "ckRemoto";
            this.ckRemoto.Size = new System.Drawing.Size(105, 17);
            this.ckRemoto.TabIndex = 0;
            this.ckRemoto.Text = "Conexión remota";
            this.ckRemoto.UseVisualStyleBackColor = true;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.Black;
            this.txtCorreo.Location = new System.Drawing.Point(573, 29);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(181, 21);
            this.txtCorreo.TabIndex = 5;
            this.txtCorreo.Leave += new System.EventHandler(this.txtCorreo_Leave);
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Location = new System.Drawing.Point(328, 29);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(162, 21);
            this.txtPass.TabIndex = 4;
            this.txtPass.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtUsuario.Location = new System.Drawing.Point(59, 29);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(181, 21);
            this.txtUsuario.TabIndex = 3;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(527, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "E-mail:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.toolStrip1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNuevo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1161, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbNuevo
            // 
            this.tbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbNuevo.Name = "tbNuevo";
            this.tbNuevo.Size = new System.Drawing.Size(52, 22);
            this.tbNuevo.Text = "Nuevo";
            this.tbNuevo.Click += new System.EventHandler(this.tbNuevo_Click);
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1161, 593);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgUsuarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tConfiguraciones.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.tabPrincipal.PerformLayout();
            this.gbNominas.ResumeLayout(false);
            this.gbNominas.PerformLayout();
            this.tabConfiguraciones.ResumeLayout(false);
            this.tabConfiguraciones.PerformLayout();
            this.tabCatalogos.ResumeLayout(false);
            this.tabCatalogos.PerformLayout();
            this.tabRemoto.ResumeLayout(false);
            this.tabRemoto.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.DataGridView dgUsuarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tConfiguraciones;
        private System.Windows.Forms.TabPage tabPrincipal;
        private System.Windows.Forms.TabPage tabConfiguraciones;
        private System.Windows.Forms.CheckBox ckNominas;
        private System.Windows.Forms.CheckBox ckCambioEpmpresa;
        private System.Windows.Forms.CheckBox ckApariencia;
        private System.Windows.Forms.TabPage tabCatalogos;
        private System.Windows.Forms.CheckBox ckEmpleados;
        private System.Windows.Forms.CheckBox ckTurnos;
        private System.Windows.Forms.CheckBox ckUsuarios;
        private System.Windows.Forms.CheckBox ckRespalda;
        private System.Windows.Forms.CheckBox ckGuardaTurnos;
        private System.Windows.Forms.CheckBox ckGuardaUsuarios;
        private System.Windows.Forms.CheckBox ckGuardaEmpleados;
        private System.Windows.Forms.GroupBox gbNominas;
        private System.Windows.Forms.CheckBox ckGuardarMovtos;
        private System.Windows.Forms.CheckBox ckImprimir;
        private System.Windows.Forms.CheckBox ckAutorizar;
        private System.Windows.Forms.CheckBox ckGenerar;
        private System.Windows.Forms.CheckBox ckMovimientos;
        private System.Windows.Forms.CheckBox ckGuardaSucursales;
        private System.Windows.Forms.CheckBox ckSucursales;
        private System.Windows.Forms.TabPage tabRemoto;
        private System.Windows.Forms.CheckBox ckRemoto;
        private System.Windows.Forms.CheckBox chkDetalleTurnos;
        private System.Windows.Forms.CheckBox ckImprimirId;
        private System.Windows.Forms.CheckBox chkExcelEmpleados;
        private System.Windows.Forms.CheckBox ckGuardaAreas;
        private System.Windows.Forms.CheckBox ckAreas;
        private System.Windows.Forms.CheckBox ckAgregaAreas;
    }
}