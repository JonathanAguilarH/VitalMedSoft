
namespace VitalLabSoft
{
    partial class frmIncidenciaChecador
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbEmpleado = new System.Windows.Forms.PictureBox();
            this.gbInformacionPersonal = new System.Windows.Forms.GroupBox();
            this.gbTipoNómina = new System.Windows.Forms.GroupBox();
            this.nSueldoHora = new System.Windows.Forms.NumericUpDown();
            this.nSueldoTurno = new System.Windows.Forms.NumericUpDown();
            this.lblSignoPesos1 = new System.Windows.Forms.Label();
            this.lblSignoPeso = new System.Windows.Forms.Label();
            this.ckTurno = new System.Windows.Forms.CheckBox();
            this.ckHora = new System.Windows.Forms.CheckBox();
            this.lblAntiguedad = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtAntiguedad = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtPuesto = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.gbClientes = new System.Windows.Forms.GroupBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.dgEmpleados = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbActualiza = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblidDireccion = new System.Windows.Forms.Label();
            this.gbPeriodos = new System.Windows.Forms.GroupBox();
            this.rbMensual = new System.Windows.Forms.RadioButton();
            this.rbQuincenal = new System.Windows.Forms.RadioButton();
            this.rbSemanal = new System.Windows.Forms.RadioButton();
            this.cmPeriodos = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpleado)).BeginInit();
            this.gbInformacionPersonal.SuspendLayout();
            this.gbTipoNómina.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSueldoHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSueldoTurno)).BeginInit();
            this.gbClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpleados)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.gbPeriodos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbEmpleado);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(375, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 271);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Foto empleado";
            // 
            // pbEmpleado
            // 
            this.pbEmpleado.ErrorImage = global::VitalLabSoft.Properties.Resources.Sin_imagen;
            this.pbEmpleado.Image = global::VitalLabSoft.Properties.Resources.Sin_imagen;
            this.pbEmpleado.Location = new System.Drawing.Point(5, 20);
            this.pbEmpleado.Name = "pbEmpleado";
            this.pbEmpleado.Size = new System.Drawing.Size(200, 245);
            this.pbEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmpleado.TabIndex = 35;
            this.pbEmpleado.TabStop = false;
            // 
            // gbInformacionPersonal
            // 
            this.gbInformacionPersonal.Controls.Add(this.gbTipoNómina);
            this.gbInformacionPersonal.Controls.Add(this.lblAntiguedad);
            this.gbInformacionPersonal.Controls.Add(this.lblNombre);
            this.gbInformacionPersonal.Controls.Add(this.txtAntiguedad);
            this.gbInformacionPersonal.Controls.Add(this.lblTitulo);
            this.gbInformacionPersonal.Controls.Add(this.label2);
            this.gbInformacionPersonal.Controls.Add(this.txtTitulo);
            this.gbInformacionPersonal.Controls.Add(this.txtPuesto);
            this.gbInformacionPersonal.Controls.Add(this.txtNombres);
            this.gbInformacionPersonal.ForeColor = System.Drawing.Color.White;
            this.gbInformacionPersonal.Location = new System.Drawing.Point(592, 135);
            this.gbInformacionPersonal.Name = "gbInformacionPersonal";
            this.gbInformacionPersonal.Size = new System.Drawing.Size(971, 107);
            this.gbInformacionPersonal.TabIndex = 4;
            this.gbInformacionPersonal.TabStop = false;
            this.gbInformacionPersonal.Text = "Información personal";
            // 
            // gbTipoNómina
            // 
            this.gbTipoNómina.BackColor = System.Drawing.Color.White;
            this.gbTipoNómina.Controls.Add(this.nSueldoHora);
            this.gbTipoNómina.Controls.Add(this.nSueldoTurno);
            this.gbTipoNómina.Controls.Add(this.lblSignoPesos1);
            this.gbTipoNómina.Controls.Add(this.lblSignoPeso);
            this.gbTipoNómina.Controls.Add(this.ckTurno);
            this.gbTipoNómina.Controls.Add(this.ckHora);
            this.gbTipoNómina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.gbTipoNómina.Location = new System.Drawing.Point(662, 17);
            this.gbTipoNómina.Name = "gbTipoNómina";
            this.gbTipoNómina.Size = new System.Drawing.Size(296, 77);
            this.gbTipoNómina.TabIndex = 18;
            this.gbTipoNómina.TabStop = false;
            this.gbTipoNómina.Text = "Datos de nómina";
            // 
            // nSueldoHora
            // 
            this.nSueldoHora.DecimalPlaces = 2;
            this.nSueldoHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.nSueldoHora.Location = new System.Drawing.Point(180, 47);
            this.nSueldoHora.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nSueldoHora.Name = "nSueldoHora";
            this.nSueldoHora.Size = new System.Drawing.Size(100, 21);
            this.nSueldoHora.TabIndex = 4;
            this.nSueldoHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nSueldoHora.ThousandsSeparator = true;
            this.nSueldoHora.Visible = false;
            // 
            // nSueldoTurno
            // 
            this.nSueldoTurno.DecimalPlaces = 2;
            this.nSueldoTurno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.nSueldoTurno.Location = new System.Drawing.Point(180, 20);
            this.nSueldoTurno.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nSueldoTurno.Name = "nSueldoTurno";
            this.nSueldoTurno.Size = new System.Drawing.Size(100, 21);
            this.nSueldoTurno.TabIndex = 2;
            this.nSueldoTurno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nSueldoTurno.ThousandsSeparator = true;
            this.nSueldoTurno.Visible = false;
            // 
            // lblSignoPesos1
            // 
            this.lblSignoPesos1.AutoSize = true;
            this.lblSignoPesos1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignoPesos1.Location = new System.Drawing.Point(159, 50);
            this.lblSignoPesos1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSignoPesos1.Name = "lblSignoPesos1";
            this.lblSignoPesos1.Size = new System.Drawing.Size(15, 15);
            this.lblSignoPesos1.TabIndex = 36;
            this.lblSignoPesos1.Text = "$";
            this.lblSignoPesos1.Visible = false;
            // 
            // lblSignoPeso
            // 
            this.lblSignoPeso.AutoSize = true;
            this.lblSignoPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignoPeso.Location = new System.Drawing.Point(159, 23);
            this.lblSignoPeso.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSignoPeso.Name = "lblSignoPeso";
            this.lblSignoPeso.Size = new System.Drawing.Size(15, 15);
            this.lblSignoPeso.TabIndex = 35;
            this.lblSignoPeso.Text = "$";
            this.lblSignoPeso.Visible = false;
            // 
            // ckTurno
            // 
            this.ckTurno.AutoSize = true;
            this.ckTurno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.ckTurno.Location = new System.Drawing.Point(17, 22);
            this.ckTurno.Name = "ckTurno";
            this.ckTurno.Size = new System.Drawing.Size(121, 19);
            this.ckTurno.TabIndex = 1;
            this.ckTurno.Text = "Pago por turno";
            this.ckTurno.UseVisualStyleBackColor = true;
            this.ckTurno.CheckedChanged += new System.EventHandler(this.ckTurno_CheckedChanged);
            // 
            // ckHora
            // 
            this.ckHora.AutoSize = true;
            this.ckHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.ckHora.Location = new System.Drawing.Point(17, 49);
            this.ckHora.Name = "ckHora";
            this.ckHora.Size = new System.Drawing.Size(117, 19);
            this.ckHora.TabIndex = 3;
            this.ckHora.Text = "Pago por hora";
            this.ckHora.UseVisualStyleBackColor = true;
            this.ckHora.CheckedChanged += new System.EventHandler(this.ckHora_CheckedChanged);
            // 
            // lblAntiguedad
            // 
            this.lblAntiguedad.AutoSize = true;
            this.lblAntiguedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAntiguedad.ForeColor = System.Drawing.Color.White;
            this.lblAntiguedad.Location = new System.Drawing.Point(345, 77);
            this.lblAntiguedad.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAntiguedad.Name = "lblAntiguedad";
            this.lblAntiguedad.Size = new System.Drawing.Size(83, 15);
            this.lblAntiguedad.TabIndex = 16;
            this.lblAntiguedad.Text = "Antigüedad:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(8, 24);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtAntiguedad
            // 
            this.txtAntiguedad.Enabled = false;
            this.txtAntiguedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAntiguedad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtAntiguedad.Location = new System.Drawing.Point(437, 74);
            this.txtAntiguedad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAntiguedad.Name = "txtAntiguedad";
            this.txtAntiguedad.Size = new System.Drawing.Size(218, 21);
            this.txtAntiguedad.TabIndex = 17;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(23, 50);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(47, 15);
            this.lblTitulo.TabIndex = 15;
            this.lblTitulo.Text = "Título:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Área / Puesto:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Enabled = false;
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtTitulo.Location = new System.Drawing.Point(79, 47);
            this.txtTitulo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(576, 21);
            this.txtTitulo.TabIndex = 10;
            // 
            // txtPuesto
            // 
            this.txtPuesto.Enabled = false;
            this.txtPuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuesto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtPuesto.Location = new System.Drawing.Point(112, 74);
            this.txtPuesto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPuesto.MaxLength = 50;
            this.txtPuesto.Name = "txtPuesto";
            this.txtPuesto.Size = new System.Drawing.Size(217, 21);
            this.txtPuesto.TabIndex = 4;
            // 
            // txtNombres
            // 
            this.txtNombres.Enabled = false;
            this.txtNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtNombres.Location = new System.Drawing.Point(79, 20);
            this.txtNombres.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(576, 21);
            this.txtNombres.TabIndex = 1;
            // 
            // gbClientes
            // 
            this.gbClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbClientes.Controls.Add(this.lblBuscar);
            this.gbClientes.Controls.Add(this.txtBuscador);
            this.gbClientes.Controls.Add(this.dgEmpleados);
            this.gbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbClientes.ForeColor = System.Drawing.Color.White;
            this.gbClientes.Location = new System.Drawing.Point(13, 135);
            this.gbClientes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbClientes.Name = "gbClientes";
            this.gbClientes.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbClientes.Size = new System.Drawing.Size(355, 787);
            this.gbClientes.TabIndex = 1;
            this.gbClientes.TabStop = false;
            this.gbClientes.Text = "Listado de empleados";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(9, 17);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(67, 15);
            this.lblBuscar.TabIndex = 13;
            this.lblBuscar.Text = "Buscador";
            // 
            // txtBuscador
            // 
            this.txtBuscador.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(78)))), ((int)(((byte)(106)))));
            this.txtBuscador.Location = new System.Drawing.Point(8, 35);
            this.txtBuscador.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(339, 22);
            this.txtBuscador.TabIndex = 1;
            // 
            // dgEmpleados
            // 
            this.dgEmpleados.AllowUserToAddRows = false;
            this.dgEmpleados.AllowUserToDeleteRows = false;
            this.dgEmpleados.AllowUserToResizeRows = false;
            this.dgEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgEmpleados.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgEmpleados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgEmpleados.Location = new System.Drawing.Point(4, 63);
            this.dgEmpleados.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgEmpleados.MultiSelect = false;
            this.dgEmpleados.Name = "dgEmpleados";
            this.dgEmpleados.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEmpleados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgEmpleados.RowHeadersVisible = false;
            this.dgEmpleados.RowHeadersWidth = 82;
            this.dgEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEmpleados.Size = new System.Drawing.Size(347, 718);
            this.dgEmpleados.TabIndex = 2;
            this.dgEmpleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmpleados_CellContentClick);
            this.dgEmpleados.SelectionChanged += new System.EventHandler(this.dgClientes_SelectionChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancelar.Location = new System.Drawing.Point(1445, 894);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 28);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGuardar.Location = new System.Drawing.Point(1320, 894);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 28);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.toolStrip1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbActualiza,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1575, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbActualiza
            // 
            this.tbActualiza.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbActualiza.Name = "tbActualiza";
            this.tbActualiza.Size = new System.Drawing.Size(115, 22);
            this.tbActualiza.Text = "Recarga listado";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblidDireccion
            // 
            this.lblidDireccion.AutoSize = true;
            this.lblidDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidDireccion.Location = new System.Drawing.Point(1044, 37);
            this.lblidDireccion.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblidDireccion.Name = "lblidDireccion";
            this.lblidDireccion.Size = new System.Drawing.Size(0, 15);
            this.lblidDireccion.TabIndex = 25;
            this.lblidDireccion.Visible = false;
            // 
            // gbPeriodos
            // 
            this.gbPeriodos.Controls.Add(this.rbMensual);
            this.gbPeriodos.Controls.Add(this.rbQuincenal);
            this.gbPeriodos.Controls.Add(this.rbSemanal);
            this.gbPeriodos.Controls.Add(this.cmPeriodos);
            this.gbPeriodos.ForeColor = System.Drawing.Color.White;
            this.gbPeriodos.Location = new System.Drawing.Point(13, 37);
            this.gbPeriodos.Name = "gbPeriodos";
            this.gbPeriodos.Size = new System.Drawing.Size(1550, 92);
            this.gbPeriodos.TabIndex = 26;
            this.gbPeriodos.TabStop = false;
            this.gbPeriodos.Text = "Selecciona período";
            // 
            // rbMensual
            // 
            this.rbMensual.AutoSize = true;
            this.rbMensual.Location = new System.Drawing.Point(201, 20);
            this.rbMensual.Name = "rbMensual";
            this.rbMensual.Size = new System.Drawing.Size(80, 19);
            this.rbMensual.TabIndex = 6;
            this.rbMensual.Text = "Mensual";
            this.rbMensual.UseVisualStyleBackColor = true;
            this.rbMensual.CheckedChanged += new System.EventHandler(this.rbMensual_CheckedChanged);
            // 
            // rbQuincenal
            // 
            this.rbQuincenal.AutoSize = true;
            this.rbQuincenal.Checked = true;
            this.rbQuincenal.Location = new System.Drawing.Point(105, 20);
            this.rbQuincenal.Name = "rbQuincenal";
            this.rbQuincenal.Size = new System.Drawing.Size(90, 19);
            this.rbQuincenal.TabIndex = 5;
            this.rbQuincenal.TabStop = true;
            this.rbQuincenal.Text = "Quincenal";
            this.rbQuincenal.UseVisualStyleBackColor = true;
            this.rbQuincenal.CheckedChanged += new System.EventHandler(this.rbQuincenal_CheckedChanged);
            // 
            // rbSemanal
            // 
            this.rbSemanal.AutoSize = true;
            this.rbSemanal.Location = new System.Drawing.Point(14, 20);
            this.rbSemanal.Name = "rbSemanal";
            this.rbSemanal.Size = new System.Drawing.Size(82, 19);
            this.rbSemanal.TabIndex = 4;
            this.rbSemanal.Text = "Semanal";
            this.rbSemanal.UseVisualStyleBackColor = true;
            this.rbSemanal.CheckedChanged += new System.EventHandler(this.rbSemanal_CheckedChanged);
            // 
            // cmPeriodos
            // 
            this.cmPeriodos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmPeriodos.DisplayMember = "(ningunos)";
            this.cmPeriodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmPeriodos.FormattingEnabled = true;
            this.cmPeriodos.Location = new System.Drawing.Point(14, 52);
            this.cmPeriodos.Name = "cmPeriodos";
            this.cmPeriodos.Size = new System.Drawing.Size(1524, 23);
            this.cmPeriodos.TabIndex = 3;
            // 
            // frmIncidenciaChecador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1575, 934);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbPeriodos);
            this.Controls.Add(this.gbInformacionPersonal);
            this.Controls.Add(this.lblidDireccion);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbClientes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmIncidenciaChecador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmClientes";
            this.Load += new System.EventHandler(this.frmConfiguracionNomina_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpleado)).EndInit();
            this.gbInformacionPersonal.ResumeLayout(false);
            this.gbInformacionPersonal.PerformLayout();
            this.gbTipoNómina.ResumeLayout(false);
            this.gbTipoNómina.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSueldoHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSueldoTurno)).EndInit();
            this.gbClientes.ResumeLayout(false);
            this.gbClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpleados)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbPeriodos.ResumeLayout(false);
            this.gbPeriodos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox gbClientes;
        private System.Windows.Forms.DataGridView dgEmpleados;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbActualiza;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.TextBox txtPuesto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblidDireccion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.PictureBox pbEmpleado;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbInformacionPersonal;
        private System.Windows.Forms.GroupBox gbPeriodos;
        private System.Windows.Forms.Label lblAntiguedad;
        private System.Windows.Forms.TextBox txtAntiguedad;
        private System.Windows.Forms.ComboBox cmPeriodos;
        private System.Windows.Forms.RadioButton rbMensual;
        private System.Windows.Forms.RadioButton rbQuincenal;
        private System.Windows.Forms.RadioButton rbSemanal;
        private System.Windows.Forms.GroupBox gbTipoNómina;
        private System.Windows.Forms.NumericUpDown nSueldoHora;
        private System.Windows.Forms.NumericUpDown nSueldoTurno;
        private System.Windows.Forms.Label lblSignoPesos1;
        private System.Windows.Forms.Label lblSignoPeso;
        private System.Windows.Forms.CheckBox ckTurno;
        private System.Windows.Forms.CheckBox ckHora;
    }
}