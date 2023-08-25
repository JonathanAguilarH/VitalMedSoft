namespace VitalLabSoft
{
    partial class frmSucursales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSucursales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.tbBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.infoGridSucursales = new System.Windows.Forms.DataGridView();
            this.btnNuevoPaquete = new System.Windows.Forms.Button();
            this.txtNuevoPaquete = new System.Windows.Forms.TextBox();
            this.gbGridSucursal = new System.Windows.Forms.GroupBox();
            this.gbInfoSucursal = new System.Windows.Forms.GroupBox();
            this.ckbRemoto = new System.Windows.Forms.CheckBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.lblRFC = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.pbLogoSucursal = new System.Windows.Forms.PictureBox();
            this.lblLogo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblDNS = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombreSucursal = new System.Windows.Forms.TextBox();
            this.Abrir = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoGridSucursales)).BeginInit();
            this.gbGridSucursal.SuspendLayout();
            this.gbInfoSucursal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoSucursal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCerrar,
            this.tbBtnNuevo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1000, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
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
            // 
            // tbBtnNuevo
            // 
            this.tbBtnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbBtnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tbBtnNuevo.Image")));
            this.tbBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBtnNuevo.Name = "tbBtnNuevo";
            this.tbBtnNuevo.Size = new System.Drawing.Size(56, 22);
            this.tbBtnNuevo.Text = "Nueva";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnEliminar.Location = new System.Drawing.Point(893, 178);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 29;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnAgregar.Location = new System.Drawing.Point(812, 178);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 28;
            this.btnAgregar.Text = "Guardar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // infoGridSucursales
            // 
            this.infoGridSucursales.AllowUserToAddRows = false;
            this.infoGridSucursales.AllowUserToDeleteRows = false;
            this.infoGridSucursales.AllowUserToResizeRows = false;
            this.infoGridSucursales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoGridSucursales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.infoGridSucursales.BackgroundColor = System.Drawing.Color.White;
            this.infoGridSucursales.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.infoGridSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(78)))), ((int)(((byte)(106)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.infoGridSucursales.DefaultCellStyle = dataGridViewCellStyle2;
            this.infoGridSucursales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(78)))), ((int)(((byte)(106)))));
            this.infoGridSucursales.Location = new System.Drawing.Point(8, 23);
            this.infoGridSucursales.Margin = new System.Windows.Forms.Padding(5);
            this.infoGridSucursales.Name = "infoGridSucursales";
            this.infoGridSucursales.ReadOnly = true;
            this.infoGridSucursales.RowHeadersVisible = false;
            this.infoGridSucursales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.infoGridSucursales.Size = new System.Drawing.Size(960, 313);
            this.infoGridSucursales.TabIndex = 42;
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
            // gbGridSucursal
            // 
            this.gbGridSucursal.Controls.Add(this.infoGridSucursales);
            this.gbGridSucursal.ForeColor = System.Drawing.Color.White;
            this.gbGridSucursal.Location = new System.Drawing.Point(12, 252);
            this.gbGridSucursal.Name = "gbGridSucursal";
            this.gbGridSucursal.Size = new System.Drawing.Size(976, 344);
            this.gbGridSucursal.TabIndex = 43;
            this.gbGridSucursal.TabStop = false;
            this.gbGridSucursal.Text = "Sucursales existentes";
            // 
            // gbInfoSucursal
            // 
            this.gbInfoSucursal.Controls.Add(this.ckbRemoto);
            this.gbInfoSucursal.Controls.Add(this.lblTelefono);
            this.gbInfoSucursal.Controls.Add(this.textBox7);
            this.gbInfoSucursal.Controls.Add(this.lblRFC);
            this.gbInfoSucursal.Controls.Add(this.textBox1);
            this.gbInfoSucursal.Controls.Add(this.lblDireccion);
            this.gbInfoSucursal.Controls.Add(this.textBox6);
            this.gbInfoSucursal.Controls.Add(this.pbLogoSucursal);
            this.gbInfoSucursal.Controls.Add(this.lblLogo);
            this.gbInfoSucursal.Controls.Add(this.groupBox1);
            this.gbInfoSucursal.Controls.Add(this.lblNombre);
            this.gbInfoSucursal.Controls.Add(this.txtNombreSucursal);
            this.gbInfoSucursal.Controls.Add(this.btnAgregar);
            this.gbInfoSucursal.Controls.Add(this.btnEliminar);
            this.gbInfoSucursal.ForeColor = System.Drawing.Color.White;
            this.gbInfoSucursal.Location = new System.Drawing.Point(12, 39);
            this.gbInfoSucursal.Name = "gbInfoSucursal";
            this.gbInfoSucursal.Size = new System.Drawing.Size(976, 207);
            this.gbInfoSucursal.TabIndex = 44;
            this.gbInfoSucursal.TabStop = false;
            this.gbInfoSucursal.Text = "Información de Sucursal";
            // 
            // ckbRemoto
            // 
            this.ckbRemoto.AutoSize = true;
            this.ckbRemoto.Location = new System.Drawing.Point(767, 76);
            this.ckbRemoto.Name = "ckbRemoto";
            this.ckbRemoto.Size = new System.Drawing.Size(179, 19);
            this.ckbRemoto.TabIndex = 54;
            this.ckbRemoto.Text = "Activar conexión remota";
            this.ckbRemoto.UseVisualStyleBackColor = true;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(727, 37);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(67, 15);
            this.lblTelefono.TabIndex = 53;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // textBox7
            // 
            this.textBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.textBox7.Location = new System.Drawing.Point(795, 34);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(160, 21);
            this.textBox7.TabIndex = 52;
            // 
            // lblRFC
            // 
            this.lblRFC.AutoSize = true;
            this.lblRFC.Location = new System.Drawing.Point(554, 37);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(38, 15);
            this.lblRFC.TabIndex = 51;
            this.lblRFC.Text = "RFC:";
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.textBox1.Location = new System.Drawing.Point(593, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 21);
            this.textBox1.TabIndex = 50;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(177, 77);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(72, 15);
            this.lblDireccion.TabIndex = 49;
            this.lblDireccion.Text = "Dirección:";
            // 
            // textBox6
            // 
            this.textBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.textBox6.Location = new System.Drawing.Point(251, 74);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(498, 21);
            this.textBox6.TabIndex = 48;
            // 
            // pbLogoSucursal
            // 
            this.pbLogoSucursal.Location = new System.Drawing.Point(59, 28);
            this.pbLogoSucursal.Name = "pbLogoSucursal";
            this.pbLogoSucursal.Size = new System.Drawing.Size(91, 77);
            this.pbLogoSucursal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoSucursal.TabIndex = 47;
            this.pbLogoSucursal.TabStop = false;
            this.pbLogoSucursal.Click += new System.EventHandler(this.pbLogoSucursal_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Location = new System.Drawing.Point(16, 28);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(39, 15);
            this.lblLogo.TabIndex = 46;
            this.lblLogo.Text = "Logo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPass);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.lblUsuario);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.lblPuerto);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.lblDNS);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(19, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(935, 61);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de conexión remota";
            this.groupBox1.Visible = false;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(665, 24);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(80, 15);
            this.lblPass.TabIndex = 37;
            this.lblPass.Text = "Contraseña";
            // 
            // textBox5
            // 
            this.textBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.textBox5.Location = new System.Drawing.Point(746, 21);
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '*';
            this.textBox5.Size = new System.Drawing.Size(169, 21);
            this.textBox5.TabIndex = 36;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(394, 24);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(61, 15);
            this.lblUsuario.TabIndex = 35;
            this.lblUsuario.Text = "Usuario:";
            // 
            // textBox4
            // 
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.textBox4.Location = new System.Drawing.Point(454, 21);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(192, 21);
            this.textBox4.TabIndex = 34;
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Location = new System.Drawing.Point(263, 24);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(53, 15);
            this.lblPuerto.TabIndex = 33;
            this.lblPuerto.Text = "Puerto:";
            // 
            // textBox3
            // 
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.textBox3.Location = new System.Drawing.Point(317, 21);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(59, 21);
            this.textBox3.TabIndex = 32;
            // 
            // lblDNS
            // 
            this.lblDNS.AutoSize = true;
            this.lblDNS.Location = new System.Drawing.Point(14, 24);
            this.lblDNS.Name = "lblDNS";
            this.lblDNS.Size = new System.Drawing.Size(40, 15);
            this.lblDNS.TabIndex = 31;
            this.lblDNS.Text = "DNS:";
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.textBox2.Location = new System.Drawing.Point(54, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(192, 21);
            this.textBox2.TabIndex = 30;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(156, 37);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(140, 15);
            this.lblNombre.TabIndex = 31;
            this.lblNombre.Text = "Nombre de sucursal:";
            // 
            // txtNombreSucursal
            // 
            this.txtNombreSucursal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.txtNombreSucursal.Location = new System.Drawing.Point(302, 34);
            this.txtNombreSucursal.Name = "txtNombreSucursal";
            this.txtNombreSucursal.Size = new System.Drawing.Size(234, 21);
            this.txtNombreSucursal.TabIndex = 30;
            // 
            // Abrir
            // 
            this.Abrir.FileName = "openFileDialog1";
            // 
            // frmSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1000, 608);
            this.Controls.Add(this.gbInfoSucursal);
            this.Controls.Add(this.gbGridSucursal);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmSucursales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmSucursales_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoGridSucursales)).EndInit();
            this.gbGridSucursal.ResumeLayout(false);
            this.gbInfoSucursal.ResumeLayout(false);
            this.gbInfoSucursal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoSucursal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView infoGridSucursales;
        private System.Windows.Forms.ToolStripButton btnCerrar;
        private System.Windows.Forms.Button btnNuevoPaquete;
        private System.Windows.Forms.TextBox txtNuevoPaquete;
        private System.Windows.Forms.GroupBox gbGridSucursal;
        private System.Windows.Forms.ToolStripButton tbBtnNuevo;
        private System.Windows.Forms.GroupBox gbInfoSucursal;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombreSucursal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDNS;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pbLogoSucursal;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.CheckBox ckbRemoto;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label lblRFC;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog Abrir;
    }
}