namespace VitalLabSoft
{
    partial class frmRelojChecador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelojChecador));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.PanelRelojChecador = new System.Windows.Forms.Panel();
            this.gbPanelInformacion = new System.Windows.Forms.GroupBox();
            this.gbImagen = new System.Windows.Forms.GroupBox();
            this.pbEmpleado = new System.Windows.Forms.PictureBox();
            this.gbInfoAsistencias = new System.Windows.Forms.GroupBox();
            this.lblRetardos = new System.Windows.Forms.Label();
            this.lblFaltas = new System.Windows.Forms.Label();
            this.gbBasico = new System.Windows.Forms.GroupBox();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbHuellaDigital = new System.Windows.Forms.GroupBox();
            this.lblInfoLector = new System.Windows.Forms.Label();
            this.pbHuella = new System.Windows.Forms.PictureBox();
            this.lHora = new System.Windows.Forms.Label();
            this.reloj = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.PanelRelojChecador.SuspendLayout();
            this.gbPanelInformacion.SuspendLayout();
            this.gbImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpleado)).BeginInit();
            this.gbInfoAsistencias.SuspendLayout();
            this.gbBasico.SuspendLayout();
            this.gbHuellaDigital.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.toolStrip1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1920, 25);
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
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PanelRelojChecador
            // 
            this.PanelRelojChecador.Controls.Add(this.gbPanelInformacion);
            this.PanelRelojChecador.Controls.Add(this.gbHuellaDigital);
            this.PanelRelojChecador.Controls.Add(this.lHora);
            this.PanelRelojChecador.ForeColor = System.Drawing.Color.White;
            this.PanelRelojChecador.Location = new System.Drawing.Point(0, 25);
            this.PanelRelojChecador.Name = "PanelRelojChecador";
            this.PanelRelojChecador.Size = new System.Drawing.Size(1920, 751);
            this.PanelRelojChecador.TabIndex = 58;
            // 
            // gbPanelInformacion
            // 
            this.gbPanelInformacion.Controls.Add(this.gbImagen);
            this.gbPanelInformacion.Controls.Add(this.gbInfoAsistencias);
            this.gbPanelInformacion.Controls.Add(this.gbBasico);
            this.gbPanelInformacion.ForeColor = System.Drawing.Color.White;
            this.gbPanelInformacion.Location = new System.Drawing.Point(330, 245);
            this.gbPanelInformacion.Name = "gbPanelInformacion";
            this.gbPanelInformacion.Size = new System.Drawing.Size(1578, 496);
            this.gbPanelInformacion.TabIndex = 4;
            this.gbPanelInformacion.TabStop = false;
            this.gbPanelInformacion.Text = "Información general";
            // 
            // gbImagen
            // 
            this.gbImagen.Controls.Add(this.pbEmpleado);
            this.gbImagen.ForeColor = System.Drawing.Color.White;
            this.gbImagen.Location = new System.Drawing.Point(6, 23);
            this.gbImagen.Name = "gbImagen";
            this.gbImagen.Size = new System.Drawing.Size(371, 467);
            this.gbImagen.TabIndex = 2;
            this.gbImagen.TabStop = false;
            this.gbImagen.Text = "Imagen del trabajador";
            // 
            // pbEmpleado
            // 
            this.pbEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbEmpleado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbEmpleado.Location = new System.Drawing.Point(3, 18);
            this.pbEmpleado.Name = "pbEmpleado";
            this.pbEmpleado.Size = new System.Drawing.Size(365, 446);
            this.pbEmpleado.TabIndex = 43;
            this.pbEmpleado.TabStop = false;
            // 
            // gbInfoAsistencias
            // 
            this.gbInfoAsistencias.Controls.Add(this.lblRetardos);
            this.gbInfoAsistencias.Controls.Add(this.lblFaltas);
            this.gbInfoAsistencias.ForeColor = System.Drawing.Color.White;
            this.gbInfoAsistencias.Location = new System.Drawing.Point(383, 235);
            this.gbInfoAsistencias.Name = "gbInfoAsistencias";
            this.gbInfoAsistencias.Size = new System.Drawing.Size(1183, 255);
            this.gbInfoAsistencias.TabIndex = 1;
            this.gbInfoAsistencias.TabStop = false;
            this.gbInfoAsistencias.Text = "Información de asistencias";
            // 
            // lblRetardos
            // 
            this.lblRetardos.AutoSize = true;
            this.lblRetardos.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetardos.Location = new System.Drawing.Point(27, 146);
            this.lblRetardos.Name = "lblRetardos";
            this.lblRetardos.Size = new System.Drawing.Size(185, 44);
            this.lblRetardos.TabIndex = 1;
            this.lblRetardos.Text = "Retardos:";
            this.lblRetardos.Visible = false;
            // 
            // lblFaltas
            // 
            this.lblFaltas.AutoSize = true;
            this.lblFaltas.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaltas.Location = new System.Drawing.Point(27, 54);
            this.lblFaltas.Name = "lblFaltas";
            this.lblFaltas.Size = new System.Drawing.Size(141, 44);
            this.lblFaltas.TabIndex = 0;
            this.lblFaltas.Text = "Faltas: ";
            this.lblFaltas.Visible = false;
            // 
            // gbBasico
            // 
            this.gbBasico.Controls.Add(this.lblPuesto);
            this.gbBasico.Controls.Add(this.lblTitulo);
            this.gbBasico.Controls.Add(this.lblNombre);
            this.gbBasico.ForeColor = System.Drawing.Color.White;
            this.gbBasico.Location = new System.Drawing.Point(383, 23);
            this.gbBasico.Name = "gbBasico";
            this.gbBasico.Size = new System.Drawing.Size(1183, 206);
            this.gbBasico.TabIndex = 0;
            this.gbBasico.TabStop = false;
            this.gbBasico.Text = "Información básica";
            // 
            // lblPuesto
            // 
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.BackColor = System.Drawing.Color.Transparent;
            this.lblPuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuesto.ForeColor = System.Drawing.Color.White;
            this.lblPuesto.Location = new System.Drawing.Point(9, 143);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(0, 55);
            this.lblPuesto.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(13, 102);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 31);
            this.lblTitulo.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(6, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 73);
            this.lblNombre.TabIndex = 0;
            // 
            // gbHuellaDigital
            // 
            this.gbHuellaDigital.Controls.Add(this.lblInfoLector);
            this.gbHuellaDigital.Controls.Add(this.pbHuella);
            this.gbHuellaDigital.ForeColor = System.Drawing.Color.White;
            this.gbHuellaDigital.Location = new System.Drawing.Point(12, 245);
            this.gbHuellaDigital.Name = "gbHuellaDigital";
            this.gbHuellaDigital.Size = new System.Drawing.Size(312, 496);
            this.gbHuellaDigital.TabIndex = 3;
            this.gbHuellaDigital.TabStop = false;
            this.gbHuellaDigital.Text = "Huella digital";
            // 
            // lblInfoLector
            // 
            this.lblInfoLector.ForeColor = System.Drawing.Color.White;
            this.lblInfoLector.Location = new System.Drawing.Point(6, 428);
            this.lblInfoLector.Name = "lblInfoLector";
            this.lblInfoLector.Size = new System.Drawing.Size(291, 56);
            this.lblInfoLector.TabIndex = 42;
            // 
            // pbHuella
            // 
            this.pbHuella.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbHuella.Location = new System.Drawing.Point(6, 23);
            this.pbHuella.Name = "pbHuella";
            this.pbHuella.Size = new System.Drawing.Size(300, 402);
            this.pbHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHuella.TabIndex = 41;
            this.pbHuella.TabStop = false;
            // 
            // lHora
            // 
            this.lHora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lHora.BackColor = System.Drawing.Color.Transparent;
            this.lHora.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Bold);
            this.lHora.Location = new System.Drawing.Point(12, 22);
            this.lHora.Name = "lHora";
            this.lHora.Size = new System.Drawing.Size(1896, 220);
            this.lHora.TabIndex = 1;
            this.lHora.Text = "00:00:00 A.M.";
            this.lHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reloj
            // 
            this.reloj.Interval = 1000;
            this.reloj.Tick += new System.EventHandler(this.reloj_Tick);
            // 
            // frmRelojChecador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1920, 785);
            this.Controls.Add(this.PanelRelojChecador);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmRelojChecador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmRelojChecador_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.PanelRelojChecador.ResumeLayout(false);
            this.gbPanelInformacion.ResumeLayout(false);
            this.gbImagen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpleado)).EndInit();
            this.gbInfoAsistencias.ResumeLayout(false);
            this.gbInfoAsistencias.PerformLayout();
            this.gbBasico.ResumeLayout(false);
            this.gbBasico.PerformLayout();
            this.gbHuellaDigital.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCerrar;
        private System.Windows.Forms.Panel PanelRelojChecador;
        private System.Windows.Forms.GroupBox gbPanelInformacion;
        private System.Windows.Forms.PictureBox pbEmpleado;
        private System.Windows.Forms.GroupBox gbInfoAsistencias;
        private System.Windows.Forms.GroupBox gbBasico;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox gbHuellaDigital;
        private System.Windows.Forms.Label lblInfoLector;
        private System.Windows.Forms.PictureBox pbHuella;
        private System.Windows.Forms.Label lHora;
        private System.Windows.Forms.Timer reloj;
        private System.Windows.Forms.GroupBox gbImagen;
        private System.Windows.Forms.Label lblRetardos;
        private System.Windows.Forms.Label lblFaltas;
    }
}