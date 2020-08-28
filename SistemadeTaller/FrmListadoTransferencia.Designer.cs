namespace SistemadeTaller
{
    partial class FrmListadoTransferencia
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
            this.grupo = new System.Windows.Forms.GroupBox();
            this.btnBuscarOrden = new System.Windows.Forms.Button();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.txtFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.txtFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.txtFechaCobro = new System.Windows.Forms.MaskedTextBox();
            this.btnAnular = new System.Windows.Forms.Button();
            this.grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // grupo
            // 
            this.grupo.Controls.Add(this.btnAnular);
            this.grupo.Controls.Add(this.txtFechaCobro);
            this.grupo.Controls.Add(this.btnCobrar);
            this.grupo.Controls.Add(this.label3);
            this.grupo.Controls.Add(this.btnBuscarOrden);
            this.grupo.Controls.Add(this.Grilla);
            this.grupo.Controls.Add(this.txtFechaHasta);
            this.grupo.Controls.Add(this.txtFechaDesde);
            this.grupo.Controls.Add(this.label2);
            this.grupo.Controls.Add(this.label1);
            this.grupo.Controls.Add(this.lblFecha);
            this.grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupo.Location = new System.Drawing.Point(12, -2);
            this.grupo.Name = "grupo";
            this.grupo.Size = new System.Drawing.Size(824, 444);
            this.grupo.TabIndex = 7;
            this.grupo.TabStop = false;
            // 
            // btnBuscarOrden
            // 
            this.btnBuscarOrden.Location = new System.Drawing.Point(370, 13);
            this.btnBuscarOrden.Name = "btnBuscarOrden";
            this.btnBuscarOrden.Size = new System.Drawing.Size(77, 30);
            this.btnBuscarOrden.TabIndex = 64;
            this.btnBuscarOrden.Text = "Buscar";
            this.btnBuscarOrden.UseVisualStyleBackColor = true;
            this.btnBuscarOrden.Click += new System.EventHandler(this.btnBuscarOrden_Click);
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(6, 82);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(793, 341);
            this.Grilla.TabIndex = 63;
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(288, 17);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(76, 23);
            this.txtFechaHasta.TabIndex = 60;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(108, 16);
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
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(790, 25);
            this.label2.TabIndex = 58;
            this.label2.Text = "LISTADO DE TARJETAS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 54;
            this.label1.Text = "Fecha Hasta:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(6, 19);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(96, 17);
            this.lblFecha.TabIndex = 45;
            this.lblFecha.Text = "Fecha Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 65;
            this.label3.Text = "Fecha Cobro";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCobrar
            // 
            this.btnCobrar.Location = new System.Drawing.Point(630, 13);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(77, 30);
            this.btnCobrar.TabIndex = 66;
            this.btnCobrar.Text = "Transferir";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // txtFechaCobro
            // 
            this.txtFechaCobro.Location = new System.Drawing.Point(548, 17);
            this.txtFechaCobro.Mask = "00/00/0000";
            this.txtFechaCobro.Name = "txtFechaCobro";
            this.txtFechaCobro.Size = new System.Drawing.Size(76, 23);
            this.txtFechaCobro.TabIndex = 67;
            this.txtFechaCobro.ValidatingType = typeof(System.DateTime);
            // 
            // btnAnular
            // 
            this.btnAnular.Location = new System.Drawing.Point(713, 12);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(77, 30);
            this.btnAnular.TabIndex = 68;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // FrmListadoTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(848, 454);
            this.Controls.Add(this.grupo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListadoTransferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmListadoTransferencia_Load);
            this.grupo.ResumeLayout(false);
            this.grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupo;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.MaskedTextBox txtFechaHasta;
        private System.Windows.Forms.MaskedTextBox txtFechaDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnBuscarOrden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.MaskedTextBox txtFechaCobro;
        private System.Windows.Forms.Button btnAnular;
    }
}