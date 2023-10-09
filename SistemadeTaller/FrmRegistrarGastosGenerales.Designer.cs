namespace SistemadeTaller
{
    partial class FrmRegistrarGastosGenerales
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
            this.lblMecanico = new System.Windows.Forms.Label();
            this.CmbMecanico = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblMecanico);
            this.groupBox1.Controls.Add(this.CmbMecanico);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbConcepto);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.txtEfectivo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 353);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar pago de gastos generales";
            // 
            // lblMecanico
            // 
            this.lblMecanico.AutoSize = true;
            this.lblMecanico.Location = new System.Drawing.Point(34, 117);
            this.lblMecanico.Name = "lblMecanico";
            this.lblMecanico.Size = new System.Drawing.Size(68, 17);
            this.lblMecanico.TabIndex = 29;
            this.lblMecanico.Text = "Mecánico";
            this.lblMecanico.Visible = false;
            // 
            // CmbMecanico
            // 
            this.CmbMecanico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMecanico.FormattingEnabled = true;
            this.CmbMecanico.Location = new System.Drawing.Point(117, 117);
            this.CmbMecanico.Name = "CmbMecanico";
            this.CmbMecanico.Size = new System.Drawing.Size(256, 24);
            this.CmbMecanico.TabIndex = 28;
            this.CmbMecanico.Visible = false;
            // 
            // button1
            // 
            this.button1.Image = global::SistemadeTaller.Properties.Resources.page_add;
            this.button1.Location = new System.Drawing.Point(382, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 28);
            this.button1.TabIndex = 27;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Concepto";
            // 
            // cmbConcepto
            // 
            this.cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcepto.FormattingEnabled = true;
            this.cmbConcepto.Location = new System.Drawing.Point(117, 87);
            this.cmbConcepto.Name = "cmbConcepto";
            this.cmbConcepto.Size = new System.Drawing.Size(256, 24);
            this.cmbConcepto.TabIndex = 25;
            this.cmbConcepto.SelectedIndexChanged += new System.EventHandler(this.cmbConcepto_SelectedIndexChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(117, 174);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(305, 103);
            this.txtDescripcion.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Descripción";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(117, 29);
            this.txtFecha.Mask = "00/00/0000";
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 23);
            this.txtFecha.TabIndex = 22;
            this.txtFecha.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(117, 294);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 37);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Location = new System.Drawing.Point(117, 57);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(100, 23);
            this.txtEfectivo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = " Monto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "Tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(117, 147);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(256, 24);
            this.cmbTipo.TabIndex = 31;
            // 
            // FrmRegistrarGastosGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(466, 396);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegistrarGastosGenerales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gastos Generales";
            this.Load += new System.EventHandler(this.FrmRegistrarGastosGenerales_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMecanico;
        private System.Windows.Forms.ComboBox CmbMecanico;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label5;
    }
}