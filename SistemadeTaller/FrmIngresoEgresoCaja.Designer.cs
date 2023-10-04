namespace SistemadeTaller
{
    partial class FrmIngresoEgresoCaja
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.label43 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbTipoOperacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.CmbTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CmbTipo);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.txtImporte);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbTipoOperacion);
            this.groupBox1.Controls.Add(this.dpFecha);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 287);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movimientos de Caja";
            // 
            // dpFecha
            // 
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(105, 40);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(87, 23);
            this.dpFecha.TabIndex = 83;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label43.Location = new System.Drawing.Point(18, 38);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(47, 17);
            this.label43.TabIndex = 82;
            this.label43.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(17, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 88;
            this.label2.Text = "Operación";
            // 
            // CmbTipoOperacion
            // 
            this.CmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoOperacion.FormattingEnabled = true;
            this.CmbTipoOperacion.Location = new System.Drawing.Point(104, 69);
            this.CmbTipoOperacion.Name = "CmbTipoOperacion";
            this.CmbTipoOperacion.Size = new System.Drawing.Size(161, 24);
            this.CmbTipoOperacion.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(17, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 89;
            this.label1.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(105, 127);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(374, 23);
            this.txtDescripcion.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(17, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 91;
            this.label3.Text = "Importe";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(104, 156);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(160, 23);
            this.txtImporte.TabIndex = 92;
            this.txtImporte.Leave += new System.EventHandler(this.txtImporte_Leave);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(105, 196);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 93;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // CmbTipo
            // 
            this.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipo.FormattingEnabled = true;
            this.CmbTipo.Location = new System.Drawing.Point(103, 99);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new System.Drawing.Size(161, 24);
            this.CmbTipo.TabIndex = 94;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(17, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 95;
            this.label4.Text = "Tipo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(189, 196);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 96;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmIngresoEgresoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(534, 367);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmIngresoEgresoCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario de Caja";
            this.Load += new System.EventHandler(this.FrmIngresoEgresoCaja_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbTipoOperacion;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbTipo;
        private System.Windows.Forms.Button btnCancelar;
    }
}