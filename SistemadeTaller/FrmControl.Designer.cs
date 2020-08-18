namespace SistemadeTaller
{
    partial class FrmControl
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
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.txtCupon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodOrden = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVencidas = new System.Windows.Forms.Label();
            this.ChkVencida = new System.Windows.Forms.CheckBox();
            this.btnCobroPrenda = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.MaskedTextBox();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.txtCupon);
            this.Grupo.Controls.Add(this.label7);
            this.Grupo.Controls.Add(this.txtCodOrden);
            this.Grupo.Controls.Add(this.label6);
            this.Grupo.Controls.Add(this.lblVencidas);
            this.Grupo.Controls.Add(this.ChkVencida);
            this.Grupo.Controls.Add(this.btnCobroPrenda);
            this.Grupo.Controls.Add(this.label4);
            this.Grupo.Controls.Add(this.txtFecha);
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.btnBuscar);
            this.Grupo.Controls.Add(this.txtApellido);
            this.Grupo.Controls.Add(this.txtPatente);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(1166, 498);
            this.Grupo.TabIndex = 61;
            this.Grupo.TabStop = false;
            // 
            // txtCupon
            // 
            this.txtCupon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCupon.Location = new System.Drawing.Point(724, 13);
            this.txtCupon.Name = "txtCupon";
            this.txtCupon.Size = new System.Drawing.Size(84, 23);
            this.txtCupon.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(669, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 67;
            this.label7.Text = "Cupón";
            // 
            // txtCodOrden
            // 
            this.txtCodOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodOrden.Location = new System.Drawing.Point(453, 12);
            this.txtCodOrden.Name = "txtCodOrden";
            this.txtCodOrden.Size = new System.Drawing.Size(84, 23);
            this.txtCodOrden.TabIndex = 66;
            this.txtCodOrden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodOrden_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 65;
            this.label6.Text = "Orden";
            // 
            // lblVencidas
            // 
            this.lblVencidas.AutoSize = true;
            this.lblVencidas.Location = new System.Drawing.Point(1005, 12);
            this.lblVencidas.Name = "lblVencidas";
            this.lblVencidas.Size = new System.Drawing.Size(66, 17);
            this.lblVencidas.TabIndex = 64;
            this.lblVencidas.Text = "Vencidas";
            // 
            // ChkVencida
            // 
            this.ChkVencida.AutoSize = true;
            this.ChkVencida.Checked = true;
            this.ChkVencida.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkVencida.Location = new System.Drawing.Point(822, 15);
            this.ChkVencida.Name = "ChkVencida";
            this.ChkVencida.Size = new System.Drawing.Size(85, 21);
            this.ChkVencida.TabIndex = 63;
            this.ChkVencida.Text = "Vencidas";
            this.ChkVencida.UseVisualStyleBackColor = true;
            // 
            // btnCobroPrenda
            // 
            this.btnCobroPrenda.Image = global::SistemadeTaller.Properties.Resources.money_euro1;
            this.btnCobroPrenda.Location = new System.Drawing.Point(959, 7);
            this.btnCobroPrenda.Name = "btnCobroPrenda";
            this.btnCobroPrenda.Size = new System.Drawing.Size(40, 26);
            this.btnCobroPrenda.TabIndex = 62;
            this.btnCobroPrenda.UseVisualStyleBackColor = true;
            this.btnCobroPrenda.Click += new System.EventHandler(this.btnCobroPrenda_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(543, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 61;
            this.label4.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(587, 12);
            this.txtFecha.Mask = "00/00/0000";
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(76, 23);
            this.txtFecha.TabIndex = 60;
            this.txtFecha.ValidatingType = typeof(System.DateTime);
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(10, 67);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(1150, 389);
            this.Grilla.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1150, 25);
            this.label2.TabIndex = 59;
            this.label2.Text = "Control de operaciones";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::SistemadeTaller.Properties.Resources.zoom;
            this.btnBuscar.Location = new System.Drawing.Point(913, 7);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(40, 26);
            this.btnBuscar.TabIndex = 51;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Location = new System.Drawing.Point(240, 13);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(153, 23);
            this.txtApellido.TabIndex = 3;
            // 
            // txtPatente
            // 
            this.txtPatente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPatente.Location = new System.Drawing.Point(70, 13);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(100, 23);
            this.txtPatente.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1017, 483);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 62;
            this.label5.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTotal.Location = new System.Drawing.Point(1072, 480);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 23);
            this.txtTotal.TabIndex = 63;
            // 
            // FrmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1180, 514);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Grupo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmControl";
            this.Load += new System.EventHandler(this.FrmControl_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.Label lblVencidas;
        private System.Windows.Forms.CheckBox ChkVencida;
        private System.Windows.Forms.Button btnCobroPrenda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtFecha;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtCodOrden;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCupon;
        private System.Windows.Forms.Label label7;
    }
}