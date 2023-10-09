namespace SistemadeTaller
{
    partial class FrmListadoMovimiento
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
            this.label2 = new System.Windows.Forms.Label();
            this.CmbTipo = new System.Windows.Forms.ComboBox();
            this.btnVerDocumento = new System.Windows.Forms.Button();
            this.dpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label43 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbTipo);
            this.groupBox1.Controls.Add(this.btnVerDocumento);
            this.groupBox1.Controls.Add(this.dpFechaHasta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dpFechaDesde);
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(675, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Movimientos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(306, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 86;
            this.label2.Text = "Tipo";
            // 
            // CmbTipo
            // 
            this.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipo.FormattingEnabled = true;
            this.CmbTipo.Location = new System.Drawing.Point(348, 21);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new System.Drawing.Size(133, 24);
            this.CmbTipo.TabIndex = 85;
            // 
            // btnVerDocumento
            // 
            this.btnVerDocumento.Image = global::SistemadeTaller.Properties.Resources.zoom;
            this.btnVerDocumento.Location = new System.Drawing.Point(496, 18);
            this.btnVerDocumento.Name = "btnVerDocumento";
            this.btnVerDocumento.Size = new System.Drawing.Size(31, 28);
            this.btnVerDocumento.TabIndex = 84;
            this.btnVerDocumento.UseVisualStyleBackColor = true;
            this.btnVerDocumento.Click += new System.EventHandler(this.btnVerDocumento_Click);
            // 
            // dpFechaHasta
            // 
            this.dpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaHasta.Location = new System.Drawing.Point(202, 24);
            this.dpFechaHasta.Name = "dpFechaHasta";
            this.dpFechaHasta.Size = new System.Drawing.Size(87, 23);
            this.dpFechaHasta.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(151, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 82;
            this.label1.Text = "Hasta";
            // 
            // dpFechaDesde
            // 
            this.dpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFechaDesde.Location = new System.Drawing.Point(58, 26);
            this.dpFechaDesde.Name = "dpFechaDesde";
            this.dpFechaDesde.Size = new System.Drawing.Size(87, 23);
            this.dpFechaDesde.TabIndex = 81;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label43.Location = new System.Drawing.Point(3, 25);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(49, 17);
            this.label43.TabIndex = 80;
            this.label43.Text = "Desde";
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(11, 65);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(688, 337);
            this.Grilla.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(557, 411);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 87;
            this.label3.Text = "Total";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.Location = new System.Drawing.Point(599, 408);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(100, 23);
            this.txtSaldo.TabIndex = 88;
            // 
            // FrmListadoMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(705, 437);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Grilla);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListadoMovimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Movimientos";
            this.Load += new System.EventHandler(this.FrmListadoMovimiento_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dpFechaHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpFechaDesde;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Button btnVerDocumento;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.ComboBox CmbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaldo;
    }
}