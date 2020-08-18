namespace SistemadeTaller
{
    partial class FrmEjecutarOrden
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
            this.btnImprimirSolicitud = new System.Windows.Forms.Button();
            this.btnEliminarOrden = new System.Windows.Forms.Button();
            this.CmbTipo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOrdenesSinSaldo = new System.Windows.Forms.Label();
            this.lblOrdenesConSaldo = new System.Windows.Forms.Label();
            this.lblAmarillo = new System.Windows.Forms.Label();
            this.grdOrdenes = new System.Windows.Forms.DataGridView();
            this.txtNroOrden = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImprimirOrden = new System.Windows.Forms.Button();
            this.btnVetOrden = new System.Windows.Forms.Button();
            this.txtFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.txtFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarOrden = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.grpBoxOrden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxOrden
            // 
            this.grpBoxOrden.Controls.Add(this.btnImprimirSolicitud);
            this.grpBoxOrden.Controls.Add(this.btnEliminarOrden);
            this.grpBoxOrden.Controls.Add(this.CmbTipo);
            this.grpBoxOrden.Controls.Add(this.label7);
            this.grpBoxOrden.Controls.Add(this.lblOrdenesSinSaldo);
            this.grpBoxOrden.Controls.Add(this.lblOrdenesConSaldo);
            this.grpBoxOrden.Controls.Add(this.lblAmarillo);
            this.grpBoxOrden.Controls.Add(this.grdOrdenes);
            this.grpBoxOrden.Controls.Add(this.txtNroOrden);
            this.grpBoxOrden.Controls.Add(this.label6);
            this.grpBoxOrden.Controls.Add(this.txtApellido);
            this.grpBoxOrden.Controls.Add(this.label5);
            this.grpBoxOrden.Controls.Add(this.txtPatente);
            this.grpBoxOrden.Controls.Add(this.label4);
            this.grpBoxOrden.Controls.Add(this.txtCantidad);
            this.grpBoxOrden.Controls.Add(this.txtTotal);
            this.grpBoxOrden.Controls.Add(this.lblTotal);
            this.grpBoxOrden.Controls.Add(this.label3);
            this.grpBoxOrden.Controls.Add(this.btnImprimirOrden);
            this.grpBoxOrden.Controls.Add(this.btnVetOrden);
            this.grpBoxOrden.Controls.Add(this.txtFechaHasta);
            this.grpBoxOrden.Controls.Add(this.txtFechaDesde);
            this.grpBoxOrden.Controls.Add(this.label2);
            this.grpBoxOrden.Controls.Add(this.btnBuscarOrden);
            this.grpBoxOrden.Controls.Add(this.label1);
            this.grpBoxOrden.Controls.Add(this.lblFecha);
            this.grpBoxOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxOrden.Location = new System.Drawing.Point(14, 9);
            this.grpBoxOrden.Name = "grpBoxOrden";
            this.grpBoxOrden.Size = new System.Drawing.Size(1116, 513);
            this.grpBoxOrden.TabIndex = 3;
            this.grpBoxOrden.TabStop = false;
            // 
            // btnImprimirSolicitud
            // 
            this.btnImprimirSolicitud.Location = new System.Drawing.Point(906, 45);
            this.btnImprimirSolicitud.Name = "btnImprimirSolicitud";
            this.btnImprimirSolicitud.Size = new System.Drawing.Size(77, 30);
            this.btnImprimirSolicitud.TabIndex = 89;
            this.btnImprimirSolicitud.Text = "Solicitud";
            this.btnImprimirSolicitud.UseVisualStyleBackColor = true;
            this.btnImprimirSolicitud.Click += new System.EventHandler(this.btnImprimirSolicitud_Click);
            // 
            // btnEliminarOrden
            // 
            this.btnEliminarOrden.Image = global::SistemadeTaller.Properties.Resources.cancel;
            this.btnEliminarOrden.Location = new System.Drawing.Point(1033, 10);
            this.btnEliminarOrden.Name = "btnEliminarOrden";
            this.btnEliminarOrden.Size = new System.Drawing.Size(31, 28);
            this.btnEliminarOrden.TabIndex = 88;
            this.btnEliminarOrden.UseVisualStyleBackColor = true;
            this.btnEliminarOrden.Visible = false;
            this.btnEliminarOrden.Click += new System.EventHandler(this.btnEliminarOrden_Click);
            // 
            // CmbTipo
            // 
            this.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipo.FormattingEnabled = true;
            this.CmbTipo.Location = new System.Drawing.Point(108, 48);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new System.Drawing.Size(208, 24);
            this.CmbTipo.TabIndex = 87;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 17);
            this.label7.TabIndex = 86;
            this.label7.Text = "Tipo de orden";
            // 
            // lblOrdenesSinSaldo
            // 
            this.lblOrdenesSinSaldo.AutoSize = true;
            this.lblOrdenesSinSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenesSinSaldo.Location = new System.Drawing.Point(360, 464);
            this.lblOrdenesSinSaldo.Name = "lblOrdenesSinSaldo";
            this.lblOrdenesSinSaldo.Size = new System.Drawing.Size(149, 17);
            this.lblOrdenesSinSaldo.TabIndex = 85;
            this.lblOrdenesSinSaldo.Text = "Ordenes Con Saldo";
            // 
            // lblOrdenesConSaldo
            // 
            this.lblOrdenesConSaldo.AutoSize = true;
            this.lblOrdenesConSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenesConSaldo.Location = new System.Drawing.Point(200, 464);
            this.lblOrdenesConSaldo.Name = "lblOrdenesConSaldo";
            this.lblOrdenesConSaldo.Size = new System.Drawing.Size(144, 17);
            this.lblOrdenesConSaldo.TabIndex = 84;
            this.lblOrdenesConSaldo.Text = "Ordenes Sin Saldo";
            // 
            // lblAmarillo
            // 
            this.lblAmarillo.AutoSize = true;
            this.lblAmarillo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmarillo.Location = new System.Drawing.Point(9, 464);
            this.lblAmarillo.Name = "lblAmarillo";
            this.lblAmarillo.Size = new System.Drawing.Size(185, 17);
            this.lblAmarillo.TabIndex = 83;
            this.lblAmarillo.Text = "Ordenes Pre Ingresadas";
            // 
            // grdOrdenes
            // 
            this.grdOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrdenes.Location = new System.Drawing.Point(6, 103);
            this.grdOrdenes.Name = "grdOrdenes";
            this.grdOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOrdenes.Size = new System.Drawing.Size(1110, 352);
            this.grdOrdenes.TabIndex = 82;
            // 
            // txtNroOrden
            // 
            this.txtNroOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroOrden.Location = new System.Drawing.Point(808, 15);
            this.txtNroOrden.Name = "txtNroOrden";
            this.txtNroOrden.Size = new System.Drawing.Size(62, 23);
            this.txtNroOrden.TabIndex = 81;
            this.txtNroOrden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroOrden_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(754, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 80;
            this.label6.Text = "Orden";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtApellido
            // 
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Location = new System.Drawing.Point(593, 18);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(155, 23);
            this.txtApellido.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(529, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 78;
            this.label5.Text = "Apellido";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPatente
            // 
            this.txtPatente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPatente.Location = new System.Drawing.Point(423, 18);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(100, 23);
            this.txtPatente.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 76;
            this.label4.Text = "Patente";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(856, 455);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 23);
            this.txtCantidad.TabIndex = 75;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(1016, 455);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 23);
            this.txtTotal.TabIndex = 74;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(972, 458);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(40, 17);
            this.lblTotal.TabIndex = 73;
            this.lblTotal.Text = "Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(786, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 72;
            this.label3.Text = "Cantidad";
            // 
            // btnImprimirOrden
            // 
            this.btnImprimirOrden.Image = global::SistemadeTaller.Properties.Resources.printer;
            this.btnImprimirOrden.Location = new System.Drawing.Point(996, 12);
            this.btnImprimirOrden.Name = "btnImprimirOrden";
            this.btnImprimirOrden.Size = new System.Drawing.Size(31, 28);
            this.btnImprimirOrden.TabIndex = 71;
            this.btnImprimirOrden.UseVisualStyleBackColor = true;
            this.btnImprimirOrden.Click += new System.EventHandler(this.btnImprimirOrden_Click);
            // 
            // btnVetOrden
            // 
            this.btnVetOrden.Image = global::SistemadeTaller.Properties.Resources.zoom;
            this.btnVetOrden.Location = new System.Drawing.Point(959, 11);
            this.btnVetOrden.Name = "btnVetOrden";
            this.btnVetOrden.Size = new System.Drawing.Size(31, 28);
            this.btnVetOrden.TabIndex = 70;
            this.btnVetOrden.UseVisualStyleBackColor = true;
            this.btnVetOrden.Click += new System.EventHandler(this.btnVetOrden_Click);
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(278, 18);
            this.txtFechaHasta.Mask = "00/00/0000";
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(76, 23);
            this.txtFechaHasta.TabIndex = 60;
            this.txtFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(108, 18);
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
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1112, 25);
            this.label2.TabIndex = 58;
            this.label2.Text = "LISTADO DE ORDENES DE TRABAJO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuscarOrden
            // 
            this.btnBuscarOrden.Location = new System.Drawing.Point(876, 13);
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
            this.label1.Location = new System.Drawing.Point(190, 19);
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
            // FrmEjecutarOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1142, 517);
            this.Controls.Add(this.grpBoxOrden);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEjecutarOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de ordenes de trabajo";
            this.Load += new System.EventHandler(this.FrmEjecutarOrden_Load);
            this.grpBoxOrden.ResumeLayout(false);
            this.grpBoxOrden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrdenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxOrden;
        private System.Windows.Forms.Button btnBuscarOrden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtFechaHasta;
        private System.Windows.Forms.MaskedTextBox txtFechaDesde;
        private System.Windows.Forms.Button btnVetOrden;
        private System.Windows.Forms.Button btnImprimirOrden;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNroOrden;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grdOrdenes;
        private System.Windows.Forms.Label lblAmarillo;
        private System.Windows.Forms.Label lblOrdenesConSaldo;
        private System.Windows.Forms.Label lblOrdenesSinSaldo;
        private System.Windows.Forms.ComboBox CmbTipo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEliminarOrden;
        private System.Windows.Forms.Button btnImprimirSolicitud;
    }
}