namespace VitalLabSoft
{
    partial class frmCargaDesdeExcel
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.btnNuevoPaquete = new System.Windows.Forms.Button();
            this.txtNuevoPaquete = new System.Windows.Forms.TextBox();
            this.Abrir = new System.Windows.Forms.OpenFileDialog();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbCargaExcel = new System.Windows.Forms.GroupBox();
            this.btnEliminaTodo = new System.Windows.Forms.Button();
            this.gbVistaPrevia = new System.Windows.Forms.GroupBox();
            this.gbProgreso = new System.Windows.Forms.GroupBox();
            this.pbGuardado = new System.Windows.Forms.ProgressBar();
            this.dgVistaPrevia = new System.Windows.Forms.DataGridView();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCargaExcel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.gbCargaExcel.SuspendLayout();
            this.gbVistaPrevia.SuspendLayout();
            this.gbProgreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaPrevia)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(1093, 25);
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
            // Abrir
            // 
            this.Abrir.FileName = "openFileDialog1";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnCancelar.Location = new System.Drawing.Point(631, 558);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(159, 39);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Enabled = false;
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnGuardar.Location = new System.Drawing.Point(233, 558);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(159, 39);
            this.btnGuardar.TabIndex = 28;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbCargaExcel
            // 
            this.gbCargaExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCargaExcel.Controls.Add(this.btnEliminaTodo);
            this.gbCargaExcel.Controls.Add(this.btnCancelar);
            this.gbCargaExcel.Controls.Add(this.gbVistaPrevia);
            this.gbCargaExcel.Controls.Add(this.lblInfo);
            this.gbCargaExcel.Controls.Add(this.btnCargaExcel);
            this.gbCargaExcel.Controls.Add(this.button1);
            this.gbCargaExcel.Controls.Add(this.btnGuardar);
            this.gbCargaExcel.ForeColor = System.Drawing.Color.White;
            this.gbCargaExcel.Location = new System.Drawing.Point(12, 39);
            this.gbCargaExcel.Name = "gbCargaExcel";
            this.gbCargaExcel.Size = new System.Drawing.Size(1066, 604);
            this.gbCargaExcel.TabIndex = 44;
            this.gbCargaExcel.TabStop = false;
            this.gbCargaExcel.Text = "Carga desde Excel";
            // 
            // btnEliminaTodo
            // 
            this.btnEliminaTodo.ForeColor = System.Drawing.Color.Black;
            this.btnEliminaTodo.Location = new System.Drawing.Point(403, 70);
            this.btnEliminaTodo.Name = "btnEliminaTodo";
            this.btnEliminaTodo.Size = new System.Drawing.Size(283, 54);
            this.btnEliminaTodo.TabIndex = 34;
            this.btnEliminaTodo.Text = "Eliminar todos los registros de Base de Datos (Botón temporal)";
            this.btnEliminaTodo.UseVisualStyleBackColor = true;
            this.btnEliminaTodo.Click += new System.EventHandler(this.btnEliminaTodo_Click);
            // 
            // gbVistaPrevia
            // 
            this.gbVistaPrevia.Controls.Add(this.gbProgreso);
            this.gbVistaPrevia.Controls.Add(this.dgVistaPrevia);
            this.gbVistaPrevia.ForeColor = System.Drawing.Color.White;
            this.gbVistaPrevia.Location = new System.Drawing.Point(17, 189);
            this.gbVistaPrevia.Name = "gbVistaPrevia";
            this.gbVistaPrevia.Size = new System.Drawing.Size(1043, 364);
            this.gbVistaPrevia.TabIndex = 33;
            this.gbVistaPrevia.TabStop = false;
            this.gbVistaPrevia.Text = "Vista previa";
            this.gbVistaPrevia.Visible = false;
            // 
            // gbProgreso
            // 
            this.gbProgreso.Controls.Add(this.pbGuardado);
            this.gbProgreso.ForeColor = System.Drawing.Color.White;
            this.gbProgreso.Location = new System.Drawing.Point(260, 155);
            this.gbProgreso.Name = "gbProgreso";
            this.gbProgreso.Size = new System.Drawing.Size(552, 93);
            this.gbProgreso.TabIndex = 35;
            this.gbProgreso.TabStop = false;
            this.gbProgreso.Text = "Progreso envío a Base de Datos";
            this.gbProgreso.Visible = false;
            // 
            // pbGuardado
            // 
            this.pbGuardado.Location = new System.Drawing.Point(6, 30);
            this.pbGuardado.Name = "pbGuardado";
            this.pbGuardado.Size = new System.Drawing.Size(540, 43);
            this.pbGuardado.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbGuardado.TabIndex = 34;
            // 
            // dgVistaPrevia
            // 
            this.dgVistaPrevia.AllowUserToResizeRows = false;
            this.dgVistaPrevia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgVistaPrevia.BackgroundColor = System.Drawing.Color.White;
            this.dgVistaPrevia.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgVistaPrevia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgVistaPrevia.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgVistaPrevia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgVistaPrevia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.dgVistaPrevia.Location = new System.Drawing.Point(3, 18);
            this.dgVistaPrevia.Margin = new System.Windows.Forms.Padding(5);
            this.dgVistaPrevia.Name = "dgVistaPrevia";
            this.dgVistaPrevia.RowHeadersVisible = false;
            this.dgVistaPrevia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVistaPrevia.Size = new System.Drawing.Size(1037, 343);
            this.dgVistaPrevia.TabIndex = 44;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(16, 127);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(1031, 59);
            this.lblInfo.TabIndex = 32;
            this.lblInfo.Text = "No se ha seleccionado archivo de carga";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCargaExcel
            // 
            this.btnCargaExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCargaExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnCargaExcel.Image = global::VitalLabSoft.Properties.Resources.cargaExcel;
            this.btnCargaExcel.Location = new System.Drawing.Point(822, 38);
            this.btnCargaExcel.Name = "btnCargaExcel";
            this.btnCargaExcel.Size = new System.Drawing.Size(225, 86);
            this.btnCargaExcel.TabIndex = 31;
            this.btnCargaExcel.Text = "Cargar Excel";
            this.btnCargaExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCargaExcel.UseVisualStyleBackColor = true;
            this.btnCargaExcel.Click += new System.EventHandler(this.btnCargaExcel_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.button1.Image = global::VitalLabSoft.Properties.Resources.ExcelPlantilla;
            this.button1.Location = new System.Drawing.Point(17, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 86);
            this.button1.TabIndex = 30;
            this.button1.Text = "Obtener plantilla";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // frmCargaDesdeExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(1093, 659);
            this.Controls.Add(this.gbCargaExcel);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmCargaDesdeExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmCargaDesdeExcel_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbCargaExcel.ResumeLayout(false);
            this.gbVistaPrevia.ResumeLayout(false);
            this.gbProgreso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVistaPrevia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCerrar;
        private System.Windows.Forms.Button btnNuevoPaquete;
        private System.Windows.Forms.TextBox txtNuevoPaquete;
        private System.Windows.Forms.OpenFileDialog Abrir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbCargaExcel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCargaExcel;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox gbVistaPrevia;
        public System.Windows.Forms.DataGridView dgVistaPrevia;
        private System.Windows.Forms.GroupBox gbProgreso;
        private System.Windows.Forms.ProgressBar pbGuardado;
        private System.Windows.Forms.Button btnEliminaTodo;
    }
}