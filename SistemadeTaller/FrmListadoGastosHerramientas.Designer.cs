namespace SistemadeTaller
{
    partial class FrmListadoGastosHerramientas
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
            this.grpBoxOrden = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.txtFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.txtFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarOrden = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.grpBoxOrden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxOrden
            // 
            this.grpBoxOrden.Controls.Add(this.btnAnular);
            this.grpBoxOrden.Controls.Add(this.btnAgregar);
            this.grpBoxOrden.Controls.Add(this.txtNombre);
            this.grpBoxOrden.Controls.Add(this.txtTotal);
            this.grpBoxOrden.Controls.Add(this.label4);
            this.grpBoxOrden.Controls.Add(this.label3);
            this.grpBoxOrden.Controls.Add(this.Grilla);
            this.grpBoxOrden.Controls.Add(this.txtFechaHasta);
            this.grpBoxOrden.Controls.Add(this.txtFechaDesde);
            this.grpBoxOrden.Controls.Add(this.label2);
            this.grpBoxOrden.Controls.Add(this.btnBuscarOrden);
            this.grpBoxOrden.Controls.Add(this.label1);
            this.grpBoxOrden.Controls.Add(this.lblFecha);
            this.grpBoxOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxOrden.Location = new System.Drawing.Point(12, -19);
            this.grpBoxOrden.Name = "grpBoxOrden";
            this.grpBoxOrden.Size = new System.Drawing.Size(893, 473);
            this.grpBoxOrden.TabIndex = 5;
            this.grpBoxOrden.TabStop = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(436, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(186, 23);
            this.txtNombre.TabIndex = 96;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(766, 441);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(105, 23);
            this.txtTotal.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(720, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 94;
            this.label3.Text = "Total";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(0, 96);
            this.Grilla.Name = "Grilla";
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(862, 333);
            this.Grilla.TabIndex = 63;
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(279, 33);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(76, 23);
            this.txtFechaHasta.TabIndex = 60;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(108, 33);
            this.txtFechaDesde.Mask = "00/00/0000";
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(76, 23);
            this.txtFechaDesde.TabIndex = 59;
            this.txtFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(0, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(862, 25);
            this.label2.TabIndex = 58;
            this.label2.Text = "Listado de Herramientas";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuscarOrden
            // 
            this.btnBuscarOrden.Location = new System.Drawing.Point(628, 23);
            this.btnBuscarOrden.Name = "btnBuscarOrden";
            this.btnBuscarOrden.Size = new System.Drawing.Size(77, 30);
            this.btnBuscarOrden.TabIndex = 55;
            this.btnBuscarOrden.Text = "Buscar";
            this.btnBuscarOrden.UseVisualStyleBackColor = true;
            this.btnBuscarOrden.Click += new System.EventHandler(this.btnBuscarOrden_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 54;
            this.label1.Text = "Fecha Hasta:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(6, 33);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(96, 17);
            this.lblFecha.TabIndex = 45;
            this.lblFecha.Text = "Fecha Desde:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 95;
            this.label4.Text = "Descripción";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(711, 23);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(77, 30);
            this.btnAgregar.TabIndex = 97;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.Location = new System.Drawing.Point(794, 25);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(77, 30);
            this.btnAnular.TabIndex = 98;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // FrmListadoGastosHerramientas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(901, 466);
            this.Controls.Add(this.grpBoxOrden);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListadoGastosHerramientas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmListadoGastosHerramientas";
            this.Load += new System.EventHandler(this.FrmListadoGastosHerramientas_Load);
            this.grpBoxOrden.ResumeLayout(false);
            this.grpBoxOrden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxOrden;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.MaskedTextBox txtFechaHasta;
        private System.Windows.Forms.MaskedTextBox txtFechaDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarOrden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnAnular;
    }
}