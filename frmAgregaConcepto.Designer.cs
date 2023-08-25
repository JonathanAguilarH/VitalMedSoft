namespace VitalLabSoft
{
    partial class frmAgregaConcepto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregaConcepto));
            this.rbDeduccion = new System.Windows.Forms.RadioButton();
            this.rbPercepcion = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nPago = new System.Windows.Forms.NumericUpDown();
            this.lblPago = new System.Windows.Forms.Label();
            this.cbConceptoPago = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPago)).BeginInit();
            this.SuspendLayout();
            // 
            // rbDeduccion
            // 
            this.rbDeduccion.AutoSize = true;
            this.rbDeduccion.ForeColor = System.Drawing.Color.White;
            this.rbDeduccion.Location = new System.Drawing.Point(137, 25);
            this.rbDeduccion.Name = "rbDeduccion";
            this.rbDeduccion.Size = new System.Drawing.Size(109, 22);
            this.rbDeduccion.TabIndex = 24;
            this.rbDeduccion.Text = "Deducción";
            this.rbDeduccion.UseVisualStyleBackColor = true;
            // 
            // rbPercepcion
            // 
            this.rbPercepcion.AutoSize = true;
            this.rbPercepcion.Checked = true;
            this.rbPercepcion.ForeColor = System.Drawing.Color.White;
            this.rbPercepcion.Location = new System.Drawing.Point(19, 25);
            this.rbPercepcion.Name = "rbPercepcion";
            this.rbPercepcion.Size = new System.Drawing.Size(112, 22);
            this.rbPercepcion.TabIndex = 23;
            this.rbPercepcion.TabStop = true;
            this.rbPercepcion.Text = "Percepción";
            this.rbPercepcion.UseVisualStyleBackColor = true;
            this.rbPercepcion.CheckedChanged += new System.EventHandler(this.rbPercepcion_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nPago);
            this.groupBox1.Controls.Add(this.lblPago);
            this.groupBox1.Controls.Add(this.cbConceptoPago);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.rbPercepcion);
            this.groupBox1.Controls.Add(this.rbDeduccion);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 126);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo concepto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Concepto:";
            // 
            // nPago
            // 
            this.nPago.DecimalPlaces = 2;
            this.nPago.Location = new System.Drawing.Point(108, 85);
            this.nPago.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nPago.Name = "nPago";
            this.nPago.Size = new System.Drawing.Size(119, 26);
            this.nPago.TabIndex = 28;
            this.nPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.ForeColor = System.Drawing.Color.White;
            this.lblPago.Location = new System.Drawing.Point(40, 87);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(62, 18);
            this.lblPago.TabIndex = 29;
            this.lblPago.Text = "Pago: $";
            // 
            // cbConceptoPago
            // 
            this.cbConceptoPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConceptoPago.DisplayMember = "(ningunos)";
            this.cbConceptoPago.FormattingEnabled = true;
            this.cbConceptoPago.Location = new System.Drawing.Point(108, 53);
            this.cbConceptoPago.Name = "cbConceptoPago";
            this.cbConceptoPago.Size = new System.Drawing.Size(679, 26);
            this.cbConceptoPago.TabIndex = 27;
            this.cbConceptoPago.SelectedIndexChanged += new System.EventHandler(this.cbConceptoPago_SelectedIndexChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(553, 87);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(112, 26);
            this.btnGuardar.TabIndex = 25;
            this.btnGuardar.Text = "Agregar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(675, 87);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 26);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAgregaConcepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(66)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(818, 144);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAgregaConcepto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar concepto";
            this.Load += new System.EventHandler(this.frmAgregaConcepto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rbDeduccion;
        private System.Windows.Forms.RadioButton rbPercepcion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nPago;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.ComboBox cbConceptoPago;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}