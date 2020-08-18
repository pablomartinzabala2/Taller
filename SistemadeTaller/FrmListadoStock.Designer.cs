namespace SistemadeTaller
{
    partial class FrmListadoStock
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
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLinterna = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnImprimirOrden = new System.Windows.Forms.Button();
            this.grpBoxOrden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxOrden
            // 
            this.grpBoxOrden.Controls.Add(this.btnLinterna);
            this.grpBoxOrden.Controls.Add(this.btnBuscar);
            this.grpBoxOrden.Controls.Add(this.btnImprimirOrden);
            this.grpBoxOrden.Controls.Add(this.txtNombre);
            this.grpBoxOrden.Controls.Add(this.Grilla);
            this.grpBoxOrden.Controls.Add(this.label2);
            this.grpBoxOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxOrden.Location = new System.Drawing.Point(12, 10);
            this.grpBoxOrden.Name = "grpBoxOrden";
            this.grpBoxOrden.Size = new System.Drawing.Size(799, 454);
            this.grpBoxOrden.TabIndex = 7;
            this.grpBoxOrden.TabStop = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(6, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(245, 23);
            this.txtNombre.TabIndex = 64;
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(6, 66);
            this.Grilla.Name = "Grilla";
            this.Grilla.ReadOnly = true;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(775, 364);
            this.Grilla.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(775, 25);
            this.label2.TabIndex = 58;
            this.label2.Text = "LISTADO DE RESPUESTO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLinterna
            // 
            this.btnLinterna.Image = global::SistemadeTaller.Properties.Resources.Linterna;
            this.btnLinterna.Location = new System.Drawing.Point(331, 5);
            this.btnLinterna.Name = "btnLinterna";
            this.btnLinterna.Size = new System.Drawing.Size(31, 31);
            this.btnLinterna.TabIndex = 74;
            this.btnLinterna.UseVisualStyleBackColor = true;
            this.btnLinterna.Click += new System.EventHandler(this.btnLinterna_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::SistemadeTaller.Properties.Resources.zoom;
            this.btnBuscar.Location = new System.Drawing.Point(257, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(31, 31);
            this.btnBuscar.TabIndex = 73;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnImprimirOrden
            // 
            this.btnImprimirOrden.Image = global::SistemadeTaller.Properties.Resources.printer;
            this.btnImprimirOrden.Location = new System.Drawing.Point(294, 5);
            this.btnImprimirOrden.Name = "btnImprimirOrden";
            this.btnImprimirOrden.Size = new System.Drawing.Size(31, 31);
            this.btnImprimirOrden.TabIndex = 72;
            this.btnImprimirOrden.UseVisualStyleBackColor = true;
            this.btnImprimirOrden.Click += new System.EventHandler(this.btnImprimirOrden_Click);
            // 
            // FrmListadoStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(809, 476);
            this.Controls.Add(this.grpBoxOrden);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListadoStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de stock";
            this.Load += new System.EventHandler(this.FrmListadoStock_Load);
            this.grpBoxOrden.ResumeLayout(false);
            this.grpBoxOrden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxOrden;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnImprimirOrden;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLinterna;
    }
}